//+---------------------------------------------------------------------------
//
//  Copyright ( C ) Microsoft, 2002.
//
//  File:       shared_any.cpp
//
//  Contents:   pool allocator for reference counts
//
//  Classes:    ref_count_allocator and helpers
//
//  Functions:
//
//  Author:     Eric Niebler ( ericne@microsoft.com )
//
//----------------------------------------------------------------------------


#ifdef _MT
# ifndef _WIN32_WINNT
#  define _WIN32_WINNT 0x0403
# endif
# include <windows.h>
#endif

#include <cassert>
#include <functional>  // for std::less
#include <algorithm>   // for std::swap
#include "shared_any.h"
#include "scoped_any.h"

namespace detail
{
    namespace
    {
        class critsec
        {
#ifdef _MT
            CRITICAL_SECTION m_cs;

            critsec()
            {
                InitializeCriticalSectionAndSpinCount( &m_cs, 4000 );
                ++initialized;
            }
            ~critsec()
            {
                --initialized;
                DeleteCriticalSection( &m_cs );
            }

        public:

            void enter()
            {
                if( initialized )
                    EnterCriticalSection( &m_cs );
            }
            void leave()
            {
                if( initialized )
                    LeaveCriticalSection( &m_cs );
            }
#endif
        public:

            static int     initialized;
            static critsec instance;
        };
        
        int     critsec::initialized = 0;
        critsec critsec::instance;
    }

    struct lock
    {
#ifdef _MT
        critsec & m_cs;

        explicit lock( critsec & cs )
            : m_cs(cs)
        {
            m_cs.enter();
        }
        ~lock()
        {
            m_cs.leave();
        }
#else
        explicit lock( critsec & )
        {
        }
#endif
    private:
        lock( lock const & );
        lock & operator=( lock const & );
    };

    struct ref_count_block
    {
        static long const s_sizeBlock = 256;

        short m_free_list; // offset to start of freelist
        short m_available; // count of refcounts in this block that are available
        long  m_refcounts[ s_sizeBlock ];
        
        ref_count_block()
            : m_free_list(0)
            , m_available(s_sizeBlock)
        {
            for( long l=0; l<s_sizeBlock; ++l )
                m_refcounts[l] = l+1;
        }
        
        bool empty() const // throw()
        {
            return s_sizeBlock == m_available;
        }
        
        bool full() const // throw()
        {
            return 0 == m_available;
        }
        
        long volatile *alloc( lock & )
        {
            assert( 0 != m_available );
            long *refcount = m_refcounts + m_free_list;
            m_free_list = static_cast<short>( *refcount );
            --m_available;
            return refcount;
        }
        
        void free( long volatile *refcount, lock & ) // throw()
        {
            assert( owns( refcount ) );
            *refcount = m_free_list;
            m_free_list = static_cast<short>( refcount - m_refcounts );
            ++m_available;
        }
        
        bool owns( long volatile *refcount ) const // throw()
        {
            return ! std::less<void*>()( const_cast<long*>( refcount ), const_cast<long*>( m_refcounts ) ) &&
                    std::less<void*>()( const_cast<long*>( refcount ), const_cast<long*>( m_refcounts ) + s_sizeBlock );
        }
    };


    struct ref_count_allocator::node
    {
        node           *m_next;
        node           *m_prev;
        ref_count_block m_block;
        explicit node( node *next=0, node *prev=0 )
            : m_next(next)
            , m_prev(prev)
            , m_block()
        {
            if( m_next )
                m_next->m_prev = this;
            if( m_prev )
                m_prev->m_next = this;
        }
    };

    
    void ref_count_allocator::finalize()
    {
        lock l( critsec::instance );
        for( node *next; m_list_blocks; m_list_blocks=next )
        {
            next = m_list_blocks->m_next;
            delete m_list_blocks;
        }
        m_last_alloc = 0;
        m_last_free = 0;
    }
    
    long volatile *ref_count_allocator::alloc()
    {
        lock l( critsec::instance );
        if( ! m_last_alloc || m_last_alloc->m_block.full() )
        {
            for( m_last_alloc = m_list_blocks; 
                m_last_alloc && m_last_alloc->m_block.full();
                m_last_alloc = m_last_alloc->m_next );
            if( ! m_last_alloc )
            {
                m_last_alloc = new( std::nothrow ) node( m_list_blocks );
                if( ! m_last_alloc )
                    return 0;
                m_list_blocks = m_last_alloc;
            }
        }
        return m_last_alloc->m_block.alloc( l );
    }

    long volatile *ref_count_allocator::alloc( long val )
    {
        long volatile *refcount = alloc();
        *refcount = val;
        return refcount;
    }
    
    void ref_count_allocator::free( long volatile *refcount ) // throw()
    {
        // don't rearrange the order of these locals!
        scoped_any<node*,close_delete> scoped_last_free;
        lock l( critsec::instance );

        if( ! m_last_free || ! m_last_free->m_block.owns( refcount ) )
        {
            for( m_last_free = m_list_blocks; 
                m_last_free && ! m_last_free->m_block.owns( refcount );
                m_last_free = m_last_free->m_next );
        }
        
        assert( m_last_free && m_last_free->m_block.owns( refcount ) );
        m_last_free->m_block.free( refcount, l );
        
        if( m_last_free != m_list_blocks && m_last_free->m_block.empty() )
        {
            if( 0 != ( m_last_free->m_prev->m_next = m_last_free->m_next ) )
                m_last_free->m_next->m_prev = m_last_free->m_prev;
            
            if( ! m_list_blocks->m_block.empty() )
            {
                m_last_free->m_next = m_list_blocks;
                m_last_free->m_prev = 0;
                m_list_blocks->m_prev = m_last_free;
                m_list_blocks = m_last_free;
            }
            else
            {
                reset( scoped_last_free, m_last_free ); // deleted after critsec is released
                if( m_last_alloc == m_last_free )
                    m_last_alloc = m_list_blocks;
            }

            m_last_free = 0;
        }
    }

    // Notice that ref_count_allocator::instance is
    // never cleaned up. That is, the blocks it
    // maintains are never deallocated. It's ok, really.
    // If you need to clean up the blocks and
    // you are certain that no refcounts are
    // outstanding, you can use the finalize()
    // method to force deallocation
    ref_count_allocator ref_count_allocator::instance = {0,0,0};

}

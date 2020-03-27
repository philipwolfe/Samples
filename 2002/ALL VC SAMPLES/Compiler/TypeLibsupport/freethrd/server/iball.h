
#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0347 */
/* at Thu Jun 28 22:29:06 2001
 */
/* Compiler settings for iball.idl:
    Os, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 440
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __iball_h__
#define __iball_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IBall_FWD_DEFINED__
#define __IBall_FWD_DEFINED__
typedef interface IBall IBall;
#endif 	/* __IBall_FWD_DEFINED__ */


#ifndef __Ball_FWD_DEFINED__
#define __Ball_FWD_DEFINED__

#ifdef __cplusplus
typedef class Ball Ball;
#else
typedef struct Ball Ball;
#endif /* __cplusplus */

#endif 	/* __Ball_FWD_DEFINED__ */


/* header files for imported files */
#include "unknwn.h"
#include "oaidl.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __IBall_INTERFACE_DEFINED__
#define __IBall_INTERFACE_DEFINED__

/* interface IBall */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_IBall;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("F002da32-0000-0000-c000-000000000046")
    IBall : public IUnknown
    {
    public:
        virtual /* [propget][id] */ HRESULT STDMETHODCALLTYPE get_Ball( 
            /* [out] */ POINT *pOrg,
            /* [out] */ POINT *pExt,
            /* [retval][out] */ COLORREF *pcrColor) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Reset( 
            /* [in] */ RECT *pNewRect,
            /* [in] */ short nBallSize) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Move( 
            /* [in] */ BOOL bAlive,
            /* [retval][out] */ BOOL *bRet) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IBallVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IBall * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IBall * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IBall * This);
        
        /* [propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Ball )( 
            IBall * This,
            /* [out] */ POINT *pOrg,
            /* [out] */ POINT *pExt,
            /* [retval][out] */ COLORREF *pcrColor);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Reset )( 
            IBall * This,
            /* [in] */ RECT *pNewRect,
            /* [in] */ short nBallSize);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Move )( 
            IBall * This,
            /* [in] */ BOOL bAlive,
            /* [retval][out] */ BOOL *bRet);
        
        END_INTERFACE
    } IBallVtbl;

    interface IBall
    {
        CONST_VTBL struct IBallVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IBall_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IBall_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IBall_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IBall_get_Ball(This,pOrg,pExt,pcrColor)	\
    (This)->lpVtbl -> get_Ball(This,pOrg,pExt,pcrColor)

#define IBall_Reset(This,pNewRect,nBallSize)	\
    (This)->lpVtbl -> Reset(This,pNewRect,nBallSize)

#define IBall_Move(This,bAlive,bRet)	\
    (This)->lpVtbl -> Move(This,bAlive,bRet)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [propget][id] */ HRESULT STDMETHODCALLTYPE IBall_get_Ball_Proxy( 
    IBall * This,
    /* [out] */ POINT *pOrg,
    /* [out] */ POINT *pExt,
    /* [retval][out] */ COLORREF *pcrColor);


void __RPC_STUB IBall_get_Ball_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IBall_Reset_Proxy( 
    IBall * This,
    /* [in] */ RECT *pNewRect,
    /* [in] */ short nBallSize);


void __RPC_STUB IBall_Reset_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IBall_Move_Proxy( 
    IBall * This,
    /* [in] */ BOOL bAlive,
    /* [retval][out] */ BOOL *bRet);


void __RPC_STUB IBall_Move_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IBall_INTERFACE_DEFINED__ */



#ifndef __BallLib_LIBRARY_DEFINED__
#define __BallLib_LIBRARY_DEFINED__

/* library BallLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_BallLib;

EXTERN_C const CLSID CLSID_Ball;

#ifdef __cplusplus

class DECLSPEC_UUID("F002da33-0000-0000-c000-000000000046")
Ball;
#endif
#endif /* __BallLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif



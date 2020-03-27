/*****************************************************************************
 *  Copyright (C) Microsoft Corp 2000.  All rights reserved.
 *
 *  Run: cl /CLR valTypes.cpp
 *
 *  Description: Some Boxing and UnBoxing of valuetypes
 *
 *****************************************************************************/

#using<mscorlib.dll>
using namespace System;

///////////////////////////////////////////////////////////////////////////////////////////
int nFailures = 0;
int _assert(int line, char *f) {Console::Write(L"ASSERTION FAILED AT LINE "); Console::Write(line);\
    Console::Write(L": \""); Console::Write(f); Console::WriteLine(L"\"");return ++nFailures;}
#define ASSERT(f) ( (f) || _assert(__LINE__, #f) )

///////////////////////////////////////////////////////////////////////////////////////////

__value struct V {
    int m_i;
    void method(Object *o) {
        Console::WriteLine(S"passed");
    }
};

int main() {

    V v = {5};

    __box V *pbv = __box(v);

    int i = pbv->m_i;               // acessing V members directly (implicit unbox)
    ASSERT( i == 5 );

    V *pv = pbv;                    // conversion from boxed to valuetype, unboxing
    ASSERT( pv->m_i == 5 );

    ASSERT( (*pv).m_i == 5 );

    V v3 = *pv;                     // bitwise copy
    v3.m_i = 10;

    ASSERT( v3.m_i == 10 );         // of course
    ASSERT( (*pv).m_i == 5 );       // *pv should not change

    pv = &v3;
    ASSERT( (*pv).m_i == 10 );      // *pv should change

    V v2 = *pbv;                    // de-referencing of boxed type evaluates to unboxing,
                                    // standard conversion
    ASSERT( v2.m_i == 5 );

    (*pbv).m_i = 10;                // another example of de-referencing
    i = pbv->m_i;
    ASSERT( i == 10 );

    pbv->m_i = 123;           // change the inner value of boxed variable (unboxing)
    v = *pbv;                       // unboxing
    ASSERT( v.m_i == 123 );
    
    Object *o = __box(v);    
    pbv = reinterpret_cast<__box V*>(o);    // note: reinterpret_cast is required!
    i = pbv->m_i;
    ASSERT( i == 123 );

    String *str1 = L"V";
    String *str2 = pbv->ToString();
    ASSERT( str1->Equals( str2 ) );     

    // This must compile:

    o = __box(v);
    V *pV = dynamic_cast<V*>(o);    // ok
    v  = *pV;                       // ok
    v = *dynamic_cast<V*>(o);       // ok

    v = *__box(*__box(*pbv));
    i = v.m_i;
    pbv = __box(*__box(*__box(*__box(*pbv))));
    i -= pbv->m_i;
    ASSERT( i == 0 );
        
    // Now test boxing-unboxing for CLR built-in type Int32

    Int32 i32 = 5;
    i = 0;

    __box int *pi1  = __box(5);     i += *pi1;
    __box Int32 *pi2    = __box(5);     i += *pi2;
    __box Int32 *pi3    = __box(i32);   i += *pi3;
    __box int *pi4  = __box(i32);   i += *pi4;

    ASSERT( i == 5+5+5+5 );

    pi1 = pi2;                      // should be a legal conversion
    
   //pi1 = pbv;                     // Note: illegal conversion

   //pass a ValueType to a member that takes type Object*
   //(happens a lot when calling the base class libraries)
   V tmp = V();
   v.method( __box(tmp) );

    if( nFailures == 0 ){
        Console::WriteLine( "SUCCESS" );
    }else{
        Console::WriteLine( "FAIL" );
    }

    return nFailures;
}


#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0342 */
/* at Tue May 22 05:55:41 2001
 */
/* Compiler settings for Math.idl:
    Oicf, W1, Zp8, env=Win32 (32b run)
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

#ifndef __Math_h__
#define __Math_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IAdder_FWD_DEFINED__
#define __IAdder_FWD_DEFINED__
typedef interface IAdder IAdder;
#endif 	/* __IAdder_FWD_DEFINED__ */


#ifndef __ISubtracter_FWD_DEFINED__
#define __ISubtracter_FWD_DEFINED__
typedef interface ISubtracter ISubtracter;
#endif 	/* __ISubtracter_FWD_DEFINED__ */


#ifndef __Adder_FWD_DEFINED__
#define __Adder_FWD_DEFINED__

#ifdef __cplusplus
typedef class Adder Adder;
#else
typedef struct Adder Adder;
#endif /* __cplusplus */

#endif 	/* __Adder_FWD_DEFINED__ */


#ifndef __Subtracter_FWD_DEFINED__
#define __Subtracter_FWD_DEFINED__

#ifdef __cplusplus
typedef class Subtracter Subtracter;
#else
typedef struct Subtracter Subtracter;
#endif /* __cplusplus */

#endif 	/* __Subtracter_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __IAdder_INTERFACE_DEFINED__
#define __IAdder_INTERFACE_DEFINED__

/* interface IAdder */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IAdder;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("8E127E6C-16B3-44B4-89CE-520C9058A8C1")
    IAdder : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE Add( 
            /* [in] */ short sAddend1,
            /* [in] */ short sAddend2,
            /* [retval][out] */ long *plSum) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IAdderVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IAdder * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IAdder * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IAdder * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IAdder * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IAdder * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IAdder * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IAdder * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Add )( 
            IAdder * This,
            /* [in] */ short sAddend1,
            /* [in] */ short sAddend2,
            /* [retval][out] */ long *plSum);
        
        END_INTERFACE
    } IAdderVtbl;

    interface IAdder
    {
        CONST_VTBL struct IAdderVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAdder_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IAdder_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IAdder_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IAdder_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IAdder_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IAdder_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IAdder_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IAdder_Add(This,sAddend1,sAddend2,plSum)	\
    (This)->lpVtbl -> Add(This,sAddend1,sAddend2,plSum)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IAdder_Add_Proxy( 
    IAdder * This,
    /* [in] */ short sAddend1,
    /* [in] */ short sAddend2,
    /* [retval][out] */ long *plSum);


void __RPC_STUB IAdder_Add_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAdder_INTERFACE_DEFINED__ */


#ifndef __ISubtracter_INTERFACE_DEFINED__
#define __ISubtracter_INTERFACE_DEFINED__

/* interface ISubtracter */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_ISubtracter;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("D6FB16C3-18F8-421E-8BC4-EBAA1BC53D72")
    ISubtracter : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE Subtract( 
            /* [in] */ long lMinuend,
            /* [in] */ long lSubtrahend,
            /* [retval][out] */ long *plResidual) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISubtracterVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISubtracter * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISubtracter * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISubtracter * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISubtracter * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISubtracter * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISubtracter * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISubtracter * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Subtract )( 
            ISubtracter * This,
            /* [in] */ long lMinuend,
            /* [in] */ long lSubtrahend,
            /* [retval][out] */ long *plResidual);
        
        END_INTERFACE
    } ISubtracterVtbl;

    interface ISubtracter
    {
        CONST_VTBL struct ISubtracterVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISubtracter_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISubtracter_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISubtracter_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISubtracter_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISubtracter_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISubtracter_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISubtracter_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISubtracter_Subtract(This,lMinuend,lSubtrahend,plResidual)	\
    (This)->lpVtbl -> Subtract(This,lMinuend,lSubtrahend,plResidual)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE ISubtracter_Subtract_Proxy( 
    ISubtracter * This,
    /* [in] */ long lMinuend,
    /* [in] */ long lSubtrahend,
    /* [retval][out] */ long *plResidual);


void __RPC_STUB ISubtracter_Subtract_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISubtracter_INTERFACE_DEFINED__ */



#ifndef __MathLib_LIBRARY_DEFINED__
#define __MathLib_LIBRARY_DEFINED__

/* library MathLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_MathLib;

EXTERN_C const CLSID CLSID_Adder;

#ifdef __cplusplus

class DECLSPEC_UUID("FF381FA0-7EA5-4F6F-9DD1-DADE83249ED5")
Adder;
#endif

EXTERN_C const CLSID CLSID_Subtracter;

#ifdef __cplusplus

class DECLSPEC_UUID("843DBE57-63C3-47C4-AF6E-829C91A0A2A8")
Subtracter;
#endif
#endif /* __MathLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif



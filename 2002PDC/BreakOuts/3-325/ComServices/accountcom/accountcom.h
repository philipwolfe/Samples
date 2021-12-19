
#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 5.03.0280 */
/* at Fri Jun 16 21:27:33 2000
 */
/* Compiler settings for C:\COM99\Tst\TestSrc\Interop\Samples\ComServices\accountcom\accountcom.idl:
    Oicf (OptLev=i2), W1, Zp8, env=Win32 (32b run), ms_ext, c_ext
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

#ifndef __accountcom_h__
#define __accountcom_h__

/* Forward Declarations */ 

#ifndef __IAccount_FWD_DEFINED__
#define __IAccount_FWD_DEFINED__
typedef interface IAccount IAccount;
#endif 	/* __IAccount_FWD_DEFINED__ */


#ifndef __IMoveMoney_FWD_DEFINED__
#define __IMoveMoney_FWD_DEFINED__
typedef interface IMoveMoney IMoveMoney;
#endif 	/* __IMoveMoney_FWD_DEFINED__ */


#ifndef __IGetReceipt_FWD_DEFINED__
#define __IGetReceipt_FWD_DEFINED__
typedef interface IGetReceipt IGetReceipt;
#endif 	/* __IGetReceipt_FWD_DEFINED__ */


#ifndef __IUpdateReceipt_FWD_DEFINED__
#define __IUpdateReceipt_FWD_DEFINED__
typedef interface IUpdateReceipt IUpdateReceipt;
#endif 	/* __IUpdateReceipt_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 

void __RPC_FAR * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void __RPC_FAR * ); 


#ifndef __ACCOUNTCom_LIBRARY_DEFINED__
#define __ACCOUNTCom_LIBRARY_DEFINED__

/* library ACCOUNTCom */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_ACCOUNTCom;

#ifndef __IAccount_INTERFACE_DEFINED__
#define __IAccount_INTERFACE_DEFINED__

/* interface IAccount */
/* [object][oleautomation][dual][helpstring][uuid] */ 


EXTERN_C const IID IID_IAccount;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("04CF0B72-1989-11D0-B917-0080C7394688")
    IAccount : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Post( 
            /* [in] */ long lAccount,
            /* [in] */ long lAmount,
            /* [retval][out] */ BSTR __RPC_FAR *pbstrResult) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IAccountVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IAccount __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IAccount __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IAccount __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfoCount )( 
            IAccount __RPC_FAR * This,
            /* [out] */ UINT __RPC_FAR *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfo )( 
            IAccount __RPC_FAR * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo __RPC_FAR *__RPC_FAR *ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetIDsOfNames )( 
            IAccount __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR __RPC_FAR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID __RPC_FAR *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Invoke )( 
            IAccount __RPC_FAR * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS __RPC_FAR *pDispParams,
            /* [out] */ VARIANT __RPC_FAR *pVarResult,
            /* [out] */ EXCEPINFO __RPC_FAR *pExcepInfo,
            /* [out] */ UINT __RPC_FAR *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Post )( 
            IAccount __RPC_FAR * This,
            /* [in] */ long lAccount,
            /* [in] */ long lAmount,
            /* [retval][out] */ BSTR __RPC_FAR *pbstrResult);
        
        END_INTERFACE
    } IAccountVtbl;

    interface IAccount
    {
        CONST_VTBL struct IAccountVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAccount_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IAccount_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IAccount_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IAccount_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IAccount_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IAccount_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IAccount_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IAccount_Post(This,lAccount,lAmount,pbstrResult)	\
    (This)->lpVtbl -> Post(This,lAccount,lAmount,pbstrResult)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IAccount_Post_Proxy( 
    IAccount __RPC_FAR * This,
    /* [in] */ long lAccount,
    /* [in] */ long lAmount,
    /* [retval][out] */ BSTR __RPC_FAR *pbstrResult);


void __RPC_STUB IAccount_Post_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAccount_INTERFACE_DEFINED__ */


#ifndef __IMoveMoney_INTERFACE_DEFINED__
#define __IMoveMoney_INTERFACE_DEFINED__

/* interface IMoveMoney */
/* [object][oleautomation][dual][helpstring][uuid] */ 


EXTERN_C const IID IID_IMoveMoney;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("04CF0B77-1989-11D0-B917-0080C7394688")
    IMoveMoney : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Perform( 
            /* [in] */ long lPrimeAccount,
            /* [in] */ long lSecondAccount,
            /* [in] */ long lAmount,
            /* [in] */ long lTranType,
            /* [retval][out] */ BSTR __RPC_FAR *pbstrResult) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMoveMoneyVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IMoveMoney __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IMoveMoney __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IMoveMoney __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfoCount )( 
            IMoveMoney __RPC_FAR * This,
            /* [out] */ UINT __RPC_FAR *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfo )( 
            IMoveMoney __RPC_FAR * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo __RPC_FAR *__RPC_FAR *ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetIDsOfNames )( 
            IMoveMoney __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR __RPC_FAR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID __RPC_FAR *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Invoke )( 
            IMoveMoney __RPC_FAR * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS __RPC_FAR *pDispParams,
            /* [out] */ VARIANT __RPC_FAR *pVarResult,
            /* [out] */ EXCEPINFO __RPC_FAR *pExcepInfo,
            /* [out] */ UINT __RPC_FAR *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Perform )( 
            IMoveMoney __RPC_FAR * This,
            /* [in] */ long lPrimeAccount,
            /* [in] */ long lSecondAccount,
            /* [in] */ long lAmount,
            /* [in] */ long lTranType,
            /* [retval][out] */ BSTR __RPC_FAR *pbstrResult);
        
        END_INTERFACE
    } IMoveMoneyVtbl;

    interface IMoveMoney
    {
        CONST_VTBL struct IMoveMoneyVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMoveMoney_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMoveMoney_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMoveMoney_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMoveMoney_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMoveMoney_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMoveMoney_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMoveMoney_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IMoveMoney_Perform(This,lPrimeAccount,lSecondAccount,lAmount,lTranType,pbstrResult)	\
    (This)->lpVtbl -> Perform(This,lPrimeAccount,lSecondAccount,lAmount,lTranType,pbstrResult)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IMoveMoney_Perform_Proxy( 
    IMoveMoney __RPC_FAR * This,
    /* [in] */ long lPrimeAccount,
    /* [in] */ long lSecondAccount,
    /* [in] */ long lAmount,
    /* [in] */ long lTranType,
    /* [retval][out] */ BSTR __RPC_FAR *pbstrResult);


void __RPC_STUB IMoveMoney_Perform_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMoveMoney_INTERFACE_DEFINED__ */


#ifndef __IGetReceipt_INTERFACE_DEFINED__
#define __IGetReceipt_INTERFACE_DEFINED__

/* interface IGetReceipt */
/* [object][oleautomation][dual][helpstring][uuid] */ 


EXTERN_C const IID IID_IGetReceipt;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("A81260B1-DDC8-11D0-B5A0-00C04FB957D8")
    IGetReceipt : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE GetNextReceipt( 
            /* [retval][out] */ long __RPC_FAR *plReceiptNo) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IGetReceiptVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IGetReceipt __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IGetReceipt __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IGetReceipt __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfoCount )( 
            IGetReceipt __RPC_FAR * This,
            /* [out] */ UINT __RPC_FAR *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfo )( 
            IGetReceipt __RPC_FAR * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo __RPC_FAR *__RPC_FAR *ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetIDsOfNames )( 
            IGetReceipt __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR __RPC_FAR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID __RPC_FAR *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Invoke )( 
            IGetReceipt __RPC_FAR * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS __RPC_FAR *pDispParams,
            /* [out] */ VARIANT __RPC_FAR *pVarResult,
            /* [out] */ EXCEPINFO __RPC_FAR *pExcepInfo,
            /* [out] */ UINT __RPC_FAR *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetNextReceipt )( 
            IGetReceipt __RPC_FAR * This,
            /* [retval][out] */ long __RPC_FAR *plReceiptNo);
        
        END_INTERFACE
    } IGetReceiptVtbl;

    interface IGetReceipt
    {
        CONST_VTBL struct IGetReceiptVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IGetReceipt_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IGetReceipt_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IGetReceipt_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IGetReceipt_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IGetReceipt_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IGetReceipt_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IGetReceipt_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IGetReceipt_GetNextReceipt(This,plReceiptNo)	\
    (This)->lpVtbl -> GetNextReceipt(This,plReceiptNo)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IGetReceipt_GetNextReceipt_Proxy( 
    IGetReceipt __RPC_FAR * This,
    /* [retval][out] */ long __RPC_FAR *plReceiptNo);


void __RPC_STUB IGetReceipt_GetNextReceipt_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IGetReceipt_INTERFACE_DEFINED__ */


#ifndef __IUpdateReceipt_INTERFACE_DEFINED__
#define __IUpdateReceipt_INTERFACE_DEFINED__

/* interface IUpdateReceipt */
/* [object][oleautomation][dual][helpstring][uuid] */ 


EXTERN_C const IID IID_IUpdateReceipt;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("A81260B7-DDC8-11D0-B5A0-00C04FB957D8")
    IUpdateReceipt : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Update( 
            /* [retval][out] */ long __RPC_FAR *plReceiptNo) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IUpdateReceiptVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IUpdateReceipt __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IUpdateReceipt __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IUpdateReceipt __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfoCount )( 
            IUpdateReceipt __RPC_FAR * This,
            /* [out] */ UINT __RPC_FAR *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfo )( 
            IUpdateReceipt __RPC_FAR * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo __RPC_FAR *__RPC_FAR *ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetIDsOfNames )( 
            IUpdateReceipt __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR __RPC_FAR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID __RPC_FAR *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Invoke )( 
            IUpdateReceipt __RPC_FAR * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS __RPC_FAR *pDispParams,
            /* [out] */ VARIANT __RPC_FAR *pVarResult,
            /* [out] */ EXCEPINFO __RPC_FAR *pExcepInfo,
            /* [out] */ UINT __RPC_FAR *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Update )( 
            IUpdateReceipt __RPC_FAR * This,
            /* [retval][out] */ long __RPC_FAR *plReceiptNo);
        
        END_INTERFACE
    } IUpdateReceiptVtbl;

    interface IUpdateReceipt
    {
        CONST_VTBL struct IUpdateReceiptVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IUpdateReceipt_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IUpdateReceipt_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IUpdateReceipt_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IUpdateReceipt_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IUpdateReceipt_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IUpdateReceipt_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IUpdateReceipt_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IUpdateReceipt_Update(This,plReceiptNo)	\
    (This)->lpVtbl -> Update(This,plReceiptNo)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IUpdateReceipt_Update_Proxy( 
    IUpdateReceipt __RPC_FAR * This,
    /* [retval][out] */ long __RPC_FAR *plReceiptNo);


void __RPC_STUB IUpdateReceipt_Update_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IUpdateReceipt_INTERFACE_DEFINED__ */

#endif /* __ACCOUNTCom_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif



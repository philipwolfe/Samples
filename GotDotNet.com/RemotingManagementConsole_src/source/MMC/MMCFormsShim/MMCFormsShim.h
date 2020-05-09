
#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0347 */
/* at Sat Apr 05 14:18:19 2003
 */
/* Compiler settings for MMCFormsShim.idl:
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

#ifndef __MMCFormsShim_h__
#define __MMCFormsShim_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IMMCFormsShimCtrl_FWD_DEFINED__
#define __IMMCFormsShimCtrl_FWD_DEFINED__
typedef interface IMMCFormsShimCtrl IMMCFormsShimCtrl;
#endif 	/* __IMMCFormsShimCtrl_FWD_DEFINED__ */


#ifndef __IMMCFormsShim_FWD_DEFINED__
#define __IMMCFormsShim_FWD_DEFINED__
typedef interface IMMCFormsShim IMMCFormsShim;
#endif 	/* __IMMCFormsShim_FWD_DEFINED__ */


#ifndef __IWin32Window_FWD_DEFINED__
#define __IWin32Window_FWD_DEFINED__
typedef interface IWin32Window IWin32Window;
#endif 	/* __IWin32Window_FWD_DEFINED__ */


#ifndef __MMCFormsShimCtrl_FWD_DEFINED__
#define __MMCFormsShimCtrl_FWD_DEFINED__

#ifdef __cplusplus
typedef class MMCFormsShimCtrl MMCFormsShimCtrl;
#else
typedef struct MMCFormsShimCtrl MMCFormsShimCtrl;
#endif /* __cplusplus */

#endif 	/* __MMCFormsShimCtrl_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __IMMCFormsShimCtrl_INTERFACE_DEFINED__
#define __IMMCFormsShimCtrl_INTERFACE_DEFINED__

/* interface IMMCFormsShimCtrl */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IMMCFormsShimCtrl;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("85BCEB7D-7628-4BEB-8A00-56414702FDC8")
    IMMCFormsShimCtrl : public IDispatch
    {
    public:
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_FormClassName( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_FormClassName( 
            /* [in] */ BSTR newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_AssemblyName( 
            /* [retval][out] */ BSTR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_AssemblyName( 
            /* [in] */ BSTR newVal) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMMCFormsShimCtrlVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMMCFormsShimCtrl * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMMCFormsShimCtrl * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMMCFormsShimCtrl * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMMCFormsShimCtrl * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMMCFormsShimCtrl * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMMCFormsShimCtrl * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMMCFormsShimCtrl * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_FormClassName )( 
            IMMCFormsShimCtrl * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_FormClassName )( 
            IMMCFormsShimCtrl * This,
            /* [in] */ BSTR newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_AssemblyName )( 
            IMMCFormsShimCtrl * This,
            /* [retval][out] */ BSTR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_AssemblyName )( 
            IMMCFormsShimCtrl * This,
            /* [in] */ BSTR newVal);
        
        END_INTERFACE
    } IMMCFormsShimCtrlVtbl;

    interface IMMCFormsShimCtrl
    {
        CONST_VTBL struct IMMCFormsShimCtrlVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMMCFormsShimCtrl_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMMCFormsShimCtrl_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMMCFormsShimCtrl_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMMCFormsShimCtrl_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IMMCFormsShimCtrl_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IMMCFormsShimCtrl_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IMMCFormsShimCtrl_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IMMCFormsShimCtrl_get_FormClassName(This,pVal)	\
    (This)->lpVtbl -> get_FormClassName(This,pVal)

#define IMMCFormsShimCtrl_put_FormClassName(This,newVal)	\
    (This)->lpVtbl -> put_FormClassName(This,newVal)

#define IMMCFormsShimCtrl_get_AssemblyName(This,pVal)	\
    (This)->lpVtbl -> get_AssemblyName(This,pVal)

#define IMMCFormsShimCtrl_put_AssemblyName(This,newVal)	\
    (This)->lpVtbl -> put_AssemblyName(This,newVal)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE IMMCFormsShimCtrl_get_FormClassName_Proxy( 
    IMMCFormsShimCtrl * This,
    /* [retval][out] */ BSTR *pVal);


void __RPC_STUB IMMCFormsShimCtrl_get_FormClassName_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE IMMCFormsShimCtrl_put_FormClassName_Proxy( 
    IMMCFormsShimCtrl * This,
    /* [in] */ BSTR newVal);


void __RPC_STUB IMMCFormsShimCtrl_put_FormClassName_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE IMMCFormsShimCtrl_get_AssemblyName_Proxy( 
    IMMCFormsShimCtrl * This,
    /* [retval][out] */ BSTR *pVal);


void __RPC_STUB IMMCFormsShimCtrl_get_AssemblyName_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE IMMCFormsShimCtrl_put_AssemblyName_Proxy( 
    IMMCFormsShimCtrl * This,
    /* [in] */ BSTR newVal);


void __RPC_STUB IMMCFormsShimCtrl_put_AssemblyName_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMMCFormsShimCtrl_INTERFACE_DEFINED__ */


#ifndef __IMMCFormsShim_INTERFACE_DEFINED__
#define __IMMCFormsShim_INTERFACE_DEFINED__

/* interface IMMCFormsShim */
/* [unique][helpstring][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IMMCFormsShim;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("B8F882F8-3D93-401c-A4D4-E3A9943E858D")
    IMMCFormsShim : public IUnknown
    {
    public:
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE HostUserControl( 
            BSTR Assembly,
            BSTR Class,
            /* [retval][out] */ IUnknown **ppControlObject) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IMMCFormsShimVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMMCFormsShim * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMMCFormsShim * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMMCFormsShim * This);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE *HostUserControl )( 
            IMMCFormsShim * This,
            BSTR Assembly,
            BSTR Class,
            /* [retval][out] */ IUnknown **ppControlObject);
        
        END_INTERFACE
    } IMMCFormsShimVtbl;

    interface IMMCFormsShim
    {
        CONST_VTBL struct IMMCFormsShimVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMMCFormsShim_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IMMCFormsShim_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IMMCFormsShim_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IMMCFormsShim_HostUserControl(This,Assembly,Class,ppControlObject)	\
    (This)->lpVtbl -> HostUserControl(This,Assembly,Class,ppControlObject)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring] */ HRESULT STDMETHODCALLTYPE IMMCFormsShim_HostUserControl_Proxy( 
    IMMCFormsShim * This,
    BSTR Assembly,
    BSTR Class,
    /* [retval][out] */ IUnknown **ppControlObject);


void __RPC_STUB IMMCFormsShim_HostUserControl_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IMMCFormsShim_INTERFACE_DEFINED__ */



#ifndef __MMCFormsShimLib_LIBRARY_DEFINED__
#define __MMCFormsShimLib_LIBRARY_DEFINED__

/* library MMCFormsShimLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_MMCFormsShimLib;

#ifndef __IWin32Window_INTERFACE_DEFINED__
#define __IWin32Window_INTERFACE_DEFINED__

/* interface IWin32Window */
/* [object][uuid] */ 


EXTERN_C const IID IID_IWin32Window;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("458AB8A2-A1EA-4D7B-8EBE-DEE5D3D9442C")
    IWin32Window : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE get_Handle( 
            /* [retval][out] */ long *pHWnd) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWin32WindowVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWin32Window * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWin32Window * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWin32Window * This);
        
        HRESULT ( STDMETHODCALLTYPE *get_Handle )( 
            IWin32Window * This,
            /* [retval][out] */ long *pHWnd);
        
        END_INTERFACE
    } IWin32WindowVtbl;

    interface IWin32Window
    {
        CONST_VTBL struct IWin32WindowVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWin32Window_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IWin32Window_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IWin32Window_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IWin32Window_get_Handle(This,pHWnd)	\
    (This)->lpVtbl -> get_Handle(This,pHWnd)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE IWin32Window_get_Handle_Proxy( 
    IWin32Window * This,
    /* [retval][out] */ long *pHWnd);


void __RPC_STUB IWin32Window_get_Handle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IWin32Window_INTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_MMCFormsShimCtrl;

#ifdef __cplusplus

class DECLSPEC_UUID("97AD17DA-70A5-45B9-9E10-DEAA3D26E17D")
MMCFormsShimCtrl;
#endif
#endif /* __MMCFormsShimLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long *, BSTR * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif



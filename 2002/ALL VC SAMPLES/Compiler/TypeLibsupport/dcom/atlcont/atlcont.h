
#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0347 */
/* at Tue Jul 03 11:26:11 2001
 */
/* Compiler settings for AtlCont.idl:
    Oic, W1, Zp8, env=Win32 (32b run)
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

#ifndef __AtlCont_h__
#define __AtlCont_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IAtlCont_FWD_DEFINED__
#define __IAtlCont_FWD_DEFINED__
typedef interface IAtlCont IAtlCont;
#endif 	/* __IAtlCont_FWD_DEFINED__ */


#ifndef __CAtlCont_FWD_DEFINED__
#define __CAtlCont_FWD_DEFINED__

#ifdef __cplusplus
typedef class CAtlCont CAtlCont;
#else
typedef struct CAtlCont CAtlCont;
#endif /* __cplusplus */

#endif 	/* __CAtlCont_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __IAtlCont_INTERFACE_DEFINED__
#define __IAtlCont_INTERFACE_DEFINED__

/* interface IAtlCont */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_IAtlCont;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("BFD466C3-376C-11D0-96B5-00A0C90DC94B")
    IAtlCont : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Run( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE Stop( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IAtlContVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IAtlCont * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IAtlCont * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IAtlCont * This);
        
        HRESULT ( STDMETHODCALLTYPE *Run )( 
            IAtlCont * This);
        
        HRESULT ( STDMETHODCALLTYPE *Stop )( 
            IAtlCont * This);
        
        END_INTERFACE
    } IAtlContVtbl;

    interface IAtlCont
    {
        CONST_VTBL struct IAtlContVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAtlCont_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IAtlCont_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IAtlCont_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IAtlCont_Run(This)	\
    (This)->lpVtbl -> Run(This)

#define IAtlCont_Stop(This)	\
    (This)->lpVtbl -> Stop(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE IAtlCont_Run_Proxy( 
    IAtlCont * This);


void __RPC_STUB IAtlCont_Run_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlCont_Stop_Proxy( 
    IAtlCont * This);


void __RPC_STUB IAtlCont_Stop_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAtlCont_INTERFACE_DEFINED__ */



#ifndef __ATLCONTLib_LIBRARY_DEFINED__
#define __ATLCONTLib_LIBRARY_DEFINED__

/* library ATLCONTLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_ATLCONTLib;

EXTERN_C const CLSID CLSID_CAtlCont;

#ifdef __cplusplus

class DECLSPEC_UUID("BFD466C2-376C-11D0-96B5-00A0C90DC94B")
CAtlCont;
#endif
#endif /* __ATLCONTLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif



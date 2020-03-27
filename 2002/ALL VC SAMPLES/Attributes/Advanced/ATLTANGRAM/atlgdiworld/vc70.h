// File: vc70.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 5.03.0280 */
/* at Thu Apr 27 09:55:30 2000
 */
/* Compiler settings for vc70.idl:
    Os (OptLev=s), W1, Zp8, env=Win32 (32b run), ms_ext, c_ext
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

#ifndef __vc70_h__
#define __vc70_h__

/* Forward Declarations */ 

#ifndef __IATLTangramModelEvent_FWD_DEFINED__
#define __IATLTangramModelEvent_FWD_DEFINED__
typedef interface IATLTangramModelEvent IATLTangramModelEvent;
#endif 	/* __IATLTangramModelEvent_FWD_DEFINED__ */


#ifndef __IATLTangramModel_FWD_DEFINED__
#define __IATLTangramModel_FWD_DEFINED__
typedef interface IATLTangramModel IATLTangramModel;
#endif 	/* __IATLTangramModel_FWD_DEFINED__ */


#ifndef __IATLTangramTransform_FWD_DEFINED__
#define __IATLTangramTransform_FWD_DEFINED__
typedef interface IATLTangramTransform IATLTangramTransform;
#endif 	/* __IATLTangramTransform_FWD_DEFINED__ */


#ifndef __IAtlTangramCanvas_FWD_DEFINED__
#define __IAtlTangramCanvas_FWD_DEFINED__
typedef interface IAtlTangramCanvas IAtlTangramCanvas;
#endif 	/* __IAtlTangramCanvas_FWD_DEFINED__ */


#ifndef __IAtlTangramVisual_FWD_DEFINED__
#define __IAtlTangramVisual_FWD_DEFINED__
typedef interface IAtlTangramVisual IAtlTangramVisual;
#endif 	/* __IAtlTangramVisual_FWD_DEFINED__ */


#ifndef __IAtlTangramWorld_FWD_DEFINED__
#define __IAtlTangramWorld_FWD_DEFINED__
typedef interface IAtlTangramWorld IAtlTangramWorld;
#endif 	/* __IAtlTangramWorld_FWD_DEFINED__ */


#ifndef __IAtlTangramGdiWorld_FWD_DEFINED__
#define __IAtlTangramGdiWorld_FWD_DEFINED__
typedef interface IAtlTangramGdiWorld IAtlTangramGdiWorld;
#endif 	/* __IAtlTangramGdiWorld_FWD_DEFINED__ */


#ifndef __IAtlTangramGdiVisual_FWD_DEFINED__
#define __IAtlTangramGdiVisual_FWD_DEFINED__
typedef interface IAtlTangramGdiVisual IAtlTangramGdiVisual;
#endif 	/* __IAtlTangramGdiVisual_FWD_DEFINED__ */


#ifndef __CAtlTangramGdiVisual_FWD_DEFINED__
#define __CAtlTangramGdiVisual_FWD_DEFINED__

#ifdef __cplusplus
typedef class CAtlTangramGdiVisual CAtlTangramGdiVisual;
#else
typedef struct CAtlTangramGdiVisual CAtlTangramGdiVisual;
#endif /* __cplusplus */

#endif 	/* __CAtlTangramGdiVisual_FWD_DEFINED__ */


#ifndef __CAtlGdiWorld_FWD_DEFINED__
#define __CAtlGdiWorld_FWD_DEFINED__

#ifdef __cplusplus
typedef class CAtlGdiWorld CAtlGdiWorld;
#else
typedef struct CAtlGdiWorld CAtlGdiWorld;
#endif /* __cplusplus */

#endif 	/* __CAtlGdiWorld_FWD_DEFINED__ */


/* header files for imported files */
#include "docobj.h"
#include "comcat.h"
#include "tantypeiface.h"

#ifdef __cplusplus
extern "C"{
#endif 

void __RPC_FAR * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void __RPC_FAR * ); 

#ifndef __IATLTangramModelEvent_INTERFACE_DEFINED__
#define __IATLTangramModelEvent_INTERFACE_DEFINED__

/* interface IATLTangramModelEvent */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_IATLTangramModelEvent;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("4A6E83B0-B0F4-11d0-B69F-00A0C903487A")
    IATLTangramModelEvent : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE OnModelChange( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IATLTangramModelEventVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IATLTangramModelEvent __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IATLTangramModelEvent __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IATLTangramModelEvent __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *OnModelChange )( 
            IATLTangramModelEvent __RPC_FAR * This);
        
        END_INTERFACE
    } IATLTangramModelEventVtbl;

    interface IATLTangramModelEvent
    {
        CONST_VTBL struct IATLTangramModelEventVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IATLTangramModelEvent_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IATLTangramModelEvent_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IATLTangramModelEvent_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IATLTangramModelEvent_OnModelChange(This)	\
    (This)->lpVtbl -> OnModelChange(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE IATLTangramModelEvent_OnModelChange_Proxy( 
    IATLTangramModelEvent __RPC_FAR * This);


void __RPC_STUB IATLTangramModelEvent_OnModelChange_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IATLTangramModelEvent_INTERFACE_DEFINED__ */


#ifndef __IATLTangramModel_INTERFACE_DEFINED__
#define __IATLTangramModel_INTERFACE_DEFINED__

/* interface IATLTangramModel */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_IATLTangramModel;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("060BAAA2-B076-11D0-B69F-00A0C903487A")
    IATLTangramModel : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE GetNumberOfVertices( 
            /* [out] */ long __RPC_FAR *pcVertices) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetVertices( 
            /* [in] */ long cVertices,
            /* [size_is][out] */ TangramPoint2d __RPC_FAR *points) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetVertices( 
            /* [in] */ long cVertices,
            /* [size_is][in] */ TangramPoint2d __RPC_FAR *points) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IATLTangramModelVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IATLTangramModel __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IATLTangramModel __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IATLTangramModel __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetNumberOfVertices )( 
            IATLTangramModel __RPC_FAR * This,
            /* [out] */ long __RPC_FAR *pcVertices);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetVertices )( 
            IATLTangramModel __RPC_FAR * This,
            /* [in] */ long cVertices,
            /* [size_is][out] */ TangramPoint2d __RPC_FAR *points);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetVertices )( 
            IATLTangramModel __RPC_FAR * This,
            /* [in] */ long cVertices,
            /* [size_is][in] */ TangramPoint2d __RPC_FAR *points);
        
        END_INTERFACE
    } IATLTangramModelVtbl;

    interface IATLTangramModel
    {
        CONST_VTBL struct IATLTangramModelVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IATLTangramModel_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IATLTangramModel_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IATLTangramModel_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IATLTangramModel_GetNumberOfVertices(This,pcVertices)	\
    (This)->lpVtbl -> GetNumberOfVertices(This,pcVertices)

#define IATLTangramModel_GetVertices(This,cVertices,points)	\
    (This)->lpVtbl -> GetVertices(This,cVertices,points)

#define IATLTangramModel_SetVertices(This,cVertices,points)	\
    (This)->lpVtbl -> SetVertices(This,cVertices,points)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE IATLTangramModel_GetNumberOfVertices_Proxy( 
    IATLTangramModel __RPC_FAR * This,
    /* [out] */ long __RPC_FAR *pcVertices);


void __RPC_STUB IATLTangramModel_GetNumberOfVertices_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IATLTangramModel_GetVertices_Proxy( 
    IATLTangramModel __RPC_FAR * This,
    /* [in] */ long cVertices,
    /* [size_is][out] */ TangramPoint2d __RPC_FAR *points);


void __RPC_STUB IATLTangramModel_GetVertices_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IATLTangramModel_SetVertices_Proxy( 
    IATLTangramModel __RPC_FAR * This,
    /* [in] */ long cVertices,
    /* [size_is][in] */ TangramPoint2d __RPC_FAR *points);


void __RPC_STUB IATLTangramModel_SetVertices_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IATLTangramModel_INTERFACE_DEFINED__ */


#ifndef __IATLTangramTransform_INTERFACE_DEFINED__
#define __IATLTangramTransform_INTERFACE_DEFINED__

/* interface IATLTangramTransform */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_IATLTangramTransform;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("D5056310-B0F4-11d0-B69F-00A0C903487A")
    IATLTangramTransform : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Translate( 
            /* [in] */ double x,
            /* [in] */ double y) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetTranslation( 
            /* [out] */ TangramPoint2d __RPC_FAR *point) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE Rotate( 
            /* [in] */ double fDegrees) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetRotation( 
            /* [out] */ double __RPC_FAR *pRotation) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IATLTangramTransformVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IATLTangramTransform __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IATLTangramTransform __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IATLTangramTransform __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Translate )( 
            IATLTangramTransform __RPC_FAR * This,
            /* [in] */ double x,
            /* [in] */ double y);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTranslation )( 
            IATLTangramTransform __RPC_FAR * This,
            /* [out] */ TangramPoint2d __RPC_FAR *point);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Rotate )( 
            IATLTangramTransform __RPC_FAR * This,
            /* [in] */ double fDegrees);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetRotation )( 
            IATLTangramTransform __RPC_FAR * This,
            /* [out] */ double __RPC_FAR *pRotation);
        
        END_INTERFACE
    } IATLTangramTransformVtbl;

    interface IATLTangramTransform
    {
        CONST_VTBL struct IATLTangramTransformVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IATLTangramTransform_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IATLTangramTransform_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IATLTangramTransform_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IATLTangramTransform_Translate(This,x,y)	\
    (This)->lpVtbl -> Translate(This,x,y)

#define IATLTangramTransform_GetTranslation(This,point)	\
    (This)->lpVtbl -> GetTranslation(This,point)

#define IATLTangramTransform_Rotate(This,fDegrees)	\
    (This)->lpVtbl -> Rotate(This,fDegrees)

#define IATLTangramTransform_GetRotation(This,pRotation)	\
    (This)->lpVtbl -> GetRotation(This,pRotation)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE IATLTangramTransform_Translate_Proxy( 
    IATLTangramTransform __RPC_FAR * This,
    /* [in] */ double x,
    /* [in] */ double y);


void __RPC_STUB IATLTangramTransform_Translate_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IATLTangramTransform_GetTranslation_Proxy( 
    IATLTangramTransform __RPC_FAR * This,
    /* [out] */ TangramPoint2d __RPC_FAR *point);


void __RPC_STUB IATLTangramTransform_GetTranslation_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IATLTangramTransform_Rotate_Proxy( 
    IATLTangramTransform __RPC_FAR * This,
    /* [in] */ double fDegrees);


void __RPC_STUB IATLTangramTransform_Rotate_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IATLTangramTransform_GetRotation_Proxy( 
    IATLTangramTransform __RPC_FAR * This,
    /* [out] */ double __RPC_FAR *pRotation);


void __RPC_STUB IATLTangramTransform_GetRotation_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IATLTangramTransform_INTERFACE_DEFINED__ */


#ifndef __IAtlTangramCanvas_INTERFACE_DEFINED__
#define __IAtlTangramCanvas_INTERFACE_DEFINED__

/* interface IAtlTangramCanvas */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_IAtlTangramCanvas;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("8FAD674F-AD34-11D0-B69F-00A0C903487A")
    IAtlTangramCanvas : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Initialize( 
            /* [in] */ HWND hWnd,
            /* [in] */ long cx,
            /* [in] */ long cy) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE Paint( 
            /* [in] */ HDC hdcDest,
            /* [in] */ RECT rectUpdate) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE Update( 
            /* [in] */ RECT rectUpdate) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetHDC( 
            /* [out] */ HDC __RPC_FAR *pHDC) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetPalette( 
            /* [in] */ HPALETTE hPal) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE OnQueryNewPalette( 
            /* [in] */ HWND hWndReceived) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IAtlTangramCanvasVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IAtlTangramCanvas __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IAtlTangramCanvas __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IAtlTangramCanvas __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Initialize )( 
            IAtlTangramCanvas __RPC_FAR * This,
            /* [in] */ HWND hWnd,
            /* [in] */ long cx,
            /* [in] */ long cy);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Paint )( 
            IAtlTangramCanvas __RPC_FAR * This,
            /* [in] */ HDC hdcDest,
            /* [in] */ RECT rectUpdate);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Update )( 
            IAtlTangramCanvas __RPC_FAR * This,
            /* [in] */ RECT rectUpdate);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetHDC )( 
            IAtlTangramCanvas __RPC_FAR * This,
            /* [out] */ HDC __RPC_FAR *pHDC);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetPalette )( 
            IAtlTangramCanvas __RPC_FAR * This,
            /* [in] */ HPALETTE hPal);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *OnQueryNewPalette )( 
            IAtlTangramCanvas __RPC_FAR * This,
            /* [in] */ HWND hWndReceived);
        
        END_INTERFACE
    } IAtlTangramCanvasVtbl;

    interface IAtlTangramCanvas
    {
        CONST_VTBL struct IAtlTangramCanvasVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAtlTangramCanvas_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IAtlTangramCanvas_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IAtlTangramCanvas_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IAtlTangramCanvas_Initialize(This,hWnd,cx,cy)	\
    (This)->lpVtbl -> Initialize(This,hWnd,cx,cy)

#define IAtlTangramCanvas_Paint(This,hdcDest,rectUpdate)	\
    (This)->lpVtbl -> Paint(This,hdcDest,rectUpdate)

#define IAtlTangramCanvas_Update(This,rectUpdate)	\
    (This)->lpVtbl -> Update(This,rectUpdate)

#define IAtlTangramCanvas_GetHDC(This,pHDC)	\
    (This)->lpVtbl -> GetHDC(This,pHDC)

#define IAtlTangramCanvas_SetPalette(This,hPal)	\
    (This)->lpVtbl -> SetPalette(This,hPal)

#define IAtlTangramCanvas_OnQueryNewPalette(This,hWndReceived)	\
    (This)->lpVtbl -> OnQueryNewPalette(This,hWndReceived)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE IAtlTangramCanvas_Initialize_Proxy( 
    IAtlTangramCanvas __RPC_FAR * This,
    /* [in] */ HWND hWnd,
    /* [in] */ long cx,
    /* [in] */ long cy);


void __RPC_STUB IAtlTangramCanvas_Initialize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramCanvas_Paint_Proxy( 
    IAtlTangramCanvas __RPC_FAR * This,
    /* [in] */ HDC hdcDest,
    /* [in] */ RECT rectUpdate);


void __RPC_STUB IAtlTangramCanvas_Paint_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramCanvas_Update_Proxy( 
    IAtlTangramCanvas __RPC_FAR * This,
    /* [in] */ RECT rectUpdate);


void __RPC_STUB IAtlTangramCanvas_Update_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramCanvas_GetHDC_Proxy( 
    IAtlTangramCanvas __RPC_FAR * This,
    /* [out] */ HDC __RPC_FAR *pHDC);


void __RPC_STUB IAtlTangramCanvas_GetHDC_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramCanvas_SetPalette_Proxy( 
    IAtlTangramCanvas __RPC_FAR * This,
    /* [in] */ HPALETTE hPal);


void __RPC_STUB IAtlTangramCanvas_SetPalette_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramCanvas_OnQueryNewPalette_Proxy( 
    IAtlTangramCanvas __RPC_FAR * This,
    /* [in] */ HWND hWndReceived);


void __RPC_STUB IAtlTangramCanvas_OnQueryNewPalette_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAtlTangramCanvas_INTERFACE_DEFINED__ */


#ifndef __IAtlTangramVisual_INTERFACE_DEFINED__
#define __IAtlTangramVisual_INTERFACE_DEFINED__

/* interface IAtlTangramVisual */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_IAtlTangramVisual;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("D62E8DC8-AEDD-11d0-80C9-00609714FDFE")
    IAtlTangramVisual : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE GetModel( 
            /* [in] */ const IID __RPC_FAR *iid,
            /* [iid_is][out] */ IUnknown __RPC_FAR *__RPC_FAR *ppI) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetSelected( 
            /* [in] */ BOOL bSelected) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IAtlTangramVisualVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IAtlTangramVisual __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IAtlTangramVisual __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IAtlTangramVisual __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetModel )( 
            IAtlTangramVisual __RPC_FAR * This,
            /* [in] */ const IID __RPC_FAR *iid,
            /* [iid_is][out] */ IUnknown __RPC_FAR *__RPC_FAR *ppI);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetSelected )( 
            IAtlTangramVisual __RPC_FAR * This,
            /* [in] */ BOOL bSelected);
        
        END_INTERFACE
    } IAtlTangramVisualVtbl;

    interface IAtlTangramVisual
    {
        CONST_VTBL struct IAtlTangramVisualVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAtlTangramVisual_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IAtlTangramVisual_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IAtlTangramVisual_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IAtlTangramVisual_GetModel(This,iid,ppI)	\
    (This)->lpVtbl -> GetModel(This,iid,ppI)

#define IAtlTangramVisual_SetSelected(This,bSelected)	\
    (This)->lpVtbl -> SetSelected(This,bSelected)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE IAtlTangramVisual_GetModel_Proxy( 
    IAtlTangramVisual __RPC_FAR * This,
    /* [in] */ const IID __RPC_FAR *iid,
    /* [iid_is][out] */ IUnknown __RPC_FAR *__RPC_FAR *ppI);


void __RPC_STUB IAtlTangramVisual_GetModel_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramVisual_SetSelected_Proxy( 
    IAtlTangramVisual __RPC_FAR * This,
    /* [in] */ BOOL bSelected);


void __RPC_STUB IAtlTangramVisual_SetSelected_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAtlTangramVisual_INTERFACE_DEFINED__ */


#ifndef __IAtlTangramWorld_INTERFACE_DEFINED__
#define __IAtlTangramWorld_INTERFACE_DEFINED__

/* interface IAtlTangramWorld */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_IAtlTangramWorld;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("582787A4-AED3-11d0-80C9-00609714FDFE")
    IAtlTangramWorld : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Initialize( 
            /* [in] */ HWND hwnd,
            /* [in] */ double logicalCX,
            /* [in] */ double logicalCY) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE DeviceToModel( 
            /* [in] */ POINT ptIN,
            /* [out] */ TangramPoint2d __RPC_FAR *pptOut) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE VisualFromPoint( 
            /* [in] */ POINT pt,
            /* [in] */ const IID __RPC_FAR *iid,
            /* [iid_is][out] */ IUnknown __RPC_FAR *__RPC_FAR *pITangramVisual) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CreateVisualForModel( 
            /* [in] */ IATLTangramModel __RPC_FAR *pModel) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SelectVisual( 
            /* [in] */ IAtlTangramVisual __RPC_FAR *pSelectedVisual,
            /* [in] */ BOOL bSelect) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE Animate( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IAtlTangramWorldVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IAtlTangramWorld __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IAtlTangramWorld __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IAtlTangramWorld __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Initialize )( 
            IAtlTangramWorld __RPC_FAR * This,
            /* [in] */ HWND hwnd,
            /* [in] */ double logicalCX,
            /* [in] */ double logicalCY);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *DeviceToModel )( 
            IAtlTangramWorld __RPC_FAR * This,
            /* [in] */ POINT ptIN,
            /* [out] */ TangramPoint2d __RPC_FAR *pptOut);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *VisualFromPoint )( 
            IAtlTangramWorld __RPC_FAR * This,
            /* [in] */ POINT pt,
            /* [in] */ const IID __RPC_FAR *iid,
            /* [iid_is][out] */ IUnknown __RPC_FAR *__RPC_FAR *pITangramVisual);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *CreateVisualForModel )( 
            IAtlTangramWorld __RPC_FAR * This,
            /* [in] */ IATLTangramModel __RPC_FAR *pModel);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SelectVisual )( 
            IAtlTangramWorld __RPC_FAR * This,
            /* [in] */ IAtlTangramVisual __RPC_FAR *pSelectedVisual,
            /* [in] */ BOOL bSelect);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Animate )( 
            IAtlTangramWorld __RPC_FAR * This);
        
        END_INTERFACE
    } IAtlTangramWorldVtbl;

    interface IAtlTangramWorld
    {
        CONST_VTBL struct IAtlTangramWorldVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAtlTangramWorld_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IAtlTangramWorld_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IAtlTangramWorld_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IAtlTangramWorld_Initialize(This,hwnd,logicalCX,logicalCY)	\
    (This)->lpVtbl -> Initialize(This,hwnd,logicalCX,logicalCY)

#define IAtlTangramWorld_DeviceToModel(This,ptIN,pptOut)	\
    (This)->lpVtbl -> DeviceToModel(This,ptIN,pptOut)

#define IAtlTangramWorld_VisualFromPoint(This,pt,iid,pITangramVisual)	\
    (This)->lpVtbl -> VisualFromPoint(This,pt,iid,pITangramVisual)

#define IAtlTangramWorld_CreateVisualForModel(This,pModel)	\
    (This)->lpVtbl -> CreateVisualForModel(This,pModel)

#define IAtlTangramWorld_SelectVisual(This,pSelectedVisual,bSelect)	\
    (This)->lpVtbl -> SelectVisual(This,pSelectedVisual,bSelect)

#define IAtlTangramWorld_Animate(This)	\
    (This)->lpVtbl -> Animate(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE IAtlTangramWorld_Initialize_Proxy( 
    IAtlTangramWorld __RPC_FAR * This,
    /* [in] */ HWND hwnd,
    /* [in] */ double logicalCX,
    /* [in] */ double logicalCY);


void __RPC_STUB IAtlTangramWorld_Initialize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramWorld_DeviceToModel_Proxy( 
    IAtlTangramWorld __RPC_FAR * This,
    /* [in] */ POINT ptIN,
    /* [out] */ TangramPoint2d __RPC_FAR *pptOut);


void __RPC_STUB IAtlTangramWorld_DeviceToModel_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramWorld_VisualFromPoint_Proxy( 
    IAtlTangramWorld __RPC_FAR * This,
    /* [in] */ POINT pt,
    /* [in] */ const IID __RPC_FAR *iid,
    /* [iid_is][out] */ IUnknown __RPC_FAR *__RPC_FAR *pITangramVisual);


void __RPC_STUB IAtlTangramWorld_VisualFromPoint_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramWorld_CreateVisualForModel_Proxy( 
    IAtlTangramWorld __RPC_FAR * This,
    /* [in] */ IATLTangramModel __RPC_FAR *pModel);


void __RPC_STUB IAtlTangramWorld_CreateVisualForModel_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramWorld_SelectVisual_Proxy( 
    IAtlTangramWorld __RPC_FAR * This,
    /* [in] */ IAtlTangramVisual __RPC_FAR *pSelectedVisual,
    /* [in] */ BOOL bSelect);


void __RPC_STUB IAtlTangramWorld_SelectVisual_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramWorld_Animate_Proxy( 
    IAtlTangramWorld __RPC_FAR * This);


void __RPC_STUB IAtlTangramWorld_Animate_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAtlTangramWorld_INTERFACE_DEFINED__ */


#ifndef __IAtlTangramGdiWorld_INTERFACE_DEFINED__
#define __IAtlTangramGdiWorld_INTERFACE_DEFINED__

/* interface IAtlTangramGdiWorld */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_IAtlTangramGdiWorld;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("09A63AE0-AED1-11D0-80C9-00609714FDFE")
    IAtlTangramGdiWorld : public IAtlTangramWorld
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE ModelToDevice( 
            /* [in] */ TangramPoint2d pptIn,
            /* [out] */ POINT __RPC_FAR *pptOut) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE AddUpdateRect( 
            /* [in] */ RECT rectUpdate) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IAtlTangramGdiWorldVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IAtlTangramGdiWorld __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IAtlTangramGdiWorld __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IAtlTangramGdiWorld __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Initialize )( 
            IAtlTangramGdiWorld __RPC_FAR * This,
            /* [in] */ HWND hwnd,
            /* [in] */ double logicalCX,
            /* [in] */ double logicalCY);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *DeviceToModel )( 
            IAtlTangramGdiWorld __RPC_FAR * This,
            /* [in] */ POINT ptIN,
            /* [out] */ TangramPoint2d __RPC_FAR *pptOut);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *VisualFromPoint )( 
            IAtlTangramGdiWorld __RPC_FAR * This,
            /* [in] */ POINT pt,
            /* [in] */ const IID __RPC_FAR *iid,
            /* [iid_is][out] */ IUnknown __RPC_FAR *__RPC_FAR *pITangramVisual);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *CreateVisualForModel )( 
            IAtlTangramGdiWorld __RPC_FAR * This,
            /* [in] */ IATLTangramModel __RPC_FAR *pModel);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SelectVisual )( 
            IAtlTangramGdiWorld __RPC_FAR * This,
            /* [in] */ IAtlTangramVisual __RPC_FAR *pSelectedVisual,
            /* [in] */ BOOL bSelect);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Animate )( 
            IAtlTangramGdiWorld __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ModelToDevice )( 
            IAtlTangramGdiWorld __RPC_FAR * This,
            /* [in] */ TangramPoint2d pptIn,
            /* [out] */ POINT __RPC_FAR *pptOut);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *AddUpdateRect )( 
            IAtlTangramGdiWorld __RPC_FAR * This,
            /* [in] */ RECT rectUpdate);
        
        END_INTERFACE
    } IAtlTangramGdiWorldVtbl;

    interface IAtlTangramGdiWorld
    {
        CONST_VTBL struct IAtlTangramGdiWorldVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAtlTangramGdiWorld_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IAtlTangramGdiWorld_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IAtlTangramGdiWorld_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IAtlTangramGdiWorld_Initialize(This,hwnd,logicalCX,logicalCY)	\
    (This)->lpVtbl -> Initialize(This,hwnd,logicalCX,logicalCY)

#define IAtlTangramGdiWorld_DeviceToModel(This,ptIN,pptOut)	\
    (This)->lpVtbl -> DeviceToModel(This,ptIN,pptOut)

#define IAtlTangramGdiWorld_VisualFromPoint(This,pt,iid,pITangramVisual)	\
    (This)->lpVtbl -> VisualFromPoint(This,pt,iid,pITangramVisual)

#define IAtlTangramGdiWorld_CreateVisualForModel(This,pModel)	\
    (This)->lpVtbl -> CreateVisualForModel(This,pModel)

#define IAtlTangramGdiWorld_SelectVisual(This,pSelectedVisual,bSelect)	\
    (This)->lpVtbl -> SelectVisual(This,pSelectedVisual,bSelect)

#define IAtlTangramGdiWorld_Animate(This)	\
    (This)->lpVtbl -> Animate(This)


#define IAtlTangramGdiWorld_ModelToDevice(This,pptIn,pptOut)	\
    (This)->lpVtbl -> ModelToDevice(This,pptIn,pptOut)

#define IAtlTangramGdiWorld_AddUpdateRect(This,rectUpdate)	\
    (This)->lpVtbl -> AddUpdateRect(This,rectUpdate)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE IAtlTangramGdiWorld_ModelToDevice_Proxy( 
    IAtlTangramGdiWorld __RPC_FAR * This,
    /* [in] */ TangramPoint2d pptIn,
    /* [out] */ POINT __RPC_FAR *pptOut);


void __RPC_STUB IAtlTangramGdiWorld_ModelToDevice_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramGdiWorld_AddUpdateRect_Proxy( 
    IAtlTangramGdiWorld __RPC_FAR * This,
    /* [in] */ RECT rectUpdate);


void __RPC_STUB IAtlTangramGdiWorld_AddUpdateRect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAtlTangramGdiWorld_INTERFACE_DEFINED__ */


#ifndef __IAtlTangramGdiVisual_INTERFACE_DEFINED__
#define __IAtlTangramGdiVisual_INTERFACE_DEFINED__

/* interface IAtlTangramGdiVisual */
/* [unique][helpstring][uuid][object] */ 


EXTERN_C const IID IID_IAtlTangramGdiVisual;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("09A63AEF-AED1-11D0-80C9-00609714FDFE")
    IAtlTangramGdiVisual : public IAtlTangramVisual
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Initialize( 
            /* [in] */ IATLTangramModel __RPC_FAR *pModel,
            /* [in] */ IAtlTangramGdiWorld __RPC_FAR *pWorld) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE IsPtIn( 
            /* [in] */ POINT pt) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetBoundingRect( 
            /* [out] */ RECT __RPC_FAR *pBoundingRect) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE DrawOn( 
            /* [in] */ IAtlTangramCanvas __RPC_FAR *pCanvas) = 0;
        
        virtual /* [helpstring] */ HRESULT STDMETHODCALLTYPE ReleaseConnectionPoint( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IAtlTangramGdiVisualVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IAtlTangramGdiVisual __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IAtlTangramGdiVisual __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IAtlTangramGdiVisual __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetModel )( 
            IAtlTangramGdiVisual __RPC_FAR * This,
            /* [in] */ const IID __RPC_FAR *iid,
            /* [iid_is][out] */ IUnknown __RPC_FAR *__RPC_FAR *ppI);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetSelected )( 
            IAtlTangramGdiVisual __RPC_FAR * This,
            /* [in] */ BOOL bSelected);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Initialize )( 
            IAtlTangramGdiVisual __RPC_FAR * This,
            /* [in] */ IATLTangramModel __RPC_FAR *pModel,
            /* [in] */ IAtlTangramGdiWorld __RPC_FAR *pWorld);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *IsPtIn )( 
            IAtlTangramGdiVisual __RPC_FAR * This,
            /* [in] */ POINT pt);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetBoundingRect )( 
            IAtlTangramGdiVisual __RPC_FAR * This,
            /* [out] */ RECT __RPC_FAR *pBoundingRect);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *DrawOn )( 
            IAtlTangramGdiVisual __RPC_FAR * This,
            /* [in] */ IAtlTangramCanvas __RPC_FAR *pCanvas);
        
        /* [helpstring] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *ReleaseConnectionPoint )( 
            IAtlTangramGdiVisual __RPC_FAR * This);
        
        END_INTERFACE
    } IAtlTangramGdiVisualVtbl;

    interface IAtlTangramGdiVisual
    {
        CONST_VTBL struct IAtlTangramGdiVisualVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAtlTangramGdiVisual_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IAtlTangramGdiVisual_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IAtlTangramGdiVisual_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IAtlTangramGdiVisual_GetModel(This,iid,ppI)	\
    (This)->lpVtbl -> GetModel(This,iid,ppI)

#define IAtlTangramGdiVisual_SetSelected(This,bSelected)	\
    (This)->lpVtbl -> SetSelected(This,bSelected)


#define IAtlTangramGdiVisual_Initialize(This,pModel,pWorld)	\
    (This)->lpVtbl -> Initialize(This,pModel,pWorld)

#define IAtlTangramGdiVisual_IsPtIn(This,pt)	\
    (This)->lpVtbl -> IsPtIn(This,pt)

#define IAtlTangramGdiVisual_GetBoundingRect(This,pBoundingRect)	\
    (This)->lpVtbl -> GetBoundingRect(This,pBoundingRect)

#define IAtlTangramGdiVisual_DrawOn(This,pCanvas)	\
    (This)->lpVtbl -> DrawOn(This,pCanvas)

#define IAtlTangramGdiVisual_ReleaseConnectionPoint(This)	\
    (This)->lpVtbl -> ReleaseConnectionPoint(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE IAtlTangramGdiVisual_Initialize_Proxy( 
    IAtlTangramGdiVisual __RPC_FAR * This,
    /* [in] */ IATLTangramModel __RPC_FAR *pModel,
    /* [in] */ IAtlTangramGdiWorld __RPC_FAR *pWorld);


void __RPC_STUB IAtlTangramGdiVisual_Initialize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramGdiVisual_IsPtIn_Proxy( 
    IAtlTangramGdiVisual __RPC_FAR * This,
    /* [in] */ POINT pt);


void __RPC_STUB IAtlTangramGdiVisual_IsPtIn_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramGdiVisual_GetBoundingRect_Proxy( 
    IAtlTangramGdiVisual __RPC_FAR * This,
    /* [out] */ RECT __RPC_FAR *pBoundingRect);


void __RPC_STUB IAtlTangramGdiVisual_GetBoundingRect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE IAtlTangramGdiVisual_DrawOn_Proxy( 
    IAtlTangramGdiVisual __RPC_FAR * This,
    /* [in] */ IAtlTangramCanvas __RPC_FAR *pCanvas);


void __RPC_STUB IAtlTangramGdiVisual_DrawOn_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring] */ HRESULT STDMETHODCALLTYPE IAtlTangramGdiVisual_ReleaseConnectionPoint_Proxy( 
    IAtlTangramGdiVisual __RPC_FAR * This);


void __RPC_STUB IAtlTangramGdiVisual_ReleaseConnectionPoint_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IAtlTangramGdiVisual_INTERFACE_DEFINED__ */



#ifndef __ATLGdiWorldAttrib_LIBRARY_DEFINED__
#define __ATLGdiWorldAttrib_LIBRARY_DEFINED__

/* library ATLGdiWorldAttrib */
/* [helpstring][uuid][version] */ 


EXTERN_C const IID LIBID_ATLGdiWorldAttrib;

EXTERN_C const CLSID CLSID_CAtlTangramGdiVisual;

#ifdef __cplusplus

class DECLSPEC_UUID("028B1533-5DF2-4b40-A636-CDFDAD38678E")
CAtlTangramGdiVisual;
#endif

EXTERN_C const CLSID CLSID_CAtlGdiWorld;

#ifdef __cplusplus

class DECLSPEC_UUID("EE10B316-9599-4f96-8320-53077D73D65A")
CAtlGdiWorld;
#endif
#endif /* __ATLGdiWorldAttrib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  HDC_UserSize(     unsigned long __RPC_FAR *, unsigned long            , HDC __RPC_FAR * ); 
unsigned char __RPC_FAR * __RPC_USER  HDC_UserMarshal(  unsigned long __RPC_FAR *, unsigned char __RPC_FAR *, HDC __RPC_FAR * ); 
unsigned char __RPC_FAR * __RPC_USER  HDC_UserUnmarshal(unsigned long __RPC_FAR *, unsigned char __RPC_FAR *, HDC __RPC_FAR * ); 
void                      __RPC_USER  HDC_UserFree(     unsigned long __RPC_FAR *, HDC __RPC_FAR * ); 

unsigned long             __RPC_USER  HPALETTE_UserSize(     unsigned long __RPC_FAR *, unsigned long            , HPALETTE __RPC_FAR * ); 
unsigned char __RPC_FAR * __RPC_USER  HPALETTE_UserMarshal(  unsigned long __RPC_FAR *, unsigned char __RPC_FAR *, HPALETTE __RPC_FAR * ); 
unsigned char __RPC_FAR * __RPC_USER  HPALETTE_UserUnmarshal(unsigned long __RPC_FAR *, unsigned char __RPC_FAR *, HPALETTE __RPC_FAR * ); 
void                      __RPC_USER  HPALETTE_UserFree(     unsigned long __RPC_FAR *, HPALETTE __RPC_FAR * ); 

unsigned long             __RPC_USER  HWND_UserSize(     unsigned long __RPC_FAR *, unsigned long            , HWND __RPC_FAR * ); 
unsigned char __RPC_FAR * __RPC_USER  HWND_UserMarshal(  unsigned long __RPC_FAR *, unsigned char __RPC_FAR *, HWND __RPC_FAR * ); 
unsigned char __RPC_FAR * __RPC_USER  HWND_UserUnmarshal(unsigned long __RPC_FAR *, unsigned char __RPC_FAR *, HWND __RPC_FAR * ); 
void                      __RPC_USER  HWND_UserFree(     unsigned long __RPC_FAR *, HWND __RPC_FAR * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif



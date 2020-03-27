// File: gdiworldiface.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "..\atlmodel\atlmodeliface.h"
#include "..\atltangramCanvas\atlTangramcanvasIface.h"

[ object,
  uuid(76B8FAB8-0BAB-4B79-A301-F18C795A2E1C),
  helpstring("ITangramVisual Interface"),
  pointer_default(unique)
]
__interface IAtlTangramVisual : IUnknown
{
	HRESULT GetModel(	[in] REFIID iid, 
						[out, iid_is(iid)] IUnknown** ppI);
	HRESULT SetSelected([in] BOOL bSelected) ;
};

[ object,
  uuid(F672FEDB-0C1D-4DF9-B852-4A0B706748F8),
  helpstring("ITangramWorld Interface"),
  pointer_default(unique)
]
__interface IAtlTangramWorld : IUnknown
{
	HRESULT Initialize([in] HWND hwnd, [in] double logicalCX, [in] double logicalCY) ;
	HRESULT DeviceToModel([in] POINT ptIN, [out] TangramPoint2d* pptOut) ;
	HRESULT VisualFromPoint([in] POINT pt, 
							[in] REFIID iid, 
							[out, iid_is(iid)] IUnknown** pITangramVisual) ;

	HRESULT CreateVisualForModel([in] IATLTangramModel* pModel) ;
	HRESULT SelectVisual([in] IAtlTangramVisual* pSelectedVisual, [in] BOOL bSelect);
	HRESULT Animate() ; 
};

[ object,
  uuid(A3DC0F60-F413-4828-980F-33FD05E59FE0),
  helpstring("IAtlTangramGdiWorld Interface"),
  pointer_default(unique)
]
__interface IAtlTangramGdiWorld : IAtlTangramWorld
{
	HRESULT __stdcall ModelToDevice(	[in] TangramPoint2d pptIn, [out] POINT* pptOut) ;
	HRESULT __stdcall AddUpdateRect([in] RECT rectUpdate) ; 
};

[ object,
  uuid(2BF1FC24-F8A0-4D84-BA30-C59423B3451B),
  helpstring("IAtlTangramGdiVisual Interface"),
  pointer_default(unique)
]
__interface IAtlTangramGdiVisual : IAtlTangramVisual
{
	HRESULT  __stdcall Initialize([in] IATLTangramModel* pModel, [in] IAtlTangramGdiWorld* pWorld) ;
	HRESULT  __stdcall IsPtIn([in] POINT pt) ;
	HRESULT  __stdcall GetBoundingRect([out] RECT* pBoundingRect) ;
	HRESULT  __stdcall DrawOn([in] IAtlTangramCanvas* pCanvas) ;    
	[helpstring("method ReleaseConnectionPoint")] 
	HRESULT  __stdcall ReleaseConnectionPoint();
};



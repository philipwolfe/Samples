// File: atltangramcanvasiface.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

[ object,
  uuid(706DD59C-C668-48D3-ADB9-D873E730919E),	
  helpstring("IAtlTangramCanvas Interface"),
  pointer_default(unique)
]
__interface IAtlTangramCanvas : IUnknown
{
	HRESULT Initialize([in] HWND hWnd, [in] long cx, [in] long cy) ;
	HRESULT Paint([in] HDC hdcDest, [in] RECT rectUpdate) ;
	HRESULT Update([in] RECT rectUpdate) ;
	HRESULT GetHDC([out] HDC* pHDC) ;  
	HRESULT SetPalette([in]HPALETTE hPal); 
	HRESULT OnQueryNewPalette([in] HWND hWndReceived) ;
};
// AtlTangramCanvasImpl.h : Declaration of the CAtlTangramCanvas
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

#pragma once
#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CAtlTangramCanvas
[ coclass,
  uuid(B272D9C4-F46B-4ADE-88AE-BDAB47D96BF5),
  helpstring("AtlTangramCanvas Attrib Class"),
  progid("AtlTangram.AtlTangramCanvasAttrib.1"),
  vi_progid("AtlTangram.AtlTangramCanvasAttrib"),
  default("IAtlTangramCanvas")//,
  //registration_script("control.rgs")
]
class ATL_NO_VTABLE CAtlTangramCanvas : 
	public IAtlTangramCanvas
{
public:
	CAtlTangramCanvas():
		m_hWnd(NULL),
		m_hbmp(NULL),
		m_pBits(NULL),
		m_hdc(NULL),
		m_hPal(NULL)
	{
		m_sizeDIB.cx = m_sizeDIB.cy = 0; 
	}

	~CAtlTangramCanvas()
	{
		// Select the old bitmap back into the buffer DC.
		if (m_hbmOld)
		{
			::SelectObject(m_hdc, m_hbmOld);
		}

		// Delete bitmap.
		if (m_hbmp) 
		{
			DeleteObject(m_hbmp);
		}

		// Delete DC.
		if (m_hdc) 
		{
			::DeleteDC(m_hdc) ;
		}
	}

DECLARE_ONLY_AGGREGATABLE(CAtlTangramCanvas)


// IAtlTangramCanvas
public:
	virtual HRESULT __stdcall Initialize(HWND hWnd, long cx, long cy) ;//Initialize can be called multiple times.
	virtual HRESULT __stdcall Paint(HDC hdcDest, RECT rectUpdate) ;
	virtual HRESULT __stdcall Update(RECT rectUpdate);
	virtual HRESULT __stdcall GetHDC(HDC* phdc ) ; 
	virtual HRESULT __stdcall SetPalette(HPALETTE hPal); 
	virtual HRESULT __stdcall OnQueryNewPalette(HWND hWndReceived) ;
//Member Variables
private:
	// Handle to window associated with this Canvas.
	HWND m_hWnd ; 

	// Handle to dib section.
	HBITMAP m_hbmp ;

	// Handle to old bitmap.
	HBITMAP m_hbmOld ;

	// Pointer to the bits.
	void* m_pBits ;		

	// Size of the canvas.
	SIZE m_sizeDIB ;

	// Handle to the device memory context for the dib section.
	HDC m_hdc ;

	// Handle to the palette used by the dib section.
	HPALETTE m_hPal;
};


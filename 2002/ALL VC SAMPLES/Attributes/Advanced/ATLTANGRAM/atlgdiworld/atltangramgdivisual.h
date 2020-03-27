// AtlTangramGdiVisual.h : Declaration of the CAtlTangramGdiVisual
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#ifndef __ATLTANGRAMGDIVISUAL_H_
#define __ATLTANGRAMGDIVISUAL_H_

#include "resource.h"       // main symbols
#include "..\util.h"

/////////////////////////////////////////////////////////////////////////////
// CAtlTangramGdiVisual
[ coclass,
  uuid(41C45028-58F0-4FA6-8DAF-5AE94C2EC46E),
  helpstring("AtlTangramGdiVisualAttrib Class"),
  progid("AtlTangram.AtlTangramGdiVisualAttrib.1"),
  vi_progid("AtlTangram.AtlTangramGdiVisualAttrib"),
  default("IAtlTangramGdiVisual"),
  com_interface_entry("COM_INTERFACE_ENTRY(IAtlTangramVisual)"),
  com_interface_entry("COM_INTERFACE_ENTRY(IATLTangramModelEvent)"),
  event_receiver(com,true)
]
class ATL_NO_VTABLE CAtlTangramGdiVisual :
	public IAtlTangramGdiVisual,
	public IATLTangramModelEvent   // event sink interface
{
public:
	CAtlTangramGdiVisual():
		m_pGdiWorld(0),
		m_pModel(0),
		m_pIConnectionPoint(0),
		m_ptVertices(0),
		m_dwCookie(0),
		m_bSelected(FALSE)
	{
	}

	~CAtlTangramGdiVisual();


public:

	// IAtlTangramVisual
	virtual HRESULT  __stdcall GetModel( const IID& iid, IUnknown** ppI) ;
	virtual HRESULT  __stdcall SetSelected(BOOL bSelected) ;

	// IAtlTangramGdiVisual
	virtual HRESULT  __stdcall Initialize(IATLTangramModel* pModel, IAtlTangramGdiWorld* pWorld) ;
	virtual HRESULT  __stdcall IsPtIn(POINT pt) ;
	virtual HRESULT  __stdcall GetBoundingRect(RECT* pBoundingRect) ;
	virtual HRESULT  __stdcall DrawOn(IAtlTangramCanvas* pCanvas) ;

	// ITangramModelEvent
	virtual HRESULT __stdcall OnModelChange() ;

	// Helper function
	void SyncToModel() ;

	HRESULT __stdcall AdviseConnectionPoint(IATLTangramModel* pModel);
	STDMETHOD(ReleaseConnectionPoint)();

// Member Variables
private:
	// Event Sink support.
	IConnectionPoint* m_pIConnectionPoint ;
	DWORD m_dwCookie ;

	// Backpointer to parent World component.
	IAtlTangramGdiWorld* m_pGdiWorld ;

	// Pointer to associated model.
	IATLTangramModel* m_pModel ;

	// Array of vertices.
	POINT* m_ptVertices ;
	long m_cVertices ;

	// Selection status.
	BOOL m_bSelected ;
};

#endif //__ATLTANGRAMGDIVISUAL_H_

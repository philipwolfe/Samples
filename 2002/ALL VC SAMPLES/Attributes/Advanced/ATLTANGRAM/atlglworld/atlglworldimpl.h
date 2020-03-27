// AtlGLWorldImpl.h : Declaration of the CAtlGLWorld
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

#ifndef __ATLGLWORLD_H_
#define __ATLGLWORLD_H_

#include "resource.h"       // main symbols
// STL Headers
#include <new.h>
#include <algorithm>
#include <xmemory>
#include <list>
#include "CGL.h"
#include "AtlGLWorldiface.h"

///////////////////////////////////////////////////////////
//
//  Structures
//
typedef struct tagTangramPoint3d
{
	double x ;
	double y ;
	double z ;
} TangramPoint3d ;

/////////////////////////////////////////////////////////////////////////////
// CAtlGLWorld
[ coclass,
  uuid(329A1DF3-D81D-43a7-9F96-A31C63EA9C75),
  helpstring("AtlTangramGLWorldAttrib Class"),
  progid("AtlTangram.AtlTangramGLWorldAttrib.1"),
  vi_progid("AtlTangram.AtlTangramGLWorldAttrib"),
  default("IAtlTangramGLWorld"),
  com_interface_entry("COM_INTERFACE_ENTRY(IAtlTangramWorld)"),
  com_interface_entry("COM_INTERFACE_ENTRY_AGGREGATE(__uuidof(IAtlTangramCanvas), m_pCanvasUnknown )"),
  implements_category("CATID_AtlTangramWorldCategory"),
  registration_script("control.rgs")
]
class ATL_NO_VTABLE CAtlGLWorld :
	public IAtlTangramGLWorld
{
public:
	CAtlGLWorld()
	:   m_pCanvas(NULL),
		m_pCanvasUnknown(NULL),
		m_pGL(NULL),
		m_hdc(NULL),
		m_hMainWnd(NULL),
		m_bPicking(FALSE)

	{
		m_ptLowerLeft.x = m_ptLowerLeft.y = 0.0 ;
		m_ptUpperRight.x = m_ptUpperRight.y = 0.0;
	}

	~CAtlGLWorld() ;

	void FinalRelease()
	{
		TCHAR buf[128];
		wsprintf(buf,_T("GLWorld: m_dwRef = %d\n"), m_dwRef);
		ATLTRACE(buf);
		// Release the ICanvas interface on the aggregated object.
		if (m_pCanvas != NULL)
		{
			// Add a reference back to the outer object.
			GetControllingUnknown()->AddRef() ;
			// Remove the reference on the inner and outer objects.
			m_pCanvas->Release() ;
			m_pCanvas = NULL ;
		}
		wsprintf(buf,_T("GLWorld: m_dwRef = %d\n"), m_dwRef);
		ATLTRACE(buf);

		// Release our hold on the inner object.
		if (m_pCanvasUnknown != NULL)
		{
			m_pCanvasUnknown->Release() ;
			m_pCanvasUnknown = NULL ;
		}
		wsprintf(buf,_T("GLWorld: m_dwRef = %d\n"), m_dwRef);
		ATLTRACE(buf);
	}


	// Special Registration
	static void SpecialReg(BOOL bRegister) ;
private:
	// Declare the delegating IUnknown.
	DECLARE_GET_CONTROLLING_UNKNOWN()

	// IAtlTangramWorld Members
	virtual HRESULT __stdcall Initialize(HWND hwnd, double logicalCX, double logicalCY) ;
	virtual HRESULT __stdcall DeviceToModel(POINT ptIN, TangramPoint2d* pptOut) ;

	virtual HRESULT __stdcall VisualFromPoint(  POINT pt,
												REFIID iid,
												IUnknown** ppIAtlTangramVisual) ;
	virtual HRESULT __stdcall CreateVisualForModel(IATLTangramModel* pModel) ;
	virtual HRESULT __stdcall SelectVisual(IAtlTangramVisual* pSelectedVisual, BOOL bSelect) ;
	virtual HRESULT __stdcall Animate() ;

	// ITangramGLWorld
	virtual HRESULT ModelToDevice(TangramPoint2d ptIn, TangramPoint2d* pptOut);



public:
	// OpenGL Support Functions
	BOOL GLResize(int cx, int cy) ;
	BOOL GLSetup() ;
	BOOL GLRender() ;

private:
	// Member Variables
#pragma warning(disable:4786)
	typedef std::list<IAtlTangramGLVisual*> CVisualList;
	CVisualList m_VisualList ;
#pragma warning(default:4786)

	// World Members
	HDC m_hdc ;

	// Aggregated Canvas Component
	IAtlTangramCanvas* m_pCanvas ;
	IUnknown* m_pCanvasUnknown ;

	// Handle to the main window.
	HWND m_hMainWnd ;

	// OpenGL Support Code
	CGL* m_pGL ;

	// OpenGL Picking Support
	BOOL m_bPicking ;
	int Pick(POINT pt) ;

	// Coordinates of lowerleft and upper right of the window.
	TangramPoint3d m_ptLowerLeft ;
	TangramPoint3d m_ptUpperRight ;
};

#endif //__ATLGLWORLD_H_

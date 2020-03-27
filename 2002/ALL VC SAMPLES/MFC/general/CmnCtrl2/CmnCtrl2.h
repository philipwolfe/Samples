// CmnCtrl2.h : main header file for the CMNCTRL2 application
//

// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#if !defined(AFX_CMNCTRL2_H__A14ECE90_E24D_11D0_8286_00C04FD73634__INCLUDED_)
#define AFX_CMNCTRL2_H__A14ECE90_E24D_11D0_8286_00C04FD73634__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CCmnCtrl2App:
// See CmnCtrl2.cpp for the implementation of this class
//

class CCmnCtrl2App : public CWinApp
{
public:
	CCmnCtrl2App();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CCmnCtrl2App)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CCmnCtrl2App)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_CMNCTRL2_H__A14ECE90_E24D_11D0_8286_00C04FD73634__INCLUDED_)

// HttpSvr.h : main header file for the HTTPSVR application
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols

#define PORT_HTTP       80
#define WSM_DOCHIT      (WM_USER+1)
#define WSM_CGIDONE     (WM_USER+2)

/////////////////////////////////////////////////////////////////////////////
// CHttpSvrApp:
// See HttpSvr.cpp for the implementation of this class
//

class CHttpSvrApp : public CWinApp
{
public:
	void RegisterLogFile( void );
	CHttpSvrApp();
	~CHttpSvrApp();
	CString         m_strDefSvr;

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CHttpSvrApp)
	public:
	virtual BOOL InitInstance();
	virtual BOOL OnIdle(LONG lCount);
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CHttpSvrApp)
	afx_msg void OnAppAbout();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

// global helper routines.....
void AddFile( CString& strPath, UINT uStr );
void AddFile( CString& strPath, const CString& strFile);

/////////////////////////////////////////////////////////////////////////////

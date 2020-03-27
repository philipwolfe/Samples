// WebDbg.h : main header file for the WebDbg application
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols


/////////////////////////////////////////////////////////////////////////////
// Struct to deal with Assert and Trace messages
//

#define HPS_ASSERT_MESSAGE 0
#define HPS_TRACE_MESSAGE 1

//Struct to send messages to child window
struct ThreadMessageParam
{
	HANDLE hEvent;
	INT    nRet;
	INT    nMsgType;
};

/////////////////////////////////////////////////////////////////////////////
// CWebDbgApp:
// See WebDbg.cpp for the implementation of this class
//

class CWebDbgApp : public CWinApp
{
public:
	CWebDbgApp();
	~CWebDbgApp();
	BOOL WantStackTrace();
	LPCTSTR GetPipeName() { return (LPCTSTR)m_strPipeName; }
	HANDLE GetPipe()
	{
		return m_hPipe;
	}
	BOOL CreatePipe();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CWebDbgApp)
	public:
	virtual BOOL InitInstance();
	//virtual BOOL PreTranslateMessage(MSG* pMsg);
	virtual BOOL ExitInstance();
	//}}AFX_VIRTUAL

// Implementation
	void QuitPipeThread();
	void BeginPipeThread();
	HRESULT TestAccessToPipe();
	HRESULT SendPipeMessage(const DEBUG_SERVER_MESSAGE *pMsg);
	HANDLE m_hPipe;

public:
	//{{AFX_MSG(CWebDbgApp)
	afx_msg void OnAppAbout();
	afx_msg void OnViewStacktrace();
	afx_msg void OnUpdateViewStacktrace(CCmdUI* pCmdUI);
	afx_msg void OnAppPipe();
	afx_msg void OnAppPermissions();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

private:
	HANDLE m_hMutexOneInstance;
	BOOL m_bWantStackTrace;
	CString m_strPipeName;
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

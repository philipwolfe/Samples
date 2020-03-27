// MailClientMFC.h : main header file for the PROJECT_NAME application
// (c) 2000 Microsoft Corporation
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

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CMailClientApp:
//

class CMailClientApp : public CWinApp
{
public:
	CMailClientApp();
	~CMailClientApp();
	
public:
	virtual BOOL InitInstance();

	LPCTSTR GetLogin() { return m_strLogin; }
	LPCTSTR GetPassword() { return m_strPassword; }
	
	BSTR GetSessionID() { return m_bstrSessionID; }
	LONG GetUserID() { return m_lUserID; }
	void SetSessionID(BSTR bstrSessionID) { m_bstrSessionID = bstrSessionID; }
	void SetUserID(long lUserID) { m_lUserID = lUserID; }

// Implementation
	DECLARE_MESSAGE_MAP()

private:
	CString m_strLogin;
	CString m_strPassword;
	BSTR m_bstrSessionID;
	LONG m_lUserID;
};


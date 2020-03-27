// MailClientMFC.cpp : Defines the class behaviors for the application.
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "MailClientMFC.h"
#include "LoginDlg.h"
#include "MainDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMailClientApp

BEGIN_MESSAGE_MAP(CMailClientApp, CWinApp)
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMailClientApp construction

CMailClientApp::CMailClientApp()
{
	m_bstrSessionID = NULL;
}

CMailClientApp::~CMailClientApp()
{
	// Free the session ID if there is one
	if (m_bstrSessionID)
		SysFreeString(m_bstrSessionID);
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CMailClientApp object

CMailClientApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CMailClientApp initialization

BOOL CMailClientApp::InitInstance()
{

	InitCommonControls();
	CoInitialize(NULL);

	// Create a block so that the destructors get called before CoUninitialize()
	{
		// Present the initial login dialog
		CLoginDlg dlg;
		if (dlg.DoModal() == IDCANCEL)
			goto cleanup;

		// Set the member data
		m_strLogin = dlg.GetLogin();
		m_strPassword = dlg.GetPassword();
		m_lUserID = dlg.GetUserID();
		m_bstrSessionID = dlg.GetSessionID();
	}
	{
		while (1)
		{
			// Present the main dialog
			// If the dialog returns anything but IDOK, we need to relogin
			CMainDlg mainDlg;
			if (mainDlg.DoModal() == IDOK)
				break;

			// Present the login dialog
			CLoginDlg loginDlg;
			if (loginDlg.DoModal() == IDCANCEL)
				break;

			// Set the member data
			m_strLogin = loginDlg.GetLogin();
			m_strPassword = loginDlg.GetPassword();
			m_lUserID = loginDlg.GetUserID();
			m_bstrSessionID = loginDlg.GetSessionID();
		}


	}
	// Clean up and exit
cleanup:
	CoUninitialize();
	return FALSE;
}

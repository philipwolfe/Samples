// HttpClient.cpp : Defines the class behaviors for the application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "HttpClient.h"
#include "HttpClientDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif



BEGIN_MESSAGE_MAP(CHttpClientApp, CWinApp)
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()



CHttpClientApp theApp;


BOOL CHttpClientApp::InitInstance()
{
	CWinApp::InitInstance();

	AfxEnableControlContainer();

	CHttpClientDlg dlg;

	m_pMainWnd = &dlg;

	dlg.DoModal();

	return FALSE;
}

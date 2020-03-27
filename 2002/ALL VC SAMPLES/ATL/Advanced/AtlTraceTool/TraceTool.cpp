// TraceTool.cpp : Defines the class behaviors for the application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "TraceTool.h"
#include "TraceToolDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


// CTraceToolApp

BEGIN_MESSAGE_MAP(CTraceToolApp, CWinApp)
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()


// CTraceToolApp construction

CTraceToolApp::CTraceToolApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CTraceToolApp object

CTraceToolApp theApp;


// CTraceToolApp initialization

static const LPCTSTR g_pszEventName = _T( "ATLTraceTool_Instance" );

BOOL CTraceToolApp::InitInstance()
{
	// Check to see if another instance of the tool is running
	BOOL bCreated = m_hSingleInstanceEvent.Create( NULL, FALSE, FALSE, g_pszEventName );
	if( !bCreated )
	{
		return( FALSE );
	}
	if( ::GetLastError() == ERROR_ALREADY_EXISTS )
	{
		m_hSingleInstanceEvent.Set();  // Notify the original instance
		return( FALSE );
	}

	CWinApp::InitInstance();


	CTraceToolDlg dlg;
	m_pMainWnd = &dlg;
	INT_PTR nResponse = dlg.DoModal();
	if (nResponse == IDOK)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with OK
	}
	else if (nResponse == IDCANCEL)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with Cancel
	}

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}

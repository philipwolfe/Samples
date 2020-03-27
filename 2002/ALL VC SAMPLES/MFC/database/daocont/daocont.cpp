// DAOCont.cpp : Defines the class behaviors for the application.
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "DAOCont.h"
#include "DAOCnDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDAOContApp

BEGIN_MESSAGE_MAP(CDAOContApp, CWinApp)
	//{{AFX_MSG_MAP(CDAOContApp)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDAOContApp construction / destruction

CDAOContApp::CDAOContApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}

CDAOContApp::~CDAOContApp()
{
	AfxDaoTerm();
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CDAOContApp object

CDAOContApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CDAOContApp initialization

BOOL CDAOContApp::InitInstance()
{
	AfxEnableControlContainer();

	CDAOContDlg dlg;
	m_pMainWnd = &dlg;
	int nResponse = (int)dlg.DoModal();
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

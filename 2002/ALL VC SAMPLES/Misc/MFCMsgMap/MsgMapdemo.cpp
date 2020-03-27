// MsgMapdemo.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "MsgMapdemo.h"
#include "MsgMapdemoDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


// CMsgMapdemoApp

BEGIN_MESSAGE_MAP(CMsgMapdemoApp, CWinApp)
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()


// CMsgMapdemoApp construction

CMsgMapdemoApp::CMsgMapdemoApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CMsgMapdemoApp object

CMsgMapdemoApp theApp;


// CMsgMapdemoApp initialization

BOOL CMsgMapdemoApp::InitInstance()
{
	CWinApp::InitInstance();


	CMsgMapdemoDlg dlg;
	m_pMainWnd = &dlg;
	int nResponse = dlg.DoModal();
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

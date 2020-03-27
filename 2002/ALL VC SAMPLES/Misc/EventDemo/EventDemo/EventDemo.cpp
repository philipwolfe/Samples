// EventDemo.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "EventDemo.h"
#include "EventDemoDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


// CEventDemoApp

BEGIN_MESSAGE_MAP(CEventDemoApp, CWinApp)
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()


// CEventDemoApp construction

CEventDemoApp::CEventDemoApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CEventDemoApp object

CEventDemoApp theApp;


// CEventDemoApp initialization

BOOL CEventDemoApp::InitInstance()
{
	CWinApp::InitInstance();

	AfxEnableControlContainer();


	CEventDemoDlg dlg;
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

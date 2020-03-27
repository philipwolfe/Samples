// PrintDlgEx.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "PrintDlgEx.h"
#include "PrintDlgExDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


// CPrintDlgExApp

BEGIN_MESSAGE_MAP(CPrintDlgExApp, CWinApp)
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()


// CPrintDlgExApp construction

CPrintDlgExApp::CPrintDlgExApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}


// The one and only CPrintDlgExApp object

CPrintDlgExApp theApp;


// CPrintDlgExApp initialization

BOOL CPrintDlgExApp::InitInstance()
{
	CWinApp::InitInstance();

	AfxEnableControlContainer();


	CPrintDlgExDlg dlg;
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

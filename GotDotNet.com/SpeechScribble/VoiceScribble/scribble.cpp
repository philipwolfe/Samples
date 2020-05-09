// Scribble.cpp : Defines the class behaviors for the application.
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
#include "Scribble.h"

#include "MainFrm.h"
#include "ChildFrm.h"
#include "IpFrame.h"
#include "ScribDoc.h"
#include "ScribVw.h"



#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CScribbleApp

BEGIN_MESSAGE_MAP(CScribbleApp, CWinApp)
	//{{AFX_MSG_MAP(CScribbleApp)
	ON_COMMAND(ID_APP_ABOUT, OnAppAbout)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
	// Standard file based document commands
	ON_COMMAND(ID_FILE_NEW, CWinApp::OnFileNew)
	ON_COMMAND(ID_FILE_OPEN, CWinApp::OnFileOpen)
	// Standard print setup command
	ON_COMMAND(ID_FILE_PRINT_SETUP, CWinApp::OnFilePrintSetup)
	ON_COMMAND(ID_GRAPHIC_MODE, OnModeGraphic)
	ON_UPDATE_COMMAND_UI(ID_GRAPHIC_MODE, OnUpdateModeGraphic)
	ON_COMMAND(ID_EDIT_MODE, OnModeEdit)
	ON_UPDATE_COMMAND_UI(ID_EDIT_MODE, OnUpdateModeEdit)
	ON_COMMAND(ID_ENABLE_GRAMMAR, OnEnableGrammar)
	ON_UPDATE_COMMAND_UI(ID_ENABLE_GRAMMAR, OnUpdateEnableGrammar)
	ON_COMMAND(ID_DISABLE_GRAMMAR, OnDisableGrammar)
	ON_UPDATE_COMMAND_UI(ID_DISABLE_GRAMMAR, OnUpdateDisableGrammar)

END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CScribbleApp construction

CScribbleApp::CScribbleApp()
{
	m_bIsEditMode = false;
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CScribbleApp object

CScribbleApp theApp;
CSAPIWrapper_SpeechRecoEnv* g_SpeechEngine = &theApp.m_speechRecoEnv;

// This identifier was generated to be statistically unique for your app.
// You may change it if you prefer to choose a specific identifier.

// {7559FD90-9B93-11CE-B0F0-00AA006C28B3}
static const CLSID clsid =
{ 0x7559fd90, 0x9b93, 0x11ce, { 0xb0, 0xf0, 0x0, 0xaa, 0x0, 0x6c, 0x28, 0xb3 } };

/////////////////////////////////////////////////////////////////////////////
// CScribbleApp initialization
BEGIN_VCOMMAND_MAP(CScribbleApp)
	ON_VCOMMAND_SIMPLE(VID_MODE_EDIT, OnVoiceModeEdit)
	ON_VCOMMAND_SIMPLE(VID_MODE_GRAPH, OnVoiceModeGraphic)
END_VCOMMAND_MAP()



BOOL CScribbleApp::InitInstance()
{
	// Initialize OLE libraries
	if (!AfxOleInit())
	{
		AfxMessageBox(IDP_OLE_INIT_FAILED);
		return FALSE;
	}

	// Standard initialization
	// If you are not using these features and wish to reduce the size
	//  of your final executable, you should remove from the following
	//  the specific initialization routines you do not need.

	LoadStdProfileSettings();  // Load standard INI file options (including MRU)

	
	HRESULT hRet =  m_speechRecoEnv.InitializeSAPI( ID_TurtleGraphics_GRAMMAR);
	if( !SUCCEEDED(hRet))
	{
		AfxMessageBox(_T("SAPI Initialization Failed"), MB_OK | MB_ICONSTOP);
		return FALSE;
	}
	m_speechRecoEnv.EnableGrammar();
	m_speechRecoEnv.AddSubscriber(this);
	EnableModeCommands();



	// Register the application's document templates.  Document templates
	//  serve as the connection between documents, frame windows and views.

	CMultiDocTemplate* pDocTemplate;
	pDocTemplate = new CMultiDocTemplate(
		IDR_SCRIBBTYPE,
		RUNTIME_CLASS(CScribbleDoc),
		RUNTIME_CLASS(CChildFrame), // custom MDI child frame
		RUNTIME_CLASS(CScribbleView));

	
	pDocTemplate->SetServerInfo(
		IDR_SCRIBBTYPE_SRVR_EMB, IDR_SCRIBBTYPE_SRVR_IP,
		RUNTIME_CLASS(CInPlaceFrame));

	AddDocTemplate(pDocTemplate);
	// Connect the COleTemplateServer to the document template.
	//  The COleTemplateServer creates new documents on behalf
	//  of requesting OLE containers by using information
	//  specified in the document template.
	m_server.ConnectTemplate(clsid, pDocTemplate, FALSE);

	// Register all OLE server factories as running.  This enables the
	//  OLE libraries to create objects from other applications.
	COleTemplateServer::RegisterAll();
		// Note: MDI applications register all server objects without regard
		//  to the /Embedding or /Automation on the command line.

	AfxInitRichEdit();

	// create main MDI Frame window
	CMainFrame* pMainFrame = new CMainFrame;
	if (!pMainFrame->LoadFrame(IDR_MAINFRAME))
		return FALSE;
	m_pMainWnd = pMainFrame;

	// Enable drag/drop open.  We don't call this in Win32, since a
	//  document file extension wasn't chosen while running AppWizard.
	m_pMainWnd->DragAcceptFiles();

	// Parse command line for standard shell commands, DDE, file open
	CCommandLineInfo cmdInfo;
	ParseCommandLine(cmdInfo);

	// Check to see if launched as OLE server
	if (cmdInfo.m_bRunEmbedded || cmdInfo.m_bRunAutomated)
	{
		// Application was run with /Embedding or /Automation.  Don't show the
		//  main window in this case.
		return TRUE;
	}


	// When a server application is launched stand-alone, it is a good idea
	//  to update the system registry in case it has been damaged.
	m_server.UpdateRegistry(OAT_INPLACE_SERVER);

	// Dispatch commands specified on the command line
	if (!ProcessShellCommand(cmdInfo))
		return FALSE;

	// The main window has been initialized, so show and update it.
	pMainFrame->ShowWindow(m_nCmdShow);
	pMainFrame->UpdateWindow();

	return TRUE;
}



int CScribbleApp::ExitInstance()
{
	// TODO: Add your specialized code here and/or call the base class
	m_speechRecoEnv.RemoveSubscriber(this);
	m_speechRecoEnv.CloseSAPI();
	return __super::ExitInstance();
}

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA
	
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
		// No message handlers
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

// App command to run the dialog
void CScribbleApp::OnAppAbout()
{
	CAboutDlg aboutDlg;
	aboutDlg.DoModal();
}

/////////////////////////////////////////////////////////////////////////////
// CScribbleApp commands

void CScribbleApp::OnModeGraphic()
{
	m_bIsEditMode = false;
	EnableModeCommands();
}
void CScribbleApp::OnUpdateModeGraphic(CCmdUI *pCmdUI)
{
	if( m_bIsEditMode )
		pCmdUI->SetCheck(0);
	else
		pCmdUI->SetCheck(1);

}

void CScribbleApp::OnModeEdit()
{
	m_bIsEditMode = true;
	EnableModeCommands();
}
void CScribbleApp::OnUpdateModeEdit(CCmdUI *pCmdUI)
{
	if( m_bIsEditMode )
		pCmdUI->SetCheck(1);
	else
		pCmdUI->SetCheck(0);
}


BOOL	CScribbleApp::OnVoiceModeGraphic()
{
	OnModeGraphic();
	// forward the message
	return FALSE;
}
BOOL	CScribbleApp::OnVoiceModeEdit()
{
	OnModeEdit();
	// forward the message
	return FALSE;
}



void	CScribbleApp::EnableModeCommands()
{
	m_speechRecoEnv.EnableRule(VID_MODE_GRAPH);
	m_speechRecoEnv.EnableRule(VID_MODE_EDIT);
	

	m_speechRecoEnv.EnableRule(VID_COMPILE, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_RUN, m_bIsEditMode);

	// Always on
	m_speechRecoEnv.EnableRule(VID_UNDO);
	m_speechRecoEnv.EnableRule(VID_RESET);

	m_speechRecoEnv.EnableRule(VID_FORWARD);
	m_speechRecoEnv.EnableRule(VID_LEFT);
	m_speechRecoEnv.EnableRule(VID_RIGHT);
	m_speechRecoEnv.EnableRule(VID_PENUP);
	m_speechRecoEnv.EnableRule(VID_PENDOWN);
	m_speechRecoEnv.EnableRule(VID_CLS);
	m_speechRecoEnv.EnableRule(VID_SLEEP);
	

	// Edit Mode Only
	m_speechRecoEnv.EnableRule(VID_CURRENT_VARS, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_DECLARE, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_SET, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_INCREMENT, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_DECREMENT, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_MULTIPLY, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_DIVIDE, m_bIsEditMode);

	m_speechRecoEnv.EnableRule(VID_IF, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_ELSE, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_ENDIF, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_DO, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_UNTIL, m_bIsEditMode);

	m_speechRecoEnv.EnableRule(VID_PROCEDURE, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_START, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_CALL, m_bIsEditMode);
	m_speechRecoEnv.EnableRule(VID_END, m_bIsEditMode);
	
	m_speechRecoEnv.EnableRule(VID_BOOL_OPERATOR, m_bIsEditMode);
	

}

void CScribbleApp::OnUpdateEnableGrammar(CCmdUI *pCmdUI)
{
	pCmdUI->SetCheck(m_speechRecoEnv.m_bGrammarEnabled?1:0);
}
void CScribbleApp::OnUpdateDisableGrammar(CCmdUI *pCmdUI)
{
	pCmdUI->SetCheck(m_speechRecoEnv.m_bGrammarEnabled?0:1);
}
void CScribbleApp::OnEnableGrammar()
{
	m_speechRecoEnv.EnableGrammar();
}
void CScribbleApp::OnDisableGrammar()
{
	m_speechRecoEnv.EnableGrammar(false);
}



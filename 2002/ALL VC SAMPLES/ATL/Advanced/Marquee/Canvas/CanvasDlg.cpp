// CanvasDlg.cpp
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// CanvasDlg.cpp : implementation file
//

#include "stdafx.h"
#include "Canvas.h"
#include "CanvasDlg.h"
#import "progid:PerfDisp.PerfMonDisp.1" no_namespace named_guids
#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()

// CCanvasDlg dialog

IMPLEMENT_DYNAMIC(CCanvasDlg, CDialog);
CCanvasDlg::CCanvasDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CCanvasDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	EnableAutomation();
}
CCanvasDlg::~CCanvasDlg()
{
}

void CCanvasDlg::DoDataExchange(CDataExchange* pDX)
{
	DDX_Control(pDX, IDC_DRAWAREA, m_wndDrawArea);
	CDialog::DoDataExchange(pDX);
}


BEGIN_DISPATCH_MAP(CCanvasDlg, CDialog)
	DISP_PROPERTY_EX(CCanvasDlg, "Width", GetWidth, SetNotSupported, VT_I4)
	DISP_PROPERTY_EX(CCanvasDlg, "Height", GetHeight, SetNotSupported, VT_I4)
	DISP_FUNCTION(CCanvasDlg, "DrawLine", DrawLine, VT_EMPTY, VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4)
	DISP_FUNCTION(CCanvasDlg, "FillRect", FillRect, VT_EMPTY, VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4)
	DISP_FUNCTION(CCanvasDlg, "FrameRect", FrameRect, VT_EMPTY, VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4)
	DISP_FUNCTION(CCanvasDlg, "Ellipse", Ellipse, VT_EMPTY, VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4 VTS_I4)
END_DISPATCH_MAP()

// Note: we add support for IID_ICanvas to support typesafe binding
//  from VBA.  This IID must match the GUID that is attached to the 
//  dispinterface in the .IDL file.

// {84A16C90-D8E4-4BD8-8901-40F6D8E762E6}
static const IID IID_ICanvas =
{ 0x84A16C90, 0xD8E4, 0x4BD8, { 0x89, 0x1, 0x40, 0xF6, 0xD8, 0xE7, 0x62, 0xE6 } };

BEGIN_INTERFACE_MAP(CCanvasDlg, CDialog)
	INTERFACE_PART(CCanvasDlg, IID_ICanvas, Dispatch)
END_INTERFACE_MAP()

BEGIN_MESSAGE_MAP(CCanvasDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_CLOSE()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_WM_TIMER()
	ON_WM_DESTROY()
END_MESSAGE_MAP()


// CCanvasDlg message handlers

BOOL CCanvasDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here
	m_wndDrawArea.Initialize();

	// create a script site
	CComObjectNoLock<CScriptDriver>* spScriptDriver = new CComObjectNoLock<CScriptDriver>;
	m_spScriptDriver = spScriptDriver;

	// load the scripting engine
	HRESULT hr;

	hr = m_spScriptDriver->Initialize(__uuidof(JScript));
	if (FAILED(hr))
		return TRUE;

    // add Canvas and PerfMonDisp items the the script's global namespace
	hr = m_spScriptDriver->AddNamedItem(L"Canvas", GetIDispatch(FALSE));
	if (FAILED(hr))
		return TRUE;

	CComPtr<IUnknown> spUnk;
	hr = spUnk.CoCreateInstance(__uuidof(CPerfMonDisp));
	if (FAILED(hr))
		return TRUE;

	hr = m_spScriptDriver->AddNamedItem(L"PerfMonDisp", spUnk);
	if (FAILED(hr))
		return TRUE;

    // load the file script.js into the script engine
	if (m_spScriptDriver->ParseScriptFile("script.js"))
		return TRUE;

    // set the script engine to the Connected state. This will finish
    // the initialization and put the engine into a state where we can run things
	hr = m_spScriptDriver->Connect();
	if (FAILED(hr))
		return TRUE;

    // invoke the OnInitialize() method in the script
	m_spScriptDriver->Invoke(L"OnInitialize");

	SetTimer(100, 0, NULL);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CCanvasDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CCanvasDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CCanvasDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CCanvasDlg::OnClose() 
{
	TRACE("OnClose\n");
	CDialog::OnClose();
}

void CCanvasDlg::OnOK() 
{
	TRACE("OnOK\n");
	CDialog::OnOK();
}

void CCanvasDlg::OnCancel() 
{
	TRACE("OnCancel\n");
	CDialog::OnCancel();
}

void CCanvasDlg::OnDestroy(void)
{
	HRESULT hr = m_spScriptDriver->Close();
	if (FAILED(hr))
		MessageBox("Script Close failed", "Error", MB_OK | MB_ICONERROR);

	TRACE("OnDestroy\n");
	CDialog::OnDestroy();
}

void CCanvasDlg::OnFinalRelease(void)
{
	// ignore - we don't want the base class to delete us
}

HRESULT CCanvasDlg::DrawLine(
			/* in */ int x1, /* in */ int y1,
			/* in */ int x2, /* in */ int y2,
			/* in */ int r, /* in */ int g, /* in */ int b)
{
	AFX_MANAGE_STATE(AfxGetAppModuleState());

	return m_wndDrawArea.DrawLine(CPoint(x1, y1), CPoint(x2, y2), RGB(r, g, b));
}

HRESULT CCanvasDlg::FillRect(
	/* in */ int left, /* in */ int top, /* in */ int right, /* in */ int bottom,
	/* in */ int r, /* in */ int g, /* in */ int b)
{
	AFX_MANAGE_STATE(AfxGetAppModuleState());

	return m_wndDrawArea.FillRect(CRect(left, top, right, bottom), RGB(r, g, b));
}

HRESULT CCanvasDlg::FrameRect(
	/* in */ int left, /* in */ int top, /* in */ int right, /* in */ int bottom,
	/* in */ int r, /* in */ int g, /* in */ int b)
{
	AFX_MANAGE_STATE(AfxGetAppModuleState());

	return m_wndDrawArea.FrameRect(CRect(left, top, right, bottom), RGB(r, g, b));
}

HRESULT CCanvasDlg::Ellipse(
	/* in */ int left, /* in */ int top, /* in */ int right, /* in */ int bottom,
	/* in */ int rEdge, /* in */ int gEdge, /* in */ int bEdge,
	/* in */ int rFill, /* in */ int gFill, /* in */ int bFill)
{
	AFX_MANAGE_STATE(AfxGetAppModuleState());

	return m_wndDrawArea.Ellipse(CRect(left, top, right, bottom), RGB(rEdge, gEdge, bEdge), RGB(rFill, gFill, bFill));
}

void CCanvasDlg::OnTimer(UINT nIDEvent)
{
	if (nIDEvent == 100 && m_spScriptDriver)
	{
		m_spScriptDriver->Invoke(L"OnTick");
		m_wndDrawArea.Flip();
	}

	CDialog::OnTimer(nIDEvent);
}

long CCanvasDlg::GetWidth(void)
{
	AFX_MANAGE_STATE(AfxGetAppModuleState());

	return m_wndDrawArea.GetWidth();
}

long CCanvasDlg::GetHeight(void)
{
	AFX_MANAGE_STATE(AfxGetAppModuleState());

	return m_wndDrawArea.GetHeight();
}

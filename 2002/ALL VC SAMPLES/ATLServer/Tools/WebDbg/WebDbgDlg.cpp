// WebDbgDlg.cpp : implementation file
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "WebDbg.h"
#include "WebDbgDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

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

/////////////////////////////////////////////////////////////////////////////
// CWebDbgDlg dialog

CWebDbgDlg::CWebDbgDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CWebDbgDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CWebDbgDlg)
	//}}AFX_DATA_INIT
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CWebDbgDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CWebDbgDlg)
	DDX_Control(pDX, IDC_EDIT, m_richEdit);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CWebDbgDlg, CDialog)
	//{{AFX_MSG_MAP(CWebDbgDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_COMMAND(ID_FILE_CLOSE, OnFileClose)
	ON_COMMAND(ID_HELP_ABOUT, OnHelpAbout)
	ON_WM_CLOSE()
	ON_WM_SIZE()
	ON_WM_ERASEBKGND()
	//}}AFX_MSG_MAP
	ON_COMMAND(ID_EDIT_CLEAR_ALL, OnClear)
	ON_COMMAND(ID_EDIT_SELECT_ALL, OnSelectAll)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CWebDbgDlg message handlers
void CWebDbgDlg::OnClear()
{
	m_richEdit.SetSel(0,-1);
	m_richEdit.Clear();
}

void CWebDbgDlg::OnSelectAll()
{
	m_richEdit.SetSel(0,-1);
}
BOOL CWebDbgDlg::OnInitDialog()
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

	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	LoadAccelTable(MAKEINTRESOURCE(IDR_MAIN));
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CWebDbgDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CWebDbgDlg::OnPaint() 
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

HCURSOR CWebDbgDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CWebDbgDlg::OnCancel() 
{
	// override OnCancel to stop closing
	// the dialog when the user hits escape
}

void CWebDbgDlg::OnFileClose() 
{
	EndDialog(TRUE);	
}

void CWebDbgDlg::OnHelpAbout() 
{
	CAboutDlg dlgAbout;
	dlgAbout.DoModal();
}

void CWebDbgDlg::OnClose() 
{
	EndDialog(TRUE);
}

void CWebDbgDlg::OnSize(UINT nType, int cx, int cy) 
{
	CDialog::OnSize(nType, cx, cy);

	// check if the richedit has been created
	if (!m_richEdit.m_hWnd)
		return;

	// move the richedit control
	CRect rct;
	m_richEdit.GetWindowRect(&rct);

	ScreenToClient(&rct);

	rct.right = cx - rct.left;
	rct.bottom = cy - rct.top;

	m_richEdit.MoveWindow(&rct);
}

BOOL CWebDbgDlg::OnEraseBkgnd(CDC* pDC) 
{
	if (!m_richEdit.m_hWnd)
		return CDialog::OnEraseBkgnd(pDC);

	CBrush br;
	br.CreateSysColorBrush(COLOR_3DFACE);

	CRect rct;
	GetClientRect(&rct);

	// get the size of the richedit control
	CRect rctEdit;
	m_richEdit.GetWindowRect(&rctEdit);
	ScreenToClient(&rctEdit);

	CRect rctFill = rct;

	rctFill.right = rctEdit.left;
	pDC->FillRect(&rctFill, &br);

	rctFill.left = rctEdit.right;
	rctFill.right = rct.right;
	pDC->FillRect(&rctFill, &br);

	rctFill = rct;
	rctFill.bottom = rctEdit.top;
	pDC->FillRect(&rctFill, &br);

	rctFill.top = rctEdit.bottom;
	rctFill.bottom = rct.bottom;
	pDC->FillRect(&rctFill, &br);

	return TRUE;
}

void CWebDbgDlg::OnOK() 
{
}

void CWebDbgDlg::HandleTraceMessage(MSG* pMsg)
{
	HANDLE hEvent = (HANDLE *) pMsg->lParam;
	LPCSTR szMessage = (LPCSTR) pMsg->wParam;

	// add the text to our richedit control
	m_richEdit.ReplaceSel(szMessage);
	SetEvent(hEvent);
}

BOOL CWebDbgDlg::PreTranslateMessage(MSG* pMsg) 
{
	if (pMsg->message==WM_KEYDOWN && pMsg->wParam==VK_ESCAPE)
		return TRUE;
	else if (pMsg->message==WM_USER && pMsg->hwnd==NULL)
	{
		HandleTraceMessage(pMsg);
		return TRUE;
	}

	if (pMsg->message >= WM_KEYFIRST && pMsg->message <= WM_KEYLAST)
		TranslateAccelerator(m_hWnd, m_hAccelTable, pMsg);

	return CDialog::PreTranslateMessage(pMsg);
}

BOOL CWebDbgDlg::LoadAccelTable(LPCTSTR lpszResourceName)
{
	ASSERT(lpszResourceName != NULL);

	HINSTANCE hInst = AfxFindResourceHandle(lpszResourceName, RT_ACCELERATOR);
	m_hAccelTable = ::LoadAccelerators(hInst, lpszResourceName);
	return (m_hAccelTable != NULL);
}

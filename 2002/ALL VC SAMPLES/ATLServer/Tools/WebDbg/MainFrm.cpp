// MainFrm.cpp : implementation of the CMainFrame class
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

#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMainFrame

IMPLEMENT_DYNAMIC(CMainFrame, CFrameWnd)

BEGIN_MESSAGE_MAP(CMainFrame, CFrameWnd)
	//{{AFX_MSG_MAP(CMainFrame)
	ON_WM_CREATE()
	ON_WM_SETFOCUS()
	ON_WM_CLOSE()
	ON_COMMAND(ID_VIEW_ONTOP, OnViewOnTop)
	ON_UPDATE_COMMAND_UI(ID_VIEW_ONTOP, OnUpdateViewOnTop)
	//}}AFX_MSG_MAP
	ON_MESSAGE(WM_USER, OnWMUser)
END_MESSAGE_MAP()

static UINT indicators[] =
{
	ID_SEPARATOR,           // status line indicator
	ID_INDICATOR_CAPS,
	ID_INDICATOR_NUM,
	ID_INDICATOR_SCRL,
};

/////////////////////////////////////////////////////////////////////////////
// CMainFrame construction/destruction

CMainFrame::CMainFrame()
{
	// TODO: add member initialization code here
	
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;
	// create a view to occupy the client area of the frame
	if (!m_wndView.Create(NULL, NULL, AFX_WS_DEFAULT_VIEW,
		CRect(0, 0, 0, 0), this, AFX_IDW_PANE_FIRST, NULL))
	{
		TRACE0("Failed to create view window\n");
		return -1;
	}
	
	if (!m_wndToolBar.CreateEx(this, TBSTYLE_FLAT, WS_CHILD | WS_VISIBLE | CBRS_TOP
		| CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC) ||
		!m_wndToolBar.LoadToolBar(IDR_MAINFRAME))
	{
		TRACE0("Failed to create toolbar\n");
		return -1;      // fail to create
	}

	if (!m_wndStatusBar.Create(this) ||
		!m_wndStatusBar.SetIndicators(indicators,
		  sizeof(indicators)/sizeof(UINT)))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	LoadBarState(_T("Settings"));

	// Delete these three lines if you don't want the toolbar to be dockable
	/*
	m_wndToolBar.EnableDocking(CBRS_ALIGN_ANY);
	EnableDocking(CBRS_ALIGN_ANY);
	DockControlBar(&m_wndToolBar);
	*/

	return 0;
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if( !CFrameWnd::PreCreateWindow(cs) )
		return FALSE;
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	cs.dwExStyle &= ~WS_EX_CLIENTEDGE;
	cs.lpszClass = AfxRegisterWndClass(0);
	CString profileString(AfxGetApp()->GetProfileString(_T("Settings"), _T("Basic"), _T("10, 10, 310, 310, 0")));
	TCHAR* profileBuf = profileString.GetBuffer(0);
	TCHAR* tmp = profileBuf;
	int prefs[5];
	int i = 0;
	while (1)
	{
		if (*tmp == ',' || *tmp == 0)
		{
			prefs[i++] = _ttoi(profileBuf);
			profileBuf = tmp+1;
		}
		if (*tmp == 0)
			break;
		tmp++;
	}
	profileString.ReleaseBuffer();
	if (prefs[0] < 0)
	{
		AfxGetApp()->m_nCmdShow = SW_SHOWMAXIMIZED;
	}
	else
	{
		cs.y = prefs[1];
		cs.x = prefs[0];
		cs.cx = prefs[2] - prefs[0];
		cs.cy = prefs[3] - prefs[1];
	}
	m_bOnTop = prefs[4];
	if (m_bOnTop)
		cs.dwExStyle |= WS_EX_TOPMOST;

	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// CMainFrame diagnostics

#ifdef _DEBUG
void CMainFrame::AssertValid() const
{
	CFrameWnd::AssertValid();
}

void CMainFrame::Dump(CDumpContext& dc) const
{
	CFrameWnd::Dump(dc);
}

#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CMainFrame message handlers
void CMainFrame::OnSetFocus(CWnd* /* pOldWnd */)
{
	// forward focus to the view window
	m_wndView.SetFocus();
}

BOOL CMainFrame::OnCmdMsg(UINT nID, int nCode, void* pExtra, AFX_CMDHANDLERINFO* pHandlerInfo)
{
	// let the view have first crack at the command
	if (m_wndView.OnCmdMsg(nID, nCode, pExtra, pHandlerInfo))
		return TRUE;

	// otherwise, do default handling
	return CFrameWnd::OnCmdMsg(nID, nCode, pExtra, pHandlerInfo);
}

LRESULT CMainFrame::OnWMUser(WPARAM wParam, LPARAM lParam)
{
	return m_wndView.HandleDebugMessage(wParam, lParam);
}

void CMainFrame::OnClose() 
{
	if (IsIconic())
	{
		CFrameWnd::OnClose();
		return;
	}
	LPCTSTR szSection = _T("Settings");
	CString data;
	if (IsZoomed())
	{
		data.Format(_T("%d, %d, %d, %d, %d"), -1, 0, 0, 0, m_bOnTop);
	}
	else
	{
		RECT rctInit;
		GetWindowRect(&rctInit);
		data.Format(_T("%d, %d, %d, %d, %d"), 
			rctInit.left, rctInit.top, rctInit.right, rctInit.bottom, m_bOnTop);
	}

	LOGFONT lf;
	m_wndView.m_font.GetLogFont(&lf);
	CString font;
	SaveBarState(szSection);
	AfxGetApp()->WriteProfileString(szSection, _T("Basic"), data);
	HKEY hKey;
	DWORD dwDisposition;
	if (RegCreateKeyEx(HKEY_CURRENT_USER, _T("Software\\HPS\\WebDbg\\Settings"), 0, NULL, 
		REG_OPTION_NON_VOLATILE, KEY_WRITE, NULL, &hKey, &dwDisposition) == ERROR_SUCCESS)
	{
		RegSetValueEx(hKey, _T("Font"), 0, REG_BINARY, (BYTE*)&lf, sizeof(LOGFONT));
	}
	CFrameWnd::OnClose();
}


void CMainFrame::OnViewOnTop() 
{
	m_bOnTop = !m_bOnTop;
	SetWindowPos(m_bOnTop ? &wndTopMost : &wndNoTopMost, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE);
}


void CMainFrame::OnUpdateViewOnTop(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck(m_bOnTop ? 1 : 0);
}
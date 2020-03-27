// ChildView.cpp : implementation of the CChildView class
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
#include "ChildView.h"
#include <mbstring.h>
#include "FilterDialog.h"
#include "DebugDialog.h"
#include <iostream>
#include <fstream>

using namespace std;

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CChildView

CChildView::CChildView()
{
	m_bBreakOnMessage = FALSE;
	m_bRegEx = FALSE;
}

CChildView::~CChildView()
{
}

BEGIN_MESSAGE_MAP(CChildView,CWnd )
	//{{AFX_MSG_MAP(CChildView)
	ON_WM_PAINT()
	ON_WM_SIZE()
	ON_WM_CREATE()
	ON_WM_ERASEBKGND()
	ON_WM_CTLCOLOR()
	//}}AFX_MSG_MAP
	ON_COMMAND(ID_EDIT_CLEAR, OnClear)
	ON_COMMAND(ID_EDIT_SELECT_ALL, OnSelectAll)
	ON_COMMAND(ID_EDIT_COPY, OnCopy)
	ON_COMMAND(ID_EDIT_FILTER, OnFilter)
	ON_COMMAND(ID_FILE_SAVE, OnFileSave)
	ON_COMMAND(ID_EDIT_FONT, OnEditFont)
END_MESSAGE_MAP()


/////////////////////////////////////////////////////////////////////////////
// CChildView message handlers
BOOL CChildView::PreTranslateMessage(MSG* pMsg)
{
	if (pMsg->message == WM_RBUTTONUP)
	{
		DisplayPopup(AfxGetMainWnd(), pMsg->pt.x, pMsg->pt.y);
		return TRUE;
	}
	return CWnd::PreTranslateMessage(pMsg);
}

void CChildView::DisplayPopup(CWnd* /* pWnd */, int x, int y)
{
	CMenu menu;
	if (menu.LoadMenu(IDR_POPUP_MENU))
	{
		CMenu* pPopup = menu.GetSubMenu(0);
		ASSERT(pPopup != NULL);

		pPopup->TrackPopupMenu(TPM_LEFTALIGN | TPM_RIGHTBUTTON, x, y, AfxGetMainWnd());
	}
}

void CChildView::OnEditFont()
{
	LOGFONT lf;
	m_font.GetLogFont(&lf);
	CFontDialog fontDlg(&lf);
	int nRet = fontDlg.DoModal();
	if (nRet == IDCANCEL)
		return;

	fontDlg.GetCurrentFont(&lf);
	m_font.Detach();
	m_font.CreateFontIndirect(&lf);
	m_Edit.SetFont(&m_font);
}

void CChildView::OnFilter()
{
	CFilterDialog filterDlg(this);

	//Set the current filter string
	filterDlg.SetText(m_Filter.GetFilter());

	//Set the current break state
	filterDlg.SetChecked(m_bBreakOnMessage);
	filterDlg.SetRegEx(m_bRegEx);
	int nRet = filterDlg.DoModal();
	if (nRet == IDCANCEL)
		return;

	if (filterDlg.AddFilter(m_Filter))
	{
		m_bBreakOnMessage = filterDlg.BreakChecked();
		m_bRegEx = filterDlg.UseRegEx();
	}
}

void CChildView::OnClear()
{
	m_Edit.SetReadOnly(FALSE);
	m_Edit.SetSel(0, -1);
	m_Edit.Clear();
	m_Edit.SetReadOnly();
}

void CChildView::OnCopy()
{
	m_Edit.Copy();
}

void CChildView::OnFileSave()
{

	CFileDialog fileDialog(FALSE);
	int nRet = fileDialog.DoModal();

	if (nRet == IDCANCEL)
	{
		if (CommDlgExtendedError() == 0) return;
		else return; //?
	}

	//else nRet == IDOK
	CString strText;
	m_Edit.GetWindowText(strText);
	HANDLE hFile = CreateFile(fileDialog.GetPathName(), GENERIC_WRITE, FILE_SHARE_READ, 
		NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
	
	if (GetFileType(hFile) != FILE_TYPE_DISK)
		return;

	DWORD dwWritten = 0;
	DWORD dwTotalWritten = 0;
	DWORD dwLength = strText.GetLength();
	do
	{
		nRet = WriteFile(hFile, (void*)((LPCTSTR)strText), dwLength, &dwWritten, NULL);
		if (!nRet)
		{
			SetForegroundWindow();
			AfxMessageBox(ID_ERR_FILE_SAVE, MB_OK|MB_ICONEXCLAMATION);
			break;
		}
		dwTotalWritten += dwWritten;
	} while (dwTotalWritten < dwLength);

	CloseHandle(hFile);
}

void CChildView::OnSelectAll()
{
	m_Edit.SetSel(0, -1);
}


BOOL CChildView::PreCreateWindow(CREATESTRUCT& cs) 
{
	if (!CWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle |= WS_EX_CLIENTEDGE;
	cs.style &= ~WS_BORDER;
	cs.lpszClass = AfxRegisterWndClass(CS_HREDRAW|CS_VREDRAW|CS_DBLCLKS, 
		::LoadCursor(NULL, IDC_ARROW), HBRUSH(COLOR_WINDOW+1), NULL);

	m_Brush.CreateSolidBrush(GetSysColor(COLOR_WINDOW));
	m_font.Detach();
	LOGFONT lf;
	HKEY hKey;
	DWORD dwSize = sizeof(LOGFONT);
	if (RegOpenKeyEx(HKEY_CURRENT_USER, _T("Software\\HPS\\WebDbg\\Settings"), 0, KEY_READ, &hKey) != ERROR_SUCCESS ||
		RegQueryValueEx(hKey, _T("Font"), 0, NULL, (BYTE*)&lf, &dwSize) != ERROR_SUCCESS)
	{
		HGDIOBJ hObj = GetStockObject(DEFAULT_GUI_FONT);
		GetObject(hObj, sizeof(LOGFONT), (void*)&lf);
	}
	m_font.CreateFontIndirect(&lf);
	return TRUE;
}

void CChildView::OnPaint() 
{
	CPaintDC dc(this);
}

int CChildView::OnCreate(CREATESTRUCT* lpcs)
{
	int nRet = CWnd::OnCreate(lpcs);
	CRect rect;

	m_Edit.Create(ES_MULTILINE | ES_WANTRETURN | ES_NOHIDESEL | ES_READONLY | WS_VISIBLE | 
		ES_AUTOHSCROLL | ES_AUTOVSCROLL | WS_VSCROLL | WS_HSCROLL | WS_CHILD, 
		rect, this, 0x1000);

	m_Edit.SetFont(&m_font);
	return nRet;
}

void CChildView::OnSize(UINT /* uType */, int cx, int cy)
{
	if (m_Edit.m_hWnd)
		m_Edit.MoveWindow(0, 0, cx, cy);
}


BOOL CChildView::OnEraseBkgnd(CDC *pDC)
{
	if (!m_Edit.m_hWnd)
		return CWnd::OnEraseBkgnd(pDC);

	CBrush br;
	br.CreateSysColorBrush(COLOR_3DFACE);

	CRect rct;
	GetClientRect(&rct);

	//get size of edit control
	CRect rctEdit;
	m_Edit.GetWindowRect(&rctEdit);
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

LRESULT CChildView::HandleTraceMessage(ThreadMessageParam* msgParam, LPCTSTR szMessage)
{
	msgParam->nRet = IDIGNORE;
	if (m_Filter.Passes(szMessage))
	{
		msgParam->nRet = IDIGNORE;
		if (m_bBreakOnMessage)
		{
			msgParam->nRet = IDOK;
		}

		EscapeShowMessage(szMessage);
	}
	SetEvent(msgParam->hEvent);
	return 0;
}

LRESULT CChildView::HandleAssertMessage(ThreadMessageParam* msgParam, LPCTSTR szMessage)
{
	msgParam->nRet = IDOK;
	EscapeShowMessage(szMessage);
	SetEvent(msgParam->hEvent);
	return 0;
}

void CChildView::EscapeShowMessage(LPCTSTR szMessage)
{
	TCHAR msg[2048];
	int i=0, j=0;
	TCHAR ch;
	while ((ch = szMessage[i++]) != '\0')
	{
		if (j >= 2045)
			break;
		if (ch == '\r' && szMessage[i+1] != '\n')
		{					
			msg[j++] = '\r';
			msg[j++] = '\n';
			continue;					
		}
		if (ch == '\n' && i != 0 && szMessage[i-1] != '\r')
		{
			msg[j++] = '\r';
			msg[j++] = '\n';
			continue;
		}
		msg[j++] = ch;
	}
	msg[j] = '\0';

	int nLen = m_Edit.GetWindowTextLength();
	m_Edit.SetSel(nLen, nLen+1);
	m_Edit.ReplaceSel(msg);
}

LRESULT CChildView::HandleDebugMessage(WPARAM wParam, LPARAM lParam)
{
	ThreadMessageParam* msgParam = (ThreadMessageParam*) lParam;
	switch (msgParam->nMsgType)
	{
		case HPS_TRACE_MESSAGE: 
			HandleTraceMessage(msgParam, (LPCTSTR)wParam);
			break;
		case HPS_ASSERT_MESSAGE:
			HandleAssertMessage(msgParam, (LPCTSTR)wParam);
			break;
		default:
			ATLASSERT(0);
			break;
	}
	return 0;
}

HBRUSH CChildView::OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor)
{
	CWnd::OnCtlColor(pDC, pWnd, nCtlColor);

	pDC->SetBkColor(GetSysColor(COLOR_WINDOW));

	return m_Brush;
}
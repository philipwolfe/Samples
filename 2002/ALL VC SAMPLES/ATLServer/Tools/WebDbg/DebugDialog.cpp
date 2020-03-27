// DebugDialog.cpp : implementation file
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
#include "DebugDialog.h"
#include <atlutil.h>
#include "winbase.h"
#include <tchar.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDebugDialog dialog



CDebugDialog::CDebugDialog(CWnd* pParent, BOOL bExpanded, BOOL bLocalMachine)
	: CDialog(CDebugDialog::IDD, pParent)
{
	//{{AFX_DATA_INIT(CDebugDialog)
	m_FileEdit = _T("");
	m_LineEdit = _T("");
	m_ProcessEdit = _T("");
	m_MessageEdit = _T("");
	//}}AFX_DATA_INIT
	m_bLocalMachine = bLocalMachine;
	m_bExpanded = bExpanded;
}

void CDebugDialog::UpdateSize()
{
	if (!m_bExpanded)
	{
		CString strWindowText;
		strWindowText.LoadString(IDS_BTN_EXPAND);
		m_ExpandButton.SetWindowText(strWindowText);
		RECT rectDlg;
		GetWindowRect(&rectDlg);

		RECT rectButton;
		m_ExpandButton.GetWindowRect(&rectButton);

		rectDlg.bottom = rectButton.bottom;

		SetWindowPos(&wndTop, rectDlg.left, rectDlg.top,
			rectDlg.right-rectDlg.left, rectDlg.bottom-rectDlg.top+10, 
			SWP_NOMOVE);
	}
	else //The dialog is expanded
	{
		CString strWindowText;
		strWindowText.LoadString(IDS_BTN_HIDE);
		m_ExpandButton.SetWindowText(strWindowText);

		RECT rectDlg;
		GetWindowRect(&rectDlg);

		
		RECT rectList;
		m_StackTraceList.GetWindowRect(&rectList);

		rectDlg.bottom = rectList.bottom;
	
		SetWindowPos(&wndTop, m_rectFullSize.left, m_rectFullSize.top,
			m_rectFullSize.right-m_rectFullSize.left, m_rectFullSize.bottom-m_rectFullSize.top,
			SWP_NOMOVE);
	}
}

BOOL CDebugDialog::InitData(int nMsgType, DWORD dwProcessId, LPCTSTR lpszMessage, LPCTSTR lpszStackTrace)
{
	ATLASSERT(lpszMessage && lpszStackTrace);

	//if we want stack trace info
	CString str;
	TCHAR ch;
	int i = 0;
	if (lpszStackTrace)
		m_StackString = lpszStackTrace;


	TCHAR szBuf[256];
	_stprintf(szBuf, _T("%d\0"), dwProcessId);
	m_ProcessEdit = szBuf;

	if (nMsgType == HPS_ASSERT_MESSAGE)
	{
		//Get the file name
		i = 0;
		while ((ch = lpszMessage[i++]) != '(')
		{
			m_FileEdit += ch;
		}

		//Get the line number
		while ((ch = lpszMessage[i++]) != ')')
		{
			m_LineEdit += ch;
		}
	}

	m_MessageEdit = lpszMessage;

	return TRUE;
}

void CDebugDialog::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDebugDialog)
	DDX_Control(pDX, IDC_STACKTRACE_LIST, m_StackTraceList);
	DDX_Control(pDX, IDC_EXPAND, m_ExpandButton);
	DDX_Text(pDX, IDC_FILE_EDIT, m_FileEdit);
	DDX_Text(pDX, IDC_LINE_EDIT, m_LineEdit);
	DDX_Text(pDX, IDC_EDIT_PROCESSID, m_ProcessEdit);
	DDX_Text(pDX, ID_ASSERT_EDIT, m_MessageEdit);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CDebugDialog, CDialog)
	//{{AFX_MSG_MAP(CDebugDialog)
	ON_BN_CLICKED(IDC_EXPAND, OnExpand)
	ON_BN_CLICKED(IDABORT, OnAbort)
	ON_BN_CLICKED(IDIGNORE, OnIgnore)
	ON_BN_CLICKED(IDRETRY, OnRetry)
	ON_BN_CLICKED(IDCOPY, OnCopy)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDebugDialog message handlers

void CDebugDialog::OnExpand() 
{
	m_bExpanded = !m_bExpanded;
	UpdateSize();
}

BOOL CDebugDialog::OnInitDialog() 
{
	CDialog::OnInitDialog();
	
	GetWindowRect(&m_rectFullSize);
	CString strWindowText;

	if (m_bExpanded)
	{
		strWindowText.LoadString(IDS_BTN_HIDE);
		m_ExpandButton.SetWindowText(strWindowText);
	}
	else
	{
		strWindowText.LoadString(IDS_BTN_EXPAND);
		m_ExpandButton.SetWindowText(strWindowText);
	}

	GetDlgItem(IDRETRY)->EnableWindow(m_bLocalMachine);

	strWindowText.LoadString(IDS_COLUMN_ADDRESS);
	m_StackTraceList.InsertColumn(0, strWindowText);

	strWindowText.LoadString(IDS_COLUMN_MODULE);
	m_StackTraceList.InsertColumn(1, strWindowText);

	strWindowText.LoadString(IDS_COLUMN_FUNCTION);
	m_StackTraceList.InsertColumn(2, strWindowText);

	RECT rectList;
	GetWindowRect(&rectList);
	int nWidth = rectList.right-rectList.left;
	m_StackTraceList.SetColumnWidth(0, nWidth/4);
	m_StackTraceList.SetColumnWidth(1, nWidth/4);
	m_StackTraceList.SetColumnWidth(2, 2*nWidth/4);


	int nItemCnt = 0;
	int nItemSubCnt = 0;
	
	//trace information is formatted as follows:
	//(<address><STACK_TRACE_PART_DELIMITER><module><STACK_TRACE_PART_DELIMITER><symbol><STACK_TRACE_PART_DELIMITER><STACK_TRACE_LINE_DELIMITER>)* <null-char>
	
	CString items[3];
	int i = 0;
	TCHAR ch;
	
	CString str;
	LVITEM item;
	item.mask = LVIF_TEXT;
	while (i < m_StackString.GetLength())
	{
		ch = m_StackString[i];
		if (ch == '\0')
			break;
		if (ch == STACK_TRACE_LINE_DELIMITER)
		{
			nItemCnt++;
			nItemSubCnt = 0;
		}
		else if (ch == STACK_TRACE_PART_DELIMITER)
		{
			item.iItem = nItemCnt;
			item.iSubItem = nItemSubCnt;
			item.cchTextMax = str.GetLength();
			item.pszText = const_cast<TCHAR*>((LPCTSTR)str);
			
			if (nItemSubCnt == 0)
			{
				m_StackTraceList.InsertItem(&item);
			}
			else
			{
				m_StackTraceList.SetItem(&item);
			}
			
			nItemSubCnt++;
			str = _T("");
		}
		else
		{
			str += ch;
		}
		i++;
	}
	str.Empty();

	UpdateSize();

	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

void CDebugDialog::OnAbort() 
{
	int nRet = IDABORT;
	EndDialog(nRet);
	return;
	
}

void CDebugDialog::OnIgnore() 
{
	int nRet = IDIGNORE;
	EndDialog(nRet);
	return;
	
}

void CDebugDialog::OnRetry() 
{
	int nRet = IDRETRY;
	EndDialog(nRet);
	return;
}

BOOL CDebugDialog::PreTranslateMessage(MSG* pMsg) 
{
	return CDialog::PreTranslateMessage(pMsg);
}

void CDebugDialog::OnCopy() 
{
	
	int i = 0;
	int nSubCnt = 0;
	TCHAR ch;
	
	CString str;

	str += m_MessageEdit;
	str += _T("\r\n");
	str += m_FileEdit;
	str += _T("\r\n");
	str += m_LineEdit;
	str += _T("\r\n");
	str += m_ProcessEdit;
	str += _T("\r\n");

	while (i < m_StackString.GetLength())
	{
		ch = m_StackString[i];
		if (ch == '\0')
			break;
		if (ch == STACK_TRACE_LINE_DELIMITER)
		{
			str += _T("\r\n");
			nSubCnt = 0;
		}
		else if (ch == STACK_TRACE_PART_DELIMITER)
		{	
			if (nSubCnt++ < 2)
				str += _T(", ");
		}
		else
		{
			str += ch;
		}
		i++;
	}

	if (OpenClipboard())
	{
		EmptyClipboard();
		HANDLE hData = GlobalAlloc(GMEM_MOVEABLE | GMEM_DDESHARE, str.GetLength()+1);
		LPTSTR lpszData = (TCHAR*)GlobalLock(hData);
		_tcscpy(lpszData, ((LPCTSTR)str));

		if (!SetClipboardData(CF_TEXT, hData))
			AfxMessageBox(IDS_NO_CLIPBOARD_WRITEY, MB_OK|MB_ICONEXCLAMATION);
		CloseClipboard();
	}
	else
		AfxMessageBox(IDS_NO_CLIPBOARD_OPEN, MB_OK|MB_ICONEXCLAMATION);

	str.Empty();
	return;
}


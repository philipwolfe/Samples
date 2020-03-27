// File: DebugDialog.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(AFX_DEBUGDIALOG_H__249D273C_4110_11D3_A6E1_00C04F680B34__INCLUDED_)
#define AFX_DEBUGDIALOG_H__249D273C_4110_11D3_A6E1_00C04F680B34__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// DebugDialog.h : header file
//

#include "atlutil.h"
#include "WebDbg.h"

/////////////////////////////////////////////////////////////////////////////
// CDebugDialog dialog

class CDebugDialog : public CDialog
{
// Construction
public:
	CDebugDialog(CWnd* pParent, BOOL bExpanded, BOOL bLocalMachine);
	BOOL InitData(int nMsgType, DWORD dwProcessId, LPCTSTR lpszMessage, LPCTSTR lpszStackTrace = NULL);

// Dialog Data
	//{{AFX_DATA(CDebugDialog)
	enum { IDD = IDD_DEBUG_DIALOG };
	CListCtrl	m_StackTraceList;
	CButton	m_ExpandButton;
	CString	m_FileEdit;
	CString	m_LineEdit;
	CString	m_ProcessEdit;
	CString	m_MessageEdit;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDebugDialog)
	public:
	virtual BOOL PreTranslateMessage(MSG* pMsg);
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	BOOL m_bLocalMachine;
	BOOL m_bExpanded;
	RECT m_rectFullSize;
	void UpdateSize();
	CString m_StackString;

	// Generated message map functions
	//{{AFX_MSG(CDebugDialog)
	afx_msg void OnExpand();
	virtual BOOL OnInitDialog();
	afx_msg void OnAbort();
	afx_msg void OnIgnore();
	afx_msg void OnRetry();
	afx_msg void OnCopy();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DEBUGDIALOG_H__249D273C_4110_11D3_A6E1_00C04F680B34__INCLUDED_)

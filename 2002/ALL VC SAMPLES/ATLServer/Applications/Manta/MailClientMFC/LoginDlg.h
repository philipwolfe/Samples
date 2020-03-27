// LoginDlg.h : header file
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CLoginDlg dialog
class CLoginDlg : public CDialog
{
// Construction
public:
	CLoginDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_LOGINDLG };

	LPCTSTR GetLogin() { return m_strLogin; }
	LPCTSTR GetPassword() { return m_strPassword; }
	BSTR GetSessionID() { return m_bstrSessionID; }
	LONG GetUserID() { return m_lUserID; }

// Implementation
protected:
	HICON m_hIcon;
	CString m_strLogin;
	CString m_strPassword;
	LONG m_lUserID;
	BSTR m_bstrSessionID;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	virtual void OnOK();
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnEditChange();
	
	DECLARE_MESSAGE_MAP()
};

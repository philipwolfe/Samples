// HttpClientDlg.h : header file
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once


//class CProgress;

// CHttpClientDlg dialog
#include "afxcmn.h"
#include "afxwin.h"
class CHttpClientDlg : public CDialog
{
// Construction
public:
	CHttpClientDlg(CWnd* pParent = NULL);	// standard constructor
	~CHttpClientDlg();

	static bool WINAPI CHttpClientDlg::Callback(DWORD dwBytesSent, DWORD dwCookie);
// Dialog Data
	enum { IDD = IDD_HTTPCLIENT_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support

	void OnOK();

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()

private:
	CAtlHttpClient* client;

	bool clientInUse;
	bool cancelNavigate;

	CString m_urlStr;
	CUrl m_url;
	CString m_proxy;
	CString m_response;
	int m_proxy_port;
	BOOL m_auth_basic;
	BOOL m_auth_ntlm;
	BOOL m_use_proxy;

	CProgressCtrl m_progressBar;
public:
	CButton m_navigateButton;
	void OnBnClickedUseproxy(void);
};

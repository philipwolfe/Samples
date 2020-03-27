// MainDlg.h : header file
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "MailService.h"
using namespace MailService;

#define TIMERID_CHECKMAIL	101
#define WM_TRAYEVENT		WM_APP + 1

/////////////////////////////////////////////////////////////////////////////
// CMainDlg dialog
class CMainDlg : public CDialog
{
// Construction
public:
	CMainDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_MAINDLG };

// Implementation
protected:
	HICON			m_hIcon;
	CListCtrl		m_ctrlMsgList;
	CMailService	m_mailService;
	CBitmap			m_bmpUnread;
	CBitmap			m_bmpRead;
	CImageList		m_imgList;
	
	// Generated message map functions
	virtual BOOL OnInitDialog();
	virtual void OnCancel();
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	afx_msg void OnCheckMail();
	afx_msg void OnTimer(UINT nIDEvent);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnSysCommand(UINT uCode, LONG lPos);
	afx_msg LRESULT OnTrayEvent(WPARAM wp, LPARAM lp);
	afx_msg void OnMessageDblClick(NMHDR* pNMHDR, LRESULT* pResult);

	void DisableCheckMailButton();
	void EnableCheckMailButton();
	
	DECLARE_MESSAGE_MAP()
};

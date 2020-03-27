// File: BasicAuthDlg.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once


// CBasicAuthDlg dialog

class CBasicAuthDlg : public CDialog
{
	DECLARE_DYNAMIC(CBasicAuthDlg)

public:
	CBasicAuthDlg(CWnd* pParent = NULL);   // standard constructor
	virtual ~CBasicAuthDlg();

// Dialog Data
	enum { IDD = IDD_BASICAUTH };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	CString m_username;
	CString m_password;
};

// BasicAuthDlg.cpp : implementation file
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "HttpClient.h"
#include "BasicAuthDlg.h"


// CBasicAuthDlg dialog

IMPLEMENT_DYNAMIC(CBasicAuthDlg, CDialog)
CBasicAuthDlg::CBasicAuthDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CBasicAuthDlg::IDD, pParent)
	, m_username(_T(""))
	, m_password(_T(""))
{
}

CBasicAuthDlg::~CBasicAuthDlg()
{
}

void CBasicAuthDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_USERNAME, m_username);
	DDX_Text(pDX, IDC_PASSWORD, m_password);
}


BEGIN_MESSAGE_MAP(CBasicAuthDlg, CDialog)
END_MESSAGE_MAP()


// CBasicAuthDlg message handlers

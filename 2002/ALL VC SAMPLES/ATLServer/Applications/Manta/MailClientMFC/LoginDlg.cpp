// LoginDlg.cpp : implementation file
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "MailClientMFC.h"
#include "LoginDlg.h"
#include "MailService.h"
using namespace MailService;

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CLoginDlg dialog

CLoginDlg::CLoginDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CLoginDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAILICON);
}

void CLoginDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_LOGIN, m_strLogin);
	DDX_Text(pDX, IDC_PASSWORD, m_strPassword);
}

BEGIN_MESSAGE_MAP(CLoginDlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_EN_CHANGE(IDC_LOGIN, OnEditChange)
	ON_EN_CHANGE(IDC_PASSWORD, OnEditChange)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CLoginDlg message handlers

BOOL CLoginDlg::OnInitDialog()
{
	CDialog::OnInitDialog();
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	return TRUE;  
}

void CLoginDlg::OnPaint() 
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

HCURSOR CLoginDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CLoginDlg::OnOK()
{
	// Update the DDX variables
	UpdateData();

	// Attempt to log the user in
	CMailService mailService;
	if (FAILED(mailService.Login(CComBSTR(m_strLogin), CComBSTR(m_strPassword), (int*) &m_lUserID, &m_bstrSessionID)))
	{
		MessageBox("Could not login to mail service.\nMantaWeb Mail Service might be down.", "Login Error", MB_OK | MB_ICONHAND);
		return;
	}
	// The call succeeded, but if the user id is -1, the login information was incorrect
	if (m_lUserID == -1)
	{
		MessageBox("Could not login to mail service.\nLogin or password incorrect.", "Login Error", MB_OK | MB_ICONINFORMATION);
		return;
	}

	// Return the default
	return CDialog::OnOK();
}

void CLoginDlg::OnEditChange()
{
	// Update the DDX variables
	UpdateData();

	// If either of the fields are empty, disable the ok button
	if (m_strLogin.IsEmpty() || m_strPassword.IsEmpty())
		GetDlgItem(IDOK)->EnableWindow(FALSE);
	else
		GetDlgItem(IDOK)->EnableWindow();
}
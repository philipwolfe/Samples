// FilterDialog.cpp : implementation file
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
#include "FilterDialog.h"
#include "TraceFilter.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CFilterDialog dialog


CFilterDialog::CFilterDialog(CWnd* pParent /*=NULL*/)
	: CDialog(CFilterDialog::IDD, pParent)
{
	//{{AFX_DATA_INIT(CFilterDialog)
	m_EditString = _T("");
	m_bBreakChecked = FALSE;
	m_bRegEx = FALSE;
	//}}AFX_DATA_INIT
}


void CFilterDialog::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CFilterDialog)
	DDX_Text(pDX, IDC_EDIT1, m_EditString);
	DDX_Check(pDX, IDC_BREAK_CHECK, m_bBreakChecked);
	DDX_Check(pDX, IDC_REGEX, m_bRegEx);
	//}}AFX_DATA_MAP
}

BOOL CFilterDialog::AddFilter(CTraceFilter& filter)
{
	if (!filter.SetFilter((LPCTSTR)m_EditString, UseRegEx()))
	{
		AfxMessageBox(IDS_INVALID_REGEXP, MB_OK|MB_ICONEXCLAMATION);
		return FALSE;
	}
	return TRUE;
}

BOOL CFilterDialog::BreakChecked()
{
	return m_bBreakChecked;
}

BOOL CFilterDialog::UseRegEx()
{
	return m_bRegEx;
}

void CFilterDialog::SetText(LPCTSTR lpszFilterString)
{
	m_EditString = lpszFilterString;
}

void CFilterDialog::SetChecked(BOOL bChecked)
{
	m_bBreakChecked = bChecked;
}

void CFilterDialog::SetRegEx(BOOL bRegEx)
{
	m_bRegEx = bRegEx;
}

BEGIN_MESSAGE_MAP(CFilterDialog, CDialog)
	//{{AFX_MSG_MAP(CFilterDialog)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CFilterDialog message handlers

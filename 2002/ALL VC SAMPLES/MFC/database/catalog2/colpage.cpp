// ColumnPage.cpp : implementation file
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "catalog2.h"
#include "ColPage.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CColumnPage property page

IMPLEMENT_DYNCREATE(CColumnPage, CPropertyPage)

CColumnPage::CColumnPage() : CPropertyPage(CColumnPage::IDD)
{
	//{{AFX_DATA_INIT(CColumnPage)
	m_bLength = FALSE;
	m_bNullability = FALSE;
	m_bPrecision = FALSE;
	//}}AFX_DATA_INIT
}

CColumnPage::~CColumnPage()
{
}

void CColumnPage::DoDataExchange(CDataExchange* pDX)
{
	CPropertyPage::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CColumnPage)
	DDX_Check(pDX, IDC_LENGTH, m_bLength);
	DDX_Check(pDX, IDC_NULLABILITY, m_bNullability);
	DDX_Check(pDX, IDC_PRECISION, m_bPrecision);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CColumnPage, CPropertyPage)
	//{{AFX_MSG_MAP(CColumnPage)
		// NOTE: the ClassWizard will add message map macros here
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CColumnPage message handlers

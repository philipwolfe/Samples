// coursset.cpp : implementation file
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "enroll.h"
#include "coursset.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CCourseSet

IMPLEMENT_DYNAMIC(CCourseSet, CRecordset)

CCourseSet::CCourseSet(CDatabase* pdb)
	: CRecordset(pdb)
{
	//{{AFX_FIELD_INIT(CCourseSet)
	m_CourseID = _T("");
	m_CourseTitle = _T("");
	m_Hours = 0;
	m_nFields = 3;
	//}}AFX_FIELD_INIT
}

CString CCourseSet::GetDefaultSQL()
{
	return _T("COURSE");
}

void CCourseSet::DoFieldExchange(CFieldExchange* pFX)
{
	//{{AFX_FIELD_MAP(CCourseSet)
	pFX->SetFieldType(CFieldExchange::outputColumn);
	RFX_Text(pFX, "CourseID", m_CourseID);
	RFX_Text(pFX, "CourseTitle", m_CourseTitle);
	RFX_Int(pFX, "Hours", m_Hours);
	//}}AFX_FIELD_MAP
}

/////////////////////////////////////////////////////////////////////////////
// CCourseSet diagnostics

#ifdef _DEBUG
void CCourseSet::AssertValid() const
{
	CRecordset::AssertValid();
}

void CCourseSet::Dump(CDumpContext& dc) const
{
	CRecordset::Dump(dc);
}
#endif //_DEBUG


// File: FilterDialog.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(AFX_FILTERDIALOG_H__FA49588A_3939_11D3_A6DD_00C04F680B34__INCLUDED_)
#define AFX_FILTERDIALOG_H__FA49588A_3939_11D3_A6DD_00C04F680B34__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// FilterDialog.h : header file
//

#include "TraceFilter.h"

/////////////////////////////////////////////////////////////////////////////
// CFilterDialog dialog

class CFilterDialog : public CDialog
{
// Construction
public:
	CFilterDialog(CWnd* pParent = NULL);   // standard constructor
	BOOL AddFilter(CTraceFilter&);
	BOOL BreakChecked();
	BOOL UseRegEx();
	void SetRegEx(BOOL bRegEx);
	void SetText(LPCTSTR lpszFilterString);
	void SetChecked(BOOL bChecked);

// Dialog Data
	//{{AFX_DATA(CFilterDialog)
	enum { IDD = IDD_FILTER_DIALOG };
	CString	m_EditString;
	BOOL	m_bBreakChecked;
	BOOL    m_bRegEx;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CFilterDialog)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CFilterDialog)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_FILTERDIALOG_H__FA49588A_3939_11D3_A6DD_00C04F680B34__INCLUDED_)

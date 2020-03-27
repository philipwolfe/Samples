// File: PipeDlg.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(AFX_PIPEDLG_H__714DF55C_0A74_42E4_8204_183CBA6AE401__INCLUDED_)
#define AFX_PIPEDLG_H__714DF55C_0A74_42E4_8204_183CBA6AE401__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// PipeDlg.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CPipeDlg dialog

class CPipeDlg : public CDialog
{
// Construction
public:
	CPipeDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CPipeDlg)
	enum { IDD = IDD_PIPE_DIALOG };
	CString m_PipeName;
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CPipeDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CPipeDlg)
		// NOTE: the ClassWizard will add member functions here
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_PIPEDLG_H__714DF55C_0A74_42E4_8204_183CBA6AE401__INCLUDED_)

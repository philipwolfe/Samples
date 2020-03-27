// ChildView.h : interface of the CChildView class
//
/////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "TraceFilter.h"

/////////////////////////////////////////////////////////////////////////////
// CChildView window

class CChildView : public CWnd
{
// Construction
public:
	CChildView();

// Attributes
public:
	CEdit m_Edit;
	CFont m_font;
	HICON m_hIcon;
	BOOL m_bBreakOnMessage;
	BOOL m_bRegEx;

// Operations
public:
	LRESULT HandleTraceMessage(ThreadMessageParam* msgParam, LPCTSTR szMessage);
	LRESULT HandleAssertMessage(ThreadMessageParam* msgParam, LPCTSTR szMessage);
	void EscapeShowMessage(LPCTSTR szMessage);
	LRESULT HandleDebugMessage(WPARAM wParam, LPARAM lParam);

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CChildView)
	protected:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	virtual BOOL PreTranslateMessage(MSG* pMsg);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CChildView();

	// Generated message map functions
protected:
	CTraceFilter m_Filter;
	CBrush       m_Brush;
	//{{AFX_MSG(CChildView)
	afx_msg void OnPaint();
	afx_msg void OnSize(UINT uType, int cx, int cy);
	afx_msg BOOL OnEraseBkgnd(CDC* pDC);
	afx_msg HBRUSH OnCtlColor(CDC* pDC, CWnd* pWnd, UINT nCtlColor);
	int OnCreate(CREATESTRUCT *lpcs);
	//}}AFX_MSG
	void OnClear();
	void OnSelectAll();
	void OnCopy();
	void OnFileSave();
	void OnFilter();
	void DisplayPopup(CWnd* pWnd, int x, int y);
	void OnEditFont();
	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

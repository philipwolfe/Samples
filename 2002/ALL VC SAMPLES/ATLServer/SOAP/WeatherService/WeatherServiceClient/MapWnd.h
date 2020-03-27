// File: MapWnd.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(AFX_MAPWND_H__03C564F9_D657_425B_B19C_5EF3745160D1__INCLUDED_)
#define AFX_MAPWND_H__03C564F9_D657_425B_B19C_5EF3745160D1__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// MapWnd.h : header file
//
class CWcliDlg;
/////////////////////////////////////////////////////////////////////////////
// CMapWnd window

class CMapWnd : public CWnd
{
// Construction
public:
	CMapWnd(CWcliDlg*	pHolder);

	CBitmap m_bmp;
	int m_nEndWidth;
	CPoint m_ptSel;
	CString m_strSel;
	BOOL m_bMoving;
	CWcliDlg	*_pHolder;

// Attributes
public:

// Operations
public:
	void DoFlyOut(int nEndWidth);
	void SetSel(LPCTSTR szName, double x, double y);
	BOOL IsVisible()
	{
		return (m_nEndWidth != 0);
	}

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CMapWnd)
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CMapWnd();

	// Generated message map functions
protected:
	//{{AFX_MSG(CMapWnd)
	afx_msg void OnPaint();
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnTimer(UINT nIDEvent);
	afx_msg UINT OnNcHitTest(CPoint point);
	afx_msg LRESULT OnEnterSizeMove(WPARAM, LPARAM);
	afx_msg LRESULT OnExitSizeMove(WPARAM, LPARAM);
	afx_msg void  OnClose();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_MAPWND_H__03C564F9_D657_425B_B19C_5EF3745160D1__INCLUDED_)

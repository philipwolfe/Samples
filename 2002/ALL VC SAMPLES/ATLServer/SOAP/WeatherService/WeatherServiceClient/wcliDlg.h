// wcliDlg.h : header file
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CWcliDlg dialog
#include "mapwnd.h"

#include "WeatherService.h"
using namespace WeatherService;

class CTransparentButton : public CBitmapButton
{
public:
	virtual void DrawItem(LPDRAWITEMSTRUCT lpDIS)
	{
		ASSERT(lpDIS != NULL);
		// must have at least the first bitmap loaded before calling DrawItem
		ASSERT(m_bitmap.m_hObject != NULL);     // required

		// use the main bitmap for up, the selected bitmap for down
		CBitmap* pBitmap = &m_bitmap;
		UINT state = lpDIS->itemState;
		if ((state & ODS_SELECTED) && m_bitmapSel.m_hObject != NULL)
			pBitmap = &m_bitmapSel;
		else if ((state & ODS_FOCUS) && m_bitmapFocus.m_hObject != NULL)
			pBitmap = &m_bitmapFocus;   // third image for focused
		else if ((state & ODS_DISABLED) && m_bitmapDisabled.m_hObject != NULL)
			pBitmap = &m_bitmapDisabled;   // last image for disabled

		// draw the whole button
		CDC* pDC = CDC::FromHandle(lpDIS->hDC);
		CDC memDC;
		memDC.CreateCompatibleDC(pDC);
		CBitmap* pOld = memDC.SelectObject(pBitmap);
		if (pOld == NULL)
			return;     // destructors will clean up

		CRect rect;
		rect.CopyRect(&lpDIS->rcItem);
		pDC->TransparentBlt(rect.left, rect.top, rect.Width(), rect.Height(),
			&memDC, 0, 0, rect.Width(), rect.Height(), RGB(255, 0, 255));
		memDC.SelectObject(pOld);
	}

	BOOL OnEraseBkgnd(CDC* /*pDC*/)
	{
		return TRUE;
	}

	DECLARE_MESSAGE_MAP()
};


class CWcliDlg : public CDialog
{
// Construction
public:
	CWcliDlg(CWnd* pParent = NULL);	// standard constructor
	~CWcliDlg();

	CTransparentButton m_UpdateButton;
	CTransparentButton m_ToggleButton;

	CBitmap m_bmpStatic;
	CBitmap m_bmpTherm;

	void	mapClosed();

	void OnToggleMap();
// Dialog Data
	//{{AFX_DATA(CWcliDlg)
	enum { IDD = IDD_WCLI_DIALOG };
	CStatic	m_staticDesc;
	CComboBox	m_locations;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CWcliDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

	CMapWnd *m_pMapWnd;
	int m_nLowTemp;
	int m_nHiTemp;
	CFont m_fntTemp;

	CWeatherService m_svc;

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CWcliDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg UINT OnNcHitTest(CPoint pt);
	afx_msg void OnOK();
	afx_msg BOOL OnEraseBkgnd(CDC* pDC);
	afx_msg void OnActivate(UINT nState, CWnd* pWndOther, BOOL bMinimized);

	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.


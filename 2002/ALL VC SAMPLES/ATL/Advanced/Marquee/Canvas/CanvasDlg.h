// CanvasDlg.h
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// CanvasDlg.h : header file
//

#pragma once
#include "DrawArea.h"
#include "Script.h"

// CCanvasDlg dialog
class CCanvasDlg : public CDialog
{
	DECLARE_DYNAMIC(CCanvasDlg);

// Construction
public:
	CCanvasDlg(CWnd* pParent = NULL);	// standard constructor
	virtual ~CCanvasDlg();

// Dialog Data
	enum { IDD = IDD_CANVAS_DIALOG };
	CDrawArea m_wndDrawArea;

public:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	void OnFinalRelease(void);

// Implementation
protected:
	HICON m_hIcon;

	CComPtr<IScriptDriver> m_spScriptDriver;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnClose();
	virtual void OnOK();
	virtual void OnCancel();
	afx_msg void OnTimer(UINT nIDEvent);
	afx_msg void OnDestroy(void);

	DECLARE_MESSAGE_MAP()
	DECLARE_DISPATCH_MAP()
	DECLARE_INTERFACE_MAP()

protected:
	HRESULT DrawLine(
		/* in */ int x1, /* in */ int y1,
		/* in */ int x2, /* in */ int y2,
		/* in */ int r, /* in */ int g, /* in */ int b);
	HRESULT FillRect(
		/* in */ int left, /* in */ int top, /* in */ int right, /* in */ int bottom,
		/* in */ int r, /* in */ int g, /* in */ int b);
	HRESULT FrameRect(
		/* in */ int left, /* in */ int top, /* in */ int right, /* in */ int bottom,
		/* in */ int r, /* in */ int g, /* in */ int b);
	HRESULT Ellipse(
		/* in */ int left, /* in */ int top, /* in */ int right, /* in */ int bottom,
		/* in */ int rEdge, /* in */ int gEdge, /* in */ int bEdge,
		/* in */ int rFill, /* in */ int gFill, /* in */ int bFill);
	long GetWidth(void);
	long GetHeight(void);
};

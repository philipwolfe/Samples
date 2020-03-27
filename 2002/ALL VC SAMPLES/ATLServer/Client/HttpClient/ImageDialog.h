// File: ImageDialog.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once


// CImageDialog dialog

class CImageDialog : public CDialog
{
	DECLARE_DYNAMIC(CImageDialog)

public:
	CImageDialog(CWnd* pParent = NULL);   // standard constructor
	virtual ~CImageDialog();

	void SetTitle(LPCTSTR t)  { title = t; }
	HRESULT Load(LPCTSTR);
	BOOL OnInitDialog();

// Dialog Data
	enum { IDD = IDD_IMAGEDLG };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()

private:
	CImage image;
	CString title;
public:
	afx_msg void OnPaint(void);
};

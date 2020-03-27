// ImageDialog.cpp : implementation file
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "HttpClient.h"
#include "ImageDialog.h"


// CImageDialog dialog

IMPLEMENT_DYNAMIC(CImageDialog, CDialog)
CImageDialog::CImageDialog(CWnd* pParent /*=NULL*/)
	: CDialog(CImageDialog::IDD, pParent)
{
}

CImageDialog::~CImageDialog()
{
}

HRESULT CImageDialog::Load(LPCTSTR fileName)
{
	return image.Load( fileName );
}

BOOL CImageDialog::OnInitDialog()
{
	CDialog::OnInitDialog();

	// calculate proper window size so that client area is equal to image size
	int w = image.GetWidth();
	int h = image.GetHeight();

	RECT clientRect;
	GetClientRect( &clientRect );

	RECT windowRect;
	GetWindowRect( &windowRect );
	windowRect.right -= windowRect.left;
	windowRect.left = 0;
	windowRect.bottom -= windowRect.top;
	windowRect.top = 0;

	int wdiff = windowRect.right - clientRect.right;
	int hdiff = windowRect.bottom - clientRect.bottom;

	// resize dialog to image
	ATLASSERT(SetWindowPos( &wndTop, 0, 0, w + wdiff, h + hdiff, SWP_NOMOVE ));

	SetWindowText( title );

	return TRUE;
}

void CImageDialog::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CImageDialog, CDialog)
	ON_WM_PAINT()
END_MESSAGE_MAP()


// CImageDialog message handlers

void CImageDialog::OnPaint(void)
{
	CPaintDC dc(this); // device context for painting
	ATLASSERT(image.BitBlt( dc, 0, 0 ));
}

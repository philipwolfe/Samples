// DrawArea.cpp
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// DrawArea.cpp : implementation file
//

#include "stdafx.h"
#include "Canvas.h"
#include "DrawArea.h"


// CDrawArea

IMPLEMENT_DYNAMIC(CDrawArea, CStatic)
CDrawArea::CDrawArea()
{
}

CDrawArea::~CDrawArea()
{
}


BEGIN_MESSAGE_MAP(CDrawArea, CStatic)
END_MESSAGE_MAP()



// CDrawArea message handlers

HRESULT CDrawArea::DrawLine(CPoint p1, CPoint p2, COLORREF clr)
{
	HDC hDC = m_backbuffer.GetDC();
	CDC* pDC = CDC::FromHandle(hDC);

	CPen pen;
	CPen* pPenOrig;

	pen.CreatePen(PS_SOLID, 0, clr);
	pPenOrig = pDC->SelectObject(&pen);
	pDC->MoveTo(p1);
	pDC->LineTo(p2);
	pDC->SelectObject(pPenOrig);

	m_backbuffer.ReleaseDC();

	return S_OK;
}

HRESULT CDrawArea::FillRect(CRect rect, COLORREF clr)
{
	HDC hDC = m_backbuffer.GetDC();
	CDC* pDC = CDC::FromHandle(hDC);

	CBrush brush;

	brush.CreateSolidBrush(clr);
	pDC->FillRect(rect, &brush);

	m_backbuffer.ReleaseDC();

	return S_OK;
}

HRESULT CDrawArea::FrameRect(CRect rect, COLORREF clr)
{
	HDC hDC = m_backbuffer.GetDC();
	CDC* pDC = CDC::FromHandle(hDC);

	CBrush brush;

	brush.CreateSolidBrush(clr);
	pDC->FrameRect(rect, &brush);

	m_backbuffer.ReleaseDC();

	return S_OK;
}

HRESULT CDrawArea::Ellipse(CRect rect, COLORREF clrEdge, COLORREF clrFill)
{
	HDC hDC = m_backbuffer.GetDC();
	CDC* pDC = CDC::FromHandle(hDC);

	CPen pen;
	CPen* pPenOrig;
	CBrush brush;
	CBrush* pBrushOrig;

	pen.CreatePen(PS_SOLID, 0, clrEdge);
	pPenOrig = pDC->SelectObject(&pen);
	brush.CreateSolidBrush(clrFill);
	pBrushOrig = pDC->SelectObject(&brush);
	pDC->Ellipse(rect);
	pDC->SelectObject(pBrushOrig);
	pDC->SelectObject(pPenOrig);

	m_backbuffer.ReleaseDC();

	return S_OK;
}

long CDrawArea::GetWidth(void)
{
	return m_backbuffer.GetWidth();
}

long CDrawArea::GetHeight(void)
{
	return m_backbuffer.GetHeight();
}

void CDrawArea::Initialize()
{
	CRect rect;
	GetWindowRect(rect);
	m_backbuffer.Create(rect.Width(), rect.Height(), 24);
}

void CDrawArea::Flip()
{
	CWindowDC dc(this);
	m_backbuffer.Draw(dc, CPoint(0, 0));
}

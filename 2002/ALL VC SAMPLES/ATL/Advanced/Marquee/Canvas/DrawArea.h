// DrawArea.h
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

#pragma once


// CDrawArea

class CDrawArea : public CStatic
{
	DECLARE_DYNAMIC(CDrawArea)

public:
	CDrawArea();
	virtual ~CDrawArea();

	HRESULT DrawLine(CPoint p1, CPoint p2, COLORREF clr);
	HRESULT FillRect(CRect rect, COLORREF clr);
	HRESULT FrameRect(CRect rect, COLORREF clr);
	HRESULT Ellipse(CRect rect, COLORREF clrEdge, COLORREF clrFill);
	long GetWidth(void);
	long GetHeight(void);

	void Initialize();
	void Flip();

protected:
	CImage m_backbuffer;

	DECLARE_MESSAGE_MAP()
};

// MapWnd.cpp : implementation file
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "wcli.h"
#include "MapWnd.h"
#include "WcliDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMapWnd

CMapWnd::CMapWnd(CWcliDlg*	pHolder) : m_ptSel(-1, -1), m_nEndWidth(0), m_bMoving(FALSE), _pHolder(pHolder)
{
}

CMapWnd::~CMapWnd()
{
}


BEGIN_MESSAGE_MAP(CMapWnd, CWnd)
	//{{AFX_MSG_MAP(CMapWnd)
	ON_WM_PAINT()
	ON_WM_CREATE()
	ON_WM_TIMER()
	ON_WM_NCHITTEST()
	ON_MESSAGE( WM_ENTERSIZEMOVE, OnEnterSizeMove )
	ON_MESSAGE( WM_EXITSIZEMOVE, OnExitSizeMove )
	ON_WM_CLOSE()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()


/////////////////////////////////////////////////////////////////////////////
// CMapWnd message handlers
void CMapWnd::OnPaint() 
{
	CPaintDC dc(this); // device context for painting
	CRect rct;
	GetClientRect(&rct);

	CDC dcMem;
	dcMem.CreateCompatibleDC(NULL);

	CBitmap *pOldBmp = dcMem.SelectObject(&m_bmp);
	dc.BitBlt(0, 0, rct.Width(), rct.Height(), &dcMem, 0, 0, SRCCOPY);

	if (m_ptSel.x >= 0)
	{
		CPen pen;
		pen.CreatePen(PS_SOLID, 1, RGB(255, 0, 0));
		CPen *pOldPen = dc.SelectObject(&pen);

		dc.MoveTo(3*m_ptSel.x/4, 0);
		dc.LineTo(3*m_ptSel.x/4, rct.bottom);
		dc.MoveTo(0, 3*m_ptSel.y/4);
		dc.LineTo(rct.right, 3*m_ptSel.y/4);
		
		CRect rctText;
		rctText.left = 3*m_ptSel.x/4 + 10;
		rctText.top = 3*m_ptSel.y/4 - 20;
		rctText.right = rct.right;
		rctText.bottom = rctText.top + 50;

		dc.SetTextColor(RGB(255, 0, 0));
		dc.DrawText(m_strSel, rctText, DT_SINGLELINE);
		dc.SelectObject(pOldPen);
	}
	dcMem.SelectObject(pOldBmp);
	// Do not call CWnd::OnPaint() for painting messages
}

LRESULT CMapWnd::OnEnterSizeMove(WPARAM, LPARAM)
{
	m_bMoving = TRUE;
	return 0;
}

LRESULT CMapWnd::OnExitSizeMove(WPARAM, LPARAM)
{
	m_bMoving = FALSE;
	return 0;
}

int CMapWnd::OnCreate(LPCREATESTRUCT lpCreateStruct) 
{
	if (CWnd::OnCreate(lpCreateStruct) == -1)
		return -1;
	
	m_bmp.LoadBitmap(IDB_US);	
	return 0;
}

void CMapWnd::DoFlyOut(int nEndWidth)
{
	if (nEndWidth)
		ShowWindow(SW_SHOW);
	m_nEndWidth = nEndWidth;
	SetTimer(100, 1, NULL);
}


void CMapWnd::OnTimer(UINT_PTR nIDEvent) 
{
	CRect rct;
	GetClientRect(&rct);
	ClientToScreen(&rct);

	if (nIDEvent == 100 && !m_bMoving)
	{
		if (m_nEndWidth == 0 && rct.Width() > 0)
		{
			if (rct.Width() > 10)
				rct.left += 10;
			else
				rct.left = rct.right;
			MoveWindow(&rct, TRUE);
		}
		else if (rct.Width() < m_nEndWidth)
		{
			rct.left -= (m_nEndWidth - rct.Width()) > 10 ?  10 : (m_nEndWidth - rct.Width());
			MoveWindow(&rct, TRUE);
		}
		else
		{
			KillTimer(nIDEvent);
			if (m_nEndWidth == 0)
				ShowWindow(SW_HIDE);
		}
	}
	else if (nIDEvent == 200)
	{

	}
	CWnd::OnTimer(nIDEvent);
}

#define MAP_CENTER_THETA 114.4167
#define MAP_CENTER_PHI 51.75

#define SCALE_X -610.7272852
#define SCALE_Y -616.4392797

#define ADJ_X 410.1972319
#define ADJ_Y 266.7813696

double d2r(double d)
{
    return M_PI * d / 180.0;
}

double r2d(double d)
{
    return 180.0 * d / M_PI;
}

void LongLatToXY(double theta, double phi, LONG *px, LONG *py)
{
    double theta1 = theta - MAP_CENTER_THETA;
    double theta2, phi2;
    {
        double x, y, z;
        x = cos(d2r(phi)) * sin(d2r(theta1));
        y = cos(d2r(phi)) * cos(d2r(theta1));
        z = sin(d2r(phi));
        theta2 = atan(z / y) - d2r(MAP_CENTER_PHI);
        phi2 = asin(x);
//        printf("x = %lf, y = %lf, z = %lf\n", x, y, z);
    }

    double outx, outy;
    {
        double x, y, z;
        x = cos(phi2) * sin(theta2);
        y = cos(phi2) * cos(theta2);
        z = sin(phi2);
        outx = z;
        outy = x;
    }
//    printf("%lf, %lf\n", outx, outy);

//    printf("x = %lf, y = %lf\n", SCALE_X * outx + ADJ_X, SCALE_Y * outy + ADJ_Y);
	outx = SCALE_X * outx + ADJ_X;
	outy = SCALE_Y * outy + ADJ_Y;
	*px = (int) outx;
	*py = (int) outy;
}

void CMapWnd::SetSel(LPCTSTR szName, double longitude, double latitude)
{
	m_strSel = szName;
	LongLatToXY(longitude, latitude, &m_ptSel.x, &m_ptSel.y);
}


UINT CMapWnd::OnNcHitTest(CPoint /*point*/) 
{
	UINT uDef = (UINT) Default();
	if (uDef == HTCLIENT)
		return HTCAPTION;
	return uDef;
}

void CMapWnd::OnClose()
{
	CWnd::OnClose();
	if( _pHolder )
	{
		_pHolder->mapClosed();
	}
}
// wcliDlg.cpp : implementation file
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
#include "wcliDlg.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

BEGIN_MESSAGE_MAP(CTransparentButton, CBitmapButton)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
	ON_WM_ERASEBKGND()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CWcliDlg dialog

CWcliDlg::CWcliDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CWcliDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CWcliDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	m_pMapWnd = NULL;
	m_nLowTemp = -20;
	m_nHiTemp = -20;
}

CWcliDlg::~CWcliDlg()
{
	delete m_pMapWnd;
}

void CWcliDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CWcliDlg)
	DDX_Control(pDX, IDC_DESCRIPTION, m_staticDesc);
	DDX_Control(pDX, IDC_COMBO1, m_locations);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CWcliDlg, CDialog)
	//{{AFX_MSG_MAP(CWcliDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_NCHITTEST()
	ON_WM_ERASEBKGND()
	ON_BN_CLICKED(IDC_TOGGLEMAP, OnToggleMap)
	ON_WM_ACTIVATE()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CWcliDlg message handlers

BOOL CWcliDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Initialize the bitmap button
	m_bmpTherm.LoadBitmap(IDB_THERM);

	m_UpdateButton.LoadBitmaps(IDB_UPDATE, IDB_UPDATEDN);
	m_UpdateButton.SubclassDlgItem(IDOK, this);
	m_UpdateButton.SizeToContent();

	m_ToggleButton.LoadBitmaps(IDB_LEFTUP, IDB_LEFTDN);
	m_ToggleButton.SubclassDlgItem(IDC_TOGGLEMAP, this);
	m_ToggleButton.SizeToContent();


	HDC hDC;
	hDC = ::GetDC(NULL);

	m_fntTemp.CreateFont(-MulDiv(10, GetDeviceCaps(hDC, LOGPIXELSY), 72),
		0, 0, 0, FW_BOLD, 0, 0, 0, ANSI_CHARSET, OUT_TT_PRECIS, CLIP_DEFAULT_PRECIS,
		ANTIALIASED_QUALITY, DEFAULT_PITCH | FF_DONTCARE, "Arial");
	::ReleaseDC(NULL, hDC);

	// enable color keying on the dialog.
	SetLayeredWindowAttributes(RGB(255, 0, 255), 200, LWA_COLORKEY);

	CRect rct;
	GetClientRect(&rct);

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	SetWindowText(_T("WeatherSample"));

	// Here we call the WebService on the server
	// to retrieve a list of the available cities
	// Notice that the call is a simple call
	// through the proxy class
	BSTR *cities = NULL;
	int nCount;
	HRESULT hr = m_svc.GetAvailableCities(&cities, &nCount);
	if (FAILED(hr))
	{
		AfxMessageBox("Failed enumerating cities");
		EndDialog(IDCANCEL);
		return FALSE;
	}

	// add the cities to the combobox
	for (int i=0; i<nCount; i++)
	{
		m_locations.AddString(CString(cities[i]));
	}

	// We now need to free the cities array since
	// it was returned by the proxy
	AtlCleanupArray(cities, nCount);
	free(cities);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CWcliDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CWcliDlg::OnPaint() 
{
	CPaintDC dc(this);
	CRect rctHi;

	CDC memDC;
	HDC hDCDesktop = ::GetDC(NULL);
	memDC.CreateCompatibleDC(CDC::FromHandle(hDCDesktop));
	::ReleaseDC(NULL, hDCDesktop);

	CBitmap* pOld = memDC.SelectObject(&m_bmpTherm);

	CWnd *pHiTherm = GetDlgItem(IDC_HITHERM);
	pHiTherm->GetWindowRect(&rctHi);
	ScreenToClient(&rctHi);

	dc.TransparentBlt(rctHi.left, rctHi.top, rctHi.Width(), rctHi.Height(),
		&memDC, 0, 0, rctHi.Width(), rctHi.Height(), RGB(255, 0, 255));

	CBrush br;
	br.CreateSolidBrush(RGB(255, 0, 0));

	rctHi.bottom -= 3;
	rctHi.left += 7;
	rctHi.right -= 7;
	rctHi.top = (int) (rctHi.bottom - (m_nHiTemp + 20.0) / 140 * (rctHi.Height()));

	dc.FillRect(&rctHi, &br);

	CFont *pOldFont = dc.SelectObject(&m_fntTemp);
	dc.SetBkMode(TRANSPARENT);
	dc.SetTextColor(RGB(255, 255, 0));
	TCHAR szTmp[20];

	if (m_nHiTemp != -20)
	{
		_stprintf(szTmp, _T("%d"), m_nHiTemp);
		rctHi.OffsetRect(12, 0);
		dc.DrawText(szTmp, -1, rctHi, DT_SINGLELINE | DT_NOCLIP);
	}

	memDC.SelectObject(pOld);
	dc.SelectObject(pOldFont);
}

HCURSOR CWcliDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}


UINT CWcliDlg::OnNcHitTest(CPoint /*pt*/)
{
	UINT uDef = (UINT) Default();
	if (uDef == HTCLIENT)
		return HTCAPTION;
	return uDef;
}

UINT GetBitmapIdForCondition(WeatherConditions condition)
{
	UINT uIdBitmap;
	switch (condition)
	{
		case Sunny:
			uIdBitmap = IDB_SUNNY;
			break;
		case Showers:
			uIdBitmap = IDB_SHOWERS;
			break;
		case Rainy:
			uIdBitmap = IDB_RAINY;
			break;
		case Fair:
			uIdBitmap = IDB_FAIR;
			break;
		case Cloudy:
			uIdBitmap = IDB_CLOUDY;
			break;
		default:
			uIdBitmap = IDB_RAINY;
			break;

	}
	return uIdBitmap;
}

void CWcliDlg::OnOK() 
{
	USES_CONVERSION;

	int nSel = m_locations.GetCurSel();
	if (nSel < 0)
	{
		AfxMessageBox("Please select a location and try again", MB_ICONINFORMATION);
		return;
	}

	CComBSTR bstrCity;
	CString strCity;
	m_locations.GetLBText(nSel, strCity);

	bstrCity = strCity;

	// Here we call the WebService
	// to retrieve the current conditions
	// for the selected city.
	Conditions conditions;
	memset(&conditions, 0x00, sizeof(conditions));

	HRESULT hr = m_svc.GetCurrentConditions(bstrCity, &conditions);
	if (FAILED(hr))
	{
		AfxMessageBox("Failed getting conditions");
		return;
	}

	m_nHiTemp = conditions.temperature;

	// update the bitmap for the current conditions
	UINT uIdBitmap = GetBitmapIdForCondition(conditions.description);
	HBITMAP hBmp = m_staticDesc.SetBitmap(LoadBitmap(AfxGetResourceHandle(), MAKEINTRESOURCE(uIdBitmap)));
	if (hBmp)
		DeleteObject(hBmp);

	AtlCleanupValue(&conditions);

	double dblLongitude;
	double dblLatitude;

	// Get the longitude and latitude of the selected
	// city from the server
	hr = m_svc.GetCityLocation(bstrCity, &dblLongitude, &dblLatitude);
	if (FAILED(hr))
	{
		AfxMessageBox("Failed getting city location");
		return;
	}

	Forecast *forecast = (Forecast *) malloc(5*sizeof(Forecast));

	// Get the 5 day forecast from the server
	hr = m_svc.GetForecast(bstrCity, forecast);
	if (FAILED(hr))
	{
		AfxMessageBox("Failed getting forecast");
	}
	else
	{
		static UINT s_ids[] = { IDC_FORECAST1, IDC_FORECAST2, IDC_FORECAST3, IDC_FORECAST4, IDC_FORECAST5 };
		static UINT s_idsTemp[] = { IDC_HILO1, IDC_HILO2, IDC_HILO3, IDC_HILO4, IDC_HILO5 };

		for (int i=0; i<5; i++)
		{
			UINT uIdBitmap = GetBitmapIdForCondition(forecast[i].description);
			HBITMAP hBmp = ((CStatic*) GetDlgItem(s_ids[i]))->SetBitmap(LoadBitmap(AfxGetResourceHandle(), MAKEINTRESOURCE(uIdBitmap)));
			if (hBmp)
				DeleteObject(hBmp);
			CString strTemp;
			strTemp.Format("%d\n%d", forecast[i].hiTemp, forecast[i].loTemp);
			GetDlgItem(s_idsTemp[i])->SetWindowText(strTemp);
		}
		// free the array
		AtlCleanupArray(forecast, 5);
		free(forecast);
	}

	if (!m_pMapWnd || !m_pMapWnd->IsVisible())
		OnToggleMap();

	m_pMapWnd->SetSel(strCity, dblLongitude, dblLatitude);

	m_pMapWnd->RedrawWindow();
	RedrawWindow();
}

BOOL CWcliDlg::OnEraseBkgnd(CDC* pDC) 
{
	CRect rct;
	GetClientRect(&rct);

	CBitmap bmp;
	bmp.LoadBitmap(IDB_SOAP);

	CDC dcMem;
	dcMem.CreateCompatibleDC(NULL);

	CBitmap *pOldBmp = dcMem.SelectObject(&bmp);
	pDC->BitBlt(0, 0, rct.Width(), rct.Height(), &dcMem, 0, 0, SRCCOPY);

	dcMem.SelectObject(pOldBmp);
	return TRUE;
}

void CWcliDlg::OnToggleMap()
{
	if (!m_pMapWnd)
	{
		CRect rct;
		GetWindowRect(&rct);
		rct.right = rct.left;
		rct.top = rct.top - 200;
		rct.bottom = rct.top + 400;

		m_pMapWnd = new CMapWnd(this);
		
		m_pMapWnd->CreateEx(WS_EX_TOOLWINDOW, AfxRegisterWndClass(CS_DBLCLKS | CS_HREDRAW | CS_VREDRAW), "", WS_POPUP | WS_VISIBLE, rct, NULL, 0);
		m_pMapWnd->SetWindowPos(this, 0, 0, 0, 0, SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOREDRAW | SWP_NOSIZE | SWP_SHOWWINDOW);
		m_pMapWnd->ShowWindow(SW_SHOW);
	}

	CRect rct;
	if (m_pMapWnd->IsVisible() == FALSE)
	{
		m_ToggleButton.LoadBitmaps(IDB_RIGHTUP, IDB_RIGHTDN);
		m_ToggleButton.GetClientRect(&rct);
		m_ToggleButton.MapWindowPoints(this, &rct);
		InvalidateRect(&rct, TRUE);
		UpdateWindow();
		m_pMapWnd->DoFlyOut(612);
		m_pMapWnd->RedrawWindow();
	}
	else
	{
		m_ToggleButton.LoadBitmaps(IDB_LEFTUP, IDB_LEFTDN);
		m_ToggleButton.GetClientRect(&rct);
		m_ToggleButton.MapWindowPoints(this, &rct);
		InvalidateRect(&rct, TRUE);
		UpdateWindow();
		m_pMapWnd->DoFlyOut(0);
		m_pMapWnd->RedrawWindow();
	}
}

void CWcliDlg::OnActivate(UINT nState, CWnd* pWndOther, BOOL bMinimized)
{
	CDialog::OnActivate(nState, pWndOther, bMinimized);
	if (nState != WA_INACTIVE)
	{
		if (m_pMapWnd)
		{
			m_pMapWnd->SetWindowPos(this, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_SHOWWINDOW);
		}
	}
}


void CWcliDlg::mapClosed()
{
	if( m_pMapWnd )
	{
		delete	m_pMapWnd;
		m_pMapWnd	=	NULL;
	}

	CRect rct;
	m_ToggleButton.LoadBitmaps(IDB_LEFTUP, IDB_LEFTDN);
	m_ToggleButton.GetClientRect(&rct);
	m_ToggleButton.MapWindowPoints(this, &rct);
	InvalidateRect(&rct, TRUE);
	UpdateWindow();
}
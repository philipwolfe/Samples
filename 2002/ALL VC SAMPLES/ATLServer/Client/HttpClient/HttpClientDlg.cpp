// HttpClientDlg.cpp : implementation file
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
#include "HttpClientDlg.h"
#include "BasicAuthDlg.h"
#include "ImageDialog.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


const TCHAR HTTP_CLIENT_INI[] = _T(".//HttpClient.ini"); 

CImage::CInitGDIPlus CImage::s_initGDIPlus;

// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()


class CSampleBasicAuth : public CBasicAuthObject, public IAuthInfo
{
	
	void Init(CAtlHttpClient *pSocket, IAuthInfo *pAuthInfo)
	{
		CBasicAuthObject::Init( pSocket, pAuthInfo );
	}
	

	bool Authenticate(LPCTSTR szAuthTypes, bool bProxy)
	{
		CBasicAuthDlg authDlg;
	
		if (authDlg.DoModal() == IDOK)
		{
			username = authDlg.m_username; 
			password = authDlg.m_password;

			return CBasicAuthObject::Authenticate( szAuthTypes, bProxy );
		}

		return false;
	}

	HRESULT GetPassword(LPTSTR szPwd, DWORD* dwBuffSize)
	{
		if (CopyCString( password, szPwd, dwBuffSize ))
			return S_OK;

		return E_FAIL;
	}

	HRESULT GetUsername(LPTSTR szUid, DWORD* dwBuffSize)
	{
		if (CopyCString( username, szUid, dwBuffSize ))
			return S_OK;

		return E_FAIL;
	}
	HRESULT GetDomain(LPTSTR szDomain, DWORD* dwBuffSize)
	{
		ATLASSERT(false);
		return S_OK;
	}

	CString username;
	CString password;
};



CHttpClientDlg::CHttpClientDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CHttpClientDlg::IDD, pParent),
	client(0),
	clientInUse(false),
	cancelNavigate(false),
	m_urlStr(_T("http://")),
	m_proxy(_T("")),
	m_response(_T("")),
	m_proxy_port(80),
	m_auth_basic(FALSE),
	m_auth_ntlm(FALSE),
	m_use_proxy(FALSE)
{
	// load URL, proxy server, and authentication settings from HttpClient.INI...

	TCHAR str[128];

	GetPrivateProfileString( _T("settings"), _T("use_proxy"), _T("false"), str, 128, HTTP_CLIENT_INI );
	if (lstrcmpi( str, _T("true") ) == 0)
		m_use_proxy = TRUE;
	else
		m_use_proxy = FALSE;

	GetPrivateProfileString( _T("settings"), _T("url"), _T("http://"), str, 128, HTTP_CLIENT_INI );
	m_urlStr = str;

	GetPrivateProfileString( _T("settings"), _T("proxy"), _T(""), str, 128, HTTP_CLIENT_INI );
	m_proxy = str;

	GetPrivateProfileString( _T("settings"), _T("proxyport"), _T("80"), str, 128, HTTP_CLIENT_INI );
	m_proxy_port = _ttoi(str);

	GetPrivateProfileString( _T("settings"), _T("basic_auth"), _T("false"), str, 128, HTTP_CLIENT_INI );
	if (lstrcmpi( str, _T("true") ) == 0)
		m_auth_basic = TRUE;
	else
		m_auth_basic = FALSE;

	GetPrivateProfileString( _T("settings"), _T("ntlm_auth"), _T("false"), str, 128, HTTP_CLIENT_INI );
	if (lstrcmpi( str, _T("true") ) == 0)
		m_auth_ntlm = TRUE;
	else
		m_auth_ntlm = FALSE;

	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

CHttpClientDlg::~CHttpClientDlg()
{
	// Save current settings to HttpClient.INI...

	WritePrivateProfileString( _T("settings"), _T("url"), m_urlStr, HTTP_CLIENT_INI );

	if (m_use_proxy)
		WritePrivateProfileString( _T("settings"), _T("use_proxy"), _T("true"),  HTTP_CLIENT_INI );
	else
		WritePrivateProfileString( _T("settings"), _T("use_proxy"), _T("false"),  HTTP_CLIENT_INI );

	WritePrivateProfileString( _T("settings"), _T("proxy"), m_proxy, HTTP_CLIENT_INI );

	CString port;
	port.Format( _T("%d"), m_proxy_port );
	WritePrivateProfileString( _T("settings"), _T("proxyport"), port, HTTP_CLIENT_INI );

	if (m_auth_basic)
		WritePrivateProfileString( _T("settings"), _T("basic_auth"), _T("true"), HTTP_CLIENT_INI );
	else
		WritePrivateProfileString( _T("settings"), _T("basic_auth"), _T("false"), HTTP_CLIENT_INI );

	if (m_auth_ntlm)
		WritePrivateProfileString( _T("settings"), _T("ntlm_auth"), _T("true"), HTTP_CLIENT_INI );
	else
		WritePrivateProfileString( _T("settings"), _T("ntlm_auth"), _T("false"), HTTP_CLIENT_INI );

	if (client)
		delete client;
}

void CHttpClientDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_URL, m_urlStr);
	DDX_Text(pDX, IDC_PROXY, m_proxy);
	DDX_Text(pDX, IDC_PROXYPORT, m_proxy_port);
	DDX_Check(pDX, IDC_AUTH_BASIC, m_auth_basic);
	DDX_Check(pDX, IDC_AUTH_NTLM, m_auth_ntlm);
	DDX_Check(pDX, IDC_USEPROXY, m_use_proxy);
	DDX_Control(pDX, IDC_PROGRESSBAR, m_progressBar);
	DDX_Control(pDX, IDOK, m_navigateButton);
}

BEGIN_MESSAGE_MAP(CHttpClientDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_USEPROXY, OnBnClickedUseproxy)
END_MESSAGE_MAP()


// CHttpClientDlg message handlers

CHttpClientDlg* thisDlg;

BOOL CHttpClientDlg::OnInitDialog()
{
	thisDlg = this;

	CDialog::OnInitDialog();

	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	OnBnClickedUseproxy();

	return TRUE;  // return TRUE  unless you set the focus to a control
}

bool WINAPI CHttpClientDlg::Callback(DWORD bytes, DWORD objPtr)
{
	CHttpClientDlg* thisObj = thisDlg;
	ATLASSERT(thisObj);

	MSG msg;
	while (::PeekMessage( &msg , NULL, NULL, NULL, PM_REMOVE ))
	{
		::TranslateMessage( &msg );
		::DispatchMessage( &msg );
	} 

	CProgressCtrl* bar = &thisObj->m_progressBar;
	ATLASSERT(bar);

	CString val;
	thisObj->client->GetHeaderValue( _T("Content-Length"), val);
	int totalLen = _ttoi(val);

	int curLen = thisObj->client->GetResponseLength();

	bar->SetRange32( 0, totalLen );

	bar->SetPos( curLen );

	return !thisObj->cancelNavigate;
}

void CHttpClientDlg::OnOK()
{
	if (clientInUse)
	{
		cancelNavigate = true;
		return;
	}

	CWnd* response = GetDlgItem( IDC_RESPONSE );
	UpdateData();

	int doubleSlash = m_urlStr.Find( _T("//") );
	if (doubleSlash > 0)
	{
		if (m_urlStr.Left(7).CompareNoCase(_T("http://")) != 0)
		{
			m_urlStr = m_urlStr.Mid( doubleSlash, m_urlStr.GetLength() - doubleSlash );
			m_urlStr = _T("http:") + m_urlStr;
			UpdateData( false );
		}
	}
	else
	{
		m_urlStr = _T("http://") + m_urlStr;
		UpdateData( false );
	}

	if (client)
		delete client;
	client = new CAtlHttpClient;

	CAtlNavigateData navData;

	navData.SetReadStatusCallback( Callback, 0 );

	if (m_use_proxy)
	{
		if (m_proxy_port < 0)
		{
			m_proxy_port = abs(m_proxy_port);
			UpdateData( false );
		}

		if (m_proxy.GetLength() > 0)
		{
			int ds = m_proxy.Find( _T("//") );
			if (ds > 0)
			{
				m_proxy = m_proxy.Mid( ds, m_proxy.GetLength() - ds );
				UpdateData( false );
			}
		}

		client->SetProxy( m_proxy, m_proxy_port );
	}

	// We've overridden the CBasicAuthObject functionality to
	// display a dialog requesting username and password.
	// Both functionalities are provided by the CSampleBasicAuth
	// class, so it is used for both the authentication and
	// the IAuthInfo arguments.
	CSampleBasicAuth basicAuth;
	if (m_auth_basic)
		client->AddAuthObj( _T("basic"), &basicAuth, &basicAuth );

	// We're using the standard CNLMAuthObject class here
	// because it automatically uses the current user's
	// credentials if no IAuthInfo implemenation is given.
	CNTLMAuthObject ntlmAuth;
	if (m_auth_ntlm)
		client->AddAuthObj( _T("NTLM"), &ntlmAuth );

	response->SetWindowText( _T("working...") );

	clientInUse = true;
	m_navigateButton.SetWindowText( _T("Cancel") );

	UpdateWindow();

	char* body = 0;
	int bodyLen = 0;
	bool imageData = false;

	if (client->Navigate( m_urlStr, &navData ))
	{
		DWORD headerSize;
		client->GetRawResponseHeader( 0, &headerSize );

		char* head = 0;
		if (headerSize > 0)
		{
			head = new char[headerSize];
			client->GetRawResponseHeader( reinterpret_cast<BYTE*>(head), &headerSize );
		}

		if (client->GetStatus() == 200) // 200 = successful HTTP transaction
		{
			bodyLen = client->GetBodyLength();
			body = new char[bodyLen+1];
			memcpy( body, client->GetBody(), bodyLen );
			body[bodyLen] = 0;

			CString text;
		
			if (head)
			{
				text += "--==[[ HEADER ]]==--\r\n";
				text += head;
			}

			text += "--==[[ BODY ]]==--\r\n";

			CString contentType;
			client->GetHeaderValue( _T("Content-Type"), contentType );
			if (contentType.Left(5).CompareNoCase( _T("image") ) == 0 && body && bodyLen > 0)
			{
				imageData = true;
				text += "(image data)";
			}
			else
				text += body;
		
			delete [] head;

			response->SetWindowText( text );
		}
	}
	else
	{
		if (cancelNavigate)
			response->SetWindowText( _T("request canceled") );
		else
		{
			CString str;
			str.Format( _T("request failed - status code: %d\r\n"), client->GetStatus() );
			response->SetWindowText( str );
		}
	}

	clientInUse = false;
	cancelNavigate = false;

	m_progressBar.SetPos( 0 );
	m_navigateButton.SetWindowText( _T("Navigate") );

	UpdateData(false);

	if (imageData)
	{
		CAtlFile file;
		if (SUCCEEDED(file.Create( _T("tmp_image"), GENERIC_WRITE, FILE_SHARE_WRITE, CREATE_ALWAYS )))
		{
			if (SUCCEEDED(file.Write( body, bodyLen )))
			{
				file.Close();

				CString title = m_urlStr;
				int slashPos = title.ReverseFind( '/' );
				if (slashPos != -1)
					title = title.Right( m_urlStr.GetLength() - slashPos - 1 );
			
				CImageDialog dlg;
				dlg.SetTitle( title );
				if (SUCCEEDED(dlg.Load( _T("tmp_image") )))
				{
					dlg.DoModal();
				}
				unlink( "tmp_image" );
			}
		}
	}
	delete [] body;
}

void CHttpClientDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CHttpClientDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this);

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

HCURSOR CHttpClientDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CHttpClientDlg::OnBnClickedUseproxy(void)
{
	CWnd* proxyEdit = GetDlgItem( IDC_PROXY );
	CWnd* proxyText = GetDlgItem( IDC_PROXY_TEXT );
	CWnd* proxyPortEdit = GetDlgItem( IDC_PROXYPORT );
	CWnd* proxyPortText = GetDlgItem( IDC_PROXYPORT_TEXT );

	UpdateData();

	if (m_use_proxy)
	{
		proxyEdit->EnableWindow();
		proxyText->EnableWindow();
		proxyPortEdit->EnableWindow();
		proxyPortText->EnableWindow();
	}
	else
	{
		proxyEdit->EnableWindow( FALSE );
		proxyText->EnableWindow( FALSE );
		proxyPortEdit->EnableWindow( FALSE );
		proxyPortText->EnableWindow( FALSE );
	}
}

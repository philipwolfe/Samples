// IMAPISampleDlg.cpp : implementation file
//

#include "stdafx.h"
#include "IMAPISample.h"
#include "IMAPISampleDlg.h"
#include "CreateJolietDiskDlg.h"
#include "CreateRedbookDiskDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
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


// CIMAPISampleDlg dialog



CIMAPISampleDlg::CIMAPISampleDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CIMAPISampleDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

CIMAPISampleDlg::~CIMAPISampleDlg()
{
}

void CIMAPISampleDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_FORMATS_LIST, m_listFormats);
	DDX_Control(pDX, IDC_DRIVES_LIST, m_listDrives);
	DDX_Control(pDX, IDC_FORMAT_INFO, m_formatInfo);
	DDX_Control(pDX, IDC_DRIVE_INFO, m_driveInfo);
}

BEGIN_MESSAGE_MAP(CIMAPISampleDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_LBN_SELCHANGE(IDC_FORMATS_LIST, OnLbnSelchangeFormatsList)
	ON_LBN_SELCHANGE(IDC_DRIVES_LIST, OnLbnSelchangeDrivesList)
	ON_BN_CLICKED(IDC_REFRESH_INFO, OnBnClickedRefreshInfo)
	ON_BN_CLICKED(IDC_OPEN_EXCLUSIVE, OnBnClickedOpenExclusive)
	ON_BN_CLICKED(IDC_EJECT, OnBnClickedEject)
	ON_BN_CLICKED(IDC_ERASE, OnBnClickedErase)
	ON_BN_CLICKED(IDC_QUERY_MEDIA_INFO, OnBnClickedQueryMediaInfo)
	ON_BN_CLICKED(IDC_QUERY_MEDIA_TYPE, OnBnClickedQueryMediaType)
	ON_BN_CLICKED(IDC_CREATE_CD, OnBnClickedCreateCD)
END_MESSAGE_MAP()


// CIMAPISampleDlg message handlers

BOOL CIMAPISampleDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
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

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	HRESULT hr = m_dm.Open();
	ATLASSERT( SUCCEEDED( hr ) );

	UpdateFormatsList();
	UpdateDriveList();
	UpdateDriveFormatInfo();

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CIMAPISampleDlg::OnSysCommand(UINT nID, LPARAM lParam)
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

void CIMAPISampleDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CIMAPISampleDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CIMAPISampleDlg::UpdateFormatsList()
{
	HRESULT hr;
	IID iid, iidActive;

	m_listFormats.ResetContent();

	HRESULT hrActive = m_dm.GetActiveDiscMasterFormat( &iidActive );
	hr = m_dm.GetFirstDiscMasterFormat( &iid );
	while( hr == S_OK )
	{
		int index;
		if( iid == __uuidof( IJolietDiscMaster ) )
			index = m_listFormats.AddString( L"Joliet (data CD)" );
		else if( iid == __uuidof( IRedbookDiscMaster ) )
			index = m_listFormats.AddString( L"Redbook (audio CD)" );
		else
		{
			CString cs;
			LPOLESTR lpsz = NULL;
			StringFromIID( iid, &lpsz );
			cs.Format( L"Unknown (%s)", lpsz );
			CoTaskMemFree( lpsz );
			index = m_listFormats.AddString( cs );
		}

		if( SUCCEEDED( hrActive ) && ( iid == iidActive ) )
			m_listFormats.SetCurSel( index );

		hr = m_dm.GetNextDiscMasterFormat( &iid );
	}
}

void CIMAPISampleDlg::UpdateDriveList()
{
	IID iidActive;

	m_listDrives.ResetContent();

	HRESULT hr;
	HRESULT hrActive = m_dm.GetActiveDiscMasterFormat( &iidActive );
	if( SUCCEEDED( hrActive ) )
	{
		CDiscRecorder drec;
		CString strActiveID;
		if( m_dm.IsDiscRecorderActive() )
		{
			CComBSTR bstrVendorID, bstrProductID, bstrRevision, bstrPath;
			hr = m_dm.GetDisplayNames( &bstrVendorID, &bstrProductID, &bstrRevision );
			ATLASSERT( SUCCEEDED( hr ) );
			hr = m_dm.GetPath( &bstrPath );
			ATLASSERT( SUCCEEDED( hr ) );
			strActiveID.Format( L"%s {%s, %s, %s}", bstrPath, bstrVendorID, bstrProductID, bstrRevision );
		}
		hr = m_dm.GetFirstDiscRecorder( drec );
		while( hr == S_OK )
		{
			CComBSTR bstrVendorID, bstrProductID, bstrRevision, bstrPath;
			hr = drec.GetDisplayNames( &bstrVendorID, &bstrProductID, &bstrRevision );
			ATLASSERT( SUCCEEDED( hr ) );
			hr = drec.GetPath( &bstrPath );
			ATLASSERT( SUCCEEDED( hr ) );

			CString strID;
			strID.Format( L"%s {%s, %s, %s}", bstrPath, bstrVendorID, bstrProductID, bstrRevision );
			int index = m_listDrives.AddString( strID );
			if( strActiveID == strID )
				m_listDrives.SetCurSel( index );
			hr = m_dm.GetNextDiscRecorder( drec );
		}
	}
	else
		m_dm.ReleaseRecorder();
}

void CIMAPISampleDlg::UpdateDriveFormatInfo()
{
	HRESULT hr;
	IID iidActive;

	m_formatInfo.SetWindowText( L"" );
	m_driveInfo.SetWindowText( L"" );

	CString csFormatInfo, csDriveInfo;

	hr = m_dm.GetActiveDiscMasterFormat( &iidActive );
	if( FAILED( hr ) )
		return;

	if( iidActive == IID_IJolietDiscMaster )
	{
		long nTotal, nUsed, nSize;
		hr = m_dm.GetTotalDataBlocks( &nTotal );
		ATLASSERT( SUCCEEDED( hr ) );
		hr = m_dm.GetUsedDataBlocks( &nUsed );
		ATLASSERT( SUCCEEDED( hr ) );
		hr = m_dm.GetDataBlockSize( &nSize );
		ATLASSERT( SUCCEEDED( hr ) );
		csFormatInfo.Format( 
			L"Total data blocks: %d\r\n"
			L"Used data blocks: %d\r\n"
			L"Data block size: %d\r\n",
			nTotal, nUsed, nSize );
	}
	else if( iidActive == IID_IRedbookDiscMaster )
	{
		long nTracks, nBlocks, nUsedBlocks, nAvailableTrackBlocks, nBlockSize;
		hr = m_dm.GetAudioBlockSize( &nBlockSize );
		ATLASSERT( SUCCEEDED( hr ) );
		hr = m_dm.GetAvailableAudioTrackBlocks( &nAvailableTrackBlocks );
		ATLASSERT( SUCCEEDED( hr ) );
		hr = m_dm.GetTotalAudioBlocks( &nBlocks );
		ATLASSERT( SUCCEEDED( hr ) );
		hr = m_dm.GetTotalAudioTracks( &nTracks );
		ATLASSERT( SUCCEEDED( hr ) );
		hr = m_dm.GetUsedAudioBlocks( &nUsedBlocks );
		ATLASSERT( SUCCEEDED( hr ) );
		csFormatInfo.Format( 
			L"Total Audio Tracks: %d\r\n"
			L"Total Audio Blocks: %d\r\n"
			L"Used Audio Blocks: %d\r\n"
			L"Available Audio Track Blocks: %d\r\n"
			L"Audio Block Size: %d\r\n",
			nTracks, nBlocks, nUsedBlocks, nAvailableTrackBlocks, nBlockSize );
	}
	else
	{
		csFormatInfo = L"Unknown format!";
	}

	m_formatInfo.SetWindowText( csFormatInfo );

	if( ! m_dm.IsDiscRecorderActive() )
		return;

	long fType = 0;
	ULONG ulStateFlags = 0;

	hr = m_dm.GetRecorderType( &fType );
	ATLASSERT( SUCCEEDED( hr ) );
	hr = m_dm.GetRecorderState( &ulStateFlags );
	ATLASSERT( SUCCEEDED( hr ) );


	TCHAR *pszRecorderType, *pszRecorderState;

	switch( fType )
	{
	case RECORDER_CDR:
		pszRecorderType = L"RECORDER_CDR";
		break;
	case RECORDER_CDRW:
		pszRecorderType = L"RECORDER_CDRW";
		break;
	default:
		pszRecorderType = L"";
	}

	switch( ulStateFlags )
	{
	case RECORDER_DOING_NOTHING:
		pszRecorderState = L"RECORDER_DOING_NOTHING";
		break;
	case RECORDER_OPENED:
		pszRecorderState = L"RECORDER_OPENED";
		break;
	case RECORDER_BURNING:
		pszRecorderState = L"RECORDER_BURNING";
		break;
	default:
		pszRecorderState = L"";
	}

	csDriveInfo.Format(
		L"Recorder type: %s\r\n"
		L"Recorder state: %s\r\n",
		pszRecorderType,
		pszRecorderState );

	STATPROPSTG propstg;
	hr = m_dm.RecorderProperties_GetFirst( &propstg );
	if( hr == S_OK )
		csDriveInfo += L"\r\nProperties:\r\n";
	while( hr == S_OK )
	{
		CString csProperty;
		PROPVARIANT propval;
		propval.vt = VT_EMPTY;
		hr = m_dm.RecorderProperties_Read( propstg.propid, &propval );
		if( hr == S_OK )
		{
			csProperty.Format( 
				L"ID: %d, Name: %s, Type: %s, Value: %s\r\n",
				propstg.propid,
				propstg.lpwstrName ? propstg.lpwstrName : L"",
				GetVariantType( propstg.vt ),
				GetVariantValue( propval ) );
			ATLASSERT( propval.vt != VT_BSTR );
		}
		else
		{
			csProperty.Format( 
				L"ID: %d, Name: %s, Type: %s\r\n",
				propstg.propid,
				propstg.lpwstrName ? propstg.lpwstrName : L"",
				GetVariantType( propstg.vt ) );
		}
		csDriveInfo += csProperty;

		if( propstg.lpwstrName )
			CoTaskMemFree( propstg.lpwstrName );

		hr = m_dm.RecorderProperties_GetNext( &propstg );
	}

	m_driveInfo.SetWindowText( csDriveInfo );
}

#if 0
	IDiscMasterProgressEventsImpl *pEvents = new IDiscMasterProgressEventsImpl;
	ATLASSERT( pEvents != NULL );

	/*
	CComObject<IDiscMasterProgressEventsImpl> *lpComObject = NULL;
	CComPtr<IDiscMasterProgressEvents> lpIDiscMasterProgressEvents;

	hr = CComObject<IDiscMasterProgressEventsImpl>::CreateInstance( &lpComObject );
	ATLASSERT( SUCCEEDED( hr ) );

	hr = lpComObject->Init();
	ATLASSERT( SUCCEEDED( hr ) );

	hr = lpComObject->QueryInterface( &lpIDiscMasterProgressEvents );
	ATLASSERT( SUCCEEDED( hr ) );
	*/

	UINT_PTR nCookie;
	hr = dm.ProgressAdvise( pEvents, &nCookie );
//	hr = dm.ProgressAdvise( lpIDiscMasterProgressEvents, &nCookie );
	ATLASSERT( SUCCEEDED( hr ) );

	pEvents->Release();
}
#endif


void CIMAPISampleDlg::OnLbnSelchangeFormatsList()
{
	int index = m_listFormats.GetCurSel();
	if( index != LB_ERR )
	{
		CString strActiveFormat;
		m_listFormats.GetText( index, strActiveFormat );

		if( strActiveFormat == L"Redbook (audio CD)" )
		{
			m_dm.SetActiveDiscMasterFormat( IID_IRedbookDiscMaster );
		}
		else if( strActiveFormat == L"Joliet (data CD)" )
		{
			m_dm.SetActiveDiscMasterFormat( IID_IJolietDiscMaster );
		}
		else
		{
			ATLASSERT( FALSE );
			return;
		}

		UpdateDriveList();
		UpdateDriveFormatInfo();
	}
}

void CIMAPISampleDlg::OnLbnSelchangeDrivesList()
{
	int index = m_listDrives.GetCurSel();
	if( index != LB_ERR )
	{
		CString strActiveID;
		m_listDrives.GetText( index, strActiveID );
		CDiscRecorder drec;
		HRESULT hr = m_dm.GetFirstDiscRecorder( drec );
		while( hr == S_OK )
		{
			CComBSTR bstrVendorID, bstrProductID, bstrRevision, bstrPath;
			hr = drec.GetDisplayNames( &bstrVendorID, &bstrProductID, &bstrRevision );
			ATLASSERT( SUCCEEDED( hr ) );
			hr = drec.GetPath( &bstrPath );
			ATLASSERT( SUCCEEDED( hr ) );

			CString strID;
			strID.Format( L"%s {%s, %s, %s}", bstrPath, bstrVendorID, bstrProductID, bstrRevision );
			if( strID == strActiveID )
			{
				m_dm.ReleaseRecorder();
				hr = m_dm.SetActiveDiscRecorder( drec );
				ATLASSERT( SUCCEEDED( hr ) );
				break;
			}
			hr = m_dm.GetNextDiscRecorder( drec );
		}
	}
	UpdateDriveFormatInfo();
}

void CIMAPISampleDlg::OnBnClickedRefreshInfo()
{
	UpdateDriveFormatInfo();
}

void CIMAPISampleDlg::OnBnClickedOpenExclusive()
{
	CString csCaption;
	GetDlgItemText( IDC_OPEN_EXCLUSIVE, csCaption );
	if( csCaption == L"Open Exclusive" )
	{
		HRESULT hr = m_dm.OpenExclusive();
		if( FAILED( hr ) )
		{
			if( hr == IMAPI_E_DEVICE_NOTACCESSIBLE )
			{
				MessageBox( L"Another application or IMAPI engine has reserved the active disc recorder. Try again later." );
			}
			else if( hr == IMAPI_E_DEVICE_NOTPRESENT )
			{
				MessageBox( L"The currently active disc recorder has been invalidated because the device was removed from the system." );
				m_dm.ReleaseRecorder();
			}
			else
			{
				MessageBox( L"Unknown error!" );
			}
			return;
		}
		SetDlgItemText( IDC_OPEN_EXCLUSIVE, L"Close" );
		GetDlgItem( IDC_EJECT )->EnableWindow( TRUE );
		GetDlgItem( IDC_ERASE )->EnableWindow( TRUE );
		GetDlgItem( IDC_QUERY_MEDIA_INFO )->EnableWindow( TRUE );
		GetDlgItem( IDC_QUERY_MEDIA_TYPE )->EnableWindow( TRUE );
	}
	else
	{
		HRESULT hr = m_dm.CloseExclusive();
		ATLASSERT( SUCCEEDED( hr ) );
		SetDlgItemText( IDC_OPEN_EXCLUSIVE, L"Open Exclusive" );
		GetDlgItem( IDC_EJECT )->EnableWindow( FALSE );
		GetDlgItem( IDC_ERASE )->EnableWindow( FALSE );
		GetDlgItem( IDC_QUERY_MEDIA_INFO )->EnableWindow( FALSE );
		GetDlgItem( IDC_QUERY_MEDIA_TYPE )->EnableWindow( FALSE );
	}
}

void CIMAPISampleDlg::OnBnClickedEject()
{
	HRESULT hr = m_dm.Eject();
	ATLASSERT( SUCCEEDED( hr ) );
}

void CIMAPISampleDlg::OnBnClickedErase()
{
	HRESULT hr;
	int i = MessageBox( L"Perform Full Erase?", L"Erase", MB_YESNOCANCEL | MB_ICONQUESTION | MB_DEFBUTTON2 );
	if( i == IDYES )
		hr = m_dm.Erase( true );
	else if( i == IDNO )
		hr = m_dm.Erase( false );
	else
		return;
	ATLASSERT( SUCCEEDED( hr ) );
	MessageBox( L"Disk erased!" );
}

void CIMAPISampleDlg::OnBnClickedQueryMediaInfo()
{
	HRESULT hr;
	CString csMediaInfo;
	byte pbsessions = 0;
	byte pblasttrack = 0;
	ULONG ulstartaddress = 0;
	ULONG ulnextwritable = 0;
	ULONG ulfreeblocks = 0;
	hr = m_dm.QueryMediaInfo( &pbsessions, &pblasttrack, &ulstartaddress, &ulnextwritable, &ulfreeblocks );
	ATLASSERT( SUCCEEDED( hr ) );
	csMediaInfo.Format(
		L"Sessions on the disc: %d\r\n"
		L"Last track of the previous session: %d\r\n"
		L"Start address of the last track: %d\r\n"
		L"Next writable address: %d\r\n"
		L"Free blocks: %d\r\n",
		pbsessions,
		pblasttrack,
		ulstartaddress,
		ulnextwritable,
		ulfreeblocks );
	MessageBox( csMediaInfo, L"Media info:" );
}

void CIMAPISampleDlg::OnBnClickedQueryMediaType()
{
	HRESULT hr;
	CString csMediaType;
	TCHAR *pszMediaType, *pszMediaFlags;
	long fMediaType = 0;
	long fMediaFlags = 0;
	hr = m_dm.QueryMediaType( &fMediaType, &fMediaFlags );
	ATLASSERT( SUCCEEDED( hr ) );
	switch( fMediaType )
	{
	case MEDIA_CDDA_CDROM:
		pszMediaType = L"MEDIA_CDDA_CDROM";
		break;
	case MEDIA_CD_ROM_XA:
		pszMediaType = L"MEDIA_CD_ROM_XA";
		break;
	case MEDIA_CD_I:
		pszMediaType = L"MEDIA_CD_I";
		break;
	case MEDIA_CD_EXTRA:
		pszMediaType = L"MEDIA_CD_EXTRA";
		break;
	case MEDIA_CD_OTHER:
		pszMediaType = L"MEDIA_CD_OTHER";
		break;
	case MEDIA_SPECIAL:
		pszMediaType = L"MEDIA_SPECIAL";
		break;
	default:
		pszMediaType = L"";
	}
	switch( fMediaFlags )
	{
	case MEDIA_BLANK:
		pszMediaFlags = L"MEDIA_BLANK";
		break;
	case MEDIA_RW:
		pszMediaFlags = L"MEDIA_RW";
		break;
	case MEDIA_WRITABLE:
		pszMediaFlags = L"MEDIA_WRITABLE";
		break;
	default:
		pszMediaFlags = L"";
	};
	csMediaType.Format(
		L"Media type: %s\r\n"
		L"Media flags: %s\r\n",
		pszMediaType,
		pszMediaFlags );

	MessageBox( csMediaType, L"Media type:" );
}

void CIMAPISampleDlg::OnBnClickedCreateCD()
{
	IID iid;
	HRESULT hr = m_dm.GetActiveDiscMasterFormat( &iid );
	if( FAILED(hr) )
		return;

	if( iid == IID_IJolietDiscMaster )
	{
		CCreateJolietDiskDlg dlg( m_dm, this );
		dlg.DoModal();
	}
	else
	{
		CCreateRedbookDiskDlg dlg( m_dm, this );
		dlg.DoModal();
	}
}

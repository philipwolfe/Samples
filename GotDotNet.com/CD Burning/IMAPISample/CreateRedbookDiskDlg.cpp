// CreateRedbookDiskDlg.cpp : implementation file
//

#include "stdafx.h"
#include "IMAPISample.h"
#include "CreateRedbookDiskDlg.h"


// CCreateRedbookDiskDlg dialog

IMPLEMENT_DYNAMIC(CCreateRedbookDiskDlg, CDialog)
CCreateRedbookDiskDlg::CCreateRedbookDiskDlg( CDiscMaster& dm, CWnd* pParent /*=NULL*/)
	: CDialog(CCreateRedbookDiskDlg::IDD, pParent), m_dm( dm )
{
}

CCreateRedbookDiskDlg::~CCreateRedbookDiskDlg()
{
}

void CCreateRedbookDiskDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_TRACKS_LIST, m_tracksList);
}

BOOL CCreateRedbookDiskDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	//m_fileList;
	int n;
	n = m_tracksList.InsertColumn( 0, L"No.", LVCFMT_LEFT, 40, 0 );
	ATLASSERT ( n != -1 );
	n = m_tracksList.InsertColumn( 1, L"File", LVCFMT_LEFT, 408, 1 );
	ATLASSERT ( n != -1 );
	n = m_tracksList.InsertColumn( 2, L"Time", LVCFMT_LEFT, 70, 2 );
	ATLASSERT ( n != -1 );

	return TRUE;  // return TRUE  unless you set the focus to a control
}


BEGIN_MESSAGE_MAP(CCreateRedbookDiskDlg, CDialog)
	ON_BN_CLICKED(IDOK, OnBnClickedOk)
	ON_BN_CLICKED(IDC_ADD_TRACK, OnBnClickedAddTrack)
	ON_BN_CLICKED(IDC_DELETE_TRACK, OnBnClickedDeleteTrack)
	ON_BN_CLICKED(IDC_MOVE_UP, OnBnClickedMoveUp)
	ON_BN_CLICKED(IDC_MOVE_DOWN, OnBnClickedMoveDown)
	ON_BN_CLICKED(IDC_BURN, OnBnClickedBurn)
	ON_NOTIFY(LVN_ITEMCHANGED, IDC_TRACKS_LIST, OnLvnItemchangedTracksList)
END_MESSAGE_MAP()


// CCreateRedbookDiskDlg message handlers

void CCreateRedbookDiskDlg::OnBnClickedOk()
{
	// TODO: Add your control notification handler code here
	//OnOK();
}

// Sort the item in reverse alphabetical order.
static int CALLBACK 
MyCompareProc(LPARAM lParam1, LPARAM lParam2, LPARAM lParamSort)
{
	if( lParam1 < lParam2 )
		return -1;
	else if( lParam1 > lParam2 )
		return 1;
	else
		return 0;
	/*
   // lParamSort contains a pointer to the list view control.
   CListCtrl* pListCtrl = (CListCtrl*) lParamSort;
   CString    strItem1 = pListCtrl->GetItemText((int)lParam1, 0);
   CString    strItem2 = pListCtrl->GetItemText((int)lParam2, 0);

   return strItem1.Compare( strItem2 );
   */
}

void CCreateRedbookDiskDlg::OnBnClickedAddTrack()
{
	static TCHAR BASED_CODE szFilter[] = L"WAV Files (*.wav)|*.wav|All Files (*.*)|*.*||";
	CFileDialog dlg( 
		TRUE, 
		L"wav", 
		NULL, 
		OFN_ALLOWMULTISELECT | OFN_EXPLORER | OFN_FILEMUSTEXIST | OFN_PATHMUSTEXIST,
		szFilter,
		this );

	if( dlg.DoModal() == IDCANCEL )
		return;

	POSITION pos = dlg.GetStartPosition();
	while( pos )
	{
		CString csPath = dlg.GetNextPathName( pos );
		CFile file;
		if( ! file.Open( csPath, CFile::modeRead ) )
		{
			CString msg;
			msg.Format( L"Unable to open file %s", csPath );
			MessageBox( msg, L"Error!" );
			continue;
		}

		struct RIFFChunk
		{
			char riff[4];
			unsigned long	length;
			char wave[4];
		} riffChunk;

		struct FormatChunk
		{
			char fmt_[4];
			unsigned int length;
			unsigned short reserved;
			unsigned short channels;
			unsigned long  sampleRate;
			unsigned long  bytesPerSecond;
			unsigned short bytesPerSample;
			unsigned short bitsPerSample;
		} formatChunk;

		struct DataChunk
		{
			char data[4];
			unsigned long length;
		} dataChunk;

		UINT nRead = file.Read( &riffChunk, sizeof( riffChunk ) );
		if( nRead != sizeof( riffChunk ) )
		{
			MessageBox( L"Error while reading wav file!", L"Error!" );
			continue;
		}

		if( strnicmp( riffChunk.riff, "riff", 4 ) != 0 )
		{
			MessageBox( L"Not a valid wav file!", L"Error!" );
			continue;
		}

		if( strnicmp( riffChunk.wave, "wave", 4 ) != 0 )
		{
			MessageBox( L"Not a valid wav file!", L"Error!" );
			continue;
		}

		nRead = file.Read( &formatChunk, sizeof( formatChunk ) );
		if( nRead != sizeof( formatChunk ) )
		{
			MessageBox( L"Error while reading wav file!", L"Error!" );
			continue;
		}

		if( strnicmp( formatChunk.fmt_, "fmt", 3 ) != 0 )
		{
			MessageBox( L"Not a valid wav file!", L"Error!" );
			continue;
		}
		if( formatChunk.length > 0x10 )
		{
			char b;
			for( unsigned int j = 0; j < ( formatChunk.length - 0x10 ); j++ )
			{
				nRead = file.Read( &b, 1 );
				if( nRead != 1 )
				{
					MessageBox( L"Not a valid wav file!", L"Error!" );
					goto CONTINUE;
				}
			}

		}
		if( formatChunk.channels != 0x02 )
		{
			MessageBox( L"This is a mono file; only stereo files are accepted!", L"Error!" );
			continue;
		}
		if( formatChunk.sampleRate != 44100 )
		{
			CString msg;
			msg.Format( L"File sample rate is: %d;  Only sample rate 44100 is accepted!" );
			MessageBox( msg, L"Error!" );
			continue;
		}

		while( true )
		{
			nRead = file.Read( &dataChunk, sizeof( dataChunk ) );
			if( nRead != sizeof( dataChunk ) )
			{
				MessageBox( L"Error while reading wav file!", L"Error!" );
				goto CONTINUE;
			}

			if( strnicmp( dataChunk.data, "data", 4 ) == 0 )
				break;

			ATLTRACE( "Unknown chunk %c%c%c%c\n", dataChunk.data[0], dataChunk.data[1], dataChunk.data[2], dataChunk.data[3] );

			unsigned long i = 0;
			while( i < dataChunk.length )
			{
				char buffer[16];
				unsigned long nToRead = 16;
				if( nToRead > ( dataChunk.length - i ) )
					nToRead = ( dataChunk.length - i );

				nRead = file.Read( buffer, nToRead );
				if( nRead != nToRead )
				{
					MessageBox( L"Error while reading wav file!", L"Error!" );
					goto CONTINUE;
				}

				i += nRead;
			}
		}

		{
			unsigned long minutes = 0;
			unsigned long seconds = 0;

			if( formatChunk.bytesPerSecond != 0 )
			{
				unsigned long nTime = dataChunk.length / formatChunk.bytesPerSecond;
				minutes = nTime / 60;
				seconds = nTime % 60;
			}

			CString csItem;
			LVITEM item;

			csItem.Format( L"%d", m_tracksList.GetItemCount() + 1 );
			item.mask = LVIF_TEXT | LVIF_PARAM;
			item.iItem = m_tracksList.GetItemCount();
			item.iSubItem = 0;
			item.pszText = const_cast<TCHAR*>((LPCTSTR)csItem);
			item.lParam = m_tracksList.GetItemCount();
			int n = m_tracksList.InsertItem( &item );
			ATLASSERT( n != -1 );
			m_tracksList.SetItemData( n, (DWORD_PTR)m_tracksList.GetItemCount() + 1 );

			item.mask = LVIF_TEXT;
			item.iItem = n;
			item.iSubItem = 1;
			item.pszText = const_cast<TCHAR*>((LPCTSTR)csPath);
			int m = m_tracksList.SetItem( &item );
			ATLASSERT( m != -1 );

			csItem.Format( L"%d:%02d", minutes, seconds );
			item.mask = LVIF_TEXT;
			item.iItem = n;
			item.iSubItem = 2;
			item.pszText = const_cast<TCHAR*>((LPCTSTR)csItem);
			m = m_tracksList.SetItem( &item );
			ATLASSERT( m != -1 );
		}
CONTINUE:;
	}
}

void CCreateRedbookDiskDlg::OnBnClickedDeleteTrack()
{
	if( m_tracksList.GetSelectedCount() == 0 )
		return;

	while( m_tracksList.GetSelectedCount() != 0 )
	{
		POSITION pos = m_tracksList.GetFirstSelectedItemPosition();
		int nIndex = m_tracksList.GetNextSelectedItem( pos );
		m_tracksList.DeleteItem( nIndex );
	}

	for( int nIndex = 0; nIndex < m_tracksList.GetItemCount(); nIndex++ )
	{
		CString csID;
		csID.Format( L"%d", nIndex + 1 );
		m_tracksList.SetItemText( nIndex, 0, csID );
		m_tracksList.SetItemData( nIndex, nIndex );
	}
}

void CCreateRedbookDiskDlg::OnBnClickedMoveUp()
{
	if( m_tracksList.GetSelectedCount() != 1 )
		return;

	POSITION pos = m_tracksList.GetFirstSelectedItemPosition();
	int nIndex = m_tracksList.GetNextSelectedItem( pos );
	if( nIndex == 0 )
		return;

	CString csID = m_tracksList.GetItemText( nIndex, 0 );
	CString csPrevID = m_tracksList.GetItemText( nIndex - 1, 0 );

	m_tracksList.SetItemText( nIndex - 1, 0, csID );
	m_tracksList.SetItemData( nIndex - 1, nIndex + 1 );
	m_tracksList.SetItemText( nIndex, 0, csPrevID );
	m_tracksList.SetItemData( nIndex, nIndex );

	BOOL r = m_tracksList.SortItems(MyCompareProc, (LPARAM)&m_tracksList );
	ATLASSERT( r );

	UpdateButtons();
}

void CCreateRedbookDiskDlg::OnBnClickedMoveDown()
{
	if( m_tracksList.GetSelectedCount() != 1 )
		return;

	POSITION pos = m_tracksList.GetFirstSelectedItemPosition();
	int nIndex = m_tracksList.GetNextSelectedItem( pos );
	if( nIndex == ( m_tracksList.GetItemCount() - 1 ) )
		return;

	CString csID = m_tracksList.GetItemText( nIndex, 0 );
	CString csNextID = m_tracksList.GetItemText( nIndex + 1, 0 );

	m_tracksList.SetItemText( nIndex, 0, csNextID );
	m_tracksList.SetItemData( nIndex, nIndex + 2 );
	m_tracksList.SetItemText( nIndex + 1, 0, csID );
	m_tracksList.SetItemData( nIndex + 1, nIndex + 1 );

	BOOL r = m_tracksList.SortItems(MyCompareProc, (LPARAM)&m_tracksList );
	ATLASSERT( r );

	UpdateButtons();
}

void CCreateRedbookDiskDlg::OnBnClickedBurn()
{
	HRESULT hr;
	for( int i = 0; i < m_tracksList.GetItemCount(); i++ )
	{
		CString csPath = m_tracksList.GetItemText( i, 1 );

		CFile file;
		if( ! file.Open( csPath, CFile::modeRead ) )
		{
			CString msg;
			msg.Format( L"Unable to open file %s", csPath );
			MessageBox( msg, L"Error!" );
			return;
		}

		struct RIFFChunk
		{
			char riff[4];
			unsigned long	length;
			char wave[4];
		} riffChunk;

		struct DataChunk
		{
			char data[4];
			unsigned long length;
		} dataChunk;

		UINT nRead = file.Read( &riffChunk, sizeof( riffChunk ) );
		if( nRead != sizeof( riffChunk ) )
		{
			MessageBox( L"Error while reading wav file!", L"Error!" );
			return;
		}

		if( strnicmp( riffChunk.riff, "riff", 4 ) != 0 )
		{
			MessageBox( L"Not a valid wav file!", L"Error!" );
			return;
		}

		if( strnicmp( riffChunk.wave, "wave", 4 ) != 0 )
		{
			MessageBox( L"Not a valid wav file!", L"Error!" );
			return;
		}

		while( true )
		{
			nRead = file.Read( &dataChunk, sizeof( dataChunk ) );
			if( nRead != sizeof( dataChunk ) )
			{
				MessageBox( L"Error while reading wav file!", L"Error!" );
				return;
			}

			if( strnicmp( dataChunk.data, "data", 4 ) == 0 )
				break;

			ATLTRACE( "Skipping chunk: '%c%c%c%c'\n", dataChunk.data[0], dataChunk.data[1], dataChunk.data[2], dataChunk.data[3] );

			unsigned long i = 0;
			while( i < dataChunk.length )
			{
				char buffer[16];
				unsigned long nToRead = 16;
				if( nToRead > ( dataChunk.length - i ) )
					nToRead = ( dataChunk.length - i );

				nRead = file.Read( buffer, nToRead );
				if( nRead != nToRead )
				{
					MessageBox( L"Error while reading wav file!", L"Error!" );
					return;
				}

				i += nRead;
			}
		}

		long nBlocksCount = dataChunk.length / 2352;
		if( dataChunk.length % 2352 )
			nBlocksCount++;
		
		hr = m_dm.CreateAudioTrack( nBlocksCount );
		ATLASSERT( SUCCEEDED( hr ) );

		byte blocks[2352];
		for( int k = 0; k < nBlocksCount; k++ )
		{
			memset( blocks, 0, 2352 );
			unsigned long nToRead = 2352;
            if( k == ( nBlocksCount - 1 ) )
				nToRead = dataChunk.length % 2352;

			nRead = file.Read( blocks, nToRead );
			if( nRead != nToRead )
			{
				MessageBox( L"Error while reading wav file!", L"Error!" );
				return;
			}

			hr = m_dm.AddAudioTrackBlocks( blocks, 2352 );
			ATLASSERT( SUCCEEDED( hr ) );
		}

		hr = m_dm.CloseAudioTrack();
		ATLASSERT( SUCCEEDED( hr ) );
	}
	hr = m_dm.RecordDisc( false, true );
	ATLASSERT( SUCCEEDED( hr ) );
}

void CCreateRedbookDiskDlg::OnLvnItemchangedTracksList(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMLISTVIEW pNMLV = reinterpret_cast<LPNMLISTVIEW>(pNMHDR);
	// TODO: Add your control notification handler code here
	*pResult = 0;

	UpdateButtons();
}

void CCreateRedbookDiskDlg::UpdateButtons()
{
	if( m_tracksList.GetSelectedCount() == 0 )
	{
		GetDlgItem( IDC_DELETE_TRACK )->EnableWindow( FALSE );
		GetDlgItem( IDC_MOVE_UP )->EnableWindow( FALSE );
		GetDlgItem( IDC_MOVE_DOWN )->EnableWindow( FALSE );
	}
	else if( m_tracksList.GetSelectedCount() == 1 )
	{
		POSITION pos = m_tracksList.GetFirstSelectedItemPosition();
		int nIndex = m_tracksList.GetNextSelectedItem( pos );

		if( nIndex != 0 )
			GetDlgItem( IDC_MOVE_UP )->EnableWindow( TRUE );
		else
			GetDlgItem( IDC_MOVE_UP )->EnableWindow( FALSE );

		if( nIndex != ( m_tracksList.GetItemCount() - 1 ) )
			GetDlgItem( IDC_MOVE_DOWN )->EnableWindow( TRUE );
		else
			GetDlgItem( IDC_MOVE_DOWN )->EnableWindow( FALSE );

		GetDlgItem( IDC_DELETE_TRACK )->EnableWindow( TRUE );
	}
	else
	{
		GetDlgItem( IDC_DELETE_TRACK )->EnableWindow( TRUE );
		GetDlgItem( IDC_MOVE_UP )->EnableWindow( FALSE );
		GetDlgItem( IDC_MOVE_DOWN )->EnableWindow( FALSE );
	}
}

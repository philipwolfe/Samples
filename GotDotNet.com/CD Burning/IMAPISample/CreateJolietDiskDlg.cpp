// CreateJolietDiskDlg.cpp : implementation file
//

#include "stdafx.h"
#include "IMAPISample.h"
#include "CreateJolietDiskDlg.h"
#include "EnterVariantDlg.h"

// CCreateJolietDiskDlg dialog

IMPLEMENT_DYNAMIC(CCreateJolietDiskDlg, CDialog)
CCreateJolietDiskDlg::CCreateJolietDiskDlg(CDiscMaster& dm, CWnd* pParent /*=NULL*/)
	: CDialog(CCreateJolietDiskDlg::IDD, pParent), m_dm(dm)
{
}

CCreateJolietDiskDlg::~CCreateJolietDiskDlg()
{
}

void CCreateJolietDiskDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_FOLDER_TREE, m_folderTree);
	DDX_Control(pDX, IDC_FILE_LIST, m_fileList);
	DDX_Control(pDX, IDC_PROPERTY_LIST, m_propertyList);
}


BEGIN_MESSAGE_MAP(CCreateJolietDiskDlg, CDialog)
	ON_BN_CLICKED(IDC_NEW_FOLDER, OnBnClickedNewFolder)
	ON_BN_CLICKED(IDC_DELETE_FOLDER, OnBnClickedDeleteFolder)
	ON_BN_CLICKED(IDC_RENAME_FOLDER, OnBnClickedRenameFolder)
	ON_NOTIFY(TVN_ENDLABELEDIT, IDC_FOLDER_TREE, OnTvnEndlabeleditFolderTree)
	ON_BN_CLICKED(IDOK, OnBnClickedOk)
	ON_NOTIFY(TVN_SELCHANGING, IDC_FOLDER_TREE, OnTvnSelchangingFolderTree)
	ON_NOTIFY(TVN_BEGINLABELEDIT, IDC_FOLDER_TREE, OnTvnBeginlabeleditFolderTree)
	ON_BN_CLICKED(IDC_ADD_FILES, OnBnClickedAddFiles)
	ON_BN_CLICKED(IDC_REMOVE_FILES, OnBnClickedRemoveFiles)
	ON_BN_CLICKED(IDC_RENAME_FILE, OnBnClickedRenameFile)
	ON_NOTIFY(LVN_ODSTATECHANGED, IDC_FILE_LIST, OnLvnOdstatechangedFileList)
	ON_NOTIFY(LVN_ENDLABELEDIT, IDC_FILE_LIST, OnLvnEndlabeleditFileList)
	ON_BN_CLICKED(IDC_BURN, OnBnClickedBurn)
	ON_NOTIFY(LVN_ITEMCHANGED, IDC_PROPERTY_LIST, OnLvnItemchangedPropertyList)
	ON_BN_CLICKED(IDC_EDIT_PROPERTY, OnBnClickedEditProperty)
END_MESSAGE_MAP()


// CCreateJolietDiskDlg message handlers

BOOL CCreateJolietDiskDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	//m_fileList;
	int n;
	n = m_propertyList.InsertColumn( 0, L"ID", LVCFMT_LEFT, 30, 0 );
	ATLASSERT ( n != -1 );
	n = m_propertyList.InsertColumn( 1, L"Name", LVCFMT_LEFT, 180, 1 );
	ATLASSERT ( n != -1 );
	n = m_propertyList.InsertColumn( 2, L"Type", LVCFMT_LEFT, 70, 2 );
	ATLASSERT ( n != -1 );
	n = m_propertyList.InsertColumn( 3, L"Value", LVCFMT_LEFT, 230, 3 );
	ATLASSERT ( n != -1 );

	n = m_fileList.InsertColumn( 0, L"Filename", LVCFMT_LEFT, 107, 0 );
	ATLASSERT ( n != -1 );
	n = m_fileList.InsertColumn( 1, L"Path", LVCFMT_LEFT, 150, 1 );
	ATLASSERT ( n != -1 );

	STATPROPSTG propstg;
	HRESULT hr = m_dm.JolietProperties_GetFirst( &propstg );
	int nItemCount = 0;
	while( hr == S_OK )
	{
		int m;
		CString csTemp;
		LVITEM item;
		item.mask = LVIF_TEXT;
		item.iItem = nItemCount;
		item.iSubItem = 0;
		csTemp.Format( L"%d", propstg.propid );
		item.pszText = const_cast<TCHAR*>((LPCTSTR)csTemp);

		n = m_propertyList.InsertItem( &item );
		ATLASSERT( n != -1 );

		item.mask = LVIF_TEXT;
		item.iItem = n;
		item.iSubItem = 1;
		csTemp.Format( L"%s", propstg.lpwstrName ? propstg.lpwstrName : L"" );
		item.pszText = const_cast<TCHAR*>((LPCTSTR)csTemp);
		m = m_propertyList.SetItem( &item );
		ATLASSERT( m != -1 );

		item.mask = LVIF_TEXT;
		item.iItem = n;
		item.iSubItem = 2;
		csTemp = GetVariantType( propstg.vt );
		item.pszText = const_cast<TCHAR*>((LPCTSTR)csTemp);
		m = m_propertyList.SetItem( &item );
		ATLASSERT( m != -1 );

		csTemp.Empty();
		PROPVARIANT propval;
		propval.vt = VT_EMPTY;
		hr = m_dm.JolietProperties_Read( propstg.propid, &propval );
		if( hr == S_OK )
		{
			csTemp = GetVariantValue( propval );
			if( propval.vt == VT_BSTR )
				SysFreeString( propval.bstrVal );
		}
		item.mask = LVIF_TEXT;
		item.iItem = n;
		item.iSubItem = 3;
		item.pszText = const_cast<TCHAR*>((LPCTSTR)csTemp);
		m = m_propertyList.SetItem( &item );
		ATLASSERT( m != -1 );

		if( propstg.lpwstrName )
			CoTaskMemFree( propstg.lpwstrName );

		++nItemCount;
		hr = m_dm.JolietProperties_GetNext( &propstg );
	}

	ATLASSERT( SUCCEEDED( hr ) );

	HTREEITEM hItem = m_folderTree.InsertItem( L"root" );
	m_folderTree.SetItemData( hItem, (DWORD_PTR)&m_folderAndFiles );
	m_folderTree.Select( hItem, TVGN_CARET );

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CCreateJolietDiskDlg::OnBnClickedNewFolder()
{
	HTREEITEM hParent = m_folderTree.GetSelectedItem();
	CString csFolderName;
	CFoldersAndFiles* pNewFolder = NULL;

	if( hParent == NULL )
		return;

	CFoldersAndFiles* pFilesAndFolders = (CFoldersAndFiles*)m_folderTree.GetItemData( hParent );
	ATLASSERT( pFilesAndFolders );

	int nFolderIndex = 1;
	for(;;)
	{
		if( nFolderIndex == 1 )
			csFolderName = L"NewFolder";
		else
			csFolderName.Format( L"NewFolder%d", nFolderIndex );

		pNewFolder = pFilesAndFolders->AddNewFolder( csFolderName );
		if( pNewFolder )
			break;

		++nFolderIndex;
	} // for

	HTREEITEM hItem = m_folderTree.InsertItem( csFolderName, hParent ? hParent : TVI_ROOT, TVI_LAST );
	ATLASSERT( hItem != NULL );
	m_folderTree.SetItemData( hItem, (DWORD_PTR)pNewFolder );
	m_folderTree.Expand( hParent, TVE_EXPAND );
//	m_folderTree.RedrawWindow();
}

void CCreateJolietDiskDlg::OnBnClickedDeleteFolder()
{
	HTREEITEM hItem = m_folderTree.GetSelectedItem();
	if( hItem == NULL )
		return;

	CString csFolderName;
	HTREEITEM hParent = m_folderTree.GetParentItem( hItem );
	if( hParent == NULL )
		return;

	CFoldersAndFiles* pParentFolder = (CFoldersAndFiles*)m_folderTree.GetItemData( hParent );
    ATLASSERT( pParentFolder );

	bool result = pParentFolder->DeleteFolder( m_folderTree.GetItemText( hItem ) );
	ATLASSERT( result );

	m_folderTree.DeleteItem( hItem );
}

void CCreateJolietDiskDlg::OnBnClickedRenameFolder()
{
	HTREEITEM hItem = m_folderTree.GetSelectedItem();
	if( hItem == NULL )
		return;

	HTREEITEM hParent = m_folderTree.GetParentItem( hItem );
	if( hParent == NULL )
		return;

	m_folderTree.SetFocus();
	CEdit* pEdit = m_folderTree.EditLabel( hItem );
}

void CCreateJolietDiskDlg::OnTvnEndlabeleditFolderTree(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMTVDISPINFO pTVDispInfo = reinterpret_cast<LPNMTVDISPINFO>(pNMHDR);
	*pResult = 0;
	if( ! (pTVDispInfo->item.mask & TVIF_TEXT ) )
		return;

	HTREEITEM hItem = m_folderTree.GetSelectedItem();
	if( !hItem )
		return;

	HTREEITEM hParent = m_folderTree.GetParentItem( hItem );
	if( !hParent )
		return;

	CFoldersAndFiles* pParentFolder = (CFoldersAndFiles*)m_folderTree.GetItemData( hParent );
    ATLASSERT( pParentFolder );

	CString csOldName = m_folderTree.GetItemText( hItem );
	CString csNewName = pTVDispInfo->item.pszText;
	csNewName.Trim();
	if( csNewName.IsEmpty() )
	{
		MessageBox( L"Invalid folder name!" );
		return;
	}

	bool result = pParentFolder->RenameFolder( csOldName, csNewName );
	if( !result )
	{
		MessageBox( L"Duplicate folder name!" );
		return;
	}

	m_folderTree.SetItemText( hItem, csNewName );
}

void CCreateJolietDiskDlg::OnBnClickedOk()
{
	// TODO: Add your control notification handler code here
	// OnOK();
}

void CCreateJolietDiskDlg::OnTvnBeginlabeleditFolderTree(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMTVDISPINFO pTVDispInfo = reinterpret_cast<LPNMTVDISPINFO>(pNMHDR);

	ATLASSERT( pTVDispInfo->item.mask & TVIF_HANDLE );
	HTREEITEM hParent = m_folderTree.GetParentItem( pTVDispInfo->item.hItem );
	if( hParent )
			*pResult = 0;
	else
			*pResult = TRUE;
}

void CCreateJolietDiskDlg::OnTvnSelchangingFolderTree(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMTREEVIEW pNMTreeView = reinterpret_cast<LPNMTREEVIEW>(pNMHDR);
	*pResult = 0;

	ATLASSERT( pNMTreeView->itemOld.mask & TVIF_HANDLE );
	ATLASSERT( pNMTreeView->itemNew.mask & TVIF_HANDLE );
	if( pNMTreeView->itemOld.hItem == pNMTreeView->itemNew.hItem )
		return;

	HTREEITEM hParent = m_folderTree.GetParentItem( pNMTreeView->itemNew.hItem );
	if( hParent )
	{
		GetDlgItem( IDC_DELETE_FOLDER )->EnableWindow( TRUE );
		GetDlgItem( IDC_RENAME_FOLDER )->EnableWindow( TRUE );
	}
	else
	{
		GetDlgItem( IDC_DELETE_FOLDER )->EnableWindow( FALSE );
		GetDlgItem( IDC_RENAME_FOLDER )->EnableWindow( FALSE );
	}

	m_fileList.DeleteAllItems();
	CFoldersAndFiles* pParentFolder = (CFoldersAndFiles*)m_folderTree.GetItemData( pNMTreeView->itemNew.hItem );
    ATLASSERT( pParentFolder );
	POSITION pos = pParentFolder->m_fileList.GetHeadPosition();
	while( pos )
	{
		CFileEntry entry = pParentFolder->m_fileList.GetNext( pos );

		LVITEM item;

		item.mask = LVIF_TEXT;
		item.iItem = m_fileList.GetItemCount();
		item.iSubItem = 0;
		item.pszText = const_cast<TCHAR*>((LPCTSTR)entry.m_csFilename);
		int n = m_fileList.InsertItem( &item );
		ATLASSERT( n != -1 );

		item.mask = LVIF_TEXT;
		item.iItem = n;
		item.iSubItem = 1;
		item.pszText = const_cast<TCHAR*>((LPCTSTR)entry.m_csPath);
		int m = m_fileList.SetItem( &item );
		ATLASSERT( m != -1 );
	}
}

void CCreateJolietDiskDlg::OnLvnOdstatechangedFileList(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMLVODSTATECHANGE pStateChanged = reinterpret_cast<LPNMLVODSTATECHANGE>(pNMHDR);
	*pResult = 0;

	UINT nSelCount = m_fileList.GetSelectedCount();
	if( nSelCount > 0 )
	{
		GetDlgItem( IDC_REMOVE_FILES )->EnableWindow( TRUE );
		if( nSelCount == 1 )
			GetDlgItem( IDC_RENAME_FILE )->EnableWindow( TRUE );
		else
			GetDlgItem( IDC_RENAME_FILE )->EnableWindow( FALSE );
	}
	else
	{
		GetDlgItem( IDC_REMOVE_FILES )->EnableWindow( FALSE );
		GetDlgItem( IDC_RENAME_FILE )->EnableWindow( FALSE );
	}
}

void CCreateJolietDiskDlg::OnBnClickedAddFiles()
{
	HTREEITEM hParent = m_folderTree.GetSelectedItem();
	if( !hParent )
		return;

	CFoldersAndFiles* pParentFolder = (CFoldersAndFiles*)m_folderTree.GetItemData( hParent );
	ATLASSERT( pParentFolder );

	CFileDialog dlg( 
		TRUE, 
		NULL, 
		NULL, 
		OFN_ALLOWMULTISELECT | OFN_EXPLORER | OFN_FILEMUSTEXIST | OFN_PATHMUSTEXIST,
		NULL,
		this );

	if( dlg.DoModal() == IDCANCEL )
		return;

	POSITION pos = dlg.GetStartPosition();
	while( pos )
	{
		CString csPath = dlg.GetNextPathName( pos );
		CString csFilename;
		int c = csPath.ReverseFind( '\\' );
		
		int nIndex = 1;
		for(;;)
		{
			if( nIndex == 1 )
				csFilename = csPath.Mid( c + 1 );
			else
				csFilename.Format( L"%s%d", csPath.Mid( c + 1 ), nIndex );

			if( pParentFolder->AddNewFile( csFilename, csPath ) )
				break;

			++nIndex;
		}

		LVITEM item;

		item.mask = LVIF_TEXT;
		item.iItem = m_fileList.GetItemCount();
		item.iSubItem = 0;
		item.pszText = const_cast<TCHAR*>((LPCTSTR)csFilename);
		int n = m_fileList.InsertItem( &item );
		ATLASSERT( n != -1 );

		item.mask = LVIF_TEXT;
		item.iItem = n;
		item.iSubItem = 1;
		item.pszText = const_cast<TCHAR*>((LPCTSTR)csPath);
		int m = m_fileList.SetItem( &item );
		ATLASSERT( m != -1 );
	}
}

void CCreateJolietDiskDlg::OnBnClickedRemoveFiles()
{
	HTREEITEM hParent = m_folderTree.GetSelectedItem();
	if( !hParent )
		return;

	if( m_fileList.GetSelectedCount() == 0 )
		return;

	CFoldersAndFiles* pParentFolder = (CFoldersAndFiles*)m_folderTree.GetItemData( hParent );
	ATLASSERT( pParentFolder );

	POSITION pos = m_fileList.GetFirstSelectedItemPosition();
	while( pos )
	{
		int nItem = m_fileList.GetNextSelectedItem( pos );
		CString csFilename = m_fileList.GetItemText( nItem, 0 );
		bool r = pParentFolder->DeleteFile( csFilename );
		ATLASSERT( r );
		m_fileList.DeleteItem( nItem );
	}
}

void CCreateJolietDiskDlg::OnBnClickedRenameFile()
{
	HTREEITEM hParent = m_folderTree.GetSelectedItem();
	if( !hParent )
		return;

	if( m_fileList.GetSelectedCount() != 1 )
		return;

	CFoldersAndFiles* pParentFolder = (CFoldersAndFiles*)m_folderTree.GetItemData( hParent );
	ATLASSERT( pParentFolder );

	POSITION pos = m_fileList.GetFirstSelectedItemPosition();
	int nItem = m_fileList.GetNextSelectedItem( pos );
	m_fileList.SetFocus();
	CEdit* pEdit = m_fileList.EditLabel( nItem );
}


void CCreateJolietDiskDlg::OnLvnEndlabeleditFileList(NMHDR *pNMHDR, LRESULT *pResult)
{
	NMLVDISPINFO *pDispInfo = reinterpret_cast<NMLVDISPINFO*>(pNMHDR);
	*pResult = 0;
	ATLASSERT( pDispInfo->item.mask & LVIF_TEXT );

	HTREEITEM hParent = m_folderTree.GetSelectedItem();
	if( !hParent )
		return;

	if( m_fileList.GetSelectedCount() != 1 )
		return;

	CFoldersAndFiles* pParentFolder = (CFoldersAndFiles*)m_folderTree.GetItemData( hParent );
	ATLASSERT( pParentFolder );

	POSITION pos = m_fileList.GetFirstSelectedItemPosition();
	int nItem = m_fileList.GetNextSelectedItem( pos );

	CString csOldFileName = m_fileList.GetItemText( nItem, 0 );
	CString csNewFileName = pDispInfo->item.pszText;
	csNewFileName.Trim();
	if( csNewFileName.IsEmpty() )
		return;

	if( csNewFileName == csOldFileName )
		return;

	if( pParentFolder->RenameFile( csOldFileName, csNewFileName ) )
	{
		m_fileList.SetItemText( nItem, 0, csNewFileName );
	}
	else
	{
		MessageBox( L"Invalid/duplicate filename!" );
	}
}


void CCreateJolietDiskDlg::OnBnClickedBurn()
{
	CComPtr<IStorage> spStorage;
	m_folderAndFiles.GetIStorage( &spStorage );

	HRESULT hr = m_dm.AddData( spStorage, 0 );
	ATLASSERT( SUCCEEDED( hr ) );

	hr = m_dm.RecordDisc( false, true );
	ATLASSERT( SUCCEEDED( hr ) );
}

void CCreateJolietDiskDlg::OnLvnItemchangedPropertyList(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMLISTVIEW pNMLV = reinterpret_cast<LPNMLISTVIEW>(pNMHDR);
	// TODO: Add your control notification handler code here
	*pResult = 0;
}

void CCreateJolietDiskDlg::OnBnClickedEditProperty()
{
	if( m_propertyList.GetSelectedCount() != 1 )
		return;

	POSITION pos = m_propertyList.GetFirstSelectedItemPosition();
	int nIndex = m_propertyList.GetNextSelectedItem( pos );
	CString csIndex = m_propertyList.GetItemText( nIndex, 0 );

	PROPVARIANT var;
	PROPID propid = _wtol( csIndex );

	HRESULT hr = m_dm.JolietProperties_Read( propid, &var );
	if( SUCCEEDED( hr ) )
	{
		CEnterVariantDlg dlg( var );
		if( dlg.DoModal() == IDOK )
		{
			hr = m_dm.JolietProperties_Write( propid, &var );
			if( SUCCEEDED( hr ) )
			{
				CString csTemp = GetVariantValue( var );
				m_propertyList.SetItemText( nIndex, 3, csTemp );
			}
			else
			{
				MessageBox( L"Failed to change the property value!", L"Error!" );
			}
		}
	}
}

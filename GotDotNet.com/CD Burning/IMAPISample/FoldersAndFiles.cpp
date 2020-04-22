#include "StdAfx.h"
#include "foldersandfiles.h"

CFileEntry::CFileEntry( void )
{
}

CFileEntry::CFileEntry( const CString& csFilename, const CString& csPath )
	: m_csFilename(csFilename), m_csPath(csPath )
{
}

CFileEntry::CFileEntry( const CFileEntry& other )
{
	Copy( other );
}

CFileEntry::~CFileEntry( void )
{
}

CFileEntry& CFileEntry::operator=( const CFileEntry& other )
{
	Copy( other );
	return *this;
}

void CFileEntry::Copy( const CFileEntry& other )
{
	if( this != &other )
	{
		m_csFilename = other.m_csFilename;
		m_csPath = other.m_csPath;
	}
}

bool CFileEntry::operator==( const CFileEntry& other ) const
{
	if( this == &other )
		return true;

	return ( other.m_csFilename == m_csFilename );
}


CFoldersAndFiles::CFoldersAndFiles(void)
{
}

CFoldersAndFiles::CFoldersAndFiles( const CString& csFolder )
	: m_csFolderName( csFolder )
{
}

CFoldersAndFiles::~CFoldersAndFiles(void)
{
	while( ! m_folderList.IsEmpty() )
	{
		CFoldersAndFiles* pFolders = m_folderList.RemoveHead();
		ATLASSERT( pFolders );
		delete pFolders;
	}
}

bool CFoldersAndFiles::AddNewFile( const CString& csFilename, const CString& csPath )
{
	// check for duplicate folder name
	POSITION pos = FindFolder( csFilename );
	if( pos )
		return false;

	// check for duplicate file name
	CFileEntry element( csFilename, csPath );
	pos = m_fileList.Find( element );
	if( pos )
		return false;

	m_fileList.AddTail( element );
	return true;
}

bool CFoldersAndFiles::DeleteFile( const CString& csFilename )
{
	CFileEntry element;
	element.m_csFilename = csFilename;
	POSITION pos = m_fileList.Find( element );
	if( pos == NULL )
		return false;

	m_fileList.RemoveAt( pos );
	return true;
}

bool CFoldersAndFiles::RenameFile( const CString& csFilename, const CString& csNewFilename )
{
	// check for duplicate folder name
	POSITION pos = FindFolder( csNewFilename );
	if( pos )
		return false;

	CFileEntry element;
	// check for duplicate file name
	element.m_csFilename = csNewFilename;
	pos = m_fileList.Find( element );
	if( pos )
		return false;

	element.m_csFilename = csFilename;
	pos = m_fileList.Find( element );
	if( pos == NULL )
		return false;

	{
		CFileEntry& temp = m_fileList.GetAt( pos );
		temp.m_csFilename = csNewFilename;
	}
	return true;
}

POSITION CFoldersAndFiles::FindFolder( const CString& csFolder )
{
	POSITION pos = m_folderList.GetHeadPosition();
	while( pos )
	{
		CFoldersAndFiles* pFolders = m_folderList.GetAt( pos );
		if( pFolders->m_csFolderName == csFolder )
			break;

		m_folderList.GetNext( pos );
	}

	return pos;
}

CFoldersAndFiles* CFoldersAndFiles::AddNewFolder( const CString& csFolder )
{
	// check for duplicate folder name
	POSITION pos = FindFolder( csFolder );
	if( pos )
		return NULL;

	// check for duplicate file name
	CFileEntry element;
	element.m_csFilename = csFolder;
	pos = m_fileList.Find( element );
	if( pos )
		return NULL;

	CFoldersAndFiles *pNewFolder = new CFoldersAndFiles( csFolder );
	m_folderList.AddTail( pNewFolder );
	return pNewFolder;
}

bool CFoldersAndFiles::DeleteFolder( const CString& csFolder )
{
	POSITION pos = FindFolder( csFolder );
	if( !pos )
		return false;

	CFoldersAndFiles *pFolder = m_folderList.GetAt( pos );
	delete pFolder;
	m_folderList.RemoveAt( pos );
	return true;
}

bool CFoldersAndFiles::RenameFolder( const CString& csFolder, const CString& csNewName )
{
	// check for duplicate folder name
	POSITION pos = FindFolder( csNewName );
	if( pos )
		return false;

	// check for duplicate file name
	CFileEntry element;
	element.m_csFilename = csNewName;
	pos = m_fileList.Find( element );
	if( pos != NULL )
		return false;

	// Find the folder
	pos = FindFolder( csFolder );
	if( !pos )
		return false;

	CFoldersAndFiles *pFolder = m_folderList.GetAt( pos );
	pFolder->m_csFolderName = csNewName;
	return true;
}

bool CFoldersAndFiles::GetIStorage( IStorage** ppStorage )
{
	ATLASSERT( ppStorage );
	IStorage* pStorage = new CFolderStorage( this );
	*ppStorage = pStorage;
	return true;
}

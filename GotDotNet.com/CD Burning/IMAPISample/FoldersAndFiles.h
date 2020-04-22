#pragma once
#include "folderstorage.h"

class CFileEntry
{
public:
	CFileEntry( void );
	CFileEntry( const CString& csFilename, const CString& csPath );
	CFileEntry( const CFileEntry& other );
	virtual ~CFileEntry( void );
	CFileEntry& operator=( const CFileEntry& other );
	bool operator==( const CFileEntry& other ) const;
protected:
	void Copy( const CFileEntry& other );

public:
	CString m_csFilename;
	CString m_csPath;
};

class CFoldersAndFiles
{
public:
	CAtlList<CFoldersAndFiles*> m_folderList;
	CAtlList<CFileEntry> m_fileList;
	CString m_csFolderName;

	CFoldersAndFiles(void);
	CFoldersAndFiles( const CString& csFolder );
	virtual ~CFoldersAndFiles(void);

	bool AddNewFile( const CString& csFilename, const CString& csPath );
	bool DeleteFile( const CString& csFilename );
	bool RenameFile( const CString& csFilename, const CString& csNewFilename );

	POSITION FindFolder( const CString& csFolder );
	CFoldersAndFiles* AddNewFolder( const CString& csFolder );
	bool DeleteFolder( const CString& csFolder );
	bool RenameFolder( const CString& csFolder, const CString& csNewName );

	bool GetIStorage( IStorage** ppStorage );
};

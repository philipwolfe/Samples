#include "StdAfx.h"
#include "folderstorage.h"
#include "foldersandfiles.h"
#include "filestream.h"

CFolderStorage::CFolderStorage( CFoldersAndFiles* pFolders )
{
	m_nIndex = 0;
	m_nRefCount = 1;
	ATLASSERT( pFolders );
	m_pFolders = pFolders;
}

CFolderStorage::~CFolderStorage(void)
{
	ATLASSERT( m_nRefCount == 0 );
}

HRESULT STDMETHODCALLTYPE CFolderStorage::QueryInterface( 
	/* [in] */ REFIID riid,
	/* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject)
{
	if( !ppvObject )
		return E_FAIL;

	if( riid == IID_IStorage )
	{
		InterlockedIncrement( &m_nRefCount );
		*ppvObject = static_cast<IStorage*>(this);
		return S_OK;
	}
	else if( riid == IID_IEnumSTATSTG )
	{
		InterlockedIncrement( &m_nRefCount );
		*ppvObject = static_cast<IEnumSTATSTG*>(this);
		return S_OK;
	}
	else if( riid == IID_IUnknown )
	{
		InterlockedIncrement( &m_nRefCount );
		*ppvObject = static_cast<IStorage*>(this);
		return S_OK;
	}
	else
		return E_NOINTERFACE;
}

ULONG STDMETHODCALLTYPE CFolderStorage::AddRef( void )
{
	return InterlockedIncrement( &m_nRefCount );
}

ULONG STDMETHODCALLTYPE CFolderStorage::Release( void )
{
	LONG n = InterlockedDecrement( &m_nRefCount );
	if( n == 0 )
		delete this;

	return n;
}


HRESULT STDMETHODCALLTYPE CFolderStorage::CreateStream( 
	/* [string][in] */ const OLECHAR *pwcsName,
	/* [in] */ DWORD grfMode,
	/* [in] */ DWORD reserved1,
	/* [in] */ DWORD reserved2,
	/* [out] */ IStream **ppstm)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

/* [local] */ HRESULT STDMETHODCALLTYPE CFolderStorage::OpenStream( 
/* [string][in] */ const OLECHAR *pwcsName,
/* [unique][in] */ void *reserved1,
/* [in] */ DWORD grfMode,
/* [in] */ DWORD reserved2,
/* [out] */ IStream **ppstm)
{
	if( ppstm == NULL )
		return STG_E_INVALIDPOINTER;

	if( pwcsName == NULL )
		return STG_E_INVALIDPARAMETER;

	if( !( grfMode & STGM_SHARE_EXCLUSIVE ) )
		return STG_E_INVALIDFLAG;

	if( grfMode & STGM_WRITE )
		return STG_E_ACCESSDENIED;

	if( grfMode & STGM_READWRITE )
		return STG_E_ACCESSDENIED;

	CFileEntry entry;
	entry.m_csFilename = pwcsName;
	POSITION pos = m_pFolders->m_fileList.Find( entry );
	if( pos == NULL )
		return STG_E_INVALIDNAME;

	entry = m_pFolders->m_fileList.GetAt( pos );

	HANDLE hFile = CreateFile( 
		entry.m_csPath,
		GENERIC_READ,
		0,
		NULL,
		OPEN_EXISTING,
		FILE_ATTRIBUTE_NORMAL,
		NULL );

	ATLASSERT( hFile );
	if( !hFile )
		return E_FAIL;
	
	CFileStream* pFileStream = new CFileStream( hFile );
	*ppstm = static_cast<IStream*>(pFileStream);
	return S_OK;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::CreateStorage( 
	/* [string][in] */ const OLECHAR *pwcsName,
	/* [in] */ DWORD grfMode,
	/* [in] */ DWORD reserved1,
	/* [in] */ DWORD reserved2,
	/* [out] */ IStorage **ppstg)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::OpenStorage( 
	/* [string][unique][in] */ const OLECHAR *pwcsName,
	/* [unique][in] */ IStorage *pstgPriority,
	/* [in] */ DWORD grfMode,
	/* [unique][in] */ SNB snbExclude,
	/* [in] */ DWORD reserved,
	/* [out] */ IStorage **ppstg)
{
	if( pwcsName == NULL )
		return STG_E_FILENOTFOUND;
	if( ppstg == NULL )
		return STG_E_INVALIDPOINTER;

	if( !( grfMode & STGM_SHARE_EXCLUSIVE ) )
		return STG_E_INVALIDFLAG;

	if( grfMode & STGM_WRITE )
		return STG_E_ACCESSDENIED;

	if( grfMode & STGM_READWRITE )
		return STG_E_ACCESSDENIED;

	POSITION pos = m_pFolders->FindFolder( pwcsName );
	if( pos == NULL )
		return STG_E_FILENOTFOUND;

	CFoldersAndFiles* pFolder = m_pFolders->m_folderList.GetAt( pos );
	ATLASSERT( pFolder );

	IStorage* pStorage = NULL;
	bool r = pFolder->GetIStorage( &pStorage );
	ATLASSERT( r );

	*ppstg = pStorage;

	return S_OK;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::CopyTo( 
	/* [in] */ DWORD ciidExclude,
	/* [size_is][unique][in] */ const IID *rgiidExclude,
	/* [unique][in] */ SNB snbExclude,
	/* [unique][in] */ IStorage *pstgDest)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::MoveElementTo( 
	/* [string][in] */ const OLECHAR *pwcsName,
	/* [unique][in] */ IStorage *pstgDest,
	/* [string][in] */ const OLECHAR *pwcsNewName,
	/* [in] */ DWORD grfFlags)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::Commit( 
	/* [in] */ DWORD grfCommitFlags)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::Revert( void)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

/* [local] */ HRESULT STDMETHODCALLTYPE CFolderStorage::EnumElements( 
/* [in] */ DWORD reserved1,
/* [size_is][unique][in] */ void *reserved2,
/* [in] */ DWORD reserved3,
/* [out] */ IEnumSTATSTG **ppenum)
{
	if( ppenum == NULL )
		return STG_E_INVALIDPARAMETER;

	InterlockedIncrement( &m_nRefCount );
	*ppenum = static_cast<IEnumSTATSTG*>(this);
	return S_OK;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::DestroyElement( 
	/* [string][in] */ const OLECHAR *pwcsName)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::RenameElement( 
	/* [string][in] */ const OLECHAR *pwcsOldName,
	/* [string][in] */ const OLECHAR *pwcsNewName)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::SetElementTimes( 
	/* [string][unique][in] */ const OLECHAR *pwcsName,
	/* [unique][in] */ const FILETIME *pctime,
	/* [unique][in] */ const FILETIME *patime,
	/* [unique][in] */ const FILETIME *pmtime)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::SetClass( 
	/* [in] */ REFCLSID clsid)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::SetStateBits( 
	/* [in] */ DWORD grfStateBits,
	/* [in] */ DWORD grfMask)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::Stat( 
	/* [out] */ STATSTG *pstatstg,
	/* [in] */ DWORD grfStatFlag)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

	// IEnumSTATSTG methods
HRESULT STDMETHODCALLTYPE CFolderStorage::Next( ULONG celt, STATSTG *rgelt, ULONG *pceltFetched )
{
	ULONG nFetched = 0;
	if( rgelt == NULL )
		return E_POINTER;


	for( ULONG nIndex = 0; nIndex < celt; nIndex++ )
	{
		// Are we fetching folders or files?
		if( m_nIndex < m_pFolders->m_folderList.GetCount() )
		{
			POSITION pos = m_pFolders->m_folderList.FindIndex( m_nIndex );
			ATLASSERT(pos);
			CFoldersAndFiles* pFolder = m_pFolders->m_folderList.GetAt( pos );
			ATLASSERT(pFolder);

			int nLength = ( pFolder->m_csFolderName.GetLength() + 1 ) * sizeof(TCHAR);
			rgelt[nIndex].pwcsName = (LPOLESTR)CoTaskMemAlloc( nLength );
			memcpy( rgelt[nIndex].pwcsName, pFolder->m_csFolderName, nLength );
			rgelt[nIndex].type = STGTY_STORAGE;
			rgelt[nIndex].cbSize.QuadPart = 0;
			rgelt[nIndex].mtime.dwHighDateTime = 0;
			rgelt[nIndex].mtime.dwLowDateTime = 0;
			rgelt[nIndex].ctime.dwHighDateTime = 0;
			rgelt[nIndex].ctime.dwLowDateTime = 0;
			rgelt[nIndex].atime.dwHighDateTime = 0;
			rgelt[nIndex].atime.dwLowDateTime = 0;
			rgelt[nIndex].grfMode = 0;
			rgelt[nIndex].grfLocksSupported = 0;
			rgelt[nIndex].clsid = CLSID_NULL;
			rgelt[nIndex].grfStateBits = 0;
			rgelt[nIndex].reserved = 0;
		}
		else if( ( m_nIndex - m_pFolders->m_folderList.GetCount() ) < m_pFolders->m_fileList.GetCount() )
		{
			POSITION pos = m_pFolders->m_fileList.FindIndex( m_nIndex - m_pFolders->m_folderList.GetCount() );
			ATLASSERT(pos);
			CFileEntry file = m_pFolders->m_fileList.GetAt( pos );

			HANDLE hFile = CreateFile( 
				file.m_csFilename,
				GENERIC_READ,
				0,
				NULL,
				OPEN_EXISTING,
				FILE_ATTRIBUTE_NORMAL,
				NULL );

			ATLASSERT( hFile );
			if( !hFile )
				return E_FAIL;

			GetFileSizeEx( hFile, (PLARGE_INTEGER)&( rgelt[nIndex].cbSize ) );
			GetFileTime( hFile, &( rgelt[nIndex].ctime ), &( rgelt[nIndex].atime), &( rgelt[nIndex].mtime ) );

			CloseHandle( hFile );

			int nLength = ( file.m_csFilename.GetLength() + 1 ) * sizeof(TCHAR);
			rgelt[nIndex].pwcsName = (LPOLESTR)CoTaskMemAlloc( nLength );
			memcpy( rgelt[nIndex].pwcsName, file.m_csFilename, nLength );
			rgelt[nIndex].type = STGTY_STREAM;
			rgelt[nIndex].grfMode = 0;
			rgelt[nIndex].grfLocksSupported = 0;
			rgelt[nIndex].clsid = CLSID_NULL;
			rgelt[nIndex].grfStateBits = 0;
			rgelt[nIndex].reserved = 0;
		}
		else
			break;

		m_nIndex++;
		nFetched++;
	}

	if( pceltFetched )
		*pceltFetched = nFetched;

	return S_OK;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::Skip( ULONG celt )
{
	m_nIndex += celt;
	return S_OK;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::Reset(void)
{
	m_nIndex = 0;
	return S_OK;
}

HRESULT STDMETHODCALLTYPE CFolderStorage::Clone( IEnumSTATSTG **ppenum )
{
	if( ppenum == NULL )
		return E_POINTER;

	CFolderStorage *pNewFolderStorage = new CFolderStorage( m_pFolders );
	*ppenum = pNewFolderStorage;
	return S_OK;
}

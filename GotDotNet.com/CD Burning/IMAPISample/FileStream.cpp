#include "StdAfx.h"
#include "filestream.h"

CFileStream::CFileStream( HANDLE hFile )
{
	ATLASSERT( hFile );
	m_hFile = hFile;
	m_nRefCount = 1;
}

CFileStream::~CFileStream(void)
{
	ATLASSERT( m_nRefCount == 0 );
	CloseHandle( m_hFile );
}

HRESULT STDMETHODCALLTYPE CFileStream::QueryInterface( 
	/* [in] */ REFIID riid,
	/* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject)
{
	if( !ppvObject )
		return E_FAIL;

	if( riid == IID_IStream )
	{
		InterlockedIncrement( &m_nRefCount );
		*ppvObject = static_cast<IStream*>(this);
		return S_OK;
	}
	else if( riid == IID_IUnknown )
	{
		InterlockedIncrement( &m_nRefCount );
		*ppvObject = static_cast<IStream*>(this);
		return S_OK;
	}
	else
		return E_NOINTERFACE;
}

ULONG STDMETHODCALLTYPE CFileStream::AddRef( void )
{
	return InterlockedIncrement( &m_nRefCount );
}

ULONG STDMETHODCALLTYPE CFileStream::Release( void )
{
	LONG n = InterlockedDecrement( &m_nRefCount );
	if( n == 0 )
		delete this;

	return n;
}

HRESULT STDMETHODCALLTYPE CFileStream::Read(
							   void *pv,  //Pointer to buffer into which the stream is read
							   ULONG cb,  //Specifies the number of bytes to read
							   ULONG *pcbRead
							   //Pointer to location that contains actual
							   // number of bytes read
							   )
{
	ATLASSERT( pv );
	if( !pv )
		return E_POINTER;

	DWORD dwRead;
	BOOL r = ReadFile( m_hFile, pv, cb, &dwRead, NULL );
	if( r )
	{
		if( pcbRead )
			*pcbRead = dwRead;
		return S_OK;
	}
	return E_FAIL;
}

HRESULT STDMETHODCALLTYPE CFileStream::Write(
								void const *pv,     //Pointer to the buffer address from which the stream is written
								ULONG cb,           //Specifies the number of bytes to write
								ULONG *pcbWritten   //Specifies the actual number of bytes written
								)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFileStream::Seek(
							   LARGE_INTEGER dlibMove,          //Offset relative to dwOrigin
							   DWORD dwOrigin,                  //Specifies the origin for the offset
							   ULARGE_INTEGER *plibNewPosition  //Pointer to location containing
							   // new seek pointer
							   )
{
	DWORD dwMoveMethod;
	switch( dwOrigin )
	{
	case STREAM_SEEK_SET:
		dwMoveMethod = FILE_BEGIN;
		break;
	case STREAM_SEEK_CUR:
		dwMoveMethod = FILE_CURRENT;
		break;
	case STREAM_SEEK_END:
		dwMoveMethod = FILE_END;
		break;
	default:
		return STG_E_INVALIDFUNCTION;
	}

	LARGE_INTEGER newFilePointer;
	BOOL r = SetFilePointerEx( m_hFile, dlibMove, &newFilePointer, dwMoveMethod );

	if( r )
	{
		if( plibNewPosition )
			(*plibNewPosition).QuadPart = newFilePointer.QuadPart;
		return S_OK;
	}

	return E_FAIL;
}

HRESULT STDMETHODCALLTYPE CFileStream::SetSize(
								  ULARGE_INTEGER libNewSize  //Specifies the new size of the stream object
								  )
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFileStream::CopyTo(
								 IStream *pstm,               //Pointer to the destination stream
								 ULARGE_INTEGER cb,           //Specifies the number of bytes to copy
								 ULARGE_INTEGER *pcbRead,     //Pointer to the actual number of bytes 
								 // read from the source
								 ULARGE_INTEGER *pcbWritten   //Pointer to the actual number of 
								 // bytes written to the destination
								 )
{
	char buffer[1024];
	ULARGE_INTEGER nBytesCopied;
	nBytesCopied.QuadPart = 0;

	if( pstm == NULL )
		return STG_E_INVALIDPOINTER;

	if( pstm == static_cast<IStream*>(this) )
	{
		ATLASSERT( FALSE );
		return STG_E_INVALIDPOINTER; // we do not support copying to ourself
	}
	else
	{
		DWORD dwBytesRead;
		while( cb.QuadPart > 0 )
		{
			DWORD dwBytesToRead;
			if( cb.QuadPart > 1024 )
				dwBytesToRead = 1024;
			else
				dwBytesToRead = cb.QuadPart;

			BOOL r = ReadFile( m_hFile, buffer, dwBytesToRead, &dwBytesRead, NULL );
			if( !r )
				return E_FAIL;
			if( dwBytesRead == 0 )
				break;

			ULONG cbBytesWritten;
			r = pstm->Write( buffer, dwBytesRead, &cbBytesWritten );
			if( !r )
				return STG_E_WRITEFAULT;
			if( dwBytesRead != cbBytesWritten )
				return STG_E_MEDIUMFULL;

			nBytesCopied.QuadPart += cbBytesWritten;
			cb.QuadPart -= cbBytesWritten;
		}
		if( pcbRead )
			pcbRead->QuadPart = nBytesCopied.QuadPart;
		if( pcbWritten )
			pcbWritten->QuadPart = nBytesCopied.QuadPart;
		return S_OK;
	}
}

HRESULT STDMETHODCALLTYPE CFileStream::Commit(
								 DWORD grfCommitFlags  //Specifies how changes are committed
								 )
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFileStream::Revert(void)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFileStream::LockRegion(
									 ULARGE_INTEGER libOffset,  //Specifies the byte offset for
									 // the beginning of the range
									 ULARGE_INTEGER cb,         //Specifies the length of the range in bytes
									 DWORD dwLockType           //Specifies the restriction on
									 // accessing the specified range
									 )
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFileStream::UnlockRegion(
									   ULARGE_INTEGER libOffset,  //Specifies the byte offset for
									   // the beginning of the range
									   ULARGE_INTEGER cb,         //Specifies the length of the range in bytes
									   DWORD dwLockType           //Specifies the access restriction
									   // previously placed on the range
									   )
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFileStream::Stat(
							   STATSTG *pstatstg,  //Location for STATSTG structure
							   DWORD grfStatFlag   //Values taken from the STATFLAG enumeration
							   )
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}

HRESULT STDMETHODCALLTYPE CFileStream::Clone(
								IStream **ppstm  //Pointer to location for pointer to the new stream object
								)
{
	ATLASSERT( FALSE );
	return E_NOTIMPL;
}


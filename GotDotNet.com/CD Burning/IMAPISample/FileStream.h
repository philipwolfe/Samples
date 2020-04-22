#pragma once

class CFileStream :
	public IStream
{
	HANDLE m_hFile;
	LONG m_nRefCount;
public:
	CFileStream( HANDLE hFile );
	virtual ~CFileStream(void);

	virtual HRESULT STDMETHODCALLTYPE QueryInterface( REFIID riid, void __RPC_FAR *__RPC_FAR *ppvObject );
	virtual ULONG STDMETHODCALLTYPE AddRef( void);
	virtual ULONG STDMETHODCALLTYPE Release( void);

	virtual HRESULT STDMETHODCALLTYPE Read(
		void *pv,  //Pointer to buffer into which the stream is read
		ULONG cb,  //Specifies the number of bytes to read
		ULONG *pcbRead
		//Pointer to location that contains actual
		// number of bytes read
		);
	virtual HRESULT STDMETHODCALLTYPE Write(
		void const *pv,     //Pointer to the buffer address from which the stream is written
		ULONG cb,           //Specifies the number of bytes to write
		ULONG *pcbWritten   //Specifies the actual number of bytes written
		);
	virtual HRESULT STDMETHODCALLTYPE Seek(
		LARGE_INTEGER dlibMove,          //Offset relative to dwOrigin
		DWORD dwOrigin,                  //Specifies the origin for the offset
		ULARGE_INTEGER *plibNewPosition  //Pointer to location containing
		// new seek pointer
		);
	virtual HRESULT STDMETHODCALLTYPE SetSize(
		ULARGE_INTEGER libNewSize  //Specifies the new size of the stream object
		);
	virtual HRESULT STDMETHODCALLTYPE CopyTo(
		IStream *pstm,               //Pointer to the destination stream
		ULARGE_INTEGER cb,           //Specifies the number of bytes to copy
		ULARGE_INTEGER *pcbRead,     //Pointer to the actual number of bytes 
		// read from the source
		ULARGE_INTEGER *pcbWritten   //Pointer to the actual number of 
		// bytes written to the destination
		);
	virtual HRESULT STDMETHODCALLTYPE Commit(
		DWORD grfCommitFlags  //Specifies how changes are committed
		);
	virtual HRESULT STDMETHODCALLTYPE Revert(void);
	virtual HRESULT STDMETHODCALLTYPE LockRegion(
		ULARGE_INTEGER libOffset,  //Specifies the byte offset for
		// the beginning of the range
		ULARGE_INTEGER cb,         //Specifies the length of the range in bytes
		DWORD dwLockType           //Specifies the restriction on
		// accessing the specified range
		);
	virtual HRESULT STDMETHODCALLTYPE UnlockRegion(
		ULARGE_INTEGER libOffset,  //Specifies the byte offset for
		// the beginning of the range
		ULARGE_INTEGER cb,         //Specifies the length of the range in bytes
		DWORD dwLockType           //Specifies the access restriction
		// previously placed on the range
		);
	virtual HRESULT STDMETHODCALLTYPE Stat(
		STATSTG *pstatstg,  //Location for STATSTG structure
		DWORD grfStatFlag   //Values taken from the STATFLAG enumeration
		);
	virtual HRESULT STDMETHODCALLTYPE Clone(
		IStream **ppstm  //Pointer to location for pointer to the new stream object
		);
};

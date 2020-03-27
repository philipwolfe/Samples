// VCUE_FileStream.h
// (c) 2000 Microsoft Corporation
//
//////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(_VCUE_FILESTREAM_H___68B7A7C2_B78F_4196_86FF_F6E223BA6A0B___INCLUDED_)
#define _VCUE_FILESTREAM_H___68B7A7C2_B78F_4196_86FF_F6E223BA6A0B___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include <atlcom.h>
#include "VCUE_COM.h"

namespace VCUE
{
	inline HRESULT FileStreamRead(HANDLE hFile, void* pBuffer, ULONG nBytes, ULONG* pnBytesRead)
	{
		if (pnBytesRead)
			*pnBytesRead = 0;
		
		HRESULT hr = E_INVALIDARG;
		
		if (pBuffer && nBytes && hFile && hFile != INVALID_HANDLE_VALUE)
		{
			ULONG nBytesRead = 0;
			BOOL bSuccess = ReadFile(hFile, pBuffer, nBytes, &nBytesRead, NULL);
			if (bSuccess)
			{
				if (pnBytesRead)
					*pnBytesRead = nBytesRead;
				
				if (nBytesRead != nBytes)
					hr = E_UNEXPECTED;
				else
					hr = S_OK;
			}
			else
				hr = AtlHresultFromLastError();
		}
		
		return hr;
	}

	inline HRESULT FileStreamWrite(HANDLE hFile, const void* pBuffer, ULONG nBytes, ULONG* pnBytesWritten)
	{
		if (pnBytesWritten)
			*pnBytesWritten = 0;

		HRESULT hr = E_INVALIDARG;

		if (pBuffer && nBytes && hFile && hFile != INVALID_HANDLE_VALUE)
		{
			ULONG nBytesWritten = 0;
			BOOL bSuccess = WriteFile(hFile, pBuffer, nBytes, &nBytesWritten, NULL);
			if (bSuccess)
			{
				if (pnBytesWritten)
					*pnBytesWritten = nBytesWritten;

				if (nBytesWritten != nBytes)
					hr = E_UNEXPECTED;
				else
					hr = S_OK;
			}
			else
				hr = AtlHresultFromLastError();
		}
		
		return hr;
	}

	template < typename VTable = ISequentialStream >
	class ISequentialStreamImpl : public VTable
	{
	protected:
		HANDLE m_hFile;

	public:
		ISequentialStreamImpl(HANDLE hFile = INVALID_HANDLE_VALUE) : m_hFile(hFile) {}

		STDMETHOD(Read)(void* pBuffer, ULONG nBytes, ULONG* pnBytesRead)
		{
			return FileStreamRead(m_hFile, pBuffer, nBytes, pnBytesRead);
		}

		STDMETHOD(Write)(const void* pBuffer, ULONG nBytes, ULONG* pnBytesWritten)
		{
			return FileStreamWrite(m_hFile, pBuffer, nBytes, pnBytesWritten);
		}
	};

	// TODO - add threading model param?
	class ATL_NO_VTABLE CComStreamOnFile : 
		public CComObjectRootEx<CComSingleThreadModel>,
		public ISequentialStreamImpl<>
	{
	public:

		HRESULT Initialize(HANDLE hFile)
		{
			ATLASSERT(m_hFile == INVALID_HANDLE_VALUE);

			HRESULT hr = E_INVALIDARG;
			if (hFile && hFile != INVALID_HANDLE_VALUE)
			{
				m_hFile = hFile;
				hr = S_OK;
			}
			return hr;
		}

		BEGIN_COM_MAP(CComStreamOnFile)
			COM_INTERFACE_ENTRY(ISequentialStream)
		END_COM_MAP()
	};

	typedef CComObjectNoRefCount<CComStreamOnFile> CStreamOnFile;

	HRESULT CreateStreamOnFile(LPCSTR szFileName, ISequentialStream** ppStream)
	{
		HRESULT hr = E_FAIL;

		HANDLE hFile = ::CreateFileA(
								szFileName,
								GENERIC_READ,
								FILE_SHARE_READ,
								NULL,
								OPEN_EXISTING,
								FILE_FLAG_SEQUENTIAL_SCAN,
								NULL);

		if (hFile == INVALID_HANDLE_VALUE)
			hr = AtlHresultFromLastError();

		CAtlFile theFile(hFile);

		if (SUCCEEDED(hr))
		{
			CComObject<CComStreamOnFile>* pStream = NULL;
			hr = CComObject<CComStreamOnFile>::CreateInstance(&pStream);
			if (SUCCEEDED(hr))
			{
				ATLASSERT(pStream != NULL);

				pStream->AddRef();
				hr = pStream->Initialize(theFile);

				if (SUCCEEDED(hr))
					hr = pStream->QueryInterface(ppStream);

				pStream->Release();
			}

		}

		return hr;
	}

} // namespace VCUE

#endif // !defined(_VCUE_FILESTREAM_H___68B7A7C2_B78F_4196_86FF_F6E223BA6A0B___INCLUDED_)

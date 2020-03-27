// File: StreamOnCString.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#ifndef STREAMONCSTRING_H_INCLUDED
#define STREAMONCSTRING_H_INCLUDED

class CReadWriteStreamOnCString : public IWriteStream,
			public IStreamImpl
{
public:
	HRESULT __stdcall QueryInterface(REFIID riid, void **ppv) throw()
	{
		if (ppv == NULL)
		{
			return E_POINTER;
		}

		*ppv = NULL;

		if (InlineIsEqualGUID(riid, IID_IUnknown) ||
			InlineIsEqualGUID(riid, IID_IStream) ||
			InlineIsEqualGUID(riid, IID_ISequentialStream))
		{
			*ppv = static_cast<IStream *>(this);
			return S_OK;
		}

		return E_NOINTERFACE;
	}

	ULONG __stdcall AddRef() throw()
	{
		::InterlockedIncrement( &l_refCount );
		return 1;
	}

	ULONG __stdcall Release() throw()
	{
		if( l_refCount > 0 )
		{
			::InterlockedDecrement( &l_refCount );
			if( l_refCount == 0 )
				Cleanup();
		}
		return 1;
	}

public:
	CStringA		m_str;
	long			m_nCurr;
	long			m_nBodyLen;

	long			l_refCount;


public:

	CReadWriteStreamOnCString() throw()
		: m_nCurr(0), m_nBodyLen(0), l_refCount(0)
	{
	}

	BOOL Cleanup() throw()
	{
		m_nCurr		=	0;
		m_nBodyLen	=	0;

		m_str.Empty();

		return TRUE;
	}

	HRESULT __stdcall Read(void *pDest, ULONG nMaxLen, ULONG *pnRead) throw()
	{
		ATLASSERT( pDest != NULL );

		if (pnRead != NULL)
		{
			*pnRead = 0;
		}

		long nRead = m_nCurr;
		if (nRead < m_nBodyLen)
		{
			long nLength = min((int)(m_nBodyLen - nRead), (LONG) nMaxLen);
			memcpy(pDest, (LPCSTR)m_str + nRead, nLength);
			m_nCurr+= nLength;

			if (pnRead != NULL)
			{
				*pnRead = (ULONG) nLength;
			}
		}

		return S_OK;
	}

	HRESULT WriteStream(LPCSTR szOut, int nLen, LPDWORD pdwWritten) throw()
	{
		ATLASSERT( szOut != NULL );

		if (nLen < 0)
		{
			nLen = (int) strlen(szOut);
		}

		_ATLTRY
		{
			m_str.Append(szOut, nLen);
			m_nBodyLen	=	m_str.GetLength();
		}
		_ATLCATCHALL()
		{
			return E_OUTOFMEMORY;
		}

		if (pdwWritten != NULL)
		{
			*pdwWritten = (DWORD) nLen;
		}

		return S_OK;
	}

	HRESULT FlushStream() throw()
	{
		return S_OK;
	}

}; // class CReadWriteStreamOnCString


#endif STREAMONCSTRING_H_INCLUDED
// VCUE_OLEDBClient.h
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

#if !defined(_VCUE_OLEDBCLIENT_H___22F2028A_FED9_437D_86E2_374F05FCAC23___INCLUDED_)
#define _VCUE_OLEDBCLIENT_H___22F2028A_FED9_437D_86E2_374F05FCAC23___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include <atldbcli.h>

namespace VCUE
{

	inline bool OleDbSucceeded(HRESULT hr) throw()
	{
		if (SUCCEEDED(hr))
		{
			if (DB_S_ERRORSOCCURRED == hr)
				AtlTraceErrorRecords(hr);
			return true;
		}
		else
		{
			AtlTraceErrorRecords(hr);
			return false;
		}
	}

	inline bool OleDbFailed(HRESULT hr) throw()
	{
		return !OleDbSucceeded(hr);
	}

	class CBLOBItem
	{
	public:
		ISequentialStream* m_pStream;
		ULONG m_ulLength;
		ULONG m_ulDbStatus;

		CBLOBItem() : m_pStream(0), m_ulLength(0), m_ulDbStatus(DBSTATUS_S_ISNULL)
		{
		}

		void Clear()
		{
			if (DBSTATUS_S_OK == m_ulDbStatus && m_pStream)
			{
				m_pStream->Release();
				m_pStream = NULL;
				m_ulDbStatus = DBSTATUS_S_ISNULL;
			}
		}

		HRESULT SetData(ISequentialStream* pStream, ULONG ulLength)
		{
			HRESULT hr = E_POINTER;

			if (pStream)
			{
				// Release existing ISequentialStream pointer if present.
				Clear();

				// Set new ISequentialStream pointer.
				m_pStream = pStream;
				m_pStream->AddRef();

				// Set length field and status.
				m_ulLength = ulLength;
				m_ulDbStatus = DBSTATUS_S_OK;

				hr = S_OK;
			}

			return hr;
		}

		HRESULT Read(void* pv, ULONG cb, ULONG* pcbRead)
		{
			HRESULT hr = E_FAIL;
			if (DBSTATUS_S_OK == m_ulDbStatus && m_pStream)
				hr = m_pStream->Read(pv, cb, pcbRead);
			return hr;
		}

		HRESULT Write(const void* pv, ULONG cb, ULONG* pcbWritten)
		{
			HRESULT hr = E_FAIL;
			if (DBSTATUS_S_OK == m_ulDbStatus && m_pStream)
				hr = m_pStream->Write(pv, cb, pcbWritten);
			return hr;
		}

	};

	#define VCUE_BLOB_COLUMN_ENTRY( nColumnID, member )	\
		BLOB_ENTRY_LENGTH_STATUS(nColumnID, IID_ISequentialStream, STGM_READ, member.m_pStream, member.m_ulLength, member.m_ulDbStatus)

	#define VCUE_BLOB_NAME_ENTRY( pszName, member )	\
		BLOB_NAME_LENGTH_STATUS(pszName, IID_ISequentialStream, STGM_READ, member.m_pStream, member.m_ulLength, member.m_ulDbStatus)


} // namespace VCUE

#endif // !defined(_VCUE_OLEDBCLIENT_H___22F2028A_FED9_437D_86E2_374F05FCAC23___INCLUDED_)

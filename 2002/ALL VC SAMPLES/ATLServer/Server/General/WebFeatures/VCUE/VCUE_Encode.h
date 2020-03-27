// VCUE_Encode.h
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

#if !defined(_VCUE_ENCODE_H___56CB3A01_D832_11D3_BADB_00C04F8EC847___INCLUDED_)
#define _VCUE_ENCODE_H___56CB3A01_D832_11D3_BADB_00C04F8EC847___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

namespace VCUE
{
	inline bool UrlEncode(const CStringA& strSource, CStringA& strDestination) throw()
	{
		bool bSuccess = true;
		ATL::EscapeToCString(strDestination, strSource);
		return bSuccess;
	}

	inline bool UrlDecode(const CStringA& strSource, CStringA& strDestination) throw()
	{
		bool bSuccess = false;
		DWORD dwCharacters = strSource.GetLength();
		if (ATL::AtlUnescapeUrl(strSource,
			strDestination.GetBuffer(dwCharacters),
			&dwCharacters,dwCharacters))
			bSuccess = true;

		strDestination.ReleaseBuffer(dwCharacters);
		return bSuccess;
	}

	inline bool Base64Encode(const CStringA& strSource, CStringA& strDestination)
	{
		bool bSuccess = false;
		
		int nBytes = Base64EncodeGetRequiredLength(strSource.GetLength(), ATL_BASE64_FLAG_NOPAD | ATL_BASE64_FLAG_NOCRLF);
		if (ATL::Base64Encode(
			reinterpret_cast<const BYTE*>(static_cast<const char*>(strSource)),
			strSource.GetLength(),
			strDestination.GetBuffer(nBytes),
			&nBytes,
			ATL_BASE64_FLAG_NOPAD | ATL_BASE64_FLAG_NOCRLF
			))
		{
				bSuccess = true;
		}
		strDestination.ReleaseBuffer(nBytes);
		return bSuccess;
	}

	inline bool Base64Decode(const CStringA& strSource, CStringA& strDestination)
	{
		bool bSuccess = false;
		int nBytes = Base64DecodeGetRequiredLength(strSource.GetLength());
		if (ATL::Base64Decode(
			strSource,
			strSource.GetLength(),
			reinterpret_cast<BYTE*>(strDestination.GetBuffer(nBytes)),
			&nBytes
			))
		{
				bSuccess = true;
		}
		strDestination.ReleaseBuffer(nBytes);
		return bSuccess;
	}

	inline HRESULT HexEncode(const BYTE* Data, int Bytes, CStringA& Encoded)
	{
		HRESULT hr = E_OUTOFMEMORY;
		int EncodedLength = AtlHexEncodeGetRequiredLength(Bytes);
		CStringA::PXSTR p = Encoded.GetBufferSetLength((EncodedLength / sizeof(CStringA::XCHAR)) + 1);
		if (p)
		{
			if (AtlHexEncode(Data, Bytes, p, &EncodedLength))
			{
				p[EncodedLength] = 0;
				Encoded.ReleaseBuffer(EncodedLength);
				hr = S_OK;
			}
			else
			{
				Encoded.ReleaseBuffer(0);
				hr = E_FAIL;
			}
		}

		return hr;
	}
	
	template <class T>
	inline HRESULT HexEncodeByteArray(const T& Data, CStringA& Encoded)
	{
		static_cast<const BYTE[sizeof(Data)]>(Data);
		return HexEncode(Data, sizeof(Data), Encoded);
	}

} // namespace VCUE

#endif // !defined(_VCUE_ENCODE_H___56CB3A01_D832_11D3_BADB_00C04F8EC847___INCLUDED_)

// VCUE_API.h
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

#if !defined(_VCUE_API_H___E35A4CFD_15D0_45B3_9455_5A8A84354584___INCLUDED_)
#define _VCUE_API_H___E35A4CFD_15D0_45B3_9455_5A8A84354584___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

namespace VCUE
{
	HRESULT GetFullTempFileName(CString& str, LPCTSTR szPrefix = _T("VCUE"))
	{
		HRESULT hr = E_UNEXPECTED;

		TCHAR szPath[_MAX_PATH];
		const size_t BufferCharacters = sizeof(szPath)/sizeof(szPath[0]);
		DWORD dwCharacters = GetTempPath(BufferCharacters, szPath);
		if (!dwCharacters)
			return AtlHresultFromLastError();

		if (dwCharacters >= BufferCharacters)
			return E_FAIL; // Path too long
		
		LPTSTR szTempFileName = str.GetBuffer(_MAX_PATH);
		if (GetTempFileName(szPath, szPrefix, 0, szTempFileName))
		{
			hr = S_OK;
			str.ReleaseBuffer();
		}
		else
		{
			hr = AtlHresultFromLastError();
			str.ReleaseBuffer(0);
		}

		return hr;
	}

	#pragma comment(lib, "Rpcrt4.lib")

	//#if defined(UNICODE)
	//	typedef unsigned short VCUE_RPC_CHAR;
	//#else
		typedef unsigned char VCUE_RPC_CHAR;
	//#endif

	inline bool GuidFromString(const CStringA& strGuid, GUID& guid) throw()
	{
		bool bSuccess = false;
		RPC_STATUS status = UuidFromStringA(reinterpret_cast<VCUE_RPC_CHAR*>(const_cast<LPSTR>(static_cast<LPCSTR>(strGuid))), &guid);
		if (RPC_S_OK == status)
			bSuccess = true;
		return bSuccess;
	}

	inline bool StringFromGuid(const GUID& guid, CStringA& strGuid) throw()
	{
		bool bSuccess = false;
		VCUE_RPC_CHAR* pstr = 0;
		RPC_STATUS status = UuidToStringA(const_cast<GUID*>(&guid), &pstr);
		if (RPC_S_OK == status)
		{
			strGuid = pstr;
			RpcStringFreeA(&pstr);
			bSuccess = true;
		}
		return bSuccess;
	}


}; // namespace VCUE

#endif // !defined(_VCUE_API_H___E35A4CFD_15D0_45B3_9455_5A8A84354584___INCLUDED_)

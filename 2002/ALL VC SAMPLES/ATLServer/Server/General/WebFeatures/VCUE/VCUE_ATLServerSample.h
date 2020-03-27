// VCUE_ATLServerSample.h
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

#if !defined(_VCUE_ATLSERVERSAMPLE_H___33410D05_1BEA_4B94_AA3C_03348238FD6B___INCLUDED_)
#define _VCUE_ATLSERVERSAMPLE_H___33410D05_1BEA_4B94_AA3C_03348238FD6B___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include <atlbase.h>
#include "VCUE_OleDbClient.h"

namespace VCUE
{
	class CModule : public CAtlDllModuleT<CModule>
	{
	public:
		BOOL WINAPI DllMain(DWORD dwReason, LPVOID lpReserved) throw()
		{
	#if defined(_M_IX86)
			if (dwReason == DLL_PROCESS_ATTACH)
			{
				// stack overflow handler
				_set_security_error_handler( AtlsSecErrHandlerFunc );
			}
	#endif
			return __super::DllMain(dwReason, lpReserved);
		}
	};

	inline bool GetModulePath(CStringA& strPath)
	{
		bool bSuccess = false;
		char szBuffer[_MAX_PATH];
		const size_t BufferCharacters = sizeof(szBuffer)/sizeof(szBuffer[0]);
		DWORD dwCharacters = GetModuleFileNameA(_AtlBaseModule.GetModuleInstance(), szBuffer, BufferCharacters);
		if (dwCharacters && (dwCharacters < BufferCharacters))
		{
			if (PathRemoveFileSpecA(szBuffer))
			{
				PathAddBackslashA(szBuffer);
				strPath = szBuffer;
				bSuccess = true;
			}
		}

		return bSuccess;
	}

	inline bool GetModuleNoExtension(CStringA& strModule)
	{
		bool bSuccess = false;
		char szBuffer[_MAX_PATH];
		const size_t BufferCharacters = sizeof(szBuffer)/sizeof(szBuffer[0]);
		DWORD dwCharacters = GetModuleFileNameA(_AtlBaseModule.GetModuleInstance(), szBuffer, BufferCharacters);
		if (dwCharacters && (dwCharacters < BufferCharacters))
		{
			PathRemoveExtensionA(szBuffer);
			strModule = szBuffer;
			bSuccess = true;
		}

		return bSuccess;
	}


	inline HRESULT InitializeDbSession(CSession& theSession, const CString& strSettings)
	{
		HRESULT hr = E_UNEXPECTED;
		CStringA strInitializationFile;
		if (!GetModulePath(strInitializationFile))
			strInitializationFile = _T("C:\\");
		
		strInitializationFile += strSettings;

		USES_CONVERSION;
		CDataSource theConnection;
		hr = theConnection.OpenFromFileName(A2CW(strInitializationFile));
		if (OleDbSucceeded(hr))
		{
			hr = theSession.Open(theConnection);
			ATLASSERT(OleDbSucceeded(hr));
		}

		return hr;
	}

	inline HRESULT InitializeDbSession(CSession& theSession)
	{
		HRESULT hr = E_UNEXPECTED;
		CStringA strInitializationFile;
		if (GetModuleNoExtension(strInitializationFile))
			strInitializationFile += _T(".udl");
		else
			strInitializationFile = _T("C:\\ATLServer.udl");

		USES_CONVERSION;
		CDataSource theConnection;
		hr = theConnection.OpenFromFileName(A2CW(strInitializationFile));
		if (OleDbSucceeded(hr))
		{
			hr = theSession.Open(theConnection);
			ATLASSERT(OleDbSucceeded(hr));
		}

		return hr;
	}

}; // namespace VCUE

#endif // !defined(_VCUE_ATLSERVERSAMPLE_H___33410D05_1BEA_4B94_AA3C_03348238FD6B___INCLUDED_)

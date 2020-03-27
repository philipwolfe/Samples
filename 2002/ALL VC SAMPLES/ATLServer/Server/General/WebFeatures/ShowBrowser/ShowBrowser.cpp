// ShowBrowser.cpp : Defines the entry point for the DLL application.
// (c) 2000 Microsoft Corporation
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "..\VCUE\VCUE_ErrorString.h"
#include "..\VCUE\VCUE_RequestHandler.h"
#include "..\VCUE\VCUE_Conversion.h"
#include "..\VCUE\VCUE_Time.h"
#include "..\VCUE\VCUE_AtlServerSample.h"
using namespace VCUE;

VCUE::CModule _Module;

// For custom assert and trace handling with WebDbg
#ifdef _DEBUG
CDebugReportHook g_ReportHook;
#endif


/////////////////////////////////////////////////////////////////////////////
// DLL Entry Point

extern "C"
BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	hInstance;
	return _Module.DllMain(dwReason, lpReserved); 
}


#define STREAM_BOOL_CAPABILITY( ItemName )							\
		hr = pBrowser->##ItemName(&bResult);	\
		if(SUCCEEDED(hr))						\
			m_HttpResponse << "<tr><td>" << #ItemName << "</td><td>" << (bResult ? "True" : "False") << "</td></tr>\n";	\
		else														\
			m_HttpResponse << "<tr><td>" << #ItemName << "</td><td>" << "<i>Failed to get browser property. HRESULT = " << hr << " (" << GetErrorString(hr) << ")</i>" << "</td></tr>\n";


#define STREAM_BSTR_CAPABILITY( ItemName )							\
		bstrValue.Empty();											\
		hr = pBrowser->##ItemName(&bstrValue);						\
		if (SUCCEEDED(hr))											\
			m_HttpResponse << "<tr><td>" << #ItemName << "</td><td>" << ToCStringA(bstrValue) << "</td></tr>\n";	\
		else														\
			m_HttpResponse << "<tr><td>" << #ItemName << "</td><td>" << "<i>Failed to get browser property. HRESULT = " << hr << " (" << GetErrorString(hr) << ")</i>" << "</td></tr>\n";

class CShowBrowser : 
	public CCustomRequestHandler<CShowBrowser>
{
public:


	HTTP_CODE ValidateAndExchange()
	{
		// Set the headers
		m_HttpResponse.SetContentType("text/html");		
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnShowBrowser()
	{
		// Get the browser capabilities
		CComPtr<IBrowserCaps> pBrowser;
		HRESULT hr = GetBrowserCapabilities(&pBrowser);
		if (SUCCEEDED(hr))
		{
			m_HttpResponse << "<table>";
			m_HttpResponse << "<tr><th>Property</th><th>Value</th></tr>\n";

			CStringA strValue;
			m_HttpResponse << "<tr><td>HTTP_USER_AGENT</td><td>";
			if (m_HttpRequest.GetServerVariable("HTTP_USER_AGENT", strValue))											\
				m_HttpResponse << strValue;
			else
				m_HttpResponse << "<i>" << GetErrorString() << "</i>";
			m_HttpResponse << "</td></tr>\n";

			CComBSTR bstrValue;
			STREAM_BSTR_CAPABILITY(GetBrowserName);
			STREAM_BSTR_CAPABILITY(GetPlatform);
			STREAM_BSTR_CAPABILITY(GetVersion);
			STREAM_BSTR_CAPABILITY(GetMajorVer);
			STREAM_BSTR_CAPABILITY(GetMinorVer);

			BOOL bResult = FALSE;
			STREAM_BOOL_CAPABILITY(SupportsFrames);
			STREAM_BOOL_CAPABILITY(SupportsTables);
			STREAM_BOOL_CAPABILITY(SupportsCookies);
			STREAM_BOOL_CAPABILITY(SupportsBackgroundSounds);
			STREAM_BOOL_CAPABILITY(SupportsVBScript);
			STREAM_BOOL_CAPABILITY(SupportsJavaScript);
			STREAM_BOOL_CAPABILITY(SupportsJavaApplets);
			STREAM_BOOL_CAPABILITY(SupportsActiveXControls);
			STREAM_BOOL_CAPABILITY(SupportsCDF);
			STREAM_BOOL_CAPABILITY(SupportsAuthenticodeUpdate);
			STREAM_BOOL_CAPABILITY(IsBeta);
			STREAM_BOOL_CAPABILITY(IsCrawler);
			STREAM_BOOL_CAPABILITY(IsAOL);
			STREAM_BOOL_CAPABILITY(IsWin16);
			STREAM_BOOL_CAPABILITY(IsAK);
			STREAM_BOOL_CAPABILITY(IsSK);
			STREAM_BOOL_CAPABILITY(IsUpdate);

			m_HttpResponse << "</table>";
		}
		else
		{
			m_HttpResponse << "Failed to get browser capabilities. HRESULT = " << hr << " (" << GetErrorString(hr) << ")";
		}

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "ShowBrowser Sample";
		return HTTP_SUCCESS;
	}
	
	BEGIN_REPLACEMENT_METHOD_MAP(CShowBrowser)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("ShowBrowser", OnShowBrowser)
	END_REPLACEMENT_METHOD_MAP()
};

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CShowBrowser)
END_HANDLER_MAP()

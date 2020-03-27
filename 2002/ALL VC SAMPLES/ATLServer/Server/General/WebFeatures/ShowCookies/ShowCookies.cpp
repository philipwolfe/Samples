// ShowCookies.cpp : Defines the entry point for the DLL application.
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

class CShowCookies : 
	public CRequestHandlerT<CShowCookies>
{
public:

	HTTP_CODE ValidateAndExchange()
	{
		// Simple initialization - build array of cookies
		m_HttpRequest.GetRequestCookies();

		m_HttpResponse.SetContentType("text/html");
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		return HTTP_SUCCESS; // continue processing request
	}

	DWORD FormFlags()
	{
		// Don't create files if form data contains them.
		return ATL_FORM_FLAG_IGNORE_FILES;
	}

	// Handle the "ShowCookies" tag
	HTTP_CODE OnShowCookies()
	{
		const CHttpRequest::CookieMap& theCookies = m_HttpRequest.m_requestCookies;

		// Check that cookies are present
		if (theCookies.GetCount())
		{
			// Loop through the cookies displaying
			// the name and value of each cookie
			POSITION posCookie = theCookies.GetStartPosition();
			while (posCookie != NULL)
			{
				const CCookie& theCookie = theCookies.GetNextValue(posCookie);
				CStringA strName;
				BOOL bSuccess = theCookie.GetName(strName);

				if (bSuccess)
				{
					m_HttpResponse << "<tr><td>";
					m_HttpResponse << strName;
					m_HttpResponse << "</td><td>";
				
					POSITION pos = theCookie.GetFirstValuePos();
					if (pos)
					{
						// Multi-valued cookie
						CStringA strKey;
						CStringA strValue;
						m_HttpResponse << "<table><tr><th>Name</th><th>Value</th></tr>\n";
						while (pos != NULL)
						{
							theCookie.GetNextValueAssoc(pos, strKey, strValue);
							m_HttpResponse << "<tr><td>";
							m_HttpResponse << strKey;
							m_HttpResponse << "</td><td>";
							m_HttpResponse << strValue;
							m_HttpResponse << "</td></tr>\n";
						}
						m_HttpResponse << "</table>\n";
					}
					else				
					{
						// Single-valued cookie
						CStringA strValue;
						if (theCookie.GetValue(strValue))
							m_HttpResponse << strValue;
						else
							m_HttpResponse << "Failed to get cookie value";
					}
					m_HttpResponse << "</td></tr>\n";
				}

			}
		}
		else
			m_HttpResponse << "<tr><td>No cookies in the current request!</td><td></td></tr>";

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnShowCookieVariable()
	{
		CStringA strValue;
		if (m_HttpRequest.GetServerVariable("HTTP_COOKIE", strValue))											\
			m_HttpResponse << strValue;
		else
			m_HttpResponse << "<i>" << GetErrorString() << "</i>";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "ShowCookies Sample";
		return HTTP_SUCCESS;
	}

	
	BEGIN_REPLACEMENT_METHOD_MAP(CShowCookies)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("ShowCookies", OnShowCookies)
		REPLACEMENT_METHOD_ENTRY("ShowCookieVariable", OnShowCookieVariable)
	END_REPLACEMENT_METHOD_MAP()
};

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CShowCookies)
END_HANDLER_MAP()

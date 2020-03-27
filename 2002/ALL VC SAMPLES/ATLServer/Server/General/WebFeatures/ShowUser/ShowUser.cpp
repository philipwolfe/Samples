// ShowUser.cpp : Defines the entry point for the DLL application.
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
#include "..\VCUE\VCUE_ServerContext.h"
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

#define STREAM_RAW_VARIABLE( ItemName )							\
		bSuccess = m_HttpRequest.GetServerVariable(#ItemName, strValue);	\
		m_HttpResponse << "<tr><td>" << #ItemName << "</td><td>";		\
		if (bSuccess)											\
			m_HttpResponse << strValue;									\
		else													\
			m_HttpResponse << "<i>" << GetErrorString() << "</i>";	\
		m_HttpResponse << "</td></tr>\n";


class CShowUser : 
	public CCustomRequestHandler<CShowUser>
{
public:

	HTTP_CODE CheckValidRequest() throw()
	{
		// You can use m_spServerContext and m_HttpResponse here.
		// Do not use m_HttpRequest - it hasn't been initialized yet.

		// Try to get the LOGON_USER, if not present return HTTP_UNAUTHORIZED (401)
		CStringA strLogonUser;
		if (GetServerVariable(m_spServerContext, "LOGON_USER", strLogonUser))
		{
			if (strLogonUser.GetLength())
				return HTTP_SUCCESS;
		}

		return SetStatusCode(HTTP_UNAUTHORIZED);
	}

	HTTP_CODE ValidateAndExchange()
	{
		// Set the headers
		m_HttpResponse.SetContentType("text/html");		
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnShowUser()
	{
		CStringA strValue;
		BOOL bSuccess = FALSE;

		m_HttpResponse << "<table>";
		m_HttpResponse << "<tr><th>Server Variable</th><th>Value</th></tr>\n";

		STREAM_RAW_VARIABLE(AUTH_PASSWORD);
		STREAM_RAW_VARIABLE(AUTH_TYPE);
		STREAM_RAW_VARIABLE(AUTH_USER);
		STREAM_RAW_VARIABLE(HTTP_AUTHORIZATION);
		STREAM_RAW_VARIABLE(LOGON_USER);
		STREAM_RAW_VARIABLE(REMOTE_USER);

		m_HttpResponse << "</table>";

		HANDLE hToken = INVALID_HANDLE_VALUE;
		bSuccess = m_spServerContext->GetImpersonationToken(&hToken);
		m_HttpResponse << "<p>The impersonation token could " << (bSuccess ? "" : "not ") << "be obtained.</p>";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "ShowUser Sample";
		return HTTP_SUCCESS;
	}
	
	BEGIN_REPLACEMENT_METHOD_MAP(CShowUser)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("ShowUser", OnShowUser)
	END_REPLACEMENT_METHOD_MAP()
};

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CShowUser)
END_HANDLER_MAP()

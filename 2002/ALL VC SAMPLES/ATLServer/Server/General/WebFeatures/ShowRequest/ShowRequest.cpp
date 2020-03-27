// ShowRequest.cpp : Defines the entry point for the DLL application.
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
#include "..\VCUE\VCUE_Request.h"
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

class CShowRequest : 
	public CRequestHandlerT<CShowRequest>
{
public:
	HTTP_CODE ValidateAndExchange()
	{
		// Set the headers
		m_HttpResponse.SetContentType("text/html");
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		return HTTP_SUCCESS; // continue processing request
	}

	DWORD FormFlags()
	{
		// Don't create files if form data contains them.
		return ATL_FORM_FLAG_IGNORE_FILES;
	}

// These items are drawn directly from the ECB structure
#define STREAM_ITEM( ItemName )							\
		m_HttpResponse << "<tr><td>" << #ItemName << "</td>";	\
		m_HttpResponse << "<td>" << m_HttpRequest.Get##ItemName() << "</td></tr>\n";

// These items are server variables with
// explicit wrapper functions supplied 
// by CHttpRequest
#define STREAM_VARIABLE( ItemName )						\
		m_HttpRequest.Get##ItemName(strValue);			\
		m_HttpResponse << "<tr><td>" << #ItemName << "</td>";	\
		m_HttpResponse << "<td>" << strValue << "</td></tr>\n";

	HTTP_CODE OnShowRequest()
	{
		CStringA strValue;

		m_HttpResponse << "<tr><td>AbsoluteUrl</td>";
		m_HttpResponse << "<td>" << GetAbsoluteUrl(m_HttpRequest) << "</td></tr>\n";

		STREAM_VARIABLE(AcceptEncodings);
		STREAM_VARIABLE(AcceptTypes);
		STREAM_ITEM(Authenticated);
		STREAM_VARIABLE(AuthenticationType);
		STREAM_VARIABLE(AuthUserName);
		STREAM_VARIABLE(AuthUserPassword);
		STREAM_ITEM(AvailableBytes);

		// Careful not to assume nul-termination of available data
		m_HttpResponse << "<tr><td>AvailableData</td><td>";
		DWORD dwWritten = 0;
		m_HttpResponse.WriteStream(reinterpret_cast<const char*>(m_HttpRequest.GetAvailableData()), m_HttpRequest.GetAvailableBytes(), &dwWritten);
		m_HttpResponse << "</td></tr>\n";

		if (dwWritten != m_HttpRequest.GetAvailableBytes())
			m_HttpResponse << "<tr><td>Highly unexpected</td><td>Couldn't write all the data</td></tr>\n";

		STREAM_ITEM(ContentType);
		STREAM_ITEM(MethodString);	// Called TServerContext::GetRequestMethod (s/be GetMethod to match EXTENSION_CONTROL_BLOCK)
		STREAM_ITEM(PathInfo);
		STREAM_ITEM(PathTranslated);

		m_HttpResponse << "<tr><td>PhysicalScriptFolder</td>";
		m_HttpResponse << "<td>" << GetPhysicalScriptFolder(m_HttpRequest) << "</td></tr>\n";

		STREAM_ITEM(QueryString);
		STREAM_VARIABLE(ScriptName);
		STREAM_ITEM(ScriptPathTranslated);
		STREAM_ITEM(TotalBytes);
		STREAM_VARIABLE(Url);
		STREAM_VARIABLE(UrlReferer); // Deliberately misspelled to match spelling of server variable
		STREAM_VARIABLE(UserAgent);
		STREAM_VARIABLE(UserHostAddress);
		STREAM_VARIABLE(UserHostName);
		STREAM_VARIABLE(UserLanguages);
		STREAM_VARIABLE(UserName);

		m_HttpResponse << "<tr><td>VirtualScriptFolder</td>";
		m_HttpResponse << "<td>" << GetVirtualScriptFolder(m_HttpRequest) << "</td></tr>\n";

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "ShowRequest Sample";
		return HTTP_SUCCESS;
	}
	
	BEGIN_REPLACEMENT_METHOD_MAP(CShowRequest)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("ShowRequest", OnShowRequest)
	END_REPLACEMENT_METHOD_MAP()
};


BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CShowRequest)
END_HANDLER_MAP()

// ShowQueryString.cpp : Defines the entry point for the DLL application.
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

class CShowQueryString : 
	public CRequestHandlerT<CShowQueryString>
{
public:

	HTTP_CODE ValidateAndExchange()
	{
		ATLTRACE("CShowQueryString::ValidateAndExchange\n");

		// Set the headers
		m_HttpResponse.SetContentType("text/html");
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		return HTTP_SUCCESS; // continue processing request
	}

	// Handle the "ShowQueryString" tag
	HTTP_CODE OnShowQueryString()
	{
		ATLTRACE("CShowQueryString::OnShowQueryString\n");

		// Get query fields collection from the request
		const CHttpRequestParams& theFields = m_HttpRequest.GetQueryParams();

		// Check that query fields are present
		if (theFields.GetCount())
		{
			CStringA strName;
			CStringA strValue;

			// Loop through the fields displaying
			// the name and value of each field
			POSITION pos = theFields.GetStartPosition();
			while (pos != NULL)
			{
				theFields.GetNextAssoc(pos, strName, strValue);
				m_HttpResponse << "<tr><td>";
				m_HttpResponse << strName;
				m_HttpResponse << "</td><td>";
				m_HttpResponse << strValue;
				m_HttpResponse << "</td></tr>\n";
			}

		}
		else
			m_HttpResponse << "<tr><td>No query fields in the current request!</td><td></td></tr>";

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnShowQueryStringVariable()
	{
		ATLTRACE("CShowQueryString::OnShowQueryStringVariable\n");

		CStringA strValue;
		if (m_HttpRequest.GetServerVariable("QUERY_STRING", strValue))											\
			m_HttpResponse << strValue;
		else
			m_HttpResponse << "<i>" << GetErrorString() << "</i>";
		return HTTP_SUCCESS;
	}


	HTTP_CODE OnTitle()
	{
		ATLTRACE("CShowQueryString::OnTitle\n");
		m_HttpResponse << "ShowQueryString Sample";
		return HTTP_SUCCESS;
	}
	
	BEGIN_REPLACEMENT_METHOD_MAP(CShowQueryString)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("ShowQueryString", OnShowQueryString)
		REPLACEMENT_METHOD_ENTRY("ShowQueryStringVariable", OnShowQueryStringVariable)
	END_REPLACEMENT_METHOD_MAP()
};


BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CShowQueryString)
END_HANDLER_MAP()

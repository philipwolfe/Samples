// NotModified.cpp : Defines the entry point for the DLL application.
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
#include "..\VCUE\VCUE_ServerContext.h"
#include "..\VCUE\VCUE_AtlServerSample.h"
using namespace VCUE;

#include <atltime.h>

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

class CNotModified : 
	public CCustomRequestHandler<CNotModified>
{
public:

	HTTP_CODE CheckValidRequest() throw()
	{
		// You can use m_spServerContext and m_HttpResponse here.
		// Do not use m_HttpRequest - it hasn't been initialized yet.

		// If we get a conditional request, for a page received 
		// in the last minute, return a 'not modified' response.
		if (ClientHasRecentContent(m_spServerContext, 1))
			return NoProcess(HTTP_NOT_MODIFIED);

		return HTTP_SUCCESS;
	}

	HTTP_CODE ValidateAndExchange()
	{
		// Set the headers
		m_HttpResponse.SetContentType("text/html");		
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnNotModified()
	{
		m_HttpResponse << "<b>" << HttpTime() << "</b>";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "304 (Not Modified) Sample";
		return HTTP_SUCCESS;
	}
	
	BEGIN_REPLACEMENT_METHOD_MAP(CNotModified)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("NotModified", OnNotModified)
	END_REPLACEMENT_METHOD_MAP()
};

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CNotModified)
END_HANDLER_MAP()

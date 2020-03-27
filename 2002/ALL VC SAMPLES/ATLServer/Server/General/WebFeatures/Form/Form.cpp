// Form.cpp : Defines the entry point for the DLL application.
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
#include "..\VCUE\VCUE_Time.h"
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

class CForm : 
	public CRequestHandlerT<CForm>
{
public:
	CStringA strReferrer;

	HTTP_CODE ValidateAndExchange()
	{
		// Set the headers
		m_HttpResponse.SetContentType("text/html");	
		m_HttpResponse.SetExpires(0); // Prevent client-side caching
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		m_HttpRequest.GetUrlReferer(strReferrer);

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnReferrer()
	{
		m_HttpResponse << strReferrer;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "Form";
		return HTTP_SUCCESS;
	}
	
	BEGIN_REPLACEMENT_METHOD_MAP(CForm)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("Referrer", OnReferrer)
	END_REPLACEMENT_METHOD_MAP()
};


BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CForm)
END_HANDLER_MAP()

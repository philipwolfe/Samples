// SetCookies.cpp : Defines the entry point for the DLL application.
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


class CSetCookies : 
	public CRequestHandlerT<CSetCookies>
{
public:

	HTTP_CODE ValidateAndExchange()
	{
		// Simple initialization - generate cookies to send to client

		// Create a single-valued cookie
		CSessionCookie theSessionCookie("theSessionID");
		BOOL bSuccess = m_HttpResponse.AppendCookie(&theSessionCookie);
		ATLASSERT(bSuccess);

		// Create a single-valued cookie
		bSuccess = m_HttpResponse.AppendCookie("single_valued_cookie", "theValue");
		ATLASSERT(bSuccess);

		// Note that cookies without a value are allowed
		bSuccess = m_HttpResponse.AppendCookie(CCookie("novalue"));
		ATLASSERT(bSuccess);

		// Create a multi-valued cookie
		CCookie cookieMultiValued("multi_valued_cookie");

		bSuccess = cookieMultiValued.AddValue("item_one", "theFirstValue");
		ATLASSERT(bSuccess);

		bSuccess = cookieMultiValued.AddValue("item_two", "theSecondValue");
		ATLASSERT(bSuccess);

		bSuccess = m_HttpResponse.AppendCookie(&cookieMultiValued);
		ATLASSERT(bSuccess);

		// Create a persistent cookie with a timeout of 5 minutes
		CCookie cookiePersistent("persistent_cookie", "theValue");

		bSuccess = cookiePersistent.SetPath("/");
		ATLASSERT(bSuccess);

		bSuccess = cookiePersistent.SetExpires(GmtTime(5));
		ATLASSERT(bSuccess);

		bSuccess = m_HttpResponse.AppendCookie(&cookiePersistent);
		ATLASSERT(bSuccess);

		m_HttpResponse.SetContentType("text/html");
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		return HTTP_SUCCESS; // continue processing request
	}

	DWORD FormFlags()
	{
		// Don't create files if form data contains them.
		return ATL_FORM_FLAG_IGNORE_FILES;
	}

	// Handle the "SetCookies" tag
	HTTP_CODE OnSetCookies()
	{
		// Describe the cookies sent to the client
		m_HttpResponse <<
		"<P>The following cookies were sent to the client:</P>"
		"<UL>"
		"<LI>A single valued session cookie</LI>"
		"<LI>A single valued cookie</LI>"
		"<LI>A cookie without a value</LI>"
		"<LI>A multi-valued cookie</LI>"
		"<LI>A single-valued persistent cookie (expires in 5 minutes)</LI>"
		"</UL>"
		;

		return HTTP_SUCCESS;
	}
	
	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "SetCookies Sample";
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CSetCookies)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("SetCookies", OnSetCookies)
	END_REPLACEMENT_METHOD_MAP()
};

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CSetCookies)
END_HANDLER_MAP()

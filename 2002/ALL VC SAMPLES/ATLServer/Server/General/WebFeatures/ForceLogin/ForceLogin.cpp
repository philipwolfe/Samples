// ForceLogin.cpp : Defines the entry point for the DLL application.
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
#include "..\VCUE\VCUE_Encode.h"
#include "..\VCUE\VCUE_Encrypt.h"
#include "..\VCUE\VCUE_RequestHandler.h"
#include "..\VCUE\VCUE_Time.h"
#include "..\VCUE\VCUE_AtlServerSample.h"
using namespace VCUE;

VCUE::CModule _Module;

// For custom assert and trace handling with WebDbg
#ifdef _DEBUG
CDebugReportHook g_ReportHook;
#endif

// We use a special cookie to determine whether the user 
// has logged on to our site.
//
// Note that the login page should use HTTPS to protect
// names and passwords as they travel along the wire.
// If the cookie is to be used for secure identification subsequent 
// requests should also be via HTTPS. If the cookie is simply for 
// customization / logging purposes, HTTP is OK.

#define VCUE_SESSION_COOKIE_NAME				"Tr@nQui1it33"

/////////////////////////////////////////////////////////////////////////////
// DLL Entry Point


extern "C"
BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	hInstance;
	return _Module.DllMain(dwReason, lpReserved); 
}

class CLoginPage : 
	public CRequestHandlerT<CLoginPage>
{
public:

	bool m_bResource;

	DWORD FormFlags()
	{
		// Don't create files if form data contains them.
		return ATL_FORM_FLAG_IGNORE_FILES;
	}

	bool AllowLogin(LPCSTR szUserName, LPCSTR szPassword)
	{
		// To avoid extra setup steps to run this sample, we allow login if the user name and password match
		if (szUserName[0] != '\0' && (lstrcmpiA(szUserName, szPassword) == 0))
			return true;
		return false;
	}

	DWORD ValidateAndExchange()
	{
		// Get collections from the request
		const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();
		const CHttpRequestParams& QueryFields = m_HttpRequest.GetQueryParams();

		// Now get information
		LPCSTR pszUserName = FormFields.Lookup("user");
		LPCSTR pszPassword = FormFields.Lookup("password");
		LPCSTR pszResource = QueryFields.Lookup("redirect");

		m_bResource = pszResource ? true : false;

		if (pszUserName && m_bResource)
		{
			if (AllowLogin(pszUserName, pszPassword))
			{
				// Username/password is valid, so generate special cookie
				CStringA strCookieValue;
				CTimedSessionCreator<8> SessionCreator;
				HRESULT hr = SessionCreator.Create(pszUserName, pszPassword, strCookieValue);
				if (SUCCEEDED(hr))
				{
					m_HttpResponse.AppendCookie(VCUE_SESSION_COOKIE_NAME, strCookieValue);
					m_HttpResponse.Redirect(pszResource, CHttpResponse::HTTP_REDIRECT_SEE_OTHER);
					return HTTP_SUCCESS_NO_PROCESS;
				}
				
				// Unexpected failure
				ATLASSERT(false);
				return HTTP_FAIL;
			}
		}

		return HTTP_SUCCESS;
	}

	DWORD OnSubmitUrl()
	{
		// Write the current URL back into the response stream
		m_HttpResponse << GetAbsoluteUrl(m_HttpRequest);

		return HTTP_SUCCESS;
	}

	DWORD OnUserName()
	{
		// If we have been provided with a username,
		// write the value back to the file so that
		// the user doesn't have to retype it.
		LPCSTR pszUserName = m_HttpRequest.GetFormVars().Lookup("user");
		if(pszUserName)
			m_HttpResponse << pszUserName;

		return HTTP_SUCCESS;
	}
	
	DWORD OnTitle()
	{
		if (m_bResource)
			m_HttpResponse << "Login Page";
		else
			m_HttpResponse << "This page is not intended to be viewed directly.";
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CLoginPage)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("SubmitUrl", OnSubmitUrl)
		REPLACEMENT_METHOD_ENTRY("UserName", OnUserName)
	END_REPLACEMENT_METHOD_MAP()
};

class CProtectedResource : 
	public CCustomRequestHandler<CProtectedResource>
{
public:

	DWORD CheckValidRequest() throw()
	{
		// You can use m_spServerContext and m_HttpResponse here.
		// Do not use m_HttpRequest - it hasn't been initialized yet.

		// If the size of the request is unreasonably large,
		// we should return HTTP_REQUEST_ENTITY_TOO_LONG.
		// IIS protects us against 
		// unreasonably large headers, but it's up to us to limit
		// the size of the request body where necessary.

		ATLTRACE("CProtectedResource::CheckValidRequest\n");

		if (m_spServerContext->GetTotalBytes() > 10000)
			return SetStatusCode(HTTP_REQUEST_ENTITY_TOO_LONG);

		return HTTP_SUCCESS;
	}

	DWORD FormFlags()
	{
		// Don't create files if form data contains them.
		return ATL_FORM_FLAG_IGNORE_FILES;
	}

	bool RequestMeetsAccessPolicy()
	{
		CStringA szCookieValue;
		if (m_HttpRequest.Cookies(VCUE_SESSION_COOKIE_NAME).GetValue(szCookieValue))
		{
			// We only check that the cookie is present
			// A better approach would store sessions
			// in a database and check whether the cookie
			// was listed and had not expired
			if (szCookieValue.GetLength())
			{
				return true;
			}
		}
		return false;
	}

	DWORD ValidateAndExchange()
	{
		// This resource is protected
		
		// First, we perform a quick check on the request to make
		// sure that it's not an attack on the site. 

		// In this example, we just check the total size of the request.
		// If the request is considered too large, we reject it.

		// Next we validate the request against an access policy for the resource.
		// If the request we receive meets our access policy, we allow
		// access to the resource. If the request doesn't meet our access
		// policy, we redirect the user to a page that allows them to change
		// the characteristics of their request in order to gain access.

		// In this particular example, we require the user to have a 
		// special cookie. If they don't have such a cookie, we redirect
		// to a login page that will allow them to obtain the cookie.		

		if (RequestMeetsAccessPolicy())
		{
			// Set headers and continue processing the request
			m_HttpResponse.SetContentType("text/html");
			m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

			return HTTP_SUCCESS;
		}
		
		// Build up redirect URL
		CStringA strAbsoluteUrl;
		if (GetAbsoluteUrl(m_HttpRequest, strAbsoluteUrl)) // Get absolute URL of this page
		{
			CStringA strUrl;
			if (BuildAbsoluteUrl(m_HttpRequest, "loginpage.srf?redirect=", strUrl)) // Build absolute URL for login page
			{
				strUrl += strAbsoluteUrl;
				m_HttpResponse.Redirect(strUrl, CHttpResponse::HTTP_REDIRECT_SEE_OTHER);
				return HTTP_SUCCESS_NO_PROCESS;
			}
		}
		
		// Unexpected error
		ATLASSERT(false);
		return ServerError(); // Unexpected error
	}
	
	DWORD OnTitle()
	{
		m_HttpResponse << "Welcome to the protected resource!";
		return HTTP_SUCCESS;
	}
	
	BEGIN_REPLACEMENT_METHOD_MAP(CProtectedResource)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
	END_REPLACEMENT_METHOD_MAP()
};

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("ProtectedResource", CProtectedResource)
	HANDLER_ENTRY("LoginPage", CLoginPage)
END_HANDLER_MAP()


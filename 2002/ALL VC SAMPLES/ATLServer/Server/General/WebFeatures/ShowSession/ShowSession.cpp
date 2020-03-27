// ShowSession.cpp : Defines the entry point for the DLL application.
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

class CShowSession : 
	public CCustomRequestHandler<CShowSession>
{
public:

	long m_lVariableCount;
	DWORD m_dwSessionCount;
	LPCSTR m_pszName;
	CStringA m_strValue;
	bool m_bShowPut;

	HTTP_CODE ValidateAndExchange()
	{
		// Set the headers
		m_HttpResponse.SetContentType("text/html");
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		// Get the session service
		CComPtr<ISessionStateService> spSessionService;
		HRESULT hr = QueryService(&spSessionService);
		if (FAILED(hr))
			return ServerError();

		// Get or create the session for this user
		CComPtr<ISession> spSession;
		hr = EnsureGetSession(spSessionService, &spSession);
		if (FAILED(hr))
			return ServerError();

		const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();

		// Now get information
		m_pszName = FormFields.Lookup("thename");
		m_strValue.Empty();
		m_bShowPut = true;

		if (lstrcmpA("get", FormFields.Lookup("themethod")) == 0)
		{
			// must be get
			if (m_pszName)
			{
				if (m_pszName[0] != 0)
				{
					CComVariant var;
					hr = spSession->GetVariable(m_pszName, &var);
					if (SUCCEEDED(hr))
					{
						m_strValue = ToCStringA(var);
					}
					else
						m_strValue = "[not found]";
				}
			}
		}
		else if (lstrcmpA("put", FormFields.Lookup("themethod")) == 0)
		{
			// must be put
			LPCSTR pszValue = FormFields.Lookup("thevalue");

			if (m_pszName && pszValue)
			{
				if (m_pszName[0] != 0)
				{
					hr = spSession->SetVariable(m_pszName, CComVariant(pszValue)); // add or update
					if (FAILED(hr))
						return ServerError();
				}
			}

			m_bShowPut = false;
		}
		
		// Get current information about the sessions on this machine
		CComPtr<ISessionStateControl> spSessionControl;
		hr = spSessionService.QueryInterface(&spSessionControl);
		if (FAILED(hr))
			return ServerError();

		// Get the count of active sessions
		m_dwSessionCount = 0;
		hr = spSessionControl->GetSessionCount(&m_dwSessionCount);
		if (FAILED(hr))
			return ServerError();

		// Get the count of session variables
		m_lVariableCount = -1;
		hr = spSession->GetCount(&m_lVariableCount);
	//	if (FAILED(hr))
	//		return ServerError();

		return HTTP_SUCCESS;
	}


	HTTP_CODE OnShowSession()
	{
		m_HttpResponse
			<< "<p>Sessions (on this machine): " << m_dwSessionCount << "</p>"
			<< "<p>Variables (in this session): " << m_lVariableCount << "</p>"
			;

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnShowName()
	{
		if (m_pszName)
			m_HttpResponse << m_pszName;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnShowValue()
	{
		if (m_strValue.GetLength())
			m_HttpResponse << m_strValue;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnShowPut()
	{
		if (m_bShowPut)
			m_HttpResponse << "selected";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "ShowSession Sample";
		return HTTP_SUCCESS;
	}
	
	BEGIN_REPLACEMENT_METHOD_MAP(CShowSession)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("ShowSession", OnShowSession)
		REPLACEMENT_METHOD_ENTRY("ShowName", OnShowName)
		REPLACEMENT_METHOD_ENTRY("ShowValue", OnShowValue)
		REPLACEMENT_METHOD_ENTRY("ShowPut", OnShowPut)
	END_REPLACEMENT_METHOD_MAP()
};


BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CShowSession)
END_HANDLER_MAP()

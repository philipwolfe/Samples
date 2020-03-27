// ShowErrors.cpp : Defines the entry point for the DLL application.
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
#include "..\VCUE\VCUE_ErrorProvider.h"
#include "..\VCUE\VCUE_RequestHandler.h"
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

class CShowErrors : 
	public CCustomRequestHandler<CShowErrors>
{
public:

	HTTP_CODE ValidateAndExchange()
	{
		// Set the headers
		m_HttpResponse.SetContentType("text/html");
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		CStringA strHttpError;
		CStringA strSubError;

		bool bUseCustom = false;
		DWORD dwStatus = HTTP_ERROR_CODE(HTTP_SUCCESS);			// No error
		DWORD dwSubStatus = HTTP_SUBERROR_CODE(HTTP_SUCCESS);	// No error
		
		typedef CHttpRequestParams::BaseMap CStringMap;
		const CStringMap& form = m_HttpRequest.GetFormVars();

		if (form.Lookup("httperror", strHttpError))
			dwStatus = atol(strHttpError);

		if (form.Lookup("suberror", strSubError))
			dwSubStatus = atol(strSubError);
		
		if (form.Lookup("customerror", strSubError))
			bUseCustom = true;

		HTTP_CODE dwReturn = HTTP_SUCCESS;
		if (HTTP_ERROR_CODE(HTTP_SUCCESS) != HTTP_ERROR_CODE(dwStatus))
		{
			m_HttpResponse << 
				"This text is used to show that the error handling code "
				"ensures that the response buffer is cleared of existing content. "
				"You should never see this text at the client.";

			if (bUseCustom)
			{
				CCustomError theError(m_HttpRequest, m_HttpResponse);
				theError.ReturnResponse(dwStatus, dwSubStatus);

				dwReturn = SetStatusCode(dwStatus, SUBERR_NO_PROCESS);
			}
			else
				dwReturn = SetErrorCode(dwStatus, dwSubStatus); // return the requested error
		}
		
		return dwReturn;
	}

	bool WriteHttpStatusOption(DWORD dwStatus)
	{
		m_HttpResponse
				<< "<option value=\""
				<< dwStatus
				<< "\">"
				<< GetHttpStatusString(dwStatus)
				<< "</option>\n"
				;

		return true;
	}

	HTTP_CODE OnHttpErrorOptions()
	{
		// 2xx codes are successes - many of them require no response body
		// 3xx codes are redirects - browsers rarely display the response body
		// so we just write 4xx (client error) and 5xx (server error) status codes

		for (DWORD dwStatus = 400; dwStatus < 418; ++dwStatus)
			WriteHttpStatusOption(dwStatus);

		for (DWORD dwStatus = 500; dwStatus < 506; ++dwStatus)
			WriteHttpStatusOption(dwStatus);

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "ShowErrors Sample";
		return HTTP_SUCCESS;
	}
	
	BEGIN_REPLACEMENT_METHOD_MAP(CShowErrors)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("HttpErrorOptions", OnHttpErrorOptions)
	END_REPLACEMENT_METHOD_MAP()
};

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CShowErrors)
END_HANDLER_MAP()

// ShowForm.cpp : Defines the entry point for the DLL application.
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

class CShowForm : 
	public CRequestHandlerT<CShowForm>
{
public:

	DWORD FormFlags()
	{
		// Allow files of all types.
		return ATL_FORM_FLAG_NONE;
	}

	HTTP_CODE ValidateAndExchange()
	{
		// Set the headers
		m_HttpResponse.SetContentType("text/html");
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		return HTTP_SUCCESS; // continue processing request
	}

	HTTP_CODE Uninitialize(HTTP_CODE dwError)
	{
		// Ensure that all files are deleted so that we don't run out of space.
		m_HttpRequest.DeleteFiles();
		return dwError;
	}

	HTTP_CODE OnShowForm()
	{
		// Get form fields collection from the request
		const CHttpRequestParams& theFields = m_HttpRequest.GetFormVars();

		// Check that form fields are present
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
			m_HttpResponse << "<tr><td>No form fields in the current request!</td><td></td></tr>";

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "ShowForm Sample";
		return HTTP_SUCCESS;
	}

	
	BEGIN_REPLACEMENT_METHOD_MAP(CShowForm)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("ShowForm", OnShowForm)
	END_REPLACEMENT_METHOD_MAP()
};

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CShowForm)
END_HANDLER_MAP()

// ShowAccept.cpp : Defines the entry point for the DLL application.
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

#include <mlang.h>

#include "..\VCUE\VCUE_Time.h"
#include "..\VCUE\VCUE_ServerContext.h"
#include "..\VCUE\VCUE_RequestHandler.h"
#include "..\VCUE\VCUE_Request.h"
#include "..\VCUE\VCUE_Accept.h"
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


class CShowAccept : 
	public CCustomRequestHandler<CShowAccept>
{
public:

	DWORD FormFlags()
	{
		// Don't create files if form data contains them.
		return ATL_FORM_FLAG_IGNORE_FILES;
	}

	CAcceptCollection m_Languages;
	CAcceptCollection m_Encodings;
	CAcceptCollection m_Types;
	CAcceptCollection m_Charset;

	HTTP_CODE ValidateAndExchange()
	{
		CStringA strAccept;
		if (m_HttpRequest.GetUserLanguages(strAccept))
			m_Languages.Parse(strAccept);

		if (m_HttpRequest.GetAcceptEncodings(strAccept))
			m_Encodings.Parse(strAccept);

		if (m_HttpRequest.GetAcceptTypes(strAccept))
			m_Types.Parse(strAccept);

		if (m_HttpRequest.GetServerVariable("HTTP_ACCEPT_CHARSET", strAccept))
			m_Charset.Parse(strAccept);

		// Set the headers
		m_HttpResponse.SetContentType("text/html");
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		return HTTP_SUCCESS; // continue processing request
	}

	HTTP_CODE ShowAcceptCollection(const CAtlList<CAcceptItem>& theCollection, const char* szTitle)
	{
		if (theCollection.GetCount())
		{
			m_HttpResponse << "<h2>" << szTitle << "</h2>\n";
			m_HttpResponse << "<table>\n";
			m_HttpResponse << "<tr><th>Item</th><th>Priority</th></tr>\n";

			// Loop through the fields displaying
			// the name and value of each field
			POSITION pos = theCollection.GetHeadPosition();
			while (pos)
			{
				const CAcceptItem& item = theCollection.GetNext(pos);
				m_HttpResponse << "<tr><td>";
				m_HttpResponse << item.GetValue();
				m_HttpResponse << "</td><td>";
				m_HttpResponse << item.GetPriority();
				m_HttpResponse << "</td></tr>\n";
			}

			m_HttpResponse << "</table>\n";
		}

		return HTTP_SUCCESS;
	}

	// Handle the "ShowAccept" tag
	HTTP_CODE OnShowAccept()
	{
		ShowAcceptCollection(m_Languages, "Languages");
		ShowAcceptCollection(m_Encodings, "Encodings");
		ShowAcceptCollection(m_Types, "Types");
		ShowAcceptCollection(m_Charset, "Character Set");

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "ShowAccept Sample";
		return HTTP_SUCCESS;
	}
	
	BEGIN_REPLACEMENT_METHOD_MAP(CShowAccept)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("ShowAccept", OnShowAccept)
	END_REPLACEMENT_METHOD_MAP()
};

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CShowAccept)
END_HANDLER_MAP()

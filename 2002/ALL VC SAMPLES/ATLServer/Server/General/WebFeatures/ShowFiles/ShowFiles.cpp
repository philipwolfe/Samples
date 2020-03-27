// ShowFiles.cpp : Defines the entry point for the DLL application.
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

class CShowFiles : 
	public CRequestHandlerT<CShowFiles>
{
public:

	 
	//Override this function to modify the Posted data that can be recieved(to be able to recieve larger files)
	/*
	DWORD MaxFormSize()
	{		
		return DEFAULT_MAX_FORM_SIZE;		
	}
	*/
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

	HTTP_CODE OnTableHeader()
	{
		m_HttpResponse << "<tr><th>Parameter Name</th><th>File Name</th><th>Content Type</th><th>Server Location</th><th>File Size</th><th>Client Location</th></tr>\n";
		return HTTP_SUCCESS;
	}
	
	HTTP_CODE OnShowFiles()
	{
		// Get collection of files from the request
		const CHttpRequest::FileMap& theFiles = m_HttpRequest.m_Files;

		// Check that files are present
		if (theFiles.GetCount())
		{
			// Loop through the files displaying the properties
			POSITION pos = theFiles.GetStartPosition();
			while (pos != NULL)
			{
				IHttpFile* pFile = theFiles.GetNextValue(pos);
				m_HttpResponse << "<tr><td>";
				m_HttpResponse << pFile->GetParamName();
				m_HttpResponse << "</td><td>";
				m_HttpResponse << pFile->GetFileName();
				m_HttpResponse << "</td><td>";
				m_HttpResponse << pFile->GetContentType();
				m_HttpResponse << "</td><td>";
				m_HttpResponse << pFile->GetTempFileName();
				m_HttpResponse << "</td><td>";
				m_HttpResponse << pFile->GetFileSize();
				m_HttpResponse << "</td><td>";
				m_HttpResponse << pFile->GetFullFileName();
				m_HttpResponse << "</td></tr>\n";
			}

		}
		else
			m_HttpResponse << "<tr><td>No files in the current request!</td><td></td><td></td><td></td><td></td><td></td></tr>";

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "ShowFiles Sample";
		return HTTP_SUCCESS;
	}

	
	BEGIN_REPLACEMENT_METHOD_MAP(CShowFiles)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("ShowFiles", OnShowFiles)
		REPLACEMENT_METHOD_ENTRY("TableHeader", OnTableHeader)
	END_REPLACEMENT_METHOD_MAP()
};

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CShowFiles)
END_HANDLER_MAP()

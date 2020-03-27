// ShowImage.cpp : Defines the entry point for the DLL application.
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

// Compiler cannot distinguish between AtlAlign<size_t, ULONG> and AtlAlign<UINT, ULONG>
// which causes a warning.  Can be safely disabled.
#pragma warning(push)
#pragma warning(disable:4267) // conversion from 'size_t' to 'UINT', possible loss of data
#include <atlimage.h>
#pragma warning(pop)

#include "..\VCUE\VCUE_Time.h"
#include "..\VCUE\VCUE_ServerContext.h"
#include "..\VCUE\VCUE_RequestHandler.h"
#include "..\VCUE\VCUE_Request.h"
#include "..\VCUE\VCUE_FileStream.h"
#include "..\VCUE\VCUE_API.h"
#include "..\VCUE\VCUE_Photonicity.h"
#include "..\VCUE\VCUE_AtlServerSample.h"

using namespace VCUE;
using namespace VCUE::Photonicity;

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


class CShowImage : 
	public CCustomRequestHandler<CShowImage>
{
public:

	DWORD FormFlags()
	{
		// Allow files of all types.
		return ATL_FORM_FLAG_NONE;
	}

	DWORD MaxFormSize()
	{
		// Allow at most 5 MB of data, but individual files are limited to 1 MB (see below)
		return 5 * 1024 * 1024;
	}

	CSession m_Session;

	CAtlArray<LONG> arrID;
	CAtlArray<IHttpFile*> arrTooLarge;
	CAtlArray<IHttpFile*> arrNoLoad;
	CAtlArray<IHttpFile*> arrNoSave;
	CAtlArray<IHttpFile*> arrNoDB;
	CAtlArray<IHttpFile*> arrSuccess;
	CAtlArray<LONG> arrIDs;

	HTTP_CODE SendImageOrError(CSession& theSession, LONG lID)
	{
		HTTP_CODE dwReturn = HTTP_FAIL;
		bool bSendBody = (m_HttpRequest.GetMethod() != CHttpRequest::HTTP_METHOD_HEAD);
		HRESULT hr = SendImage(theSession, lID, m_HttpResponse, bSendBody);

		switch (hr)
		{
		case S_OK:				// image sent
			dwReturn = HTTP_SUCCESS_NO_PROCESS;
			break;
		case S_FALSE:			// not modified
			dwReturn = NoProcess(HTTP_NOT_MODIFIED);
			break;
		case DB_S_ENDOFROWSET:	// no image with that ID
			PreventClientResponseCaching();
			if (bSendBody)
			{
				m_HttpResponse.SetContentType("text/html");
				m_HttpResponse << "<html><body>No image: " << lID << "</body></html>";
			}
			dwReturn = NoProcess(HTTP_NOT_FOUND);
			m_HttpResponse.Flush();
			break;
		default:				// unexpected error
			ATLASSERT(false);
			dwReturn = ServerError();
			break;
		}

		return dwReturn;
	}


	HTTP_CODE ValidateAndExchange()
	{
		HRESULT hr = InitializeDbSession(m_Session);
		if (FAILED(hr))
			return ServerError();

		typedef CHttpRequestParams::BaseMap CStringMap;
		const CStringMap& form = m_HttpRequest.GetFormVars();

		CStringA strID;
		LONG lID = 0;
		if (form.Lookup("id", strID))
			lID = atol(strID);

		if (lID)
			return SendImageOrError(m_Session, lID);


		// Get collection of files from the request
		const CHttpRequest::FileMap& theFiles = m_HttpRequest.m_Files;

		// Check that files are present
		if (theFiles.GetCount())
		{
			// Loop through the files
			POSITION pos = theFiles.GetStartPosition();
			while (pos != NULL)
			{
				IHttpFile* pFile = theFiles.GetNextValue(pos);
				if (pFile->GetFileSize() > (1024 * 1024)) // Files must be less than 1MB (choose not to let ATL Server handle size, so that we can give user info about the files we've rejected)
				{
					arrTooLarge.Add(pFile);
					continue;
				}

				CImage image;
				if (FAILED(image.Load(CA2CT(pFile->GetTempFileName()))))
				{
					arrNoLoad.Add(pFile);
					continue;
				}

				CString strTempFileName;
				if (FAILED(GetFullTempFileName(strTempFileName)))
					return ServerError();

				if (FAILED(image.Save(strTempFileName, Gdiplus::ImageFormatPNG)))
				{
					arrNoSave.Add(pFile);
					DeleteFile(strTempFileName);
					continue;
				}

				image.Load(strTempFileName);

				CAtlFile theFile;
			
				hr = theFile.Create(strTempFileName, GENERIC_READ, FILE_SHARE_READ,
							OPEN_EXISTING, FILE_FLAG_SEQUENTIAL_SCAN);

				if (SUCCEEDED(hr))
				{
					ULONGLONG lBytes = 0;
					hr = theFile.GetSize(lBytes);
					if (SUCCEEDED(hr))
					{
						CStreamOnFile stream;
						hr = stream.Initialize(theFile);
						if (SUCCEEDED(hr))
						{
							const LONG lPngFormatId = 2;
							const LONG lRandomUserId = 99;

							LONG lID = 0;
							CSprocInsertImage sprocInsert;
							hr = sprocInsert.Execute(
								m_Session,
								&stream, static_cast<LONG>(lBytes), image.GetWidth(), image.GetHeight(),
								image.GetBPP(), lPngFormatId, lRandomUserId, lID);
							if (SUCCEEDED(hr))
							{
								arrIDs.Add(lID);
								arrSuccess.Add(pFile);
							}
							else
								arrNoDB.Add(pFile);
						}
					}
					theFile.Close();
				}

				DeleteFile(strTempFileName);
			}

		}

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
		m_HttpResponse << "<table>\n<tr><th>Parameter Name</th><th>File Name</th><th>Content Type</th><th>Server Location</th><th>File Size</th><th>Client Location</th></tr>\n";
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTableFooter()
	{
		m_HttpResponse << "</table>\n";
		return HTTP_SUCCESS;
	}
	
	HTTP_CODE WriteHttpFileArray(const CAtlArray<IHttpFile*>& arr, const char* szCaption)
	{
		if (arr.GetCount())
		{
			m_HttpResponse << "<h2>" << szCaption << "</h2>\n";
			OnTableHeader();
			for (unsigned int nIndex = 0; nIndex < arr.GetCount(); ++nIndex)
			{
				WriteHttpFile(arr[nIndex]);
			}
			OnTableFooter();
		}
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnShowImage()
	{
		WriteHttpFileArray(arrTooLarge, "These files were too large:");
		WriteHttpFileArray(arrNoLoad, "These files could not be opened as images:");
		WriteHttpFileArray(arrNoSave, "These files could not be converted:");
		WriteHttpFileArray(arrNoDB, "An unexpected database error occurred while processing these files:");
		WriteHttpFileArray(arrSuccess, "These files were successfully converted and added to the database:");

		if (arrIDs.GetCount())
		{
			m_HttpResponse << "<h2>Here you can see the converted images from the database:</h2>\n";
			for (unsigned int nIndex = 0; nIndex < arrIDs.GetCount(); ++nIndex)
			{
				m_HttpResponse << "<p><img src = \"showimage.srf?id=" << arrIDs[nIndex] << "\"></p>\n";
			}
		}

		return HTTP_SUCCESS;
	}

	HTTP_CODE WriteHttpFile(IHttpFile* pFile)
	{
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
				WriteHttpFile(pFile);
			}

		}
		else
			m_HttpResponse << "<tr><td>No files in the current request!</td><td></td><td></td><td></td><td></td><td></td></tr>";

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << "ShowImage Sample";
		return HTTP_SUCCESS;
	}
	
	BEGIN_REPLACEMENT_METHOD_MAP(CShowImage)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("ShowImage", OnShowImage)
		REPLACEMENT_METHOD_ENTRY("TableHeader", OnTableHeader)
		REPLACEMENT_METHOD_ENTRY("ShowFiles", OnShowFiles)
		REPLACEMENT_METHOD_ENTRY("TableFooter", OnTableFooter)
	END_REPLACEMENT_METHOD_MAP()
};

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CShowImage)
END_HANDLER_MAP()

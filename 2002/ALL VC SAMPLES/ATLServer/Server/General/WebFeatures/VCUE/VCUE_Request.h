// VCUE_Request.h
// (c) 2000 Microsoft Corporation
//
//////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(_VCUE_REQUEST_H___89C9471F_C886_11D3_BACC_00C04F8EC847___INCLUDED_)
#define _VCUE_REQUEST_H___89C9471F_C886_11D3_BACC_00C04F8EC847___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include <atlisapi.h>

namespace VCUE
{
	// Call this function to retrieve the protocol used for the current request.
	// Returns true on success, false on failure.
	// The protocol returned by this function is lowercase and versionless allowing
	// it to be used to build up URLs or display to users.
	inline bool GetProtocol(CHttpRequest& theRequest, CStringA& strProtocol)
	{
		bool bSuccess = false;

		CStringA strVariable;

		// Get the protocol string
		if (theRequest.GetServerVariable("SERVER_PROTOCOL", strVariable))
		{
			// Remove the version
			int nFound = strVariable.Find('/');
			if (nFound != -1)
				strProtocol = strVariable.Left(nFound);
			else
				strProtocol = strVariable;

			// Prettify
			strProtocol.MakeLower();

			// Success!
			bSuccess = true;
		}

		return bSuccess;
	}

	// Return protocol directly (or empty string on failure).
	inline CStringA GetProtocol(CHttpRequest& theRequest)
	{
		CStringA strProtocol;
		if (!GetProtocol(theRequest, strProtocol))
			strProtocol = "";
		
		return strProtocol;
	}

	// Call this function to retrieve the URL for the root folder.
	// (e.g. http://www.microsoft.com/)
	// Returns true on success, false on failure.
	inline bool GetRootUrl(CHttpRequest& theRequest, CStringA& strRootUrl)
	{
		bool bSuccess = false;

		// Start with the protocol string
		if (GetProtocol(theRequest, strRootUrl))
		{
			// Get the host and the port
			CStringA strVariable;
			if (theRequest.GetServerVariable("HTTP_HOST", strVariable))
			{
				// Add protocol separator
				strRootUrl += "://";

				// Add the host and the port
				strRootUrl += strVariable;

				// Add slash
				strRootUrl += "/";

				bSuccess = true;
			}
		}
		return bSuccess;
	}

	// Return root URL directly (or empty string on failure).
	inline CStringA GetRootUrl(CHttpRequest& theRequest)
	{
		CStringA strRootUrl;
		if (!GetRootUrl(theRequest, strRootUrl))
			strRootUrl = "";
		
		return strRootUrl;
	}


	// Call this function to retrieve the absolute URL for the current request.
	// Returns true on success, false on failure
	// The absolute URL of the current request is a string representation of the URL
	// that can be output as an A link in an HTML page or used for redirecting back to
	// the current resource. The absolute URL includes the protocol, server, port, path
	// and query string for the current request.
	inline bool GetAbsoluteUrl(CHttpRequest& theRequest, CStringA& strAbsoluteUrl)
	{
		bool bSuccess = false;

		// Start with the protocol string
		if (GetProtocol(theRequest, strAbsoluteUrl))
		{
			// Get the host and the port
			CStringA strVariable;
			if (theRequest.GetServerVariable("HTTP_HOST", strVariable))
			{
				// Add protocol separator
				strAbsoluteUrl += "://";

				// Add the host and the port
				strAbsoluteUrl += strVariable;

				// Add the path info and query string
				if (theRequest.GetServerVariable("HTTP_URL", strVariable))
				{
					strAbsoluteUrl += strVariable;

					// Success!
					bSuccess = true;
				}
			}
		}
		
		return bSuccess;
	}

	// Return URL directly (or empty string on failure).
	inline CStringA GetAbsoluteUrl(CHttpRequest& theRequest)
	{
		CStringA strAbsoluteUrl;
		if (!GetAbsoluteUrl(theRequest, strAbsoluteUrl))
			strAbsoluteUrl = "";
		
		return strAbsoluteUrl;
	}

	// Call this function to retrieve the virtual folder of the current script
	// Returns true on success, false on failure
	inline bool GetVirtualScriptFolder(CHttpRequest& theRequest, CStringA& strVirtualFolder)
	{
		bool bSuccess = false;
		if (theRequest.GetScriptName(strVirtualFolder))
		{
			int nFound = strVirtualFolder.ReverseFind('/');
			if (nFound != -1)
				strVirtualFolder = strVirtualFolder.Left(nFound + 1);
			else
				strVirtualFolder += '/';

			// Success!
			bSuccess = true;
		}
		return bSuccess;
	}

	// Return virtual script folder directly (or empty string on failure).
	inline CStringA GetVirtualScriptFolder(CHttpRequest& theRequest)
	{
		CStringA strVirtualScriptFolder;
		if (!GetVirtualScriptFolder(theRequest, strVirtualScriptFolder))
			strVirtualScriptFolder = "";
		
		return strVirtualScriptFolder;
	}

	// Call this function to retrieve the physical folder of the current script
	// Returns true on success, false on failure
	inline bool GetPhysicalScriptFolder(CHttpRequest& theRequest, CStringA& strPhysicalFolder)
	{
		bool bSuccess = false;
		strPhysicalFolder = theRequest.GetScriptPathTranslated();
		if (strPhysicalFolder.GetLength())
		{
			int nFound = strPhysicalFolder.ReverseFind('\\');
			if (nFound != -1)
				strPhysicalFolder = strPhysicalFolder.Left(nFound + 1);
			else
				strPhysicalFolder += '\\';

			// Success!
			bSuccess = true;
		}
		return bSuccess;
	}

	// Return physical script folder directly (or empty string on failure).
	inline CStringA GetPhysicalScriptFolder(CHttpRequest& theRequest)
	{
		CStringA strPhysicalScriptFolder;
		if (!GetPhysicalScriptFolder(theRequest, strPhysicalScriptFolder))
			strPhysicalScriptFolder = "";
		
		return strPhysicalScriptFolder;
	}


	// Call this function to build an absolute URL from a resource located
	// in the same virtual folder as the current script.
	// Returns true on success, false on failure
	inline bool BuildAbsoluteUrl(CHttpRequest& theRequest, const char* szResource, CStringA& strFullPath)
	{
		bool bSuccess = false;

		// Start with protocol
		if (GetProtocol(theRequest, strFullPath))
		{
			// Get host and port
			CStringA strVariable;
			if (theRequest.GetServerVariable("HTTP_HOST", strVariable))
			{
				// Add protocol separator
				strFullPath += "://";

				// Add host and port
				strFullPath += strVariable;

				// Get virtual folder
				if (GetVirtualScriptFolder(theRequest, strVariable))
				{
					// Add virtual folder
					strFullPath += strVariable;

					// Add resource
					strFullPath += szResource;

					// Success!
					bSuccess = true;
				}
			}
		}
		return bSuccess;
	}

	// Return the URL directly (or empty string on failure).
	inline CStringA BuildAbsoluteUrl(CHttpRequest& theRequest, const char* szResource)
	{
		CStringA strAbsoluteUrl;
		if (!BuildAbsoluteUrl(theRequest, szResource, strAbsoluteUrl))
			strAbsoluteUrl = "";
		
		return strAbsoluteUrl;
	}


} // namespace VCUE

#endif // !defined(_VCUE_REQUEST_H___89C9471F_C886_11D3_BACC_00C04F8EC847___INCLUDED_)

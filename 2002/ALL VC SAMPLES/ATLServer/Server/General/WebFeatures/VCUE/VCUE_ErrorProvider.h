// VCUE_ErrorProvider.h
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

#if !defined(_VCUE_ERRORPROVIDER_H___FE77E054_D374_11D3_BAD8_00C04F8EC847___INCLUDED_)
#define _VCUE_ERRORPROVIDER_H___FE77E054_D374_11D3_BAD8_00C04F8EC847___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include "VCUE_Request.h"
#include "VCUE_Time.h"
#include "VCUE_Response.h"

namespace VCUE
{
	// This class can be used to send custom errors back
	// to the client.
	class CCustomError
	{
	protected:
		CHttpRequest& m_request;
		CHttpResponse& m_response;

	public:

		CCustomError(CHttpRequest& request, CHttpResponse& response)
			: m_request(request), m_response(response)
		{
			// Clear the current response headers and body
			m_response.ClearResponse();

			// Try to prevent caching of this response
			// by setting the cache-control and expires headers.
			// (Note that headers may already have been sent,
			// so this may not work, but it's worth a try).
			m_response.SetCacheControl("no-cache");
			m_response.SetExpires(0);
		}


	public:
		// Call this function to return an error response to the client.
		//
		// This function tries to generate the response in one of three ways:
		// 1. Transmit a file from the local errors folder.
		// 2. Transmit a file from the errors folder for the site.
		// 3. Generate a generic response
		//
		// Don't forget to add meta information to your error files
		// to prevent robots from indexing them.
		bool ReturnResponse(DWORD dwStatus = 500, DWORD dwSubStatus = 0)
		{
			bool bSuccess = false;

			// Set the status of the response
			m_response.SetStatusCode(dwStatus);

			// Don't send a body with head requests
			if (m_request.GetMethod() == CHttpRequest::HTTP_METHOD_HEAD)
			{
					// Call Flush to ensure headers are sent
					m_response.Flush();
					bSuccess = true;
			}
			else
			{
				CStringA strFile;
				if (dwSubStatus)
					strFile.Format("%u-%u.htm", dwStatus, dwSubStatus);
				else
					strFile.Format("%u.htm", dwStatus);

				// First try finding error file close to the current script
				CStringA strLocal("errors\\");
				strLocal += strFile;

				if (SynchronousTransmitFile(m_response, strLocal))
					bSuccess = true;
				else
				{
					// Now try finding error file for site
					CStringA strRoot;

					if (m_request.GetServerVariable("APPL_PHYSICAL_PATH", strRoot))
					{
						strRoot += strLocal;

						if (SynchronousTransmitFile(m_response, strRoot))
							bSuccess = true;
						else
						{
							// Finally, generate a response
							bSuccess = GenerateResponse(dwStatus, dwSubStatus);

							// Send response
							m_response.Flush();
						}
					}
				}

			}
			
			return bSuccess;
		}


	private:
		bool GenerateResponse(DWORD dwStatus = 500, DWORD dwSubStatus = 0)
		{
			// Headers and status code have been configured and HEAD requests have been filtered
			LPCSTR szHttpStatus = NULL;
			CDefaultErrorProvider::GetErrorText(dwStatus, dwSubStatus, &szHttpStatus, NULL);

			CStringA strTime = HttpTime();

			m_response 
				<< 
				"<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 3.2 Final//EN\">\n"
				"<html>\n"
				"<head>\n"
				"<style>\n"
				"a:link			{font:8pt/11pt verdana; color:FF0000}\n"
				"a:visited		{font:8pt/11pt verdana; color:#4e4e4e}\n"
				"</style>\n"
				"\n"
				"<meta http-equiv=\"Content-Type\" Content=\"text-html; charset=Windows-1252\">\n"
				"<meta name=\"robots\" content=\"noindex\">\n"
				"\n"
				"<title>The page cannot be displayed</title>\n"
				"\n"
				"</head>\n"
				"\n"
				"<script>\n"
				"<!--\n"
				"function NiceBrowser()\n"
				"{\n"
				"	if (!((window.navigator.userAgent.indexOf(\"MSIE\") > 0) && (window.navigator.appVersion.charAt(0) == \"2\")))\n"
				"		return true;\n"
				"	else\n"
				"		return false;\n"
				"}\n"
				"function Homepage()\n"
				"{\n"
				"	if (NiceBrowser())\n"
				"	{\n"
				"		var serverName = document.location.hostname;\n"
				"		var serverURL = document.location.protocol + \"//\" + document.location.host;\n"
				"		document.write(\"<a href=\\\"\" + serverURL + \"\\\">\" + serverName + \"</a>\");\n"
				"	}\n"
				"}\n"
				"function Thispage()\n"
				"{\n"
				"	if (NiceBrowser())\n"
				"	{\n"
				"		document.write(\"<li>Page - \" + document.location.href + \"</li>\");\n"
				"	}\n"
				"}\n"
				"//-->\n"
				"</script>\n"
				"\n"
				"<body bgcolor=\"FFFFFF\">\n"
				"\n"
				"<table width=\"410\" cellpadding=\"3\" cellspacing=\"5\">\n"
				"\n"
				"<tr>\n"
					"<td align=\"left\" valign=\"middle\" width=\"360\">\n"
						"<h1 style=\"COLOR:000000; FONT: 13pt/15pt verdana\">"
						"The page cannot be displayed"
						"</h1>\n"
					"</td>\n"
				"</tr>\n"
				"\n"
				"<tr>\n"
					"<td width=\"400\" colspan=\"2\">\n"
						"<font style=\"COLOR:000000; FONT: 8pt/11pt verdana\">"
							"The page you are looking for is currently unavailable. "
							"The page may not exist, the web site might be experiencing technical difficulties, "
							"or you may need to adjust your browser settings."
						"</font>"
					"</td>\n"
				"</tr>\n"
				"\n"
				"<tr>\n"
				"<td width=\"400\" colspan=\"2\">\n"
				"<font style=\"COLOR:000000; FONT: 8pt/11pt verdana\">\n"
				"\n"
				"<hr color=\"#C0C0C0\" noshade>\n"
				"\n"
				"<p>Please try the following:</p>\n"
				"<ul>\n"
					"<li>"
						"Click the "
						"<a href=\"javascript:location.reload()\">Refresh</a>"
						" button, or try again later."
					"</li>\n"
					"<li>"
						"If you typed the page address, make sure that it is spelled correctly."
					"</li>\n"
					"<li>"
						"Click the  Back button to try another link"
					"</li>\n"
					"<li>"
						"Open the\n"
						"<script>\n"
						"<!--\n"
						"Homepage();\n"
						"//-->\n"
						"</script>\n"
						"home page, and then look for links to the information you want."
					"</li>\n"
					"\n"
				"</ul>\n"
				"\n"
				"<hr color=\"#C0C0C0\" noshade>\n"
				"\n"
				"<p>Technical Information (for support personnel)</p>\n"
				"\n"
				"<ul>\n"
					"<li>"
						"Details:\n"
						"<ul>\n"
						"<script>\n"
						"<!--\n"
						"Thispage();\n"
						"//-->\n"
						"</script>\n"
						"<li>Time - " << strTime << "</li>\n"
						"<li>HTTP " << dwStatus << " - " << szHttpStatus << "</li>\n"
						"<li>Subcode " << dwSubStatus << "</li>\n"
						"<li>Source - ATL Server</li>\n"
						"</ul>\n"
					"</li>\n"
					"<li>"
						"More information:\n"
						"<ul>"
						"<li><a href=\"http://manta\" target=\"_blank\">ATL Server Technical Support</a></li>\n"
						"</ul>"
					"</li>\n"
				"</ul>\n"
				"\n"
				"</font></td>\n"
				"</tr>\n"
				"\n"
				"</table>\n"
				"</body>\n"
				"</html>\n"
			;

			return true;
		}	
	};

} // namespace VCUE
#endif // !defined(_VCUE_ERRORPROVIDER_H___FE77E054_D374_11D3_BAD8_00C04F8EC847___INCLUDED_)

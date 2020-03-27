// ConfirmUser.cpp : Defines the entry point for the DLL application.
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

#include <atlsmtpconnection.h>

#include "..\VCUE\VCUE_API.h"
#include "..\VCUE\VCUE_Time.h"
#include "..\VCUE\VCUE_OleDbClient.h"
#include "..\VCUE\VCUE_ServerContext.h"
#include "..\VCUE\VCUE_RequestHandler.h"
#include "..\VCUE\VCUE_Request.h"
#include "..\VCUE\VCUE_AtlServerSample.h"

using namespace VCUE;

#include "ConfirmUserDB.h"

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


class CConfirmUser : 
	public CCustomRequestHandler<CConfirmUser>
{
public:

	CSession m_Session;
	CStringA m_strName;
	CStringA m_strTitle;
	CStringA m_strAction;
	CStringA m_strInformation;
	bool m_bShowUserDetail;

	DWORD FormFlags()
	{
		// Don't create files if form data contains them.
		return ATL_FORM_FLAG_IGNORE_FILES;
	}

	bool InitializeForConfirmation(const CStringA& str)
	{
		m_strTitle = "Please log in to confirm your registration";

		m_strAction = "<input type=\"hidden\" name=\"confirm\" value=\"";
		m_strAction += str;
		m_strAction += "\">";

		m_bShowUserDetail = false;

		return true;
	}

	HTTP_CODE ValidateAndExchange()
	{
		m_bShowUserDetail = true;
		PreventClientResponseCaching();

		HRESULT hr = InitializeDbSession(m_Session);
		if (FAILED(hr))
			return ServerError();

		const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();
		const CHttpRequestParams& QueryFields = m_HttpRequest.GetQueryParams();

		CStringA str;
		str = QueryFields.Lookup("showconfirm");
		if (str.GetLength())
		{
			InitializeForConfirmation(str);
			return HTTP_SUCCESS;
		}

		m_strName = FormFields.Lookup("user");
		CStringA strPassword = FormFields.Lookup("password");

		CStringA strGuid = FormFields.Lookup("confirm");
		if (strGuid.GetLength())
		{
			InitializeForConfirmation(strGuid);
			return Confirm(m_strName, strPassword, strGuid);
		}

		if (FormFields.Lookup("user") && FormFields.Lookup("password") && FormFields.Lookup("email"))
		{
			CStringA strEmail = FormFields.Lookup("email");
			return AddUser(m_strName, strPassword, strEmail);
		}

		// Set the headers
		m_HttpResponse.SetContentType("text/html");
		m_HttpResponse.AppendHeader("Last-Modified", HttpTime());

		return HTTP_SUCCESS; // continue processing request
	}


	HTTP_CODE Confirm(const CStringA& strName, const CStringA& strPassword, const CStringA& strGuid)
	{
		GUID guid = {0};
		if (!GuidFromString(strGuid, guid))
		{
			return ClientError(); // bogus guids aren't our fault
		}

		LONG lID = 0;
		CSprocConfirmUser sprocConfirm;
		HRESULT hr = sprocConfirm.Execute(
			m_Session, 
			strName, 
			strPassword, 
			guid, 
			lID);

		if (FAILED(hr))
			return ServerError();

		if (lID)
		{
			m_HttpResponse << 
				"<html><body>"
				"Your account details have been confirmed "
				"and you're all signed up. Congratulations!</body></html>";
			m_HttpResponse.Flush();
			return HTTP_SUCCESS_NO_PROCESS;
		}

		m_strInformation = "<p>Your user name or password are incorrect. Please try again.</p>";
		return HTTP_SUCCESS;
	}

	HTTP_CODE AddUser(const CStringA& strName, const CStringA& strPassword, const CStringA& strEmail)
	{
		CSprocAddUser sprocAdd;
		HRESULT hr = sprocAdd.Execute(
			m_Session, 
			strName, 
			strPassword, 
			strEmail);

		if (FAILED(hr))
			return ServerError();

		if (InlineIsEqualGUID(sprocAdd.m_GUID, GUID_NULL))
		{
			m_strInformation = "<p>Your user name is already taken. Please try another.</p>";
			return HTTP_SUCCESS;
		}

		CStringA strGuid;
		if (!StringFromGuid(sprocAdd.m_GUID, strGuid))
		{
			m_strInformation = "<p>We're having some trouble. Please try again.</p>";
			return HTTP_SUCCESS;
		}

		CStringA strUrl = BuildAbsoluteUrl(m_HttpRequest, "confirmuser.srf?showconfirm=");
		strUrl += strGuid;

		CStringA strMessage(
			"Please go to the following URL and enter your user name and password "
			"to confirm your signup to our service:\n"
			);
		strMessage += strUrl;


		#define _QUOTE(x) # x
		#define QUOTE(x) _QUOTE(x)
		#define __FILE__LINE__ __FILE__ "(" QUOTE(__LINE__) ") : "

		#pragma message(__FILE__LINE__ "warning VCUESample002 : Change the SMTP server and sender to match the configuration of your system.")

		CMimeMessage msg;
		msg.SetSender(_T("vcue_atlserver_sample@microsoft.com"));
		msg.SetSubject(_T("Signup Confirmation"));
		msg.AddRecipient(CA2CT(static_cast<LPCSTR>(strEmail)), CA2CT(static_cast<LPCSTR>(strName)));

		msg.AddText(CA2CT(static_cast<LPCSTR>(strMessage)));

		CSMTPConnection connection;

		if (!connection.Connect(_T("smarthost")))
		{
			m_HttpResponse << "Could Not Connect To Server\r\n";
			return HTTP_SUCCESS_NO_PROCESS;
		}

		if (!connection.SendMessage(msg))
		{
			m_HttpResponse << "Failed To Send Message!\r\n";
			return HTTP_SUCCESS_NO_PROCESS;
		}

		m_HttpResponse 
			<< 
			"<html><body>"
			"<p>Your user name is available.</p> "
			"<p>To complete the signup process, "
			"follow the instructions contained in the email "
			"that you will receive from us shortly at the following address:</p>"
			<<
			strEmail
			<<
			"</body></html>";
		m_HttpResponse.Flush();
		return HTTP_SUCCESS_NO_PROCESS;
	}

	HTTP_CODE OnTitle()
	{
		m_HttpResponse << (m_strTitle.GetLength() ? m_strTitle : "ConfirmUser Sample");
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnUserName()
	{
		m_HttpResponse << m_strName;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnInformation()
	{
		m_HttpResponse << m_strInformation;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnAction()
	{
		m_HttpResponse << m_strAction;
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnShowUserDetail()
	{
		return m_bShowUserDetail ? HTTP_SUCCESS : HTTP_S_FALSE;
	}
	
	BEGIN_REPLACEMENT_METHOD_MAP(CConfirmUser)
		REPLACEMENT_METHOD_ENTRY("Title", OnTitle)
		REPLACEMENT_METHOD_ENTRY("UserName", OnUserName)
		REPLACEMENT_METHOD_ENTRY("Information", OnInformation)
		REPLACEMENT_METHOD_ENTRY("Action", OnAction)
		REPLACEMENT_METHOD_ENTRY("ShowUserDetail", OnShowUserDetail)
	END_REPLACEMENT_METHOD_MAP()
};

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CConfirmUser)
END_HANDLER_MAP()

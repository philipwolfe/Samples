// ForgotPassHandler.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "ForgotPassDB.h"

// class CForgetPassHandler
// This handler is responsible for emailing passwords to users who forget them.
[ request_handler("ForgotPass") ]
class CForgotPassHandler : public CMantaWebBase<CForgotPassHandler>
{
private:
	CStringA m_strEmail;		// User's email address
	CStringA m_strFirstName;	// User's first name
	CStringA m_strLastName;		// User's last name
	CStringA m_strHint;			// User's password hint
	bool m_bFailed;				// Boolean to specify if there was an error
	bool m_bMessageSent;		// Boolean to specify if the message was sent
	
public:
	HTTP_CODE ValidateAndExchange()
	{
		// Set the content type to html
		m_HttpResponse.SetContentType("text/html");

		// Get the cached data connection
		HRESULT hr = GetDataConnection(&m_dataConnection);
		if (FAILED(hr))
			return DatabaseError("CMantaWebBase&lt;CForgotPassHandler&gt;::GetDataConnection()", hr);

		m_bFailed = false;
		m_bMessageSent = false;

		const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();
		const CHttpRequestParams& QueryFields = m_HttpRequest.GetQueryParams();

		// Check to see if all the fields are present
		if (FormFields.Lookup("email") != NULL)
		{
			if (!ValidateFormData(FormFields))
			{
				m_bFailed = true;
				return HTTP_SUCCESS;
			}

			return SendEmail();
		}
		
		// Get the login from the persistant cookie
		LPCSTR lpszLogin = GetLogin(true);
		if (lpszLogin)
		{
			// Attempt to lookup the user's email address
			CFindEmail findEmail;
			lstrcpyn(findEmail.m_szLogin, lpszLogin, DB_MAX_STRLEN);

			if (findEmail.OpenRowset(m_dataConnection, NULL) == S_OK)
			{
				if (findEmail.MoveFirst() == S_OK)
					m_strEmail = findEmail.m_szEmail;
			}
		}
		return HTTP_SUCCESS;
	}

	[ tag_name("Failed") ]
	HTTP_CODE OnFailed()
	{
		// Return HTTP_SUCCESS if there was a failure
		return (m_bFailed) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("MessageSent") ]
	HTTP_CODE OnMessageSent()
	{
		// Return HTTP_SUCCESS if the message was sent
		return (m_bMessageSent) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("EmailAddress") ]
	HTTP_CODE OnEmailAddress()
	{
		// Respond with the email address
		m_HttpResponse << m_strEmail;
		return HTTP_SUCCESS;
	}

protected:
	bool ValidateFormData(const CHttpRequestParams& FormFields)
	{
		// Validate the email address
		if (FormFields.Validate("email", &m_strEmail, 1, DB_MAX_STRLEN) != VALIDATION_S_OK ||
			m_strEmail.Find("@", 0) == -1 || m_strEmail.Find(" ", 0) != -1)
			return false;

		// Validate the email address is in the database
		CUserInfo userInfo;
		lstrcpy(userInfo.m_szEmail, m_strEmail);
		HRESULT hr = userInfo.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return DatabaseError("CUserInfo::OpenRowset()", hr);
		hr = userInfo.MoveFirst();
		if (hr != S_OK)
		{
			if (hr == DB_S_ENDOFROWSET)
				return false;
			return DatabaseError("CUserInfo::MoveFirst()", hr);
		}
		userInfo.Close();

		// Email address is valid, copy the member data
		m_strFirstName = userInfo.m_szFirstName;
		m_strLastName = userInfo.m_szLastName;
		m_strHint = userInfo.m_szHint;
		
		return true;
	}

	HTTP_CODE SendEmail()
	{
		// Compose and send the email with the user's password
		CStringA strMessage;
		strMessage.Format(	"Dear %s,\r\n\r\n"
						    "Here is the MantaWeb account information you requested:\r\n\r\n"
							"Your account password hint is: %s.\r\n\r\n"
							"Login using http://localhost/MantaWeb/login.srf\r\n\r\n"
						    "Thank you for using MantaWeb.\r\n\r\n"
							"Regards,\r\n     MantaWeb Support", m_strFirstName, m_strHint);

		// Create the mime message
		CMimeMessage msg;
		msg.SetSender("mantaweb-sample@microsoft.com");
		msg.SetSubject("MantaWeb Support");
		CString strName;
		strName.Format("%s %s", m_strFirstName, m_strLastName);
		msg.AddRecipient(m_strEmail, strName);
		msg.AddText(strMessage);

		// Connect to the SMTP server and send the message
		CSMTPConnection connection;
		if (!connection.Connect("localhost"))
			return SMTPError();

		if (!connection.SendMessage(msg))
			return SMTPError();

		m_bMessageSent = true;
		
		return HTTP_SUCCESS;
	}


}; // class CForgotPassHandler

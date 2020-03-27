// LoginHandler.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "..\Common\Crypt.h"
#include "LoginDB.h"			// Login database classes

namespace Login		// Prevent FailureFlag name clash
{
	typedef struct _FailureFlags
	{
		bool m_bFailure;		// General failure bit
		bool m_bEmptyLogin;		// Empty login name
		bool m_bEmptyPassword;	// Empty password
		bool m_bLoginFailed;	// Login failed
	} FailureFlags;
}

[ request_handler("Login") ]
class CLoginHandler : public CMantaWebBase<CLoginHandler>
{
private:
	CStringA	m_strFirstName;			// User's first name
	CStringA	m_strLogin;				// User's login
	CStringA	m_strPassword;			// User's password
	bool		m_bRememberPass;		// Boolean to specify if we're remembering the password
	Login::FailureFlags m_fFailure;		// Login failure flags
	
public:
	// Default constructor
	CLoginHandler() : m_bRememberPass(false)
	{
		// Set all the failure flags to false
		memset(&m_fFailure, false, sizeof(Login::FailureFlags));
	}

	HTTP_CODE ValidateAndExchange()
	{
		// Set the content type to html
		m_HttpResponse.SetContentType("text/html");

		// Get the cached data connection
		HRESULT hr = GetDataConnection(&m_dataConnection);
		if (FAILED(hr))
			return DatabaseError("CMantaWebBase&lt;CLoginHandler&gt;::GetDataConnection()", hr);

		// Get the request param objects
		const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();
		const CHttpRequestParams& QueryFields = m_HttpRequest.GetQueryParams();

		//Check for a logout request
		if (QueryFields.Lookup("logout") != NULL)
		{
			// Remove the session info and redirect to this page (get rid of query params)
			MantaWeb::CRemoveSessionData removeSession;
			GetSessionID(&removeSession.m_guidSessionID);
			removeSession.OpenRowset(m_dataConnection, NULL);
			removeSession.Close();
			m_HttpResponse.Redirect("login.srf");
			return HTTP_SUCCESS_NO_PROCESS;
		}
		if (QueryFields.Lookup("uid") != NULL &&	// Request to redirect to a message
		    QueryFields.Lookup("sid") != NULL &&	// Used with the mail service client
			QueryFields.Lookup("msgid") != NULL)
		{
			return RedirectToMessage(QueryFields);
		}

		// Check to see if all the fields are present
		if (FormFields.Lookup("login") != NULL &&
			FormFields.Lookup("password") != NULL)
		{
			// Validate member data
			if (!ValidateFormData(FormFields))
				return HTTP_SUCCESS;
		
			// Log user in
			return Login();
		}

		// Lookup the login name from the persistant cookie
		m_strLogin = GetLogin(true);
		m_strFirstName = GetFirstName(true);
		if (!GetRememberPass(&m_bRememberPass))
			m_bRememberPass = false;
			
		// If we're remembering password, find the password in the database
		if (!m_strLogin.IsEmpty() && m_bRememberPass)
		{
			CFindPassword findPassword;
			// Attempt to get the password
			lstrcpyn(findPassword.m_szLogin, m_strLogin, DB_MAX_STRLEN);
			hr = findPassword.OpenRowset(m_dataConnection, NULL);
			if (hr == S_OK)
			{
				hr = findPassword.MoveFirst();
				if (hr == S_OK)
					m_strPassword = findPassword.m_szPassword;
			}
		}
		return HTTP_SUCCESS;
	}
	
	[ tag_name("WelcomeMsg") ]
	HTTP_CODE OnWelcomeMsg()
	{
		// Respond with the welcome message
		if (m_strFirstName.GetLength() != 0)
			m_HttpResponse << "Welcome back to MantaWeb, " << m_strFirstName << ".";
		else
			m_HttpResponse << "Welcome to MantaWeb!  Sign up today!";
		return HTTP_SUCCESS;
	}

	[ tag_name("Failure") ]
	HTTP_CODE OnFailure()
	{
		// Return HTTP_SUCCESS if there was a failure
		return (m_fFailure.m_bFailure) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("EmptyLogin") ]
	HTTP_CODE OnEmptyLogin()
	{
		// Return HTTP_SUCCESS if the login was invalid
		return (m_fFailure.m_bEmptyLogin) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}
	
	[ tag_name("LoginFailed") ]
	HTTP_CODE OnLoginFailed()
	{
		// Return HTTP_SUCCESS if the login failed
		return (m_fFailure.m_bLoginFailed) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("EmptyPassword") ]
	HTTP_CODE OnEmptyPassword()
	{
		// Return HTTP_SUCCESS if the password was invalid
		return (m_fFailure.m_bEmptyPassword) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("LoginName") ]
	HTTP_CODE OnLoginName()
	{
		// Respond with the login
		m_HttpResponse << m_strLogin;
		return HTTP_SUCCESS;
	}

	[ tag_name("Password") ]
	HTTP_CODE OnPassword()
	{
		// Respond with the password
		if (m_bRememberPass && !m_fFailure.m_bFailure) m_HttpResponse << m_strPassword;
		return HTTP_SUCCESS;
	}

	[ tag_name("RememberPassword") ]
	HTTP_CODE OnRememberPassword()
	{
		// Respond sucess if we're remembering the password
		return m_bRememberPass ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

protected:
	bool ValidateFormData(const CHttpRequestParams& FormFields)
	{
		// Validate the login
		if (FormFields.Validate("login", &m_strLogin, 1, DB_MAX_STRLEN) != VALIDATION_S_OK)
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bEmptyLogin = true;
		}
		// Validate the password
		if (FormFields.Validate("password", &m_strPassword, 1, DB_MAX_STRLEN) != VALIDATION_S_OK)
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bEmptyPassword = true;
		}

		// If the remember pass field is present, set to true
		if (FormFields.Lookup("rememberpass") != NULL)
			m_bRememberPass = true;
		else
			m_bRememberPass = false;
			
		return !m_fFailure.m_bFailure;
	}

	HTTP_CODE Login()
	{
		// Get the login information
		CLoginUser loginUser;
		lstrcpyn(loginUser.m_szLogin, m_strLogin, DB_MAX_STRLEN);
		
		HRESULT hr = loginUser.OpenRowset(m_dataConnection, FALSE);
		if (hr != S_OK)
			return DatabaseError("CLoginUser::OpenRowset()", hr);

		hr = loginUser.MoveFirst();
		if (hr != S_OK)
		{
			if (hr != DB_S_ENDOFROWSET)
				return DatabaseError("CLoginUser::MoveFirst()", hr);
		}

		// If the passwords match
		if (hr == S_OK)
		{
			hr = CompareSecret(
				(const BYTE*) (LPCSTR) m_strPassword, m_strPassword.GetLength(),
				(BYTE*) loginUser.m_szSalt, lstrlen(loginUser.m_szSalt),
				(BYTE*) loginUser.m_szPassword, lstrlen(loginUser.m_szPassword));
		}

		if (hr == S_OK)
		{
			// Attempt to find a current session
			MantaWeb::CSessionData sessionData;

			sessionData.m_lUserID = loginUser.m_lUserID;
			hr = sessionData.OpenRowset(m_dataConnection, NULL);
			if (hr != S_OK)
				return DatabaseError("CSessionData::OpenRowset()", hr);

			hr = sessionData.MoveFirst();
			if (hr != S_OK && hr != DB_S_ENDOFROWSET)
				return DatabaseError("CSessionData::MoveFirst()", hr);

			// If there is an existing invalid session
			if (hr == DB_S_ENDOFROWSET || SessionTimeOut(sessionData.m_lastAccess))
			{
				// Remove the session
				MantaWeb::CRemoveSessionData removeSession;

				memcpy(&removeSession.m_guidSessionID, &sessionData.m_guidSessionID, sizeof(GUID));
				hr = removeSession.OpenRowset(m_dataConnection, NULL);
				if (hr != S_OK)
					return DatabaseError("CRemoveSessionData::OpenRowset()", hr);
				
				// Insert a new session
				MantaWeb::CInsertSession insertSession;
				insertSession.m_lUserID = loginUser.m_lUserID;

				hr = insertSession.OpenRowset(m_dataConnection, NULL);
				if (hr != S_OK)
					return DatabaseError("CInsertSession::OpenRowset()", hr);

				// Get the generated session id (GUID)
				hr = sessionData.OpenRowset(m_dataConnection, NULL);
				if (hr != S_OK)
					return DatabaseError("CSessionData::OpenRowset()", hr);

				hr = sessionData.MoveFirst();
				if (hr != S_OK)
					return DatabaseError("CSessionData::MoveFirst()", hr);				
			}
			// Write the persistant cookie and session cookie
			WritePersistCookie(m_strLogin, loginUser.m_szFirstName, (m_bRememberPass) ? "1" : "0");
			WriteSessionCookie(m_strLogin, loginUser.m_szFirstName, loginUser.m_szLastName, loginUser.m_lUserID, sessionData.m_guidSessionID);
			// Redirect to the main page
			m_HttpResponse.Redirect("main.srf");
			return HTTP_SUCCESS;
		}
		// Login failed
		m_fFailure.m_bLoginFailed = true;
		m_fFailure.m_bFailure = true;
		return HTTP_SUCCESS;
	}

	HTTP_CODE RedirectToMessage(const CHttpRequestParams& QueryFields)
	{
		LONG userID;
		GUID sessionID;
		QueryFields.Exchange("uid", &userID);
		QueryFields.Exchange("sid", &sessionID);

		// Validate the session
		if (ValidateSession(userID, sessionID))
		{
			// Get the user data for the session cookie
			CUserSessionData sessionData;
			sessionData.m_lUserID = userID;
			HRESULT hr = sessionData.OpenRowset(m_dataConnection, NULL);
			if (hr != S_OK)
				return DatabaseError("CUserSessionData::OpenRowset()", hr);
			hr = sessionData.MoveFirst();
			if (hr != S_OK)
				return DatabaseError("CUserSessionData::MoveFirst()", hr);
			sessionData.Close();

			// Create the session cookie
			WriteSessionCookie(sessionData.m_szLogin, sessionData.m_szFirstName, sessionData.m_szLastName, userID, sessionID);
			// Load the html from resource
			CString strHTML;
			LoadHtmlFromResource(MAKEINTRESOURCE(IDR_MAILREDIRECT), strHTML);

			// Replace the message id and send back the response
			strHTML.Replace("[MSGID]", QueryFields.Lookup("msgid"));
			m_HttpResponse << strHTML;
			return HTTP_SUCCESS_NO_PROCESS;
		}
			
		// Session not valid, send them to the login page (get rid of query params)
		m_HttpResponse.Redirect("login.srf");
		return HTTP_SUCCESS_NO_PROCESS;
	}

}; // class CLoginHandler

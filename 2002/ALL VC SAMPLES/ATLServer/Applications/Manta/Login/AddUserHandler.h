// AddUserHandler.h : Defines the ATL Server request handler class
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
#include "ATLSMTPConnection.h"	// For CSMTPConnection
#include "AddUserDB.h"			// For AddUser database classes

namespace AddUser	// Protection for FailureFlags and FormValues from name clashes
{
    typedef struct _FailureFlags
	{
		bool m_bFailure;			// General failure
		bool m_bInvalidFirstName;	// Invalid first name
		bool m_bInvalidLastName;	// Invalid last name
		bool m_bInvalidLogin;		// Invalid login
		bool m_bInvalidEmail;		// Invalid email
		bool m_bInvalidPassword;	// Invalid password
		bool m_bPasswordMismatch;	// Passwords didn't match
		bool m_bLoginNameTaken;		// Login name already in database
		bool m_bInvalidHint;		// Invalid Hint
	} FailureFlags;
}

// class CAddUserHandler
// This handler is responsible for adding new users into the user table.
[ request_handler("AddUser") ]
class CAddUserHandler : public CMantaWebBase<CAddUserHandler>
{
private:
	CStringA	m_strFirstName;			// User's first name
	CStringA	m_strLastName;			// User's last name
	CStringA	m_strLogin;				// User's login
	CStringA	m_strEmail;				// User's email
	CStringA	m_strPassword1;			// User's first password
	CStringA	m_strPassword2;			// User's second password (matched against first)
	CStringA	m_strHint;				// User's password hint
	bool		m_bRememberPass;		// Boolean to remember password
	AddUser::FailureFlags m_fFailure;	// Failure flags

public:
	HTTP_CODE ValidateAndExchange()
	{
		// Set the content type to html
		m_HttpResponse.SetContentType("text/html");
		
		// Get the cached data connection
		HRESULT hr = GetDataConnection(&m_dataConnection);
		if (FAILED(hr))
			return DatabaseError("CMantaWebBase&lt;CAddUserHandler&gt;::GetDataConnection()", hr);

		// Clear the failure flags
		memset(&m_fFailure, false, sizeof(AddUser::FailureFlags));
		m_bRememberPass = false;

		const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();
		const CHttpRequestParams& QueryFields = m_HttpRequest.GetQueryParams();

		// Check to see if this is a confirmation
		CStringA strUser = QueryFields.Lookup("confirm");
		if (strUser.GetLength())
			return ConfirmUser(strUser);
		
		// Check to see if this is not yet a registration
		if (FormFields.Lookup("firstname") == NULL	|| 
			FormFields.Lookup("lastname") == NULL	||
			FormFields.Lookup("login") == NULL		||
			FormFields.Lookup("email") == NULL		||
			FormFields.Lookup("password1") == NULL	||
			FormFields.Lookup("password2") == NULL  ||
			FormFields.Lookup("hint") == NULL)
		{
			// Not all form values are present (ignore passed form data)
			return HTTP_SUCCESS;
		}

		// Validate form data
		if (!ValidateFormData(FormFields)) return HTTP_SUCCESS;

		// Add the user
		return AddUser();
	}

	[ tag_name("Failure") ]
	HTTP_CODE OnFailure()
	{
		// Return HTTP_SUCCESS if there was an error
		return (m_fFailure.m_bFailure) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("InvalidFirstName") ]
	HTTP_CODE OnInvalidFirstName()
	{
		// Return HTTP_SUCCESS if the first name was invalid
		return (m_fFailure.m_bInvalidFirstName) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("InvalidLastName") ]
	HTTP_CODE OnInvalidLastName()
	{
		// Return HTTP_SUCCESS if the last name was invalid
		return (m_fFailure.m_bInvalidLastName) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("InvalidLogin") ]
	HTTP_CODE OnInvalidLogin()
	{
		// Return HTTP_SUCCESS if the login was invalid
		return (m_fFailure.m_bInvalidLogin) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}
	
	[ tag_name("InvalidEmail") ]
	HTTP_CODE OnInvalidEmail()
	{
		// Return HTTP_SUCCESS if the email address was invalid
		return (m_fFailure.m_bInvalidEmail) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("InvalidPassword") ]
	HTTP_CODE OnInvalidPassword()
	{
		// Return HTTP_SUCCESS if the first password was invalid
		return (m_fFailure.m_bInvalidPassword) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("PasswordMismatch") ]
	HTTP_CODE OnPasswordMismatch()
	{
		// Return HTTP_SUCCESS if the first password didn't match the second password
		return (m_fFailure.m_bPasswordMismatch) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}
	
	[ tag_name("LoginTaken") ]
	HTTP_CODE OnLoginTaken()
	{
		// Return HTTP_SUCCESS if the login is already in use
		return (m_fFailure.m_bLoginNameTaken) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("InvalidHint") ]
	HTTP_CODE OnInvalidHint()
	{
		// Return HTTP_SUCCESS if the hint was invalid
		return (m_fFailure.m_bInvalidHint) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("MaxStringLen") ]
	HTTP_CODE OnMaxStringLen()
	{
		// Respond with the maximum acceptable length of a string
		m_HttpResponse << DB_MAX_STRLEN;
		return HTTP_SUCCESS;
	}

	[ tag_name("RememberPass") ]
	HTTP_CODE OnRememberPass()
	{
		// Return HTTP_SUCCESS if the remember pass was checked
		return (m_bRememberPass) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("FirstName") ]
	HTTP_CODE OnFirstName()
	{
		// Respond with the first name
		m_HttpResponse << m_strFirstName;
		return HTTP_SUCCESS;
	}

	[ tag_name("LastName") ]
	HTTP_CODE OnLastName()
	{
		// Respond with the last name
		m_HttpResponse << m_strLastName;
		return HTTP_SUCCESS;
	}

	[ tag_name("Login") ]
	HTTP_CODE OnLogin()
	{
		// Respond with the login
		m_HttpResponse << m_strLogin;
		return HTTP_SUCCESS;
	}

	[ tag_name("Email") ]
	HTTP_CODE OnEmail()
	{
		// Respond with the email address
		m_HttpResponse << m_strEmail;
		return HTTP_SUCCESS;
	}

	[ tag_name("Password1") ]
	HTTP_CODE OnPassword1()
	{
		// Respond with the first password
		m_HttpResponse << m_strPassword1;
		return HTTP_SUCCESS;
	}

	[ tag_name("Password2") ]
	HTTP_CODE OnPassword2()
	{
		// Respond with the second password
		m_HttpResponse << m_strPassword2;
		return HTTP_SUCCESS;
	}

	[ tag_name("Hint") ]
	HTTP_CODE OnHint()
	{
		// Respond with the hint
		m_HttpResponse << m_strHint;
		return HTTP_SUCCESS;
	}

protected:

	bool ValidateFormData(const CHttpRequestParams& FormFields)
	{
		// Validate the first name
		if (FormFields.Validate("firstname", &m_strFirstName, 1, DB_MAX_STRLEN) != VALIDATION_S_OK ||
			!ValidateString(m_strFirstName))
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bInvalidFirstName = true;
		}
		// Validate the last name
		if (FormFields.Validate("lastname", &m_strLastName, 1, DB_MAX_STRLEN) != VALIDATION_S_OK ||
			!ValidateString(m_strLastName))
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bInvalidLastName = true;
		}
		// Validate the login
		if (FormFields.Validate("login", &m_strLogin, 1, DB_MAX_STRLEN) != VALIDATION_S_OK ||
			m_strLogin.Find(" ", 0) != -1 || !ValidateString(m_strLogin))
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bInvalidLogin = true;
		}
		// Validate the email
		if (FormFields.Validate("email", &m_strEmail, 1, DB_MAX_STRLEN) != VALIDATION_S_OK ||
			m_strEmail.Find("@", 0) == -1 || m_strEmail.Find(" ", 0) != -1 ||
			!ValidateString(m_strEmail))
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bInvalidEmail = true;
		}
		// Validate the first password
		if (FormFields.Validate("password1", &m_strPassword1, 1, DB_MAX_STRLEN) != VALIDATION_S_OK ||
			!ValidateString(m_strPassword1))
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bInvalidPassword = true;
		}
		// Validate the second password
		if ((FormFields.Exchange("password2", &m_strPassword2) != VALIDATION_S_OK || m_strPassword1 != m_strPassword2) &&
			!m_fFailure.m_bInvalidPassword)
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bPasswordMismatch = true;
		}
		// Validate the hint
		if (FormFields.Validate("hint", &m_strHint, 1, DB_MAX_STRLEN) != VALIDATION_S_OK ||
			!ValidateString(m_strHint))
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bInvalidHint = true;
		}
		// Lookup the remember password check
		if (FormFields.Lookup("rememberpass") != NULL)
			m_bRememberPass = true;
		else
			m_bRememberPass = false;

		// Find a user with the same login
		CFindUserID findUserID;
		lstrcpyn(findUserID.m_szLogin, m_strLogin, DB_MAX_STRLEN);

		HRESULT hr = findUserID.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return false;
		hr = findUserID.MoveFirst();
		if (hr != DB_S_ENDOFROWSET)
		{
			// Error, login already in use
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bLoginNameTaken = true;
		}

		return !m_fFailure.m_bFailure;
	}

	HTTP_CODE ConfirmUser(const CStringA& strUser)
	{
		// Confirm the user
		CConfirmUser confirmUser;
		lstrcpy(confirmUser.m_szLogin, strUser);
		HRESULT hr = confirmUser.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return DatabaseError("CConfirmUser::OpenRowset()", hr);

		// Read the confirm response from resource
		// Respond with the html
		CString strHTML;
		LoadHtmlFromResource(MAKEINTRESOURCE(IDR_THANKYOU), strHTML);
		m_HttpResponse << strHTML;
		m_HttpResponse.Flush();
		return HTTP_SUCCESS_NO_PROCESS;
	}

	HTTP_CODE AddUser()
	{
		// Add the user to the database
		CAddUser addUser;
		lstrcpy(addUser.m_szFirstName, m_strFirstName);
		lstrcpy(addUser.m_szLastName, m_strLastName);
		lstrcpy(addUser.m_szEmail, m_strEmail);
		lstrcpy(addUser.m_szLogin, m_strLogin);
		lstrcpy(addUser.m_szHint, m_strHint);

		HRESULT hr;

		// don't store the real password. only store a one-way encrypted hash
		DWORD dwSaltLen = 4;
		DWORD dwPasswordLen = DB_MAX_STRLEN;
		hr = HashSecret(
			(const BYTE*) (LPCSTR) m_strPassword1, m_strPassword1.GetLength(),
			(BYTE*) addUser.m_szSalt, dwSaltLen,
			(BYTE*) addUser.m_szPassword, dwPasswordLen);
		if (FAILED(hr))
			return HTTP_FAIL;

		addUser.m_szSalt[dwSaltLen] = 0;
		addUser.m_szPassword[dwPasswordLen] = 0;

		hr = addUser.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return DatabaseError("CAddUser::OpenRowset()", hr);

		// Send the confirmation email
#if defined(SEND_CONFIRMATION_MAIL)
		 if (!SendMail())
			return SMTPError();
#endif

		// Create the MantaWeb persistant cookie
		WritePersistCookie(addUser.m_szLogin, addUser.m_szFirstName,  (m_bRememberPass) ? "1" : "0");

		// Send the response page
		CString strHTML;
		LoadHtmlFromResource(MAKEINTRESOURCE(IDR_CONFIRM), strHTML);
		strHTML.Replace("[NAME]", m_strFirstName);
		strHTML.Replace("[EMAIL]", m_strEmail);
		strHTML.Replace("[LOGIN]", m_strLogin);
		m_HttpResponse << strHTML;
		m_HttpResponse.Flush();

		return HTTP_SUCCESS_NO_PROCESS;
	}

	bool SendMail()
	{
		// Build the confirmation url (Note: change this to your site)
		CStringA strUrl = "http://localhost/MantaWeb/newuser.srf?confirm=";
		strUrl += m_strLogin;
		
		// Compose and send the confirmation email
		CStringA strMessage;
		strMessage.Format(	"Dear %s,\r\n\r\n"
							"Thank you for registering with MantaWeb.\r\n\r\n"
							"Please click on the following url to confirm your registration.\r\n"
						    "After your confirmation is recieved, you may use your login and password to access MantaWeb.\r\n\r\n"
							"Confirmation URL: %s\r\n\r\n"
							"Please keep your password safe so no one else can access you account.\r\n\r\n"
							"Thank you,\r\n     MantaWeb Support", m_strFirstName, strUrl	);
		
		// Create the mime message
		CMimeMessage msg;
		msg.SetSender("mantaweb-sample@microsoft.com");
		msg.SetSubject("MantaWeb Registration Confirmation");
		CString strName;
		strName.Format("%s %s", m_strFirstName, m_strLastName);
		msg.AddRecipient(m_strEmail, strName);
		msg.AddText(strMessage);

		// Connect to the SMTP server and send the message
		CSMTPConnection connection;
		if (!connection.Connect("localhost"))
			return false;

		if (!connection.SendMessage(msg))
			return false;
		
		return true;
	}

}; // class CAddUserHandler

// ProfileHandler.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "ProfileDB.h"

namespace Profile
{
    typedef struct _FailureFlags
	{
		bool m_bFailure;			// General failure
		bool m_bInvalidFirstName;	// Invalid first name
		bool m_bInvalidLastName;	// Invalid last name
		bool m_bInvalidEmail;		// Invalid email
		bool m_bInvalidPassword;	// Invalid password
		bool m_bPasswordMismatch;	// Passwords didn't match
		bool m_bInvalidPopServer;	// Invalid POP server
		bool m_bInvalidPopPort;		// Invalid POP port
		bool m_bInvalidPopUserName;	// Invalid POP user name
		bool m_bInvalidPopPassword;	// Invalid POP password
	} FailureFlags;
}

// class CProfileHandler
// This handler displays and updates the user profile.
// Note: POP passwords are not encrypted.
[ request_handler("Profile") ]
class CProfileHandler : public CMantaWebBase<CProfileHandler>
{
private:
	CStringA m_strFirstName;			// First name in the user's profile
	CStringA m_strLastName;				// Last name in the user's profile
	CStringA m_strEmail;				// User's email address in the user's profile
	CStringA m_strPassword1;			// First password user enters
	CStringA m_strPassword2;			// Second password user enters
	CStringA m_strPopServer;			// POP server in user's profile
	long	 m_lPopPort;				// POP port in user's profile
	CStringA m_strPopUserName;			// POP user name in user's profile
	CStringA m_strPopPassword;			// POP password in user's profile
	Profile::FailureFlags m_fFailure;	// Failure flags
	bool m_bProfileChanged;				// Boolean to specify if the profile update succeeded

public:
	HTTP_CODE ValidateAndExchange()
	{
		// Set the content type to html
		m_HttpResponse.SetContentType("text/html");

		// Validate the session
		if (!ValidateSession())
			return ValidationError();

		// Clear the flags
		memset(&m_fFailure, false, sizeof(Profile::FailureFlags));
		m_bProfileChanged = false;

		const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();
		// If all the form fields are present
		if (FormFields.Lookup("firstname") != NULL &&
			FormFields.Lookup("lastname") != NULL &&
			FormFields.Lookup("email") != NULL &&
			FormFields.Lookup("password1") != NULL &&
			FormFields.Lookup("password2") != NULL &&
			FormFields.Lookup("popserver") != NULL &&
			FormFields.Lookup("popport") != NULL &&
			FormFields.Lookup("popusername") != NULL &&
			FormFields.Lookup("poppassword"))
		{
			// Validate the form data
			if (!ValidateFormData(FormFields))
				return HTTP_SUCCESS;

			// Update the profile
			return UpdateProfile();
		}
		else
		{
			// Get the user profile
			CUserProfile m_userProfile;
			GetUserID(&m_userProfile.m_lUserID);
			HRESULT hr;
			hr = m_userProfile.OpenRowset(m_dataConnection, NULL);
			if (hr != S_OK)
				return DatabaseError("CUserProfile::OpenRowset()", hr);
			hr = m_userProfile.MoveFirst();
			if (hr != S_OK)
				return DatabaseError("CUserProfile::MoveFirst()", hr);
			
			// Set the member data
			m_strFirstName = m_userProfile.m_szFirstName;
			m_strLastName = m_userProfile.m_szLastName;
			m_strEmail = m_userProfile.m_szEmail;
			m_strPopServer = m_userProfile.m_szPopServer;
			m_lPopPort = m_userProfile.m_lPopServerPort;
			m_strPopUserName = m_userProfile.m_szPopUserName;
			m_strPopPassword = m_userProfile.m_szPopPassword;
		}
		return HTTP_SUCCESS;
	}

	[ tag_name("UpdateSuccessful") ]
	HTTP_CODE OnUpdateSuccessful()
	{
		// Return HTTP_SUCCESS if the profile was updated successfully
		return (m_bProfileChanged) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("Failure") ]
	HTTP_CODE OnFailure()
	{
		// Return HTTP_SUCCESS if there was a failure
		return (m_fFailure.m_bFailure) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("InvalidFirstName") ]
	HTTP_CODE OnInvalidFirstName()
	{
		// Return HTTP_SUCCESS if the first name is invalid
		return (m_fFailure.m_bInvalidFirstName) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("InvalidLastName") ]
	HTTP_CODE OnInvalidLastName()
	{
		// Return HTTP_SUCCESS if the last name is invalid
		return (m_fFailure.m_bInvalidLastName) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("InvalidEmail") ]
	HTTP_CODE OnInvalidEmail()
	{
		// Return HTTP_SUCCESS if the email address is invalid
		return (m_fFailure.m_bInvalidEmail) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("InvalidPassword") ]
	HTTP_CODE OnInvalidPassword()
	{
		// Return HTTP_SUCCESS if the password is invalid
		return (m_fFailure.m_bInvalidPassword) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("PasswordMismatch") ]
	HTTP_CODE OnPasswordMismatch()
	{
		// Return HTTP_SUCCESS if the passwords do not match
		return (m_fFailure.m_bPasswordMismatch) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("InvalidPopServer") ]
	HTTP_CODE OnInvalidPopServer()
	{
		// Return HTTP_SUCCESS if the POP server name is invalid
		return (m_fFailure.m_bInvalidPopServer) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("InvalidPopPort") ]
	HTTP_CODE OnInvalidPopPort()
	{
		// Return HTTP_SUCCESS if the POP port is invalid
		return (m_fFailure.m_bInvalidPopPort) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("InvalidPopUserName") ]
	HTTP_CODE OnInvalidPopUserName()
	{
		// Return HTTP_SUCCESS if the POP user name is invalid
		return (m_fFailure.m_bInvalidPopUserName) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("InvalidPopPassword") ]
	HTTP_CODE OnInvalidPopPassword()
	{
		// Return HTTP_SUCCESS if the POP password is invalid
		return (m_fFailure.m_bInvalidPopPassword) ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[ tag_name("MaxStringLen") ]
	HTTP_CODE OnMaxStringLen()
	{
		// Return the maximum number of characters for a string
		m_HttpResponse << DB_MAX_STRLEN;
		return HTTP_SUCCESS;
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

	[ tag_name("PopServer") ]
	HTTP_CODE OnPopServer()
	{
		// Respond with the POP server address
		m_HttpResponse << m_strPopServer;
		return HTTP_SUCCESS;
	}

	[ tag_name("PopPort") ]
	HTTP_CODE OnPopPort()
	{
		 // Respond with the POP server address
		m_HttpResponse << m_lPopPort;
		return HTTP_SUCCESS;
	}

	[ tag_name("PopUserName") ]
	HTTP_CODE OnPopUserName()
	{
		// Respond with the POP user name
		m_HttpResponse << m_strPopUserName;
		return HTTP_SUCCESS;
	}

	[ tag_name("PopPassword") ]
	HTTP_CODE OnPopPassword()
	{
		// Respond with the POP password
		m_HttpResponse << m_strPopPassword;
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
		// Validate the email address
		if (FormFields.Validate("email", &m_strEmail, 1, DB_MAX_STRLEN) != VALIDATION_S_OK ||
			m_strEmail.Find("@", 0) == -1 || m_strEmail.Find(" ", 0) != -1 ||
			!ValidateString(m_strEmail))
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bInvalidEmail = true;
		}
		// Validate the first password
		DWORD dwRet = FormFields.Validate("password1", &m_strPassword1, 0, DB_MAX_STRLEN);
		if ( (dwRet != VALIDATION_S_OK && dwRet != VALIDATION_S_EMPTY) || !ValidateString(m_strPassword1))
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bInvalidPassword = true;
		}
		// Get the second password, and if the first password is there, match against it
		dwRet = FormFields.Exchange("password2", &m_strPassword2);
		if ( ( (dwRet != VALIDATION_S_OK && dwRet != VALIDATION_S_EMPTY) || m_strPassword1 != m_strPassword2 ) && 
			!m_fFailure.m_bInvalidPassword)
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bPasswordMismatch = true;
		}
		// Validate the POP server
		dwRet = FormFields.Validate("popserver", &m_strPopServer, 0, DB_MAX_STRLEN);
		if ( (dwRet != VALIDATION_S_OK && dwRet != VALIDATION_S_EMPTY) || !ValidateString(m_strPopServer))
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bInvalidPopServer = true;
		}
		// Validate the POP port
		if (FormFields.Validate("popport", &m_lPopPort, 1, 100000) != VALIDATION_S_OK ||
			!ValidateString(m_strPopServer))
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bInvalidPopPort = true;
		}
		// Validate the POP user name
		dwRet = FormFields.Validate("popusername", &m_strPopUserName, 0, DB_MAX_STRLEN);
		if ((dwRet != VALIDATION_S_OK && dwRet != VALIDATION_S_EMPTY) || !ValidateString(m_strPopUserName))
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bInvalidPopUserName = true;
		}
		// Validate the POP password
		dwRet = FormFields.Validate("poppassword", &m_strPopPassword, 0, DB_MAX_STRLEN);
		if ((dwRet != VALIDATION_S_OK && dwRet != VALIDATION_S_EMPTY) || !ValidateString(m_strPopPassword))
		{
			m_fFailure.m_bFailure = true;
			m_fFailure.m_bInvalidPopPassword = true;
		}
		return !m_fFailure.m_bFailure;
	}

	HTTP_CODE UpdateProfile()
	{
		CUpdateProfile updateProfile;
		HRESULT hr;

		// Copy the data into the profile
		lstrcpyn(updateProfile.m_szFirstName, m_strFirstName, DB_MAX_STRLEN);
		lstrcpyn(updateProfile.m_szLastName, m_strLastName, DB_MAX_STRLEN);
		lstrcpyn(updateProfile.m_szEmail, m_strEmail, DB_MAX_STRLEN);
		lstrcpyn(updateProfile.m_szPopServer, m_strPopServer, DB_MAX_STRLEN);
		lstrcpyn(updateProfile.m_szPopUserName, m_strPopUserName, DB_MAX_STRLEN);
		lstrcpyn(updateProfile.m_szPopPassword, m_strPopPassword, DB_MAX_STRLEN);
		updateProfile.m_lPopServerPort = m_lPopPort;
		GetUserID(&updateProfile.m_lUserID);

		// Update the user's profile
		hr = updateProfile.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return DatabaseError("CUpdateProfile::OpenRowset()", hr);
		updateProfile.Close();

		// If we need to update the password
		if (m_strPassword1 != "")
		{
			CUpdatePassword updatePassword;
			
			// TODO: Encrypt password here.

			// Copy the password
			lstrcpyn(updatePassword.m_szPassword, m_strPassword1, DB_MAX_STRLEN);
			updatePassword.m_lUserID = updateProfile.m_lUserID;
			// Update the password
			hr = updatePassword.OpenRowset(m_dataConnection, NULL);
			if (hr != S_OK)
				return DatabaseError("CUpdatePassword::OpenRowset()", hr);
			// Reset the passwords
			m_strPassword1 = m_strPassword2 = "";
		}
		// Rewrite the cookies, and set changed to true
		m_bProfileChanged = true;
		WritePersistCookie(GetLogin(true), m_strFirstName, GetRememberPass());
		WriteSessionCookie(GetLogin(), m_strFirstName, m_strLastName, GetUserID(), GetSessionID());
		return HTTP_SUCCESS;
	}


}; // class CSessionHandler

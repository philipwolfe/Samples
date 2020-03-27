// File: Login.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "StdAfx.h"
#include "Login.h"
#include "Commands.h"
#include "Helpers.h"
#include "Encrypt.h"

HTTP_CODE CLoginHandler::ValidateAndExchange()
{
	using VCUE::OpenCommandRowset;
	using VCUE::SendError;
	using VCUE::QueryService;

	// Set the content-type of the response.
	m_HttpResponse.SetContentType("text/html");

	// Create a validation context to hold the results of the data validation.
	CValidateContext validationContext;

	// Look for the username and password in the form data.
	// Ensure that the username and password are between 1 and 50 chars.
	const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();
	FormFields.Validate("username", static_cast<LPCSTR*>(NULL), 1, 50, &validationContext);
	FormFields.Validate("password", static_cast<LPCSTR*>(NULL), 1, 50, &validationContext);

	if (validationContext.ParamsOK())
	{
		// Get the user name and password from the form fields.
		LPCSTR szUser = FormFields.Lookup("username");
		LPCSTR szPassword = FormFields.Lookup("password");
		
		// Create a command object to query the database for this username and password.
		CCommandSiteUser cmdSiteUser;
		
		HRESULT hr = E_UNEXPECTED;

		hr = cmdSiteUser.SetUserName(szUser);
		if (FAILED(hr))
			return SendError(m_HttpResponse, "An unexpected error occurred.");

		// Open or retrieve the cached database connection and execute
		// the SQL query to retrieve any users with matching username
		hr = OpenCommandRowset(m_spServiceProvider, cmdSiteUser);

		// Move to the first row of the result set
		if (SUCCEEDED(hr))
		{
			hr = cmdSiteUser.MoveFirst();
			if (S_OK == hr)
			{
				hr = cmdSiteUser.ComparePassword(szPassword);
			}
			else if (SUCCEEDED(hr))
			{
				// The following code automatically adds a user to the database
				// if the username doesn't exist. This allows you to test this application
				// without having to implement more feature rich code for adding users.
				//
				// This code is only provided because it's not easy to add hashed passwords
				// and random salt values to the database by hand.
				//
				// Look at the WebFeatures : ConfirmUser sample to find full featured
				// code that allows the addition of users and provides for email confirmation. 
				#ifdef DEBUG
					// This code adds the user to the database
				LPCSTR szEmail = FormFields.Lookup("email");
				CCommandCreateUser cmdCreateUser;
				hr = cmdCreateUser.SetUserName(szUser);
				if (SUCCEEDED(hr))
				{
					hr = cmdCreateUser.SetPassword(szPassword);
					if (SUCCEEDED(hr))
					{
						hr = cmdCreateUser.SetEmail(szEmail);
						if (SUCCEEDED(hr))
						{
							hr = OpenCommandRowset(m_spServiceProvider, cmdCreateUser);
						}
					}
				}

				if (SUCCEEDED(hr))
				{
					m_strStatus = "The user was added to the database. You can now login.";
				}
				else
				{
					m_strStatus = "Failed to add user.";
				}
				
				hr = S_FALSE;
				#endif
			}
			
		}

		if (FAILED(hr))
			return SendError(m_HttpResponse, "An error occurred accessing the database.");

		if (hr != S_OK)
		{
			// The user has supplied an invalid combination of username and password.
			if (0 == m_strStatus.GetLength())
				m_strStatus = "Invalid username or password, please try again";
		}
		else
		{
			// The user has provided a valid combination of username and password.

			// Get a pointer to the session service.
			CComPtr<ISessionStateService> spSessionService;
			if (FAILED(QueryService(m_spServiceProvider, &spSessionService)))
				return HTTP_FAIL;

			// Create a new session.
			CHAR szSessionId[COOKIE_VALUE_SIZE + 1];
			szSessionId[0] = 0;
			DWORD dwSize = (sizeof(szSessionId) / sizeof(szSessionId[0])) - 1;

			CComPtr<ISession> spSession;
			hr = spSessionService->CreateNewSession(szSessionId, &dwSize, &spSession);

			if (FAILED(hr))
			{
				return SendError(m_HttpResponse, "An error occurred creating a new session object.");
			}

			// Put the session ID in a cookie.
			CCookie cookieStore;
			cookieStore.SetName(COOKIE_NAME);
			BOOL bSuccess = cookieStore.AddValue(COOKIE_VALUE_NAME, szSessionId);
			if (bSuccess)
				bSuccess = m_HttpResponse.AppendCookie(&cookieStore);

			if (!bSuccess)
			{
				return SendError(m_HttpResponse, "An error occurred creating the cookie.");
			}
			
			// Store the username in session state
			CComVariant varUserName = szUser;
			hr = spSession->SetVariable("UserName", varUserName);
            if (FAILED(hr))
			{
				return SendError(m_HttpResponse, "An error occurred adding a variable to the session.");
			}

			// Redirect to the main page.
			m_HttpResponse.Redirect("tutorial.srf");

			// Discontinue processing of the SRF file.
			return HTTP_SUCCESS_NO_PROCESS;
		}
	}

	return HTTP_SUCCESS;
}

HTTP_CODE CLoginHandler::OnStatus()
{
	// Output the status text.
	m_HttpResponse << "<p>" << m_strStatus << "</p>";
	return HTTP_SUCCESS;
}

HTTP_CODE CLoginHandler::OnDebug()
{
	// Return true if this is a debug build.
	#ifdef DEBUG
		return HTTP_SUCCESS;
	#else
		return HTTP_S_FALSE;
	#endif
}
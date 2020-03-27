// MainHandler.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

// class CMainHandler
// This handler just validates the session and displays the user's first and last name 
// from the session cookie.
[ request_handler("Default") ]
class CMainHandler : public CMantaWebBase<CMainHandler>
{
public:
	HTTP_CODE ValidateAndExchange()
	{
		// Validate the session
		if (!ValidateSession())
			return ValidationError();

		return HTTP_SUCCESS;
	}

	[ tag_name("FirstName") ]
	HTTP_CODE OnFirstName()
	{
		// Respond with the first name from the session cookie
		LPCSTR lpszFirstName = GetFirstName();
		if (lpszFirstName)
			m_HttpResponse << lpszFirstName;
		else
			m_HttpResponse << "[first name unknown]";
		return HTTP_SUCCESS;
	}

	[ tag_name("LastName") ]
	HTTP_CODE OnLastName()
	{
		// Respond with the last name from the session cookie
		LPCSTR lpszLastName = GetLastName();
		if (lpszLastName)
			m_HttpResponse << lpszLastName;
		else
			m_HttpResponse << "[last name unknown]";
		return HTTP_SUCCESS;
	}
};
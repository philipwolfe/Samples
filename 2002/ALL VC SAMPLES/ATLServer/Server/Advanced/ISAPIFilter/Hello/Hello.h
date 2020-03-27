// Hello.h
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// Hello.h : Defines the ATL Server request handler class
//
#pragma once

[ request_handler("Default") ]
class CHelloHandler
{
private:
	// Put private members here

protected:
	// Put protected members here

public:
	// Put public members here

	HTTP_CODE ValidateAndExchange()
	{
		// Set the content-type
		m_HttpResponse.SetContentType("text/html");

		// check for form submission
		CStringA strUser(m_HttpRequest.QueryParams.Lookup("user"));

		CStringA strPage;
		strPage.Format("<html><body>Hello %s!</body></html>", strUser);

		m_HttpResponse << strPage;

		return HTTP_SUCCESS;
	}
}; // class CHelloHandler

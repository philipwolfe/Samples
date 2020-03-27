// hotswaptest.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

[ request_handler("Default") ]
class ChotswaptestHandler
{
private:
	// Put private members here

protected:
	// Put protected members here

public:
	// Put public members here

	HTTP_CODE ValidateAndExchange()
	{
		// TODO: Put all initialization and validation code here
		
		// Set the content-type
		m_HttpResponse.SetContentType("text/html");
		
		return HTTP_SUCCESS;
	}
 
	// Here is an example of how to use a replacement tag with the stencil processor
	[ tag_name(name="Hello") ]
	HTTP_CODE OnHello(void)
	{
		m_HttpResponse << "Hello World!";
		return HTTP_SUCCESS;
	}
}; // class ChotswaptestHandler

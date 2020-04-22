// Created by Microsoft (R) C/C++ Compiler Version 13.00.9360
//
// d:\sourcedepot\vcqalibs\test sources\work in progress\hps\hailstorm\pdc\tankonline\myserviceshandler.mrg.h
// compiler-generated file created 10/19/01 at 11:51:29
//
// This C++ source file is intended to be a representation of the
// source code injected by the compiler.  It may not compile or
// run exactly as the original source file.
//


//+++ Start Injected Code
[no_injected_text(true)];      // Suppress injected text, it has already been injected
#pragma warning(disable: 4543) // Suppress warnings about skipping injected text
#pragma warning(disable: 4199) // Suppress warnings from attribute providers

#pragma message("\n\nNOTE: This merged source file should be visually inspected for correctness.\n\n")
//--- End Injected Code

#include "stdafx.h"

#include "mycontacts.h"

[request_handler("MyServices")]
class CMyServicesHandler : 	
	public CTankHandlerBaseT<CMyServicesHandler>
{
public:
	HTTP_CODE ValidateAndExchange()
	{		
		HTTP_CODE httpCode = __super::ValidateAndExchange();

		if (httpCode == HTTP_SUCCESS)
		{
			m_HttpResponse.Redirect("tankonline.srf");
		}
		else
		{
			if (m_isPostBack)
			{
				m_HttpResponse << "Please ensure that 'server' and 'puid' both have valid values";
			}
		}
		
		// always return success, we're not leaving this page until the user
		// fills out a valid server name and puid
		return HTTP_SUCCESS;
	}
};

//+++ Start Injected Code For Attribute 'request_handler'
#injected_line 5 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\myserviceshandler.h"

				
DECLARE_REQUEST_HANDLER("MyServices", CMyServicesHandler, ::CMyServicesHandler)

			
//--- End Injected Code For Attribute 'request_handler'

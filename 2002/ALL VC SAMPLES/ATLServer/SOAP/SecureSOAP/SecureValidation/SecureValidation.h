// SecureValidation.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "SimpleUserPwdValidate.h"
[ request_handler("Default") ]
class CSecureValidationHandler
{
private:
	// Put private members here

protected:
	// Holds the name of the user

	CSimpleUserPwdValidator	_userValidator;
	
	// describes the state of the page : validate or not (i.e. Login)
	bool		m_bValidateMode;

public:
	// Put public members here

	HTTP_CODE ValidateAndExchange()
	{
		
		DWORD	dwRet = 0L;
		LPCSTR	szMode = NULL;

		// Set the content-type
		m_HttpResponse.SetContentType("text/html");

		
		
		m_bValidateMode	=	false;
		
		if( VALIDATION_S_OK == m_HttpRequest.QueryParams.Exchange("mode", &szMode) )
			m_bValidateMode	= szMode &&( 0 == stricmp( szMode, "validate") );

		if( m_bValidateMode )
		{
			LPCSTR	szUserName		=	NULL;
			LPCSTR	szPwd			=	NULL;
			
			dwRet = m_HttpRequest.FormVars.Exchange("userName", &szUserName);

			if( dwRet != VALIDATION_S_OK )
			{
				// Add custom code for rendering an error to the user if validation fails.
			}
			else
			{
				
				dwRet = m_HttpRequest.FormVars.Exchange("pwd", &szPwd);
				// Add custom code for rendering an error to the user if validation fails.
 
			}
			
			// Assuming the validation went well
			_userValidator.setUserNameAndPassword( szUserName, szPwd);
		}

		

		
		return HTTP_SUCCESS;
	}
 
protected:
	[ tag_name(name = "mode") ]
	HTTP_CODE Onvalid(LPTSTR	strMode)
	{
		HTTP_CODE	retCode	=	HTTP_S_FALSE;

		if( _tcsicmp(strMode, _T("resultPage")) == 0 )
			retCode	=	m_bValidateMode ? HTTP_SUCCESS : HTTP_S_FALSE;
		
		return retCode ;
	}


	[ tag_name(name = "displayStatus") ]
	HTTP_CODE OnDisplayStatus(void)
	{
		m_HttpResponse	<<	"<H1>";

		m_HttpResponse	<<	"<font color=\">";

		if( _userValidator.isValid() )
			m_HttpResponse	<<	"#ff0000\">";
		else
			m_HttpResponse	<<	"#0007f\">";
		
		m_HttpResponse	<<	_userValidator.errorString();

		m_HttpResponse	<<	"</font><H1>";

		return HTTP_SUCCESS;
	}


}; // class CSecureValidationHandler

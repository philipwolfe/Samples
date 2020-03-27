// SecureValidationClient.cpp : Defines the entry point for the console application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include	<iostream>
#include "SecureValidationWS.h"
#include "SecureSocket.h"

using namespace std;
using namespace SecureValidationService;


/*
	Typedef for a CSoapSocketClientT (the default HTTP client) the uses
	a custom socket wrapper supporting SSL
*/
typedef CSoapSocketClientT<CSecureEvtSyncSocket> CSecureSoapSocketClient;



// simple method to dump the results to stdout
void	dumpValidationResults(HRESULT hRetCode, bool bValidated, BSTR bstrError )
{
	
	if( SUCCEEDED(hRetCode) )
	{
		CW2A	szErr(bstrError);
		cout	<<	_T("SOAP Invocation was successful. See results below:")	<<	endl;
		cout	<<	_T("User was :")		<<	(LPCTSTR)(bValidated?_T("Validated"):_T("Rejected"))	<<	endl;
		cout	<<	_T("Error message :")	<<	(LPCTSTR)szErr	<<	endl;

		::SysFreeString( bstrError );
	}
	else
	{
		cout	<<	_T("The SOAP Invocation failed")	<<	endl;
	}
}





int main(int argc, char* argv[])
{
	
	BSTR		bstrUser, bstrPwd, bstrError;
	bool		bValidated;
	HRESULT		hRet;
	#pragma message( __FILE__"(57): warning SECURESOAP01: Change <your_machine_name> to the name of your web server, then remove this pragma" ) 
	LPCTSTR		szUrl	=	_T("https://<your_machine_name>/SecureSOAP/SecureValidation.dll?Handler=SecureValidationService");

	CoInitialize(NULL);	

	// Replace this with other test values
	// NOTE : the default validation method on the server will fail only if the user name is empty
	bstrUser	=	::SysAllocString(L"UserName");
	bstrPwd		=	::SysAllocString(L"Password");



	// Using SSL with the default CSoapSocketClientT and a  custom SSL-enabled socket wrapper
	// NOTE : this code block will only compile on Windows 2000
	{
		CSecureValidationServiceT<CSecureSoapSocketClient>	srv;

		bValidated = false;
		srv.SetUrl(szUrl);


		cout	<<	_T("Invoking secure method with custom socket wrapper")		<<	endl;
		hRet	=	srv.validateUser( bstrUser, bstrPwd, &bValidated, &bstrError);

		dumpValidationResults( hRet, bValidated, bstrError );
		cout	<<	endl;

		srv.Cleanup();
		
	}




	// Using SSL with the MSXML HTTP client. It has built-in support for secure communication
	// NOTE : this code block will only work if MSXML3.0 is installed 
	{
		CSecureValidationServiceT<CSoapMSXMLInetClient>	srv;

		bValidated = false;
		srv.SetUrl(szUrl);

		cout	<<	_T("Invoking secure method with CSoapMSXMLInet client")		<<	endl;
		hRet	=	srv.validateUser( bstrUser, bstrPwd, &bValidated, &bstrError);

		dumpValidationResults( hRet, bValidated, bstrError );
		cout	<<	endl;

		srv.Cleanup();
	}


	// Using SSL with the WinINET HTTP client. It has built-in support for secure communication
	{
		CSecureValidationServiceT<CSoapWininetClient>	srv;


		bValidated = false;
		srv.SetUrl(szUrl);

		cout	<<	_T("Invoking secure method with CSoapWininet client")		<<	endl;
		hRet	=	srv.validateUser( bstrUser, bstrPwd, &bValidated, &bstrError);

		dumpValidationResults( hRet, bValidated, bstrError );
		cout	<<	endl;

		srv.Cleanup();
	}

	::SysFreeString( bstrUser );
	::SysFreeString( bstrPwd );

	
	CoUninitialize();
	
	return 0;
}

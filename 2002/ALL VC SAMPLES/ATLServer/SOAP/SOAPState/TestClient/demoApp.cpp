// File: demoApp.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#define _WIN32_WINDOWS 0x0500
// include the file generated by sproxy for simpleTestApp.dll
#include "SimpleSoapAppProxy.h"
using namespace SStateService;


void	SendMessageToServer(BSTR bstrUser, BSTR bstrPwd, BSTR bstrMsg)
{
	CSStateService	srv;
	eState			state;
	BSTR	bstrOut;
	
	printf("\nTrying to initialize the server : ");

	srv.m_bstrStorageKey	=	::SysAllocString(L"");
	
	HRESULT	hr	=	srv.initPersistSoapServer(bstrUser, bstrPwd, &state);

	if( SUCCEEDED(hr) )
	{
		if( state == eNEW_OBJECT )
		{
			printf("New server object created!\n");
		}
		else if (state == eEXISTING_OBJECT)
		{
			printf("Connected to existing server object\n");
		}
		else
			hr	=	E_FAIL;
	}
	
	if(FAILED(hr))
	{
		printf("Failed to initialize\n");
		return;
	}

	// setting the timeout to 1 minute
	hr	=	srv.setPersistSoapServerTimeout(60);


	
	printf("Sending %ls\n", bstrMsg);
	hr = srv.HelloWorld(bstrMsg, &bstrOut);
	printf("Return : %d\n", hr);
	if( SUCCEEDED(hr))
	{
		printf("Result %ls\n", bstrOut);
		::SysFreeString( bstrOut);
	}
	
	
	printf("Sending %ls\n", bstrUser);
	hr = srv.HelloWorld(bstrUser, &bstrOut);
	printf("Return : %d\n", hr);
	if( SUCCEEDED(hr))
	{
		printf("Result %ls\n", bstrOut);
		::SysFreeString( bstrOut);
	}
	srv.Cleanup();
}



void	DestroyPersistentServer(BSTR bstrUser, BSTR bstrPwd)
{
	CSStateService	srv;
	eState			state;
	
	
	printf("\nTrying to connect to the server : ");

	srv.m_bstrStorageKey	=	::SysAllocString(L"");
	
	HRESULT	hr	=	srv.initPersistSoapServer(bstrUser, bstrPwd, &state);

	if( SUCCEEDED(hr) )
	{
		if( state == eNEW_OBJECT )
		{
			printf("New server object created!\n");
		}
		else if (state == eEXISTING_OBJECT)
		{
			printf("Connected to existing server object\n");
		}
		else
			hr	=	E_FAIL;
	}
	
	if(FAILED(hr))
	{
		printf("Failed to initialize\n");
		return;
	}

	printf("Calling destroy method - ");
	hr	=	srv.destroyPersistSoapServer(bstrUser, bstrPwd);
	printf("Return : %d\n", hr);
	srv.Cleanup();
}



void main()
{
	
	CoInitialize(NULL);
	BSTR	bstrUser, bstrPwd;
	BSTR	bstrFirstMessage, bstrSecondMessage;

	bstrUser	=	::SysAllocString(L"SomeUser");
	bstrPwd	=	::SysAllocString(L"SomePassword");

	// call the server first time
	// Expected : created a new server object, last return value : 
	//  (First session) Hello, UserName
	bstrFirstMessage	=	::SysAllocString(L"(First session) Hello, ");
	SendMessageToServer(bstrUser, bstrPwd, bstrFirstMessage);
	::SysFreeString(bstrFirstMessage);
	
	// call the server the second time
	// Expected : connected to existing server object, last return value : 
	//  (First session) Hello, UserName -- (Second session) Hello, UserName
	bstrSecondMessage	=	::SysAllocString(L" -- (Second session) Hello, ");
	SendMessageToServer(bstrUser, bstrPwd, bstrSecondMessage);
	::SysFreeString(bstrSecondMessage);


	// destroy the persistent server
	// expected : connected to existing server object,
	DestroyPersistentServer(bstrUser, bstrPwd);


	// call the server the third time, after destroying it. A new one should be created
	// Expected : created a new server object, last return value : 
	//  (First session) Hello, UserName
	bstrFirstMessage	=	::SysAllocString(L"(First session) Hello, ");
	SendMessageToServer(bstrUser, bstrPwd, bstrFirstMessage);
	::SysFreeString(bstrFirstMessage);

	::SysFreeString(bstrUser);	
	::SysFreeString(bstrPwd);	

	CoUninitialize();
}
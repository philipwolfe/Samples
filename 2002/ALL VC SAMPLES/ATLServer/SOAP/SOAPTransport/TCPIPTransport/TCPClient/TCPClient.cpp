// File: TCPClient.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

// include the file generated by sproxy for simpleTestApp.dll
#include "stdafx.h"

#include "SimpleSoapAppProxy.h"
using namespace SimpleSoapAppService;

// Include the header for the TCP transport 
#include "SoapTCPClient.h"

void main()
{
	
	CoInitialize(NULL);

	{
		BSTR bstrIn, bstrOut;
		
		// Instantiate the template on the TCP transport instead of one of the  ...Inet clients
		CSimpleSoapAppServiceT<CSoapTCPClient>	srv;
		unsigned short				nServerPort	=	333;

		srv.SetTCPSoapServer("localhost", nServerPort);


		srv.SetSocketTimeout(2000);
		
		
		// Everything after this line is NOT specific to the SoapDebugClient
		bstrIn	=	::SysAllocString(L"User");
		
		HRESULT hr = srv.HelloWorld(bstrIn, &bstrOut);
	
		printf("Return : %d\n", hr);
		if( SUCCEEDED(hr))
		{
			printf("Result %S\n", bstrOut);
			::SysFreeString( bstrOut);
		}
		
		srv.Cleanup();
	}
	CoUninitialize();
}
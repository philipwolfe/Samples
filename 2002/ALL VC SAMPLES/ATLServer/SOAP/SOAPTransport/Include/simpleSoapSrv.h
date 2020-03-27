// SimpleSoapApp.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

/*
	This file presents the modifications to a wizard generated SOAP server to make it usable 
	with a custom transport
	
	The modifications are marked with comments followed by the WizardModif word
*/
#pragma once

#include "SoapTransportSrv.h"

namespace SimpleSoapAppService
{
// all struct, enum, and typedefs for your webservice should go inside the namespace

// ISimpleSoapAppService - web service interface declaration
//
[
	uuid("D41CEEC6-2CF1-4324-AAE3-C4954F600DFA"), 
	object
]
__interface ISimpleSoapAppService
{
	// HelloWorld is a sample ATL Server web service method.  It shows how to
	// declare a web service method and its in-parameters and out-parameters
	[id(1)] HRESULT HelloWorld([in] BSTR bstrInput, [out, retval] BSTR *bstrOutput);
	// TODO: Add additional web service methods here
};


// SimpleSoapAppService - web service implementation
//
[
	// THIS HAS TO BE COMMENTED -  NOT A REQ HANDLER ANYMORE
	// IT MUST BE REPLACED by a method returning the request_handler name
	// WizardModif1 : request_handler(name="Default", sdl="GenSimpleSoapAppServiceWSDL"),
	soap_handler(
		name="SimpleSoapAppService", 
		namespace="urn:SimpleSoapAppService",
		protocol="soap"
	)
]
class CSimpleSoapAppService :
	// WizardModif2 :  must inherit from SoapTransportHandler, to expose an entry point for the SOAP invocation
	public CSoapTransportHandler<CSimpleSoapAppService>,
	public ISimpleSoapAppService
{
public:
	// override this in your service class to provide the name of your service
	// make sure that, on the client side, you set the URL to something ending with "Handler=ThisName"
	static LPCSTR	ServiceName()
	{
		return "Default";
	}

protected:
	// This is a sample web service method that shows how to use the 
	// soap_method attribute to expose a method as a web method
	[ soap_method ]
	HRESULT HelloWorld(/*[in]*/ BSTR bstrInput, /*[out, retval]*/ BSTR *bstrOutput)
	{
		CComBSTR bstrOut(L"Hello ");
		bstrOut += bstrInput;
		bstrOut += L"!";
		*bstrOutput = bstrOut.Detach();
		
		return S_OK;
	}

}; // class CSimpleSoapAppService

} // namespace SimpleSoapAppService

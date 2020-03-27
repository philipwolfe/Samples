// SimpleSoapApp.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

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
	request_handler(name="Default", sdl="GenSimpleSoapAppServiceWSDL"),
	soap_handler(
		name="SimpleSoapAppService", 
		namespace="urn:SimpleSoapAppService",
		protocol="soap"
	)
]
class CSimpleSoapAppService :
	public ISimpleSoapAppService
{
public:
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

	// TODO: Add additional web service methods here
}; // class CSimpleSoapAppService

} // namespace SimpleSoapAppService

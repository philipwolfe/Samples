// File: SynchronousSoapSrv.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
namespace SynchronousSoapSrv
{
// all struct, enum, and typedefs for your webservice should go inside the namespace


// ISynchronousSoapService - web service interface declaration
//
[
	uuid("2B85DA74-DCD8-41AF-AC66-6D7D789E270D"), 
	object
]
__interface ISynchronousSoapService
{
	// HelloWorld is a sample ATL Server web service method.  It shows how to
	// declare a web service method and its in-parameters and out-parameters
	[id(1)] HRESULT performStringOperation([in] BSTR bstrInput, [out, retval] BSTR *bstrOutput);
};



// SynchronousSoapService - web service implementation
//
[
	request_handler(name="Synchronous", sdl="GenSynchronousSoapServiceWSDL"),
	soap_handler(
		name="SynchronousSoapService", 
		namespace="urn:SynchronousSoapService",
		protocol="soap"
	)
]
class CSynchronousSoapService :
	public ISynchronousSoapService
{



protected:
	


	// This is a sample web service method that shows how to use the 
	// soap_method attribute to expose a method as a web method
	[ soap_method ]
	HRESULT performStringOperation(/*[in]*/ BSTR bstrInput, /*[out, retval]*/ BSTR *bstrOutput)
	{
		// perform a delay to simulate a time consuming operation
		ATLTRACE("Start string operation	 \n");
		Sleep(5000);
		CComBSTR bstrOut(L"Hello ");
		bstrOut += bstrInput;//*bstrOutput;
		bstrOut += L"!";
		::SysFreeString(*bstrOutput);
		*bstrOutput = bstrOut.Detach();
		ATLTRACE("End string operation	 \n");
		
		return S_OK;
	}


	// This is a sample web service method that shows how to use the 
	// soap_method attribute to expose a method as a web method

//	[ soap_method ]
//	HRESULT performExtraSoapCall(/*[in]*/ BSTR bstrInput, /*[out, retval]*/ BSTR *bstrOutput)
//	{
//		HRESULT		hRet;
//		
//		
//		ISAXXMLReader		*xmlReader		=	NULL;
//
//		// get an ISAXMLReader* FROM THE THREAD POOL SERVICE
//		hRet	=	m_spServiceProvider->QueryService(__uuidof(IThreadPoolService), __uuidof(ISAXXMLReader), (void**) &xmlReader);
//
//
//		// use the cached _xmlReader object
//		
//		BaseSrvService::CBaseSrvService	baseServer(xmlReader);
//		hRet	=	baseServer.doSomething(bstrInput, bstrOutput);
//
//		if( SUCCEEDED(hRet))
//		{
//			CComBSTR bstrOut(L"Hello ");
//			bstrOut += *bstrOutput;
//			bstrOut += L"!";
//			::SysFreeString(*bstrOutput);
//			*bstrOutput = bstrOut.Detach();
//		}
//
//		
//		return S_OK;
//	}

	// TODO: Add additional web service methods here
}; // class CSynchronousSoapService

} // namespace SynchronousSoapService

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

namespace SecureValidationService
{
// all struct, enum, and typedefs for your webservice should go inside the namespace

// ISecureValidationService - web service interface declaration
//
[
	uuid("76352291-83A9-42E8-9077-F6392E641AF0"), 
	object
]
__interface ISecureValidationService
{
	// HelloWorld is a sample ATL Server web service method.  It shows how to
	// declare a web service method and its in-parameters and out-parameters
	[id(1)] HRESULT validateUser([in] BSTR bstrUserName, [in] BSTR bstrPwd, [out, retval] bool*	pbRetVal, [out]BSTR* pbstrErrorInfo);
	// TODO: Add additional web service methods here
};


// SecureValidationService - web service implementation
//
[
	request_handler(name="SecureValidationService", sdl="GenSecureValidationServiceWSDL"),
	soap_handler(
		name="SecureValidationService", 
		namespace="urn:SecureValidationService",
		protocol="soap"
	)
]
class CSecureValidationService :
	public ISecureValidationService
{
public:
protected:
	// This is a sample web service method that shows how to use the 
	// soap_method attribute to expose a method as a web method
	[ soap_method ]
	HRESULT validateUser(BSTR bstrUserName, BSTR bstrPwd, bool*	pbRetVal, BSTR* pbstrErrorInfo)
	{
		CSimpleUserPwdValidator	userValidator;
		CComBSTR	bstrError;
		CW2A szUserName(bstrUserName);
		CW2A szPwd(bstrPwd);


		userValidator.setUserNameAndPassword( szUserName, szPwd);
		
		*pbRetVal	=	userValidator.isValid();

		bstrError.Append(userValidator.errorString() );
		*pbstrErrorInfo	=	bstrError.Detach();
		
		return S_OK;
	}
	// TODO: Add additional web service methods here
}; // class CSecureValidationService

} // namespace SecureValidationService

// SState.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "../Include/Persist.h"
namespace SStateService
{







// ISStateService - web service interface declaration
//
[
	uuid("7177BD3E-A1F0-433A-9AAF-314985F8C1D8"), 
	object
]
__interface ISStateService : public IPersistSoapServer
{
	// State persistent information

	[id(1)]	HRESULT		HelloWorld( [in]BSTR bstrIn, [out, retval]BSTR *bstrOutput);

};








// SStateService - web service implementation
//
[
	request_handler(name="Default", sdl="GenSStateServiceWSDL"),
	soap_handler(
		name="SStateService", 
		namespace="urn:SStateService",
		protocol="soap"
	)
]
class CSStateService :
	public ISStateService
{
protected:
	CStringA		m_strData;

public:

	BSTR			m_bstrStorageKey;

	/* 
		method to return the transport header
		It's up to the implenentation whether the transport token is a cookie or a SOAP header
	*/
	HRESULT		getObjToken(storageKey&	token)
	{
		try
		{
			CW2A	strHeader(m_bstrStorageKey);
			token	=	strHeader;
		}
		catch(...)
		{
			return E_FAIL;
		}

		return S_OK;
	}
	
	// method to set the transport header
	HRESULT		setObjToken(storageKey&	token)
	{
		CComBSTR	bstrHeader;

		bstrHeader.Append( (LPCSTR)token );
		m_bstrStorageKey	=	bstrHeader.Detach();
		return S_OK;
	}
	
	
	// Loads the object from a blob of data
	HRESULT		persist_load(const ATLSOAP_BLOB	&data)
	{
		m_strData.SetString( (LPCSTR)data.data, data.size);
		return S_OK;
	}
	
	
	// Saves the object to a blob of data
	HRESULT		persist_dump(ATLSOAP_BLOB	&data)
	{
		data.size	=	m_strData.GetLength();
		data.data	=	new unsigned char[ data.size ];
		memcpy( data.data, (unsigned char*)(LPCSTR)m_strData, data.size);
		return S_OK;
	}


	// The only public SOAP Methods
	[soap_method ]
	[soap_header(value="m_bstrStorageKey")]
	/*[id(1)]	*/HRESULT		initPersistSoapServer(/*[in]*/BSTR bstrUser, /*[in]*/BSTR bstrPwd, /*[out, retval]*/eState*	state)
	{
		CComPtr<ISOAPSrvStorageService>	storageSrv;
		HRESULT	hr = m_spServiceProvider->QueryService(__uuidof(ISOAPSrvStorageService), 
						__uuidof(ISOAPSrvStorageService), (void **)&storageSrv);
		ATLASSERT( SUCCEEDED(hr) );

		hr		=	storageSrv->createNewObject( bstrUser, bstrPwd, static_cast<IPersistSoapServer*>(this));

		if( SUCCEEDED(hr) )
		{
			*state	=	(eState)HRESULT_CODE(hr);
		}
		return S_OK;
	}

	[soap_method ]
	[soap_header(value="m_bstrStorageKey")]
	/*[id(2)]	*/HRESULT		destroyPersistSoapServer(/*[in]*/BSTR bstrUser, /*[in]*/BSTR bstrPwd)
	{
		CComPtr<ISOAPSrvStorageService>	storageSrv;
		HRESULT	hr = m_spServiceProvider->QueryService(__uuidof(ISOAPSrvStorageService), 
						__uuidof(ISOAPSrvStorageService), (void **)&storageSrv);
		ATLASSERT( SUCCEEDED(hr) );

		hr		=	storageSrv->deleteObject( static_cast<IPersistSoapServer*>(this), bstrUser, bstrPwd);

		return S_OK;
	}


	[soap_method ]
	[soap_header(value="m_bstrStorageKey")]
	/*[id(3)]	*/HRESULT		setPersistSoapServerTimeout(/*[in]*/DWORD	dwTimeoutSecs)
	{
		CComPtr<ISOAPSrvStorageService>	storageSrv;
		HRESULT	hr = m_spServiceProvider->QueryService(__uuidof(ISOAPSrvStorageService), 
						__uuidof(ISOAPSrvStorageService), (void **)&storageSrv);
		ATLASSERT( SUCCEEDED(hr) );

		hr		=	storageSrv->setObjectTimeout( static_cast<IPersistSoapServer*>(this), dwTimeoutSecs);

		return S_OK;
	}


	// This is a sample web service method that shows how to use the 
	// soap_method attribute to expose a method as a web method
	
	[soap_method]
	[soap_header(value="m_bstrStorageKey")]
	HRESULT HelloWorld(/*[in]*/ BSTR bstrInput, /*[out, retval]*/ BSTR *bstrOutput)
	{
		CPersistentHandler	persistHandler(static_cast<IPersistSoapServer*>(this), m_spServiceProvider);

		ATLASSERT( persistHandler.loaded() );

		CW2A	strIn( bstrInput);

		m_strData	+=	strIn;

		CComBSTR	retVal;
		retVal.Append( m_strData);
		*bstrOutput	=	retVal.Detach();
		
		return S_OK;
	}
	// TODO: Add additional web service methods here
}; // class CSStateService

} // namespace SStateService

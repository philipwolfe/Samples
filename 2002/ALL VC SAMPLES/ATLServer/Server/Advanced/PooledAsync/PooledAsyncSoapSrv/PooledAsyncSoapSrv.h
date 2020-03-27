// MidSrv.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include <commonPool.h>
namespace PoolAsyncSoapSrv
{
// all struct, enum, and typedefs for your webservice should go inside the namespace


// IPoolAsyncSoapService - web service interface declaration
//
[
	uuid("2B85DA74-DCD8-41AF-AC66-6D7D789E270D"), 
	object
]
__interface IPoolAsyncSoapService
{
	// HelloWorld is a sample ATL Server web service method.  It shows how to
	// declare a web service method and its in-parameters and out-parameters
	[id(1)] HRESULT performStringOperation([in] BSTR bstrInput, [out, retval] BSTR *bstrOutput);
};



// PoolAsyncSoapService - web service implementation
//
[
	request_handler(name="Default", sdl="GenPoolAsyncSoapServiceWSDL"),
	soap_handler(
		name="PoolAsyncSoapService", 
		namespace="urn:PoolAsyncSoapService",
		protocol="soap"
	)
]
class CPoolAsyncSoapService :
	public IPoolAsyncSoapService,
	public IAsyncSoapHandler
{

public:
	AtlServerRequest	*m_pRequestInfo;

	CStringA			_response;

	
public:
	DECLARE_ASYNC_HANDLER_EX()

	CPoolAsyncSoapService():m_pRequestInfo(NULL)
	{
	}


	HTTP_CODE HandleRequest(AtlServerRequest *pRequestInfo, IServiceProvider *pProvider) throw()
	{
		ATLTRACE("Handling Request \n");
		if( pRequestInfo->dwRequestState	==	ATLSRV_STATE_BEGIN)
		{
			// First handleRequest
			ATLTRACE("First Handle Request \n");
			HRESULT		hRetErrorCode = HTTP_SUCCESS;

// Copy the code from CSoapRootHandler::HandleRequest
			// we will allow omission of the SOAPAction header
			// and attempt to continue processing.
			// We will fail iff the client attempts to send headers without
			// sending the SOAPAction header

			char szBuf[ATL_URL_MAX_URL_LENGTH+1];
			szBuf[0] = '\0';
			DWORD dwLen = ATL_URL_MAX_URL_LENGTH;
			if (m_spServerContext->GetServerVariable("HTTP_SOAPACTION", szBuf, &dwLen) != FALSE)
			{
				// drop the last "
				szBuf[dwLen-2] = '\0';
				char *szMethod = strrchr(szBuf, '#');
				if (szMethod != NULL)
				{
					_ATLTRY
					{
						// ignore return code here
						SetSoapMapFromName(CA2W( szMethod+1 ), -1, GetNamespaceUri(), -1, true);
					}
					_ATLCATCHALL()
					{
						return AtlsHttpError(500, ISE_SUBERR_OUTOFMEM);
					}
				}
			}
	
			CStreamOnServerContext s(pRequestInfo->pServerContext);

	#ifdef _DEBUG

			CSAXSoapErrorHandler err;
			GetReader()->putErrorHandler(&err);

	#endif // _DEBUG

			hRetErrorCode = BeginParse(&s);

	#ifdef _DEBUG
			// release the error handler
			GetReader()->putErrorHandler(NULL);
	#endif // _DEBUG

			if (FAILED(hRetErrorCode))
			{
				Cleanup();
				if (m_hcErr == HTTP_SUCCESS)
				{
					CHttpResponse HttpResponse(pRequestInfo->pServerContext);
					m_pHttpResponse = &HttpResponse;
					SoapFault(SOAP_E_CLIENT, NULL, NULL);
				}

				return m_hcErr;
			}
// End copy the code from CSoapRootHandler::HandleRequest

// Now, attempt to post  the request to the thread pool
			if( SUCCEEDED(hRetErrorCode) ) 
			{
				m_pRequestInfo	=	pRequestInfo;


				IThreadPoolService	*pThreadPoolSvc	=	NULL;
				hRetErrorCode	=	pProvider->QueryService(__uuidof(IThreadPoolService), __uuidof(IThreadPoolService), (void**) &pThreadPoolSvc );
				if( SUCCEEDED(hRetErrorCode) )
				{
					
					CPoolAsyncSoapService		*pThis	=	static_cast<CPoolAsyncSoapService*>(pRequestInfo->pHandler);
					IAsyncSoapHandler	*pAsyncHandler  =	static_cast<IAsyncSoapHandler*>(pThis);
					
					if( !pThreadPoolSvc->QueueRequest(pAsyncHandler, FALSE) )
					{
						// Cannot handle this request
						hRetErrorCode	=	E_FAIL;
					}
				}

			}

			if( FAILED(hRetErrorCode) )
			{
				CHttpResponse HttpResponse(pRequestInfo->pServerContext);
				m_pHttpResponse = &HttpResponse;
				SoapFault(SOAP_E_SERVER, NULL, NULL);
				return hRetErrorCode;
			}

			return HTTP_SUCCESS_ASYNC_NOFLUSH;
		}
		else
		{
			ATLTRACE("Second Handle Request \n");
			char	buffSize[10];
			ATLASSERT( !_response.IsEmpty() );
			CHttpResponse HttpResponse(pRequestInfo->pServerContext);
			m_pHttpResponse	=	&HttpResponse;

			itoa(_response.GetLength(), buffSize, 10);
			HttpResponse.AppendHeader("Content-Length", buffSize);
			HttpResponse.AsyncPrep();

			pRequestInfo->pszBuffer	  = LPCSTR(_response);
			pRequestInfo->dwBufferLen = _response.GetLength();

			return HTTP_SUCCESS_ASYNC_DONE;
		}

	
		
	}


	void	processRequest()
	{
		ATLTRACE("Process Request \n");
		HRESULT				hr;
		bool				bContinue = true;
		
		
		CHttpResponse HttpResponse(m_pRequestInfo->pServerContext);
		m_pHttpResponse		=	&HttpResponse;
		HttpResponse.HaveSentHeaders(TRUE);
		HttpResponse.SetWriteToClient(FALSE);



		_ATLTRY
		{
			hr = CallFunctionInternal();
		}
		_ATLCATCHALL()
		{
			// cleanup before propagating user exception
			Cleanup();
			HttpResponse.Detach();
			_ATLRETHROW;
		}

		if (FAILED(hr))
		{
			bContinue = false;
			Cleanup();
			HttpResponse.ClearHeaders();
			HttpResponse.ClearContent();
			
			if (m_hcErr != HTTP_SUCCESS)
			{
				HttpResponse.SetStatusCode(HTTP_ERROR_CODE(m_hcErr));
				bContinue	=	false;
			}
			else
			{
				HttpResponse.SetStatusCode(500);
				GenerateAppError(&HttpResponse, hr);
				hr	=	 AtlsHttpError(500, SUBERR_NO_PROCESS);
			}
		}

		
		if( bContinue )
		{
			//HttpRee
			HttpResponse.SetContentType("text/xml");
			hr = GenerateResponse(&HttpResponse);
			Cleanup();
			if (FAILED(hr))
			{
				hr	=	SoapFault(SOAP_E_SERVER, NULL, NULL);
				bContinue	=	false;
			}
		}

 		
		// Save the response buffer
		_response	=	HttpResponse.m_strContent;		
		ATLTRACE("Requeing \n");
		m_pRequestInfo->pExtension->QueueRequest( m_pRequestInfo );
	}



		

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
}; // class CPoolAsyncSoapService

} // namespace PoolAsyncSoapService

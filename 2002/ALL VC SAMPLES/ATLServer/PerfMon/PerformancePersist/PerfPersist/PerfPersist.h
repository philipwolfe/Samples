// PerfPersist.h
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// PerfPersist.h : Defines the ATL Server request handler class
//
#pragma once

#include "FibonacciPerf.h"
#include "PerfService.h"
#include <atlsync.h>

[ request_handler("Default") ]
class CPerfPersistHandler
{
private:
	// Put private members here

protected:
	// Put protected members here
	CFibonacciPerf* m_pFibonacciPerf;
	CFibonacciStats* m_pFibonacciStats;
	CComPtr<IFibonacciPerfService> m_spService;

	HRESULT GetPerfService()
	{
		// here we register a service that creates one global instance
		// of our CPerfMon object that's shared by all requests
		HRESULT hr;
		hr = m_spServiceProvider->QueryService(__uuidof(IFibonacciPerfService), &m_spService);
		if (FAILED(hr))
		{
			CComQIPtr<IIsapiExtension> spExtension = m_spServiceProvider;
			if (!spExtension)
				return E_FAIL;
			else
			{
				CComObject<CFibonacciPerfService>* pServiceOb;
				hr = CComObject<CFibonacciPerfService>::CreateInstance(&pServiceOb);
				if (FAILED(hr) || pServiceOb == NULL)
					return E_FAIL;
				m_spService = pServiceOb;

				hr = spExtension->AddService(
					__uuidof(IFibonacciPerfService),
					__uuidof(IFibonacciPerfService),
					m_spService,
					_pModule->GetModuleInstance());
				if (FAILED(hr))
					return E_FAIL;
			}
		}

		return S_OK;
	}

public:
	// Put public members here
	CString m_strRequest;

	HTTP_CODE ValidateAndExchange()
	{
		HRESULT hr;

		hr = GetPerfService();
		if (FAILED(hr))
		{
#ifdef _DEBUG
			CString str;
			str.Format("Failure Loading Perf Service: %8.8x", hr);
			m_HttpResponse << str;
#endif
			return HTTP_FAIL;
		}

		hr = m_spService->GetFibonacciPerf(&m_pFibonacciPerf);
		if (FAILED(hr))
		{
#ifdef _DEBUG
			CString str;
			str.Format("Failure retreiving Fibonacci Perf from Perf Service: %8.8x", hr);
			m_HttpResponse << str;
#endif
			return HTTP_FAIL;
		}

		hr = m_pFibonacciPerf->CreateInstance(1, L"Fibonacci Stats", &m_pFibonacciStats);
		if (FAILED(hr))
		{
#ifdef _DEBUG
			CString str;
			str.Format("Failure creating Fibonacci Stats: %8.8x", hr);
			m_HttpResponse << str;
#endif
			return HTTP_FAIL;
		}

		// TODO: Put all initialization and validation code here
		m_strRequest = m_HttpRequest.FormVars.Lookup("request");
		
		// Set the content-type
		m_HttpResponse.SetContentType("text/html");
		
		return HTTP_SUCCESS;
	}
 
	int fibonacci(int nRequest)
	{
		m_pFibonacciStats->m_dwRecursiveCalls++;
		if (nRequest < 1)
			return 0;
		else if (nRequest == 1 || nRequest == 2)
			return 1;
		else if (nRequest > 50)
			return 0;
		else
			return fibonacci(nRequest-1) + fibonacci(nRequest-2);
	}

	// Here is an example of how to use a replacement tag with the stencil processor
	[ tag_name(name="Result") ]
	HTTP_CODE OnResult(void)
	{
		if (!m_strRequest.IsEmpty())
		{
			int nRequest = _ttoi(m_strRequest);
			m_pFibonacciStats->m_dwNumRequests++;
			m_pFibonacciStats->m_dwLastRequest = nRequest;
			m_HttpResponse << "The fibonacci of " << nRequest << " is " << fibonacci(nRequest);
		}

		return HTTP_SUCCESS;
	}
}; // class CPerfPersistHandler

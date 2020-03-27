// PerformanceCounter.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

class CPerformanceCounterHandler
	: public CRequestHandlerT<CPerformanceCounterHandler>
{
private:
	// Put private members here
	CComPtr<ISampleCounter> counter;

protected:
	// Put protected members here

public:
	// Put public members here

	// TODO: Add additional tags to the replacement method map
	BEGIN_REPLACEMENT_METHOD_MAP(CPerformanceCounterHandler)
		REPLACEMENT_METHOD_ENTRY("SampleTitle", OnTitle)
	END_REPLACEMENT_METHOD_MAP()

	HTTP_CODE ValidateAndExchange()
	{
		m_HttpResponse.SetContentType("text/html");
	
		HRESULT hr = m_spServiceProvider->QueryService(__uuidof(ISampleCounter), __uuidof(ISampleCounter), reinterpret_cast<void**>(&counter));
		if (FAILED(hr))
			counter = 0;

		const CHttpRequestParams& formFields = m_HttpRequest.GetFormVars();

		if (formFields.Lookup("Submit1"))
			counter->IncCounter(0);

		if (formFields.Lookup("Submit2"))
			counter->IncCounter(1);

		if (formFields.Lookup("Submit3"))
			counter->IncCounter(2);

		return HTTP_SUCCESS;
	}
 
protected:
	// Here is an example of how to use a replacement tag with the stencil processor
	HTTP_CODE OnTitle(void)
	{
		m_HttpResponse << "ATL Server PerformanceCounter Sample";

		return HTTP_SUCCESS;
	}
}; // class CPerformanceCounterHandler

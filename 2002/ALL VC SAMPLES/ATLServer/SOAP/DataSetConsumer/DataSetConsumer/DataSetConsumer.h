// DataSetConsumer.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

//=============================================================================
// This line makes the reference to the proxy class generated by sproxy 
// from your webservice. If you have another name for the header file that
// was created by sproxy then change this line to reflect it. If you accepted
// the default then you should not have to make any changes on this line.
//=============================================================================
#include "Service1.h"

#pragma once

[ request_handler("Default") ]
class CDataSetConsumerHandler
{
private:
	// Put private members here

protected:
	// Put protected members here

public:
	// Put public members here

	HTTP_CODE ValidateAndExchange()
	{
		// TODO: Put all initialization and validation code here
		
		// Set the content-type
		m_HttpResponse.SetContentType("text/html");
		
		return HTTP_SUCCESS;
	}
 
protected:
//==============================================================================
// Implementation:
// Here is an example of how to use a replacement tag with the stencil processor
//==============================================================================
	[ tag_name(name="Parse") ]
	HTTP_CODE OnParse(void)
	{

		CComBSTR bstrXML;
		
//=====================================================================================
// Call into WebService Proxy that you generated. If the call fails, exit gracefully.
//=====================================================================================
		Service1::CService1T<CSoapSocketClientT<> > *myService =
			new Service1::CService1T<CSoapSocketClientT<> > ();
		HRESULT hr = myService->GetDataSet(&bstrXML);
		if( FAILED(hr) ){
			m_HttpResponse << "<br><br><b>ERROR:</b> Could not call the GetDataSet Web Service method.<br><br>";
			return HTTP_SUCCESS;
		}

//=====================================================================================
// Use the DOM.
//=====================================================================================		
		CComPtr<IXMLDOMDocument> spDoc;
		hr = spDoc.CoCreateInstance(__uuidof(DOMDocument));
		if (FAILED(hr))
		{
			m_HttpResponse << "<br><br><b>ERROR:</b> CoCreateInstance failed<br><br>";
			return HTTP_SUCCESS;
		}

//=====================================================================================
// Load the XML stream into the DOM. Then parse the tree and print some of the data.
//=====================================================================================
		VARIANT_BOOL varLoadSuccessful;
		CComBSTR bstrFrag;
		bstrFrag.Append(L"<DataSetFrag>");
		bstrFrag.AppendBSTR(bstrXML);
		bstrFrag.Append(L"</DataSetFrag>");

		hr = spDoc->loadXML(bstrFrag, &varLoadSuccessful);
		if (FAILED(hr) || varLoadSuccessful != VARIANT_TRUE)
		{
			CComPtr<IXMLDOMParseError> spErr;
			hr = spDoc->get_parseError(&spErr);
			if (FAILED(hr))
			{
				m_HttpResponse << "<br><br><b>ERROR:</b> Failed loading the XML stream into the DOM.<br><br>";
			}
			else
			{	
				CComBSTR bstrReason;
				hr = spErr->get_reason(&bstrReason);
				m_HttpResponse << "<br><br><b>ERROR:</b> " << bstrReason << "<br><br>";
				m_HttpResponse << "<font color=red>" << bstrFrag << "</font><br><br>";
			}
			return HTTP_SUCCESS;
		}
		
		CComPtr<IXMLDOMNode> spChild1;
		hr = spDoc->get_firstChild(&spChild1);
		
//=====================================================================================
// Traverse the tree and print out an XML node that contains data from the dataset
// you exposed in your Web Service.
//=====================================================================================
		m_HttpResponse << "<table align=\"center\" width=\"75%\" border=\"1\"><tr><td>\n";
		while (spChild1 != NULL)
		{
			CComBSTR bstrBaseName;
			hr = spChild1->get_text(&bstrBaseName);
			m_HttpResponse << bstrBaseName ;
			CComPtr<IXMLDOMNode> spNext;
			hr = spChild1->get_nextSibling(&spNext);
			spChild1.Release();
			spChild1.Attach( spNext.Detach() );
		}
		m_HttpResponse << "</td></tr></table>\n";

		return HTTP_SUCCESS;
	} 

}; // class CDataSetConsumerHandler

// TipOfTheDay.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include <time.h>			// need this to see the random function to get a random tip

// Smart pointers that we will use when building the current random tip.
_COM_SMARTPTR_TYPEDEF(IXMLDOMDocument,	__uuidof(IXMLDOMDocument));
_COM_SMARTPTR_TYPEDEF(IXMLDOMElement,	__uuidof(IXMLDOMElement));
_COM_SMARTPTR_TYPEDEF(IXMLDOMNodeList,	__uuidof(IXMLDOMNodeList));
_COM_SMARTPTR_TYPEDEF(IXMLDOMNode,		__uuidof(IXMLDOMNode));

// For custom assert and trace handling with WebDbg.exe
#ifdef _DEBUG
CDebugReportHook g_ReportHook;
#endif

#include "TipOfTheDay.h"
[ module(name="TipOfTheDay", type="dll") ]
class CDllMainOverride
{
public:
	BOOL WINAPI DllMain(DWORD dwReason, LPVOID lpReserved)
	{
#if defined(_M_IX86)
		// stack overflow handler
		_set_security_error_handler( AtlsSecErrHandlerFunc );
#endif
		return __super::DllMain(dwReason, lpReserved);
	}
};

[ emitidl(restricted) ];

//
// Method: ValidateAndExchange
// Purpose: Overrideable allows us to interogate the query string or post data 
//			along with other information at this time before processing the 
//			requested file. Also an initialization point.
//
HTTP_CODE CTipOfTheDayHandler::ValidateAndExchange()
{

	// TODO: Put all initialization and validation code here
	m_bInited = false;
	m_bsCategoryMajor = "";
	m_bsCategoryMinor = "";
	m_bsTipOfTheDay = "";
	m_bsSource = "Unknown";

	// Set the content-type
	m_HttpResponse.SetContentType("text/html");
	
	return HTTP_SUCCESS;
}

//
// Method: OnDisplayVersion
// Purpose: Tag handler for displaying the application name and version
//
HTTP_CODE CTipOfTheDayHandler::OnDisplayVersion(void)
{
	m_HttpResponse << "Tip Of The Day ATL Server 1.0";
	return HTTP_SUCCESS;
}

//
// Method: OnRandomTip
// Purpose: This initializes the remaining methods in which the random tips 
//			contents are returned. This method builds the location to the tips, 
//			loads them, gets a random tip and sets the tips contents to the corresponding fields.
//
HTTP_CODE CTipOfTheDayHandler::OnRandomTip(void)
{
	HRESULT hr = S_OK;
	IXMLDOMDocumentPtr ptrTipsFile = NULL;
	hr = ptrTipsFile.CreateInstance(CLSID_DOMDocument);
	if (SUCCEEDED(hr) && ptrTipsFile != NULL)
	{
		// build path to tip of the day xml file
		CString strPath;
		m_HttpRequest.GetPhysicalPath(strPath);
		strPath.Append("TipOfTheDay.xml");

		// load document
		VARIANT_BOOL vbLoaded = VARIANT_FALSE;
		ptrTipsFile->put_async(VARIANT_FALSE);
		hr = ptrTipsFile->load(_variant_t(strPath), &vbLoaded);
		if (SUCCEEDED(hr) && vbLoaded == VARIANT_TRUE)
		{
			IXMLDOMElementPtr ptrDocRoot = NULL;
			hr = ptrTipsFile->get_documentElement(&ptrDocRoot);
			if (SUCCEEDED(hr) && ptrDocRoot != NULL)
			{
				IXMLDOMNodeListPtr ptrTipsList = NULL;
				hr = ptrDocRoot->get_childNodes(&ptrTipsList);
				if (SUCCEEDED(hr) && ptrTipsList != NULL)
				{
					long lTipCount = 0;
					hr = ptrTipsList->get_length(&lTipCount);
					if (SUCCEEDED(hr) && lTipCount)
					{
						IXMLDOMNodePtr ptrTip = NULL;
						// randomize and load tip of the day
						// seed random number generator
						srand( (unsigned)time( NULL ) );
						hr = ptrTipsList->get_item(rand() % lTipCount, &ptrTip);
						if (SUCCEEDED(hr) && ptrTip != NULL)
						{
							/*
								<CategoryMajor>ATL Server</CategoryMajor>
								<CategoryMinor>SRF include Tag</CategoryMinor>
								<TipText>Files included by using the include tag do not have to be files of .SRF extension. The include can be another ATLServer DLL, HTML file, TXT file, or SRF File for examples.</TipText>
								<Source>Erik Thompson</Source>
							*/
							IXMLDOMNodePtr ptrField = NULL;
							_bstr_t bsField;
							BSTR bstrText = NULL;
							
							bsField = "CategoryMajor";
							hr = ptrTip->selectSingleNode(bsField, &ptrField);
							if (SUCCEEDED(hr) && ptrField != NULL)
							{
								ptrField->get_text(&bstrText);
								m_bsCategoryMajor = bstrText;
								SysFreeString(bstrText), bstrText = NULL;
								ptrField = NULL;
							}

							bsField = "CategoryMinor";
							hr = ptrTip->selectSingleNode(bsField, &ptrField);
							if (SUCCEEDED(hr) && ptrField != NULL)
							{
								ptrField->get_text(&bstrText);
								m_bsCategoryMinor = bstrText;
								SysFreeString(bstrText), bstrText = NULL;
								ptrField = NULL;
							}

							bsField = "TipText";
							hr = ptrTip->selectSingleNode(bsField, &ptrField);
							if (SUCCEEDED(hr) && ptrField != NULL)
							{
								ptrField->get_text(&bstrText);
								m_bsTipOfTheDay = bstrText;
								SysFreeString(bstrText), bstrText = NULL;
								ptrField = NULL;
							}

							bsField = "Source";
							hr = ptrTip->selectSingleNode(bsField, &ptrField);
							if (SUCCEEDED(hr) && ptrField != NULL)
							{
								ptrField->get_text(&bstrText);
								m_bsSource = bstrText;
								SysFreeString(bstrText), bstrText = NULL;
								ptrField = NULL;
							}

							ptrTip = NULL;
						}
					}
					ptrTipsList = NULL;
				}
				ptrDocRoot = NULL;
			}
		}
		ptrTipsFile=NULL;
	}
	m_bInited = true;
	return HTTP_SUCCESS;
}

//
// Method: OnTipCategoryMajor
// Purpose: Writes to the response object the contents of the category major for the tip
//
HTTP_CODE CTipOfTheDayHandler::OnTipCategoryMajor(void)
{
	if (IsInited())
	{
		m_HttpResponse << static_cast<TCHAR*>(m_bsCategoryMajor);
	}
	return HTTP_SUCCESS;
}

//
// Method: OnTipCategoryMinor
// Purpose: Writes to the response object the contents of the category minor for the tip
//
HTTP_CODE CTipOfTheDayHandler::OnTipCategoryMinor(void)
{
	if (IsInited())
	{
		m_HttpResponse << static_cast<TCHAR*>(m_bsCategoryMinor);
	}
	return HTTP_SUCCESS;
}

//
// Method: OnTipInfo 
// Purpose: Writes to the response object the tip f the day
//
HTTP_CODE CTipOfTheDayHandler::OnTipInfo(void)
{
	if (IsInited(true))
	{
		m_HttpResponse << static_cast<TCHAR*>(m_bsTipOfTheDay);
	}
	return HTTP_SUCCESS;
}

//
// Method: OnTipSource
// Purpose: Writes to the response object the source that was identified for the tip
//
HTTP_CODE CTipOfTheDayHandler::OnTipSource(void)
{
	if (IsInited())
	{
		m_HttpResponse << static_cast<TCHAR*>(m_bsSource);
	}
	return HTTP_SUCCESS;
}

//
// sproxy.exe generated file
// do not modify this file
// 
// Created: 01/16/2001@21:31:31.48 GMT
//

#include <winsock2.h>
#include <windows.h>
#include <atlsoap.h>



struct _tagAccessories
{
	BSTR bstrName;
	BSTR bstrDescription;
	float fPrice;
};

inline HRESULT AtlGetXMLValue<_tagAccessories>(IXMLDOMNode *pNode, _tagAccessories *pVal, ATL_ID_HASH *pidHash)
{
	CComPtr<IXMLDOMNode> pParam;
	
	HRESULT hr = GetHref(pNode, &pParam, pidHash);
	if (FAILED(hr))
		return hr;
		
	int nFieldCount = 3;

	CComPtr<IXMLDOMNodeList> spFields;

	pParam->get_childNodes(&spFields);

	long lCount = 0;

	if (spFields)
	{
		hr = spFields->get_length(&lCount);
		if (FAILED(hr))
		{
			return hr;
		}
	}
	
	CComBSTR bstrName;
	
	for (long lIndex=0; lIndex<lCount; lIndex++)
	{
		CComPtr<IXMLDOMNode> spField;
		hr = spFields->get_item(lIndex, &spField);
		if (FAILED(hr))
			return hr;

		bstrName.Empty();		
		hr = spField->get_baseName(&bstrName);
		if (FAILED(hr))
			return hr;

		if (!wcscmp(bstrName, L"bstrName"))
		{
			AtlGetXMLValue(spField, &pVal->bstrName, pidHash);
			nFieldCount--;
			continue;
		}
		if (!wcscmp(bstrName, L"bstrDescription"))
		{
			AtlGetXMLValue(spField, &pVal->bstrDescription, pidHash);
			nFieldCount--;
			continue;
		}
		if (!wcscmp(bstrName, L"fPrice"))
		{
			AtlGetXMLValue(spField, &pVal->fPrice, pidHash);
			nFieldCount--;
			continue;
		}
	}
	if (nFieldCount != 0)
		return E_FAIL;
	return S_OK;	
}

inline HRESULT AtlCleanupValue<_tagAccessories>(_tagAccessories *pVal)
{
	AtlCleanupValue(&pVal->bstrName);
	AtlCleanupValue(&pVal->bstrDescription);
	AtlCleanupValue(&pVal->fPrice);
	return S_OK;
}

inline HRESULT AtlGenXMLValue<_tagAccessories>(IWriteStream *pStream, _tagAccessories *pVal)
{
	CWriteStreamHelper s(pStream);
	s << "<" << "bstrName";
	
	pStream->WriteStream(">", 1, NULL);
	AtlGenXMLValue(pStream, &pVal->bstrName);
	s << "</" << "bstrName" << ">\r\n";
	s << "<" << "bstrDescription";
	
	pStream->WriteStream(">", 1, NULL);
	AtlGenXMLValue(pStream, &pVal->bstrDescription);
	s << "</" << "bstrDescription" << ">\r\n";
	s << "<" << "fPrice";
	
	pStream->WriteStream(">", 1, NULL);
	AtlGenXMLValue(pStream, &pVal->fPrice);
	s << "</" << "fPrice" << ">\r\n";
	return S_OK;
}

struct _tagSpecials
{
	int nID;
	BSTR bstrName;
	float fPrice;
};

inline HRESULT AtlGetXMLValue<_tagSpecials>(IXMLDOMNode *pNode, _tagSpecials *pVal, ATL_ID_HASH *pidHash)
{
	CComPtr<IXMLDOMNode> pParam;
	
	HRESULT hr = GetHref(pNode, &pParam, pidHash);
	if (FAILED(hr))
		return hr;
		
	int nFieldCount = 3;

	CComPtr<IXMLDOMNodeList> spFields;

	pParam->get_childNodes(&spFields);

	long lCount = 0;

	if (spFields)
	{
		hr = spFields->get_length(&lCount);
		if (FAILED(hr))
		{
			return hr;
		}
	}
	
	CComBSTR bstrName;
	
	for (long lIndex=0; lIndex<lCount; lIndex++)
	{
		CComPtr<IXMLDOMNode> spField;
		hr = spFields->get_item(lIndex, &spField);
		if (FAILED(hr))
			return hr;

		bstrName.Empty();		
		hr = spField->get_baseName(&bstrName);
		if (FAILED(hr))
			return hr;

		if (!wcscmp(bstrName, L"nID"))
		{
			AtlGetXMLValue(spField, &pVal->nID, pidHash);
			nFieldCount--;
			continue;
		}
		if (!wcscmp(bstrName, L"bstrName"))
		{
			AtlGetXMLValue(spField, &pVal->bstrName, pidHash);
			nFieldCount--;
			continue;
		}
		if (!wcscmp(bstrName, L"fPrice"))
		{
			AtlGetXMLValue(spField, &pVal->fPrice, pidHash);
			nFieldCount--;
			continue;
		}
	}
	if (nFieldCount != 0)
		return E_FAIL;
	return S_OK;	
}

inline HRESULT AtlCleanupValue<_tagSpecials>(_tagSpecials *pVal)
{
	AtlCleanupValue(&pVal->nID);
	AtlCleanupValue(&pVal->bstrName);
	AtlCleanupValue(&pVal->fPrice);
	return S_OK;
}

inline HRESULT AtlGenXMLValue<_tagSpecials>(IWriteStream *pStream, _tagSpecials *pVal)
{
	CWriteStreamHelper s(pStream);
	s << "<" << "nID";
	
	pStream->WriteStream(">", 1, NULL);
	AtlGenXMLValue(pStream, &pVal->nID);
	s << "</" << "nID" << ">\r\n";
	s << "<" << "bstrName";
	
	pStream->WriteStream(">", 1, NULL);
	AtlGenXMLValue(pStream, &pVal->bstrName);
	s << "</" << "bstrName" << ">\r\n";
	s << "<" << "fPrice";
	
	pStream->WriteStream(">", 1, NULL);
	AtlGenXMLValue(pStream, &pVal->fPrice);
	s << "</" << "fPrice" << ">\r\n";
	return S_OK;
}

class CDigiServiceService : public CSoapSocketClient
{
public:
	CComPtr<IXMLDOMDocument> m_spDoc;
	CComPtr<IXMLDOMNode> m_spHeader;
	CComPtr<IXMLDOMNode> m_spMethod;
	ATL_ID_HASH m_idHash;
	
	// constructor
	CDigiServiceService() :
		CSoapSocketClient(_T("http://localhost/Cameras/DigiService.dll?Handler=Default"))
	{
	}
	
	HRESULT BeginParse()
	{
		return ::BeginParse(&m_spDoc, &m_spHeader, &m_spMethod, &m_idHash, &m_ReadStream);
	}
	
	void Cleanup()
	{
		m_spMethod.Release();
		m_spHeader.Release();
		m_spDoc.Release();
		m_idHash.RemoveAll();
		CSoapSocketClient::Cleanup();
	}

	// you must call this function to initialize the internal header map
	HRESULT Initialize()
	{
		return S_OK;
	}

	HRESULT GetSpecials(int *count, _tagSpecials **__retval)
	{
		Cleanup();
		if (count == NULL)
			return E_INVALIDARG;
		if (__retval == NULL)
			return E_INVALIDARG;
		memset(__retval, 0x00, sizeof(*__retval));
		int __size___retval(0);
		
		HRESULT __atl__soap__hr = S_OK;
		
		CComBSTR __atl__soap__bstrName;
		int __atl__soap__nParamCount = 2;
		CComBSTR __atl__soap__bstrMethod;
		CComPtr<IXMLDOMNodeList> __atl__soap__spParams;
		long __atl__soap__lCount = 0;

		m_Stream.WriteStream("<SOAP:Envelope  xmlns:snp=\"urn:DigiServiceService\" xmlns:SOAP=\"http://schemas.xmlsoap.org/soap/envelope/\">\n", -1, NULL);
		m_Stream.WriteStream("    <SOAP:Body>\r\n<snp:GetSpecials>", -1, NULL);
		m_Stream.WriteStream("<count", -1, NULL);
		
		m_Stream.WriteStream(">", -1, NULL);
		__atl__soap__hr = AtlGenXMLValue(&m_Stream, count);
		if (__atl__soap__hr != S_OK)
			return __atl__soap__hr;
		m_Stream.WriteStream("</count>", -1, NULL);
		m_Stream.WriteStream("</snp:GetSpecials>\n</SOAP:Body>\n</SOAP:Envelope>", -1, NULL);
		__atl__soap__hr = SendRequest(_T("SOAPAction: urn:DigiServiceService#GetSpecials\r\n"));
		if (FAILED(__atl__soap__hr))
			return __atl__soap__hr;
		__atl__soap__hr = BeginParse();
		if (FAILED(__atl__soap__hr))
			return __atl__soap__hr;
		
		__atl__soap__hr = m_spMethod->get_baseName(&__atl__soap__bstrMethod);
		if (FAILED(__atl__soap__hr))
			return __atl__soap__hr;
		if (wcscmp(__atl__soap__bstrMethod, L"GetSpecialsResponse"))
			return E_FAIL;
		
		m_spMethod->get_childNodes(&__atl__soap__spParams);
		if (__atl__soap__spParams)
		{
			__atl__soap__hr = __atl__soap__spParams->get_length(&__atl__soap__lCount);
			if (FAILED(__atl__soap__hr))
				return __atl__soap__hr;
		}
		
		for (long __atl__soap__lIndex=0; __atl__soap__nParamCount > 0 && __atl__soap__lIndex<__atl__soap__lCount; __atl__soap__lIndex++)
		{
			CComPtr<IXMLDOMNode> __atl__soap__spParam;
			__atl__soap__hr = __atl__soap__spParams->get_item(__atl__soap__lIndex, &__atl__soap__spParam);
			if (FAILED(__atl__soap__hr))
				goto Cleanup;
			
			__atl__soap__bstrName.Empty();
			__atl__soap__hr = __atl__soap__spParam->get_baseName(&__atl__soap__bstrName);
			if (FAILED(__atl__soap__hr))
				goto Cleanup;
	
			if (!wcscmp(__atl__soap__bstrName, L"count"))
			{
				__atl__soap__hr = AtlGetXMLValue(__atl__soap__spParam, count, &m_idHash);if (__atl__soap__hr != S_OK) goto Cleanup;
				__atl__soap__nParamCount--;
				continue;
			}
			if (!wcscmp(__atl__soap__bstrName, L"return"))
			{
				{
					int __size__ = -1; 
					__atl__soap__hr = AtlGetXMLArrayValue(__atl__soap__spParam, __retval, &__size__, &m_idHash, true, &__size___retval);
					}if (__atl__soap__hr != S_OK) goto Cleanup;
				__atl__soap__nParamCount--;
				continue;
			}
		}
	
		if (__atl__soap__nParamCount != 0)
		{
			// some out parameters were not found
			return E_FAIL;
		}
		return S_OK;
Cleanup:
		if (count != NULL)
			AtlCleanupValue(count);
		if (__retval != NULL)
		{
			if (__size___retval > 0)
			{
				int __size__[] = { 1, __size___retval };
				AtlCleanupArray(*__retval, __size__);
				free(*__retval);
			}
		}
		return __atl__soap__hr;
	}

	HRESULT GetAccessories(int nCameraID, int *count, _tagAccessories **__retval)
	{
		Cleanup();
		if (count == NULL)
			return E_INVALIDARG;
		if (__retval == NULL)
			return E_INVALIDARG;
		memset(__retval, 0x00, sizeof(*__retval));
		int __size___retval(0);
		
		HRESULT __atl__soap__hr = S_OK;
		
		CComBSTR __atl__soap__bstrName;
		int __atl__soap__nParamCount = 2;
		CComBSTR __atl__soap__bstrMethod;
		CComPtr<IXMLDOMNodeList> __atl__soap__spParams;
		long __atl__soap__lCount = 0;

		m_Stream.WriteStream("<SOAP:Envelope  xmlns:snp=\"urn:DigiServiceService\" xmlns:SOAP=\"http://schemas.xmlsoap.org/soap/envelope/\">\n", -1, NULL);
		m_Stream.WriteStream("    <SOAP:Body>\r\n<snp:GetAccessories>", -1, NULL);
		m_Stream.WriteStream("<nCameraID", -1, NULL);
		
		m_Stream.WriteStream(">", -1, NULL);
		__atl__soap__hr = AtlGenXMLValue(&m_Stream, &nCameraID);
		if (__atl__soap__hr != S_OK)
			return __atl__soap__hr;
		m_Stream.WriteStream("</nCameraID>", -1, NULL);
		m_Stream.WriteStream("<count", -1, NULL);
		
		m_Stream.WriteStream(">", -1, NULL);
		__atl__soap__hr = AtlGenXMLValue(&m_Stream, count);
		if (__atl__soap__hr != S_OK)
			return __atl__soap__hr;
		m_Stream.WriteStream("</count>", -1, NULL);
		m_Stream.WriteStream("</snp:GetAccessories>\n</SOAP:Body>\n</SOAP:Envelope>", -1, NULL);
		__atl__soap__hr = SendRequest(_T("SOAPAction: urn:DigiServiceService#GetAccessories\r\n"));
		if (FAILED(__atl__soap__hr))
			return __atl__soap__hr;
		__atl__soap__hr = BeginParse();
		if (FAILED(__atl__soap__hr))
			return __atl__soap__hr;
		
		__atl__soap__hr = m_spMethod->get_baseName(&__atl__soap__bstrMethod);
		if (FAILED(__atl__soap__hr))
			return __atl__soap__hr;
		if (wcscmp(__atl__soap__bstrMethod, L"GetAccessoriesResponse"))
			return E_FAIL;
		
		m_spMethod->get_childNodes(&__atl__soap__spParams);
		if (__atl__soap__spParams)
		{
			__atl__soap__hr = __atl__soap__spParams->get_length(&__atl__soap__lCount);
			if (FAILED(__atl__soap__hr))
				return __atl__soap__hr;
		}
		
		for (long __atl__soap__lIndex=0; __atl__soap__nParamCount > 0 && __atl__soap__lIndex<__atl__soap__lCount; __atl__soap__lIndex++)
		{
			CComPtr<IXMLDOMNode> __atl__soap__spParam;
			__atl__soap__hr = __atl__soap__spParams->get_item(__atl__soap__lIndex, &__atl__soap__spParam);
			if (FAILED(__atl__soap__hr))
				goto Cleanup;
			
			__atl__soap__bstrName.Empty();
			__atl__soap__hr = __atl__soap__spParam->get_baseName(&__atl__soap__bstrName);
			if (FAILED(__atl__soap__hr))
				goto Cleanup;
	
			if (!wcscmp(__atl__soap__bstrName, L"count"))
			{
				__atl__soap__hr = AtlGetXMLValue(__atl__soap__spParam, count, &m_idHash);if (__atl__soap__hr != S_OK) goto Cleanup;
				__atl__soap__nParamCount--;
				continue;
			}
			if (!wcscmp(__atl__soap__bstrName, L"return"))
			{
				{
					int __size__ = -1; 
					__atl__soap__hr = AtlGetXMLArrayValue(__atl__soap__spParam, __retval, &__size__, &m_idHash, true, &__size___retval);
					}if (__atl__soap__hr != S_OK) goto Cleanup;
				__atl__soap__nParamCount--;
				continue;
			}
		}
	
		if (__atl__soap__nParamCount != 0)
		{
			// some out parameters were not found
			return E_FAIL;
		}
		return S_OK;
Cleanup:
		if (count != NULL)
			AtlCleanupValue(count);
		if (__retval != NULL)
		{
			if (__size___retval > 0)
			{
				int __size__[] = { 1, __size___retval };
				AtlCleanupArray(*__retval, __size__);
				free(*__retval);
			}
		}
		return __atl__soap__hr;
	}
};


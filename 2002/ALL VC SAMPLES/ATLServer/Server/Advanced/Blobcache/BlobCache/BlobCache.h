// BlobCache.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include <atlrx.h>
#include <string>
#include <fstream>
#include "VCUE_MemoryCache.h"

namespace VCUE
{
	HRESULT GetLineFromFile(const CStringA& strFile, const unsigned int nLine, std::string& strLine)
	{
		HRESULT hr = E_FAIL;
		std::ifstream fsFile;
		fsFile.open(strFile);
		if (fsFile.is_open())
		{
			hr = S_OK;
			for (unsigned int nCurrentLine = 0; nCurrentLine < nLine; ++nCurrentLine)
			{
				if (fsFile.eof() || !fsFile.good())
					return E_FAIL;

				std::getline(fsFile, strLine);
			}
		}

		return hr;
	}

} // namespace VCUE

const int CACHE_SIZE_LIMIT = 5;


[ request_handler("Default") ]
class CBlobCacheHandler
{
public:
	HTTP_CODE ValidateAndExchange()
	{
		HRESULT hr = E_UNEXPECTED;

		hr = QueryService(&m_spCache);
		if (FAILED(hr))
			return SendError("Failed to obtain the memory cache service.");

		hr = QueryService(&m_spCacheControl);
		if (FAILED(hr))
			return SendError("Failed to obtain the memory cache control service.");

		hr = QueryService(&m_spCacheStats);
		if (FAILED(hr))
			return SendError("Failed to obtain the memory cache statistics service.");

		hr = QueryService(&m_spCacheClient);
		if (FAILED(hr))
			return SendError("Failed to obtain the memory cache client service.");

		hr = m_spCacheControl->SetMaxAllowedEntries( CACHE_SIZE_LIMIT );
		if (FAILED(hr))
			return SendError("Failed to set the maximum number of entries in the cache.");

		hr = m_HttpResponse.SetContentType("text/html");
		const CHttpRequestParams& formFields = m_HttpRequest.GetFormVars();

		if (formFields.Lookup("Clearcache"))
		{
			hr = m_spCacheControl->ResetCache();
			if (SUCCEEDED(hr))
			{
				strStatus = "Successfully cleared the cache.";
				return HTTP_SUCCESS;
			}
			else
				return SendError("Failed to clear the cache.");
		}

		if (formFields.Lookup("Clearstats"))
		{
			hr = m_spCacheStats->ClearStats();
			if (SUCCEEDED(hr))
			{
				strStatus = "Successfully cleared the statistics.";
				return HTTP_SUCCESS;
			}
			else
				return SendError("Failed to clear the statistics.");
		}

		// Get the key of an item from the form data
		CStringA strKey = formFields.Lookup("keystr");
		
		// Remove leading & trailing whitespace
		strKey.Trim();

		// Check the length of the string.
		if (0 == strKey.GetLength())
		{
			strStatus = "No key entered. Please enter a numeric key between 1 and 100.";
			return HTTP_SUCCESS;
		}

		// Build a regular expression that matches up to three decimal digits in the range 1-100
		CAtlRegExp<CAtlRECharTraitsA> regularExpression;
		if (REPARSE_ERROR_OK != regularExpression.Parse("^[1-9][0-9]?0?$"))
			return SendError("Failed to parse a regular expression.");

		CAtlREMatchContext<CAtlRECharTraitsA> matchContext;
		if (!regularExpression.Match(strKey, &matchContext))
		{
			strStatus = "Invalid key entered. Please enter a numeric key between 1 and 100.";
			return HTTP_SUCCESS;
		}

		// Use the helper class to ensure that we don't leak any handles
		VCUE::CMemoryCacheHandle hEntry(m_spCache);
		hr = hEntry.Acquire(strKey);
		if (SUCCEEDED(hr))
		{
			DWORD dwSize = 0;
			LPSTR szData = 0;
			hr = hEntry.GetData(&szData, &dwSize);
			if (SUCCEEDED(hr))
			{
				// Copy the data so that we can release the cache handle.
				strData = szData;
				strStatus = "The data was obtained from the cache";
			}
			else
				return SendError("A call to IMemoryCache::GetData with a valid handle failed.");
		}
		else
		{
			strStatus = "The data was not found in the cache.";

			CStringA strDataFile;
			if (!m_HttpRequest.GetPhysicalPath(strDataFile))
				return SendError("Failed to get the physical path of the request.");
			strDataFile += "values.txt";

			std::string strValue;
			hr = VCUE::GetLineFromFile(strDataFile, atoi(strKey), strValue);
			if (FAILED(hr))
				return SendError("Failed to obtain a value from the file.");

			strData = strValue.c_str();

			// Make sure to allocate and free cache items with same allocator.
			DWORD dwSize = strData.GetLength() + 1;
			LPSTR szValue = static_cast<LPSTR>(::HeapAlloc(::GetProcessHeap(), 0, dwSize));
			if (!CopyCString(strData, szValue, &dwSize))
				return SendError("Failed to copy string.");

			FILETIME ft = {0};
			hr = m_spCache->Add(strKey, szValue, dwSize, &ft, 0, 0, m_spCacheClient);
			if (FAILED(hr))
				return SendError("Failed to add a value to the cache.");
		}

		m_spCache->Flush();
		return HTTP_SUCCESS;
	}
 
protected:

	[ tag_name(name="limit") ]
	HTTP_CODE OnLimit(void)
	{
		HRESULT hr = E_UNEXPECTED;

		DWORD dwMaximumAllowedEntries = 0;
		hr = m_spCacheControl->GetMaxAllowedEntries(&dwMaximumAllowedEntries);
		if (FAILED(hr))
			return SendError("Failed to get the maximum number of allowed entries.");
		
		DWORD dwMaximumAllowedSize = 0;
		hr = m_spCacheControl->GetMaxAllowedSize(&dwMaximumAllowedSize);
		if (FAILED(hr))
			return SendError("Failed to get the maximum allowed size of the cache.");

		m_HttpResponse << "<p>The maximum number of entries allowed in the cache: " << dwMaximumAllowedEntries << "</p>";
		m_HttpResponse << "<p>The maximum allowed size of the cache: " << dwMaximumAllowedSize << "</p>";
	
		return HTTP_SUCCESS;
	}

	[ tag_name(name="output") ]
	HTTP_CODE OnOutput(void)
	{
		m_HttpResponse << "<tr><td><b>Value</b></td><td>\"" << strData << "\"</td></tr>";
		m_HttpResponse << "<tr><td><b>Status</b></td><td>" << strStatus << "</td></tr>";
		return HTTP_SUCCESS;
	}

	[ tag_name(name="stats") ]
	HTTP_CODE OnStats(void)
	{
		HRESULT hr = E_UNEXPECTED;

		DWORD dwHits = 0;
		hr = m_spCacheStats->GetHitCount(&dwHits);
		if (FAILED(hr))
			return SendError("Failed to get the hit count.");

		DWORD dwMisses = 0;
		m_spCacheStats->GetMissCount(&dwMisses);
		if (FAILED(hr))
			return SendError("Failed to get the miss count.");

		DWORD dwMaximumEntries = 0;
		m_spCacheStats->GetMaxEntryCount(&dwMaximumEntries);
		if (FAILED(hr))
			return SendError("Failed to get the maximum entry count.");

		DWORD dwCurrentEntries = 0;
		m_spCacheStats->GetCurrentEntryCount(&dwCurrentEntries);
		if (FAILED(hr))
			return SendError("Failed to get the current entry count.");

		DWORD dwMaximumSize = 0;
		m_spCacheStats->GetMaxAllocSize(&dwMaximumSize);
		if (FAILED(hr))
			return SendError("Failed to get the maximum entry count.");

		DWORD dwCurrentSize = 0;
		m_spCacheStats->GetCurrentAllocSize(&dwCurrentSize);
		if (FAILED(hr))
			return SendError("Failed to get the current entry count.");

		m_HttpResponse << "<tr><td><b>Hits</b></td><td>" << dwHits << "</td></tr>";
		m_HttpResponse << "<tr><td><b>Misses</b></td><td>" << dwMisses << "</td></tr>";
		m_HttpResponse << "<tr><td><b>Current Entries</b></td><td>" << dwCurrentEntries << "</td></tr>";
		m_HttpResponse << "<tr><td><b>Current Size</b></td><td>" << dwCurrentSize << "</td></tr>";
		m_HttpResponse << "<tr><td><b>Maximum Entries</b></td><td>" << dwMaximumEntries << "</td></tr>";
		m_HttpResponse << "<tr><td><b>Maximum Size</b></td><td>" << dwMaximumSize << "</td></tr>";

		return HTTP_SUCCESS;
	}

private:
	// Helpers
	template <class ComInterface>
	HRESULT QueryService(ComInterface** ppInterface)
	{
		return m_spServiceProvider->QueryService(__uuidof(ComInterface), ppInterface);
	}
	
	// Call this function to return a simple error response to the user.
	// The HTTP status code defaults to 500 (a generic server error).
	HTTP_CODE SendError(const CStringA& strError, WORD wHttpStatus = 500)
	{
		// Clear any buffered headers (including cookies) and content.
		m_HttpResponse.ClearResponse();

		// Suggest that clients and proxies do not cache this response.
		m_HttpResponse.SetCacheControl("no-cache");
		m_HttpResponse.SetExpires(0);

		// Set the status code in the response object.
		m_HttpResponse.SetStatusCode(wHttpStatus);

		// Build the body of the response.
		m_HttpResponse << "<html><head><title>BlobCache Error</title></head><body><p>" << strError << "</p></body></html>";

		// Return a HTTP_CODE that tells the ATL Server code to discontinue processing of the SRF file.
		return AtlsHttpError(wHttpStatus, SUBERR_NO_PROCESS);
	}

	// Data Members
	CComPtr<IMemoryCache> m_spCache;
	CComPtr<IMemoryCacheControl> m_spCacheControl;
	CComPtr<IMemoryCacheStats> m_spCacheStats;
	CComPtr<IMemoryCacheClient> m_spCacheClient;

	CStringA strData;
	CStringA strStatus;
};

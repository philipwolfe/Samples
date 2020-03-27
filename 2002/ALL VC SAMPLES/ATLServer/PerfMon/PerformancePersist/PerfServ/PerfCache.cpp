// PerfCache.cpp
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// PerfCache.cpp : Implementation of CPerfCache

#include "stdafx.h"
#include "PerfCache.h"


// CPerfCache
class CCachePerf : public CPerfMon
{
public:
	void SetAppName(CString strAppName)
	{
		m_strAppName = strAppName;
	}

	HRESULT OpenAllData()
	{
		// touch all the memory blocks so we have all of them open
		CAtlFileMappingBase* pBlock;
		pBlock = _GetNextBlock(NULL);
		while (pBlock)
			pBlock = _GetNextBlock(pBlock);

		return S_OK;
	}

private:
	LPCTSTR GetAppName() const throw() { return m_strAppName; }
	HRESULT CreateMap(WORD, HINSTANCE, UINT*) { return S_OK; }

	CString m_strAppName;
};

CAtlMap<CString, CAutoPtr<CCachePerf>, CStringElementTraits<CString>, CAutoPtrElementTraits<CCachePerf> > g_cache;

// CPerfCache


STDMETHODIMP CPerfCache::CachePerfApp(BSTR bstrAppName)
{
	_ATLTRY
	{
		HRESULT hr;
		CString strAppName(bstrAppName);

		CCachePerf* pPerfMon = NULL;
		if (!g_cache.Lookup(strAppName, pPerfMon))
		{
			CAutoPtr<CCachePerf> spPerfMon;
			ATLTRY(spPerfMon.Attach(new CCachePerf));
			if (spPerfMon == NULL)
				return E_OUTOFMEMORY;

			pPerfMon = spPerfMon;

			spPerfMon->SetAppName(strAppName);
			hr = spPerfMon->Initialize();
			if (FAILED(hr))
				return hr;

			g_cache.SetAt(strAppName, spPerfMon);
		}

		hr = pPerfMon->OpenAllData();
		if (FAILED(hr))
			return hr;
	}
	_ATLCATCHALL()
	{
		return E_FAIL;
	}

	return S_OK;
}

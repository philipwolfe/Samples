// PerfService.h
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.


#pragma once

__interface ATL_NO_VTABLE __declspec(uuid("2DC4AE64-BCD6-401A-9212-3A7EAF536F89")) 
	IFibonacciPerfService : public IUnknown
{
	HRESULT  STDMETHODCALLTYPE QueryInterface(REFIID riid, void **ppv);
	ULONG STDMETHODCALLTYPE AddRef();
	ULONG STDMETHODCALLTYPE Release();
	HRESULT GetFibonacciPerf(CFibonacciPerf** ppPerfMon);
};

CFibonacciPerf g_perf;

class CFibonacciPerfService :
	public CComObjectRootEx<CComMultiThreadModel>,
	public IFibonacciPerfService
{
public:
	BEGIN_COM_MAP(CFibonacciPerfService)
		COM_INTERFACE_ENTRY(IFibonacciPerfService)
	END_COM_MAP()

	CFibonacciPerfService()
	{
	}

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		HRESULT hr;
		
		CComPtr<IDispatch> spPerfCache;
		hr = spPerfCache.CoCreateInstance(__uuidof(CPerfCache));
		if (FAILED(hr))
			return E_FAIL;

		CRevertThreadToken revert;
		if (!revert.Initialize())
			return E_FAIL;

		hr = g_perf.Initialize();
		if (FAILED(hr))
		{
			revert.Restore();
			return E_FAIL;
		}

		g_perf.SetPerfCache(spPerfCache);

		revert.Restore();

		return S_OK;
	}
	
	void FinalRelease() 
	{
	}

	HRESULT GetFibonacciPerf(CFibonacciPerf** ppPerfMon)
	{
		*ppPerfMon = &g_perf;
		return S_OK;
	}
};

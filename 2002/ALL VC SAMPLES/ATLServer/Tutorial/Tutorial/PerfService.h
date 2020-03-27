// File: PerfService.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "Helpers.h"

// perfmon object
[ perf_object(namestring = "ATL Server Tutorial", helpstring = "Number of orders taken by ATL Server tutorial application", detail = PERF_DETAIL_NOVICE) ]
class CTutorialStatistics
{
public:
	[ perf_counter(namestring = "Orders", helpstring = "Number of orders taken by ATL Server tutorial application", countertype = PERF_COUNTER_RAWCOUNT, defscale = 0, detail = PERF_DETAIL_NOVICE) ]
	LONG m_dwOrders;
};



// perfmon class
[ perfmon(name="Perf_TutorialPerf", register=true) ]
class CTutorialPerformanceManager
{

};

__interface ATL_NO_VTABLE __declspec(uuid("2DC4AE64-BCD6-401A-9212-3A7EAF536F89")) 
ITutorialPerformanceService : public IUnknown
{
	HRESULT AddOrder();
};

CTutorialPerformanceManager g_PerformanceManager;

class CTutorialPerformanceService :
	public CComObjectRootEx<CComMultiThreadModel>,
	public CComCoClass<CTutorialPerformanceService>,
	public ITutorialPerformanceService
{
public:
	BEGIN_COM_MAP(CTutorialPerformanceService)
		COM_INTERFACE_ENTRY(ITutorialPerformanceService)
	END_COM_MAP()

	CTutorialStatistics* m_pStatistics;

	CTutorialPerformanceService()
	{
		m_pStatistics = NULL;
	}

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		HRESULT hr = S_OK;
        VCUE::CTemporaryRevertToSelf rts(hr);
        if (FAILED(hr))
            return hr;
		
		hr = g_PerformanceManager.Initialize();

		if (SUCCEEDED(hr))
		{
			CPerfLock lock(&g_PerformanceManager);
			if (SUCCEEDED(lock.GetStatus()))
				hr = g_PerformanceManager.CreateInstance(1, L"Tutorial", &m_pStatistics);
			else
				hr = E_FAIL;
		}
		return hr;
	}
	
	void FinalRelease() 
	{
		HRESULT hr = S_OK;
        VCUE::CTemporaryRevertToSelf rts(hr);
        ATLASSERT(SUCCEEDED(hr));

		CPerfLock lock(&g_PerformanceManager);
		if (SUCCEEDED(lock.GetStatus()))
			hr = g_PerformanceManager.ReleaseInstance(m_pStatistics);
		
		g_PerformanceManager.UnInitialize();
	}

	HRESULT AddOrder()
	{
		HRESULT hr = E_UNEXPECTED;
		if (m_pStatistics)
		{
			InterlockedIncrement(&(m_pStatistics->m_dwOrders));
			hr = S_OK;
		}
		return hr;
	}
};

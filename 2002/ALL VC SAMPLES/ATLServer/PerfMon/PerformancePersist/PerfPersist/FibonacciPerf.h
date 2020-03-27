// FibonacciPerf.h
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// FibonacciPerf.h: interface for the CFibonacciPerf class.
//

#import "progid:PerfServ.PerfCache" no_namespace named_guids
#pragma once

[ perf_object(namestring = "Fibonacci Stats", helpstring = "Sample Statistics for the Fibonacci Sample", detail = PERF_DETAIL_NOVICE) ]
class CFibonacciStats
{
public:
	[ perf_counter(namestring = "Last Request", helpstring = "Last Fibonacci Number Requested", countertype = PERF_COUNTER_RAWCOUNT, defscale = 0, detail = PERF_DETAIL_NOVICE) ]
	ULONG m_dwLastRequest;

	[ perf_counter(namestring = "Total Requests", helpstring = "The total number of requests for Fibonacci numbers", countertype = PERF_COUNTER_RAWCOUNT, defscale = 0, detail = PERF_DETAIL_NOVICE) ]
	ULONG m_dwNumRequests;

	[ perf_counter(namestring = "Recursive call rate", helpstring = "Rate of calls to the recursive function", countertype = PERF_COUNTER_COUNTER, defscale = -5, detail = PERF_DETAIL_NOVICE) ]
	ULONG m_dwRecursiveCalls;
};

[ perfmon(name="Perf_FibonacciPerf", register=true) ]
class CFibonacciPerf
{
public:
	void SetPerfCache(IDispatch* pPerfCache)
	{
		m_spPerfCache = pPerfCache;
		m_spPerfCache.Invoke1(L"CachePerfApp", &CComVariant(CComBSTR(GetAppName())));
	}

private:
	virtual void OnBlockAlloc(CAtlFileMappingBase* pBlock)
	{
		if (m_spPerfCache)
			m_spPerfCache.Invoke1(L"CachePerfApp", &CComVariant(CComBSTR(GetAppName())));
	}

	CComPtr<IDispatch> m_spPerfCache;
};

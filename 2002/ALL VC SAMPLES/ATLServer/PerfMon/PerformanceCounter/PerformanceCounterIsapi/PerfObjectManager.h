// PerfObjectManager.h: interface for the PerfObjectManager class.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.


#pragma once

class CSamplePerformanceObject :
	public CPerfObject
{
public:
	DECLARE_PERF_OBJECT(CSamplePerformanceObject, 1, _T("PerformanceCounterSample"), _T("PerformanceObjectHelpStr"), -1);
	BEGIN_COUNTER_MAP(CSamplePerformanceObject)
		DEFINE_COUNTER(rateCount, _T("rate"), _T("rate at which counter is increased"), PERF_COUNTER_COUNTER, 1)
		DEFINE_COUNTER(rawCount, _T("raw"), _T("raw counter value"), PERF_COUNTER_RAWCOUNT, 0)
	END_COUNTER_MAP()
	ULONG rateCount;
	ULONG rawCount;
};

class CSamplePerformanceObjectManager :
	public CPerfMon
{
public:
#define Perf_PerfObjMgr _T("Perf_PerformanceCounter")
	BEGIN_PERF_MAP(Perf_PerfObjMgr)
		CHAIN_PERF_OBJECT(CSamplePerformanceObject)
	END_PERF_MAP()


};

PERFREG_ENTRY(CSamplePerformanceObjectManager);

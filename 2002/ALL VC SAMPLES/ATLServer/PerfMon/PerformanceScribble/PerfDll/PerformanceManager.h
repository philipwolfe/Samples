// PerformanceManager.h: interface for the PerformanceManager class.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include <atlperf.h>

#pragma once

class MousePerfObj :
	public CPerfObject
{
public:
//	static const DWORD kObjectId = 1;
	DECLARE_PERF_OBJECT(MousePerfObj, 1, _T("ScribbleMouse"), _T("Scribble sample mouse performance"), -1);
	BEGIN_COUNTER_MAP(MousePerfObj)
		DEFINE_COUNTER(xaxis, _T("X_Axis"), _T("X axis counter"), PERF_COUNTER_COUNTER, -1)
		DEFINE_COUNTER(yaxis, _T("Y_Axis"), _T("Y axis counter"), PERF_COUNTER_COUNTER, -1)
		DEFINE_COUNTER(eventsPerSec, _T("EventsPerSec"), _T("Mouse events per second"), PERF_COUNTER_RAWCOUNT, 0)
	END_COUNTER_MAP()
	ULONG xaxis;
	ULONG yaxis;
	ULONG eventsPerSec;
};

class PerformanceManager :
	public CPerfMon
{
public:
#define Perf_PerformanceManager _T("Perf_PerformanceScribble")
	BEGIN_PERF_MAP(Perf_PerformanceManager)
		CHAIN_PERF_OBJECT(MousePerfObj)
	END_PERF_MAP()


};

PERFREG_ENTRY(PerformanceManager);

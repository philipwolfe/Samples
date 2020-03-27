// PerformanceCounter.cpp : Defines the entry point for the DLL application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
// For custom assert and trace handling with WebDbg.exe
#ifdef _DEBUG
CDebugReportHook g_ReportHook;
#endif

#include "..\PerformanceCounterIsapi\PerfObjectIsapiExt.h"

#include "PerformanceCounter.h"
CComModule _Module;

BEGIN_OBJECT_MAP(ObjectMap)
END_OBJECT_MAP()


// TODO: Add additional request handlers to the handler map

BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Default", CPerformanceCounterHandler)
END_HANDLER_MAP()


// DLL Entry Point
//
extern "C"
BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	// stack overflow handler
	_set_security_error_handler( AtlsSecErrHandlerFunc );
	return _Module.DllMain(hInstance, dwReason, lpReserved, ObjectMap, NULL); 
}

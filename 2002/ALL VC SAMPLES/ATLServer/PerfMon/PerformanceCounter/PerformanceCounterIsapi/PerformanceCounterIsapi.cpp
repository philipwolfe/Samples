// PerformanceCounterIsapi.cpp : Defines the entry point for the DLL application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "..\PerformanceCounterIsapi\PerfObjectIsapiExt.h"

// For custom assert and trace handling with WebDbg.exe
#ifdef _DEBUG
CDebugReportHook g_ReportHook;
#endif
CComModule _Module;

BEGIN_OBJECT_MAP(ObjectMap)
END_OBJECT_MAP()


typedef CSamplePerformanceCounterIsapiExtension<CThreadPool<CIsapiWorker>, CStdRequestStats > ExtensionType;
ExtensionType theExtension;

// Delegate ISAPI exports to theExtension
//
extern "C" DWORD WINAPI HttpExtensionProc(LPEXTENSION_CONTROL_BLOCK lpECB)
{
	return theExtension.HttpExtensionProc(lpECB);
}

extern "C" BOOL WINAPI GetExtensionVersion(HSE_VERSION_INFO* pVer)
{
	return theExtension.GetExtensionVersion(pVer);
}

extern "C" BOOL WINAPI TerminateExtension(DWORD dwFlags)
{
	return theExtension.TerminateExtension(dwFlags);
}


// DLL Entry Point
//
extern "C"
BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	return _Module.DllMain(hInstance, dwReason, lpReserved, ObjectMap, NULL); 
}

// DllRegisterServer - Adds entries to the system registry
//
STDAPI DllRegisterServer(void)
{
	return _Module.DllRegisterServer(FALSE);
}


// DllUnregisterServer - Removes entries from the system registry
//
STDAPI DllUnregisterServer(void)
{
	return _Module.DllUnregisterServer(FALSE);
}
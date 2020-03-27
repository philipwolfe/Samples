// MyIsapi.cpp : Defines the entry point for the DLL application.
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
[ module(name="MyIsapi", type="dll") ];
[ emitidl(restricted) ];

#include "MyIsapiextension.h"

BEGIN_PERFREG_MAP()
	PERFREG_ENTRY(CRequestPerfMon)
END_PERFREG_MAP()

typedef CMyIsapiExtension<CThreadPool<CMyIsapiExtensionWorker>, CPerfMonRequestStats > ExtensionType;




// The ATL Server ISAPI extension
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

// Main.cpp : Defines the entry point for the DLL application.
// (c) 2000 Microsoft Corporation
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
//CDebugReportHook g_ReportHook;
#endif

#include "MainHandler.h"
#include "ProfileHandler.h"

class CDllModule : public CAtlDllModuleT<CDllModule>
{
};

CDllModule _DllModule;

/////////////////////////////////////////////////////////////////////////////
// DLL Entry Point
//
extern "C"
BOOL WINAPI DllMain(DWORD dwReason, LPVOID lpReserved) throw()
{
	return _DllModule.DllMain(dwReason, lpReserved); 
}

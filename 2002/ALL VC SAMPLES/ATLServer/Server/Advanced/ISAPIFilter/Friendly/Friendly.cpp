// Friendly.cpp
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// Friendly.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include "friendly.h"

HMODULE g_hModule;
CFriendlyUrlFilter g_filter;

BOOL APIENTRY DllMain(
					HMODULE hModule, 
					DWORD  dwReasonForCall, 
					LPVOID lpReserved
					)
{
    if (dwReasonForCall == DLL_PROCESS_ATTACH)
	{
		g_hModule = hModule;
		DisableThreadLibraryCalls(hModule);
    }
    return TRUE;
}

extern "C" BOOL WINAPI GetFilterVersion(
					PHTTP_FILTER_VERSION pVer
					)
{
	return g_filter.GetFilterVersion(g_hModule, pVer);
}

extern "C" DWORD WINAPI HttpFilterProc(
					PHTTP_FILTER_CONTEXT pfc, 
					DWORD NotificationType, 
					LPVOID pvNotification 
					)
{
	return g_filter.HttpFilterProc(pfc, NotificationType, pvNotification);
}

extern "C" BOOL WINAPI TerminateFilter(
					DWORD dwFlags
					)
{
	return g_filter.TerminateFilter(dwFlags);
}

// (c) 2000 Microsoft Corporation
// RxReplacer.cpp : Defines the entry point for the DLL application.
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

#include "RxReplacer.h"
[ module(name="RxReplacer",type="dll") ]
class CDllMainOverride
{
public:
	BOOL WINAPI DllMain(DWORD dwReason, LPVOID lpReserved)
	{
#if defined(_M_IX86)
		// stack overflow handler
		_set_security_error_handler( AtlsSecErrHandlerFunc );
#endif
		return __super::DllMain(dwReason, lpReserved);
	}
};

[ emitidl(restricted) ];

// DigiService.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
// For custom assert and trace handling with WebDbg.exe
#ifdef _DEBUG
CDebugReportHook g_ReportHook;
#endif

#include "DigiService.h"
[ module(name="DigiService", type="dll") ];
[ emitidl(restricted) ];

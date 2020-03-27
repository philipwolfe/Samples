// DigiCams.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
// For custom assert and trace handling with WebDbg.exe
#ifdef _DEBUG
CDebugReportHook g_ReportHook;
#endif

#include "DigiCams.h"
[ module(name="DigiCams", type="dll") ];
[ emitidl(restricted) ];

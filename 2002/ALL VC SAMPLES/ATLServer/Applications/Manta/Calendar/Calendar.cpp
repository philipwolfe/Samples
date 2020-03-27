// Calendar.cpp : Defines the entry point for the DLL application.
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

#include "CalendarHandler.h"
#include "ScheduleHandler.h"
#include "AppointmentHandler.h"
#include "TasksHandler.h"
#include "TaskHandler.h"
//#include "NewAppointmentSvc.h"

[emitidl(restricted)];
	
BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Calendar", CCalendarHandler)
	HANDLER_ENTRY("Schedule", CScheduleHandler)
	HANDLER_ENTRY("Appointment", CAppointmentHandler)
	HANDLER_ENTRY("Tasks", CTasksHandler)
	HANDLER_ENTRY("Task", CTaskHandler)
END_HANDLER_MAP()

//Global functions
int GetMaxDays(int iMonth, int iYear)
{
	ATLASSERT(iMonth > 0 && iMonth < 13);

	// 28 or 29 days in month (feb)
	if (iMonth == 2)
	{
		if ( (iYear % 4 == 0) &&  ( (iYear % 100 != 0) || (iYear % 400 == 0) ) )
			return 29;	// Leap year, 29 days
		else
			return 28;	// Not a leap year, 28 days
	}
	// 30 days in month (april, june, september, november)
	else if (iMonth == 4 || iMonth == 6 || iMonth == 9 || iMonth == 11)	
		return 30;
	// 31 days in month (jan, march, may, july, august, oct, dec)
	else																
		return 31;
}

/////////////////////////////////////////////////////////////////////////////
// DLL Entry Point
//
//extern "C"
//BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
//{
//	return _DllModule.DllMain(dwReason, lpReserved); 
//}


[ module(dll, name = "Calendar") ];

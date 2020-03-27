/* 
 * Copyright (c) 2000, Microsoft Corporation. All rights reserved.
 *
 * Demonstration of the use of the Run-Time Error Checking (RTC) API without 
 * using the C Run-Time Library (CRT).
 *
 */


#ifndef _rtcsample_h
#define _rtcsample_h

#include <rtcapi.h>
#include <windows.h>

extern int GetVal(void);
extern void doSomething(short val);
extern void LoseInfoInIntToShortCast(void);
extern void thrashVar(int *i);
extern void TrashStackVariable(void);
extern void UseUninitializedVariable(void);
extern void DoInitialization(void);
extern void DoTermination(void);

#ifdef __MSVC_RUNTIME_CHECKS
#ifdef NOCRT
extern char *IntToString(int i);
#endif
extern int Catch_RTC_Failure(int errType, const char *file, int line, const char *module, const char *format, ...);
#endif

#endif // _rtcsample_h

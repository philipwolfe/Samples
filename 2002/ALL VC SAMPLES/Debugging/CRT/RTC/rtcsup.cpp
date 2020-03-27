/* 
 * Copyright (c) 2000, Microsoft Corporation. All rights reserved.
 *
 * Demonstration of the use of the Run-Time Error Checking (RTC) API without 
 * using the C Run-Time Library (CRT).
 *
 * This file contains functions for initialization and termination of RTC,
 * along with a custom handler for RTC failures.  
 * 
 */

#include "rtcsample.h"

void
DoInitialization()
{
#ifdef __MSVC_RUNTIME_CHECKS
#   ifdef NOCRT
    _RTC_Initialize();
#   else
    // This is only necessary when using a custom RTC handler function.
	// If using a debug CRT and a custom handler is *not* designated with
	// _RTC_SetErrorFunc, then failures will be reported via _CrtDbgReport.
	_RTC_SetErrorFunc(Catch_RTC_Failure);
#   endif
#endif
    // Do any other initialization here
}

void
DoTermination()
{
    // Do any other termination work here
#if defined(__MSVC_RUNTIME_CHECKS) && defined(NOCRT)
    _RTC_Terminate();
#endif
}


#ifdef __MSVC_RUNTIME_CHECKS

#include <stdarg.h>
#include <malloc.h>

#ifdef NOCRT
    // Use intrinsics, so we don't add CRT dependencies
#   pragma intrinsic(strcat)
#   pragma intrinsic(strcpy)
    char *IntToString(int i)
    {
        static char buf[15];
        bool neg = i < 0;
        int pos = 14;
        buf[14] = 0;
        do {
            buf[--pos] = i % 10 + '0';
            i /= 10;
        } while (i);
        if (neg)
            buf[--pos] = '-';
        return &buf[pos];
    }
#else // NOCRT is undefined
#   include <stdio.h>
#endif

int Catch_RTC_Failure(int errType, const char *file, int line, const char *module, const char *format, ...)
{
	// Prevent re-entrancy ; isn't necessary here, but if this were a
	// multi-threading program, it would be.
	static long running = 0;
	while (InterlockedExchange(&running, 1))
		Sleep(0);

    // First, get the RTC error number from the var-arg list...
    va_list vl;
    va_start(vl, format);
    _RTC_ErrorNumber rtc_errnum = va_arg(vl, _RTC_ErrorNumber);
    va_end(vl);
    
    // Build a string buffer to display in a message box
    char buf[1024];
#ifdef NOCRT
    const char *err = _RTC_GetErrDesc(rtc_errnum);
    strcpy(buf, err);
    if (line)
    {
        strcat(buf, "\nLine #");
        strcat(buf, IntToString(line));
    }
    if (file)
    {
        strcat(buf, "\nFile:");
        strcat(buf, file);
    }
    if (module)
    {
        strcat(buf, "\nModule:");
        strcat(buf, module);
    }
#else // NOCRT is undefined
    char buf2[1024];
    va_start(vl, format);
    vsprintf(buf2, format, vl);
    sprintf(
        buf, 
        "RTC Failure #%d (user specified type %d) occurred:\n\nModule:\t%s\nFile:\t%s\nLine:\t%d\n\nFull Message:\n%s",
        rtc_errnum,
        errType,
        module ? module : "",
        file ? file : "",
        line,
        buf2);
#endif

    running = 0;

    strcat(buf, "\n\nWould you like to break to the debugger?");

    return (MessageBox(NULL, buf, "RTC Failed...", MB_YESNO) == IDYES) ? 1 : 0;
}

#ifdef NOCRT
extern "C" _RTC_error_fn _CRT_RTC_INIT(void *, void **, int , int , int )
{
	return &Catch_RTC_Failure;
}
#endif

#endif /* rtcsamp.cpp */


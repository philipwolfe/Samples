///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2001.  All rights reserved.
//
//  Run: To throw an exception from managed-code to unmanaged-code: set compiler to "Not using managed extensions" for sampledll and to "Assembly Support (/clr)" for NDPExceptions
//       To throw an exception from unmanaged-code to managed-code: set compiler to "Not using managed extensions" for NDPExceptions and to "Assembly Support (/clr)" for sampledll
//
//  Description: Shows how to throw and handle NDP Exceptions in C++
//
///////////////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "Exception.h"

#ifdef _MANAGED
#using <mscorlib.dll>

using namespace System;
#endif

__declspec(dllimport) void thrower();

int main()
{
    try {
        thrower();
    }
    catch(const CException &e) {
        cout << "Caught " << e << endl;
    } 

    cout << "**DONE**\n";

    return 0;
}

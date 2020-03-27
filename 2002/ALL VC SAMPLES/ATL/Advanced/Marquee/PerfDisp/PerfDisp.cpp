// PerfDisp.cpp
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// PerfDisp.cpp : Implementation of DLL Exports.

// Note: Proxy/Stub Information
//      To build a separate proxy/stub DLL, 
//      run nmake -f PerfDispps.mk in the project directory.

#include "stdafx.h"
#include "resource.h"
// The module attribute causes DllMain, DllRegisterServer and DllUnregisterServer to be automatically implemented for you
[ module(dll, uuid = "{CDB3B0F4-0666-4DCE-B284-15BC0A7AF11E}", 
		 name = "PerfDisp", 
		 helpstring = "PerfDisp 1.0 Type Library",
		 resource_name = "IDR_PERFDISP") ];

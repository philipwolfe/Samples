// PerfServ.cpp
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// PerfServ.cpp : Implementation of WinMain

#include "stdafx.h"
#include "resource.h"

// The module attribute causes WinMain to be automatically implemented for you
[ module(SERVICE, uuid = "{47726A34-B3BE-4F26-92F6-C9CEDE080706}", 
		 name = "PerfServ", 
		 helpstring = "PerfServ 1.0 Type Library", 
		 resource_name="IDS_SERVICENAME") ];

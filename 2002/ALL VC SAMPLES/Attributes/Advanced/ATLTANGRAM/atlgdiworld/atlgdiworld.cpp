// ATLGdiWorld.cpp : Implementation of DLL Exports.
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// Note: Proxy/Stub Information
//      To build a separate proxy/stub DLL,
//      run nmake -f ATLGdiWorldps.mk in the project directory.

#include "stdafx.h"
#include "resource.h"

#include "GdiWorldIface.h"
#include "AtlTangramGdiVisual.h"
#include "AtlGdiWorldImpl.h"

[ module(dll,
		 uuid = "D3E72169-871F-4c98-B986-777F8B7B909B",
		 name = "ATLGdiWorldAttrib",
		 helpstring = "ATLGdiWorld Attrib 1.0 Type Library")
];
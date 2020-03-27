// AtlGLWorld.cpp : Implementation of DLL Exports.
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
//      run nmake -f AtlGLWorldps.mk in the project directory.

#include "stdafx.h"
#include "resource.h" 
#include "AtlGLWorldiface.h"

#include "AtlTangramGLVisual.h"
#include "AtlGLWorldImpl.h"

[ module(dll,
		 name = "AtlTangramGLWorldAttrib",
		 helpstring = "AtlTangramGLWorld Attrib 1.0 Type Library",
		 uuid = "DFD35969-A3FF-4e7f-958A-0391E644C7A1")
];

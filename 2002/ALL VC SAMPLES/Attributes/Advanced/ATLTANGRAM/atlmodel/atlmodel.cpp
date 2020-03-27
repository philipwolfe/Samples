// ATLModel.cpp : Implementation of DLL Exports.
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
//      run nmake -f ATLModelps.mk in the project directory.

#include "stdafx.h"
#include "resource.h"


#ifndef _LOCAL_SERVER

[ module(dll,
		 name = "ATLMODELAttrib",
		 uuid = "63A5793E-5C14-4192-867C-4E3BCB2A14F7",
		 helpstring = "ATLModel Attrib 1.0 Type Library")
];

#else

[ module(exe,
		 name = "ATLMODELAttribLocal",
		 uuid = "63A5793E-5C14-4192-867C-4E3BCB2A14F8",
		 helpstring = "ATLModelLocal Attrib 1.0 Type Library")
];

#endif

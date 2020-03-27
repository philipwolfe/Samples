// Labrador.cpp : Implementation of EXE registration.
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

#include "prelab.h"
#include "Resource.h"
#include <initguid.h>
#include "Labrador.h"
#include "LabObj.h"

#define IID_DEFINED
#include "Labrador_i.c"

class CatlLabradorModule : public CAtlExeModuleT< CatlLabradorModule >
{
public :
	DECLARE_LIBID(LIBID_LABRADORLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_LABSVR, "{B3C59461-8850-443d-9AA4-72222485927E}")
};

CatlLabradorModule _AtlModule;

OBJECT_ENTRY_AUTO(CLSID_Labrador, CLabrador)

#ifdef _WINDLL
#error This project does not support DLL, only EXE targets
#endif

/////////////////////////////////////////////////////////////////////////////
// EXE Entry Point

extern "C" int WINAPI _tWinMain(HINSTANCE /*hInstance*/, HINSTANCE /*hPrevInstance*/, 
                                LPTSTR /*lpCmdLine*/, int nShowCmd)
{
    return _AtlModule.WinMain(nShowCmd);
}


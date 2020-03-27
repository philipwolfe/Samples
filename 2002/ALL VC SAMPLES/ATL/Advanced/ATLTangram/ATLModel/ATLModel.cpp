// ATLModel.cpp : Implementation of DLL Exports.
//
// This is a part of the Active Template Library.
// Copyright (C) Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

#include "stdafx.h"
#include <initguid.h>
#include "ATLModel.h"

#include "ATLModel_i.c"
#include "ATLTangramModel.h"

#ifndef _WINDLL
// Tangram model as an exe
class CATLModelModule : public CAtlExeModuleT< CATLModelModule >
{
public :
	DECLARE_LIBID(LIBID_ATLMODELLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_IDRATLTANGRAMEXE, "{80937EF2-B1B9-11D0-B69F-00A0C903487A}")
};

#else
// Tangram model as a dll
class CATLModelModule : public CAtlDllModuleT< CATLModelModule >
{
public :
	DECLARE_LIBID(LIBID_ATLMODELLib)
};

#endif //_WINDLL

CATLModelModule _AtlModule;

/////////////////////////////////////////////////////////////////////////////
// EXE Entry Point

#ifndef _WINDLL
extern "C" int WINAPI _tWinMain(HINSTANCE /*hInstance*/, HINSTANCE /*hPrevInstance*/, 
                                LPTSTR /*lpCmdLine*/, int nShowCmd)
{
    return _AtlModule.WinMain(nShowCmd);
}
#else
/////////////////////////////////////////////////////////////////////////////
// DLL Entry Point

extern "C" BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	hInstance;
    return _AtlModule.DllMain(dwReason, lpReserved); 
}


// Used to determine whether the DLL can be unloaded by OLE
STDAPI DllCanUnloadNow(void)
{
    return _AtlModule.DllCanUnloadNow();
}


// Returns a class factory to create an object of the requested type
STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, LPVOID* ppv)
{
    return _AtlModule.DllGetClassObject(rclsid, riid, ppv);
}


// DllRegisterServer - Adds entries to the system registry
STDAPI DllRegisterServer(void)
{
    // registers object, typelib and all interfaces in typelib
    HRESULT hr = _AtlModule.DllRegisterServer();
	return hr;
}


// DllUnregisterServer - Removes entries from the system registry
STDAPI DllUnregisterServer(void)
{
	HRESULT hr = _AtlModule.DllUnregisterServer();
	return hr;
}
#endif //_WINDLL
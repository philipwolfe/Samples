// PerfDll.cpp : Implementation of DLL Exports.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

// Note: Proxy/Stub Information
//      To build a separate proxy/stub DLL, 
//      run nmake -f PerfDllps.mk in the project directory.

#include "stdafx.h"
#include "resource.h"
#include "PerfDll.h"
#include "PerformanceManager.h"

class CPerfDllModule : public CAtlDllModuleT< CPerfDllModule >
{
public :
	DECLARE_LIBID(LIBID_PerfDllLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_PERFDLL, "{AA995530-7660-46EA-B1AF-60BEE3EE64BD}")
};

CPerfDllModule _AtlModule;


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



STDAPI DllRegisterServer(void)
{
	return _AtlModule.DllRegisterServer(FALSE);
}


STDAPI DllUnregisterServer(void)
{
	return _AtlModule.DllUnregisterServer(FALSE);
}


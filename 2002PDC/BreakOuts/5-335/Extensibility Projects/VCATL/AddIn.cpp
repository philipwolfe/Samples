// AddIn.cpp : Implementation of DLL Exports.


// Note: Proxy/Stub Information
//      To build a separate proxy/stub DLL, 
//      run nmake -f AddInps.mk in the project directory.


#include "stdafx.h"
#include "resource.h"
#include "AddIn_h.h"
#include "Connect.h"



CComModule _Module;


BEGIN_OBJECT_MAP(ObjectMap)

OBJECT_ENTRY(CLSID_$SAFEOBJNAME$, CConnect)
END_OBJECT_MAP()


/////////////////////////////////////////////////////////////////////////////
// DLL Entry Point
extern "C"
BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{

    return _Module.DllMain(hInstance, dwReason, lpReserved, ObjectMap, &LIBID_$SAFEOBJNAME$Lib); 
}


/////////////////////////////////////////////////////////////////////////////
// Used to determine whether the DLL can be unloaded by OLE
STDAPI DllCanUnloadNow(void)
{

    return _Module.DllCanUnloadNow();

}

/////////////////////////////////////////////////////////////////////////////
// Returns a class factory to create an object of the requested type
STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, LPVOID* ppv)
{

    return _Module.DllGetClassObject(rclsid, riid, ppv);
}

/////////////////////////////////////////////////////////////////////////////
// DllRegisterServer - Adds entries to the system registry
STDAPI DllRegisterServer(void)
{
    // registers object, typelib and all interfaces in typelib
	HRESULT hr = _Module.UpdateRegistryFromResource(IDR_AddIn, TRUE);
	if (FAILED(hr))
		return hr;
    hr = _Module.DllRegisterServer();

	return hr;
}

/////////////////////////////////////////////////////////////////////////////
// DllUnregisterServer - Removes entries from the system registry
STDAPI DllUnregisterServer(void)
{
	HRESULT hr = _Module.DllUnregisterServer();

	if (FAILED(hr))
		return hr;
    return _Module.UpdateRegistryFromResource(IDR_AddIn, FALSE);
}



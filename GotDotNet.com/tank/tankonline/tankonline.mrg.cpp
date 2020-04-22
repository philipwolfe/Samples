// Created by Microsoft (R) C/C++ Compiler Version 13.00.9360
//
// d:\sourcedepot\vcqalibs\test sources\work in progress\hps\hailstorm\pdc\tankonline\tankonline.mrg.cpp
// compiler-generated file created 10/19/01 at 11:51:29
//
// This C++ source file is intended to be a representation of the
// source code injected by the compiler.  It may not compile or
// run exactly as the original source file.
//

// TankOnline.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
//+++ Start Injected Code
[no_injected_text(true)];      // Suppress injected text, it has already been injected
#pragma warning(disable: 4543) // Suppress warnings about skipping injected text
#pragma warning(disable: 4199) // Suppress warnings from attribute providers

#pragma message("\n\nNOTE: This merged source file should be visually inspected for correctness.\n\n")
//--- End Injected Code


// For custom assert and trace handling with WebDbg.exe
#ifdef _DEBUG
CDebugReportHook g_ReportHook;

//+++ Start Injected Code For Attribute 'module'
#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"

#ifndef GUID_DEFINED
#define GUID_DEFINED
typedef struct _GUID 
{
    unsigned long  Data1;
    unsigned short Data2;
    unsigned short Data3;
    unsigned char  Data4[ 8 ];
} 
GUID;
#endif

extern "C" const __declspec(selectany) GUID __LIBID_ = {0xecf927e7,0x1f22,0x3bd4,{0xaf,0x9d,0x7d,0xe2,0xb6,0x55,0x50,0x48}};
struct __declspec(uuid("ecf927e7-1f22-3bd4-af9d-7de2b6555048")) MyTankOnline;

//--- End Injected Code For Attribute 'module'

#endif

#include "TankOnline.h"
[ module(name="MyTankOnline", type="dll") ]
class CDllMainOverride
 :
    /*+++ Added Baseclass */ public CAtlDllModuleT<CDllMainOverride>
{
public:
	BOOL WINAPI DllMain(DWORD dwReason, LPVOID lpReserved)
	{
#if defined(_M_IX86)
		if (dwReason == DLL_PROCESS_ATTACH)
		{
			// stack overflow handler
			_set_security_error_handler( AtlsSecErrHandlerFunc );
		}
#endif
		return __super::DllMain(dwReason, lpReserved);
	}

	//+++ Start Injected Code For Attribute 'module'
    #injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"

						DECLARE_LIBID(__uuidof(MyTankOnline))
					
	//--- End Injected Code For Attribute 'module'
};

//+++ Start Injected Code For Attribute 'module'
#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"

extern CDllMainOverride _AtlModule;

//--- End Injected Code For Attribute 'module'


//+++ Start Injected Code For Attribute 'module'
#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"
extern "C" STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, void** ppv);

//--- End Injected Code For Attribute 'module'


//+++ Start Injected Code For Attribute 'module'
#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"
extern "C" STDAPI DllRegisterServer(void);

//--- End Injected Code For Attribute 'module'


//+++ Start Injected Code For Attribute 'module'
#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"
extern "C" STDAPI DllUnregisterServer(void);

//--- End Injected Code For Attribute 'module'


//+++ Start Injected Code For Attribute 'module'
#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"
extern "C" STDAPI DllCanUnloadNow(void);

//--- End Injected Code For Attribute 'module'


//+++ Start Injected Code For Attribute 'module'
#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"
BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved);

//--- End Injected Code For Attribute 'module'


//+++ Start Injected Code For Attribute 'module'
#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"

CDllMainOverride _AtlModule;

#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"
extern "C" STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, void** ppv) 
{
    return _AtlModule.DllGetClassObject(rclsid, riid, ppv);
}
#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"
extern "C" STDAPI DllRegisterServer(void) 
{
    return _AtlModule.DllRegisterServer();
}
#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"
extern "C" STDAPI DllUnregisterServer(void) 
{
    return _AtlModule.DllUnregisterServer();
}
#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"
extern "C" STDAPI DllCanUnloadNow(void) 
{
    return _AtlModule.DllCanUnloadNow();
}
#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"
BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved) 
{
    hInstance;
    return _AtlModule.DllMain(dwReason, lpReserved);
}
#injected_line 11 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\tankonline.cpp"

#if defined(_M_IX86)
#pragma comment(linker, "/EXPORT:DllMain=_DllMain@12,PRIVATE")
#pragma comment(linker, "/EXPORT:DllRegisterServer=_DllRegisterServer@0,PRIVATE")
#pragma comment(linker, "/EXPORT:DllUnregisterServer=_DllUnregisterServer@0,PRIVATE")
#pragma comment(linker, "/EXPORT:DllGetClassObject=_DllGetClassObject@12,PRIVATE")
#pragma comment(linker, "/EXPORT:DllCanUnloadNow=_DllCanUnloadNow@0,PRIVATE")
#elif defined(_M_IA64)
#pragma comment(linker, "/EXPORT:DllMain,PRIVATE")
#pragma comment(linker, "/EXPORT:DllRegisterServer,PRIVATE")
#pragma comment(linker, "/EXPORT:DllUnregisterServer,PRIVATE")
#pragma comment(linker, "/EXPORT:DllGetClassObject,PRIVATE")
#pragma comment(linker, "/EXPORT:DllCanUnloadNow,PRIVATE")
#endif	

//--- End Injected Code For Attribute 'module'


[ emitidl(restricted) ];

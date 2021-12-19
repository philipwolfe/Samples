// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently,
// but are changed infrequently

#pragma once

#define STRICT
#ifndef _WIN32_WINNT
#define _WIN32_WINNT 0x0400
#endif
#define _ATL_APARTMENT_THREADED
#define _ATL_NO_AUTOMATIC_NAMESPACE


#include "resource.h"
#include <atlbase.h>
//You may derive a class from CComModule and use it if you want to override
//something

#include <atlcom.h>
#include <atlinl.h>

#pragma warning( disable : 4278 )
#pragma warning( disable : 4146 )  
#import "mso9.dll" raw_interfaces_only named_guids 
#import "dte.olb" raw_interfaces_only named_guids 
#pragma warning( default : 4146 )
#pragma warning( default : 4278 )

#define IfFailGo(x) { hr=(x); if (FAILED(hr)) goto Error; }

using namespace ATL;
using namespace Office;
using namespace EnvDTE;


extern CComModule _Module;





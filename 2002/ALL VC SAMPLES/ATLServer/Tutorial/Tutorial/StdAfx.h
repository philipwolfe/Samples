// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers

#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS	// some CString constructors will be explicit

// turns off ATL's hiding of some common and often safely ignored warning messages
#define _ATL_ALL_WARNINGS

#ifdef DEBUG
	// 10 second DLL cache sweeps
	#define ATL_DLL_CACHE_TIMEOUT 10000
#endif

#ifndef _WIN32_WINNT
#define _WIN32_WINNT 0x0403
#endif

// TODO: this disables support for registering COM objects
// exported by this project since the project contains no
// COM objects or typelib. If you wish to export COM objects
// from this project, add a typelib and remove this line
#define _ATL_NO_COM_SUPPORT

// This line ensures that the PerfMon objects
// will be registered when regsvr32 is run
// against the DLL.
#define _ATL_PERF_REGISTER

#include <atlstencil.h>
#include <atlsession.h>
#include <atlrx.h>
#include <atlsmtpconnection.h>

// Definitions for mail support. Change these to match your own mail server and email address.
#define MAIL_SERVER_NAME "smarthost"
#define MAIL_SENDER_ADDRESS "ATLServerTutorial@microsoft.com"

// Definitions for cookie support
#define COOKIE_NAME "AtlServerTutorial"
#define COOKIE_VALUE_NAME "SessionId"
#define COOKIE_VALUE_SIZE 64

// Need to use single byte regular expression classes
typedef CAtlRegExp<CAtlRECharTraitsA> CRegularExpression;
typedef CAtlREMatchContext<CAtlRECharTraitsA> CMatchContext;

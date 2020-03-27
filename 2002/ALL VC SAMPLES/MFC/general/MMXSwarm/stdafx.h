// stdafx.h : include file for standard system include files,
//
// or project specific include files that are used frequently,
// but are changed infrequently
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.
//
#pragma once

#ifndef VC_EXTRALEAN
#define VC_EXTRALEAN		// Exclude rarely-used stuff from Windows headers
#endif

// Modify the following defines if you have to target a platform prior to the ones specified below.
#ifndef WINVER				// Allow use of features specific to Win 2K or later
#define WINVER 0x0500
#endif

#ifndef _WIN32_WINNT		// Allow use of features specific to NT4 or later
#define _WIN32_WINNT 0x0400
#endif

#ifndef _WIN32_WINDOWS		// Allow use of features specific to Win 98 or later
#define _WIN32_WINDOWS 0x0410
#endif

#ifndef _WIN32_IE			// Allow use of features specific to IE 5.01 or later
#define _WIN32_IE 0x0501
#endif

#include <afxwin.h>         // MFC core and standard components
#include <afxext.h>         // MFC extensions

#include <afxdtctl.h>		// MFC support for Internet Explorer 4 Common Controls
#ifndef _AFX_NO_AFXCMN_SUPPORT
	#include <afxcmn.h>			// MFC support for Windows Common Controls
#endif // _AFX_NO_AFXCMN_SUPPORT

#include <atlcoll.h> 		// ATL/MFC shared collection classes
#include <comdef.h>			// for _com_error

inline void SeedRandom(int nSeed = 0)
{ srand(nSeed ? nSeed : ::GetTickCount()); }
inline int Random() { return(rand()); }
inline int Random(int n) { return(rand() % n ); }

bool IsMMX();

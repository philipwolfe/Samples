// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#define WINVER 0x0400
#define _WIN32_WINNT 0x0403
#define _WIN32_IE 0x0401

#define VC_EXTRALEAN		// Exclude rarely-used stuff from Windows headers

#if (defined(_UNICODE) || defined(UNICODE))
	#error WEBDBG does not support UNICODE
#endif

#include <afxwin.h>         // MFC core and standard components
#include <afxext.h>         // MFC extensions
#include <afxdtctl.h>		// MFC support for Internet Explorer 4 Common Controls
#ifndef _AFX_NO_AFXCMN_SUPPORT
#include <afxcmn.h>			// MFC support for Windows Common Controls
#endif // _AFX_NO_AFXCMN_SUPPORT

#include <httpext.h>
#include <atlbase.h>
#include <atlcom.h>
#include <aclapi.h>
#include <atlutil.h>
#include <atlrx.h>


//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

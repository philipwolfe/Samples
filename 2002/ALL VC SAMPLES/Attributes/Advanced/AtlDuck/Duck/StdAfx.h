// stdafx.h : include file for standard system include files,
//      or project specific include files that are used frequently,
//      but are changed infrequently
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

#if !defined(AFX_STDAFX_H__120B72A6_65BF_11D0_9DDC_00A0C9034892__INCLUDED_)
#define AFX_STDAFX_H__120B72A6_65BF_11D0_9DDC_00A0C9034892__INCLUDED_


#ifdef _DEBUG
#define _ATL_DEBUG_QI
#define _ATL_DEBUG_REFCOUNT
#endif

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#define STRICT


#define _WIN32_WINNT 0x0400
#define _ATL_APARTMENT_THREADED


#include <atlbase.h>

#include <atlwin.h>
#include <atlcom.h>

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#ifndef UNUSED_ALWAYS
#define UNUSED_ALWAYS(x)  (x)
#endif

#endif // !defined(AFX_STDAFX_H__120B72A6_65BF_11D0_9DDC_00A0C9034892__INCLUDED)

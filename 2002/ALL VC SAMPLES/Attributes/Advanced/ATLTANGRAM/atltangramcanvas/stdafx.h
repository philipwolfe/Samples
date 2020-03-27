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

#if !defined(AFX_STDAFX_H__8FAD6744_AD34_11D0_B69F_00A0C903487A__INCLUDED_)
#define AFX_STDAFX_H__8FAD6744_AD34_11D0_B69F_00A0C903487A__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#define STRICT


#define _WIN32_WINNT 0x0400
#define _ATL_APARTMENT_THREADED
#define ASSERT _ASSERTE

#include <atlbase.h>
#include <atlcom.h>

BOOL IsValidAddress(const void* lp, UINT nBytes, BOOL bReadWrite);

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__8FAD6744_AD34_11D0_B69F_00A0C903487A__INCLUDED)

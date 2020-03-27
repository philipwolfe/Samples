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

#if !defined(AFX_STDAFX_H__6B05C587_AF5B_11D0_B69F_00A0C903487A__INCLUDED_)
#define AFX_STDAFX_H__6B05C587_AF5B_11D0_B69F_00A0C903487A__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#define STRICT


#define _WIN32_WINNT 0x0400
#define _ATL_APARTMENT_THREADED



#include <atlbase.h>
#include <atlcom.h>
#include <initguid.h>
#include "..\atlworldcat.h"
#include "..\tantypeiface.h"
#include <windows.h>
#include "..\util.h"
//#include "..\ATLTangramCanvas\ATLTangramCanvasiface.h"
#include "..\ATLModel\ATLModeliface.h"
#include "..\ATLGdiWorld\GdiWorldiface.h"
#include "..\AtlGdiWorld\GdiWorldiface.h"

#pragma warning(disable : 4192)
#pragma warning(disable : 4701)
#pragma warning(disable : 4702)
#pragma warning(disable : 4189)
#pragma warning(disable : 4100)




//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__6B05C587_AF5B_11D0_B69F_00A0C903487A__INCLUDED)

// VCUE_Conversion.h
// (c) 2000 Microsoft Corporation
//
//////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(_VCUE_CONVERSION_H___633A330A_27E8_4B8F_89B2_1CBC1993400D___INCLUDED_)
#define _VCUE_CONVERSION_H___633A330A_27E8_4B8F_89B2_1CBC1993400D___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

namespace VCUE
{
	inline CStringA ToCStringA(LPCWSTR wsz) throw()
	{
		USES_CONVERSION;
		return wsz ? W2CA(wsz) : "";
	}

	inline CStringA ToCStringA(const VARIANT& v) throw()
	{
		CComVariant var(v);
		return (SUCCEEDED(var.ChangeType(VT_BSTR))) ? ToCStringA(var.bstrVal) : "";
	}

	inline CStringA ToCStringA(const VARIANT* pv) throw()
	{
		return pv ? ToCStringA(*pv) : "";
	}

	inline CStringA ToCStringA(LONG l) throw()
	{
		CStringA str;
		str.Format("%ld", l);
		return str;
	}

	inline WORD StringToWord(const char* p, char** pp) throw()
	{
		return static_cast<WORD>(strtoul(p, pp, 10));
	}


} // namespace VCUE


#endif // !defined(_VCUE_CONVERSION_H___633A330A_27E8_4B8F_89B2_1CBC1993400D___INCLUDED_)

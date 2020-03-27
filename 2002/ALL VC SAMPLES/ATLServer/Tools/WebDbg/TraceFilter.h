// File: TraceFilter.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#ifndef _TRACE_FILTER_H_
#define  _TRACE_FILTER_H_
#include "stdafx.h"
#include <string.h>
#include <tchar.h>

class CTraceFilter
{
public:
	CTraceFilter()
		:m_bRegEx(FALSE)
	{
	}

	BOOL SetFilter(LPCTSTR lpszFilterString, BOOL bRegEx=FALSE)
	{
		m_bRegEx = bRegEx;
		
		if (m_bRegEx)
			if (!m_rx.Parse(lpszFilterString))
				return FALSE;
		m_strFilter = lpszFilterString;
		return TRUE;
	}


	BOOL Passes(LPCTSTR lpszTestString)
	{
		if (m_bRegEx)
		{
			CAtlREMatchContext<CAtlRECharTraits> ctx;
			return m_rx.Match(lpszTestString, &ctx);
		}
		return (_tcsncmp((LPCTSTR)m_strFilter, lpszTestString, m_strFilter.GetLength()) == 0);
	}

	LPCTSTR GetFilter()
	{
		return m_strFilter;
	}

protected:
	CString m_strFilter;
	CAtlRegExp<CAtlRECharTraits> m_rx;
	BOOL m_bRegEx;
};
#endif
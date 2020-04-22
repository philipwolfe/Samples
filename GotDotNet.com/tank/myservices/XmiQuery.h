#pragma once

#include "resource1.h"
#include "xmibase.h"

#include <atlstencil.h>
#include <atlcoll.h>

class CXmiQuery : 
	public CBaseElement<CXmiQuery>	
{
private:
	CString m_service;
	CString	m_xpQuery;

public:
	CXmiQuery()
	{		
	}

	virtual ~CXmiQuery(void)
	{}
	
	void SetService(const CString& service)
	{
		m_service = service;
	}

	void SetXpQuery(const CString& query)
	{
		m_xpQuery = query;
	}

	virtual const char* GetSRF()
	{
		return IDR_QUERY;
	}

	HTTP_CODE OnGetService()
	{
		Write(m_service);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetXpSelectClause()
	{
		Write(m_xpQuery);
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CXmiQuery)		
		REPLACEMENT_METHOD_ENTRY("GetService",			OnGetService)
		REPLACEMENT_METHOD_ENTRY("GetXpSelectClause",	OnGetXpSelectClause)
	END_REPLACEMENT_METHOD_MAP()	
};

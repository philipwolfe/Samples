#pragma once
#include "stdafx.h"

class CXmiDelete : 
	public CBaseElement<CXmiDelete>
{
private:
	CString		m_service;		
	CString		m_query;

public:

	CXmiDelete(const CString& deleteQuery)
	{
		m_query = deleteQuery;
	}

	void SetService(const CString& service)
	{
		m_service = service;
	}
	
	virtual const char* GetSRF()
	{
		return IDR_DELETE;
	}

	HTTP_CODE OnGetService()
	{
		Write(m_service);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetXpSelectClause()
	{
		Write(m_query);		
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CXmiDelete)		
		REPLACEMENT_METHOD_ENTRY("GetService",			OnGetService)		
		REPLACEMENT_METHOD_ENTRY("GetXpSelectClause",	OnGetXpSelectClause)
	END_REPLACEMENT_METHOD_MAP()	
};
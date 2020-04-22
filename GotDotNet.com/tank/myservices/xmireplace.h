#pragma once

#include "stdafx.h"
#include "xmibase.h"

template <typename TBody> class CXmiReplace :
	public CBaseElement<CXmiReplace>
{
private:
	CString		m_service;		
	CString		m_query;
	CString		m_itemNamespace;
	TBody		*m_body;

public:	
	void SetService(const CString& service)
	{
		m_service = service;
	}
		
	void SetQuery(const CString& query)
	{
		m_query	= query;
	}

	void SetBody(TBody* body)
	{
		ATLASSERT(body);

		m_body = body;
	}		

	void SetItemNamespace(const CString& n)
	{
		m_itemNamespace = n;
	}

	virtual const char* GetSRF()
	{
		return IDR_REPLACE;
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

	HTTP_CODE OnGetBody()
	{
		if (m_body)
		{
			m_body->SetOutputStream(m_stream);

			if (m_body->Generate())
			{
				return HTTP_SUCCESS;
			}
		}
		return HTTP_S_FALSE;
	}
	
	HTTP_CODE OnGetItemNamespace()
	{
		Write(m_itemNamespace);
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CXmiReplace)		
		REPLACEMENT_METHOD_ENTRY("GetService",			OnGetService)		
		REPLACEMENT_METHOD_ENTRY("GetXpSelectClause",	OnGetXpSelectClause)
		REPLACEMENT_METHOD_ENTRY("GetBody",				OnGetBody)
		REPLACEMENT_METHOD_ENTRY("GetItemNamespace",	OnGetItemNamespace)
	END_REPLACEMENT_METHOD_MAP()	
};
#pragma once

#include "resource1.h"
#include "xmibase.h"

#include <atlstencil.h>
#include <atlcoll.h>

class CEmptyInsert : 
	public CBaseElement<CEmptyInsert>
{
public:

	virtual const char* GetSRF()
	{
		return IDR_EMPTY;
	}
};

template <typename InsertBodyType = CEmptyInsert> class CXmiInsert : 
	public CBaseElement<CXmiInsert>
{
private:
	CString				m_service;	
	InsertBodyType*		m_insertBody;

public:

	CXmiInsert(void) : m_insertBody(NULL)
	{
	}

	virtual ~CXmiInsert(void)
	{
	}
	
	void SetService(const CString& service)
	{
		m_service = service;
	}

	void SetInsertBody(InsertBodyType* insertBody)
	{
		m_insertBody = insertBody;
	}
	
	virtual const char* GetSRF()
	{
		return IDR_INSERT;
	}

	HTTP_CODE OnGetService()
	{
		Write(m_service);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetInsertBody()
	{
		if (m_insertBody)
		{
			m_insertBody->SetOutputStream(this->m_stream);
		
			if (m_insertBody->Generate())
			{
				return HTTP_SUCCESS;
			}
			else
			{
				return HTTP_FAIL;
			}		
		}
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CXmiInsert)		
		REPLACEMENT_METHOD_ENTRY("GetService",			OnGetService)		
		REPLACEMENT_METHOD_ENTRY("GetInsertBody",		OnGetInsertBody)
	END_REPLACEMENT_METHOD_MAP()	
};
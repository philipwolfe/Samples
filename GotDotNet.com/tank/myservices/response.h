#pragma once

#include <atlcoll.h>

#include "contact.h"

template <typename ResponseType> class CResponse :
	public CBaseElement<CResponse>
{
public:

protected:
	typedef CAutoPtrList<ResponseType> ResponseList;

	ResponseList		m_list;
	POSITION			m_pos;
	ResponseType*		m_item;	
	bool				m_first;

public:
	CResponse(void) :
		m_pos(0), 
		m_item(NULL),
		m_first(true)
	{}

	virtual ~CResponse(void)
	{}

	void OnDoneChain(ResponseType *response)
	{
		ResponseType *copy = new ResponseType();
		copy->SetFrom(response);

		AddResponseItem(copy);		
	}

	HRESULT STDMETHODCALLTYPE startDocument()
	{
		CreateNewResponseItem();

		return __super::startDocument();
	}

	bool HasMoreResponses()
	{	
		if (m_pos)
		{		
			m_list.GetNext(m_pos);				
		}		
		return m_pos ? true : false;		
	}	

	ResponseType* GetResponse()
	{
		ATLASSERT(m_pos != NULL);
		
		return (ResponseType*) m_list.GetAt(m_pos);
	}

	bool CreateNewResponseItem()
	{
		AddResponseItem(new ResponseType());
		return true;
	}
	
protected:
	
	void AddResponseItem(ResponseType *responseType)
	{
		CAutoPtr<ResponseType> newInfo;
		newInfo.Attach(responseType);
		
		POSITION pos = m_list.AddTail(newInfo);
		m_item = (ResponseType*) m_list.GetAt(pos);

		if (!m_pos)
		{
			m_pos = m_list.GetHeadPosition();
		}
	}
};
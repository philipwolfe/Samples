#pragma once

#include "xmibase.h"
#include "contact.h"
#include "response.h"
#include "hailstormservice.h"

class CMyContactsResponse : 
	public CResponse<CContact<CMyContactsResponse> >
{
public:
	BEGIN_XMLTAG_MAP(CMyContactsResponse)		
		XMLTAG_CLASS("contact",	CContact<CMyContactsResponse>)		
	END_XMLTAG_MAP()
};

class CMyContacts 
	: public CBaseHailstormService<	CMyContactsResponse, 
									CContact<CMyContactsResponse> >
{
public:	
	CMyContacts()
	{						
		m_xmiMessage.m_service	= "myContacts";
	}

	virtual ~CMyContacts(void)
	{
	}

	virtual bool Delete(const CString& id)
	{
		CMyContactsResponse response;
		CString query;
		query.Format("//m:contact[@id='%s']", id);

		return __super::Delete(response, query);
	}
};
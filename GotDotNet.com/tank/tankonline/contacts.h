#pragma once
#include "stdafx.h"

#include "mycontacts.h"

[request_handler("Contacts")]
class CContactsHandler : 	
	public CTankHandlerBaseT<CContactsHandler>
{
private:
	CMyContacts			m_myContacts;
	CMyContactsResponse m_queryResponse;

public:	
	HTTP_CODE ValidateAndExchange()
	{
		HTTP_CODE httpCode = __super::ValidateAndExchange();

		if (httpCode != HTTP_SUCCESS)
		{
			return httpCode;
		}

		m_myContacts.SetServer(m_server);
		m_myContacts.SetPUID(m_puid);
		m_myContacts.Query(m_queryResponse);

		return HTTP_SUCCESS;
	}

	[tag_name("HasMoreContacts")]
	HTTP_CODE HasMoreContacts()
	{
		return m_queryResponse.HasMoreResponses() ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[tag_name("GetContactNameGivenName")]
	HTTP_CODE ContactNameGivenName()
	{
		m_HttpResponse << m_queryResponse.GetResponse()->name.givenName.value;	
		return HTTP_SUCCESS;
	}
	
	[tag_name("GetContactID")]
	HTTP_CODE ContactID()
	{
		m_HttpResponse << m_queryResponse.GetResponse()->id;
		return HTTP_SUCCESS;
	}

	[tag_name("GetContactNameSurname")]
	HTTP_CODE ContactNameSurname()
	{
		m_HttpResponse << m_queryResponse.GetResponse()->name.surname.value;	
		return HTTP_SUCCESS;
	}
	
	[tag_name("GetContactEmail")]
	HTTP_CODE ContactEmail()
	{
		m_HttpResponse << m_queryResponse.GetResponse()->emailaddress.email;		
		return HTTP_SUCCESS;
	}
};

[request_handler("DeleteContacts")]
class CDeleteContactsHandler : 	
	public CTankHandlerBaseT<CDeleteContactsHandler>
{
public:
	HTTP_CODE ValidateAndExchange()
	{		
		HTTP_CODE httpCode = __super::ValidateAndExchange();

		if (httpCode != HTTP_SUCCESS)
		{
			return httpCode;
		}
		
		// id's of contacts to be deleted will be on the query string
		LPCSTR name(NULL);
		LPCSTR value(NULL);

		CMyContacts myContacts;		
		myContacts.SetServer(m_server);
		myContacts.SetPUID(m_puid);

		POSITION start = m_HttpRequest.GetFirstQueryParam(&name, &value);
		while (start)
		{
			if (name && value && strcmp(name, "id") == 0)
			{
				// delete this contact		
				myContacts.Delete(value);
			}
			start = m_HttpRequest.GetNextQueryParam(start, &name, &value);
		}		
		
		return HTTP_SUCCESS;
	}
};

[request_handler("AddContact")]
class CAddContactHandler  : 	
	public CTankHandlerBaseT<CAddContactHandler>
{
private:
	
public:	
	HTTP_CODE ValidateAndExchange()
	{		
		HTTP_CODE httpCode = __super::ValidateAndExchange();

		if (httpCode != HTTP_SUCCESS)
		{
			return httpCode;
		}

		if (m_isPostBack)
		{
			// get the user's input
			const CHttpRequestParams& queryParams = m_HttpRequest.GetQueryParams();

			CString firstName	= queryParams.Lookup("firstName");
			CString	lastName	= queryParams.Lookup("lastName");
			CString	email		= queryParams.Lookup("email");

			// make sure we have values
			if (firstName.IsEmpty() || lastName.IsEmpty() || email.IsEmpty())
			{	
				return HTTP_S_FALSE;
			}

			// if we have all the values we need, try to add our contact into myContacts
			CMyContacts myContacts;		
			myContacts.SetServer(m_server);
			myContacts.SetPUID(m_puid);

			CMyContactsResponse response;
			CContact<CMyContactsResponse> newContact;

			newContact.name.givenName.value = firstName;
			newContact.name.surname.value	= lastName;
			newContact.emailaddress.email	= email;
						
			myContacts.Insert(response, newContact);			
		}

		return HTTP_SUCCESS;
	}
};

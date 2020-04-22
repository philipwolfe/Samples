// Created by Microsoft (R) C/C++ Compiler Version 13.00.9360
//
// d:\sourcedepot\vcqalibs\test sources\work in progress\hps\hailstorm\pdc\tankonline\contacts.mrg.h
// compiler-generated file created 10/19/01 at 11:51:29
//
// This C++ source file is intended to be a representation of the
// source code injected by the compiler.  It may not compile or
// run exactly as the original source file.
//


//+++ Start Injected Code
[no_injected_text(true)];      // Suppress injected text, it has already been injected
#pragma warning(disable: 4543) // Suppress warnings about skipping injected text
#pragma warning(disable: 4199) // Suppress warnings from attribute providers

#pragma message("\n\nNOTE: This merged source file should be visually inspected for correctness.\n\n")
//--- End Injected Code

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

	//+++ Start Injected Code For Attribute 'tag_name'
    #injected_line 31 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\contacts.h"
BEGIN_ATTR_REPLACEMENT_METHOD_MAP(CContactsHandler)
REPLACEMENT_METHOD_ENTRY("HasMoreContacts", HasMoreContacts)
REPLACEMENT_METHOD_ENTRY("GetContactNameGivenName", ContactNameGivenName)
REPLACEMENT_METHOD_ENTRY("GetContactID", ContactID)
REPLACEMENT_METHOD_ENTRY("GetContactNameSurname", ContactNameSurname)
REPLACEMENT_METHOD_ENTRY("GetContactEmail", ContactEmail)
END_ATTR_REPLACEMENT_METHOD_MAP()
	//--- End Injected Code For Attribute 'tag_name'
};

//+++ Start Injected Code For Attribute 'request_handler'
#injected_line 6 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\contacts.h"

				
DECLARE_REQUEST_HANDLER("Contacts", CContactsHandler, ::CContactsHandler)

			
//--- End Injected Code For Attribute 'request_handler'


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

//+++ Start Injected Code For Attribute 'request_handler'
#injected_line 66 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\contacts.h"

				
DECLARE_REQUEST_HANDLER("DeleteContacts", CDeleteContactsHandler, ::CDeleteContactsHandler)

			
//--- End Injected Code For Attribute 'request_handler'


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

//+++ Start Injected Code For Attribute 'request_handler'
#injected_line 103 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\contacts.h"

				
DECLARE_REQUEST_HANDLER("AddContact", CAddContactHandler, ::CAddContactHandler)

			
//--- End Injected Code For Attribute 'request_handler'


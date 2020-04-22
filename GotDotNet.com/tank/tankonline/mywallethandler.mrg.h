// Created by Microsoft (R) C/C++ Compiler Version 13.00.9360
//
// d:\sourcedepot\vcqalibs\test sources\work in progress\hps\hailstorm\pdc\tankonline\mywallethandler.mrg.h
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
#include "mywallet.h"

[request_handler("Wallet")]
class CWalletHandler : 
	public CTankHandlerBaseT<CWalletHandler>
{
private:
	CMyWalletResponse m_allCards;

public:
	HTTP_CODE ValidateAndExchange()
	{
		HTTP_CODE httpCode = __super::ValidateAndExchange();

		if (httpCode != HTTP_SUCCESS)
		{
			return httpCode;
		}
	
		CMyWallet myWallet;
		myWallet.SetServer(m_server);
		myWallet.SetPUID(m_puid);

		myWallet.Query(m_allCards);
		
		return httpCode;
	}

	[tag_name("HasMoreCards")]
	HTTP_CODE HasMoreCards()
	{
		return m_allCards.HasMoreResponses() ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[tag_name("GetBrandNetwork")]
	HTTP_CODE GetBrandNetwork()
	{
		m_HttpResponse << m_allCards.GetResponse()->networkBrand;
		return HTTP_SUCCESS;
	}

	[tag_name("GetDescription")]
	HTTP_CODE GetDescription()
	{
		m_HttpResponse << m_allCards.GetResponse()->description.value;
		return HTTP_SUCCESS;
	}

	[tag_name("GetCardNumber")]
	HTTP_CODE GetCardNumber()
	{
		m_HttpResponse << m_allCards.GetResponse()->cardNumber;
		return HTTP_SUCCESS;
	}

	[tag_name("GetCardID")]
	HTTP_CODE GetCardID()
	{
		m_HttpResponse << m_allCards.GetResponse()->id;
		return HTTP_SUCCESS;
	}

	//+++ Start Injected Code For Attribute 'tag_name'
    #injected_line 31 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\contacts.h"
BEGIN_ATTR_REPLACEMENT_METHOD_MAP(CWalletHandler)
REPLACEMENT_METHOD_ENTRY("HasMoreCards", HasMoreCards)
REPLACEMENT_METHOD_ENTRY("GetBrandNetwork", GetBrandNetwork)
REPLACEMENT_METHOD_ENTRY("GetDescription", GetDescription)
REPLACEMENT_METHOD_ENTRY("GetCardNumber", GetCardNumber)
REPLACEMENT_METHOD_ENTRY("GetCardID", GetCardID)
END_ATTR_REPLACEMENT_METHOD_MAP()
	//--- End Injected Code For Attribute 'tag_name'
};

//+++ Start Injected Code For Attribute 'request_handler'
#injected_line 6 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\mywallethandler.h"

				
DECLARE_REQUEST_HANDLER("Wallet", CWalletHandler, ::CWalletHandler)

			
//--- End Injected Code For Attribute 'request_handler'


[request_handler("AddCard")]
class CAddCardHandler : 
	public CTankHandlerBaseT<CAddCardHandler>
{
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

			CString cardType	= queryParams.Lookup("cardType"); 
			CString cardNumber	= queryParams.Lookup("cardNumber"); 
			CString description = queryParams.Lookup("description");

			// make sure we have values
			if (cardType.IsEmpty() || cardNumber.IsEmpty() || description.IsEmpty())
			{	
				return HTTP_S_FALSE;
			}

			CMyWallet myWallet;
			myWallet.SetServer(m_server);
			myWallet.SetPUID(m_puid);

			CMyWalletResponse response;
			CCard<CMyWalletResponse> newCard;
		
			newCard.typeOfCard			= "credit card";
			newCard.networkBrand		= cardType;
			newCard.cardNumber			= cardNumber;
			newCard.description.value	= description;

			myWallet.Insert(response, newCard);
		}

		return httpCode;
	}
};

//+++ Start Injected Code For Attribute 'request_handler'
#injected_line 67 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\mywallethandler.h"

				
DECLARE_REQUEST_HANDLER("AddCard", CAddCardHandler, ::CAddCardHandler)

			
//--- End Injected Code For Attribute 'request_handler'


[request_handler("DeleteCard")]
class CDeleteCardHandler : 
	public CTankHandlerBaseT<CDeleteCardHandler>
{
public:
	HTTP_CODE ValidateAndExchange()
	{
		HTTP_CODE httpCode = __super::ValidateAndExchange();

		if (httpCode != HTTP_SUCCESS)
		{
			return httpCode;
		}

		CMyWallet myWallet;
		myWallet.SetServer(m_server);
		myWallet.SetPUID(m_puid);

		// id's of cards to be deleted will be on the query string
		LPCSTR name(NULL);
		LPCSTR value(NULL);
		
		POSITION start = m_HttpRequest.GetFirstQueryParam(&name, &value);
		while (start)
		{
			if (name && value && strcmp(name, "id") == 0)
			{
				// delete this contact		
				myWallet.Delete(value);
			}
			start = m_HttpRequest.GetNextQueryParam(start, &name, &value);
		}		
				
		return httpCode;
	}
};

//+++ Start Injected Code For Attribute 'request_handler'
#injected_line 115 "d:\\sourcedepot\\vcqalibs\\test sources\\work in progress\\hps\\hailstorm\\pdc\\tankonline\\mywallethandler.h"

				
DECLARE_REQUEST_HANDLER("DeleteCard", CDeleteCardHandler, ::CDeleteCardHandler)

			
//--- End Injected Code For Attribute 'request_handler'

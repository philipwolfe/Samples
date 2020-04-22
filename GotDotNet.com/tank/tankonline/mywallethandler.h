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
};

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
#pragma once

#include "xmibase.h"
#include "response.h"
#include "card.h"

class CMyWalletResponse : 
	public CResponse<CCard<CMyWalletResponse> >
{
public:
	BEGIN_XMLTAG_MAP(CMyWalletResponse)		
		XMLTAG_CLASS("card",	CCard<CMyWalletResponse>)		
	END_XMLTAG_MAP()
};

class CMyWallet 
	: public CBaseHailstormService<	CMyWalletResponse, 
									CCard<CMyWalletResponse> >
{
public:	
	CMyWallet()
	{						
		m_xmiMessage.m_service	= "myWallet";
	}

	virtual bool Delete(const CString& id)
	{
		CMyWalletResponse response;
		CString query;
		query.Format("//m:card[@id='%s']", id);

		return __super::Delete(response, query);
	}
};

#if 0
class CMyCard
	: public CXmiBase<CMyCard>
{
public:
	CString m_typeOfCard;
	CString m_cardNumber;
	CString m_description;
	CString m_expirationDate;

	HTTP_CODE OnGetTypeOfCard()
	{
		Write(m_typeOfCard);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetCardNumber()	
	{
		Write(m_cardNumber);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetDescription()	
	{
		Write(m_description);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetExpirationDate()
	{
		Write(m_expirationDate);
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CMyCard)		
		REPLACEMENT_METHOD_ENTRY("GetTypeOfCard",		OnGetTypeOfCard)
		REPLACEMENT_METHOD_ENTRY("GetCardNumber",		OnGetCardNumber)		
		REPLACEMENT_METHOD_ENTRY("GetDescription",		OnGetDescription)		
		REPLACEMENT_METHOD_ENTRY("GetExpirationDate",	OnGetExpirationDate)		
	END_REPLACEMENT_METHOD_MAP()

	virtual const char* GetSRF()
	{
		return IDR_CARD;
	}
};

class CMyWalletResponse
	: public CResponseBase<CMyCard>
{
private:
	typedef CResponseBase<CMyCard> baseType;

public:
	HRESULT STDMETHODCALLTYPE endElement(LPCWSTR wszNamespaceUri,	int cchNamespaceUri,
										 LPCWSTR wszLocalName,		int cchLocalName,
										 LPCWSTR wszQName,			int cchQName)
	{		
		if (wcscmp(wszLocalName, L"card") == 0)
		{
			m_currentCharacters.Empty();

			// start a new contact
			if (!CreateNewContentInfo())
			{
				return E_FAIL;
			}			
		}
		else if (wcscmp(wszLocalName, L"cardNumber") == 0)
		{
			m_currentCharacters.Trim();
			m_currentInfo->m_cardNumber = m_currentCharacters;
			m_currentCharacters.Empty();
		}
		else if (wcscmp(wszLocalName, L"typeOfCard") == 0)
		{
			m_currentCharacters.Trim();
			m_currentInfo->m_typeOfCard = m_currentCharacters;
			m_currentCharacters.Empty();
		}
		else if (wcscmp(wszLocalName, L"description") == 0)
		{
			m_currentCharacters.Trim();
			m_currentInfo->m_description = m_currentCharacters;
			m_currentCharacters.Empty();
		}
		else if (wcscmp(wszLocalName, L"expirationDate") == 0)
		{
			m_currentCharacters.Trim();
			m_currentInfo->m_expirationDate = m_currentCharacters;
			m_currentCharacters.Empty();
		}
		
		return baseType::endElement(wszNamespaceUri, 
									cchNamespaceUri, 
									wszLocalName, 
									cchLocalName,
									wszQName, 
									cchQName);
	}	
};

class CMyWallet
	: public CBaseHailstormService<CMyWalletResponse, CMyCard>
{
public:

	CMyWallet(void)
	{
		m_xmiMessage.m_service	= "myWallet";
	}

	virtual ~CMyWallet(void)
	{
	}
};
#endif
#pragma once

#include "xmibase.h"	
#include "cat.h"
#include "address.h"
#include "localizedstring.h"
#include "currency.h"

// see contacts.h for an example of a non-MACRO declaration
BEGIN_HS_DOC_CLASS(CCard)

	CCard()
	{
		billingaddress.localname = "billingAddress";
		nameOnCard.localname	 = "nameOnCard";
		description.localname	 = "description";
		localname				 = "card";
	}

	CLASS_ELEMENT(CCat<CCard>, cat)
	CLASS_ELEMENT_REPEAT_TYPE(CLocalizableString<CCard>, nameOnCard)
    CLASS_ELEMENT_REPEAT_TYPE(CLocalizableString<CCard>, description)	
	CLASS_ELEMENT(CCurrency<CCard>, currency)
	CLASS_ELEMENT(CAddress<CCard>,	billingaddress)	
	ELEMENT(id)
	ELEMENT(typeOfCard)
    ELEMENT(networkBrand)
    ELEMENT(affiliateBrand)
    ELEMENT(cardNumber)
    ELEMENT(displayNumber)    
    ELEMENT(expirationDate)
    ELEMENT(issueDate)
    ELEMENT(validFromDate)
    ELEMENT(issueNumber)
	ELEMENT(paymentInstrumentsIssuerPuid);

	BEGIN_CLASS_ELEMENT_TYPE_MAP(CLocalizableString<CCard>)		
		CLASS_ELEMENT_ENTRY(nameOnCard)
		CLASS_ELEMENT_ENTRY(description)
	END_CLASS_ELEMENT_TYPE_MAP()

	BEGIN_SET_FROM(CCard)
		FROM_CLASS_ELEMENT(cat)
		FROM_CLASS_ELEMENT(nameOnCard)
		FROM_CLASS_ELEMENT(description)
		FROM_CLASS_ELEMENT(currency)
		FROM_CLASS_ELEMENT(billingaddress)

		FROM_ELEMENT(id)
		FROM_ELEMENT(typeOfCard)
		FROM_ELEMENT(networkBrand)
		FROM_ELEMENT(affiliateBrand)
		FROM_ELEMENT(cardNumber)
		FROM_ELEMENT(displayNumber)				
		FROM_ELEMENT(expirationDate)
		FROM_ELEMENT(issueDate)
		FROM_ELEMENT(validFromDate)
		FROM_ELEMENT(issueNumber)
		FROM_ELEMENT(paymentInstrumentsIssuerPuid)
	END_SET_FROM()

	BEGIN_REPLACEMENT_METHOD_MAP(CCard)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",				 set_prefix)		
		REPLACEMENT_METHOD_ENTRY("get_cat",							 get_cat)
		REPLACEMENT_METHOD_ENTRY("get_id",							 get_id)
		REPLACEMENT_METHOD_ENTRY("get_typeOfCard",					 get_typeOfCard)
		REPLACEMENT_METHOD_ENTRY("get_networkBrand",				 get_networkBrand)
		REPLACEMENT_METHOD_ENTRY("get_affiliateBrand",				 get_affiliateBrand)
		REPLACEMENT_METHOD_ENTRY("get_cardNumber",					 get_cardNumber)
		REPLACEMENT_METHOD_ENTRY("get_displayNumber",				 get_displayNumber)		
		REPLACEMENT_METHOD_ENTRY("get_nameOnCard",					 get_nameOnCard)
		REPLACEMENT_METHOD_ENTRY("get_description",					 get_description)
		REPLACEMENT_METHOD_ENTRY("get_currency",					 get_currency)
		REPLACEMENT_METHOD_ENTRY("get_billingaddress",				 get_billingaddress)
		REPLACEMENT_METHOD_ENTRY("get_expirationDate",				 get_expirationDate)
		REPLACEMENT_METHOD_ENTRY("get_issueDate",					 get_issueDate)
		REPLACEMENT_METHOD_ENTRY("get_validFromDate",				 get_validFromDate)
		REPLACEMENT_METHOD_ENTRY("get_issueNumber",					 get_issueNumber)
		REPLACEMENT_METHOD_ENTRY("get_paymentInstrumentsIssuerPuid", get_paymentInstrumentsIssuerPuid)
	END_REPLACEMENT_METHOD_MAP()
		
	ATTR_METHOD_DECL(set_id)
	{
		USES_CONVERSION;		
		id.SetString(W2A(wszValue), cchValue);
		return S_OK;
	}

	BEGIN_XMLATTR_MAP(CCard)
		XMLATTR_ENTRY("id",		set_id)        		
    END_XMLATTR_MAP()

	BEGIN_XMLTAG_MAP(CCard)
		XMLTAG_CLASS("cat",							 CCat<CCard>)
		XMLTAG_CLASS("nameOnCard",					 CLocalizableString<CCard>)
		XMLTAG_CLASS("description",					 CLocalizableString<CCard>)
		XMLTAG_CLASS("currency",					 CCurrency<CCard>)
		XMLTAG_CLASS("billingaddress",				 CAddress<CCard>)
		XMLTAG_ENTRY("typeOfCard",					 set_typeOfCard)
		XMLTAG_ENTRY("networkBrand",				 set_networkBrand)
		XMLTAG_ENTRY("affiliateBrand",				 set_affiliateBrand)
		XMLTAG_ENTRY("cardNumber",					 set_cardNumber)
		XMLTAG_ENTRY("displayNumber",				 set_displayNumber)				
		XMLTAG_ENTRY("expirationDate",				 set_expirationDate)
		XMLTAG_ENTRY("issueDate",					 set_issueDate)
		XMLTAG_ENTRY("validFromDate",				 set_validFromDate)
		XMLTAG_ENTRY("issueNumber",					 set_issueNumber)
		XMLTAG_ENTRY("paymentInstrumentsIssuerPuid", set_paymentInstrumentsIssuerPuid)
	END_XMLTAG_MAP()

END_HS_DOC_CLASS(IDR_CARD)

class CNoCardParent :
	public CBaseElement<CNoCardParent>
{
public:
	void OnDoneChain(CCard<CNoCardParent> *response)
	{}
};

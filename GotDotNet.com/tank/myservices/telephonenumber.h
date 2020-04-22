#pragma once
#include "xmibase.h"
#include "cat.h"

template <typename TParentClass>  class CTelephoneNumber :
	public CBaseElement<CTelephoneNumber>
{
public:
	CCat<CTelephoneNumber>	cat;
	CString					name;
	CString					countryCode;
    CString					nationalCode;
    CString					number;
    CString					numberExtension;
    CString					pin;
           
	CTelephoneNumber()
	{
		localname = "telephoneNumber";
	}

	void 
	SetFrom(CTelephoneNumber<TParentClass> *from)
	{
		cat.SetFrom(&from->cat);
		name = from->name;
		countryCode = from->countryCode;
		nationalCode = from->nationalCode;
		number = from->number;
		numberExtension = from->numberExtension;
		pin = from->pin;
	}

	void 
	OnDoneChain(CCat<CTelephoneNumber> *const c)
	{
		cat.SetFrom(c);
	}

	TAG_METHOD_DECL(set_name)
	{		
		m_characters = &name;
		return S_OK;
	}

	TAG_METHOD_DECL(set_countryCode)
	{
		m_characters = &countryCode;
		return S_OK;
	}

    TAG_METHOD_DECL(set_nationalCode)
	{
		m_characters = &nationalCode;
		return S_OK;
	}

    TAG_METHOD_DECL(set_number)
	{
		m_characters = &number;
		return S_OK;
	}

    TAG_METHOD_DECL(set_numberExtension)
	{
		m_characters = &numberExtension;
		return S_OK;
	}

    TAG_METHOD_DECL(set_pin)
	{
		m_characters = &pin;
		return S_OK;
	}

	BEGIN_XMLTAG_MAP(CTelephoneNumber)		
		XMLTAG_CLASS("cat",				CCat<CTelephoneNumber>)
		XMLTAG_ENTRY("name",			set_name)	
		XMLTAG_ENTRY("countryCode",		set_countryCode)
		XMLTAG_ENTRY("nationalCode",	set_nationalCode)
		XMLTAG_ENTRY("number",			set_number)
		XMLTAG_ENTRY("numberExtension",	set_numberExtension)
		XMLTAG_ENTRY("pin",				set_pin)	
	END_XMLTAG_MAP()

	HRESULT 
    STDMETHODCALLTYPE
    endElement( 
        LPCWSTR wszNamespaceUri,
        int cchNamespaceUri,
        LPCWSTR wszLocalName,
        int cchLocalName,
        LPCWSTR wszQName,
        int cchQName
        )
	{				
		USES_CONVERSION;
		qname.SetString(W2A(wszQName), cchQName);

		CString temp;
		temp.SetString(W2A(wszLocalName), cchLocalName);

		if (temp == localname)
		{
			// cast to our parent class
			ISAXContentHandler *pParent(NULL);
			if (SUCCEEDED(this->GetParentHandler(&pParent)) && pParent)
			{
				TParentClass* parent = static_cast<TParentClass*>(pParent);
				if (parent)
				{
					// tell our parent that we are done parsing
					parent->OnDoneChain(this);						
					pParent->Release();
				}
			}
			return __super::endElement(	wszNamespaceUri,
										cchNamespaceUri,
										wszLocalName,
										cchLocalName,
										wszQName,
										cchQName);	
		}
		return S_OK;
	}

	HTTP_CODE get_cat()
	{		
		cat.prefix = prefix;
		cat.SetOutputStream(m_stream);
		cat.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_countryCode()
	{
		Write(countryCode);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_nationalCode()
	{
		Write(nationalCode);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_number()
	{
		Write(number);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_numberExtension()
	{
		Write(numberExtension);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_pin()
	{
		Write(pin);
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CTelephoneNumber)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",	set_prefix)
		REPLACEMENT_METHOD_ENTRY("get_prefix",			get_prefix)		
		REPLACEMENT_METHOD_ENTRY("get_cat",				get_cat)		
		REPLACEMENT_METHOD_ENTRY("get_countryCode",		get_countryCode)
		REPLACEMENT_METHOD_ENTRY("get_nationalCode",	get_nationalCode)
		REPLACEMENT_METHOD_ENTRY("get_number",			get_number)
		REPLACEMENT_METHOD_ENTRY("get_numberExtension", get_numberExtension)
		REPLACEMENT_METHOD_ENTRY("get_pin",				get_pin)
	END_REPLACEMENT_METHOD_MAP()

protected:
	virtual const char* GetSRF()
	{
		return IDR_TELEPHONENUMBER;
	}
};
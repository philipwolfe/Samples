#pragma once

#include "localizedstring.h"
#include "cat.h"

template <typename TParentClass>  class CEmailAddress :
	public CBaseElement<CEmailAddress>
{
public:	
	CCat<CEmailAddress>					cat;
    CString								email;
	CLocalizableString<CEmailAddress>	name;

	CEmailAddress()
	{
		localname = "emailAddress";
		name.localname = "name";
	}

	void
	SetFrom(CEmailAddress<TParentClass> *from)
	{
		cat.SetFrom(&from->cat);
		email = from->email;
		name.SetFrom(&from->name);
	}

	void 
	OnDoneChain(CCat<CEmailAddress> *const c)
	{
		cat.SetFrom(c);
	}

	void 
	OnDoneChain(CLocalizableString<CEmailAddress> *const c)
	{
		name.SetFrom(c);
	}

	TAG_METHOD_DECL(set_email)
	{
		m_characters = &email;
		return S_OK;
	}	

	BEGIN_XMLTAG_MAP(CAddress)
		XMLTAG_CLASS("cat",			CCat<CEmailAddress>)
		XMLTAG_ENTRY("email",		set_email)
		XMLTAG_CLASS("name",		CLocalizableString<CEmailAddress>)
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

		if (localname == temp)
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

	HTTP_CODE get_email()
	{
		Write(email);

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_name()
	{
		name.prefix = prefix;
		name.SetOutputStream(m_stream);
		name.Generate();

		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CEmailAddress)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",	set_prefix)
		REPLACEMENT_METHOD_ENTRY("get_prefix",			get_prefix)					
		REPLACEMENT_METHOD_ENTRY("get_cat",				get_cat)
		REPLACEMENT_METHOD_ENTRY("get_email",			get_email)
		REPLACEMENT_METHOD_ENTRY("get_name",			get_name)
	END_REPLACEMENT_METHOD_MAP()

protected:
	virtual const char* GetSRF()
	{
		return IDR_EMAILADDRESS;
	}
};
     
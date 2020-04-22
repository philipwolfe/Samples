#pragma once

#include "xmibase.h"
#include "localizedstring.h"

template <typename TParentClass> class CCat :
	public CBaseElement<CCat>
{
public:
	CString value;
	CString ref;

	CCat()
	{
		localname = "cat";
		m_characters = &value;
	}

	void SetFrom(CCat<TParentClass>* c)
	{	
		this->ref	= c->ref;
		this->value = c->value;		
	}

	ATTR_METHOD_DECL(set_ref)
	{
		USES_CONVERSION;
		ref.SetString(W2A(wszLocalName), cchLocalName);
		return S_OK;
	}
		
	BEGIN_XMLATTR_MAP(CLocalizableString<TParentClass>)
		XMLATTR_ENTRY("ref",	set_ref)        		
    END_XMLATTR_MAP()

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
		localname.SetString(W2A(wszLocalName), cchLocalName);

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
	
	HTTP_CODE get_ref()
	{
		Write(ref);
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CCat)		
		REPLACEMENT_METHOD_ENTRY("get_ref",				get_ref)		
		REPLACEMENT_METHOD_ENTRY("get_prefix",			get_prefix)
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",	set_prefix)
		REPLACEMENT_METHOD_ENTRY("get_value",			get_value)
		REPLACEMENT_METHOD_ENTRY("get_localname",		get_localname)		
	END_REPLACEMENT_METHOD_MAP()

protected:
	virtual const char* GetSRF()
	{
		return IDR_CAT;
	}
};

#pragma once

#include "xmibase.h"

template <typename TParentClass> class CLocalizableString :
	public CBaseElement<CLocalizableString>
{
public:	
	CString lang;
	CString dir;	
	
	CLocalizableString()
	{
		lang = "en";
		dir  = "ltr";

		m_characters = &value;		
	}

	void SetFrom(CLocalizableString<TParentClass>* c)
	{	
		this->prefix	= c->prefix;
		this->localname = c->localname;
		this->qname		= c->qname;
		this->value		= c->value;
		this->lang		= c->lang;
		this->dir		= c->dir;		
	}

	ATTR_METHOD_DECL(set_lang)
	{
		USES_CONVERSION;
		lang.SetString(W2A(wszLocalName), cchLocalName);
		return S_OK;
	}

	ATTR_METHOD_DECL(set_dir)
	{
		USES_CONVERSION;
		dir.SetString(W2A(wszLocalName), cchLocalName);
		return S_OK;
	}
		
	BEGIN_XMLATTR_MAP(CLocalizableString<TParentClass>)
		XMLATTR_ENTRY("lang",	set_lang)        
		XMLATTR_ENTRY("dir",	set_dir)        
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
		
	HTTP_CODE get_lang()
	{
		Write(lang);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_dir()
	{
		Write(dir);
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CLocalizableString)		
		REPLACEMENT_METHOD_ENTRY("get_lang",			get_lang)
		REPLACEMENT_METHOD_ENTRY("get_dir",				get_dir)
		REPLACEMENT_METHOD_ENTRY("get_localname",		get_localname)
		REPLACEMENT_METHOD_ENTRY("get_prefix",			get_prefix)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",	set_prefix)		
		REPLACEMENT_METHOD_ENTRY("get_value",			get_value)
	END_REPLACEMENT_METHOD_MAP()

protected:
	virtual const char* GetSRF()
	{
		return IDR_LOCALIZABLESTRING;
	}
};

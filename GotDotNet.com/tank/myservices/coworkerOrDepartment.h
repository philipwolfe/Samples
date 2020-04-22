#pragma once
#include "xmibase.h"
#include "cat.h"
#include "localizedstring.h"

template <typename TParentClass>  class CCoworkerOrDepartment :
	public CBaseElement<CCoworkerOrDepartment>
{
public:
	CCat<CCoworkerOrDepartment>					cat;	
	CLocalizableString<CCoworkerOrDepartment>	name;
    CString										puid;
	CString										email;
	
	CCoworkerOrDepartment()
	{
		name.localname	= "name";		
		localname		= "coworkerOrDepartment";
	}

	void 
	SetFrom(CCoworkerOrDepartment<TParentClass> *from)
	{
		cat.SetFrom(&from->cat);
		name.SetFrom(&from->name);
		puid = from->puid;
		email = from->email;		
	}

	void 
	OnDoneChain(CCat<CCoworkerOrDepartment> *const c)
	{
		cat.SetFrom(c);
	}

	void 
	OnDoneChain(CLocalizableString<CCoworkerOrDepartment> *const c)
	{
		name.SetFrom(c);
	}

	TAG_METHOD_DECL(set_puid)
	{		
		m_characters = &puid;
		return S_OK;
	}

	TAG_METHOD_DECL(set_email)
	{		
		m_characters = &email;
		return S_OK;
	}

	BEGIN_XMLTAG_MAP(CIDNumber)		
		XMLTAG_CLASS("cat",		CCat<CCoworkerOrDepartment>)
		XMLTAG_CLASS("name",	CLocalizableString<CCoworkerOrDepartment>)
		XMLTAG_ENTRY("puid",	set_puid)
		XMLTAG_ENTRY("email",	set_email)		
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

	HTTP_CODE get_name()
	{
		name.prefix = prefix;
		name.SetOutputStream(m_stream);
		name.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_puid()
	{
		Write(puid);

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_email()
	{
		Write(email);

		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CCoworkerOrDepartment)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",		set_prefix)
		REPLACEMENT_METHOD_ENTRY("get_localname",			get_localname)		
		REPLACEMENT_METHOD_ENTRY("get_prefix",				get_prefix)		
		REPLACEMENT_METHOD_ENTRY("get_name",				get_name)		
		REPLACEMENT_METHOD_ENTRY("get_puid",				get_puid)			
		REPLACEMENT_METHOD_ENTRY("get_email",				get_email)		
		REPLACEMENT_METHOD_ENTRY("get_cat",					get_cat)		
	END_REPLACEMENT_METHOD_MAP()

protected:
	virtual const char* GetSRF()
	{
		return IDR_COWORKERORDEPARTMENT;
	}
};

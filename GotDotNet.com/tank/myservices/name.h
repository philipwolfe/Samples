#pragma once

#include "xmibase.h"
#include "localizedstring.h"
#include "cat.h"

template <typename TParentClass> class CName :
		public CBaseElement<CName>
{
public:		
	CCat<CName>					cat;
	CLocalizableString<CName>	title;
	CLocalizableString<CName>	givenName;
	CLocalizableString<CName>	middleName;
	CLocalizableString<CName>	surname;
	CLocalizableString<CName>	suffix;
	CLocalizableString<CName>	fileAsName;

	CName()
	{
		title.localname		 = "title";
		givenName.localname  = "givenName";
		middleName.localname = "middleName";
		surname.localname	 = "surname";
		suffix.localname	 = "suffix";
		fileAsName.localname = "fileAsName";
		localname			 = "name";
	}

	void
	SetFrom(CName<TParentClass> *from)
	{
		this->cat.SetFrom(&from->cat);
		this->title.SetFrom(&from->title);
		this->givenName.SetFrom(&from->givenName);
		this->middleName.SetFrom(&from->middleName);
		this->surname.SetFrom(&from->surname);
		this->suffix.SetFrom(&from->suffix);
		this->fileAsName.SetFrom(&from->fileAsName);
	}

	void 
	OnDoneChain(CCat<CName> *const c)
	{
		cat.SetFrom(c);
	}

	void 
	OnDoneChain(CLocalizableString<CName> *const c)
	{
		if (c->localname == "title")
		{
			title.SetFrom(c);
		}
		if (c->localname == "givenName")
		{
			givenName.SetFrom(c);
		}
		if (c->localname == "middleName")
		{
			middleName.SetFrom(c);
		}
		if (c->localname == "surname")
		{
			surname.SetFrom(c);
		}
		if (c->localname == "fileAsName")
		{
			fileAsName.SetFrom(c);
		}
		if (c->localname == "suffix")
		{
			suffix.SetFrom(c);
		}
	}

	BEGIN_XMLTAG_MAP(CName)		
		XMLTAG_CLASS("cat",			CCat<CName>)
		XMLTAG_CLASS("title",		CLocalizableString<CName>)
		XMLTAG_CLASS("givenName",	CLocalizableString<CName>)
		XMLTAG_CLASS("middleName",	CLocalizableString<CName>)
		XMLTAG_CLASS("surname",		CLocalizableString<CName>)
		XMLTAG_CLASS("suffix",		CLocalizableString<CName>)
		XMLTAG_CLASS("fileAsName",	CLocalizableString<CName>)		
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

	HTTP_CODE get_title()
	{
		title.prefix = prefix;
		title.SetOutputStream(m_stream);
		title.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_givenName()
	{		
		givenName.prefix = prefix;
		givenName.SetOutputStream(m_stream);
		givenName.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_middleName()
	{
		middleName.prefix = prefix;
		middleName.SetOutputStream(m_stream);
		middleName.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_surname()
	{
		surname.prefix = prefix;
		surname.SetOutputStream(m_stream);
		surname.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_suffix()
	{
		suffix.prefix = prefix;
		suffix.SetOutputStream(m_stream);
		suffix.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_fileasname()
	{		
		fileAsName.prefix = prefix;
		fileAsName.SetOutputStream(m_stream);
		fileAsName.Generate();

		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CName)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",	set_prefix)		
		REPLACEMENT_METHOD_ENTRY("get_cat",				get_cat)		
		REPLACEMENT_METHOD_ENTRY("get_title",			get_title)		
		REPLACEMENT_METHOD_ENTRY("get_givenName",		get_givenName)	
		REPLACEMENT_METHOD_ENTRY("get_middleName",		get_middleName)
		REPLACEMENT_METHOD_ENTRY("get_surname",			get_surname)
		REPLACEMENT_METHOD_ENTRY("get_suffix",			get_suffix)
		REPLACEMENT_METHOD_ENTRY("get_fileasname",		get_fileasname)		
	END_REPLACEMENT_METHOD_MAP()

protected:
	virtual const char* GetSRF()
	{
		return IDR_NAME;
	}
};

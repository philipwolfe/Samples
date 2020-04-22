#pragma once
#include "xmibase.h"
#include "cat.h"

template <typename TParentClass>  class CSpecialDate :
	public CBaseElement<CSpecialDate>
{
public:
	CCat<CSpecialDate>	cat;
	CString				date;

	CSpecialDate()
	{
		localname = "specialDate";
	}

	void 
	SetFrom(CSpecialDate<TParentClass> *from)
	{
		cat.SetFrom(&from->cat);
		date = from->date;
	}

	void 
	OnDoneChain(CCat<CSpecialDate> *const c)
	{
		cat.SetFrom(c);
	}

	TAG_METHOD_DECL(set_date)
	{		
		m_characters = &date;
		return S_OK;
	}

	BEGIN_XMLTAG_MAP(CSpecialDate)		
		XMLTAG_CLASS("cat",			CCat<CSpecialDate>)
		XMLTAG_ENTRY("date",		set_date)		
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

	HTTP_CODE get_date()
	{
		Write(date);

		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CSpecialDate)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",	set_prefix)		
		REPLACEMENT_METHOD_ENTRY("get_prefix",			get_prefix)		
		REPLACEMENT_METHOD_ENTRY("get_cat",				get_cat)
		REPLACEMENT_METHOD_ENTRY("get_date",			get_date)		
	END_REPLACEMENT_METHOD_MAP()

protected:
	virtual const char* GetSRF()
	{
		return IDR_SPECIALDATE;
	}
};
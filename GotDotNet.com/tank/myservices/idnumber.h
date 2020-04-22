#pragma once
#include "xmibase.h"
#include "cat.h"

template <typename TParentClass>  class CIDNumber :
	public CBaseElement<CIDNumber>
{
public:
	CCat<CIDNumber>	cat;
	CString			number;
	
	void 
	SetFrom(CIDNumber<TParentClass> *from)
	{
		cat.SetFrom(&from->cat);
		number = from->number;		
	}

	void 
	OnDoneChain(CCat<CIDNumber> *const c)
	{
		cat.SetFrom(c);
	}

	TAG_METHOD_DECL(set_number)
	{		
		m_characters = &number;
		return S_OK;
	}

	BEGIN_XMLTAG_MAP(CIDNumber)		
		XMLTAG_CLASS("cat",		CCat<CIDNumber>)
		XMLTAG_ENTRY("number",	set_number)		
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

	HTTP_CODE get_cat()
	{		
		cat.prefix = prefix;
		cat.SetOutputStream(m_stream);
		cat.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_number()
	{		
		Write(number);
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CIDNumber)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",	set_prefix)
		REPLACEMENT_METHOD_ENTRY("get_cat",				get_cat)		
		REPLACEMENT_METHOD_ENTRY("get_number",			get_number)				
	END_REPLACEMENT_METHOD_MAP()

protected:
	virtual const char* GetSRF()
	{
		return IDR_IDENTIFICATIONNUMBER;
	}
};

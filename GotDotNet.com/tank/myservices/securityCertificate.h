#pragma once
#include "xmibase.h"
#include "cat.h"

template <typename TParentClass>  class CSecurityCertificate :
	public CBaseElement<CSecurityCertificate>
{
public:
	CCat<CSecurityCertificate>	cat;
	CString						certificate;

	CSecurityCertificate()
	{
		localname = "securityCertificate";
	}

	void 
	SetFrom(CSecurityCertificate<TParentClass> *from)
	{
		cat.SetFrom(&from->cat);
		certificate = from->certificate;
	}

	void 
	OnDoneChain(CCat<CSecurityCertificate> *const c)
	{
		cat.SetFrom(c);
	}

	TAG_METHOD_DECL(set_certificate)
	{		
		m_characters = &certificate;
		return S_OK;
	}

	BEGIN_XMLTAG_MAP(CSpecialDate)		
		XMLTAG_CLASS("cat",				CCat<CSecurityCertificate>)
		XMLTAG_ENTRY("certificate",		set_certificate)		
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

	HTTP_CODE get_certificate()
	{
		Write(certificate);
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CSecurityCertificate)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",	set_prefix)
		REPLACEMENT_METHOD_ENTRY("get_prefix",			get_prefix)		
		REPLACEMENT_METHOD_ENTRY("get_cat",				get_cat)
		REPLACEMENT_METHOD_ENTRY("get_certificate",		get_certificate)		
	END_REPLACEMENT_METHOD_MAP()

protected:
	virtual const char* GetSRF()
	{
		return IDR_SECURITYCERTIFICATE;
	}
};

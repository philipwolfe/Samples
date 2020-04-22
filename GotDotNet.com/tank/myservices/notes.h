#pragma once

#include "localizedstring.h"

template <typename TParentClass> class CNotes :
	public CBaseElement<CNotes>
{
public:
	CLocalizableString <CNotes>	notes;
	
	void 
	OnDoneChain(CLocalizableString<CNotes> *localizableString)
	{
		notes.SetFrom(localizableString);
	}

	BEGIN_XMLTAG_MAP(CNotes)		
		XMLTAG_CLASS("notes", CNotes)
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
};
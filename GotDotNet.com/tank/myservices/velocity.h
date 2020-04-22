#pragma once

#include "xmibase.h"

template <typename TParentClass>  class CVelocity :
	public CBaseElement<CVelocity>
{
public:
	CString speed;
	CString direction;

	CVelocity()
	{
		localname = "velocity";
	}

	void
	SetFrom(CVelocity<TParentClass> *const from)
	{
		this->speed		= from->speed;
		this->direction = from->direction;
	}

	TAG_METHOD_DECL(set_speed)
	{
		m_characters = &speed;
		return S_OK;
	}

	TAG_METHOD_DECL(set_direction)
	{
		m_characters = &direction;
		return S_OK;
	}

	BEGIN_XMLTAG_MAP(CVelocity)				
		XMLTAG_ENTRY("speed",		set_speed)		
		XMLTAG_ENTRY("direction",	set_direction)		
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

	HTTP_CODE get_speed()
	{
		Write(speed);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_direction()
	{
		Write(direction);
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CVelocity)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",	set_prefix)
		REPLACEMENT_METHOD_ENTRY("get_prefix",			get_prefix)			
		REPLACEMENT_METHOD_ENTRY("get_speed",			get_speed)
		REPLACEMENT_METHOD_ENTRY("get_direction",		get_direction)

	END_REPLACEMENT_METHOD_MAP()

protected:
	virtual const char* GetSRF()
	{
		return IDR_VELOCITY;
	}
};
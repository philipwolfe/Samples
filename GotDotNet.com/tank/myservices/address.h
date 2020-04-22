#pragma once

#include "localizedstring.h"
#include "velocity.h"

template <typename TParentClass>  class CAddress :
	public CBaseElement<CAddress>
{
public:
	CCat<CAddress>					cat;
	CLocalizableString<CAddress>	officialAddressLine;
	CLocalizableString<CAddress>	internalAddressLine;
	CLocalizableString<CAddress>	primaryCity;
	CLocalizableString<CAddress>	secondaryCity;
	CLocalizableString<CAddress>	subdivision;
	CString							postalCode;
	CString							countryCode;
	CString							latitude;
	CString							longitude;
	CString							elevation;      
	CVelocity<CAddress>				velocity;
	CString							confidence;
	CString							precision;       

	CAddress()
	{
		localname						= "address";
		officialAddressLine.localname	= "officialAddressLine";
		internalAddressLine.localname	= "internalAddressLine";
		primaryCity.localname			= "primaryCity";
		secondaryCity.localname			= "secondaryCity";
		subdivision.localname			= "subdivision";
	}

	void
	SetFrom(CAddress<TParentClass> *from)
	{
		cat.SetFrom(&from->cat);
		officialAddressLine.SetFrom(&from->officialAddressLine);
		internalAddressLine.SetFrom(&from->internalAddressLine);
		primaryCity.SetFrom(&from->primaryCity);
		secondaryCity.SetFrom(&from->secondaryCity);
		subdivision.SetFrom(&from->subdivision);
		postalCode = from->postalCode;
		countryCode = from->countryCode;
		latitude = from->latitude;
		longitude = from->longitude;
		elevation = from->elevation;
		velocity.SetFrom(&from->velocity);
		confidence = from->confidence;
		precision = from->precision;
	}

	void 
	OnDoneChain(CCat<CAddress> *const c)
	{
		cat.SetFrom(c);
	}

	void 
	OnDoneChain(CVelocity<CAddress> *const c)
	{
		velocity.SetFrom(c);
	}

	void 
	OnDoneChain(CLocalizableString<CAddress> *const c)
	{
		if (c->localname == "officialAddressLine")
		{
			officialAddressLine.SetFrom(c);
		}

		if (c->localname == "internalAddressLine")
		{
			internalAddressLine.SetFrom(c);
		}

		if (c->localname == "primaryCity")
		{
			primaryCity.SetFrom(c);
		}

		if (c->localname == "secondaryCity")
		{
			secondaryCity.SetFrom(c);
		}

		if (c->localname == "subdivision")
		{
			subdivision.SetFrom(c);
		}	
	}

	TAG_METHOD_DECL(set_postalCode)
	{
		m_characters = &postalCode;
		return S_OK;
	}

	TAG_METHOD_DECL(set_countryCode)
	{
		m_characters = &countryCode;
		return S_OK;
	}

	TAG_METHOD_DECL(set_latitude)
	{
		m_characters = &latitude;
		return S_OK;
	}

	TAG_METHOD_DECL(set_longitude)
	{
		m_characters = &longitude;
		return S_OK;
	}

	TAG_METHOD_DECL(set_elevation)
	{
		m_characters = &elevation;
		return S_OK;
	}

	TAG_METHOD_DECL(set_confidence)
	{
		m_characters = &confidence;
		return S_OK;
	}

	TAG_METHOD_DECL(set_precision)
	{
		m_characters = &precision;
		return S_OK;
	}
	
	BEGIN_XMLTAG_MAP(CAddress)
		XMLTAG_CLASS("cat",					CCat<CAddress>)
		XMLTAG_CLASS("officialAddressLine", CLocalizableString<CAddress>)
		XMLTAG_CLASS("internalAddressLine", CLocalizableString<CAddress>)
		XMLTAG_CLASS("primaryCity",			CLocalizableString<CAddress>)
		XMLTAG_CLASS("secondaryCity",		CLocalizableString<CAddress>)
		XMLTAG_CLASS("subdivision",			CLocalizableString<CAddress>)
		XMLTAG_ENTRY("postalCode",			set_postalCode)
		XMLTAG_ENTRY("countryCode",			set_countryCode)
		XMLTAG_ENTRY("latitude",			set_latitude)
		XMLTAG_ENTRY("longitude",			set_longitude)
		XMLTAG_ENTRY("elevation",			set_elevation)      
		XMLTAG_CLASS("velocity",			CVelocity<CAddress>)
		XMLTAG_ENTRY("confidence",			set_confidence)
		XMLTAG_ENTRY("precision",			set_precision)
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

	HTTP_CODE get_officialAddressLine()
	{
		officialAddressLine.prefix = prefix;
		officialAddressLine.SetOutputStream(m_stream);
		officialAddressLine.Generate();

		return HTTP_SUCCESS;
	}
	
	HTTP_CODE get_internalAddressLine()
	{
		internalAddressLine.prefix = prefix;
		internalAddressLine.SetOutputStream(m_stream);
		internalAddressLine.Generate();

		return HTTP_SUCCESS;
	}
	HTTP_CODE get_primaryCity()
	{
		primaryCity.prefix = prefix;
		primaryCity.SetOutputStream(m_stream);
		primaryCity.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_secondaryCity()
	{
		secondaryCity.prefix = prefix;
		secondaryCity.SetOutputStream(m_stream);
		secondaryCity.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_subdivision()
	{
		subdivision.prefix = prefix;
		subdivision.SetOutputStream(m_stream);
		subdivision.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_postalCode()
	{
		Write(postalCode);

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_countryCode()
	{
		Write(countryCode);

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_latitude()
	{
		Write(latitude);	
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_longitude()
	{
		Write(longitude);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_velocity()
	{
		velocity.prefix = prefix;
		velocity.SetOutputStream(m_stream);
		velocity.Generate();
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_elevation()
	{
		Write(elevation);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_confidence()
	{
		Write(confidence);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_precision()
	{
		Write(precision);
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CAddress)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",		set_prefix)
		REPLACEMENT_METHOD_ENTRY("get_cat",					get_cat)	
		REPLACEMENT_METHOD_ENTRY("get_localname",			get_localname)	
		REPLACEMENT_METHOD_ENTRY("get_officialAddressLine",	get_officialAddressLine)
		REPLACEMENT_METHOD_ENTRY("get_internalAddressLine",	get_internalAddressLine)
		REPLACEMENT_METHOD_ENTRY("get_primaryCity",			get_primaryCity)
	    REPLACEMENT_METHOD_ENTRY("get_secondaryCity",		get_secondaryCity)
	    REPLACEMENT_METHOD_ENTRY("get_subdivision",			get_subdivision)	
		REPLACEMENT_METHOD_ENTRY("get_postalCode",			get_postalCode)
		REPLACEMENT_METHOD_ENTRY("get_countryCode",			get_countryCode)
		REPLACEMENT_METHOD_ENTRY("get_latitude",			get_latitude)
		REPLACEMENT_METHOD_ENTRY("get_longitude",			get_longitude)
		REPLACEMENT_METHOD_ENTRY("get_elevation",			get_elevation)
		REPLACEMENT_METHOD_ENTRY("get_velocity",			get_velocity)
		REPLACEMENT_METHOD_ENTRY("get_confidence",			get_confidence)
		REPLACEMENT_METHOD_ENTRY("get_precision",			get_precision)

	END_REPLACEMENT_METHOD_MAP()

protected:
	virtual const char* GetSRF()
	{
		return IDR_ADDRESS;
	}
};

     
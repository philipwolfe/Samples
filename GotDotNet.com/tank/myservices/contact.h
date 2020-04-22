#pragma once

#include "cat.h"
#include "name.h"
#include "specialdate.h"
#include "picture.h"
#include "notes.h"
#include "address.h"
#include "emailaddress.h"
#include "website.h"
#include "screenname.h"
#include "idnumber.h"
#include "workinformation.h"
#include "userreference.h"
#include "securityCertificate.h"
#include "telephonenumber.h"
#include "website.h"

template <typename TParentClass> class CContact :
		public CBaseElement<CContact>
{
public:			
	CCat<CContact>					cat;	
	CName<CContact>					name;
	CString							id;
	CString							puid;
	CString							gender;
	CSpecialDate<CContact>			specialdate;
	CPicture<CContact>				picture;
	CLocalizableString<CContact>	notes;
	CAddress<CContact>				address;
	CEmailAddress<CContact>			emailaddress;
	CWebSite<CContact>				website;	
	CScreenName<CContact>			screenname;
	CTelephoneNumber<CContact>		telephonenumber;
	CIDNumber<CContact>				idnumber;
	CWorkInformation<CContact>		workInformation;
	CUserReference<CContact>		userreference;
	CSecurityCertificate<CContact>	securityCertificate;

	CContact()
	{
		localname			= "contact";
		notes.localname		= "notes";
		gender				= "f";		
	}

	void
	SetFrom(CContact<TParentClass> *from)
	{
		id = from->id;
		cat.SetFrom(&from->cat);
		name.SetFrom(&from->name);
		puid = from->puid;
		gender = from->gender;
		specialdate.SetFrom(&from->specialdate);
		picture.SetFrom(&from->picture);
		notes.SetFrom(&from->notes);
		address.SetFrom(&from->address);
		emailaddress.SetFrom(&from->emailaddress);
		website.SetFrom(&from->website);
		screenname.SetFrom(&from->screenname);
		telephonenumber.SetFrom(&from->telephonenumber);
		idnumber.SetFrom(&from->idnumber);
		workInformation.SetFrom(&from->workInformation);
		userreference.SetFrom(&from->userreference);
		securityCertificate.SetFrom(&from->securityCertificate);
	}

	void OnDoneChain(CTelephoneNumber<CContact> *c)
	{
		telephonenumber.SetFrom(c);
	}

	void 
	OnDoneChain(CSecurityCertificate<CContact> *c)
	{
		securityCertificate.SetFrom(c);
	}

	void
	OnDoneChain(CUserReference<CContact> *c)
	{
		userreference.SetFrom(c);
	}

	void
	OnDoneChain(CWorkInformation<CContact> *c)
	{
		workInformation.SetFrom(c);
	}

	void
	OnDoneChain(CIDNumber<CContact> *c)
	{
		idnumber.SetFrom(c);
	}

	void
	OnDoneChain(CScreenName<CContact> *c)
	{
		screenname.SetFrom(c);
	}
		
	void
	OnDoneChain(CEmailAddress<CContact> *c)
	{
		emailaddress.SetFrom(c);
	}

	void
	OnDoneChain(CAddress<CContact> *c)
	{
		address.SetFrom(c);
	}

	void
	OnDoneChain(CPicture<CContact> *c)
	{
		picture.SetFrom(c);				
	}
	
	void
	OnDoneChain(CWebSite<CContact> *c)
	{
		website.SetFrom(c);
	}
	
	void
	OnDoneChain(CCat<CContact> *c)
	{
		cat.SetFrom(c);
	}

	void
	OnDoneChain(CName<CContact> *c)
	{
		name.SetFrom(c);
	}

	void
	OnDoneChain(CSpecialDate<CContact> *c)
	{
		specialdate.SetFrom(c);
	}
	
	void 
	OnDoneChain(CLocalizableString<CContact> *c)
	{
		if (c->localname == "notes")
		{
			notes.SetFrom(c);
		}			
	}

	TAG_METHOD_DECL(set_puid)
	{
		m_characters = &puid;		
		return S_OK;
	}	

	TAG_METHOD_DECL(set_gender)
	{
		m_characters = &gender;		
		return S_OK;
	}	

	ATTR_METHOD_DECL(set_id)
	{
		USES_CONVERSION;		
		id.SetString(W2A(wszValue), cchValue);
		return S_OK;
	}

	BEGIN_XMLATTR_MAP(CContact)
		XMLATTR_ENTRY("id",		set_id)        		
    END_XMLATTR_MAP()

	BEGIN_XMLTAG_MAP(CContact)		
		XMLTAG_CLASS("cat",					CCat<CContact>)
		XMLTAG_CLASS("name",				CName<CContact>)
		XMLTAG_ENTRY("puid",				set_puid)
		XMLTAG_CLASS("specialDate",			CSpecialDate<CContact>)
		XMLTAG_CLASS("picture",				CPicture<CContact>)
		XMLTAG_ENTRY("gender",				set_gender)
		XMLTAG_CLASS("notes",				CLocalizableString<CContact>)
		XMLTAG_CLASS("address",				CAddress<CContact>)
		XMLTAG_CLASS("emailAddress",		CEmailAddress<CContact>)
		XMLTAG_CLASS("webSite",				CWebSite<CContact>)
		XMLTAG_CLASS("screenName",			CScreenName<CContact>)
		XMLTAG_CLASS("telephoneNumber",		CTelephoneNumber<CContact>)
		XMLTAG_CLASS("identificationNumber",CIDNumber<CContact>)
		XMLTAG_CLASS("workInformation",		CWorkInformation<CContact>)
		XMLTAG_CLASS("userReference",		CUserReference<CContact>)
		XMLTAG_CLASS("securityCertificate", CSecurityCertificate<CContact>)
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
		else
		{
			return S_OK;
		}
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

	HTTP_CODE get_specialDate()
	{
		specialdate.prefix = prefix;
		specialdate.SetOutputStream(m_stream);
		specialdate.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_picture()
	{
		picture.prefix = prefix;
		picture.SetOutputStream(m_stream);
		picture.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_gender()
	{
		Write(gender);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_notes()
	{
		notes.prefix = prefix;
		notes.SetOutputStream(m_stream);
		notes.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_address()
	{
		address.prefix = prefix;
		address.SetOutputStream(m_stream);
		address.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_emailaddress()
	{
		emailaddress.prefix = prefix;
		emailaddress.SetOutputStream(m_stream);
		emailaddress.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_website()
	{
		website.prefix = prefix;
		website.SetOutputStream(m_stream);
		website.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_screenname()
	{
		screenname.prefix = prefix;
		screenname.SetOutputStream(m_stream);
		screenname.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_telephonenumber()
	{
		telephonenumber.prefix = prefix;
		telephonenumber.SetOutputStream(m_stream);
		telephonenumber.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_identificationNumber()
	{
		idnumber.prefix = prefix;
		idnumber.SetOutputStream(m_stream);
		idnumber.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_workInformation()
	{
		workInformation.prefix = prefix;
		workInformation.SetOutputStream(m_stream);
		workInformation.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_userReference()
	{
		userreference.prefix = prefix;
		userreference.SetOutputStream(m_stream);
		userreference.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_securityCertificate()
	{
		securityCertificate.prefix = prefix;
		securityCertificate.SetOutputStream(m_stream);
		securityCertificate.Generate();

		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CContact)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",			set_prefix)
		REPLACEMENT_METHOD_ENTRY("get_cat",						get_cat)		
		REPLACEMENT_METHOD_ENTRY("get_name",					get_name)		
		REPLACEMENT_METHOD_ENTRY("get_puid",					get_puid)		
		REPLACEMENT_METHOD_ENTRY("get_specialDate",				get_specialDate)
		REPLACEMENT_METHOD_ENTRY("get_picture",					get_picture)
		REPLACEMENT_METHOD_ENTRY("get_gender",					get_gender)
		REPLACEMENT_METHOD_ENTRY("get_notes",					get_notes)
		REPLACEMENT_METHOD_ENTRY("get_address",					get_address)
		REPLACEMENT_METHOD_ENTRY("get_emailaddress",			get_emailaddress)
		REPLACEMENT_METHOD_ENTRY("get_website",					get_website)
		REPLACEMENT_METHOD_ENTRY("get_screenname",				get_screenname)
		REPLACEMENT_METHOD_ENTRY("get_telephonenumber",			get_telephonenumber)
		REPLACEMENT_METHOD_ENTRY("get_identificationNumber",	get_identificationNumber)
		REPLACEMENT_METHOD_ENTRY("get_workInformation",			get_workInformation)		   
		REPLACEMENT_METHOD_ENTRY("get_userReference",			get_userReference)
		REPLACEMENT_METHOD_ENTRY("get_securityCertificate",		get_securityCertificate)
	END_REPLACEMENT_METHOD_MAP()

protected:
	virtual const char* GetSRF()
	{
		return IDR_CONTACT;
	}
};

class CNoContactParent :
	public CBaseElement<CNoContactParent>
{
public:
	void OnDoneChain(CContact<CNoContactParent> *response)
	{}
};

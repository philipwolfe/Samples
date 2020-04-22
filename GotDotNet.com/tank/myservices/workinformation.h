#pragma once
#include "xmibase.h"
#include "cat.h"
#include "localizedstring.h"
#include "coworkerordepartment.h"

template <typename TParentClass>  class CWorkInformation :
	public CBaseElement<CWorkInformation>
{
public:
	CCat<CWorkInformation>					cat;	
	CLocalizableString<CWorkInformation>	profession;
	CLocalizableString<CWorkInformation>	jobTitle;
	CLocalizableString<CWorkInformation>	officeLocation;
	CCoworkerOrDepartment<CWorkInformation> coworkerOrDepartment;

	CWorkInformation()
	{
		localname				 = "workInformation";
		profession.localname	 = "profession";
		jobTitle.localname		 = "jobTitle";
		officeLocation.localname = "officeLocation";
	}

	void 
	SetFrom(CWorkInformation<TParentClass> *from)
	{
		cat.SetFrom(&from->cat);		
		profession.SetFrom(&from->profession);		
		jobTitle.SetFrom(&from->jobTitle);		
		officeLocation.SetFrom(&from->officeLocation);		
		coworkerOrDepartment.SetFrom(&from->coworkerOrDepartment);		
	}

	void 
	OnDoneChain(CCat<CWorkInformation> *const c)
	{
		cat.SetFrom(c);
	}

	void
	OnDoneChain(CLocalizableString<CWorkInformation> *const c)
	{
		if (c->localname == "jobTitle")
		{
			jobTitle.SetFrom(c);
		}

		if (c->localname == "officeLocation")
		{
			officeLocation.SetFrom(c);
		}
	}
	
	void
	OnDoneChain(CCoworkerOrDepartment<CWorkInformation> *const c)
	{
		coworkerOrDepartment.SetFrom(c);	
	}

	BEGIN_XMLTAG_MAP(CWorkInformation)		
		XMLTAG_CLASS("cat",						CCat<CWorkInformation>)
		XMLTAG_CLASS("profession",				CLocalizableString<CWorkInformation>)
		XMLTAG_CLASS("jobTitle",				CLocalizableString<CWorkInformation>)
		XMLTAG_CLASS("officeLocation",			CLocalizableString<CWorkInformation>)
		XMLTAG_CLASS("coworkerOrDepartment",	CCoworkerOrDepartment<CWorkInformation>)		
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

	HTTP_CODE get_profession()
	{
		profession.prefix = prefix;
		profession.SetOutputStream(m_stream);
		profession.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_jobTitle()
	{
		jobTitle.prefix = prefix;
		jobTitle.SetOutputStream(m_stream);
		jobTitle.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_officeLocation()
	{
		officeLocation.prefix = prefix;
		officeLocation.SetOutputStream(m_stream);
		officeLocation.Generate();

		return HTTP_SUCCESS;
	}

	HTTP_CODE get_coworkerOrDepartment()
	{
		coworkerOrDepartment.prefix = prefix;
		coworkerOrDepartment.SetOutputStream(m_stream);
		coworkerOrDepartment.Generate();

		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CWorkInformation)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",			set_prefix)
		REPLACEMENT_METHOD_ENTRY("get_prefix",					get_prefix)		
		REPLACEMENT_METHOD_ENTRY("get_cat",						get_cat)		
		REPLACEMENT_METHOD_ENTRY("get_profession",				get_profession)		
		REPLACEMENT_METHOD_ENTRY("get_jobTitle",				get_jobTitle)			
		REPLACEMENT_METHOD_ENTRY("get_officeLocation",			get_officeLocation)		
		REPLACEMENT_METHOD_ENTRY("get_coworkerOrDepartment",	get_coworkerOrDepartment)		
	END_REPLACEMENT_METHOD_MAP()

protected:
	virtual const char* GetSRF()
	{
		return IDR_WORKINFORMATION;
	}
};
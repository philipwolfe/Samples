#pragma once

#include "xmibase.h"	
#include "cat.h"
#include <atlcoll.h>

typedef CAtlMap<CString, CString> SettingMapType;

template <typename TParentClass> class CApplicationSetting :
		public CBaseElement<CApplicationSetting>
{		
private:
	CString		m_settingValue;
	
public:
	SettingMapType				m_settings;
	POSITION					m_pos;
	CString						m_setting;
	CString						settingprefix;

	bool						m_first;
	CCat<CApplicationSetting>	cat;
	CString						name;
	CString						id;
	
	CApplicationSetting() : 
		m_pos(NULL),
		m_first(true)
	{
		localname = "applicationSetting";
	}

	void SetFrom(CApplicationSetting<TParentClass> *from)
	{
		cat.SetFrom(&from->cat);
		name			= from->name;
		settingprefix	= from->settingprefix;
		localname		= from->localname;
		prefix			= from->prefix;
		id				= from->id;

		POSITION start = from->m_settings.GetStartPosition();

		if (start)
		{
			CString key;
			CString value;

			key = from->m_settings.GetKeyAt(start);
			m_settings[key] = from->m_settings[key];
			from->m_settings.GetNextAssoc(start, key, value);
			while (start)
			{
				m_settings[key] = value;
				from->m_settings.GetNextAssoc(start, key, value);
			}
		}
	}

	void OnDoneChain(CCat<CApplicationSetting> *c)
	{
		cat.SetFrom(c);
	}

	TAG_METHOD_DECL(set_name)
	{
		m_characters = &name;
		return S_OK;
	}

	void AddSetting(const CString& name, const CString& value)
	{
		m_settings[name] = value;						
	}

	ATTR_METHOD_DECL(set_id)
	{
		USES_CONVERSION;		
		id.SetString(W2A(wszValue), cchValue);
		return S_OK;
	}
	
	BEGIN_XMLATTR_MAP(CApplicationSetting)
		XMLATTR_ENTRY("id",		set_id)        		
    END_XMLATTR_MAP()

	BEGIN_XMLTAG_MAP(CApplicationSetting)		
		XMLTAG_CLASS("cat",		CCat<CApplicationSetting>)
		XMLTAG_ENTRY("name",	set_name)	
	END_XMLTAG_MAP()

	HTTP_CODE has_more_settings()
	{		
		if (m_first)
		{
			m_pos   = m_settings.GetStartPosition();		
			m_first = false;
		}
		else
		{
			if (m_pos)
			{
				// update our position				
				m_settings.GetNext(m_pos);		
			}
		}
		return m_pos ? HTTP_SUCCESS : HTTP_S_FALSE;		
	}

	HTTP_CODE get_setting_name()
	{
		Write((const char*)m_settings.GetKeyAt(m_pos));
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_setting_value()
	{
		Write((const char*)m_settings.GetValueAt(m_pos));
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_setting_prefix()
	{
		Write((const char*)settingprefix);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_name()
	{
		Write((const char*)name);
		return HTTP_SUCCESS;
	}

	HTTP_CODE get_cat()
	{
		cat.prefix = prefix;
		cat.SetOutputStream(m_stream);
		cat.Generate();
		return HTTP_SUCCESS;
	}		

	BEGIN_REPLACEMENT_METHOD_MAP(CApplicationSetting)		
		REPLACEMENT_METHOD_ENTRY_EX_STR("set_prefix",	set_prefix)
		REPLACEMENT_METHOD_ENTRY("get_prefix",			get_prefix)
		REPLACEMENT_METHOD_ENTRY("get_cat",				get_cat)
		REPLACEMENT_METHOD_ENTRY("get_name",			get_name)
		REPLACEMENT_METHOD_ENTRY("has_more_settings",	has_more_settings)
		REPLACEMENT_METHOD_ENTRY("get_setting_name",	get_setting_name)
		REPLACEMENT_METHOD_ENTRY("get_setting_value",	get_setting_value)
		REPLACEMENT_METHOD_ENTRY("get_setting_prefix",	get_setting_prefix)
	END_REPLACEMENT_METHOD_MAP()

	HRESULT 
    STDMETHODCALLTYPE 
    startElement( 
        LPCWSTR wszNamespaceUri,
        int cchNamespaceUri,
        LPCWSTR wszLocalName,
        int cchLocalName,
        LPCWSTR wszQName,
        int cchQName,
        ISAXAttributes  *pAttributes
        )
	{
		USES_CONVERSION;
		CString temp;
		temp.SetString(W2A(wszLocalName), cchLocalName);

		if (temp != localname && temp != "name")
		{
			m_characters = &m_settingValue;			
		}

		return __super::startElement(wszNamespaceUri,
									 cchNamespaceUri,
									 wszLocalName,
									 cchLocalName,
									 wszQName,
									 cchQName,
									 pAttributes);		
	}

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

		if (temp != "name" && temp != "cat")
		{
			AddSetting(temp, m_settingValue);
		}
		return S_OK;
	}

protected:
	virtual const char* GetSRF()
	{
		return IDR_APPLICATION_SETTING;
	}
};

class CNoApplicationSettingParent :
	public CBaseElement<CNoApplicationSettingParent>
{
public:
	void OnDoneChain(CApplicationSetting<CNoApplicationSettingParent> *response)
	{}
};

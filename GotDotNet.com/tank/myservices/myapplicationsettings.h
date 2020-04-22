#include "xmibase.h"
#include "applicationsetting.h"
#include "response.h"
#include "hailstormservice.h"

class CMyApplicationSettingsResponse : 
	public CResponse<CApplicationSetting<CMyApplicationSettingsResponse> >
{
public:
	BEGIN_XMLTAG_MAP(CMyApplicationSettingsResponse)		
		XMLTAG_CLASS("applicationSetting",	CApplicationSetting<CMyApplicationSettingsResponse>)
	END_XMLTAG_MAP()
};

class CMyApplicationSettings 
	: public CBaseHailstormService<	CMyApplicationSettingsResponse, 
									CApplicationSetting<CMyApplicationSettingsResponse> >
{
public:	
	CMyApplicationSettings()
	{						
		m_xmiMessage.m_service	= "myApplicationSettings";
	}

	virtual bool Replace(CApplicationSetting<CMyApplicationSettingsResponse>&	replacementValues,
						 const CString&											id, 
						 const CString&											itemNamespace)
	{
		CMyApplicationSettingsResponse response;
		CString query;
		query.Format("//m:applicationSetting[@id='%s']", id);

		return __super::Replace(response, replacementValues, query, itemNamespace);
	}

	virtual bool Delete(const CString& id)
	{
		CMyApplicationSettingsResponse response;
		CString query;
		query.Format("//m:applicationSetting[@id='%s']", id);

		return __super::Delete(response, query);
	}

	virtual bool DeleteAll()
	{
		CMyApplicationSettingsResponse response;
		return __super::Delete(response, "//m:applicationSetting");
	}
};

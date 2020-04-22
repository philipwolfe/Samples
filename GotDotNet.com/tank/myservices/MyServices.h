#pragma once
#include "xmimessage.h"
#include "xmiquery.h"
#include "hailstormservice.h"

class CMyService 
	: public CXmiBase<CMyService>
{
public:
	CString Name;	

	virtual const char* GetSRF()
	{
		// TODO FIX THIS LATER
		return IDR_CONTACT;
	}
};

typedef CAutoPtrList<CMyService> ServiceInfoList;

class CMyServicesResponse : 
	public CSAXParser, 
	public CComObjectRootEx<CComSingleThreadModel>
{
private:
	ServiceInfoList		m_services;
	POSITION			m_currentServicePos;
	const CMyService*  m_currentService;

public:
	
	CMyServicesResponse() : m_currentServicePos(0), m_currentService(NULL)
	{
		m_currentServicePos = m_services.GetHeadPosition();
	}

	bool HasMoreServices()
	{
		if (!m_currentServicePos)
		{
			return false;
		}
		m_currentService = m_services.GetNext(m_currentServicePos);
		return true;
	}	

	bool GetServiceName(CString& name)
	{
		if (!m_currentService)
		{
			return false;
		}
		name = m_currentService->Name;
		return true;
	}

	BEGIN_COM_MAP(CMyServicesResponse)		
        COM_INTERFACE_ENTRY(ISAXContentHandler)
    END_COM_MAP()
	
	HRESULT OnService(LPCWSTR wszNamespaceUri,	int cchNamespaceUri,
					  LPCWSTR wszLocalName,		int cchLocalName,
					  LPCWSTR wszQName,			int cchQName,
					  ISAXAttributes *pAttributes)
	{
		// TODO get the values of the other attributes		
		// get the value of the 'name' attribute, it has to be there
		// TODO output some kind of warning if this fails
		int index(0);		
		if (SUCCEEDED(pAttributes->getIndexFromQName(L"name", (int)wcslen(L"name"), &index)))
		{
			const wchar_t *nameValue(NULL);
			int		valueSize(0);
			if (SUCCEEDED(pAttributes->getValue(index, &nameValue, &valueSize)))
			{				
				USES_CONVERSION;
				
				CAutoPtr<CMyService> service;
				service.Attach(new CMyService());

				service->Name = W2A(nameValue);

				m_services.AddTail(service);
			}
		}
		
		// if this is the first item, set our head position
		if (!m_currentServicePos)
		{
			m_currentServicePos = m_services.GetHeadPosition();
		}

		return S_OK;
	}

	HRESULT OnCat(LPCWSTR wszNamespaceUri,	int cchNamespaceUri,
				  LPCWSTR wszLocalName,		int cchLocalName,
				  LPCWSTR wszQName,			int cchQName,
				  ISAXAttributes *pAttributes)
	{
		return S_OK;
	}

	HRESULT OnKey(LPCWSTR wszNamespaceUri,	int cchNamespaceUri,
				  LPCWSTR wszLocalName,		int cchLocalName,
				  LPCWSTR wszQName,			int cchQName,
				  ISAXAttributes *pAttributes)
	{
		return S_OK;
	}

	HRESULT OnRefer(LPCWSTR wszNamespaceUri,	int cchNamespaceUri,
					LPCWSTR wszLocalName,		int cchLocalName,
					LPCWSTR wszQName,			int cchQName,
					ISAXAttributes *pAttributes)
	{
		return S_OK;
	}

	HRESULT OnTo(LPCWSTR wszNamespaceUri,	int cchNamespaceUri,
				 LPCWSTR wszLocalName,		int cchLocalName,
				 LPCWSTR wszQName,			int cchQName,
				 ISAXAttributes *pAttributes)
	{
		return S_OK;
	}

	HRESULT OnSpn(LPCWSTR wszNamespaceUri,	int cchNamespaceUri,
				  LPCWSTR wszLocalName,		int cchLocalName,
				  LPCWSTR wszQName,			int cchQName,
				  ISAXAttributes *pAttributes)
	{
		return S_OK;
	}

	HRESULT OnRealm(LPCWSTR wszNamespaceUri,	int cchNamespaceUri,
					LPCWSTR wszLocalName,		int cchLocalName,
					LPCWSTR wszQName,			int cchQName,
					ISAXAttributes *pAttributes)
	{
		return S_OK;
	}

	HRESULT OnUnrecognizedTag(LPCWSTR wszNamespaceUri,	int cchNamespaceUri,
							  LPCWSTR wszLocalName,		int cchLocalName,
							  LPCWSTR wszQName,			int cchQName,
							  ISAXAttributes *pAttributes)
	{
		// don't care about the ones we don't recognize
		return S_OK;
	}

	BEGIN_XMLTAG_MAP(CMyServicesResponse)
		XMLTAG_ENTRY("service", OnService)		
		XMLTAG_ENTRY("cat",		OnCat)
        XMLTAG_ENTRY("key",		OnKey)
        XMLTAG_ENTRY("refer",	OnRefer)
        XMLTAG_ENTRY("to",		OnTo)
        XMLTAG_ENTRY("spn",		OnSpn)
        XMLTAG_ENTRY("realm",	OnRealm)
	END_XMLTAG_MAP()	
};

typedef CComObjectStackEx<CMyServicesResponse> CMyServicesResponseType;

class CMyServices : public CBaseHailstormService<CMyServicesResponse, CMyService>
{
public:
	CMyServices()
	{						
		m_xmiMessage.m_service = "myServices";
	}

	virtual ~CMyServices(void)
	{
	}	
};

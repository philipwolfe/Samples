#pragma once

#include "resource1.h"
#include "xmibase.h"

#include <atlstencil.h>
#include <atlcoll.h>

class CXmiMessage : 
	public  CBaseElement<CXmiMessage>
{
private:
	typedef CAtlList<CString>	KEY_LIST;

	KEY_LIST		m_keys;
	POSITION		m_startKey;
	POSITION		m_currentKey;
public:
	CString m_action;
	CString m_rev;
	CString m_to;
	CString m_messageID;
	CString m_service;
	CString m_documentType;
	CString m_method;
	CString m_genResponse;	
	CString m_instance;
	CString m_cluster;
	CString m_puid;
	CString m_body;

public:
	CXmiMessage()
	{		
		// generate a message ID
		GUID guid;
		ZeroMemory(&guid, sizeof(GUID));
		HRESULT hr = CoCreateGuid(&guid);

		OLECHAR szGUID[64];
		if (::StringFromGUID2(guid, szGUID, 64))
		{
			m_messageID = szGUID;			
			m_messageID.Remove('{');
			m_messageID.Remove('}');
		}		

		// set some defaults
		m_genResponse = "always";
		m_instance	  = "1";
		m_cluster	  = "1";

		// TODO need to get this PUID for real
		m_puid		  = "2991";		
	}

	virtual ~CXmiMessage(void)
	{
	}

	virtual const char* GetSRF()
	{
		return IDR_XMI;
	}

	void SetServer(LPCSTR server)
	{
		m_to = server;
	}

	const CString& GetServer()
	{
		return m_to;
	}

	const CString& GetService()
	{
		return m_service;
	}

	void SetPUID(LPCSTR puid)
	{
		m_puid = puid;
	}

	void AddKey(CString& key)
	{

	}

	HTTP_CODE OnGetPathAction()
	{
		Write(m_action);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetPathRev()
	{
		Write(m_rev);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetPathTo()
	{
		Write(m_to);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetMessageID()
	{
		Write(m_messageID);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetService()
	{
		Write(m_service);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetDocumentType()
	{
		Write(m_documentType);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetMethod()
	{
		Write(m_method);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetGenResponse()
	{
		Write(m_genResponse);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnHasMoreKeys()
	{
		//m_currentKey = m_keys.OnGetNext(m_currentKey);
		//return m_currentKey ? HTTP_SUCCESS : HTTP_S_FALSE;		
		return HTTP_S_FALSE;
	}

	HTTP_CODE OnGetInstance()
	{
		Write(m_instance);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetCluster()
	{
		Write(m_cluster);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetPUID()
	{
		Write(m_puid);
		return HTTP_SUCCESS;
	}

	HTTP_CODE OnGetBody()
	{
		Write(m_body);
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CXmiMessage)		
		REPLACEMENT_METHOD_ENTRY("GetPathAction",	OnGetPathAction)
		REPLACEMENT_METHOD_ENTRY("GetPathRev",		OnGetPathRev)
		REPLACEMENT_METHOD_ENTRY("GetPathTo",		OnGetPathTo)
		REPLACEMENT_METHOD_ENTRY("GetMessageID",	OnGetMessageID)
		REPLACEMENT_METHOD_ENTRY("GetService",		OnGetService)
		REPLACEMENT_METHOD_ENTRY("GetDocumentType", OnGetDocumentType)
		REPLACEMENT_METHOD_ENTRY("GetMethod",		OnGetMethod)
		REPLACEMENT_METHOD_ENTRY("GetGenResponse",	OnGetGenResponse)
		REPLACEMENT_METHOD_ENTRY("HasMoreKeys",		OnHasMoreKeys)
		REPLACEMENT_METHOD_ENTRY("GetInstance",		OnGetInstance)
		REPLACEMENT_METHOD_ENTRY("GetCluster",		OnGetCluster)
		REPLACEMENT_METHOD_ENTRY("GetPUID",			OnGetPUID)
		REPLACEMENT_METHOD_ENTRY("GetBody",			OnGetBody)
	END_REPLACEMENT_METHOD_MAP()
};
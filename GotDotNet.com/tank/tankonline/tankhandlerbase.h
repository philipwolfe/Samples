#pragma once

#include "stdafx.h"

#define SERVER_VARIABLE		"server"
#define PUID_VARIABLE		"puid"
#define USERNAME_VARIABLE	"username"

#pragma warning(disable:4199)
template <	class THandler,
			class ThreadModel=CComSingleThreadModel,
			class TagReplacerType=CHtmlTagReplacer<THandler>
		 >
class CTankHandlerBaseT : 
	public CRequestHandlerT<THandler, ThreadModel, TagReplacerType>
{
protected:
	CString							m_server;
	CString							m_puid;
	CString							m_userName;

	bool							m_isPostBack;	

	CComPtr<ISessionStateService>	m_spSessionSvc;
	CComPtr<ISession>				m_spSession;

public:
	CTankHandlerBaseT() : 
	  m_isPostBack(false),
	  m_spSessionSvc(NULL),
	  m_spSession(NULL)
	{
	}

	HTTP_CODE ValidateAndExchange()
	{
		// get the ISessionStateService from the ISAPI extension
		if (FAILED(m_spServiceProvider->QueryService(__uuidof(ISessionStateService), &m_spSessionSvc)))
		{
			return HTTP_FAIL;
		}
		
		// create or get our session
		if (FAILED(EnsureGetSession(m_spSessionSvc, &m_spSession)))
		{
			return HTTP_FAIL;
		}

		// set the content-type
		m_HttpResponse.SetContentType("text/html");

		// get server, user name and puid
		m_server	= m_HttpRequest.GetQueryParams().Lookup(SERVER_VARIABLE);
		m_puid		= m_HttpRequest.GetQueryParams().Lookup(PUID_VARIABLE);
		m_userName	= m_HttpRequest.GetQueryParams().Lookup(USERNAME_VARIABLE);

		if (m_server.IsEmpty())
		{
			m_server = m_HttpRequest.GetFormVars().Lookup(SERVER_VARIABLE);			
		}		

		if (m_puid.IsEmpty())
		{
			m_puid = m_HttpRequest.GetFormVars().Lookup(PUID_VARIABLE);
		}		

		if (m_userName.IsEmpty())
		{
			m_userName = m_HttpRequest.GetFormVars().Lookup(USERNAME_VARIABLE);
		}

		if (FAILED(GetOrSetSessionValue(SERVER_VARIABLE, m_server)))
		{
			m_HttpResponse << "can't get server";
			return HTTP_FAIL;
		}

		if (FAILED(GetOrSetSessionValue(PUID_VARIABLE, m_puid)))
		{
			m_HttpResponse << "can't get puid";
			return HTTP_FAIL;
		}

		if (FAILED(GetOrSetSessionValue(USERNAME_VARIABLE, m_userName)))
		{
			m_HttpResponse << "can't get user name";
			return HTTP_FAIL;
		}
		
		if (m_server.IsEmpty() || m_puid.IsEmpty() || m_userName.IsEmpty())
		{			
			return HTTP_FAIL;
		}	

		// see if we are in a postback
		if (m_HttpRequest.GetFormVars().Lookup("submit"))
		{
			m_isPostBack = true;				
		}		
		return HTTP_SUCCESS;
	}
 
protected:
	
	HRESULT GetOrSetSessionValue(const CString& sessionVariableName,
								 CString&		sessionVariable)
	{
		HRESULT hr(S_OK);
		if (sessionVariable.IsEmpty())
		{
			CComVariant value;
			if (SUCCEEDED(m_spSession->GetVariable(sessionVariableName, &value)))
			{
				USES_CONVERSION;
				sessionVariable = OLE2T(value.bstrVal);		
			}
		}
		else
		{
			hr = m_spSession->SetVariable(sessionVariableName, CComVariant(sessionVariable));
		}

		return hr;
	}

	// Create a new session, add the session ID to the response as a cookie 
	HRESULT NewSession(ISessionStateService* pSessionService, ISession** ppSession) 
	{ 
		CHAR szID[64 + 1]; 
		*szID = 0; 
		DWORD dwCharacters = (sizeof(szID)/sizeof(szID[0])) - 1; 

		HRESULT hr = m_spSessionSvc->CreateNewSession(szID, &dwCharacters, ppSession); 

		if (SUCCEEDED(hr)) 
		{ 
			CSessionCookie theSessionCookie( szID ); 
			m_HttpResponse.AppendCookie( &theSessionCookie ); 
		} 
	
		return hr; 
	} 

	// Get session pointer based on ID in cookie 
	HRESULT GetSession(ISessionStateService* pSessionService, ISession** ppSession) 
	{ 
		HRESULT hr = E_FAIL; 
		CStringA szID; 

		if ( m_HttpRequest.Cookies(SESSION_COOKIE_NAME).GetValue( szID ))// && szID.GetLength()) 
		{ 
			hr = pSessionService->GetSession( szID, ppSession ); 
		} 

		return hr; 
	} 

	// Try to get the session, if that fails, create a new one 
	HRESULT EnsureGetSession(ISessionStateService* pSessionService, ISession** ppSession) 
	{ 
		HRESULT hr = GetSession(pSessionService, ppSession); 
	
		if (FAILED(hr)) 
		hr = NewSession( pSessionService, ppSession ); 

		return hr; 
	} 

	HTTP_CODE GetServer()
	{
		m_HttpResponse << m_server;
		return HTTP_SUCCESS;
	}

	HTTP_CODE GetPUID()
	{
		m_HttpResponse << m_puid;
		return HTTP_SUCCESS;
	}

	HTTP_CODE GetUserName()
	{	
		m_HttpResponse << m_userName;
		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(THandler)
		REPLACEMENT_METHOD_ENTRY("GetServer",	GetServer)
		REPLACEMENT_METHOD_ENTRY("GetPUID",		GetPUID)
		REPLACEMENT_METHOD_ENTRY("GetUserName",	GetUserName)
	END_REPLACEMENT_METHOD_MAP()
};

// MailService.h : Defines the ATL Server request handler class
// (c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "MailServiceDB.h"
#include "..\Common\Crypt.h"
// MSGDATA struct to return message data to the caller
typedef struct _MSGDATA
{
	BSTR m_bstrFrom;
	DATE m_DateSent;
	BSTR m_bstrSubject;
	LONG m_lMessageID;
	BOOL m_bMarkedRead;
} MSGDATA;

/////////////////////////////////////////////////////////////////////////////
// IMailService - web service interface declaration
// Note: you are not restricted to automation types, BSTR's are just easier to use

[
	uuid("216B8AF4-9A04-4820-B92E-210FA4EF5C50"), 
	object
]
__interface IMailService
{
	
	[id(1)] HRESULT Login([in] BSTR bstrLogin, [in] BSTR bstrPassword, [out] LONG* lUserID, [out] BSTR* bstrSessionID);
	[id(2)] HRESULT GetMessageCount([in] LONG lUserID, [in] BSTR bstrSessionID, [out] LONG* lMessageCount);
	[id(3)] HRESULT GetUnreadCount([in] LONG lUserID, [in] BSTR bstrSessionID, [out] LONG* lUnreadCount);
	[id(4)] HRESULT GetMessages([in] LONG lUserID, [in] BSTR bstrSessionID, [in] LONG lMax, [out] LONG *numMsgs, [out, size_is(*numMsgs)] MSGDATA **msgData);
	[id(5)] HRESULT GetLaunchURL([in] LONG lUserID, [in] BSTR bstrSessionID, [in] LONG lMessageID, [out] BSTR* bstrURL);
};

/////////////////////////////////////////////////////////////////////////////
// MailService - web service implementation
//
[
	request_handler(name="Default", sdl="GenMailServiceSDL"),
	soap_handler(
		name="MailService", 
		namespace="urn:MailService",
		protocol="soap"
	)
]
class CMailService :
	public IMailService,
	public CMantaWebBase<CMailService>
{
public:
	
	[ soap_method ]
	HRESULT Login(/*[in]*/ BSTR bstrLogin, /*[in]*/ BSTR bstrPassword, /*[out]*/ LONG* lUserID, /*[out]*/ BSTR *bstrSessionID)
	{
		// Get the cached data connection
		if (FAILED(GetDataConnection(&m_dataConnection)))
			return E_FAIL;

		// Get the user login data
		CLoginUser loginUser;
		USES_CONVERSION;
		lstrcpy(loginUser.m_szLogin, W2CA(bstrLogin));
		if (loginUser.OpenRowset(m_dataConnection, NULL) != S_OK)
			return E_FAIL;
		
		HRESULT hr = loginUser.MoveFirst();
		if (hr != S_OK && hr != DB_S_ENDOFROWSET)
			return E_FAIL;

		loginUser.Close();

		//If not the end of the rowset(invalid username)
		if (hr != DB_S_ENDOFROWSET){
			CW2A strPassword(bstrPassword);
			// If the passwords match
			hr = CompareSecret(
				(const BYTE*) (LPCSTR) strPassword, lstrlen(strPassword),
				(BYTE*) loginUser.m_szSalt, lstrlen(loginUser.m_szSalt),
				(BYTE*) loginUser.m_szPassword, lstrlen(loginUser.m_szPassword));
			if(hr==S_OK){
				// Get an existing session
				MantaWeb::CSessionData sessionData;
				sessionData.m_lUserID = loginUser.m_lUserID;
				if (sessionData.OpenRowset(m_dataConnection, NULL) != S_OK)
					return E_FAIL;
				HRESULT hr = sessionData.MoveFirst();
				if (hr != S_OK && hr != DB_S_ENDOFROWSET)
					return E_FAIL;
				sessionData.Close();

				// If there is no session, or an invalid session
				if (hr == DB_S_ENDOFROWSET || SessionTimeOut(sessionData.m_lastAccess))
				{
					// Remove an existing session
					MantaWeb::CRemoveSessionData removeSession;
					memcpy(&removeSession.m_guidSessionID, &sessionData.m_guidSessionID, sizeof(GUID));
					if (removeSession.OpenRowset(m_dataConnection, NULL) != S_OK)
						return E_FAIL;
					removeSession.Close();

					// Insert a new session
					MantaWeb::CInsertSession insertSession;
					insertSession.m_lUserID = loginUser.m_lUserID;
					if (insertSession.OpenRowset(m_dataConnection, NULL) != S_OK)
						return E_FAIL;
					insertSession.Close();
					
					// Get the new session id
					if (sessionData.OpenRowset(m_dataConnection, NULL) != S_OK)
						return E_FAIL;
					
					if (sessionData.MoveFirst() != S_OK)
						return E_FAIL;
					sessionData.Close();
				}
				// Convert the sessionID to a BSTR
				LPOLESTR lpwGuidStr;
				StringFromCLSID(sessionData.m_guidSessionID, &lpwGuidStr);
				
				// Set the output parameters
				*bstrSessionID = SysAllocString(lpwGuidStr);
				*lUserID = loginUser.m_lUserID;
				
				// Free the wide guid string
				CoTaskMemFree(lpwGuidStr);
				return S_OK;
		}}
		// Set to invalid parameters
		*lUserID = -1;
		*bstrSessionID = SysAllocString(L"{{INVALID_SESSION_ID}}");
		return S_FALSE;
	}

	[ soap_method ]
	HRESULT GetMessageCount(/*[in]*/ LONG lUserID, /*[in]*/ BSTR bstrSessionID, /*[out]*/ LONG* lMessageCount)
	{
		// Validate the session
		GUID guidSessionID;
		CLSIDFromString(bstrSessionID, &guidSessionID);
		if (!ValidateSession(lUserID, guidSessionID))
			return E_FAIL;

		// Get the message count
		CMessageCount msgCount;
		msgCount.m_lUserID = lUserID;
		if (msgCount.OpenRowset(m_dataConnection, NULL) != S_OK)
			return E_FAIL;
		if (msgCount.MoveFirst() != S_OK)
			return E_FAIL;
		msgCount.Close();

		// Set the out message count
		*lMessageCount = msgCount.m_lMessageCount;
		return S_OK;
	}

	[ soap_method ]
	HRESULT GetUnreadCount(/*[in]*/ LONG lUserID, /*[in]*/ BSTR bstrSessionID, /*[out]*/ LONG* lUnreadCount)
	{
		// Validate the session
		GUID guidSessionID;
		CLSIDFromString(bstrSessionID, &guidSessionID);
		if (!ValidateSession(lUserID, guidSessionID))
			return E_FAIL;

		// Get the unread message count
		CUnreadCount unreadCount;
		unreadCount.m_lUserID = lUserID;
		if (unreadCount.OpenRowset(m_dataConnection, NULL) != S_OK)
			return E_FAIL;
		if (unreadCount.MoveFirst() != S_OK)
			return E_FAIL;
		unreadCount.Close();

		// Set the out message count
		*lUnreadCount = unreadCount.m_lUnreadCount;
		return S_OK;
	}

	[ soap_method ]
	HRESULT GetMessages(/*[in]*/ LONG lUserID, /*[in]*/ BSTR bstrSessionID, /*[in]*/ LONG lMax, /*[out]*/ LONG *numMsgs, /*[out, size_is(*numMsgs)]*/ MSGDATA **msgData)
	{
		// Validate the session
		GUID guidSessionID;
		CLSIDFromString(bstrSessionID, &guidSessionID);
		if (!ValidateSession(lUserID, guidSessionID))
			return E_FAIL;

		// Check the size parameter
		if (lMax < 0)
			return E_FAIL;

		*numMsgs = 0;

		// Get the message data
		CMessages msgs;
		msgs.m_lUserID = lUserID;

		HRESULT hr = msgs.OpenRowset(m_dataConnection, NULL);
		if (hr != S_OK)
			return E_FAIL;

		hr = msgs.MoveFirst();
		if (hr != S_OK && hr != DB_S_ENDOFROWSET)
			return E_FAIL;
		
		// Allocate the array
		*msgData =(MSGDATA*) GetMemMgr()->Allocate(sizeof(MSGDATA)*(lMax));
		for (int i = 0; i < lMax && hr == S_OK; i++, (*numMsgs)++)
		{
			// Copy the data into the struct
			(*msgData)[i].m_bstrFrom = SysAllocString(msgs.m_wszFrom);
			(*msgData)[i].m_DateSent = msgs.m_DateSent;
			(*msgData)[i].m_bstrSubject = SysAllocString(msgs.m_wszSubject);
			(*msgData)[i].m_lMessageID = msgs.m_lMessageID;
			(*msgData)[i].m_bMarkedRead = msgs.m_bMarkedRead;
			// Get the next message
			hr = msgs.MoveNext();
		}
		msgs.Close();
		return S_OK;
	}

	[ soap_method ]
	HRESULT GetLaunchURL(/*[in]*/ LONG lUserID, /*[in]*/ BSTR bstrSessionID, /*[in]*/ LONG lMessageID,  /*[out]*/ BSTR* bstrURL)
	{
		// Return the url to launch given the user id, session id, and message id
		CStringA strURL;
		strURL.Format("http://localhost/mantaweb/login.srf?uid=%d&sid=%S&msgid=%d", lUserID, bstrSessionID, lMessageID);
		*bstrURL = strURL.AllocSysString();
		return S_OK;
	}
	
}; // class CMailService

// SessionSettings.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once


inline CStringA ToCStringA(LPCWSTR wsz) throw()
{
	USES_CONVERSION;
	return wsz ? W2CA(wsz) : "";
}

inline CStringA ToCStringA(const VARIANT& v) throw()
{
	CComVariant var(v);
	return (SUCCEEDED(var.ChangeType(VT_BSTR))) ? ToCStringA(var.bstrVal) : "";
}

inline CStringA ToCStringA(const VARIANT* pv) throw()
{
	return pv ? ToCStringA(*pv) : "";
}

inline CStringA ToCStringA(LONG l) throw()
{
	CStringA str;
	str.Format("%ld", l);
	return str;
}


typedef DWORD HTTP_STATUS_CODE;		// 200 (OK), etc.
typedef HTTP_CODE ATLS_STATUS_CODE;		// HTTP_SUCCESS, etc.
typedef DWORD ATLS_STATUS_SUBCODE;	// SUBERR_NO_PROCESS, etc.


inline HTTP_STATUS_CODE ValidateHttpStatusCode(HTTP_STATUS_CODE code) throw()
{
	// Note that we allow zero for HTTP_SUCCESS
	ATLASSERT((code == 0) || (code >= 200 && code < 207) ||  (code >= 300 && code < 308) || (code >= 400 && code < 418) || (code >= 500 && code < 506));
	return code;
}


template <typename THandler>
class CSessionRequestHandler : 
public CRequestHandlerT<THandler>
{
public:
	// Create a new session, add the session ID to the response as a cookie
	HRESULT NewSession(ISessionStateService* pSessionService, ISession** ppSession)
	{
		CHAR szID[64 + 1];
		*szID = 0;
		DWORD dwCharacters = (sizeof(szID)/sizeof(szID[0])) - 1;

		HRESULT hr = pSessionService->CreateNewSession( szID, &dwCharacters, ppSession );

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

	HRESULT TerminateSession(ISessionStateService* pSessionService)
	{
		ATLASSERT(pSessionService);
		HRESULT hr = E_FAIL;
		CStringA szID;
		m_HttpRequest.Cookies(SESSION_COOKIE_NAME).GetValue(szID);
		
		if (szID.GetLength())
		{
			hr = pSessionService->CloseSession( szID );
		}

		return hr;
	}

	ATLS_STATUS_CODE ServerError(HTTP_STATUS_CODE dwStatus = 500, ATLS_STATUS_SUBCODE dwSubCode = SUBERR_NONE)
	{
		// Only call with server error status codes
		// This function might be useful at other times
		// but your code will be harder to understand
		ATLASSERT(dwStatus >= 500 && dwStatus < 600);
		return SetErrorCode(dwStatus, dwSubCode);
	}

	ATLS_STATUS_CODE SetErrorCode(HTTP_STATUS_CODE dwStatus = 500, ATLS_STATUS_SUBCODE dwSubCode = SUBERR_NONE)
	{
		m_HttpResponse.ClearResponse();
		PreventClientResponseCaching();
		return SetStatusCode(dwStatus, dwSubCode);
	}

	ATLS_STATUS_CODE NoProcess(HTTP_STATUS_CODE dwStatus = 200)
	{
		return SetStatusCode(dwStatus, SUBERR_NO_PROCESS);
	}

	ATLS_STATUS_CODE SetStatusCode(HTTP_STATUS_CODE dwStatus = 200, ATLS_STATUS_SUBCODE dwSubCode = SUBERR_NONE)
	{
		ValidateHttpStatusCode(dwStatus);
		m_HttpResponse.SetStatusCode(dwStatus ? dwStatus : 200); // Convert zero to 200
		return HTTP_ERROR(dwStatus, dwSubCode);
	}

	bool PreventClientResponseCaching() throw()
	{
		bool bSuccess = false;
		m_HttpResponse.SetCacheControl("no-cache");
		{
			if (m_HttpResponse.SetExpires(0))
				bSuccess = true;
		}
		return bSuccess;
	}
};


class CSessionSettingsHandler : public CSessionRequestHandler<CSessionSettingsHandler>
{
public:
	HTTP_CODE ValidateAndExchange()
	{
		m_HttpResponse.SetContentType("text/html");

		// Get the ISessionStateService from the ISAPI extension
		HRESULT hr = m_spServiceProvider->QueryService(__uuidof(ISessionStateService), &stateService );

		hr = EnsureGetSession( stateService, &session );
		if (FAILED(hr))
			return ServerError(501);

		const CHttpRequestParams& formFields = m_HttpRequest.GetFormVars();

		CHttpRequest::HTTP_METHOD m = m_HttpRequest.GetMethod();
		if ( m == CHttpRequest::HTTP_METHOD_GET )
		{
			CComVariant var;
			hr = session->GetVariable("res", &var);

			CStringA strVar;
			strVar = ToCStringA(var);

			if (SUCCEEDED(hr) && strVar.GetLength() > 0)
			{
				setHighCheck = strVar.CompareNoCase("high") == 0;
				setMedCheck = strVar.CompareNoCase("med") == 0;
				setLowCheck = strVar.CompareNoCase("low") == 0;
			}
			else
			{
				setHighCheck = false;
				setMedCheck = false;
				setLowCheck = false;
			}

			var.Clear();

			hr = session->GetVariable("scale", &var);
			strVar = ToCStringA(var);

			if (SUCCEEDED(hr) && strVar.GetLength() > 0)
			{
				setScaleYesCheck = strVar.CompareNoCase("yes") == 0;
				setScaleNoCheck = strVar.CompareNoCase("no") == 0;
			}
			else
			{
				setScaleYesCheck = false;
				setScaleNoCheck = false;
			}

			return HTTP_SUCCESS;
		}


		LPCSTR res = formFields.Lookup("res");
		if (FAILED(session->SetVariable("res", CComVariant(res) )))
			return ServerError();

		LPCSTR scale = formFields.Lookup("scale");
		if (FAILED(session->SetVariable("scale", CComVariant(scale) )))
			return ServerError();

		m_HttpResponse.Redirect("gallery.srf");

		return HTTP_SUCCESS;
	}
 
	HTTP_CODE OnHighCheck()
	{
		if (setHighCheck)
			m_HttpResponse << "checked";

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnMedCheck()
	{
		if (setMedCheck)
			m_HttpResponse << "checked";

		return HTTP_SUCCESS;
	}
	HTTP_CODE OnLowCheck()
	{
		if (setLowCheck)
			m_HttpResponse << "checked";

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnScaleYes()
	{
		if (setScaleYesCheck)
			m_HttpResponse << "checked";

		return HTTP_SUCCESS;
	}

	HTTP_CODE OnScaleNo()
	{
		if (setScaleNoCheck)
			m_HttpResponse << "checked";

		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CSessionSettingsHandler)
		REPLACEMENT_METHOD_ENTRY("highcheck", OnHighCheck)
		REPLACEMENT_METHOD_ENTRY("medcheck", OnMedCheck)
		REPLACEMENT_METHOD_ENTRY("lowcheck", OnLowCheck)
		REPLACEMENT_METHOD_ENTRY("scaleYes", OnScaleYes)
		REPLACEMENT_METHOD_ENTRY("scaleNo", OnScaleNo)
	END_REPLACEMENT_METHOD_MAP()

private:
	// Session service support
	CComPtr<ISessionStateService> stateService;
	CComPtr<ISession> session;
	
	bool setHighCheck, setMedCheck, setLowCheck;
	bool setScaleNoCheck, setScaleYesCheck;
}; // class CSessionSettingsHandler



class CSessionSettingsMainHandler : public CSessionRequestHandler<CSessionSettingsMainHandler>
{
public:
	HTTP_CODE ValidateAndExchange()
	{
		// TODO: Put all initialization and validation code here
		
		m_HttpResponse.SetContentType("text/html");

		// Get the ISessionStateService from the ISAPI extension
		HRESULT hr = m_spServiceProvider->QueryService( __uuidof(ISessionStateService), &stateService );
		if (FAILED(hr))
			return ServerError();

		hr = EnsureGetSession(stateService, &session);
		if (FAILED(hr))
			return ServerError();

		CComVariant var;
		hr = session->GetVariable("res", &var);

		CStringA strVar;
		strVar = ToCStringA(var);

		if (strVar.GetLength() > 0)
		{
			resHigh = strVar.CompareNoCase("high") == 0;
			resMed = strVar.CompareNoCase("med") == 0;
			resLow = strVar.CompareNoCase("low") == 0;
		}
		else
			resHigh = resMed = resLow = false;

		hr = session->GetVariable("scale", &var);
		strVar = ToCStringA(var);

		if (strVar.GetLength() > 0)
		{
			scaleYes = strVar.CompareNoCase("yes") == 0;
			scaleNo = strVar.CompareNoCase("no") == 0;
		}
		else
			resHigh = resMed = resLow = false;

		return HTTP_SUCCESS;
	}
 
	HTTP_CODE OnImage(void)
	{
		CStringA scaleStr;

		if (scaleYes)
			scaleStr = "width=\"480\" height=\"360\"";
		else
			scaleStr = "";

		if (resHigh)
		{
			m_HttpResponse << "<img src=\"cat_high.jpg\"" << scaleStr << ">";
			m_HttpResponse << "<br>high resolution";
		}
		else if (resMed)
		{
			m_HttpResponse << "<img src=\"cat_med.jpg\"" << scaleStr << ">";
			m_HttpResponse << "<br>medium resolution";
		}
		else
		{
			m_HttpResponse << "<img src=\"cat_low.jpg\"" << scaleStr << ">";
			if (resLow == false)
				m_HttpResponse << "<br>(no settings specified) using low resolution";
			else
				m_HttpResponse << "<br>low resolution";
		}

		if (scaleYes)
			m_HttpResponse << ", scaled";
		else
			m_HttpResponse << ", actual size";

		return HTTP_SUCCESS;
	}

	BEGIN_REPLACEMENT_METHOD_MAP(CSessionSettingsMainHandler)
		REPLACEMENT_METHOD_ENTRY("image", OnImage)
	END_REPLACEMENT_METHOD_MAP()

private:
	// Session service support
	CComPtr<ISessionStateService> stateService;
	CComPtr<ISession> session;
	
	bool resHigh, resMed, resLow;
	bool scaleYes, scaleNo;

}; // class CSessionSettingsMainHandler


class CSessionSettingsResetHandler : public CSessionRequestHandler<CSessionSettingsResetHandler>
{
public:
	HTTP_CODE ValidateAndExchange()
	{
		m_HttpResponse.SetContentType("text/html");

		// Get the ISessionStateService from the ISAPI extension
		HRESULT hr = m_spServiceProvider->QueryService(__uuidof(ISessionStateService), &stateService );
		if (FAILED(hr))
			return ServerError();

		if (FAILED(TerminateSession( stateService )))
		{
			ServerError(501);
		}

		return HTTP_SUCCESS;
	}
 
private:
	// Session service support
	CComPtr<ISessionStateService> stateService;
	CComPtr<ISession> session;
	
	bool resHigh, resMed, resLow;

}; // class CSessionSettingsResetHandler


BEGIN_HANDLER_MAP()
	HANDLER_ENTRY("Intro", CSessionSettingsHandler)
	HANDLER_ENTRY("Main", CSessionSettingsMainHandler)
	HANDLER_ENTRY("Reset", CSessionSettingsResetHandler)
END_HANDLER_MAP()


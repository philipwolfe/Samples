// VCUE_RequestHandler.h
// (c) 2000 Microsoft Corporation
//
//////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(_VCUE_REQUESTHANDLER_H___5A542442_2504_4D4D_A667_38B06EA6CFA6___INCLUDED_)
#define _VCUE_REQUESTHANDLER_H___5A542442_2504_4D4D_A667_38B06EA6CFA6___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include <atlsession.h>

namespace VCUE
{

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
	class CCustomRequestHandler : 
		public CRequestHandlerT<THandler>
	{
	public:

		// QueryService template overloads

		// Remove need for void** cast
		template <typename Interface>
		HRESULT QueryService(REFGUID guidService, REFIID riid, Interface** ppInterface)
		{
			return m_spServiceProvider->QueryService(
				guidService,
				__uuidof(Interface),
				reinterpret_cast<void**>(ppInterface));
		}

		// Use __uuidof to get interface ID
		template <typename Interface>
		HRESULT QueryService(REFGUID guidService, Interface** ppInterface)
		{
			return m_spServiceProvider->QueryService(
				guidService,
				__uuidof(Interface),
				reinterpret_cast<void**>(ppInterface));
		}

		// Use __uuidof to get interface ID and service ID
		template <typename Interface>
		HRESULT QueryService(Interface** ppInterface)
		{
			return m_spServiceProvider->QueryService(
				__uuidof(Interface),
				__uuidof(Interface),
				reinterpret_cast<void**>(ppInterface));
		}

		// Simplify access to the browser capabilities for the current request
		HRESULT GetBrowserCapabilities(IBrowserCaps** ppBrowserCapabilities)
		{
			CComPtr<IBrowserCapsSvc> spBrowserCapabilitiesService;
			HRESULT hr = QueryService(&spBrowserCapabilitiesService);
			if (SUCCEEDED(hr))
				hr = spBrowserCapabilitiesService->GetCaps(m_spServerContext, ppBrowserCapabilities);

			return hr;
		}

		// Create a new session, add the session ID to the response as a cookie
		HRESULT NewSession(ISessionStateService* pSessionService, ISession** ppSession)
		{
			CHAR szID[64 + 1];
			szID[0] = 0;
			DWORD dwCharacters = (sizeof(szID)/sizeof(szID[0])) - 1;

			HRESULT hr = pSessionService->CreateNewSession(szID, &dwCharacters, ppSession);

			if (SUCCEEDED(hr)){
				CSessionCookie theSessionCookie(szID);
				m_HttpResponse.AppendCookie(&theSessionCookie);
			}

			return hr;
		}

		// Get session pointer based on ID in cookie
		HRESULT GetSession(ISessionStateService* pSessionService, ISession** ppSession)
		{
			HRESULT hr = E_FAIL;
			CStringA szID;
			m_HttpRequest.Cookies(SESSION_COOKIE_NAME).GetValue(szID);
			
			if (szID.GetLength())
			{
				hr = pSessionService->GetSession(szID, ppSession);
			}

			return hr;
		}

		// Try to get the session, if that fails, create a new one
		HRESULT EnsureGetSession(ISessionStateService* pSessionService, ISession** ppSession)
		{
			HRESULT hr = GetSession(pSessionService, ppSession);
			
			if (FAILED(hr))
				hr = NewSession(pSessionService, ppSession);

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

		ATLS_STATUS_CODE ClientError(HTTP_STATUS_CODE dwStatus = 400, ATLS_STATUS_SUBCODE dwSubCode = SUBERR_NONE)
		{
			// Only call with client error status codes
			// This function might be useful at other times
			// but your code will be harder to understand
			ATLASSERT(dwStatus >= 400 && dwStatus < 500);
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

	template <typename THandler>
	class CTraceRequestHandler : 
		public CRequestHandlerT<THandler>
	{
	private:
		typedef CRequestHandlerT<THandler> VCUEBase;

	public:
		static void UninitRequestHandlerClass() throw()
		{
			ATLTRACE("UninitRequestHandlerClass\n");
			return VCUEBase::UninitRequestHandlerClass();
		}

		HTTP_CODE InitializeHandler(
			AtlServerRequest *pRequestInfo, 
			IServiceProvider *pProvider) throw()
		{
			ATLTRACE("InitializeHandler\n");
			return VCUEBase::InitializeHandler(pRequestInfo, pProvider);
		}
		
		HTTP_CODE InitializeChild(
			AtlServerRequest *pRequestInfo, 
			IServiceProvider *pProvider, 
			IHttpRequestLookup *pRequestLookup) throw()
		{
			ATLTRACE("InitializeChild\n");
			return VCUEBase::InitializeChild(pRequestInfo, pProvider, pRequestLookup);
		}
		
		
		HTTP_CODE Initialize(
			AtlServerRequest *pRequestInfo, 
			IHttpServerContext *pSafeSrvCtx=NULL) throw()
		{
			ATLTRACE("Initialize\n");
			return VCUEBase::Initialize(pRequestInfo, pSafeSrvCtx);
		}
		

		HTTP_CODE HandleRequest(
			AtlServerRequest* pRequestInfo,
			IServiceProvider* pServiceProvider) throw()
		{
			ATLTRACE("HandleRequest\n");
			return VCUEBase::HandleRequest(pRequestInfo, pServiceProvider);
		}



	};


} // namespace VCUE


#endif // !defined(_VCUE_REQUESTHANDLER_H___5A542442_2504_4D4D_A667_38B06EA6CFA6___INCLUDED_)

// hotswap.cpp : Defines the entry point for the DLL application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
// For custom assert and trace handling with WebDbg.exe
#ifdef _DEBUG
CDebugReportHook g_ReportHook;
#endif

__declspec(selectany) CDefaultAuth _Authority;
#ifndef ATL_ADMIN_AUTHGRP
	#define ATL_ADMIN_AUTHGRP Sids::Admins()
#endif


[ module(name="hotswap", type="dll") ];
[ emitidl(restricted) ];

// This interface is implemented by our extension class and provided to 
// request handlers via IServiceProvider. A request handler can use this 
// interface to stop and resume request handling by the extension.
__interface __declspec(uuid("D11BEC99-9280-430d-94D1-DEBF555E3272"))
IHotSwapExtension : public IUnknown
{
	virtual HRESULT StopRequests() = 0;
	virtual HRESULT ResumeRequests() = 0;
	virtual HRESULT IsRunning(BOOL *pbRunning) = 0;
	virtual HRESULT FlushCaches() = 0;
};

// **********************WARNING************************************
// **********************WARNING************************************
// **********************WARNING************************************
// **********************WARNING************************************
// **********************WARNING************************************
// **********************WARNING************************************
// **********************WARNING************************************
// This is the request handler for HotSwapAdmin.srf. Please note that
// this is just a sample of how you could use a request handler to block
// requests while files are copied. The request handler coded as it is now,
// could really pose a security risk to your site because a caller 
// could block request handling on your site indefinitely. You must 
// implement your own security for your request handler so that random 
// callers can't access this code.
[request_handler("admin")]
class CAdmin
{
public:
	CComPtr<IHotSwapExtension> m_spHSE;
	CString m_strErrMessage;

	HTTP_CODE ValidateAndExchange()
	{
		m_spServiceProvider->QueryService(__uuidof(IHotSwapExtension), 
						__uuidof(IHotSwapExtension), (void **) &m_spHSE);

		if (!m_spHSE)
		{
			// No hotswap service. Return message and we're done.
			m_strErrMessage = "<h1>Hot swap capability not supported!</h1>";
		}

		HRESULT	hcErr = HTTP_FAIL;
		ATLTRY(hcErr = _Authority.IsAuthorized(&m_RequestInfo, ATL_ADMIN_AUTHGRP));

		if( hcErr != S_OK )
		{
			m_HttpResponse	<<	"You have to be an Administrator to run the hotswap sample!";
			return hcErr;
		}



		//
		LPCSTR szCommand = m_HttpRequest.FormVars.Lookup("command");
		if (szCommand)
		{
			if (!stricmp(szCommand, "start"))
			{
				m_spHSE->ResumeRequests();
			}
			else if (!strcmp(szCommand, "swap"))
			{
				LPCSTR szReplaceFile = NULL;
				LPCSTR szWithFile = NULL;
				DWORD dwErr = VALIDATION_E_FAIL;
				
				// find out which file needs to be replaced
				if (VALIDATION_S_OK != m_HttpRequest.FormVars.Validate(
					"replace_file", &szReplaceFile, 1, MAX_PATH))
					m_strErrMessage = _T("Error: replace_file parameter is not valid");
				else if (VALIDATION_S_OK != m_HttpRequest.FormVars.Validate(
					"with_file", &szWithFile, 1, MAX_PATH))
					m_strErrMessage = _T("Error: with_file parameter is not valid");
				else
				{
					// block requests
					if (S_OK == m_spHSE->StopRequests())
					{
						// flush the DLL cache
						if (S_OK == m_spHSE->FlushCaches())
						{
							// It's all good so far, replace the file
							CA2CT szr(szReplaceFile);
							CA2CT szw(szWithFile);

							if (!CopyFile(szw, szr, FALSE))
							{
								DWORD dwLastErr = GetLastError();
								m_strErrMessage.Format(_T("Error: replacing file %s with %s failed. Last error was 0x%0.8x."),
										static_cast<LPCTSTR>( szr ), static_cast<LPCTSTR>( szw ), dwLastErr);
							}
							else
								m_strErrMessage.Format(_T("Success: replaced file %s with file %s"),
											static_cast<LPCTSTR>( szr ), static_cast<LPCTSTR>( szw ));
							
						}
					}
				}
				// resume requests
				m_spHSE->ResumeRequests();
			}
		}

		return HTTP_SUCCESS;
	}

	[tag_name("IsRunning")]
	HTTP_CODE OnIsRunning()
	{
		BOOL bRunning;
		m_spHSE->IsRunning(&bRunning);
		return bRunning ? HTTP_SUCCESS : HTTP_S_FALSE;
	}

	[tag_name("ErrorMessage")]
	HTTP_CODE OnGetErrorMessage()
	{
		m_HttpResponse << m_strErrMessage;
		return HTTP_SUCCESS;
	}
};

class CSwapExtension : 
	public CIsapiExtension<>,
	public IHotSwapExtension
{
	typedef CIsapiExtension<> baseClass;
	HANDLE m_hGoEvent;
	HANDLE m_hDoneEvent;
	LONG m_lActiveThreads;
	BOOL m_bRunning;

public:

	// IHotSwapExtension methods

	// Sets the event that will block all threads in DispatchStencilCall
	// then waits for all of the currently active threads to complete their
	// processing.
	HRESULT StopRequests()
	{
		ResetEvent(m_hGoEvent);

		while (InterlockedCompareExchange(&m_lActiveThreads, 1, 1) > 1)
		{
			WaitForSingleObject(m_hDoneEvent, INFINITE);
			ResetEvent(m_hDoneEvent);
		}
		m_bRunning = FALSE;
		return S_OK;
	}

	// resumes request processing.
	HRESULT ResumeRequests()
	{
		m_bRunning = TRUE;
		SetEvent(m_hGoEvent);
		return S_OK;
	}

	HRESULT IsRunning(BOOL *pbRunning)
	{
		*pbRunning = m_bRunning;
		return S_OK;
	}

	// This is the function that actually unloads the caches.
	// We call m_DllCache.Flush twice on purpose because of the
	// mechanics of the DLL cache.
	HRESULT FlushCaches()
	{
		m_StencilCache.RemoveAllStencils();
	    m_DllCache.Flush();
		m_DllCache.Flush();
		return S_OK;
	}

	// Base class overrides

	// DispatchStencilCall is the function called by threads in the ISAPI extension's
	// thread pool right after they de-queue a request from the pool. Basically, it's
	// the main entry point for all ATLS requests. We will block here on m_hGoEvent until
	// the copy of the files is done. One of the threads in the pool is currently working
	// on the swapping, and will reset the event when it's done.
	BOOL DispatchStencilCall(AtlServerRequest *pRequestInfo) throw()
	{
		// While m_hGoEvent is non-signaled, no requests will be dispatched!
		WaitForSingleObject(m_hGoEvent, INFINITE);
		InterlockedIncrement(&m_lActiveThreads);
		BOOL bRet = baseClass::DispatchStencilCall(pRequestInfo);
		if (InterlockedDecrement(&m_lActiveThreads)==1)
			SetEvent(m_hDoneEvent);
		return bRet;
	}

	// This is the entry point that IIS calls right after it 
	// does a LoadLibrary on our DLL. This is always a good place
	// to do extension specific initializations.
	BOOL GetExtensionVersion(HSE_VERSION_INFO* pVer)
	{
		m_hGoEvent = CreateEvent(NULL, TRUE, TRUE, NULL);
		m_hDoneEvent = CreateEvent(NULL, TRUE, TRUE, NULL);
		m_lActiveThreads = 0;
		m_bRunning = TRUE;

		if (!baseClass::GetExtensionVersion(pVer))
			return FALSE;

		return TRUE;
	}

	// This is the last function IIS calls before it unloads 
	// us. Always a good place to do extension specific un-initialization.
	BOOL TerminateExtension(DWORD dwFlags)
	{
		CloseHandle(m_hGoEvent);
		CloseHandle(m_hDoneEvent);
		return baseClass::TerminateExtension(dwFlags);
	}


	// Override this function to expose the HotSwap service that is implemented by
	// this class (see IHotSwapExtension interface above).
	HRESULT STDMETHODCALLTYPE QueryService(REFGUID guidService,	REFIID riid,
		void **ppvObject)
	{
		
		HRESULT hr = baseClass::QueryService(guidService, riid, ppvObject);
		if (hr == E_POINTER || hr == E_NOINTERFACE)
		{
			if (InlineIsEqualGUID(guidService, __uuidof(IHotSwapExtension)))
				hr =  QueryInterface(riid, ppvObject);
		}
		return hr;
	}

	// The rest of this class is just standard IUnknown requirements
	HRESULT STDMETHODCALLTYPE QueryInterface(REFIID riid, void **ppv) throw()
	{
		if (!ppv)
			return E_POINTER;

		if (InlineIsEqualGUID(riid, __uuidof(IHotSwapExtension)))
		{
			*ppv = static_cast<IUnknown*>(static_cast<IHotSwapExtension*>(this));
			AddRef();
			return S_OK;
		}
		return baseClass::QueryInterface(riid, ppv);
	}

	ULONG STDMETHODCALLTYPE AddRef()
	{
		return baseClass::AddRef();
	}

	ULONG STDMETHODCALLTYPE Release()
	{
		return baseClass::Release();
	}

};

// the one and only isapi extension handler!
CSwapExtension theExtension;


// Delegate ISAPI exports to theExtension
//
extern "C" DWORD WINAPI HttpExtensionProc(LPEXTENSION_CONTROL_BLOCK lpECB)
{
	return theExtension.HttpExtensionProc(lpECB);
}

extern "C" BOOL WINAPI GetExtensionVersion(HSE_VERSION_INFO* pVer)
{
	return theExtension.GetExtensionVersion(pVer);
}

extern "C" BOOL WINAPI TerminateExtension(DWORD dwFlags)
{
	return theExtension.TerminateExtension(dwFlags);
}

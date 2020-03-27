// File: MyIsapiextension.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include <atlisapi.h>
#include <atldbcli.h>
#include <atlsession.h>

#define _DATASOURCE_CACHE 1
#define _BROWSERCAPS 2

// Uncomment the following line to use database-backed session state
// #define SESSION_DATABASE

// CMyIsapiExtensionWorker - custom thread worker class
// for datasource cache

class CMyIsapiExtensionWorker : public CIsapiWorker
{
	// per thread datasource cache
	typedef CDataSourceCache<> ds_cache_type;
	CComObjectGlobal<ds_cache_type> m_dsCache;

	// per thread browser capabilities support
	CComObjectGlobal<CBrowserCapsSvc> m_BrowserCaps;		
	
public:

	CMyIsapiExtensionWorker()
	{
	}
	
	~CMyIsapiExtensionWorker()
	{
	}
	
    virtual BOOL Initialize(void *pvParam)
	{
		if (!CIsapiWorker::Initialize(pvParam))
            return FALSE;

		if (S_OK != m_BrowserCaps.Initialize(_pModule->GetModuleInstance()))
			return FALSE;

        return TRUE;
	}

	virtual BOOL GetWorkerData(DWORD dwParam, void **ppvData)
	{
		if (dwParam == _DATASOURCE_CACHE && ppvData)
		{
			*ppvData = (void *)&m_dsCache;
			m_dsCache.AddRef();
			return TRUE;
		}
		
		if (dwParam == _BROWSERCAPS && ppvData)
		{
			*ppvData = (void *)&m_BrowserCaps;
			m_BrowserCaps.AddRef();
			return TRUE;
		}
		return FALSE;
	}
}; // class CMyIsapiExtensionWorker

// CMyIsapiExtension - the ISAPI extension class
template <class ThreadPoolClass=CThreadPool<CMyIsapiExtensionWorker>, 
	class CStatClass=CNoRequestStats, 
	class HttpUserErrorTextProvider=CDefaultErrorProvider, 
	class WorkerThreadTraits=DefaultThreadTraits >
class CMyIsapiExtension : 
	public CIsapiExtension<ThreadPoolClass, 
		CStatClass, 
		HttpUserErrorTextProvider, 
		WorkerThreadTraits>
{

protected:

	typedef CIsapiExtension<ThreadPoolClass, CStatClass, HttpUserErrorTextProvider, 
		WorkerThreadTraits> baseISAPI;
	typedef CWorkerThread<WorkerThreadTraits> WorkerThreadClass;

	// session state support
	
#ifdef SESSION_DATABASE
	typedef CSessionStateService<WorkerThreadClass, CDBSessionServiceImpl> sessionSvcType;
#else
	typedef CSessionStateService<WorkerThreadClass, CMemSessionServiceImpl> sessionSvcType;
#endif

	CComObjectGlobal<sessionSvcType> m_SessionStateSvc;

public:

	BOOL GetExtensionVersion(HSE_VERSION_INFO* pVer)
	{
		if (!baseISAPI::GetExtensionVersion(pVer))
		{
			return FALSE;
		}

		if (GetCriticalIsapiError() != 0)
		{
			return TRUE;
		}

#ifdef SESSION_DATABASE
		#pragma message(__FILE__LINE__ "warning VCUESample001 : Change pszConnection to match the database server you have configured to provide session state.")

		const char pszConnection[] = 
			"Provider=SQLOLEDB.1;"
			"Persist Security Info=True;"
			"Password=YourPassword;"
			"User ID=YourUserID;"
			"Initial Catalog=ATLServer;"
			"Data Source=YourServer"
			;
		if (S_OK !=m_SessionStateService.Initialize(&m_WorkerThread,static_cast<IServiceProvider*>this,
										ATL_SESSION_TIMEOUT,
										const_cast<void*>(static_cast<const void*>(pszConnection))))
		{
			TerminateExtension(0);
			return SetCriticalIsapiError();
		}
#else
		if (S_OK != m_SessionStateSvc.Initialize(&m_WorkerThread,  static_cast<IServiceProvider*>(this)))
		{
			TerminateExtension(0);
			return SetCriticalIsapiError();
		}
#endif
		return TRUE;
	}

	BOOL TerminateExtension(DWORD dwFlags)
	{
		m_SessionStateSvc.Shutdown();
		BOOL bRet = baseISAPI::TerminateExtension(dwFlags);
		return bRet;
	}
	
	HRESULT STDMETHODCALLTYPE QueryService(REFGUID guidService, 
			REFIID riid, void** ppvObject)
	{
		if (InlineIsEqualGUID(guidService, __uuidof(ISessionStateService)))
			return m_SessionStateSvc.QueryInterface(riid, ppvObject);
		if (InlineIsEqualGUID(guidService, __uuidof(IDataSourceCache)))
		{
			CIsapiWorker *pWorker = GetThreadWorker();
			if (pWorker)
			{
				CDataSourceCache<> *pCache = NULL;
				if (pWorker->GetWorkerData(_DATASOURCE_CACHE, (void **)&pCache))
				{
					*ppvObject = static_cast<IDataSourceCache *>(pCache);
					return S_OK;
				}
			}
		}
		if (InlineIsEqualGUID(guidService, __uuidof(IBrowserCapsSvc)))
		{
			CIsapiWorker *pWorker = GetThreadWorker();
			if (pWorker)
			{
				CBrowserCapsSvc *pBrowserCaps = NULL;
				if (pWorker->GetWorkerData(_BROWSERCAPS, (void **)&pBrowserCaps))
				{
					*ppvObject = static_cast<IBrowserCapsSvc *>(pBrowserCaps);
					return S_OK;
				}
			}
		}
		return baseISAPI::QueryService(guidService, riid, ppvObject);
	}

	virtual void OnThreadTerminate(DWORD /*dwThreadId*/)
	{
	}
}; // class CMyIsapiExtension
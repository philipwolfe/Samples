// File: OnlineAddressBookWSextension.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include <atlisapi.h>
#include <atlsession.h>

#define _DATASOURCE_CACHE 1
// COnlineAddressBookWSExtensionWorker - custom thread worker class
// for per-thread services

class CBlobCachePerfStatClass : public CPerfStatClass
{
public:
	HRESULT Initialize(CStringW strName=L"BlobCache",bool AppendProcessID=true)
    {
		if(AppendProcessID)
			strName.AppendFormat(L" in process %d", ::GetCurrentProcessId());
		return __super::Initialize(strName.GetBuffer());
	}
};

class CFileCachePerfStatClass : public CPerfStatClass
{
public:
	HRESULT Initialize(CStringW strName=L"FileCache",bool AppendProcessID=true)
    {
		if(AppendProcessID)
			strName.AppendFormat(L" in process %d", ::GetCurrentProcessId());
		return __super::Initialize(strName.GetBuffer());
	}
};


class COnlineAddressBookWSExtensionWorker : public CIsapiWorker
{
	// per thread datasource cache
	typedef CDataSourceCache<> ds_cache_type;
	CComObjectGlobal<ds_cache_type> m_dsCache;
	
public:

	COnlineAddressBookWSExtensionWorker()
	{
	}
	
	~COnlineAddressBookWSExtensionWorker()
	{
	}
	

	virtual BOOL GetWorkerData(DWORD dwParam, void **ppvData)
	{
		if (dwParam == _DATASOURCE_CACHE && ppvData)
		{
			*ppvData = (void *)&m_dsCache;
			m_dsCache.AddRef();
			return TRUE;
		}
		return FALSE;
	}
}; // class COnlineAddressBookWSExtensionWorker

// COnlineAddressBookWSExtension - the ISAPI extension class
template <class ThreadPoolClass=CThreadPool<COnlineAddressBookWSExtensionWorker>, 
	class CStatClass=CNoRequestStats, 
	class HttpUserErrorTextProvider=CDefaultErrorProvider, 
	class WorkerThreadTraits=DefaultThreadTraits >
class COnlineAddressBookWSExtension : 
	public CIsapiExtension<ThreadPoolClass, 
		CStatClass, 
		HttpUserErrorTextProvider, 
		WorkerThreadTraits>
{

protected:

	typedef CIsapiExtension<ThreadPoolClass, CStatClass, HttpUserErrorTextProvider, 
		WorkerThreadTraits> baseISAPI;
	typedef CWorkerThread<WorkerThreadTraits> WorkerThreadClass;

	// blob cache support
	CBlobCache<WorkerThreadClass, CBlobCachePerfStatClass > m_BlobCache;

	// file cache support
	CFileCache<WorkerThreadClass, CFileCachePerfStatClass > m_FileCache;

	// session state support
	typedef CSessionStateService<WorkerThreadClass, CMemSessionServiceImpl> sessionSvcType;
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
		
		if (S_OK != m_SessionStateSvc.Initialize(&m_WorkerThread,  static_cast<IServiceProvider*>(this)))
		{
			ATLTRACE("Session service failed to initialize\n");
			TerminateExtension(0);
			return SetCriticalIsapiError(IDS_ATLSRV_CRITICAL_SESSIONSTATEFAILED);
		}

		if (S_OK != m_BlobCache.Initialize(static_cast<IServiceProvider*>(this), &m_WorkerThread))
		{
			ATLTRACE("Blob cache service failed to initialize\n");
			TerminateExtension(0);
			return SetCriticalIsapiError(IDS_ATLSRV_CRITICAL_BLOBCACHEFAILED);
		}

		if (S_OK != m_FileCache.Initialize(&m_WorkerThread))
		{
			ATLTRACE("File cache service failed to initialize\n");
			TerminateExtension(0);
			return SetCriticalIsapiError(IDS_ATLSRV_CRITICAL_FILECACHEFAILED);
		}
		return TRUE;
	}

	BOOL TerminateExtension(DWORD dwFlags)
	{
		m_BlobCache.Uninitialize();
		m_FileCache.Uninitialize();
		m_SessionStateSvc.Shutdown();
		BOOL bRet = baseISAPI::TerminateExtension(dwFlags);
		return bRet;
	}
	
	HRESULT STDMETHODCALLTYPE QueryService(REFGUID guidService, 
			REFIID riid, void** ppvObject)
	{
		if (InlineIsEqualGUID(guidService, IID_IFileCache))
			return m_FileCache.QueryInterface(riid, ppvObject);
		if (InlineIsEqualGUID(guidService, IID_IMemoryCache))
			return m_BlobCache.QueryInterface(riid, ppvObject);
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
		return baseISAPI::QueryService(guidService, riid, ppvObject);
	}

	virtual void OnThreadTerminate(DWORD /*dwThreadId*/)
	{
	}
}; // class COnlineAddressBookWSExtension
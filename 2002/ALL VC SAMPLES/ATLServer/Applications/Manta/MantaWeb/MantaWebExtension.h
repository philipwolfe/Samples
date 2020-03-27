// MantaWebExtension.h: this file defines the MantaWeb ISAPI extension class and worker class
// This file is wizard generated.
//	(c) 2000 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include <atlisapi.h>
#define _DATASOURCE_CACHE 1



// CMantaWebExtensionWorker - custom thread worker class
// for datasource cache
class CMantaWebExtensionWorker : public CIsapiWorker
{
	typedef CDataSourceCache<> ds_cache_type; // per thread datasource cache
	CComObjectGlobal<ds_cache_type> m_dsCache;
public:
	CMantaWebExtensionWorker()
	{
	}
	
	~CMantaWebExtensionWorker()
	{
	}
	
	virtual BOOL GetWorkerData(DWORD dwParam, void **ppvData)
	{
		if (dwParam == _DATASOURCE_CACHE && ppvData)
		{
			*ppvData = (void *)&m_dsCache;
			return TRUE;
		}
		return FALSE;
	}
}; // class CMantaWebExtensionWorker
		
template <class ThreadPoolClass=CThreadPool<CIsapiWorker>, 
		  class CStatClass=CStdRequestStats, 
		  class HttpUserErrorTextProvider=CDefaultErrorProvider, 
		  class WorkerThreadClass=CWorkerThread<> >
	class CMantaWebExtension : 
	public CIsapiExtension<ThreadPoolClass, 
		CStatClass, 
		HttpUserErrorTextProvider>
{
protected:
	typedef CIsapiExtension<ThreadPoolClass, CStatClass, HttpUserErrorTextProvider> baseISAPI;
	CFileCache<WorkerThreadClass, CStdStatClass > m_FileCache;
public:
	BOOL GetExtensionVersion(HSE_VERSION_INFO* pVer)
	{
		BOOL bRet = baseISAPI::GetExtensionVersion(pVer);
		if (bRet)
		{
			if (S_OK != m_FileCache.Initialize(&m_WorkerThread))
			{	
				TerminateExtension(NULL);
			}
		}
		return bRet;
	}
	BOOL TerminateExtension(DWORD dwFlags)
	{
		BOOL bRet = baseISAPI::TerminateExtension(dwFlags);
		m_FileCache.Uninitialize();
		return bRet;
	}
	
	HRESULT STDMETHODCALLTYPE QueryService(REFGUID guidService, 
			REFIID riid, void** ppvObject)
	{
		if (InlineIsEqualGUID(guidService, IID_IFileCache))
			return m_FileCache.QueryInterface(riid, ppvObject);
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
}; // class CMantaWebExtension
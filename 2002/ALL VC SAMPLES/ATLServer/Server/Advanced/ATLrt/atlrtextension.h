// File: atlrtextension.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "stdafx.h"

#include <atlisapi.h>

#define _DATASOURCE_CACHE	1

// CATLRTExtensionWorker - custom thread worker class
// for datasource cache
class CATLRTExtensionWorker : public CIsapiWorker
{
	// per thread data cache
	typedef CDataSourceCache<>		ds_cache_type;
	CComObjectGlobal<ds_cache_type> m_dsCache;
			
public:

	CATLRTExtensionWorker()
	{
		Trace::TraceMsg("CATLRTExtensionWorker constructor");
	}
	
	~CATLRTExtensionWorker()
	{
		Trace::TraceMsg("CATLRTExtensionWorker destructor");		
	}
	
	virtual BOOL GetWorkerData(DWORD dwParam, void **ppvData)
	{
		ATLASSERT(ppvData);
		
		if (dwParam == _DATASOURCE_CACHE && ppvData)
		{
			*ppvData = (void *)&m_dsCache;
			m_dsCache.AddRef();
			
			return TRUE;
		}
		
		return FALSE;
	}
}; // class CATLRTExtensionWorker

// CatlrtExtension - the ISAPI extension class
template <class ThreadPoolClass=CThreadPool<CATLRTExtensionWorker>, 
	class CStatClass=CStdRequestStats, 
	class HttpUserErrorTextProvider=CDefaultErrorProvider, 
	class WorkerThreadTraits=DefaultThreadTraits >
class CatlrtExtension : 
	public CIsapiExtension<ThreadPoolClass, 
		CStatClass, 
		HttpUserErrorTextProvider, 
		WorkerThreadTraits>
{

protected:

	typedef CIsapiExtension<ThreadPoolClass, CStatClass, HttpUserErrorTextProvider, 
		WorkerThreadTraits> baseISAPI;

	// blob cache support
	CBlobCache<extWorkerType, CStdStatClass > m_BlobCache;

	// file cache support
	CFileCache<extWorkerType, CStdStatClass > m_FileCache;

public:

	BOOL GetExtensionVersion(HSE_VERSION_INFO* pVer)
	{
		if (!baseISAPI::GetExtensionVersion(pVer))
		{
			return FALSE;
		}

		if (S_OK != m_BlobCache.Initialize(static_cast<IServiceProvider*>(this), &m_WorkerThread))
		{
			TerminateExtension(0);
			return FALSE;
		}

		if (S_OK != m_FileCache.Initialize(&m_WorkerThread))
		{
			TerminateExtension(0);
			return FALSE;
		}
		return TRUE;
	}

	BOOL TerminateExtension(DWORD dwFlags)
	{
		BOOL bRet = baseISAPI::TerminateExtension(dwFlags);
		m_BlobCache.Uninitialize();
		m_FileCache.Uninitialize();
		
		return bRet;
	}
	
	HRESULT STDMETHODCALLTYPE QueryService(REFGUID guidService, 
			REFIID riid, void** ppvObject)
	{
		if (InlineIsEqualGUID(guidService, IID_IFileCache))
			return m_FileCache.QueryInterface(riid, ppvObject);
		if (InlineIsEqualGUID(guidService, IID_IMemoryCache))
			return m_BlobCache.QueryInterface(riid, ppvObject);
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

	virtual void OnThreadTerminate(DWORD dwThreadId)
	{
		
	}
}; // class CatlrtExtension
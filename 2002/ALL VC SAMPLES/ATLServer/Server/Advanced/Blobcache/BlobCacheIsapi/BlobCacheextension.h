// File: BlobCacheextension.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include <atlisapi.h>

// CBlobCacheExtension - the ISAPI extension class
template <
	class ThreadPoolClass           =   CThreadPool<CIsapiWorker>, 
	class CStatClass                =   CNoRequestStats, 
	class HttpUserErrorTextProvider =   CDefaultErrorProvider
	>
class CBlobCacheExtension : 
	public CIsapiExtension<ThreadPoolClass, CStatClass, HttpUserErrorTextProvider>
{

protected:

	typedef CIsapiExtension<ThreadPoolClass, CStatClass, HttpUserErrorTextProvider> baseISAPI;

	// blob cache support
	CBlobCache< CWorkerThread<> > m_BlobCache;

	class CMemoryCacheClient :
	    public CComObjectRootEx<CComMultiThreadModel>,
		public IMemoryCacheClient
	{
	public:
		BEGIN_COM_MAP(CMemoryCacheClient)
            COM_INTERFACE_ENTRY(IMemoryCacheClient)
		END_COM_MAP()

		STDMETHODIMP Free(const void *pvData)
		{
			ATLTRACE("Freeing: %s\n", *(LPCSTR*) pvData);
			::HeapFree(::GetProcessHeap(), 0, *(void**)pvData);
			return S_OK;
		}
	};

	CComObjectStackEx<CMemoryCacheClient> m_MCC;

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

		if (S_OK != m_BlobCache.Initialize(static_cast<IServiceProvider*>(this), &m_WorkerThread))
		{
			ATLTRACE("Blob cache service failed to initialize\n");
			TerminateExtension(0);
			return SetCriticalIsapiError(IDS_ATLSRV_CRITICAL_BLOBCACHEFAILED);
		}

		return TRUE;
	}

	BOOL TerminateExtension(DWORD dwFlags)
	{
		m_BlobCache.Uninitialize();

		BOOL bRet = baseISAPI::TerminateExtension(dwFlags);

		return bRet;
	}
	
	HRESULT STDMETHODCALLTYPE QueryService(REFGUID guidService, 
			REFIID riid, void** ppvObject)
	{
		if (InlineIsEqualGUID(guidService, IID_IMemoryCache))
			return m_BlobCache.QueryInterface(riid, ppvObject);

		if (InlineIsEqualGUID(guidService, IID_IMemoryCacheStats))
			return m_BlobCache.QueryInterface(riid, ppvObject);

		if (InlineIsEqualGUID(guidService, IID_IMemoryCacheControl))
			return m_BlobCache.QueryInterface(riid, ppvObject);

		if (InlineIsEqualGUID(guidService, IID_IMemoryCacheClient))
			return m_MCC.QueryInterface(riid, ppvObject);

		return baseISAPI::QueryService(guidService, riid, ppvObject);
	}
}; // class CBlobCacheExtension
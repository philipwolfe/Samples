// File: SessionSettingsextension.h
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

// CSessionSettingsExtension - the ISAPI extension class
template <class ThreadPoolClass=CThreadPool<CIsapiWorker>, 
	class CStatClass=CStdRequestStats, 
	class HttpUserErrorTextProvider=CDefaultErrorProvider, 
	class WorkerThreadClass=CWorkerThread<> >
class CSessionSettingsExtension : 
	public CIsapiExtension<ThreadPoolClass, 
		CStatClass, 
		HttpUserErrorTextProvider>
{

protected:

	typedef CIsapiExtension<ThreadPoolClass, CStatClass, HttpUserErrorTextProvider> baseISAPI;

	// session state support
	typedef CSessionStateService<CWorkerThread<>, CMemSessionServiceImpl> sessionSvcType;
	CComObjectGlobal<sessionSvcType> m_SessionStateSvc;

public:

	BOOL GetExtensionVersion(HSE_VERSION_INFO* pVer)
	{
		if (!baseISAPI::GetExtensionVersion(pVer))
		{
			return FALSE;
		}
		if (S_OK != m_SessionStateSvc.Initialize(&m_WorkerThread,  static_cast<IServiceProvider*>(this)))
		{
			TerminateExtension(0);
			return FALSE;
		}
		return TRUE;
	}

	BOOL TerminateExtension(DWORD dwFlags)
	{
		BOOL bRet = baseISAPI::TerminateExtension(dwFlags);
		m_SessionStateSvc.Shutdown();
		return bRet;
	}
	
	HRESULT STDMETHODCALLTYPE QueryService(REFGUID guidService, 
			REFIID riid, void** ppvObject)
	{
		if (InlineIsEqualGUID(guidService, __uuidof(ISessionStateService)))
			return m_SessionStateSvc.QueryInterface(riid, ppvObject);
		return baseISAPI::QueryService(guidService, riid, ppvObject);
	}
}; // class CSessionSettingsExtension
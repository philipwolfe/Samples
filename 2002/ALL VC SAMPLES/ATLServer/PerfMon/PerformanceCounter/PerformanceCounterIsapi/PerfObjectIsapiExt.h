// File: PerfObjectIsapiExt.h
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
#include "resource.h"
#include "PerfObjectManager.h"


const int MAX_PERF_INSTANCES = 10;


__interface ATL_NO_VTABLE __declspec(uuid("6464E0FC-5442-47c3-9F40-65BC0592AC30")) 
ISampleCounter : public IUnknown
{
	STDMETHOD(IncCounter)(int index);
};

class CSampleCounter : public ISampleCounter, public CComObjectRootEx<CComGlobalsThreadModel>
{
	BEGIN_COM_MAP(CSampleCounter)
		COM_INTERFACE_ENTRY(ISampleCounter)
	END_COM_MAP()


	void SetPerformanceObject(int index, CSamplePerformanceObject* ptr)
	{
		ATLASSERT(index >= 0);
		ATLASSERT(index < MAX_PERF_INSTANCES);

		array[index] = ptr;
	}

	STDMETHOD (IncCounter)(int index)
	{
		ATLASSERT(index >=0);
		ATLASSERT(index < MAX_PERF_INSTANCES);

		if (array[index])
		{
			InterlockedIncrement( reinterpret_cast<LONG*>(&array[index]->rateCount));
			InterlockedIncrement( reinterpret_cast<LONG*>(&array[index]->rawCount));
			return S_OK;
		}
		return S_FALSE;
	}

private:
	CSamplePerformanceObject* array[MAX_PERF_INSTANCES];
};


// CSessionSettingsExtension - the ISAPI extension class
template <class ThreadPoolClass=CThreadPool<CIsapiWorker>, 
	class CStatClass=CStdRequestStats, 
	class HttpUserErrorTextProvider=CDefaultErrorProvider>
class CSamplePerformanceCounterIsapiExtension : 
	public CIsapiExtension<ThreadPoolClass, 
		CStatClass, 
		HttpUserErrorTextProvider>
{

protected:

	typedef CIsapiExtension<ThreadPoolClass, CStatClass, HttpUserErrorTextProvider> baseISAPI;
public:

	BOOL GetExtensionVersion(HSE_VERSION_INFO* pVer)
	{
		for (int i=0; i<MAX_PERF_INSTANCES; i++)
			perfObject[i] = 0;

		if (FAILED(perfObjMgr.Initialize()))
		{
			SetCriticalIsapiError(IDS_PERF_INIT_FAILED);
			return FALSE;
		}

		{
			CPerfLock lock(&perfObjMgr);
			HRESULT hr = lock.GetStatus();
			if (FAILED(hr))
			{
				SetCriticalIsapiError(IDS_PERF_LOCK_FAILED);
				return FALSE;
			}

			hr = perfObjMgr.CreateInstanceByName(1, L"Button1", reinterpret_cast<CPerfObject**>(&perfObject[0]));
			if (FAILED(hr))
			{
				SetCriticalIsapiError(IDS_PERF_CREATEINSTANCE_FAILED);
				return FALSE;
			}
			counter.SetPerformanceObject( 0, perfObject[0] );

			hr = perfObjMgr.CreateInstanceByName(1, L"Button2", reinterpret_cast<CPerfObject**>(&perfObject[1]));
			if (FAILED(hr))
			{
				SetCriticalIsapiError(IDS_PERF_CREATEINSTANCE_FAILED);
				return FALSE;
			}
			counter.SetPerformanceObject( 1, perfObject[1] );

			hr = perfObjMgr.CreateInstanceByName(1, L"Button3", reinterpret_cast<CPerfObject**>(&perfObject[2]));
			if (FAILED(hr))
			{
				SetCriticalIsapiError(IDS_PERF_CREATEINSTANCE_FAILED);
				return FALSE;
			}
			counter.SetPerformanceObject( 2, perfObject[2] );
		}

		if (!baseISAPI::GetExtensionVersion(pVer))
		{
			return FALSE;
		}

		return TRUE;
	}

	DWORD HttpExtensionProc(LPEXTENSION_CONTROL_BLOCK lpECB)
	{
		return baseISAPI::HttpExtensionProc( lpECB );
	}

	BOOL TerminateExtension(DWORD dwFlags)
	{
		perfObjMgr.UnInitialize();

		BOOL bRet = baseISAPI::TerminateExtension(dwFlags);
	
		return bRet;
	}
	
	HRESULT STDMETHODCALLTYPE QueryService(REFGUID guidService, 
			REFIID riid, void** ppvObject)
	{
		if (InlineIsEqualGUID(guidService, __uuidof(ISampleCounter)))
		return counter.QueryInterface(riid, ppvObject);

		return baseISAPI::QueryService(guidService, riid, ppvObject);
	}
private:

	CSamplePerformanceObjectManager perfObjMgr;
	CSamplePerformanceObject* perfObject[MAX_PERF_INSTANCES];
	CComObjectGlobal<CSampleCounter> counter;
};



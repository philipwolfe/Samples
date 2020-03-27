// PerfMonDisp.h
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// PerfMonDisp.h : Declaration of the CPerfMonDisp

#pragma once
#include "resource.h"       // main symbols

// this file implements the dispatch interfaces for perfmon objects.
// the following objects are exposed:
//
// CPerfMonDisp implements IPerfMonDisp
//   IPerfMonDisp exposes all of the functionality for registering and managing perfmon object and corresponds
//   to the functionality exposed by the C++ class CPerfMon
//
// the following properties are exposed by IPerfMonDisp:
//	BSTR AppName;
//      AppName must be set before calling any methods such as Initialize or PrepRegister
//
// the following methods are exposed by IPerfMonDisp:
//  BOOL Initialize();
//      This initializes perfmon's state, creating the shared memory, synchronization objects, and
//      loading the application's registered objects and counters
//      returns true on success, or false if the application is not yet registered
//
//  PrepRegister();
//      This clears the registration information in preparation for adding new strings
//
//  int AddObjectDefinition(
//               BSTR bstrObjectName,
//               BSTR bstrHelpString,
//               int nDetailLevel,
//               int nDefaultCounter,
//               BOOL bInstanceLess);
//      This adds an object definition to the list of objects to be registered.
//      This call should be followed immediately by calls to AddCounterDefinition
//      to add the counters for the object.
//      The return value is the object id (the same value that GetObjectId would return)
//
//  int AddCounterDefinition(
//               BSTR bstrObjectName,
//               BSTR bstrHelpString,
//               int nDetailLevel,
//               int nCounterType,
//               int nMaxCounterSize,
//               int nDefaultScale);
//      Adds a counter definition to the list of counters defined for the last object
//      added with AddObjectDefinition.
//      The return value is the id of the counter (the same value that GetCountId would return)
//
//  Register();
//      This registers all of the objects and counters definitions that have been added
//      with AddObjectDefinition and AddCounterDefinition. If any objects and counters
//      are already registered, their registration will be removed before the new values
//      are registered.
//      This should only be called the first time the application is run.
//      This does not register the strings for the object - RegisterStrings must also be called
//
//  RegisterStrings(int nLanguage);
//      This registers the current set of string given by a series of AddObjectDefinition and
//      AddCounterDefinition calls with the given language. nLanguage should be the MAJOR language
//      of the LANGID that you wish to register. Some examples - english == 9, japanese == 17, etc.
//      see the LANG_* constants in winnt.h for appropriate values
//
//      To register another language after calling RegisterString, call PrepRegister to remove the
//      current strings, add the definitions again with the alternate language, then
//      call RegisterStrings again. Do NOT call Register() a second time.
//      When adding multiple languages, each language must have the same series of object and
//      counter definitions, with only the name and help string different
//
//  Unregister();
//      Unregisters the application
//
//  int GetObjectId(BSTR bstrName);
//      This returns the object id (the same one returned by AddObjectDefinition when it was called)
//      for the given object name.
//      The object name given to this function must be the one that was used when Register() was 
//      called (not RegisterStrings)
//
//  int GetCounterId(int nObjectId, BSTR bstrName);
//      This returns the counter id (the same one returned by AddCounterDefinition when it was called)
//      for the given counter name.
//      The counter name given to this function must be the one that was used when Register() was 
//      called (not RegisterStrings)
//
//  IPerfObjectDisp* CreateInstance(int nId, int nInstance, BSTR bstrName);
//      This creates an instance of the given object using nInstance as the creation key.
//      nId must the the id of a registered object (returned by GetObjectId or AddObjectInstance).
//      Use this function when you want to create an instance and know what instance id you
//      wish to use ahead of time. For example, if you're creating objects to track mouse moves
//      and mouse clicks, you can use:
//          var oMouseMove = CreateInstance(nMouseData, WM_MOUSEMOVE, "Mouse Move");
//          var oMouseLDown = CreateInstance(nMouseData, WM_LBUTTONDOWN, "Mouse Left Button Down");
//
//  IPerfObjectDisp* CreateInstanceByName(int nId, BSTR bstrName);
//      Similar to CreateInstance by uses bstrName as the creation key and assigns nInstance dynamically.
//      this is useful if you with to create instances based on a dynamic set of keys, such as the names
//      of files in a directory.
//
// CPerfObjectDisp implements IPerfObjectDisp
//   IPerfObjectDisp exposes the counters on a specific instance of a perfmon object.
//   this interface corrsponds to the C++ class CPerfObject.
//   IPerfObjectDisp object cannot be created directly, but are instead created by IPerfMonDisp::CreateInstance
//   and IPerfMonDisp::CreateInstanceByName
//
// the following methods are exposed by IPerfObjectDisp:
//  VARIANT GetCounter(int nCounter);
//  SetCounter(int nCounter, VARIANT vValue);
//  IncrementCounter(int nCounter);
//  DecrementCounter(int nCounter);
//      Use these functions to manipulate the values of the counters exposed by the object
//      nCounter is the id of the counter as returned by IPerfMonDisp::GetCounterId
//      or IPerfMonDisp::AddCounterDefinition


class CPerfObjectDisp;
class CPerfMonDisp;

__declspec(selectany) LPCTSTR c_szPerfMonDispKey = _T("SOFTWARE\\Microsoft\\PerfMonDisp");
__declspec(selectany) LPCTSTR c_szPerfMonDispValue = _T("InstalledMaps");

extern "C" DWORD __declspec(dllexport) WINAPI PerfDisp_OpenPerfMon(
	LPWSTR lpDeviceNames) throw();
extern "C" DWORD __declspec(dllexport) WINAPI PerfDisp_CollectPerfMon(
	LPWSTR lpwszValue,
	LPVOID* lppData,
	LPDWORD lpcbBytes,
	LPDWORD lpcObjectTypes) throw();
extern "C" DWORD __declspec(dllexport) WINAPI PerfDisp_ClosePerfMon() throw();

// IPerfObjectDisp
[
	object,
	uuid(B2427724-60F6-4915-8BA8-60E6269F28A6),
	dual,	helpstring("IPerfObjectDisp Interface"),
	pointer_default(unique)
]
__interface IPerfObjectDisp : IDispatch
{
	[id(1)] HRESULT GetCounter([in] int nCounter, [out, retval] VARIANT* pvValue);
	[id(2)] HRESULT SetCounter([in] int nCounter, [in] VARIANT vValue);
	[id(3)] HRESULT IncrementCounter([in] int nCounter);
	[id(4)] HRESULT DecrementCounter([in] int nCounter);
};

// CPerfObjectDisp
[
	coclass,
	threading("apartment"),
	vi_progid("PerfDisp.PerfObjectDisp"),
	progid("PerfDisp.PerfObjectDisp.1"),
	version(1.0),
	uuid(5C163489-661F-4B5E-A6CE-78B2DC1D5FF2),
	default("IPerfObjectDisp"),
	helpstring("PerfObjectDisp Class")
]
class ATL_NO_VTABLE CPerfObjectDisp : 
	public IPerfObjectDisp
{
public:
	CPerfObjectDisp()
	{
	}

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}
	
	void FinalRelease() 
	{
	}

public:
	CPerfMonDisp* m_pPerfMon;
	CComPtr<IUnknown> m_spPerfMon; // to maintain a refcount on the perfmon object
	CPerfObject* m_pObject;

public:
	// IPerfObjectDisp APIs
	HRESULT STDMETHODCALLTYPE GetCounter(/* [in] */ int nCounter, /* [out, retval] */ VARIANT* pvValue);
	HRESULT STDMETHODCALLTYPE SetCounter(/* [in] */ int nCounter, /* [in] */ VARIANT vValue);
	HRESULT STDMETHODCALLTYPE IncrementCounter(/* [in] */ int nCounter);
	HRESULT STDMETHODCALLTYPE DecrementCounter(/* [in] */ int nCounter);
};

// IPerfMonDisp
[
	object,
	uuid("67EBE16E-CD32-4E0F-9FC1-75ED1F584643"),
	dual,
	helpstring("IPerfMonDisp Interface"),
	pointer_default(unique)
]
__interface IPerfMonDisp : IDispatch
{
	[propput, id(1)] HRESULT AppName([in] BSTR bstrName);
	[propget, id(1)] HRESULT AppName([out, retval] BSTR* pbstrName);
	[id(2)] HRESULT Initialize([out, retval] BOOL* bSuccess);

	[id(3)] HRESULT PrepRegister();
	[id(4)] HRESULT AddObjectDefinition(
		[in] BSTR bstrObjectName,
		[in] BSTR bstrHelpString,
		[in] int nDetailLevel,
		[in] int nDefaultCounter,
		[in] BOOL bInstanceLess,
		[out, retval] int* pnPerfId
	);
	[id(5)] HRESULT AddCounterDefinition(
		[in] BSTR bstrObjectName,
		[in] BSTR bstrHelpString,
		[in] int nDetailLevel,
		[in] int nCounterType,
		[in] int nMaxCounterSize,
		[in] int nDefaultScale,
		[out, retval] int* pnPerfId
	);
	[id(6)] HRESULT Register();
	[id(7)] HRESULT RegisterStrings([in] int nLanguage);
	[id(8)] HRESULT Unregister();

	[id(9)] HRESULT GetObjectId([in] BSTR bstrName, [out, retval] int* pnId);
	[id(10)] HRESULT GetCounterId([in] int nObjectId, [in] BSTR bstrName, [out, retval] int* pnId);

	[id(11)] HRESULT CreateInstance([in] int nId, [in] int nInstance, [in] BSTR bstrName, [out, retval] VARIANT* pInstance);
	[id(12)] HRESULT CreateInstanceByName([in] int nId, [in] BSTR bstrName, [out, retval] VARIANT* pInstance);
};

// CPerfMonDisp
[
	coclass,
	threading("apartment"),
	vi_progid("PerfDisp.PerfMonDisp"),
	progid("PerfDisp.PerfMonDisp.1"),
	version(1.0),
	uuid("6DCF1216-AB6C-40B2-8F70-2C4708F52A4D"),
	default("IPerfMonDisp"),
	helpstring("PerfMonDisp Class")
]
class ATL_NO_VTABLE CPerfMonDisp :
	public CPerfMon,
	public IPerfMonDisp
{
public:
	CPerfMonDisp()
	{
	}

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}
	
	void FinalRelease() 
	{
	}

public:
	// CPerfMon APIs
	LPCTSTR GetAppName() const throw();
	HRESULT CreateMap(WORD wLanguage, HINSTANCE hResInstance, UINT* pSampleRes = NULL) throw();

	// IPerfMonDisp
	HRESULT STDMETHODCALLTYPE put_AppName(BSTR bstrName);
	HRESULT STDMETHODCALLTYPE get_AppName(BSTR* pbstrName);
	HRESULT STDMETHODCALLTYPE Initialize(/* [out, retval] */ BOOL* bSuccess);
	HRESULT STDMETHODCALLTYPE PrepRegister();
	HRESULT STDMETHODCALLTYPE AddObjectDefinition(
		/* [in] */ BSTR bstrObjectName,
		/* [in] */ BSTR bstrHelpString,
		/* [in] */ int nDetailLevel,
		/* [in] */ int nDefaultCounter,
		/* [in] */ BOOL bInstanceLess,
		/* [out, retval] */ int* pnPerfId
	);
	HRESULT STDMETHODCALLTYPE AddCounterDefinition(
		/* [in] */ BSTR bstrObjectName,
		/* [in] */ BSTR bstrHelpString,
		/* [in] */ int nDetailLevel,
		/* [in] */ int nCounterType,
		/* [in] */ int nMaxCounterSize,
		/* [in] */ int nDefaultScale,
		/* [out, retval] */ int* pnPerfId
	);
	HRESULT STDMETHODCALLTYPE Register();
	HRESULT STDMETHODCALLTYPE RegisterStrings(/* [in] */ int nLanguage);
	HRESULT STDMETHODCALLTYPE Unregister();
	HRESULT STDMETHODCALLTYPE GetObjectId(/* [in] */ BSTR bstrName, /* [out, retval] */ int* pnId);
	HRESULT STDMETHODCALLTYPE GetCounterId(/* [in] */ int nObjectId, /* [in] */ BSTR bstrName, /* [out, retval] */ int* pnId);
	HRESULT STDMETHODCALLTYPE CreateInstance(/* [in] */ int nId, /* [in] */ int nInstance, /* [in] */ BSTR bstrName, /* [out, retval] */ VARIANT* pInstance);
	HRESULT STDMETHODCALLTYPE CreateInstanceByName(/* [in] */ int nId, /* [in] */ BSTR bstrName, /* [out, retval] */ VARIANT* pInstance);

private:
	CString m_strAppName;
	CAtlMap<int, CString> m_mapCounters;

	// info for registration
	int m_nObjectIndex;
	int m_nCurrOffset;
	int m_nNextPerfId;

	friend class CPerfObjectDisp;
};

typedef CComObject<CPerfMonDisp> _CPerfMonDisp;
__declspec(selectany) CAtlArray<_CPerfMonDisp*> g_aPerf;

#pragma comment(linker, "/EXPORT:PerfDisp_OpenPerfMon=_PerfDisp_OpenPerfMon@4")
#pragma comment(linker, "/EXPORT:PerfDisp_CollectPerfMon=_PerfDisp_CollectPerfMon@16")
#pragma comment(linker, "/EXPORT:PerfDisp_ClosePerfMon=_PerfDisp_ClosePerfMon@0")

extern "C" ATL_NOINLINE inline DWORD __declspec(dllexport) WINAPI PerfDisp_OpenPerfMon(
	LPWSTR lpDeviceNames) throw()
{
	DWORD dwErr;
	DWORD dwChars = 0;
	CRegKey rkPerfMonDisp;

	// retrieve the existing data
	dwErr = rkPerfMonDisp.Open(HKEY_LOCAL_MACHINE, c_szPerfMonDispKey);
	if (dwErr != ERROR_SUCCESS)
		return AtlHresultFromWin32(dwErr);

	dwErr = rkPerfMonDisp.QueryMultiStringValue(c_szPerfMonDispValue, NULL, &dwChars);
	if (dwErr != ERROR_SUCCESS)
		return AtlHresultFromWin32(dwErr);

	CString str;
	LPTSTR pszBuf = str.GetBuffer(dwChars);
	dwErr = rkPerfMonDisp.QueryMultiStringValue(c_szPerfMonDispValue, pszBuf, &dwChars);
	if (dwErr != ERROR_SUCCESS)
		return AtlHresultFromWin32(dwErr);

	// remove the appname
	LPTSTR pszTemp = pszBuf;
	while (*pszTemp)
	{
		_CPerfMonDisp* pPerfMonDisp = new _CPerfMonDisp;
		pPerfMonDisp->AddRef();
		CComBSTR bstrAppName(pszTemp);
		pPerfMonDisp->put_AppName(bstrAppName);
		if (pPerfMonDisp->Open(lpDeviceNames))
			pPerfMonDisp->Release();
		else
			g_aPerf.Add(pPerfMonDisp);

		pszTemp += _tcslen(pszTemp)+1;
	}

	return 0;
}

extern "C" ATL_NOINLINE inline DWORD __declspec(dllexport) WINAPI PerfDisp_CollectPerfMon(
	LPWSTR lpwszValue,
	LPVOID* lppData,
	LPDWORD lpcbBytes,
	LPDWORD lpcObjectTypes) throw()
{
	DWORD dwOrigBytes = *lpcbBytes;
	DWORD dwBytesRemaining = *lpcbBytes;
	for (size_t i=0; i<g_aPerf.GetCount(); i++)
	{
		DWORD dwErr = g_aPerf[i]->Collect(lpwszValue, lppData, lpcbBytes, lpcObjectTypes);
		if (dwErr != 0)
			return dwErr;
		dwBytesRemaining -= *lpcbBytes;
		*lpcbBytes = dwBytesRemaining;
	}
	*lpcbBytes = dwOrigBytes - dwBytesRemaining;
	return 0;
}

extern "C" ATL_NOINLINE inline DWORD __declspec(dllexport) WINAPI PerfDisp_ClosePerfMon() throw()
{
	for (size_t i=0; i<g_aPerf.GetCount(); i++)
	{
		_CPerfMonDisp* pPerfMonDisp = g_aPerf[i];
		pPerfMonDisp->Release();
	}
	g_aPerf.RemoveAll();

	return 0;
}

inline HRESULT STDMETHODCALLTYPE CPerfObjectDisp::GetCounter(/* [in] */ int nCounter, /* [out, retval] */ VARIANT* pvValue)
{
	::VariantInit(pvValue);

	CPerfMapEntry* pEntry = m_pPerfMon->_FindCounterInfo(m_pObject->m_dwObjectId, nCounter);
	if (!pEntry)
		return E_FAIL;

	CComVariant vRes;
	switch (pEntry->m_dwCounterType & ATLPERF_SIZE_MASK)
	{
	case PERF_SIZE_DWORD:
		vRes = *LPDWORD(LPBYTE(m_pObject)+pEntry->m_nDataOffset);
		break;
	case PERF_SIZE_LARGE:
		vRes.vt = VT_UI8;
		vRes.ullVal = *PULONGLONG(LPBYTE(m_pObject)+pEntry->m_nDataOffset);
		break;
	case PERF_SIZE_VARIABLE_LEN:
		{
			LPDWORD pOffset = LPDWORD(LPBYTE(m_pObject)+pEntry->m_nDataOffset);
			LPBYTE pSrc = LPBYTE(m_pObject)+*pOffset;
			if ((pEntry->m_dwCounterType & ATLPERF_TEXT_MASK) == PERF_TEXT_UNICODE)
				vRes = LPCWSTR(pSrc);
			else
				vRes = LPCSTR(pSrc);
		}
		break;
	default:
		return E_FAIL;
	}

	::VariantCopy(pvValue, &vRes);
	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CPerfObjectDisp::SetCounter(/* [in] */ int nCounter, /* [in] */ VARIANT vValue)
{
	CPerfMapEntry* pEntry = m_pPerfMon->_FindCounterInfo(m_pObject->m_dwObjectId, nCounter);
	if (!pEntry)
		return E_FAIL;

	CComVariant v(vValue);
	HRESULT hr;
	switch (pEntry->m_dwCounterType & ATLPERF_SIZE_MASK)
	{
	case PERF_SIZE_DWORD:
		hr = v.ChangeType(VT_UI4);
		if (FAILED(hr))
			return hr;
		*LPDWORD(LPBYTE(m_pObject)+pEntry->m_nDataOffset) = V_UI4(&v);
		break;
	case PERF_SIZE_LARGE:
		hr = v.ChangeType(VT_UI8);
		if (FAILED(hr))
			return hr;
		*PULONGLONG(LPBYTE(m_pObject)+pEntry->m_nDataOffset) = V_UI8(&v);
		break;
	case PERF_SIZE_VARIABLE_LEN:
		return E_NOTIMPL;
	default:
		return E_FAIL;
	}

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CPerfObjectDisp::IncrementCounter(/* [in] */ int nCounter)
{
	CPerfMapEntry* pEntry = m_pPerfMon->_FindCounterInfo(m_pObject->m_dwObjectId, nCounter);
	if (!pEntry)
		return E_FAIL;

	switch (pEntry->m_dwCounterType & ATLPERF_SIZE_MASK)
	{
	case PERF_SIZE_DWORD:
		InterlockedIncrement(LPLONG(LPBYTE(m_pObject)+pEntry->m_nDataOffset));
		break;
	case PERF_SIZE_LARGE:
	case PERF_SIZE_VARIABLE_LEN:
		return E_NOTIMPL;
	default:
		return E_FAIL;
	}

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CPerfObjectDisp::DecrementCounter(/* [in] */ int nCounter)
{
	CPerfMapEntry* pEntry = m_pPerfMon->_FindCounterInfo(m_pObject->m_dwObjectId, nCounter);
	if (!pEntry)
		return E_FAIL;

	switch (pEntry->m_dwCounterType & ATLPERF_SIZE_MASK)
	{
	case PERF_SIZE_DWORD:
		InterlockedDecrement(LPLONG(LPBYTE(m_pObject)+pEntry->m_nDataOffset));
		break;
	case PERF_SIZE_LARGE:
	case PERF_SIZE_VARIABLE_LEN:
		return E_NOTIMPL;
	default:
		return E_FAIL;
	}

	return S_OK;
}

// CPerfMon APIs
inline LPCTSTR CPerfMonDisp::GetAppName() const throw()
{
	ATLASSERT(!m_strAppName.IsEmpty());
	return m_strAppName;
}

inline HRESULT CPerfMonDisp::CreateMap(WORD /* wLanguage */, HINSTANCE /* hResInstance */, UINT* /* pSampleRes */) throw()
{
	return S_OK;
}

// IPerfMonDisp
inline HRESULT STDMETHODCALLTYPE CPerfMonDisp::put_AppName(BSTR bstrName)
{
	m_strAppName = bstrName;

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CPerfMonDisp::get_AppName(BSTR* pbstrName)
{
	if (pbstrName == NULL)
		return E_INVALIDARG;

	CComBSTR bstr(m_strAppName);
	*pbstrName = bstr.Detach();

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CPerfMonDisp::Initialize(/* [out, retval] */ BOOL* bSuccess)
{
	if (m_strAppName.IsEmpty())
		return E_UNEXPECTED;

	*bSuccess = TRUE;
	HRESULT hr = CPerfMon::Initialize();
	if (FAILED(hr))
		*bSuccess = FALSE;

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CPerfMonDisp::PrepRegister()
{
	m_nObjectIndex = -1;
	m_nCurrOffset = 0;
	m_nNextPerfId = 1;
	ClearMap();

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CPerfMonDisp::AddObjectDefinition(
	/* [in] */ BSTR bstrObjectName,
	/* [in] */ BSTR bstrHelpString,
	/* [in] */ int nDetailLevel,
	/* [in] */ int nDefaultCounter,
	/* [in] */ BOOL bInstanceLess,
	/* [out, retval] */ int* pnPerfId
)
{
	*pnPerfId = m_nNextPerfId;

	HRESULT hr = CPerfMon::AddObjectDefinition(
		(DWORD) m_nNextPerfId,
		CString(bstrObjectName),
		CString(bstrHelpString),
		(DWORD) nDetailLevel,
		nDefaultCounter,
		bInstanceLess,
		sizeof(CPerfObject));
	if (FAILED(hr))
		return hr;

	if (m_nObjectIndex == -1)
		m_nObjectIndex = 0;
	else
		m_nObjectIndex += _GetMapEntry(m_nObjectIndex).m_nNumCounters;
	m_nCurrOffset = sizeof(CPerfObject);
	m_nNextPerfId++;

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CPerfMonDisp::AddCounterDefinition(
	/* [in] */ BSTR bstrObjectName,
	/* [in] */ BSTR bstrHelpString,
	/* [in] */ int nDetailLevel,
	/* [in] */ int nCounterType,
	/* [in] */ int nMaxCounterSize,
	/* [in] */ int nDefaultScale,
	/* [out, retval] */ int* pnPerfId
)
{
	int nSize = 0;
	switch (nCounterType & ATLPERF_SIZE_MASK)
	{
	case PERF_SIZE_DWORD:
		nSize = 4;
		break;
	case PERF_SIZE_LARGE:
		nSize = 8;
		break;
	default:
		return E_FAIL;
	}

	*pnPerfId = m_nNextPerfId;

	HRESULT hr = CPerfMon::AddCounterDefinition(
		(DWORD) m_nNextPerfId,
		CString(bstrObjectName),
		CString(bstrHelpString),
		(DWORD) nDetailLevel,
		(DWORD) nCounterType,
		(ULONG) nMaxCounterSize,
		m_nCurrOffset,
		nDefaultScale);
	if (FAILED(hr))
		return hr;

	m_nCurrOffset += nSize;
	CPerfMapEntry& object = _GetMapEntry(m_nObjectIndex);
	object.m_nStructSize += nSize;
	object.m_nAllocSize += nSize;
	m_nNextPerfId++;

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CPerfMonDisp::Register()
{
	if (m_strAppName.IsEmpty())
		return E_UNEXPECTED;

	CRegKey rkPerfMonDisp;
	DWORD dwErr;
	DWORD dwChars = 0;

	// create the key if needed
	dwErr = rkPerfMonDisp.Create(HKEY_LOCAL_MACHINE, c_szPerfMonDispKey);
	if (dwErr != ERROR_SUCCESS)
		return AtlHresultFromWin32(dwErr);

	dwErr = rkPerfMonDisp.QueryMultiStringValue(c_szPerfMonDispValue, NULL, &dwChars);
	if (dwErr == ERROR_FILE_NOT_FOUND)
	{
		// this is the first PerfMonDisp map installed on this machine.
		CString str = m_strAppName;
		LPTSTR pszBuf = str.GetBuffer(m_strAppName.GetLength()+2);
		pszBuf[m_strAppName.GetLength()+1] = 0;

		dwErr = rkPerfMonDisp.SetMultiStringValue(c_szPerfMonDispValue, pszBuf);
		if (dwErr != ERROR_SUCCESS)
			return AtlHresultFromWin32(dwErr);
	}
	else
	{
		// add this to the list of installs
		if (dwErr != ERROR_SUCCESS)
			return AtlHresultFromWin32(dwErr);

		dwChars += m_strAppName.GetLength()+1;

		CString str;
		LPTSTR pszBuf = str.GetBuffer(dwChars);
		dwErr = rkPerfMonDisp.QueryMultiStringValue(c_szPerfMonDispValue, pszBuf, &dwChars);
		if (dwErr != ERROR_SUCCESS)
			return AtlHresultFromWin32(dwErr);

		// add the appname
		LPTSTR pszTemp = pszBuf;
		while (*pszTemp)
		{
			if (m_strAppName == pszTemp)
			{
				// it's already in the list. don't add a second copy
				break;
			}
			pszTemp += _tcslen(pszTemp)+1;
			if (!*pszTemp)
			{
				// we reached the end and didn't find the appname. add it
				_tcscpy(pszTemp, m_strAppName);
				pszTemp += m_strAppName.GetLength()+1;
				*pszTemp = 0;

				dwErr = rkPerfMonDisp.SetMultiStringValue(c_szPerfMonDispValue, pszBuf);
				if (dwErr != ERROR_SUCCESS)
					return AtlHresultFromWin32(dwErr);

				break;
			}
		}
	}

	HRESULT hr = CPerfMon::Register("PerfDisp_OpenPerfMon", "PerfDisp_CollectPerfMon", "PerfDisp_ClosePerfMon");
	if (FAILED(hr))
		return hr;

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CPerfMonDisp::RegisterStrings(/* [in] */ int nLanguage)
{
	return CPerfMon::RegisterStrings(MAKELANGID(nLanguage, SUBLANG_NEUTRAL));
}

inline HRESULT STDMETHODCALLTYPE CPerfMonDisp::Unregister()
{
	if (m_strAppName.IsEmpty())
		return E_UNEXPECTED;

	CRegKey rkPerfMonDisp;
	DWORD dwErr;
	DWORD dwChars = 0;

	// retrieve the existing data
	dwErr = rkPerfMonDisp.Open(HKEY_LOCAL_MACHINE, c_szPerfMonDispKey);
	if (dwErr == ERROR_FILE_NOT_FOUND)
		return S_OK;
	else if (dwErr != ERROR_SUCCESS)
		return AtlHresultFromWin32(dwErr);

	dwErr = rkPerfMonDisp.QueryMultiStringValue(c_szPerfMonDispValue, NULL, &dwChars);
	if (dwErr != ERROR_SUCCESS)
		return AtlHresultFromWin32(dwErr);

	CString str;
	LPTSTR pszBuf = str.GetBuffer(dwChars);
	dwErr = rkPerfMonDisp.QueryMultiStringValue(c_szPerfMonDispValue, pszBuf, &dwChars);
	if (dwErr != ERROR_SUCCESS)
		return AtlHresultFromWin32(dwErr);

	// remove the appname
	LPTSTR pszTemp = pszBuf;
	while (*pszTemp)
	{
		if (m_strAppName == pszTemp)
		{
			if (dwChars == (DWORD) m_strAppName.GetLength()+2)
			{
				// this is the only thing registered, delete the PerfMonDisp regkey
				rkPerfMonDisp.Close();
				RegDeleteKey(HKEY_LOCAL_MACHINE, c_szPerfMonDispKey);
			}
			else
			{
				// delete the appname
				LPTSTR pszEnd = pszBuf+dwChars;
				LPTSTR pszNext = pszTemp+m_strAppName.GetLength()+1;
				memmove(pszTemp, pszNext, (pszEnd-pszNext)*sizeof(TCHAR));

				dwErr = rkPerfMonDisp.SetMultiStringValue(c_szPerfMonDispValue, pszBuf);
				if (dwErr != ERROR_SUCCESS)
					return AtlHresultFromWin32(dwErr);
			}

			break;
		}
		pszTemp += _tcslen(pszTemp)+1;
	}

	return CPerfMon::Unregister();
}

inline HRESULT STDMETHODCALLTYPE CPerfMonDisp::GetObjectId(/* [in] */ BSTR bstrName, /* [out, retval] */ int* pnId)
{
	CString strTarget(bstrName);
	*pnId = 0;

	UINT nIndex = 0;
	while (nIndex < _GetNumMapEntries())
	{
		CPerfMapEntry& object = _GetMapEntry(nIndex);
		if (strTarget == object.m_strName)
		{
			*pnId = (int) object.m_dwPerfId;
			return S_OK;
		}
		nIndex += object.m_nNumCounters+1;
	}

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CPerfMonDisp::GetCounterId(/* [in] */ int nObjectId, /* [in] */ BSTR bstrName, /* [out, retval] */ int* pnId)
{
	CString strTarget(bstrName);
	*pnId = 0;

	CPerfMapEntry* pObject = _FindObjectInfo(nObjectId);
	for (ULONG i=0; i<pObject->m_nNumCounters; i++)
	{
		CPerfMapEntry* pCounter = pObject+i+1;
		if (strTarget == pCounter->m_strName)
		{
			*pnId = pCounter->m_dwPerfId;
			return S_OK;
		}
	}

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CPerfMonDisp::CreateInstance(/* [in] */ int nId, /* [in] */ int nInstance, /* [in] */ BSTR bstrName, /* [out, retval] */ VARIANT* pInstance)
{
	::VariantInit(pInstance);

	CPerfObject* pObject = 0;
	HRESULT hr;
	
	hr = CPerfMon::CreateInstance((DWORD) nId, (DWORD) nInstance, bstrName, &pObject);
	if (FAILED(hr))
		return hr;

	CComObject<CPerfObjectDisp>* pObjectDisp = new CComObject<CPerfObjectDisp>;
	pObjectDisp->m_pPerfMon = this;
	pObjectDisp->m_spPerfMon = static_cast<IPerfMonDisp*>(this);
	pObjectDisp->m_pObject = pObject;

	CComVariant vObject(static_cast<IDispatch*>(pObjectDisp));
	::VariantCopy(pInstance, &vObject);
	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CPerfMonDisp::CreateInstanceByName(/* [in] */ int nId, /* [in] */ BSTR bstrName, /* [out, retval] */ VARIANT* pInstance)
{
	::VariantInit(pInstance);

	CPerfObject* pObject = 0;
	HRESULT hr;
	
	hr = CPerfMon::CreateInstanceByName((DWORD) nId, bstrName, &pObject);
	if (FAILED(hr))
		return hr;

	CComObject<CPerfObjectDisp>* pObjectDisp = new CComObject<CPerfObjectDisp>;
	pObjectDisp->m_pPerfMon = this;
	pObjectDisp->m_spPerfMon = static_cast<IPerfMonDisp*>(this);
	pObjectDisp->m_pObject = pObject;

	CComVariant vObject(static_cast<IDispatch*>(pObjectDisp));
	::VariantCopy(pInstance, &vObject);
	return S_OK;
}

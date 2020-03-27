// script.h
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

#pragma once

// This file provides an object that control all the interaction with a scripting engine.
// The main things it provides are:
// - an interface (IScriptDriver) that the user can use to:
//      load/start the engine
//      add script files
//      named objects to the script's namespace
//      invoke methods implemented by the script
// - it implements the site and handles all of the calls the the script engine makes
//   (such as asking for the interfaces to the named objects the user has added)
//
// this object doesn't do everything that can be done with a script engine, only the simple
// things that were needed for this sample. If additional functionality is needed, either
// add them to IScriptDriver or use IScriptDriver::GetScriptEngine or IScriptDriver::GetScriptDispatch
// and do the operations directly

#include <activscp.h>
#include <atlcoll.h>
#include <atlfile.h>
#include <atlconv.h>

__interface __declspec(uuid("B9E42340-7A06-457A-A49C-4044CADE606D")) IScriptDriver : public IUnknown
{
	HRESULT STDMETHODCALLTYPE Initialize(REFCLSID clsidEngine);
	HRESULT STDMETHODCALLTYPE Connect();
	HRESULT STDMETHODCALLTYPE Close();
	HRESULT STDMETHODCALLTYPE GetScriptEngine(IActiveScript** pScript);
	HRESULT STDMETHODCALLTYPE GetScriptDispatch(IDispatch** pScriptDisp);
	HRESULT STDMETHODCALLTYPE ParseScriptFile(LPSTR szFileName);
	HRESULT STDMETHODCALLTYPE AddNamedItem(LPWSTR szName, IUnknown* pUnk);
	HRESULT STDMETHODCALLTYPE Invoke(LPWSTR szMethod);
};

class CScriptDriver :
	public CComObjectRootEx<CComSingleThreadModel>,
	public IScriptDriver,
	public IActiveScriptSite
{
public:
	CScriptDriver();
	~CScriptDriver();

	BEGIN_COM_MAP(CScriptDriver)
		COM_INTERFACE_ENTRY(IActiveScriptSite)
		COM_INTERFACE_ENTRY(IScriptDriver)
	END_COM_MAP()

	CComPtr<IActiveScript> m_spScript;
	CComPtr<IDispatch> m_spScriptDisp;
	CAtlMap<CStringW, CComPtr<IUnknown>, CStringElementTraits<CStringW> > m_mapNamedItems;

	//////////////////////////////////
	// IScriptDriver methods
	HRESULT STDMETHODCALLTYPE Initialize(REFCLSID clsidEngine);
	HRESULT STDMETHODCALLTYPE Connect();
	HRESULT STDMETHODCALLTYPE Close();
	HRESULT STDMETHODCALLTYPE GetScriptEngine(IActiveScript** pScript);
	HRESULT STDMETHODCALLTYPE GetScriptDispatch(IDispatch** pScriptDisp);
	HRESULT STDMETHODCALLTYPE ParseScriptFile(LPSTR szFileName);
	HRESULT STDMETHODCALLTYPE AddNamedItem(LPWSTR szName, IUnknown* pUnk);
	HRESULT STDMETHODCALLTYPE Invoke(LPWSTR szMethod);

	//////////////////////////////////
	// IActiveScriptSite methods
    HRESULT STDMETHODCALLTYPE GetLCID(LCID *plcid);
    HRESULT STDMETHODCALLTYPE GetItemInfo(LPCOLESTR pstrName, DWORD dwReturnMask, IUnknown **ppiunkItem, ITypeInfo **ppti);
    HRESULT STDMETHODCALLTYPE GetDocVersionString(BSTR *pbstrVersion);
    HRESULT STDMETHODCALLTYPE OnScriptTerminate(const VARIANT *pvarResult, const EXCEPINFO *pExcepEnfo);
    HRESULT STDMETHODCALLTYPE OnStateChange(SCRIPTSTATE ssScriptState);
    HRESULT STDMETHODCALLTYPE OnScriptError(IActiveScriptError *pScriptError);
    HRESULT STDMETHODCALLTYPE OnEnterScript(void);
    HRESULT STDMETHODCALLTYPE OnLeaveScript(void);
};

inline CScriptDriver::CScriptDriver()
{
}

inline CScriptDriver::~CScriptDriver()
{
}

//////////////////////////////////
// IScriptDriver methods

inline HRESULT STDMETHODCALLTYPE CScriptDriver::Initialize(REFCLSID clsidEngine)
{
	if (m_spScript)
		return E_UNEXPECTED;

	HRESULT hr;

	hr = m_spScript.CoCreateInstance(clsidEngine);
	if (FAILED(hr))
		return hr;

	hr = m_spScript->SetScriptSite(this);
	if (FAILED(hr))
		return hr;

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::Connect()
{
	if (!m_spScript)
		return E_UNEXPECTED;

	HRESULT hr;

	hr = m_spScript->SetScriptState(SCRIPTSTATE_CONNECTED);
	if (FAILED(hr))
		return hr;

	hr = m_spScript->GetScriptDispatch(NULL, &m_spScriptDisp);
	if (FAILED(hr))
		return hr;

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::Close()
{
	if (!m_spScript)
		return E_UNEXPECTED;

	m_spScriptDisp.Release();
	m_spScript->Close();
	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::GetScriptEngine(IActiveScript** ppScript)
{
	if (!m_spScript)
		return E_UNEXPECTED;

	return m_spScript.CopyTo(ppScript);
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::GetScriptDispatch(IDispatch** ppScriptDisp)
{
	if (!m_spScript)
		return E_UNEXPECTED;

	if (!m_spScriptDisp)
		m_spScript.QueryInterface(&m_spScriptDisp);

	return m_spScriptDisp.CopyTo(ppScriptDisp);
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::ParseScriptFile(LPSTR szFileName)
{
	if (!m_spScript)
		return E_UNEXPECTED;

	HRESULT hr;

	CAtlFile file;
	hr = file.Create(szFileName, GENERIC_READ, 0, OPEN_EXISTING);
	if (FAILED(hr))
		return hr;

	ULONGLONG nLen;
	hr = file.GetSize(nLen);
	if (FAILED(hr))
		return hr;

	CStringA str;
	LPSTR sz = str.GetBuffer((int) nLen+1);
	if (!sz)
		return E_OUTOFMEMORY;

	hr = file.Read(sz, (DWORD) nLen);
	if (FAILED(hr))
		return hr;
	sz[nLen] = 0;

	CComQIPtr<IActiveScriptParse> spScriptParse = m_spScript;
	if (spScriptParse == NULL)
		return E_FAIL;

	hr = spScriptParse->InitNew();
	if (FAILED(hr))
		return hr;

	hr = spScriptParse->ParseScriptText(CA2W(sz), NULL, NULL, NULL, 0, 1, SCRIPTTEXT_ISPERSISTENT | SCRIPTTEXT_ISVISIBLE, NULL, NULL);
	if (FAILED(hr))
		return hr;

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::AddNamedItem(LPWSTR szName, IUnknown* pUnk)
{
	HRESULT hr;
	
	hr = m_spScript->AddNamedItem(szName, SCRIPTITEM_ISPERSISTENT | SCRIPTITEM_ISVISIBLE);
	if (FAILED(hr))
		return hr;

	m_mapNamedItems.SetAt(szName, pUnk);

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::Invoke(LPWSTR szMethod)
{
	if (m_spScriptDisp)
		return m_spScriptDisp.Invoke0(szMethod);

	return E_FAIL;
}

//////////////////////////////////
// IActiveScriptSite methods

inline HRESULT STDMETHODCALLTYPE CScriptDriver::GetLCID(/* [out] */ LCID * /* plcid */)
{
	ATLTRACE("GetLCID called\n");
	return E_NOTIMPL;
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::GetItemInfo(
    /* [in] */ LPCOLESTR pstrName,
    /* [in] */ DWORD dwReturnMask,
    /* [out] */ IUnknown **ppiunkItem,
    /* [out] */ ITypeInfo **ppti)
{
	ATLTRACE("GetItemInfo called for item %S\n", pstrName);
	CComPtr<IUnknown> spUnk;
	if (m_mapNamedItems.Lookup(pstrName, spUnk))
	{
		HRESULT hr;
		if (dwReturnMask & SCRIPTINFO_IUNKNOWN)
		{
			hr = spUnk.CopyTo(ppiunkItem);
			if (FAILED(hr))
				return TYPE_E_ELEMENTNOTFOUND;
		}

		if (dwReturnMask & SCRIPTINFO_ITYPEINFO)
		{
			*ppti = NULL;
		}
	}
	else
		return TYPE_E_ELEMENTNOTFOUND;

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::GetDocVersionString(/* [out] */ BSTR *pbstrVersion)
{
	ATLTRACE("GetDocVersionString called\n");
	CComBSTR bstr(L"ScriptDriver 1.0");
	*pbstrVersion = bstr.Detach();
	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::OnScriptTerminate(
    /* [in] */ const VARIANT * /* pvarResult */,
    /* [in] */ const EXCEPINFO * /* pExcepEnfo */)
{
	ATLTRACE("OnScriptTerminate called\n");
	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::OnStateChange(/* [in] */ SCRIPTSTATE ssScriptState)
{
	ATLTRACE("OnStateChange called. New state: ");
	switch(ssScriptState)
	{
	case SCRIPTSTATE_UNINITIALIZED:
		ATLTRACE("Uninitialized\n");
		break;
	case SCRIPTSTATE_INITIALIZED:
		ATLTRACE("Initialized\n");
		break;
	case SCRIPTSTATE_STARTED:
		ATLTRACE("Started\n");
		break;
	case SCRIPTSTATE_CONNECTED:
		ATLTRACE("Connected\n");
		break;
	case SCRIPTSTATE_DISCONNECTED:
		ATLTRACE("Disconnected\n");
		break;
	case SCRIPTSTATE_CLOSED:
		ATLTRACE("Closed\n");
		break;
	default:
		ATLTRACE("Unknown (%d)\n", ssScriptState);
	}

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::OnScriptError(/* [in] */ IActiveScriptError *m_spScriptError)
{
	ATLTRACE("OnScriptError called\n");
	ATLTRACE("Script Error:\n");
	EXCEPINFO info;
	DWORD dw;
	ULONG nLine = 0;
	LONG nChar = 0;
	CComBSTR bstrSource;
	if (SUCCEEDED(m_spScriptError->GetExceptionInfo(&info)))
	{
		ATLTRACE("Error: %S\n", info.bstrSource);
		ATLTRACE("Description: %S\n", info.bstrDescription);
		LPTSTR pszMsg = NULL;
		::FormatMessage(FORMAT_MESSAGE_ALLOCATE_BUFFER|FORMAT_MESSAGE_FROM_SYSTEM, NULL, info.scode, 0, (LPTSTR)&pszMsg, 0, NULL);
		ATLTRACE("Error code: 0x%x - %s", info.scode, pszMsg);
		::LocalFree(pszMsg);

		if (SUCCEEDED(m_spScriptError->GetSourcePosition(&dw, &nLine, &nChar)) &&
			SUCCEEDED(m_spScriptError->GetSourceLineText(&bstrSource)))
		{
			ATLTRACE("Source: %S\n", bstrSource);
			ATLTRACE("Line: %d, Char: %d\n", nLine, nChar);
		}
	}
	else
		ATLTRACE("<Unknown>\n");

	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::OnEnterScript(void)
{
//		ATLTRACE("OnEnterScript called\n");
	return S_OK;
}

inline HRESULT STDMETHODCALLTYPE CScriptDriver::OnLeaveScript(void)
{
//		ATLTRACE("OnLeaveScript called\n");
	return S_OK;
}

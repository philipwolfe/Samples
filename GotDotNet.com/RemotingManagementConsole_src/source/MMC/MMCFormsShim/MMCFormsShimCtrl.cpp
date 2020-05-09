// MMCFormsShimCtrl.cpp : Implementation of CMMCFormsShimCtrl
#include "stdafx.h"
#include "MMCFormsShim.h"
#include "MMCFormsShimCtrl.h"


// CMMCFormsShimCtrl

HRESULT CMMCFormsShimCtrl::FinalConstruct()
{
   Reset();

	CComPtr<IUnknown> pAppDomainPunk;
	HRESULT hr = CorBindToRuntimeEx(NULL, NULL, STARTUP_LOADER_OPTIMIZATION_SINGLE_DOMAIN | STARTUP_CONCURRENT_GC, __uuidof(CorRuntimeHost), __uuidof(ICorRuntimeHost), (LPVOID*)&m_pHost);
	if(FAILED(hr))
		return hr;
	hr = m_pHost->Start();
	if(FAILED(hr))
		return hr;
	hr = m_pHost->GetDefaultDomain(&pAppDomainPunk);
	if(FAILED(hr) || !pAppDomainPunk)
		return hr;
	hr = pAppDomainPunk->QueryInterface(__uuidof(mscorlib::_AppDomain), (LPVOID*)&m_pDefaultDomain);
	if(FAILED(hr) || !m_pDefaultDomain)
		return hr;

	return hr;
}	



LRESULT CMMCFormsShimCtrl::OnShowWindow(UINT, WPARAM, LPARAM, BOOL&)
{
	CComPtr<IUnknown> pUnk;
//	Reset();
//	FinalConstruct();
   if (m_bstrAssemblyName.Length() && m_bstrClass.Length())
	   HRESULT hr = HostUserControl(m_bstrAssemblyName, m_bstrClass, &pUnk);
	return 0;
}

LRESULT CMMCFormsShimCtrl::OnSize(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM lParam, BOOL& bHandled)
{
	WORD wLength = LOWORD(lParam);
	WORD wHeight = HIWORD(lParam);
	::MoveWindow(m_hWndForm, 0, 0, wLength, wHeight, TRUE);
	bHandled = FALSE;
	return 0;
}


void CMMCFormsShimCtrl::Reset()
{
	m_pHost = NULL;
	m_pDefaultDomain = NULL;
	m_varFormDisp.Clear();
	m_hWndForm = NULL;
}



HRESULT CMMCFormsShimCtrl::HostUserControl(BSTR Assembly, BSTR Class, IUnknown **ppControlObject)
{
   HRESULT hr = S_OK;

   if (m_hWndForm == NULL)
   {
      CComPtr<mscorlib::_Assembly> pAssembly;

	   RECT rc;
	   CComPtr<IWin32Window> pIWin32Window;
	   hr = m_pDefaultDomain->Load_2(Assembly, &pAssembly);
	   if(FAILED(hr) || (!pAssembly))
	   {
			hr = E_FAIL;
			Reset();
			return hr;
	   }

      hr = pAssembly->CreateInstance(Class, &m_varFormDisp);
	   if((m_varFormDisp.vt != VT_DISPATCH) && (m_varFormDisp.vt != VT_UNKNOWN) || (!m_varFormDisp.punkVal))
	   {
		   hr = E_FAIL;
		   Reset();
		   return hr;
	   }
	   hr = m_varFormDisp.pdispVal->QueryInterface(IID_IUnknown, (LPVOID*)ppControlObject);
	   hr = m_varFormDisp.pdispVal->QueryInterface(IID_IWin32Window, (LPVOID*)&pIWin32Window);
	   if(FAILED(hr))
	   {
		   Reset();
		   return hr;
	   }
      
      long nWndForm = 0;
	   hr = pIWin32Window->get_Handle(&nWndForm);
	   if(FAILED(hr) || !nWndForm)
	   {
		   Reset();
		   return hr;
	   }

#pragma warning (push)
#pragma warning (disable : 4312)
       m_hWndForm = (HWND)nWndForm;
#pragma warning (pop)


      // parent the form window returned and move it into position
	   ::SetParent(m_hWndForm, m_hWnd);
	   ::GetWindowRect(m_hWnd, &rc);
	   ::MoveWindow(m_hWndForm, 0, 0, rc.right-rc.left, rc.bottom-rc.top, TRUE);
   }

	return hr;
}

STDMETHODIMP CMMCFormsShimCtrl::get_FormClassName(BSTR* pVal)
{
	if (pVal == NULL)
		return E_POINTER;

	*pVal = m_bstrClass.Copy();
	return S_OK;
}

STDMETHODIMP CMMCFormsShimCtrl::put_FormClassName(BSTR newVal)
{
	m_bstrClass = newVal;
	return S_OK;
}

STDMETHODIMP CMMCFormsShimCtrl::get_AssemblyName(BSTR* pVal)
{
	if (pVal == NULL)
		return E_POINTER;

	*pVal = m_bstrAssemblyName.Copy();

	return S_OK;
}

STDMETHODIMP CMMCFormsShimCtrl::put_AssemblyName(BSTR newVal)
{
	m_bstrAssemblyName = newVal;
	return S_OK;
}

// This is a part of the Active Template Library. 
// Copyright (C) Microsoft Corporation
// All rights reserved. 
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// NotSoSimple.h : Declaration of the CNotSoSimple

#ifndef __NOTSOSIMPLE_H_
#define __NOTSOSIMPLE_H_

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CNotSoSimple

// #import doesn't generate a LIBID, so we have to do it manually
namespace Word
{
   struct __declspec(uuid("00020905-0000-0000-C000-000000000046"))
      /* library */ Library;
};

class ATL_NO_VTABLE CNotSoSimple : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CNotSoSimple, &CLSID_NotSoSimple>,
	public IDispatchImpl<ISwitch, &IID_ISwitch, &LIBID_ATLEVENTHANDLINGLib>,
	public IDispEventImpl</*nID*/ 1, CNotSoSimple,
            &__uuidof(Word::ApplicationEvents2),
            &__uuidof(Word::Library), /*wMajor*/ 8, /*wMinor*/ 1>

{
public:
	CNotSoSimple()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_NOTSOSIMPLE)

DECLARE_PROTECT_FINAL_CONSTRUCT()

BEGIN_COM_MAP(CNotSoSimple)
	COM_INTERFACE_ENTRY(ISwitch)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()

   CComPtr<Word::_Application> m_pApp;

   // Event handlers
   void __stdcall OnQuit()
   {
	   Stop();
   }

   void __stdcall OnDocChange()
   {
	  ATLASSERT(m_pApp != NULL);

      // Get a pointer to the _Document interface on the active document
      CComPtr<Word::_Document> pDoc;
      m_pApp->get_ActiveDocument(&pDoc);

      // Get the name from the active document
      CComBSTR bstrName;
      if (pDoc)
		  pDoc->get_Name(&bstrName);

      // Create a display string
      CComBSTR bstrDisplay(_T("New document title:\n"));
      bstrDisplay += bstrName;

      // Display the name to the user
      USES_CONVERSION;
      MessageBox(NULL, W2CT(bstrDisplay), _T("IDispEventImpl : Active Document Changed"), MB_OK);
   }

BEGIN_SINK_MAP(CNotSoSimple)
   SINK_ENTRY_EX(/*nID =*/ 1, __uuidof(Word::ApplicationEvents2), /*dispid =*/ 3, OnDocChange)
   SINK_ENTRY_EX(/*nID =*/ 1, __uuidof(Word::ApplicationEvents2), /*dispid =*/ 2, OnQuit)
END_SINK_MAP()

// ISwitch
public:

   STDMETHOD(Start)()
   {
      // If we already have an object, just return
      if (m_pApp)
         return S_OK;

      // Create an instance of Word's Application object
      HRESULT hr = m_pApp.CoCreateInstance(__uuidof(Word::Application), NULL, CLSCTX_SERVER);
	  if (FAILED(hr))
		  return hr;

	  ATLASSERT(m_pApp != NULL);

      // Make the Word user interface visible
      m_pApp->put_Visible(true);

      // Forge a connection to enable us to receive events
      DispEventAdvise(m_pApp);

      return S_OK;
   }

   STDMETHOD(Stop)()
   {
      // Check we have an object to unadvise on
      if (!m_pApp)
         return S_OK;

      // Break the connection with the event source
      DispEventUnadvise(m_pApp);

      // Release the Word application
      m_pApp.Release();

      return S_OK;
   }
};

#endif //__NOTSOSIMPLE_H_

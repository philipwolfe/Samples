// VCUE_COM.h
// (c) 2000 Microsoft Corporation
//
//////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(_VCUE_COM_H___9111840E_6934_486C_BA54_3CDDB84D50D0___INCLUDED_)
#define _VCUE_COM_H___9111840E_6934_486C_BA54_3CDDB84D50D0___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

namespace VCUE
{
	class CComInitializer
	{
	private:
		HRESULT m_hr;

	public:
		
	#if (_WIN32_WINNT >= 0x0400 ) || defined(_WIN32_DCOM) 
		CComInitializer(DWORD dwCoInit = COINIT_APARTMENTTHREADED) : m_hr(E_UNEXPECTED)
		{
			m_hr = CoInitializeEx(NULL, dwCoInit);
		}
	#else
		CComInitializer() : m_hr(E_UNEXPECTED)
		{
			m_hr = CoInitialize(NULL);
		}
	#endif

		HRESULT Result()
		{
			return m_hr;
		}

		~CComInitializer()
		{
			if (SUCCEEDED(m_hr))
				CoUninitialize();
		}
	};

	// Use this class to create COM objects
	// where the ref count doesn't control
	// the lifetime of the object or module.
	template <typename Base>
	class CComObjectNoRefCount : public Base
	{
	public:
		typedef Base _BaseClass;
		
		HRESULT m_hResFinalConstruct;
		
		#if defined(DEBUG)
			ULONG m_nRefCount;
		#endif

		CComObjectNoRefCount(void* = NULL)
		{
			#if defined(DEBUG)
				m_nRefCount = 0;
			#endif

			m_hResFinalConstruct = FinalConstruct();
		}

		~CComObjectNoRefCount()
		{
			// This assert indicates mismatched ref counts.
			//
			// The ref count has no control over the
			// lifetime of this object, so you must ensure
			// by some other means that the object remains 
			// alive while clients have references to its interfaces.
			ATLASSERT(m_nRefCount == 0);
			FinalRelease();
		}

		STDMETHOD_(ULONG, AddRef)()
		{
			#if defined(DEBUG)
				return ++m_nRefCount;
			#else
				return 0;
			#endif
		}

		STDMETHOD_(ULONG, Release)()
		{
			#if defined(DEBUG)
				return --m_nRefCount;
			#else
				return 0;
			#endif
		}

		STDMETHOD(QueryInterface)(REFIID iid, void ** ppvObject)
		{
			return _InternalQueryInterface(iid, ppvObject);
		}
	};

} // namespace VCUE

#endif // !defined(_VCUE_COM_H___9111840E_6934_486C_BA54_3CDDB84D50D0___INCLUDED_)

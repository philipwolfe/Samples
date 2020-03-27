// VCUE_MemoryCache.h : Defines helpers for dealing with cache handles
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

namespace VCUE
{
	template <class T>
	class PrePostCondition
	{
		public:
			PrePostCondition(const T& object);
			~PrePostCondition();

		private:
			const T& m_Object;
	};

	class CMemoryCacheHandle
	{
	public:
		typedef CMemoryCacheHandle thisClass;

		explicit CMemoryCacheHandle(IMemoryCache* pCache);
		~CMemoryCacheHandle();
		
		HRESULT Acquire(LPCSTR Name);
		HRESULT Release();
		HRESULT Remove();

		template <class T>
		HRESULT GetData(T** ppData, DWORD* pdwSize) const;

	private:
		// Disable copying (not possible to copy unless we keep name with the object)
		CMemoryCacheHandle(const CMemoryCacheHandle& rhs);
		CMemoryCacheHandle& operator =(const CMemoryCacheHandle& rhs);

		// Helpers
		HCACHEITEM GetHandle() const;
		void EmptyHandle();
		bool HandleIsEmpty() const;
		HCACHEITEM* GetHandlePointer();
		
		// Debugging
		void AssertValid() const;
		friend class PrePostCondition<thisClass>;

		// Data
		HCACHEITEM m_Handle;
		CComPtr<IMemoryCache> m_spCache;
	};

	///////////////////////////////////////////////////////////////////////////
	// CMemoryCacheHandle Implementation
	///////////////////////////////////////////////////////////////////////////
	inline CMemoryCacheHandle::CMemoryCacheHandle(IMemoryCache* pCache)
			: m_Handle(0), m_spCache(pCache)
	{
		PrePostCondition<thisClass> checker(*this);
	}

	inline CMemoryCacheHandle::~CMemoryCacheHandle()
	{
		PrePostCondition<thisClass> checker(*this);
		Release();
	}
	
	inline HRESULT CMemoryCacheHandle::Acquire(LPCSTR Name)
	{
		PrePostCondition<thisClass> checker(*this);

		return m_spCache->LookupEntry(Name, GetHandlePointer());
	}

	inline HRESULT CMemoryCacheHandle::Release()
	{
		PrePostCondition<thisClass> checker(*this);

		HRESULT hr = S_FALSE;
		if (!HandleIsEmpty())
		{
			hr = m_spCache->ReleaseEntry(GetHandle());
			EmptyHandle();
		}
		return hr;
	}

	inline HRESULT CMemoryCacheHandle::Remove()
	{
		PrePostCondition<thisClass> checker(*this);
		ATLASSERT(!HandleIsEmpty());

		HRESULT hr = S_FALSE;
		if (!HandleIsEmpty())
		{
			hr = m_spCache->RemoveEntry(GetHandle());
			EmptyHandle();
		}
		return hr;
	}

	template <class T>
	inline HRESULT CMemoryCacheHandle::GetData(T** ppData, DWORD* pdwSize) const
	{
		PrePostCondition<thisClass> checker(*this);
		ATLASSERT(!HandleIsEmpty());

		return m_spCache->GetData(GetHandle(), reinterpret_cast<void**>(ppData), pdwSize);
	}

	inline HCACHEITEM CMemoryCacheHandle::GetHandle() const
	{
		PrePostCondition<thisClass> checker(*this);
		return m_Handle;
	}
	
	inline void CMemoryCacheHandle::EmptyHandle()
	{
		PrePostCondition<thisClass> checker(*this);
		m_Handle = 0;
	}

	inline bool CMemoryCacheHandle::HandleIsEmpty() const
	{
		PrePostCondition<thisClass> checker(*this);
		return 0 == m_Handle;
	}

	inline HCACHEITEM* CMemoryCacheHandle::GetHandlePointer()
	{
		PrePostCondition<thisClass> checker(*this);

		Release();
		
		ATLASSERT(HandleIsEmpty());

		return &m_Handle;
	}
	
	inline void CMemoryCacheHandle::AssertValid() const
	{
		ATLASSERT(m_spCache != 0);
	}

	///////////////////////////////////////////////////////////////////////////
	// PrePostCondition Implementation
	///////////////////////////////////////////////////////////////////////////
	template <class T>
	inline PrePostCondition<T>::PrePostCondition(const T& object)
		: m_Object(object)
	{
		m_Object.AssertValid();
	}

	template <class T>
	inline PrePostCondition<T>::~PrePostCondition()
	{
		m_Object.AssertValid();
	}

} // namespace VCUE
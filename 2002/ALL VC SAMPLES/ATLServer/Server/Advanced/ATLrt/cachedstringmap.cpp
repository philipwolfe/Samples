#include "StdAfx.h"
#include "cachedstringmap.h"

CachedStringMap::CachedStringMap(void)
{
}

CachedStringMap::~CachedStringMap(void)
{
}

STDMETHODIMP CachedStringMap::QueryInterface(REFIID riid, void **ppv)
{
	if (!ppv)
	{
		return E_POINTER;
	}

	if (InlineIsEqualGUID(riid, __uuidof(IUnknown)) || 
		InlineIsEqualGUID(riid, __uuidof(IMemoryCacheClient)))
	{
		*ppv = static_cast<IMemoryCacheClient*>(this);
		return S_OK;
    }
	return E_NOINTERFACE;
}

STDMETHODIMP_(ULONG) CachedStringMap::AddRef()
{
	return 1;
}

STDMETHODIMP_(ULONG) CachedStringMap::Release()
{
	return 1;
}

STDMETHODIMP CachedStringMap::Free(const void *pData)
{
	if (!pData)
	{
		return E_POINTER;
	}

	ATLASSERT(*((void **) pData) == static_cast<void*>(this));

	delete this;

	return S_OK;
}

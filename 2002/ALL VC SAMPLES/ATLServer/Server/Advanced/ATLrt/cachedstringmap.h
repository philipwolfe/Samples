#pragma once

#include "stdafx.h"

class CachedStringMap : public IMemoryCacheClient, public StringMap
{
public:
	CachedStringMap(void);
	virtual ~CachedStringMap(void);

	// IMemoryCacheClient
    STDMETHOD(QueryInterface)(REFIID riid, void **ppv);
    STDMETHOD_(ULONG, AddRef)();    
    STDMETHOD_(ULONG, Release)();
    STDMETHOD(Free)(const void *pData);    
};

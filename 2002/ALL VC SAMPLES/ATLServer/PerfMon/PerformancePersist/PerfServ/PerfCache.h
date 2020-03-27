// PerfCache.h
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

// PerfCache.h : Declaration of the CPerfCache

#pragma once
#include "resource.h"       // main symbols


// IPerfCache
[
	object,
	uuid("44347BB4-7D96-45C2-B480-8BBCFFE5DE9E"),
	dual,	helpstring("IPerfCache Interface"),
	pointer_default(unique)
]
__interface IPerfCache : IDispatch
{

	[id(1), helpstring("method CachePerfApp")] HRESULT CachePerfApp([in] BSTR bstrAppName);
};



// CPerfCache

[
	coclass,
	threading("apartment"),
	vi_progid("PerfServ.PerfCache"),
	progid("PerfServ.PerfCache.1"),
	version(1.0),
	uuid("7876487F-92A9-47E9-A3C0-6601D7505506"),
	helpstring("PerfCache Class")
]
class ATL_NO_VTABLE CPerfCache : 
	public IPerfCache
{
public:
	CPerfCache()
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

	STDMETHOD(CachePerfApp)(BSTR bstrAppName);
};


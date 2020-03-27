// File: CmdInfoFactory.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "stdafx.h"

typedef CAtlArray<DWORD> DWordVector;

// CmdInfo stores the parameters as well as the SQL call string for a given stored procedure
class CmdInfo : public IMemoryCacheClient
{
public:
	DWordVector paramTypes;
	CStringA	cmdCallString;

	// IMemoryCacheClient
    STDMETHOD(QueryInterface)(REFIID riid, void **ppv)
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

    STDMETHOD_(ULONG, AddRef)()
	{
		return 1;
	}

    STDMETHOD_(ULONG, Release)()
	{
		return 1;
	}

    STDMETHOD(Free)(const void *pData)
	{
		if (!pData)
		{
			return E_POINTER;
		}

		ATLASSERT(*((void **) pData) == static_cast<void*>(this));

		delete this;

		return S_OK;
	}
};

// CmdInfoFactory abstracts the creation of CmdInfo.  Creating a CmdInfo is quite expensive and 
// relatively complicated.  We use this class to hide the creation details of CmdInfo, and we use
// it to hide the fact that we might cache CmdInfo objects.
class CmdInfoFactory
{
public:
	CmdInfoFactory(IMemoryCache	*cmdInfoCache);
	virtual ~CmdInfoFactory(void);

	HRESULT GetCmdInfo(	CStringA&		cmdName,
						CStringA&		connectionString, 						
						const CSession	&datasource, 
						CmdInfo			**cmdInfo, 
						bool&			infoFromCache);
private:
	HRESULT CreateAndStoreCmdInfo(const CSession&		session,								  
								  CString&				cmdName,
								  CString&				connectionString,
								  CmdInfo**				cmdInfo,
								  bool&					infoFromCache);

	HRESULT BuildCmdStringAndParams(CProcedureParameters&	procInfo,
									CString&				cmdName,
									CmdInfo*				cmdInfo);
private:
	IMemoryCache *m_cmdInfoCache;	
};

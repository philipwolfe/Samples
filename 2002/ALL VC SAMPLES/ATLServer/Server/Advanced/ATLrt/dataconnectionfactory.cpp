// File: dataconnectionfactory.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "StdAfx.h"
#include "DataConnectionFactory.h"
#include "Trace.h"

DataConnectionFactory::DataConnectionFactory(IDataSourceCache *cache)
{
	Trace::TraceMsg("DataConnectionFactory constructor");
	m_cache = cache;
}

DataConnectionFactory::~DataConnectionFactory(void)
{
	Trace::TraceMsg("DataConnectionFactory destructor");
}

HRESULT DataConnectionFactory::GetDataConnection(CStringA&			connectionString, 												 
												 CDataConnection&	datasource,
												 bool&				fromCache)
{
	HRESULT hr = S_OK;
	fromCache = false;

	if (m_cache != NULL)
	{		
		// calling Add will either create and return the data source, or it
		// will return the existing one in the cache
		hr = m_cache->Add(connectionString, CComBSTR(connectionString), &datasource);

		ASSERT(!FAILED(hr));
		if (FAILED(hr))
		{
			// if we failed here, that means that we could not add a new connection, there
			// is nothing we can do at this point, just return the failing hr

			Trace::TraceMsg("DataConnectionFactory GetDataConnection could not add a new connection");
			return hr;			 
		}

		// indicate that we got a data connection from the cache
		fromCache = true;
	}
	else
	{
		// if we weren't given a cache to use, just open the data connection normally
		// leave the fromCache flag as false
		hr = datasource.Open(CComBSTR(connectionString));

		ASSERT(!FAILED(hr));
		if (FAILED(hr))
		{
			// we can't open the data connection
			Trace::TraceMsg("DataConnectionFactory GetDataConnection we can't open the data connection");
			return hr;
		}
	}

	return hr;	
}
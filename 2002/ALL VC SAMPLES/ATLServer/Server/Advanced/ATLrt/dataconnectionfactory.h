// File: dataconnectionfactory.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "stdafx.h"

// DataConnectionFactory is used to construct (or retrieve) CDataConnection objects.
// This class can be created to use a cache, or not use one.  By having this class as a layer
// of abstraction, we can easily turn on or off data connection caching, without having to change
// our calling code. 
class DataConnectionFactory
{
public:
	DataConnectionFactory(IDataSourceCache *cache = NULL);
	~DataConnectionFactory(void);

	HRESULT GetDataConnection(	CStringA&			connectionString, 							
								CDataConnection&	datasource,
								bool&				fromCache);

private:
	IDataSourceCache *m_cache;
};

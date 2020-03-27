// File: NoopBuilder.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "stdafx.h"
#include "IResultsBuilder.h"

// NoopBuilder is an empty implementation of IResultsBuilder.  We used this class during testing.
class NoopBuilder :
	public IResultsBuilder
{
public:
	NoopBuilder(void);
	virtual ~NoopBuilder(void);

	// IResultsBuilder methods
	virtual void AddColumnValue(CStringA& value);
	virtual void SetReturnValue(CStringA& value);
	virtual void AddOutputParamValue(CStringA& value);
	virtual void DoneRow();
	virtual void DoneResultSet();
};

// File: IResultsBuilder.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "stdafx.h"

// IResultsBuilder is the interface that DBCommand interacts with to store results.  For example,
// as a DBCommand object interates over the results from a stored procedure, it calls AddColumnValue for
// each column result.  When a row of results if finished, DoneRow() is called.  This abstraction allows 
// us to substitute various storage implementations for our results.
class IResultsBuilder
{
public:	
	virtual void AddColumnValue(CStringA& value)= 0;
	virtual void SetReturnValue(CStringA& value)= 0;
	virtual void AddOutputParamValue(CStringA& value)= 0;	
	virtual void DoneRow()= 0;
	virtual void DoneResultSet()= 0;
};
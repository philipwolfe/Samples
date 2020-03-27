// File: ColumnValues.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "stdafx.h"
#include "Trace.h"

// ColumnValues is a light wrapper around CAtlArray.  It is used to store and access
// column values from the results of a stored procedure.
class ColumnValues : protected CAtlArray<CStringA>
{
public:
	ColumnValues();
	ColumnValues(const ColumnValues& c);

	~ColumnValues();
	
	const CStringA& GetColumnValue(int index) const;	
	void AddColumnValue(CStringA& value);
	int GetNumColumns() const;
	void Reset();
	
	ColumnValues& operator=(const ColumnValues& c);	
};
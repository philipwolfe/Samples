// File: RowValues.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "stdafx.h"
#include "ColumnValues.h"
#include "Trace.h"

// RowValues is a light wrapper around CAtlArray.  It is used to store and access
// row values from the results of a stored procedure.
class RowValues : protected CAtlArray<ColumnValues>
{
public:
	RowValues();
	RowValues(const RowValues& c);	
	
	~RowValues();
	
	const ColumnValues& GetRowValue(int index) const;	
	void AddRowValue(const ColumnValues& columnValues);
	void Reset();
	int GetNumRows() const;

	RowValues& operator=(const RowValues& p);
};

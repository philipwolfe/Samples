// File: RowValues.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "Stdafx.h"
#include "RowValues.h"

RowValues::RowValues() : CAtlArray<ColumnValues>()	
{
	Trace::TraceMsg("RowValues constructor");
}

RowValues::RowValues(const RowValues& c)
{
	// do a deep copy
	Trace::TraceMsg("RowValues copy constructor");
			
	int num = c.GetCount();
	
	for (int i = 0; i < num; i++)
	{						
		Add(c[i]);
	}		
}

RowValues::~RowValues()
{
	Trace::TraceMsg("RowValues destructor");		
	RemoveAll();
}

const ColumnValues& RowValues::GetRowValue(int index) const
{				
	return GetAt(index);		
}

void RowValues::AddRowValue(const ColumnValues& columnValues)
{		
	Add(columnValues);		
}

int RowValues::GetNumRows() const
{
	return GetCount();
}

void RowValues::Reset()
{
	RemoveAll();
}

// need to override = operator to make a deep copy
RowValues& RowValues::operator=(const RowValues& p)
{
	Trace::TraceMsg("RowValue = operator");

	RemoveAll();
	int num = p.GetCount();
	for (int i = 0; i < num; i++)
	{
		Add(p[i]);
	}

	return (*this);
}	
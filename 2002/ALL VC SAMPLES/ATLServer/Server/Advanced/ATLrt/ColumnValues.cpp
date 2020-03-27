// File: ColumnValues.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "Stdafx.h"
#include "ColumnValues.h"

ColumnValues::ColumnValues() : CAtlArray<CStringA>()
{
	Trace::TraceMsg("ColumnValues constructor");		
}

ColumnValues::ColumnValues(const ColumnValues& c)
{
	// do a deep copy
	Trace::TraceMsg("ColumnValues copy constructor");
			
	int num = c.GetCount();
	
	for (int i = 0; i < num; i++)
	{						
		Add(c[i]);
	}		
}

ColumnValues::~ColumnValues()
{
	Trace::TraceMsg("ColumnValues destructor");
	RemoveAll();
}

const CStringA& ColumnValues::GetColumnValue(int index) const
{		
	return GetAt(index);
}

void ColumnValues::AddColumnValue(CStringA& value)
{		
	Add(value);
}	

void ColumnValues::Reset()
{
	RemoveAll();
}

int ColumnValues::GetNumColumns() const
{
	return GetCount();
}

ColumnValues& ColumnValues::operator=(const ColumnValues& c)
{
	// do a deep copy
	Trace::TraceMsg("ColumnValues = operator");
	
	RemoveAll();			
	int num = c.GetCount();

	for (int i = 0; i < num; i++)
	{						
		Add(c[i]);
	}

	return (*this);
}
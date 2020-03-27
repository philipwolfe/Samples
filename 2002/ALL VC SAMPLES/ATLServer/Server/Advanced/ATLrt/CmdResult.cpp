// File: CmdResult.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "CmdResult.h"

CmdResult::CmdResult()
{
	Trace::TraceMsg("CmdResult constructor");	
	m_rowIndex = 0;	
	m_colIndex = 0;
	m_isFirstRow = true;
	m_isFirstCol = true;
}

CmdResult::CmdResult(const CmdResult& c)
{
	Trace::TraceMsg("CmdResult copy constructor");
	
	m_rowIndex = c.m_rowIndex;
	m_colIndex = c.m_colIndex;
	m_isFirstRow = c.m_isFirstRow;
	m_isFirstCol = c.m_isFirstCol;

	int num = c.GetRowValues().GetNumRows();
	
	for (int i = 0; i < num; i++)
	{		
		m_rowValues.AddRowValue(c.GetRowValues().GetRowValue(i));
	}
}

CmdResult::~CmdResult()
{
	Trace::TraceMsg("CmdResult destructor");
	
	m_rowValues.Reset();		
}	

void CmdResult::SetRowValues(const RowValues& rowValues)
{
	m_rowValues = rowValues;
}

const CString& CmdResult::GetColumnValue(int columnIndex) const
{
	// get the column value at the current row
	return m_rowValues.GetRowValue(m_rowIndex).GetColumnValue(columnIndex);
}

const CString& CmdResult::GetColumnValue() const
{
	// get the column value at the current row and the current column
	return m_rowValues.GetRowValue(m_rowIndex).GetColumnValue(m_colIndex);
}

const RowValues& CmdResult::GetRowValues() const
{
	return m_rowValues;
}

void CmdResult::ResetRows()
{
	m_isFirstRow = true;
	m_rowIndex = 0;
}

void CmdResult::ResetColumns()
{	
	m_isFirstCol = true;
	m_colIndex = 0;
}

void CmdResult::Close()
{
	m_rowValues.Reset();
}

int CmdResult::GetCurrentRow() const
{
	return m_rowIndex;
}

int CmdResult::GetCurrentColumn() const
{
	return m_colIndex;
}

bool CmdResult::MoveNextColumn()
{		
	if (m_isFirstCol)
		m_isFirstCol = false;
	else
		m_colIndex++;
	
	if (m_colIndex == m_rowValues.GetRowValue(m_rowIndex).GetNumColumns())
	{
		ResetColumns();
		return false;
	}
	else
	{
		return true;
	}
}	

bool CmdResult::MoveNextRow()
{		
	if (m_isFirstRow)
		m_isFirstRow = false;
	else
		m_rowIndex++;
	
	if (m_rowIndex == m_rowValues.GetNumRows())
	{
		ResetRows();
		return false;
	}
	else
	{
		return true;
	}
}	

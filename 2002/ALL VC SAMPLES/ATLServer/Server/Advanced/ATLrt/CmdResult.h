// File: CmdResult.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "stdafx.h"
#include "RowValues.h"
#include "Trace.h"

// CmdResult is the class that our concrete implementation of IResultsBuilder (ResultSetBuilder)
// uses to store results from a stored procedure.
class CmdResult
{	
public:
	CmdResult();
	CmdResult(const CmdResult& c);
	
	~CmdResult();

	void SetRowValues(const RowValues& rowValues);
	const CString& GetColumnValue(int columnIndex) const;
	const CString& GetColumnValue() const;
	const RowValues& GetRowValues() const;

	int GetCurrentRow() const;
	int GetCurrentColumn() const;
	
	void ResetColumns();
	void ResetRows();

	bool MoveNextRow();
	bool MoveNextColumn();

	void Close();

private:

	RowValues	m_rowValues;
	int			m_rowIndex;
	int			m_colIndex;
	bool		m_isFirstRow;
	bool		m_isFirstCol;
};

// File: ResultSetBuilder.h
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
#include "Trace.h"
#include "ColumnValues.h"
#include "RowValues.h"
#include "CmdResult.h"
#include "CmdResultsMap.h"

// ResultSetBuilder is our concrete implementation of IResultsBuilder.
class ResultSetBuilder : public IResultsBuilder
{
public:
	ResultSetBuilder(StringList *resultNames, 
					 StringList *outputParamNames, 
					 StringMap	*variableMap);

	virtual ~ResultSetBuilder(void);

	virtual void GetResults(CmdResultsMap& resultSet);

	// IResultsBuilder methods
	virtual void AddColumnValue(CStringA& value);
	virtual void SetReturnValue(CStringA& value);
	virtual void AddOutputParamValue(CStringA& value);
	virtual void DoneRow();
	virtual void DoneResultSet();
private:		
	StringList				*m_resultNames;
	StringList				*m_outputParamNames;
	StringMap				*m_pVariableMap;	
	CmdResultsMap			m_resultSets;	
		
	POSITION				m_outputParamNamesBegin;
	POSITION				m_resultNamesBegin;
	
	ColumnValues			m_currentColumn;
	RowValues				m_currentRow;		
	CStringA				m_currResultName;
};

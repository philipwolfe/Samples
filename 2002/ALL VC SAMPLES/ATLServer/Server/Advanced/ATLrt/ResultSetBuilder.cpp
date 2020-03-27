// File: ResultSetBuilder.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "StdAfx.h"
#include "resultsetbuilder.h"

ResultSetBuilder::ResultSetBuilder(StringList *resultNames,
								   StringList *outputParamNames,
								   StringMap *variableMap)
{		
	Trace::TraceMsg("ResultSetBuilder constructor");

	ASSERT(resultNames		!= NULL);
	ASSERT(outputParamNames != NULL);
	ASSERT(variableMap		!= NULL);
	
	m_resultNames			= resultNames;
	m_outputParamNames		= outputParamNames;
	m_pVariableMap			= variableMap;

	m_outputParamNamesBegin = m_outputParamNames->GetHeadPosition();	
	m_resultNamesBegin		= m_resultNames->GetHeadPosition();
	
	m_pVariableMap = variableMap;	
}

ResultSetBuilder::~ResultSetBuilder(void)
{
	Trace::TraceMsg("ResultSetBuilder destructor");
}

void ResultSetBuilder::AddColumnValue(CStringA& value)
{			
	m_currentColumn.AddColumnValue(value);	
}

void ResultSetBuilder::DoneRow()
{
	// add our row
	m_currentRow.AddRowValue(m_currentColumn);
	m_currentColumn.Reset();
}

void ResultSetBuilder::SetReturnValue(CStringA& value)
{	
	// add it to our variable map
	m_pVariableMap->SetAt(m_currResultName + "_return", value);	
}

void ResultSetBuilder::AddOutputParamValue(CStringA& value)
{		
	m_pVariableMap->SetAt(m_outputParamNames->GetNext(m_outputParamNamesBegin), value);			
}

void ResultSetBuilder::DoneResultSet()
{
	// add the current result set to our list
	CmdResult result;
	result.SetRowValues(m_currentRow);	

	if (m_resultNamesBegin == NULL)
	{
		// We'll get here when the caller has not specified enough
		// result names for the command
		// to get around the issue we'll construct a default name

		CStringA defaultName;
		defaultName.Format("%s_%i", m_currResultName, m_resultSets.GetCount());

		m_resultSets.SetAt(defaultName, result);
	}
	else
	{
		m_currResultName = m_resultNames->GetNext(m_resultNamesBegin);
		m_resultSets.SetAt(m_currResultName, result);
	}
	
	// reset our current result buffers
	m_currentRow.Reset();
}

void ResultSetBuilder::GetResults(CmdResultsMap& resultSet)
{
	int count = m_resultSets.GetCount();
	if (m_resultSets.GetCount() == 0)
	{
		// this happens if there were no results for a query
		// we'll call DoneResultSet() ourselves to create an empty 
		// result set
		DoneResultSet();
	}
	resultSet = m_resultSets;
}
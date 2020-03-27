// File: dbcommand.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "stdafx.h"
#include "ResultSetBuilder.h"
#include "DataConnectionFactory.h"
#include "CmdInfoFactory.h"

#define MAX_SIZE 4096

// MYBIND is used to bind to parameters and column results of a stored procedure.
struct MYBIND
{	
	MYBIND()
	{
		Trace::TraceMsg("MYBIND constructor");
		memset(this, 0, sizeof(MYBIND));
	}

	~MYBIND()
	{
		Trace::TraceMsg("MYBIND destructor");
	}
	
	TCHAR   szValue[MAX_SIZE];
	DWORD	dwStatus;
};

typedef CCommand<CManualAccessor, CRowset, CMultipleResults> CommandType;

// DBCommand is the class that allows us to execute a stored procedure on a database and get back
// the results.
class DBCommand
{
public:
	DBCommand(IResultsBuilder*			builder,
			  DataConnectionFactory*	dataConnectionFactory,
			  CmdInfoFactory*			cmdInfoFactory);
	
	virtual ~DBCommand(void);

	HRESULT Execute(CStringA&		  cmdName, 
					CStringA&		  connectionString,
					StringList&		  inputParams);	

private:	
	IResultsBuilder			*m_resultBuilder;
	DataConnectionFactory	*m_dataConnectionFactory;
	CmdInfoFactory			*m_cmdInfoFactory;

private:
	HRESULT ExecuteCommand(const CSession&	session,						   
						   CmdInfo			*cmdInfo,						   
						   StringList&		inputParams);

	HRESULT GetResults(CommandType& command, int numParams);

	void IterateRowset(CommandType&		command, 
					   ULONG			ulColumns, 
					   struct MYBIND	*pBind);		    
};
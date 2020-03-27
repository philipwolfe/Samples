// File: CmdInfoFactory.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "StdAfx.h"
#include "cmdinfofactory.h"
#include "Trace.h"

CmdInfoFactory::CmdInfoFactory(IMemoryCache	*cmdInfoCache)
{
	Trace::TraceMsg("CmdInfoFactory constructor");
	
	m_cmdInfoCache = cmdInfoCache;
}

CmdInfoFactory::~CmdInfoFactory(void)
{
	Trace::TraceMsg("CmdInfoFactory destructor");
}

HRESULT CmdInfoFactory::GetCmdInfo(	CStringA&		cmdName,
									CStringA&		connectionString, 	
									const CSession  &session, 
									CmdInfo			**cmdInfo, 
									bool&			infoFromCache)
{	
	HRESULT hr = S_OK;

	if (m_cmdInfoCache == NULL)
	{
		hr = CreateAndStoreCmdInfo(	session, 									
									cmdName, 
									connectionString, 
									cmdInfo, 
									infoFromCache);
		
		ASSERT(!FAILED(hr));
		if (FAILED(hr))
		{
			// if we can't get cmd information, nothing to do but return
			return hr;
		}		
	}
	else
	{
		// we do have a cache, see if our cmd info is in it
		HCACHEITEM hEntry = NULL;
		if (SUCCEEDED(m_cmdInfoCache->LookupEntry(cmdName + connectionString, &hEntry)))
		{
			DWORD dwSize = 0;	
			hr = m_cmdInfoCache->GetData(hEntry, (void**)cmdInfo, &dwSize);
			
			ASSERT(cmdInfo != NULL);
			ASSERT(*cmdInfo != NULL);			
			if (cmdInfo == NULL || *cmdInfo == NULL)
			{
				// we got bad data back from the cache
				if (hEntry)
				{
					m_cmdInfoCache->ReleaseEntry(hEntry);
				}
				return E_FAIL;
			}

			if (FAILED(hr))
			{
				// if we couldn't get the command info from the cache, create it
				// ourselves
				hr = CreateAndStoreCmdInfo( session, 											
											cmdName, 
											connectionString, 
											cmdInfo, 
											infoFromCache);
		
				ASSERT(!FAILED(hr));
				if (FAILED(hr))
				{
					// if we can't get cmd information, nothing to do but return
					if (hEntry)
					{
						m_cmdInfoCache->ReleaseEntry(hEntry);
					}
					return hr;
				}		
			}
			else
			{
				// getting here means we got our cmd information from the 
				// cache successfully, all we have to do is set the flag
				// so nobody deletes this value
				infoFromCache = true;				
			}
			if (hEntry)
			{
				m_cmdInfoCache->ReleaseEntry(hEntry);
			}
		}
		else
		{
			// if there was nothing in the cache, we'll have to create things on our own
			hr = CreateAndStoreCmdInfo( session, 										
										cmdName, 
										connectionString, 
										cmdInfo, 
										infoFromCache);
		
			ASSERT(!FAILED(hr));
			if (FAILED(hr))
			{
				// if we can't get cmd information, nothing to do but return
				return hr;
			}		
		}
	}	
	return hr;
}

HRESULT CmdInfoFactory::BuildCmdStringAndParams(CProcedureParameters&	procInfo,
												CString&				cmdName,
												CmdInfo*				cmdInfo)
{
	HRESULT hr = S_OK;

	// go through each parameter and build our call string	
	bool first = true;
	
	CStringA strTemp("? = ");
	CStringA strCmd;
	strCmd.Format("Call %s ", cmdName);

	while (procInfo.MoveNext() == S_OK)
	{			
		// store the type of the parameter
		cmdInfo->paramTypes.Add((WORD)procInfo.m_nType);		
		
		// build the parameter list part of our cmd call string
		switch (procInfo.m_nType)
		{
			case DBPARAMTYPE_RETURNVALUE:
				strTemp += strCmd;
				strCmd  = strTemp;				
				break;

			case DBPARAMTYPE_INPUT:
			case DBPARAMTYPE_INPUTOUTPUT:		
			case DBPARAMTYPE_OUTPUT:
				if (first)
				{
					strCmd += "(?";
					first  = false;
				}
				else
					strCmd += ", ?";
				break;
			default:
				break;
		}
	}
	if (!first)
		strCmd += ")";

	cmdInfo->cmdCallString.Format("{ %s }", strCmd);
	
	return hr;
}

HRESULT CmdInfoFactory::CreateAndStoreCmdInfo(const CSession&		session,												
											  CString&				cmdName,
											  CString&				connectionString,
											  CmdInfo**				cmdInfo,
											  bool&					infoFromCache)
{
	ASSERT(cmdInfo != NULL);
	if (cmdInfo == NULL)
	{
		return E_FAIL;
	}

	HRESULT hr = S_OK;

	*cmdInfo = new CmdInfo();	
	ASSERT(*cmdInfo);
	if (!cmdInfo)
	{
		// not much we can do here
		return E_OUTOFMEMORY;
	}

	infoFromCache = false;
	
	// connect to get information about our stored procedure
	CProcedureParameters procInfo;
	hr = procInfo.Open(session, NULL, NULL, cmdName);

	ASSERT(!FAILED(hr));
	if (FAILED(hr))
	{
		// if we can't get cmd information, nothing to do but return		
		Trace::TraceMsg("CmdInfoFactory CreateAndStoreCmdInfo can't get cmd information");		
		return hr;
	}

	// get our cmd info
	hr = BuildCmdStringAndParams(procInfo, cmdName, *cmdInfo);
	
	ASSERT(!FAILED(hr));
	if (FAILED(hr))
	{		
		// nothing we can do, we just can't get cmd info
		Trace::TraceMsg("CmdInfoFactory CreateAndStoreCmdInfo nothing we can do, we just can't get cmd info");
		return hr;
	}
	
	if (m_cmdInfoCache != NULL)
	{
		// try to add this info into the cache			
		if (SUCCEEDED(m_cmdInfoCache->Add((LPCSTR)(cmdName + connectionString),
										 (void*)*cmdInfo,
										 sizeof(CmdInfo),
										 NULL,
										 NULL,
										 NULL,
										 *cmdInfo)))
		{
			Trace::TraceMsg("CmdInfoFactory CreateAndStoreCmdInfo cmd info not in cache");
	
			// set this flag so nobody will delete cmdInfo
			infoFromCache = true;
		}		
	}
	else
	{
		Trace::TraceMsg("CmdInfoFactory CreateAndStoreCmdInfo no cache to use");

		// we don't have a cache to use
		infoFromCache = false;
	}

	procInfo.Close();
	procInfo.ClearRecordMemory();
	procInfo.FreeRecordMemory();

	return hr;
}

	
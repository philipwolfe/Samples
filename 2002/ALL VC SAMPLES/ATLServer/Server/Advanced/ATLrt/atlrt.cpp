// atlrt.cpp : Defines the entry point for the DLL application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
// For custom assert and trace handling with WebDbg.exe
#ifdef _DEBUG
CDebugReportHook g_ReportHook;
#endif

#include "atlrt.h"
[ module(name="atlrt", type="dll") ];
[ emitidl(restricted) ];

#include "atlrtextension.h"

StringMap* CATLRTHandler::m_stringmap = new StringMap();

HTTP_CODE CATLRTHandler::ValidateAndExchange()
{				
	Trace::TraceMsg("CATLRTHandler ValidateAndExchange");

	size_t count = m_stringmap->GetCount();
	m_stringmap->SetAt("hello", "world");
	count = m_stringmap->GetCount();

	// get the IMemoryCache service from the ISAPI extension
	if (FAILED(m_spServiceProvider->QueryService(__uuidof(IMemoryCache), 
					__uuidof(IMemoryCache), (void **)&m_spBinaryCache)))
		return HTTP_FAIL;

	// get the IDataSourceCache service from the ISAPI extension
	if (FAILED(m_spServiceProvider->QueryService(__uuidof(IDataSourceCache), 
					__uuidof(IDataSourceCache), (void **)&m_spDataSrcCache)))
		return HTTP_FAIL;
	
	// get or create our variable map	
	HCACHEITEM cacheHandle;
	HRESULT hr = m_spBinaryCache->LookupEntry(VARIABLE_MAP, &cacheHandle);
	if (FAILED(hr))
	{
		// we need to create a variable map
		m_variableMap = new CachedStringMap();
		ASSERT(m_variableMap);
		if (!m_variableMap)
		{
			// there isn't much we can do at this point, just return a failing HTTP_CODE
			return HTTP_S_FALSE;
		}
		
		hr = m_spBinaryCache->Add(VARIABLE_MAP, 
								  (void*)m_variableMap,
								  sizeof(CachedStringMap),
								  NULL,
								  NULL,
								  NULL,
								  m_variableMap);
		if (FAILED(hr))
		{
			Trace::TraceMsg("CATLRTHandler ValidateAndExchange can't create variable map!");
			return HTTP_S_FALSE;
		}
	}
	else
	{
		// get the variable map pointer from the cache
		DWORD dwSize = 0;	
		hr = m_spBinaryCache->GetData(cacheHandle, (void**)&m_variableMap, &dwSize);
		
		if (FAILED(hr) || !m_variableMap)
		{
			Trace::TraceMsg("CATLRTHandler ValidateAndExchange can't get variable map!");
			return HTTP_S_FALSE;
		}

		// release our cache handle
		m_spBinaryCache->ReleaseEntry(cacheHandle);
	}	

	// get or create our connection time	
	hr = m_spBinaryCache->LookupEntry(CONNECTION_MAP, &cacheHandle);
	if (FAILED(hr))
	{	
		// we need to create a connection map
		m_connectionMap = new CachedStringMap();
		ASSERT(m_connectionMap);
		if (!m_connectionMap)
		{
			// there isn't much we can do at this point, just return a failing HTTP_CODE
			return HTTP_S_FALSE;
		}

		hr = m_spBinaryCache->Add(CONNECTION_MAP, 
								  (void*)m_connectionMap,
								  sizeof(CachedStringMap),
								  NULL,
								  NULL,
								  NULL,
								  m_connectionMap);
		if (FAILED(hr))
		{
			Trace::TraceMsg("CATLRTHandler ValidateAndExchange can't create connection map!");
			return HTTP_S_FALSE;
		}
	}
	else
	{
		// get the variable map pointer from the cache
		DWORD dwSize = 0;	
		hr = m_spBinaryCache->GetData(cacheHandle, (void**)&m_connectionMap, &dwSize);
		
		if (FAILED(hr) || !m_connectionMap)
		{
			Trace::TraceMsg("CATLRTHandler ValidateAndExchange can't get connection map!");
			return HTTP_S_FALSE;
		}

		// release our cache handle
		m_spBinaryCache->ReleaseEntry(cacheHandle);
	}
		
	return HTTP_SUCCESS;
}
 
HTTP_CODE CATLRTHandler::Uninitialize(HTTP_CODE hcError) throw( )
{
	Trace::TraceMsg("CATLRTHandler Uninitialize");
	
	return HTTP_SUCCESS;
}

/////////////////////////////////////////////////////////////////////
// Variable Map Operations
/////////////////////////////////////////////////////////////////////	
HTTP_CODE CATLRTHandler::OnGetValue(TCHAR *szVariableName)
{	
	ASSERT(szVariableName);
	if (szVariableName == NULL) 
		return HTTP_SUCCESS;

	LPCSTR szValue = NULL;

	// try to find the variable value in our variable map or in the request parameters
	szValue = _GetValue(CStringA(szVariableName));

	// if we got a value from either place, output it
	if (szValue != NULL)
	{
		m_HttpResponse << szValue;				
	}

	return HTTP_SUCCESS;
}

HTTP_CODE CATLRTHandler::OnCopyValue(TCHAR *szArgs)
{
	ASSERT(szArgs);
	if (!szArgs)
		return HTTP_SUCCESS;

	ArgParser parser;

	if (!parser.Parse(szArgs))
		return HTTP_SUCCESS;

	// need 'source' and 'dest' attributes
	CStringA source;
	CStringA dest;
	
	if (parser.GetAttribute("source", source) != 1)
		return HTTP_SUCCESS;

	if (parser.GetAttribute("dest", dest) != 1)
		return HTTP_SUCCESS;

	// get the value specified by source
	LPCSTR szSourceValue = _GetValue(source);

	if (!szSourceValue)
		return HTTP_SUCCESS;

	// insert this value into the destination name	
	m_variableMap->SetAt(dest, szSourceValue);

	return HTTP_SUCCESS;
}

HTTP_CODE CATLRTHandler::OnContainsValue(TCHAR *szName)
{	
	if (!szName)
		return HTTP_S_FALSE;

	if (!_GetValue(CStringA(szName)))
		return HTTP_S_FALSE;
	else
		return HTTP_SUCCESS;	
}

HTTP_CODE CATLRTHandler::OnCompareValue(TCHAR *szArgs)
{
	if (!szArgs)
		return HTTP_S_FALSE;

	ArgParser parser;

	if (!parser.Parse(szArgs))
		return HTTP_S_FALSE;

	// get the 'name' and 'value' attributes, both are required
	CStringA name;
	CStringA value;

	if (parser.GetAttribute("name", name) != 1)
		return HTTP_S_FALSE;

	if (parser.GetAttribute("value", value) != 1)
		return HTTP_S_FALSE;

	// get the value specified by 'name1'
	LPCSTR szValue1 = _GetValue(name);
	
	if (!szValue1)
		return HTTP_S_FALSE;

	// compare the values	
	if (strcmp(szValue1, value) != 0)
	{	
		return HTTP_S_FALSE;
	}
	else
	{
		return HTTP_SUCCESS;
	}
}

HTTP_CODE CATLRTHandler::OnMaintainValue(TCHAR *szArgs)
{	
	if (!szArgs)
		return HTTP_SUCCESS;

	ArgParser parser;

	CStringA var_name;
	CStringA state_name;

	// see if we have an arg list (ie. a=b;c=d)
	if (!parser.Parse(szArgs)) // if we don't, use the whole CStringA as the name
	{		
		var_name = szArgs;
		state_name = szArgs;
	}
	else // if we do, parse out the values
	{		
		if (parser.GetAttribute("name", var_name) != 1)
			return HTTP_SUCCESS;

		if (parser.GetAttribute("save_as", state_name) != 1)
			return HTTP_SUCCESS;
	}

	// get the value specified by var_name
	LPCSTR szValue = _GetValue(var_name);

	if (!szValue)
		return HTTP_SUCCESS;

	// save this value as a hidden input field
	CStringA hiddenField;
	hiddenField.Format("<input type=\"hidden\" value=\"%s\" name=\"%s\">", szValue, state_name);
	
	m_HttpResponse << hiddenField;

	return HTTP_SUCCESS;
}

/////////////////////////////////////////////////////////////////////
// Database Operations
/////////////////////////////////////////////////////////////////////
HTTP_CODE CATLRTHandler::OnSetConnection(TCHAR *szArgs)
{
	if (!szArgs)
	{
		m_HttpResponse << "ERROR: missing argument CStringA";			
		m_HttpResponse << USEAGE_SETCONNECTION;

		return HTTP_SUCCESS;
	}
	ArgParser parser;

	// look for server, 
	CStringA name;
	CStringA conn;

	if (!parser.Parse(szArgs))
	{
		name = DEFAULT_CONNECTION;

		// we have to treat this string carefully, if there are enclosing quotes, then 
		// these quotes have to be removed		
		if (*szArgs == '\"')
		{			
			int length = strlen(szArgs);

			// we don't want the first and last characters in szArgs, which are "'s
			for (int i = 1; i < length - 1; i++)
			{	
				conn += szArgs[i];
			}	
		}
		else
		{
			conn = szArgs;		
		}
	}
	else
	{
		if (parser.GetAttribute("name", name) != 1)
		{
			m_HttpResponse << "ERROR: missing name attribute";			
			m_HttpResponse << USEAGE_SETCONNECTION;

			return HTTP_SUCCESS;
		}
		if (parser.GetAttribute("conn", conn) != 1)
		{
			m_HttpResponse << "ERROR: missing conn attribute";
			m_HttpResponse << USEAGE_SETCONNECTION;

			return HTTP_SUCCESS;
		}
	}

	// put the connection CStringA into our map
	m_connectionMap->SetAt(name, conn);

	return HTTP_SUCCESS;
}

HTTP_CODE CATLRTHandler::OnExecute(TCHAR *szArgs)
{
	if (!szArgs)
		return HTTP_S_FALSE;

	// look for:
	// cmd (required)
	// conn (optional, default to 'default_connection'
	// results (optional, default to 'default_result'
	// input_params (optional)
	// output_params (optional)
	
	ArgParser parser;

	if (!parser.Parse(szArgs))
		return HTTP_S_FALSE;

	CStringA cmd;
	if (parser.GetAttribute("cmd", cmd) != 1)
		return HTTP_S_FALSE;

	CStringA conn;
	if (parser.GetAttribute("conn", conn) != 1)
		conn = DEFAULT_CONNECTION;

	// we could have multiple result names or none at all
	StringList resultNames;
	parser.GetAttribute("results", resultNames);

	// set a default value if we don't have any result names
	if (resultNames.GetCount() == 0)
		resultNames.AddTail(DEFAULT_RESULTS);

	// we could have multiple input parameter names or none at all
	Params inputParamNames;
	StringList inputParams;
	parser.GetAttribute("params", inputParamNames);
		
	int inputParamCount = inputParamNames.GetCount();
	if (inputParamCount > 0)
	{
		// resolve our parameter values
		if (_ResolveParameters(inputParamNames, inputParams) <= 0)
		{
			// just get out of here, _ResolveParameters has already outputted
			// an error message
			// return HTTP_S_FALSE to stop processing so we don't crash
			// on calls that depend on this function succeeding
			return HTTP_S_FALSE;
		}
	}

	// we could have multiple output parameter names or none at all
	StringList outputParams;
	parser.GetAttribute("output_params", outputParams);

	// create a builder to add to our cmd results map
	ResultSetBuilder builder(&resultNames, &outputParams, m_variableMap);

	// create a data connection factory that will hide all the 
	// data cache pooling and creation details
	DataConnectionFactory dataConnectionFactory(m_spDataSrcCache);

	// create a cmd info factory that will hide all the details
	// involving getting information about a stored procedure
	CmdInfoFactory cmdInfoFactory(m_spBinaryCache);

	// execute our command	
	DBCommand command(&builder, &dataConnectionFactory, &cmdInfoFactory);

	HRESULT hr;
	if (FAILED((hr = command.Execute(	cmd,
										(*m_connectionMap)[conn],
										inputParams))))
	{
		// we could not execute the stored proc, tell the user and
		// get out of here
		m_HttpResponse << "execute command: " << cmd << " failed" << " " << hr;

		// return HTTP_S_FALSE to stop processing so we don't crash
		// on calls that depend on this function succeeding
		return HTTP_S_FALSE;
	}
	
	// if we succeeded, get the results
	builder.GetResults(m_resultsMap);

	return HTTP_SUCCESS;
}

HTTP_CODE CATLRTHandler::OnMoveNextRow(TCHAR *szArgs)
{	
	CStringA resultsName;

	if (!szArgs)
	{
		// if we get a NULL argument, use 'DEFAULT_RESULTS' as the results name		
		resultsName = DEFAULT_RESULTS;
	}
	else
	{
		// otherwise, take the whole argument string as the result name
		resultsName = szArgs;		
	}

	// if we get here, then we have a valid results name, either the default or
	// the one the user specified
	// see if we have a CmdResult using this results name as the key

	if (!_CheckForResults(resultsName))
	{
		// getting here means we have no results for the specified name, _CheckForResults
		// has already sent an error message so we can just return

		return HTTP_S_FALSE;
	}
	
	// otherwise, move the result set along
	if (m_resultsMap[resultsName].MoveNextRow())		
	{
		return HTTP_SUCCESS;
	}
	else
	{
		// MoveNextRow will be used in a loop, so returning HTTP_S_FALSE will stop
		// the loop
		return HTTP_S_FALSE;
	}
}

HTTP_CODE CATLRTHandler::OnMoveNextColumn(TCHAR *szArgs)
{
	CStringA resultsName;

	if (!szArgs)
	{
		// if we get a NULL argument, use 'DEFAULT_RESULTS' as the results name		
		resultsName = DEFAULT_RESULTS;
	}
	else
	{
		// otherwise, take the whole argument string as the result name
		resultsName = szArgs;		
	}

	// if we get here, then we have a valid results name, either the default or
	// the one the user specified
	// see if we have a CmdResult using this results name as the key

	if (!_CheckForResults(resultsName))
	{
		// getting here means we have no results for the specified name, _CheckForResults
		// has already sent an error message so we can just return

		return HTTP_S_FALSE;
	}
	
	// otherwise, move the result set along
	if (m_resultsMap[resultsName].MoveNextColumn())		
	{
		return HTTP_SUCCESS;
	}
	else
	{
		// MoveNextColumn will be used in a loop, so returning HTTP_S_FALSE will stop
		// the loop
		return HTTP_S_FALSE;
	}
}


HTTP_CODE CATLRTHandler::OnGetColumnValue(TCHAR *szArgs)
{
	// szArgs has 4 possiblities, look for each one in the following code:
	// 1. szArgs == NULL -  this means we'll use the default result name and the current column
	//						value stored for that result
	// 2. szArgs == "name=value;" - this means we'll use the specified result name and the current
	//								value stored for that result
	// 3. szArgs == "name=value;column=col" - this means we'll use the specified result name and the
	//										  specified column value.
	// 4. szArgs == "column index" - this means we'll use the default result name and the specified column
	//								 value
	
	CStringA resultsName;
	int columnIndex;

	if (szArgs == NULL)
	{
		resultsName = DEFAULT_RESULTS;
		columnIndex = -1;		
	}
	else
	{
		// parse the argument string
		ArgParser parser;

		if (!parser.Parse(szArgs))
		{
			// this is combo #4
			resultsName = DEFAULT_RESULTS;
			columnIndex = atoi(szArgs);
		}
		else
		{	
			// is this combo #2?
			if (parser.GetAttribute("name", resultsName) != 1)
			{
				// if we got here, then we have an error, tell the user and get out of here
				m_HttpResponse << BAD_ARGSTRING;
				m_HttpResponse << USEAGE_GETCOLUMNVALUE;

				return HTTP_SUCCESS;
			}
			else
			{
				// if we got here, then we assume at this point that have combo #2
				columnIndex = -1;
			}

			// this check may turn our combo #2 into combo #3
			CStringA temp;
			if (parser.GetAttribute("column", temp) == 1)
			{
				// if we got here, then we have combo #3
				columnIndex = atoi(temp);
			}
		}
	}

	// ok, if we got here then we have a valid pair of result name and column value
	// make sure we have a results set of the give name
	if (!_CheckForResults(resultsName))
	{
		// getting here means we have no results for the specified name, _CheckForResults
		// has already sent an error message so we can just return

		return HTTP_SUCCESS;
	}

	// if we have results, get the value at the specified column and output it	
	if (columnIndex == -1)
	{
		// if the column value is -1, then use the current column value stored in our CmdResult
		m_HttpResponse << m_resultsMap[resultsName].GetColumnValue();
	}
	else
	{
		// otherwise, get the column value at the current index
		m_HttpResponse << m_resultsMap[resultsName].GetColumnValue(columnIndex);
	}
	
	return HTTP_SUCCESS;
}

HTTP_CODE CATLRTHandler::OnSaveColumnValue(TCHAR *szArgs)
{
	// szArgs allows the following combinations (these combinations are not meant to be a 
	// complete list, rather they address the most common useage)
	// 
	// 1. szArgs == "name=result name;column=column index;save_as=save as name" 
	//		- use all the specified values
	// 2. szArgs == "name=result name;column=column index"
	//		- use the result name as the save_as name
	// 3. szArgs == NULL
	//		- use the default result name, current column and default save as name (default result name)
	// 4. szArgs == "save_as=save as name"
	//		- use the default result name, current column and specified save as name
	// 5. szArgs == "column=column index;save_as=save as name"
	//		- use the default result name, specified column and specified save as name
	
	CStringA resultName;
	CStringA saveAs;
	int columnIndex;

	if (szArgs == NULL)
	{
		// easy, we have combo #3
		resultName = DEFAULT_RESULTS;
		saveAs = "";
		columnIndex = -1;
	}
	else
	{
		// parse our arguments to see what we have
		ArgParser parser;

		if (!parser.Parse(szArgs))
		{
			// sorry, we don't allow this one, it would be too ambiguous, would szArgs == column index, or 
			// save as name, or result?
			// report an error and get out of here
			
			m_HttpResponse << BAD_ARGSTRING;
			m_HttpResponse << USEAGE_SAVECOLUMN;			

			return HTTP_SUCCESS;
		}

		// look for our values, go to defaults for any we can't find
		// we have to find at least 1 in order for the string to be valid
		int numFound = 0;
	
		if (parser.GetAttribute("name", resultName) != 1)
		{
			// use a default result name
			resultName = DEFAULT_RESULTS;
		}
		else
		{
			numFound++;
		}

		if (parser.GetAttribute("save_as", saveAs) != 1)
		{
			// use a default save as name
			saveAs = "";
		}
		else
		{
			numFound++;
		}
		
		CString temp;
		if (parser.GetAttribute("column", temp) != 1)
		{
			// use a default column index
			columnIndex = -1;
		}
		else
		{
			numFound++;
			columnIndex = atoi(temp);
		}

		if (numFound == 0)
		{
			// if we didn't find any values then the argument string was invalid, tell the user 
			// and get out of here

			m_HttpResponse << BAD_ARGSTRING;
			m_HttpResponse << USEAGE_SAVECOLUMN;			

			return HTTP_SUCCESS;
		}
	}

	// ok, if we got here, then we have values for our result name, save as name and column index		
	// first, make sure we have results for the specified name
	if (!_CheckForResults(resultName))
	{
		// getting here means we have no results for the specified name, _CheckForResults
		// has already sent an error message so we can just return

		return HTTP_SUCCESS;
	}
	
	// now we know we have results

	if (columnIndex == -1)
	{
		// if we are using the current column index, figure out what that value is right now
		columnIndex = m_resultsMap[resultName].GetCurrentColumn();
	}

	if (resultName == "")
	{
		// if we are using a default save as name, setup a name now, based on the default
		// results and current column
		saveAs.Format("%s_%i", resultName, columnIndex);
	}

	// get our value for the specified result and store it in our variable map
	m_variableMap->SetAt(saveAs, m_resultsMap[resultName].GetColumnValue(columnIndex));

	// all done
	return HTTP_SUCCESS;
}

HTTP_CODE CATLRTHandler::OnGetRowNumber(TCHAR *szArgs)
{
	// szArg allows the following combinations
	// 1. szArgs == NULL
	//		- use the default result name
	// 2. szArgs == result name
	//		- use the specified result name
	
	CStringA resultName;

	if (szArgs == NULL)
	{
		// combo #1
		resultName = DEFAULT_RESULTS;
	}
	else
	{
		// combo #2
		resultName = szArgs;
	}

	if (!_CheckForResults(resultName))
	{
		// getting here means we have no results for the specified name, _CheckForResults
		// has already sent an error message so we can just return

		return HTTP_SUCCESS;
	}
	
	// we've got results so output the current column value
	m_HttpResponse << m_resultsMap[resultName].GetCurrentRow();
	
	return HTTP_SUCCESS;
}

HTTP_CODE CATLRTHandler::OnGetColumnNumber(TCHAR *szArgs)
{
	// szArg allows the following combinations
	// 1. szArgs == NULL
	//		- use the default result name
	// 2. szArgs == result name
	//		- use the specified result name
	
	CStringA resultName;

	if (szArgs == NULL)
	{
		// combo #1
		resultName = DEFAULT_RESULTS;
	}
	else
	{
		// combo #2
		resultName = szArgs;
	}

	if (!_CheckForResults(resultName))
	{
		// getting here means we have no results for the specified name, _CheckForResults
		// has already sent an error message so we can just return

		return HTTP_SUCCESS;
	}
	
	// we've got results so output the current column value
	m_HttpResponse << m_resultsMap[resultName].GetCurrentColumn();

	return HTTP_SUCCESS;
}

HTTP_CODE CATLRTHandler::OnResetResults(TCHAR *szArgs)
{
	// szArg allows the following combinations
	// 1. szArgs == NULL
	//		- use the default result name
	// 2. szArgs == result name
	//		- use the specified result name	

	CStringA resultName;

	if (szArgs == NULL)
	{
		// combo #1
		resultName = DEFAULT_RESULTS;
	}
	else
	{
		// combo #2
		resultName = szArgs;
	}

	if (!_CheckForResults(resultName))
	{
		// getting here means we have no results for the specified name, _CheckForResults
		// has already sent an error message so we can just return

		return HTTP_SUCCESS;
	}
	
	// we've got results, so reset that result
	m_resultsMap[resultName].ResetColumns();
	m_resultsMap[resultName].ResetRows();

	return HTTP_SUCCESS;
}

HTTP_CODE CATLRTHandler::OnCloseResults(TCHAR *szArgs)
{
	// szArg allows the following combinations
	// 1. szArgs == NULL
	//		- use the default result name
	// 2. szArgs == result name
	//		- use the specified result name	

	CStringA resultName;

	if (szArgs == NULL)
	{
		// combo #1
		resultName = DEFAULT_RESULTS;
	}
	else
	{
		// combo #2
		resultName = szArgs;
	}

	if (!_CheckForResults(resultName))
	{
		// getting here means we have no results for the specified name, _CheckForResults
		// has already sent an error message so we can just return

		return HTTP_SUCCESS;
	}
	
	// close these results
	m_resultsMap[resultName].Close();	
	m_resultsMap.RemoveKey(resultName);

	return HTTP_SUCCESS;
}


HTTP_CODE CATLRTHandler::OnRowCount(TCHAR *szArgs)
{
	// szArg allows the following combinations
	// 1. szArgs == NULL
	//		- use the default result name
	// 2. szArgs == result name
	//		- use the specified result name
	
	CStringA resultName;

	if (szArgs == NULL)
	{
		// combo #1
		resultName = DEFAULT_RESULTS;
	}
	else
	{
		// combo #2
		resultName = szArgs;
	}

	if (!_CheckForResults(resultName))
	{
		// getting here means we have no results for the specified name, _CheckForResults
		// has already sent an error message so we can just return

		return HTTP_SUCCESS;
	}
	
	// we've got results so output the current column value
	m_HttpResponse << m_resultsMap[resultName].GetRowValues().GetNumRows();
	
	return HTTP_SUCCESS;
}


/////////////////////////////////////////////////////////////////////
// HTTP Operations
/////////////////////////////////////////////////////////////////////
HTTP_CODE CATLRTHandler::OnSetContentType(TCHAR *szContentType)
{
	m_HttpResponse.SetContentType(szContentType);
	return HTTP_SUCCESS;
}

/////////////////////////////////////////////////////////////////////
// Internal utility methods
/////////////////////////////////////////////////////////////////////
bool CATLRTHandler::_CheckForResults(CString& resultsName)
{
	const CmdResultsMap::CPair *pair = m_resultsMap.Lookup(resultsName);	

	if (pair == NULL) 
	{
		// there were no results by the specified name, tell the user and return
		m_HttpResponse << "No results of the name: " << resultsName;

		return false;
	}
	else	
		return true;	
}

// looks for values in the following order
// 1. variable map
// 2. request parameters
// 3. server variables
LPCSTR CATLRTHandler::_GetValue(CStringA& name)
{
	LPCSTR szValue = NULL;
	StringMap::CPair *pair = m_variableMap->Lookup(name);
	
	if (pair != NULL) 	// try to find the variable value in our variable map
	{
		szValue = pair->m_value;
	}	
	else // if the value is not in our variable map, try to get it from the request parameters
	{	
		// look in both query and form parameters because you may have a mix of get and post
		// parameters

		// first try GET
		szValue = this->m_HttpRequest.m_QueryParams.Lookup(name);
		if (!szValue)
		{
			// try POST if GET fails
			szValue = this->m_HttpRequest.m_pFormVars->Lookup(name);
		}		
	}

	if (szValue == NULL) 
	{
		// if after looking in the variable map and the request parameters unsuccesfully,
		// try the server variables
		CStringA value;
		if (m_HttpRequest.GetServerVariable((LPCSTR)name, value))
		{
			szValue  = value;
		}			
	}

	return szValue;
}

int CATLRTHandler::_ResolveParameters(Params params, StringList& values)
{	
	// if we don't have parameters, just return now
	int attributeCount = params.GetCount();	
	if (attributeCount == 0)
	{
		return attributeCount;
	}

	// try to get our first element
	POSITION begin = params.GetHeadPosition();	
	ASSERT(begin != NULL);

	while (begin != NULL)
	{			
		// get our parameter information
		Param ps = params.GetNext(begin);
		
		if (!ps.isLiteral)
		{
			// try to resolve our parameter if we don't want the literal value
			LPCSTR szValue = _GetValue(ps.paramName);

			if (szValue == NULL)
			{
				// we could not find a value for this name
				// don't exit yet so the user can see all the names that
				// don't match
				m_HttpResponse << "could not get value for: " << ps.paramName << "<br>";
			}	
			else
			{							
				values.AddTail(CStringA(szValue));						
			}						
		}				
	}

	return attributeCount;
}

/////////////////////////////////////////////////////////////////////
// The ATL Server ISAPI extension
/////////////////////////////////////////////////////////////////////
typedef CatlrtExtension<CThreadPool<CATLRTExtensionWorker> > ExtensionType;
ExtensionType theExtension;

// Delegate ISAPI exports to theExtension
//
extern "C" DWORD WINAPI HttpExtensionProc(LPEXTENSION_CONTROL_BLOCK lpECB)
{
	return theExtension.HttpExtensionProc(lpECB);
}

extern "C" BOOL WINAPI GetExtensionVersion(HSE_VERSION_INFO* pVer)
{
	return theExtension.GetExtensionVersion(pVer);
}

extern "C" BOOL WINAPI TerminateExtension(DWORD dwFlags)
{
	return theExtension.TerminateExtension(dwFlags);
}
// atlrt.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "ArgParser.h"
#include "DBCommand.h"
#include "ResultSetBuilder.h"
#include "NoopBuilder.h"
#include "DataConnectionFactory.h"
#include "CachedStringMap.h"

/////////////////////////////////////////////////////////////////////
// error messages
/////////////////////////////////////////////////////////////////////
static LPCSTR USEAGE_SETCONNECTION	= "<br>USEAGE: {{SetConnection(<i>connection string</i>)}} <b><i>or</i></b> {{SetConnection(name=<i>name</i>;conn=<i>connection string</i>)}}<br>";
static LPCSTR USEAGE_GETCOLUMNVALUE	= "<br>USEAGE: {{GetColumnValue()}} <b><i>or</i></b> <br>USEAGE: {{GetColumnValue(name=<i>results name</i>)}} <b><i>or</i></b> GetColumnValue(<i>column number</i>)}} <b><i>or</i></b> {{GetColumnValue(name=<i>results name</i>;column=<i>column number</i>)}}<br>";
static LPCSTR USEAGE_MOVENEXTROW	= "<br>USEAGE: {{MoveNextRow(<i>results name</i>)}} <b><i>or</i></b> {{MoveNextRow())}}<br>";
static LPCSTR USEAGE_MOVENEXTCOLUMN	= "<br>USEAGE: {{MoveNextColumn(<i>results name</i>)}} <b><i>or</i></b> {{MoveNextColumn())}}<br>";
static LPCSTR USEAGE_MATCHFILEATTRIBUTES = "<br>USEAGE: {{MatchFileAttributes(name=<i>file path, can be unc</i>;attributes=<i>archive,|compressed,|device,|directory,|encrypted,|hidden,|normal,|not_content_indexed,|offline,|readonly,|reparse_point,|sparse_file|,system|,temporary)}}<br>";

static LPCSTR USEAGE_SAVECOLUMN		= "<br>USEAGE: {{SaveColumnValue(<i>szArgs</i>)}} where szArgs can be: <ol>\
										<li> szArgs == name=result name;column=column index;save_as=save as name\
											<ul><li>use all the specified values</ul>\
										<li>szArgs == name=result name;column=column index\
											<ul><li>use the result name as the save_as name</ul>\
										<li>szArgs == NULL\
											<ul><li>use the default result name, current column and default save as name (default result name)</ul>\
										<li>szArgs == save_as=save as name\
											<ul><li>use the default result name, current column and specified save as name</ul>\
										<li>szArgs == column=column index;save_as=save as name\
											<ul><li>use the default result name, specified column and specified save as name</ul>\
									  </ol>";


static LPCSTR NULL_ARGSTRING = "<br><font color=\"red\">Argument string cannot be null</font><br>";
static LPCSTR BAD_ARGSTRING = "<br><font color=\"red\">Argument string was invalid</font><br>";


static LPCSTR VARIABLE_MAP			= "variable_map";
static LPCSTR CONNECTION_MAP		= "connectionstrin_map";

static LPCSTR DEFAULT_CONNECTION	= "default_connection";
static LPCSTR DEFAULT_RESULTS		= "default_results";
			
// CATLRTHandler is our ATL Server application request handler.  All .srf files that you build 
// with ATLRT will have it's default processing done by this class.
[ request_handler("Default") ]
class CATLRTHandler
{
public:	
	static StringMap *m_stringmap;

	HTTP_CODE ValidateAndExchange();	
	HTTP_CODE Uninitialize(HTTP_CODE hcError) throw( );

	/////////////////////////////////////////////////////////////////////
	// Comment Conventions
	// 
	// <> signifies a parameter must be specified.  For example,
	// {{Test(<name>)}} indicates that the replacement tag Test must
	// be called with a parameter.  {{Test(<name=value>)}} indicates
	// that Test must be called with name=value pair, for example,
	// '{{Test(name=testing)}}'. [] signifies that the parameter is
	// optional.
	// 
	// Some tags have a 'replacement value'.  A replacement value is what
	// the tag will be replaced by when it has been parsed by ATL Server.	
	/////////////////////////////////////////////////////////////////////

	/////////////////////////////////////////////////////////////////////
	// Variable Map Operations
	/////////////////////////////////////////////////////////////////////	

	// Tag Syntax: {{GetValue(<name>)}}
	// Description:
	//		GetValue will be replaced by the value of the variable
	//		specified by 'name'.  GetValue will look for variables
	//		in the following order:
	//			- variable map
	//			- request variables (POST and GET)
	//			- server variables
	//
	//		Variables can be stored in the variable map by using the
	//		database operations.  Request variables are set by form submissions.
	//		Server variables are set on every request of a .srf file.
	[ tag_name(name="GetValue")]
	HTTP_CODE OnGetValue(TCHAR *szVariableName);
	
	// Tag Syntax: {{CopyValue(<name=source variable;dest=new variable>)}}
	// Description:
	//		CopyValue copies the value of the variable specified by 'source variable' into
	//		the variable map entry specified by 'new variable'.  Values are obtained for
	//		the variable specified by 'source variable' in the same manner as GetValue.	
	//		This tag has no replacement value.
	[ tag_name(name="CopyValue")]
	HTTP_CODE OnCopyValue(TCHAR *szArgs);

	// Tag Syntax {{ContainsValue(<name>)}}
	// Description:
	//		Very similiar to GetValue, except that it checks for the existance of the variable
	//		specified by 'name'.  ContainsValue has no replacment value, but it will return
	//		true or false, depending on whether name exists or not.  ContainsValue should be
	//		used in an {{if}} statement.
	[ tag_name(name="ContainsValue")]
	HTTP_CODE OnContainsValue(TCHAR *szName);

	// Tag Syntax {{CompareValue(<name=variable to compare; value=literal value>)}}
	// Description:
	//		Compares the value of the variable specified by 'name' with the literal value
	//		specified by 'value'.  CompareValue will return a true or false depending on
	//		whether the values are equal.  CompareValue has no replacement value and should 
	//		be used in an {{if}} statement.
	[ tag_name(name="CompareValue")]
	HTTP_CODE OnCompareValue(TCHAR *szArgs);
		
	// Tag Syntax {{MaintainValue([name=variable name; save_as=new name] | variable_name)}}
	// Description:
	//		MaintainValue stores the specified variable into a hidden input field with the
	//		same name as the variable.  For example, {{MaintainValue(testing)}} would be 
	//		replaced by (assuming the value of 'testing' is 'hello world':
	//		
	//		<input type="hidden" name="testing" value="hello world">
	//		
	//		You can also name the hidden field by using {{MaintainValue(name=testing; save_as=testing2)}}
	//		This would generate:
	//
	//		<input type="hidden" name="testing2" value="hello world">
	[ tag_name(name="MaintainValue")]
	HTTP_CODE OnMaintainValue(TCHAR *szArgs);	

	/////////////////////////////////////////////////////////////////////
	// Database Operations
	/////////////////////////////////////////////////////////////////////

	// Tag Syntax: {{SetConnection([name=connection name; conn=connection string] | connection string)}}							
	// Description:
	//		SetConnection is used to store a connection string.  These connection strings will be used
	//		by the {{Execute}} tag to connect to data sources.  You can use multiple connection strings
	//		on a page by specifying the 'name' attribute.  If you don't specify a 'name' attribute, then the
	//		connection string is stored using a default name.
	[ tag_name(name="SetConnection")]
	HTTP_CODE OnSetConnection(TCHAR *szArgs);	
	
	// Tag Syntax: {{Execute(<cmd=stored procedure name>;
	//					     [conn=connection name];
	//						 [results=result1, results2, result3, ...];
	//						 [params=param1, param2, ...];
	//						 [output_params=param1, param2, ...])}}
	// Description:
	//		SetConnection must be called before calling Execute.  Execute executes a stored procedure.  
	//	
	//		'cmd' parameter is the only required parameter; it is used
	//		to specify the stored procedure name.  	
	//
	//		'conn' can be used to specify the name of the connection string to use.  If it isn't specified,
	//		then the connection string stored at the default name is used.  
	//
	//		'results' is optional, it is used to store the results of the stored procedure by name.  These 
	//		results will be manipulated by the rest of the database operation tags.  If 'results' is not specified, 
	//		then any results of the stored procedure will be stored by a default name.  Specifiying more than one value for 'results' implies
	//		that the stored procedure will return multiple results.  
	//
	//		'params' is used to pass parameters to the stored procedures.  Parameters values are take from the same places as {{GetValue}} or
	//		are used as literal values, if surrounded by single quotes.  For example, if params is specified as follows:
	//
	//			params=name, 'testing'
	//
	//		'name' would be considered a variable, and its value would be resolved from the same places as {{GetValue}} 
	//		(variable map, request param, server variables).  'testing' is surrounded by single quotes, so it's literal 
	//		value will be passed to the stored procedure.
	//
	//		'output_params' are use to name any output parameters that the stored procedure my return.  The values will
	//		be stored in the variable map.
	[ tag_name(name="Execute")]
	HTTP_CODE OnExecute(TCHAR *szArgs);	
	
	// Tag Syntax: {{MoveNextRow([result name])}}
	// Description:
	//		Execute has to be called before calling MoveNextRow.  Results from executing a stored procedure 
	//		are stored in tables.  MoveNextRow advances the current row in the table.  'result name' is an 
	//		optional parameter specifying what result to advance.  MoveNextRow has no replacement value, but
	//		it will return boolean depending on whether there are more rows in the results or not.  MoveNextRow
	//		should be used in a {{while}} or {{if}} statement.
	[ tag_name(name="MoveNextRow")]
	HTTP_CODE OnMoveNextRow(TCHAR *szArgs);	
	
	// Tag Syntax: {{MoveNextColumn([result name])}}
	// Description:
	//		Execute has to be called before calling MoveNextColumn.  MoveNextColumn moves over the column values
	//		stored in the results of executing a stored procedure. 'result name' is an optional parameter
	//		specifying what column to advance.  MoveNextColumn has no replacement value, but
	//		it will return boolean depending on whether there are more columns in the current row or not.  MoveNextColumn
	//		should be used in a {{while}} or {{if}} statement.
	[ tag_name(name="MoveNextColumn")]
	HTTP_CODE OnMoveNextColumn(TCHAR *szArgs);	

	// Tag Syntax: {{GetColumnValue([result name] |
	//								[name=value] | 
	//								[name=value;column=col] | 
	//								column index)}}
	// Description:
	//		Execute has to be called before calling GetColumnValue.  GetColumnValue is used to get the 
	//		value of a specific column from a set of results.  The parameters to GetColumnValue determine
	//		which column is used.  The following are the possible ways to call GetColumnValue:
	//		
	//		{{GetColumnValue()}}
	//			-  Use the default result name and the current column
	//			   value stored for that result.
	//	
	//		{{GetColumnValue(name=value)}}
	//			- Use the specified result name and the current
	//			  value stored for that result
	//
	//		{{GetColumnValue(name=value;column=col)}}
	//			- Use the specified result name and the
	//			  specified column value.			
	//
	//		{{GetColumnValue(column index)}}
	//			- Use the default result name and the specified column
	//			  value										
	[ tag_name(name="GetColumnValue")]
	HTTP_CODE OnGetColumnValue(TCHAR *szArgs);	
	
	// Tag Syntax: {{SaveColumnValue([name=result name;column=column index;save_as=save as name] | 
	//								 [name=result name;column=column index] | 
	//								 [save_as=save as name] | 
	//								 [column=column index;save_as=save as name])}}
	// Description:
	//		Execute has to be called before calling SaveColumnValue.  SaveColumnValue is 
	//		similiar to GetColumnValue except that it will store the specified column value
	//		into the variable map.  The following are the possible ways to call SaveColumnValue:
	//
	//		{{SaveColumnValue(name=result name;column=column index;save_as=save as name)}}
	//				- Use the result specified by 'result name' and the column specified by 'column index'
	//				  and save that value into the variable map under the name 'save as name'.
	//
	//		{{SaveColumnValue(name=result name;column=column index)}}
	//				- Use the result specified by 'result name' and the column specified by 'column index'
	//				  and save the value into the variable map under the name 'result name'
	//	
	//		{{SaveColumnValue()}}
	//				- Use the default result name, current column and save that value into the variable map
	//				  under the default result name
	//
	//		{{SaveColumnValue(save_as=save as name)}}
	//				- Use the default result name, the current column and save that value into the variable map
	//				  under the name specified by 'save as name;.
	//
	//		{{SaveColumnValue(column=column index;save_as=save as name)}}
	//				- Use the default result name, the column specified by 'column index' and save that value into
	//				  the variable map under the name specified by 'save as name'.
	[ tag_name(name="SaveColumnValue")]
	HTTP_CODE OnSaveColumnValue(TCHAR *szArgs);	
	
	// Tag Syntax: {{GetRowNumber([result name])}}
	// Description:
	//		Execute has to be called before calling GetRowNumber.  GetRowNumber is replaced by the row number
	//		of the current row. 'result name' is optional and can be used to specify the result from which to get the 
	//		row number.  The default result name is used if this parameter is not specified.
	[ tag_name(name="GetRowNumber")]
	HTTP_CODE OnGetRowNumber(TCHAR *szArgs);	
	
	// Tag Syntax: {{GetColumnNumber([result name])}}
	// Description:
	//		Execute has to be called before calling GetColumnNumber.  GetColumnNumber is replaced by the column number
	//		of the current column. 'result name' is optional and can be used to specify the result from which to get the 
	//		column number.  The default result name is used if this parameter is not specified.
	[ tag_name(name="GetColumnNumber")]
	HTTP_CODE OnGetColumnNumber(TCHAR *szArgs);	
	
	// Tag Syntax: {{ResetResults([result name])}}
	// Description:
	//		Execute has to be called before calling ResetResults.  ResetResults is used to reset the current row and
	//		column number of a result.  'result name' can be used to specify the result.  The default name is used if
	//		this parameter is not specified.
	[ tag_name(name="ResetResults")]
	HTTP_CODE OnResetResults(TCHAR *szArgs);	

	// Tag Syntax: {{CloseResults([result name])}}
	// Description:
	//		Execute has to be called before calling CloseResults.  CloseResults is used to erase the values of a result.  
	//		'result name' can be used to specify the result.  The default name is used if
	//		this parameter is not specified.
	[ tag_name(name="CloseResults")]
	HTTP_CODE OnCloseResults(TCHAR *szArgs);

	// Tag Syntax: {{RowCount([result name])}}
	// Description:
	//		Execute has to be called before calling RowCount.  RowCount is replaced by the number of rows in a result.  
	//		'result name' can be used to specify the result.  The default name is used if
	//		this parameter is not specified.	
	[ tag_name(name="RowCount")]
	HTTP_CODE OnRowCount(TCHAR *szArgs);

	/////////////////////////////////////////////////////////////////////
	// HTTP Operations
	/////////////////////////////////////////////////////////////////////

	// Tag Syntax: {{SetContentType(<content type>)}}
	// Description:
	//		SetContentType is used to emit a Content-Type: <content-type> header into the response stream.  This tag
	//		lets you specify the type of document you want to generate.
	[ tag_name(name="SetContentType")]
	HTTP_CODE OnSetContentType(TCHAR *szContentType);
	
private:		
	CachedStringMap	*m_variableMap;
	CachedStringMap	*m_connectionMap;
	CmdResultsMap	m_resultsMap;
	
	// blob cache support
	CComPtr<IMemoryCache> 		m_spBinaryCache;
	
	// data source cache support
	CComPtr<IDataSourceCache> m_spDataSrcCache;

	// utility functions
	LPCSTR	_GetValue(CStringA& szName);
	bool	_CheckForResults(CString& resultsName);			
	int		_ResolveParameters(Params params, StringList& values);

}; // class CatlrtHandler
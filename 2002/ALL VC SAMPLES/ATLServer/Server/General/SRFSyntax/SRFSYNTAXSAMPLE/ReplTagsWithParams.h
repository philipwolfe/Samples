// SRFSyntaxSample.h : Defines the ATL Server request handler class
// (c) 2001 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once


// Structure containing multiple parameters of a replacement method,
// to be used in OnMultipleParamHello
typedef struct tagMultipleParam
{
	char		_szWho[64];
	char		_szProduct[64];
	char		_szPlatform[64];
	int			_paramCount;
}stMultipleParam;


[ request_handler("ReplTagsWithParams") ]
class CSRFSyntaxTagsWithParamsHandler
{

protected:
	//  for browsing the current folder	
	CString			_szFileName;
	DWORD			_dwFileSize;
	CString			_szFileDate;
	HANDLE			_hFileFind;

public:

	// Initialization method. It is called by the stencil processor whenever 
	// this replacement handler is initialized 
	HTTP_CODE ValidateAndExchange()
	{
		// Set the content-type for the response
		m_HttpResponse.SetContentType("text/html");

		_hFileFind	=	INVALID_HANDLE_VALUE;
		return HTTP_SUCCESS;
	}



	/*
		Replacement method associated with a replacement tag.
		The tag_name attribute performs the association with the "simpleIntHello" replacement tag.
		The "name" parameter is required. As the optional parameter "parse_func" is missing, a default 
		parsing function will be used to generate the *pnParam parameter.
		Please check documentation for a complete list of the types supported by the default parsing functions.
		The *pnParam buffer is allocated in the default parsing function. It does not have to be 
		deallocated here.
		The method is called whenever the "simpleIntHello" replacement tag occurs inside the SRF file. 
	*/
	[
		tag_name( name = "simpleIntHello")
	]
	HTTP_CODE OnSimpleIntHello(int	*pnParam)
	{
		m_HttpResponse	<<	"Hello, parameter is "	<<	*pnParam;
		return HTTP_SUCCESS;
	}




	/*
		Replacement method associated with a replacement tag.
		The tag_name attribute performs the association with the "simpleStringHello" replacement tag.
		The "name" parameter is required. The optional parameter "parse_func" specifies the name of a 
		method to be used in parsing the replacement tag parameter.(Please look below, at  
		parseSimpleStringHelloParam description, for details on this method).

		The pszParam buffer is allocated in the specified parsing function. It does not have to be 
		deallocated here.
		The method is called whenever the "simpleStringHello" replacement tag occurs inside the SRF file. 
	*/
	[
		tag_name( name = "simpleStringHello", parse_func = "parseSimpleStringHelloParam")
	]
	HTTP_CODE OnSimpleStringHello(char *pszParam)
	{
		m_HttpResponse	<<	"Hello, "	<<	pszParam;
		return HTTP_SUCCESS;
	}
	

	/*
		Tag parameter parsing method.
		It must have the following signature: 
			HTTP_CODE <func>(IAtlMemMgr* pMemMgr, LPCSTR szParams, TYPE	*ppDest);
	
		The memory allocated with the IAtlMemMgr interface pointer does not have to be freed after use.
		The framework will free it after passing the parameter to the replacement method (in this case, 
		OnSimpleStringHello). So, the ppDest parameter MUST be allocated using the IAtlMemMgr interface
		pointer. 
		TYPE may be any simple type , array or structure containing simple types.
		szParams parameter contains all the parameters from teh SRF file as a single string.
		(everything between paranthesis)
	*/
	HTTP_CODE parseSimpleStringHelloParam(IAtlMemMgr *pMemMgr, LPCSTR szParams, char **ppDest)
	{
		// Use pMemMgr to allocate memory for ppDest, then parse 
		// your parameter from szParams, and store them in ppDest.

		size_t		iAllocSize	=	0;

		// Get the length of the single parameter. Reserve space for the trailing \0
		iAllocSize	=	strlen( szParams) + 1;
		
		
		// Allocate memory in the memoy manager, so that it may be automatically freed later
		*ppDest	=	(char*)pMemMgr->Allocate(iAllocSize);

		// Copy the input parameter in the allocated buffer
		strcpy( *ppDest, szParams);

		return HTTP_SUCCESS;
	}



	/*
		Replacement method associated with a replacement tag.
		The tag_name attribute performs the association with the "multipleStringHello" replacement tag.
		The "name" parameter is required. The optional parameter "parse_func" specifies the name of a 
		method to be used in parsing the replacement tag parameter.(Please look below, at  
		OnMultipleStringHelloParam description, for details on this method).

		The inputData structure is allocated in the specified parsing function. It does not have to be 
		deallocated here.
		The method is called whenever the "multipleStringHello" replacement tag occurs inside the SRF file. 
	*/
	[
		tag_name( name = "multipleParamHello", parse_func = "parseMultipleHelloParam")
	]

	HTTP_CODE OnMultipleParamHello(stMultipleParam	*inputData)
	{
		CStringA		szOutput;

		szOutput.Format("Congratulations, %s, for using %s (part of %s platform).<br>",
				inputData->_szWho,
				inputData->_szProduct,
				inputData->_szPlatform);
		m_HttpResponse	<<	szOutput;


		szOutput.Format("The replacement tag has %d params.", inputData->_paramCount);
		m_HttpResponse	<<	szOutput;
		
		return HTTP_SUCCESS;
	}
	


	/*
		Tag parameter parsing method.
		It must have the following signature: 
			HTTP_CODE <func>(IAtlMemMgr* pMemMgr, LPCSTR szParams, TYPE	*ppDest);
	
		The memory allocated with the IAtlMemMgr interface pointer does not have to be freed after use.
		The framework will free it after passing the parameter to the replacement method (in this case, 
		OnSimpleStringHello). So, the ppDest parameter MUST be allocated using the IAtlMemMgr interface
		pointer. 
		TYPE may be any simple type , array or structure containing simple types.
		szParams parameter contains all the parameters from the SRF file as a single string.
		(everything between paranthesis)
		In this method, the replacement tag parameters are supposed to be separated by comma.
	*/
	HTTP_CODE parseMultipleHelloParam(IAtlMemMgr *pMemMgr, LPCSTR szParams,	stMultipleParam	**ppDest)
	{
		// Use pMemMgr to allocate memory for ppDest, then parse 
		// your parameter from szParams, and store them in ppDest.

		size_t		iAllocSize	=	0;


		// Get the length of the single parameter. Reserve space for the trailing \0
		iAllocSize	=	sizeof( stMultipleParam);
		
		
		// Allocate memory in the memoy manager, so that it may be automatically freed later
		*ppDest	=	(stMultipleParam*)pMemMgr->Allocate(iAllocSize);

		
		//parse the input string, then 
		int			iCommaPos = -1;
		CStringA	szRest, szData;

		szRest	=	szParams;


		// look for the first parameter, _szWho 
		iCommaPos	=	szRest.Find(",");
		if( iCommaPos > 0 )
		{
			szData	=	szRest.Left( iCommaPos ); 
			szRest	=	szRest.Right( szRest.GetLength() - iCommaPos - 1);

			strcpy((*ppDest)->_szWho, szData);
		}

		// look for the second parameter, _szProduct
		iCommaPos	=	szRest.Find(",");
		if( iCommaPos > 0 )
		{
			szData	=	szRest.Left( iCommaPos ); 
			szRest	=	szRest.Right( szRest.GetLength() - iCommaPos - 1);

			strcpy((*ppDest)->_szProduct, szData);
		}

		// look for the third parameter, _szPlatform
		iCommaPos	=	szRest.Find(",");
		if( iCommaPos > 0 )
		{
			szData	=	szRest.Left( iCommaPos ); 
			szRest	=	szRest.Right( szRest.GetLength() - iCommaPos - 1);

			strcpy((*ppDest)->_szPlatform, szData);
		}

		// look for the fourth (last) parameter, _paramCount
		szData	=	szRest; 
		(*ppDest)->_paramCount	=	atoi(szData);


		return HTTP_SUCCESS;
	}


	[ tag_name(name="getNextFile")]
	HTTP_CODE getNextFile(LPSTR	strExt)
	{
	
		char				buffFileName[MAX_PATH];
		WIN32_FIND_DATAA	wfd;
		HANDLE				hFind	=	INVALID_HANDLE_VALUE;
		HTTP_CODE			hRet	=	HTTP_S_FALSE;
		BOOL				bFileFound	=	FALSE;

		
		
		// Get the translated path of the script.
		// It looks like C:\someFolder\...\someFile.srf
		strcpy(buffFileName, m_HttpRequest.GetScriptPathTranslated());

		
		// Remove the file name to keep only the path
		LPSTR	pszBackslash	=	strrchr(buffFileName, '\\');
		if( pszBackslash )
		{
			pszBackslash ++;
			*pszBackslash =	'\0';
		}

		// concatenate the filter the (coming as a replacement tag parameter)
		ATLASSERT(strlen(buffFileName)  + strlen(strExt) < MAX_PATH);
		strcat( buffFileName, strExt );

		
		if( _hFileFind == INVALID_HANDLE_VALUE )
		{
			// If not inside a Search operation, start one...
			_hFileFind	=	::FindFirstFileA( (LPCSTR)buffFileName, &wfd);
			bFileFound	=	(_hFileFind != INVALID_HANDLE_VALUE);
		}
		else
		{
			// ... else continue the previous one
			bFileFound	=	::FindNextFileA( _hFileFind, &wfd );
		}

		if( bFileFound )
		{
			// If at least one file was found, get the attributes of that file
			FILETIME		localTime;
			SYSTEMTIME		sysTime;

			_szFileName	=	wfd.cFileName;
			_dwFileSize	=	wfd.nFileSizeLow;

			::FileTimeToLocalFileTime( &wfd.ftLastWriteTime, &localTime);
			::FileTimeToSystemTime( &localTime, &sysTime);
			_szFileDate.Format(_T("%.2d/%.2d/%d, %.2d:%.2d"), sysTime.wMonth, sysTime.wDay, 
						sysTime.wYear, sysTime.wHour, sysTime.wMinute);

			hRet	=	HTTP_SUCCESS;
			
		}
		else
		{
			::FindClose( _hFileFind );
			_hFileFind	=	INVALID_HANDLE_VALUE;
		}


		return hRet;
	}


	[ tag_name(name="file")]
	HTTP_CODE file(LPTSTR	strExt)
	{
		// render different properties of the current file
		if( 0 == _tcsicmp(strExt, _T("name")) )
		{
			m_HttpResponse	<<	_szFileName;
		}
		else	if( 0 == _tcsicmp(strExt,  _T("size")) )
		{
			m_HttpResponse	<<	_dwFileSize;
		}
		else	if( 0 == _tcsicmp(strExt, _T("date")) )
		{
			m_HttpResponse	<<	_szFileDate;
		}
		else
			m_HttpResponse	<<	_T("N/A");

		return HTTP_SUCCESS;

	}


};


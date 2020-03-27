// File: SoapDebugClient.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#ifndef SOAP_DEBUG_CLIENT_H_INCLUDED
#define SOAP_DEBUG_CLIENT_H_INCLUDED

// Includes for SoapDebugClient
#include <atlisapi.h>
#include <stdio.h>


class CReadWriteStreamOnCString;
class CSoapDebugClient;
class CSoapDebugExtension;


class CReadWriteStreamOnCString : public IWriteStream,
			public IStreamImpl
{
public:
	HRESULT __stdcall QueryInterface(REFIID riid, void **ppv) throw()
	{
		if (ppv == NULL)
		{
			return E_POINTER;
		}

		*ppv = NULL;

		if (InlineIsEqualGUID(riid, IID_IUnknown) ||
			InlineIsEqualGUID(riid, IID_IStream) ||
			InlineIsEqualGUID(riid, IID_ISequentialStream))
		{
			*ppv = static_cast<IStream *>(this);
			return S_OK;
		}

		return E_NOINTERFACE;
	}

	ULONG __stdcall AddRef() throw()
	{
		::InterlockedIncrement( &l_refCount );
		return 1;
	}

	ULONG __stdcall Release() throw()
	{
		if( l_refCount > 0 )
		{
			::InterlockedDecrement( &l_refCount );
			if( l_refCount == 0 )
				Cleanup();
		}
		return 1;
	}

public:
	CStringA		m_str;
	long			m_nCurr;
	long			m_nBodyLen;

	long			l_refCount;


public:

	CReadWriteStreamOnCString() throw()
		: m_nCurr(0), m_nBodyLen(0), l_refCount(0)
	{
	}

	BOOL Cleanup() throw()
	{
		m_nCurr		=	0;
		m_nBodyLen	=	0;

		m_str.Empty();

		return TRUE;
	}

	HRESULT __stdcall Read(void *pDest, ULONG nMaxLen, ULONG *pnRead) throw()
	{
		ATLASSERT( pDest != NULL );

		if (pnRead != NULL)
		{
			*pnRead = 0;
		}

		long nRead = m_nCurr;
		if (nRead < m_nBodyLen)
		{
			long nLength = min((int)(m_nBodyLen - nRead), (LONG) nMaxLen);
			memcpy(pDest, (LPCSTR)m_str + nRead, nLength);
			m_nCurr+= nLength;

			if (pnRead != NULL)
			{
				*pnRead = (ULONG) nLength;
			}
		}

		return S_OK;
	}

	HRESULT WriteStream(LPCSTR szOut, int nLen, LPDWORD pdwWritten) throw()
	{
		ATLASSERT( szOut != NULL );

		if (nLen < 0)
		{
			nLen = (int) strlen(szOut);
		}

		_ATLTRY
		{
			m_str.Append(szOut, nLen);
			m_nBodyLen	=	m_str.GetLength();
		}
		_ATLCATCHALL()
		{
			return E_OUTOFMEMORY;
		}

		if (pdwWritten != NULL)
		{
			*pdwWritten = (DWORD) nLen;
		}

		return S_OK;
	}

	HRESULT FlushStream() throw()
	{
		return S_OK;
	}

}; // class CReadWriteStreamOnCString



// LOG options
#define		SOAP_DEBUG_LOG_SOAP		0x00000001
#define		SOAP_DEBUG_LOG_HTTP		0x00000002
#define		SOAP_DEBUG_LOG_ALL		SOAP_DEBUG_LOG_HTTP|SOAP_DEBUG_LOG_SOAP
#define		SOAP_DEBUG_LOG_NOTHING	0x00000000
#define		HTTP_HEADERS_END		"\r\n\r\n"

class CSoapDebugClient : public IHttpServerContext
{
protected:
	DWORD						m_logOption;
	CAtlFile					m_OutFile;
	CAtlFile					m_ErrFile;

	CReadWriteStreamOnCString	m_requestStream;
	CReadWriteStreamOnCString	m_responseStream;
	

	char					m_dllPath[MAX_PATH + 1];
	char					m_fullDllPath[MAX_PATH + 1];
	char					m_szPathTranslated[MAX_PATH + 1];
	char					m_szScriptPathTranslated[MAX_PATH + 1];
	char					m_szQueryString[ATL_URL_MAX_URL_LENGTH + 1];
	char					m_szContentType[ATL_URL_MAX_URL_LENGTH + 1];
	char					m_szVerb[MAX_PATH];
	char					m_szProtocol[MAX_PATH];
	

	typedef CAtlMap< 
				CStringA,
				CStringA,
				CStringElementTraitsI<CStringA>,
				CStringElementTraitsI<CStringA>
			   > HeaderMapType;

	HeaderMapType			m_requestHeaderMap;


	SOAPCLIENT_ERROR		m_errorState;

public:
	LPCSTR	GetDllPath()
	{
		return	m_dllPath;
	}


	LPCSTR	GetFullDllPath()
	{
		if( *m_fullDllPath != 0 )
			return m_fullDllPath;


		//calculate it
		if( ::IsFullPathA(m_dllPath) )
			return m_dllPath;
		else
		{
			char	curDir[MAX_PATH+1];
			::GetCurrentDirectoryA( MAX_PATH, curDir );
			
			if( m_dllPath[0] == '\\')
			{
				// PathCanonicalize does not handle root related paths
				strcpy(m_fullDllPath + 2, m_dllPath);
				// use curDir drive letter and :
				m_fullDllPath[0]	=	curDir[0];
				m_fullDllPath[1]	=	curDir[1];
			}
			else
			{
				char	tempBuff[2*MAX_PATH + 1];
				sprintf(tempBuff, curDir);
				sprintf(tempBuff + strlen(curDir), "\\");
				sprintf(tempBuff + strlen(tempBuff), m_dllPath);
				BOOL	bCanonicalized =	::PathCanonicalizeA( m_fullDllPath, tempBuff);
				ATLASSERT(bCanonicalized);
			}
		}
		return m_fullDllPath;
	}

	
	// sets the output file - default STD_OUT
	HRESULT	SetOutputFile(LPCTSTR	szFile = NULL)
	{
		HRESULT		hr;
		
		if( (HANDLE)m_OutFile != NULL )
		{
			m_OutFile.Close();
		}

		if (szFile == NULL)
		{
			// use Standard output
			HANDLE hOut = GetStdHandle(STD_OUTPUT_HANDLE);
			if (hOut == INVALID_HANDLE_VALUE)
				return E_FAIL;
			m_OutFile.Attach(hOut);
			hr = S_OK;
		}
		else
		{
			hr = m_OutFile.Create(szFile, GENERIC_WRITE, FILE_SHARE_READ, CREATE_ALWAYS);
		}
		return hr;
	
	}
	
	// sets the error file - defualt STD_ERROR
	HRESULT		SetErrorFile(LPCTSTR		szFile)
	{
		HRESULT		hr;

		if( (HANDLE)m_ErrFile != NULL )
		{
			m_ErrFile.Close();
		}
		if (szFile)
		{
			hr = m_ErrFile.Create(szFile, GENERIC_WRITE, FILE_SHARE_READ, CREATE_ALWAYS);
		}
		else
		{
			HANDLE hErr = GetStdHandle(STD_ERROR_HANDLE);
			if (hErr == INVALID_HANDLE_VALUE)
				hr = E_FAIL;
			else
			{
				m_ErrFile.Attach(hErr);
				hr = S_OK;
			}
		}
		return hr;
	}

	// sets the soap app dll path - default "app.dll" from URL
	HRESULT		SetSoapAppDllPath(LPCSTR		szFile)
	{
		if( strlen(szFile) >= MAX_PATH )
			return E_FAIL;

		strcpy( m_dllPath, szFile);
		*m_fullDllPath	=	0;
		return S_OK;
	}

	
	HRESULT		SetProtocol(LPCSTR		szProtocol)
	{
		if( strlen(szProtocol) >= MAX_PATH )
			return E_FAIL;

		strcpy( m_szProtocol, szProtocol);
		return S_OK;
	}
		
	// returns the old LOG option
	DWORD		SetLogOption(DWORD		newLogOption)
	{
		DWORD	oldOption	=	m_logOption;
		m_logOption	=	newLogOption;

		return oldOption;
	}


	void				SetUrl(LPCTSTR	tszURL)
	{
		// sets the QueryString
		// Assume that the URL looks like .....app.dll?Handler=....., i.e. a SOAP handler DLL
		LPCSTR			szUrl;
#ifdef UNICODE
		CW2A	w2aUrl(tszURL);
		szUrl	=	w2aUrl;
#else
		szUrl	=	tszURL;
#endif
		
		LPCSTR	pQMark			=	strchr( szUrl, '?');
		LPCSTR	pAppPathLimit	=	NULL;
		

		pAppPathLimit	=	szUrl + strlen(szUrl);

		if( pQMark != NULL )
		{
			if( strlen(pQMark+1) < ATL_URL_MAX_URL_LENGTH )
				strncpy(m_szQueryString, pQMark+1, ATL_URL_MAX_URL_LENGTH);
			pAppPathLimit	=	pQMark;
		}

		if( *m_dllPath == '\0' )
		{
			// change the m_dllPath ONLY if it is NULL 
			LPCSTR	pAppStart =	szUrl;
			LPCSTR	pCurr	=	pAppStart;

			while( pCurr != pAppPathLimit )
				if( *pCurr++ == '\\')
					pAppStart	=	pCurr;
			
			if( strlen(pAppStart) < MAX_PATH)
				strncpy(m_dllPath, pAppStart, MAX_PATH );
		}
		
	}


public:
	CSoapDebugClient(LPCTSTR strURL = NULL) : m_errorState(SOAPCLIENT_SUCCESS)
	{
		*m_szQueryString	= 0;
		*m_szContentType	= 0;
		*m_szVerb			= 0;
		*m_dllPath			= 0;
		*m_fullDllPath		= 0;

		sprintf( m_szProtocol, "HTTP/1.1");
		SetOutputFile(NULL);
		SetErrorFile(NULL);
		SetUrl(strURL);


		m_logOption			=	SOAP_DEBUG_LOG_ALL;
	}

	~CSoapDebugClient() throw()
	{
		m_OutFile.Close();
		m_ErrFile.Close();
		CleanupClient();
	}

	SOAPCLIENT_ERROR GetClientError()
	{
		return m_errorState;
	}

	void SetClientError(SOAPCLIENT_ERROR errorState)
	{
		m_errorState = errorState;
	}

	
	void CleanupClient() throw()
	{
		m_requestHeaderMap.RemoveAll();
		m_requestStream.Cleanup();
		m_responseStream.Cleanup();
	}
	
	IWriteStream * GetWriteStream() throw()
	{
		return &m_requestStream;
	}
	
	
	HRESULT GetReadStream(IStream **ppStream) throw()
	{
		if (ppStream == NULL)
		{
			return E_POINTER;
		}

		*ppStream = &m_responseStream;
		return S_OK;
	}
	
	HRESULT SendRequest(LPCTSTR szAction) throw();

protected:
	void	upcaseHttpHeaderName(CStringA&	strName)
	{
		int		iIndex;
		bool	bUpCase	=	true;
		for( iIndex = 0; iIndex  < strName.GetLength(); iIndex ++ )
		{
			if( bUpCase )
				strName.SetAt(iIndex, toupper( strName[iIndex] ));
			bUpCase	=	strName[iIndex ]  == '-';
		}
	}
	
// IHttpServerContext
protected:

public:
	void LogServerError(LPCTSTR szErr) throw()
	{
		if (m_ErrFile.m_h == NULL)
			return;

		m_ErrFile.Write(szErr, (DWORD) _tcslen(szErr)*sizeof(TCHAR));
	}

	// Implementation
	HRESULT STDMETHODCALLTYPE QueryInterface(REFIID riid, void **ppv) throw()
	{
		if (!ppv)
			return E_POINTER;
		if (InlineIsEqualGUID(riid, __uuidof(IUnknown)) ||
			InlineIsEqualGUID(riid, __uuidof(IHttpServerContext)))
		{
			*ppv = static_cast<IUnknown*>(this);
			AddRef();
			return S_OK;
		}
		return E_NOINTERFACE;
	}
	
	// Implementation
	ULONG STDMETHODCALLTYPE AddRef() throw()
	{
		return 1;
	}
	
	// Implementation
	ULONG STDMETHODCALLTYPE Release() throw()
	{
		return 1;
	}



	// Returns the HTTP status code.
	// Equivalent to EXTENSION_CONTROL_BLOCK::dwHttpStatusCode.
	DWORD GetHttpStatusCode() throw()
	{
		return 0;
	}

	// Returns a nul-terminated string that contains the HTTP method of the current request.
	// Examples of common HTTP methods include "GET" and "POST".
	// Equivalent to the REQUEST_METHOD server variable or EXTENSION_CONTROL_BLOCK::lpszMethod.
	LPCSTR GetRequestMethod() throw()
	{
		return m_szVerb;
	}

	// Returns a nul-terminated string that contains the query information.
	// This is the part of the URL that appears after the question mark (?). 
	// Equivalent to the QUERY_STRING server variable or EXTENSION_CONTROL_BLOCK::lpszQueryString.
	LPCSTR GetQueryString() throw()
	{
		return m_szQueryString;
	}

	// Returns a nul-terminated string that contains the path of the current request.
	// This is the part of the URL that appears after the server name, but before the query string.
	// Equivalent to the PATH_INFO server variable or EXTENSION_CONTROL_BLOCK::lpszPathInfo.
	LPCSTR GetPathInfo() throw()
	{
		return m_szPathTranslated;
	}

	// Call this function to retrieve a nul-terminated string containing the physical path of the script.
	//
	// Returns TRUE on success, and FALSE on failure. Call GetLastError to get extended error information.
	//
	// On entry, pdwSize should point to a DWORD that indicates the size of the buffer in bytes.
	// On exit, the DWORD contains the number of bytes transferred or available to be transferred into the buffer (including the nul-terminating byte).
	// The script path is the same as GetPathTranslated up to the first .srf or .dll.
	// For example, if GetPathTranslated returns "c:\inetpub\vcisapi\hello.srf\goodmorning",
	// then this function returns "c:\inetpub\vcisapi\hello.srf".
	LPCSTR GetScriptPathTranslated() throw()
	{		
        return m_szScriptPathTranslated;
    }

	// Returns a nul-terminated string that contains the translated path of the requested resource.
	// This is the path of the resource on the local server.
	// Equivalent to the PATH_TRANSLATED server variable or EXTENSION_CONTROL_BLOCK::lpszPathTranslated.
	LPCSTR GetPathTranslated() throw()
	{
		return m_szPathTranslated;
	}

	void SetPathTranslated(LPCSTR szPath)
	{
		//ATLASSERT(szPath != NULL);
		if( szPath == NULL )
			szPath	=	GetFullDllPath();
		strcpy(m_szPathTranslated, szPath);

        // Initialize the translated script path
		LPCSTR szEnd = m_szPathTranslated;
		
		while (TRUE)
		{
			while (*szEnd != '.' && *szEnd != '\0')
				szEnd++;
			if (*szEnd == '\0')
                break;

			szEnd++;
			if (!_strnicmp(szEnd, "dll", 3) || 
				!_strnicmp(szEnd, c_AtlSRFExtension+1, 3))
			{
				szEnd += 3;
                if (!*szEnd || *szEnd == '/' || *szEnd == '\\' || *szEnd == '?' || *szEnd == '#')
				    break;
			}
		}
		
		DWORD dwResult = (DWORD)(szEnd - m_szPathTranslated);

		memcpy(m_szScriptPathTranslated, m_szPathTranslated, dwResult);
		m_szScriptPathTranslated[dwResult] = '\0';
	}

	// Returns the total number of bytes to be received from the client.
	// If this value is 0xffffffff, then there are four gigabytes or more of available data.
	// In this case, ReadClient or AsyncReadClient should be called until no more data is returned.
	// Equivalent to the CONTENT_LENGTH server variable or EXTENSION_CONTROL_BLOCK::cbTotalBytes. 
	DWORD GetTotalBytes() throw()
	{
		ULONGLONG nLen = 0;
		nLen	=	m_requestStream.m_str.GetLength();
		return (DWORD)nLen;
	}

	// Returns the number of bytes available in the request buffer accessible via GetAvailableData.
	// If GetAvailableBytes returns the same value as GetTotalBytes, the request buffer contains the whole request.
	// Otherwise, the remaining data should be read from the client using ReadClient or AsyncReadClient.
	// Equivalent to EXTENSION_CONTROL_BLOCK::cbAvailable.
	DWORD GetAvailableBytes() throw()
	{
		return 0;
	}

	// Returns a pointer to the request buffer containing the data sent by the client.
	// The size of the buffer can be determined by calling GetAvailableBytes.
	// Equivalent to EXTENSION_CONTROL_BLOCK::lpbData
	BYTE *GetAvailableData() throw()
	{
		return NULL;
	}

	// Returns a nul-terminated string that contains the content type of the data sent by the client.
	// Equivalent to the CONTENT_TYPE server variable or EXTENSION_CONTROL_BLOCK::lpszContentType.
	LPCSTR GetContentType() throw()
	{
		return m_szContentType;
	}

	// Call this function to retrieve a nul-terminated string containing the value of the requested server variable.
	// Returns TRUE on success, and FALSE on failure. Call GetLastError to get extended error information.
	// On entry, pdwSize should point to a DWORD that indicates the size of the buffer in bytes.
	// On exit, the DWORD contains the number of bytes transferred or available to be transferred into the buffer (including the nul-terminating byte).
	// Equivalent to  EXTENSION_CONTROL_BLOCK::GetServerVariable.
	BOOL GetServerVariable(
		LPCSTR pszVariableName,
		LPSTR pvBuffer,
		DWORD * pdwSize) throw()
	{
		BOOL		bRet	=	TRUE;
		CStringA	strValue;

		
		if( stricmp( pszVariableName, "ALL_RAW") == 0 )
		{
			// render all map
			POSITION	pos;
			CStringA	strName, strValue;
			
			pos	=	m_requestHeaderMap.GetStartPosition();
			while( pos != NULL )
			{
				m_requestHeaderMap.GetNextAssoc(pos, strName, strValue);
				upcaseHttpHeaderName(strName);

				strValue	+=	strName;
				strValue	+=	":";
				strValue	+=	strValue;
			}
			
		}
		else if( stricmp( pszVariableName, "URL") == 0 )
		{
			LPCSTR	szDllName	=	strrchr(m_dllPath, '\\');
			if( NULL == szDllName )
				szDllName	=	m_dllPath;
			strValue	=	szDllName;	
		}
		else if( stricmp( pszVariableName, "SERVER_NAME") == 0 )
		{
			strValue	=	"NoServer";
		}
		else if( stricmp( pszVariableName, "SERVER_PROTOCOL") == 0 )
		{
			strValue	=	m_szProtocol;
		}
		else if( stricmp( pszVariableName, "HTTPS") == 0 )
		{
			strValue	=	"off";
		}
		else if( strstr(pszVariableName, "HTTP_") == pszVariableName)
		{
			LPCSTR	szVarName	=	pszVariableName + strlen( "HTTP_");
			CStringA	strVarName	=	szVarName;
			strVarName.MakeLower();
			if( !m_requestHeaderMap.Lookup( strVarName, strValue ) )
				strValue.Empty();
			else
				strValue	+=	"\r\n";
		}
		else
		{
			if (pvBuffer)
				*pvBuffer = 0;
			if (pdwSize)
				*pdwSize = 0;

			return	FALSE;
		}

		if( *pdwSize > (DWORD)strValue.GetLength() )
		{
			if(  pvBuffer )
				strncpy(pvBuffer, strValue, strValue.GetLength() + 1);
		}
		else
		{
			if(  pvBuffer )
				*pvBuffer	=	'\0';
			
			bRet	=	FALSE;
		}
		
		*pdwSize	=	strValue.GetLength() + 1;
		
		return bRet;
	}

	// Synchronously sends the data present in the given buffer to the client that made the request.
	// Returns TRUE on success, and FALSE on failure. Call GetLastError to get extended error information.
	// Equivalent to EXTENSION_CONTROL_BLOCK::WriteClient(..., HSE_IO_SYNC).
	BOOL WriteClient(void *pvBuffer, DWORD *pdwBytes) throw()
	{
		HRESULT	hRet	=	m_responseStream.WriteStream( (LPCSTR)pvBuffer, *pdwBytes, NULL);
		if( SUCCEEDED( hRet ) )
		{
			if( m_logOption & SOAP_DEBUG_LOG_SOAP )
			{
				hRet	=	m_OutFile.Write(pvBuffer, *pdwBytes);
				if( !SUCCEEDED(hRet) )
					LogServerError(_T("Error trying to write to Output file\r\n"));
			}
		}
		else
			LogServerError(_T("Error trying to write to m_responseStream\r\n"));
		
		return (hRet==S_OK)?TRUE:FALSE;
	}

	// Asynchronously sends the data present in the given buffer to the client that made the request.
	// Returns TRUE on success, and FALSE on failure. Call GetLastError to get extended error information.
	// Equivalent to EXTENSION_CONTROL_BLOCK::WriteClient(..., HSE_IO_ASYNC).
	BOOL AsyncWriteClient(void *pvBuffer, DWORD *pdwBytes) throw()
	{
		
		return WriteClient(pvBuffer, pdwBytes);
	}

	// Call this function to synchronously read information from the body of the web client's HTTP request into the buffer supplied by the caller.
	// Returns TRUE on success, and FALSE on failure. Call GetLastError to get extended error information.
	// Equivalent to EXTENSION_CONTROL_BLOCK::ReadClient.
	BOOL ReadClient(void * pvBuffer, DWORD * pdwSize) throw()
	{
		ATLASSERT(pdwSize != NULL);
		DWORD dwRead = 0;
		ULONG	ulRead;
		HRESULT	hr	=	m_requestStream.Read( pvBuffer, *pdwSize, &ulRead);
		*pdwSize = ulRead;
		return (hr == S_OK ? TRUE : FALSE);
	}

	// Call this function to asynchronously read information from the body of the web client's HTTP request into the buffer supplied by the caller.
	// Returns TRUE on success, and FALSE on failure. Call GetLastError to get extended error information.
	// Equivalent to the HSE_REQ_ASYNC_READ_CLIENT server support function.
	BOOL AsyncReadClient(void * pvBuffer, DWORD * pdwSize) throw()
	{
		return ReadClient(pvBuffer, pdwSize);
	}
	
	// Call this function to redirect the client to the specified URL.
	// The client receives a 302 (Found) HTTP status code.
	// Returns TRUE on success, and FALSE on failure.
	// Equivalent to the HSE_REQ_SEND_URL_REDIRECT_RESP server support function.
	BOOL SendRedirectResponse(LPCSTR /*pszRedirectURL*/) throw()
	{
		LogServerError(_T("IHttpServerContext::SendRedirectResponse not supported in command line mode.\r\n"));
		return FALSE;
	}

	// Call this function to retrieve a handle to the impersonation token for this request.
	// An impersonation token represents a user context. You can use the handle in calls to ImpersonateLoggedOnUser or SetThreadToken.
	// Do not call CloseHandle on the handle.
	// Returns TRUE on success, and FALSE on failure.
	// Equivalent to the HSE_REQ_GET_IMPERSONATION_TOKEN server support function.

	// TODO (jasjitg): Need to find a way to make this work now.
	BOOL GetImpersonationToken(HANDLE * /*pToken*/) throw()
	{
		LogServerError(_T("IHttpServerContext::GetImpersonationToken not supported in command line mode.\r\n"));
		return FALSE;
	}

	// Call this function to send an HTTP response header to the client including the HTTP status, server version, message time, and MIME version.
	// Returns TRUE on success, and FALSE on failure.
	// Equivalent to the HSE_REQ_SEND_RESPONSE_HEADER_EX server support function.
	BOOL SendResponseHeader(
		LPCSTR pszHeader = "Content-Type: text/html\r\n\r\n",
		LPCSTR pszStatusCode = "200 OK",
		BOOL fKeepConn=FALSE) throw()
	{
		if( m_logOption & SOAP_DEBUG_LOG_HTTP )
		{
			// Dump HTTP Content
			CStringA	strBuffer;
			
			if( fKeepConn )
				strBuffer.Format("HTTP/1.1 %s\r\n%s", pszStatusCode, pszHeader);
			else
				strBuffer.Format("HTTP/1.1 %s\r\nConnection:Close\r\n%s", pszStatusCode, pszHeader);
			
			HRESULT	hRet	=	m_OutFile.Write((void*)(LPSTR)strBuffer.GetBuffer(), strBuffer.GetLength());
			if( !SUCCEEDED(hRet) )
				LogServerError(_T("IHttpServerContext::SendResponseHeader failed in writing to output file.\r\n"));
		}
		
		return TRUE;
	}

	// Call this function to terminate the session for the current request.
	// Returns TRUE on success, and FALSE on failure.
	// Equivalent to the HSE_REQ_DONE_WITH_SESSION server support function.
	BOOL DoneWithSession(DWORD /*dwStatusCode*/) throw()
	{
		LogServerError(_T("IHttpServerContext::DoneWithSession not supported in command line mode.\r\n"));
		return FALSE;
	}

	// Call this function to set a special callback function that will be used for handling the completion of asynchronous I/O operations.
	// Returns TRUE on success, and FALSE on failure.
	// Equivalent to the HSE_REQ_IO_COMPLETION server support function.
	BOOL RequestIOCompletion(PFN_HSE_IO_COMPLETION /*pfn*/, DWORD * /*pdwContext*/) throw()
	{
		LogServerError(_T("IHttpServerContext::RequestIOCompletion not supported in command line mode.\r\n"));
		return FALSE;
	}

	// Call this function to transmit a file asynchronously to the client.
	// Returns TRUE on success, and FALSE on failure.
	// Equivalent to the HSE_REQ_TRANSMIT_FILE server support function.
	BOOL TransmitFile(
		HANDLE hFile,
		PFN_HSE_IO_COMPLETION /*pfn*/,
		void * /*pContext*/,
		LPCSTR /*szStatusCode*/,
		DWORD /*dwBytesToWrite*/,
		DWORD /*dwOffset*/,
		void * /*pvHead*/,
		DWORD /*dwHeadLen*/,
		void * /*pvTail*/,
		DWORD /*dwTailLen*/,
		DWORD /*dwFlags*/) throw()
	{
		char szBuffer[1024];
		DWORD dwLen;
		OVERLAPPED overlapped;
		memset(&overlapped, 0, sizeof(OVERLAPPED));
		HANDLE hEvent = CreateEvent(NULL, TRUE, TRUE, NULL);
		if (!hEvent)
			return FALSE;
		overlapped.hEvent = hEvent;
		CHandle hdlEvent;
		hdlEvent.Attach(hEvent);
		DWORD dwErr;
		do
		{
			BOOL bRet = ::ReadFile(hFile, szBuffer, 1024, &dwLen, &overlapped);
			if (!bRet && (dwErr = GetLastError()) != ERROR_IO_PENDING && dwErr != ERROR_IO_INCOMPLETE)
				return FALSE;

			if (!GetOverlappedResult(hFile, &overlapped, &dwLen, TRUE))
				return FALSE;

			if (dwLen)
			{
				DWORD dwWritten = dwLen;
				if (!WriteClient(szBuffer, &dwWritten))
					return FALSE;
			}

		} while (dwLen != 0);

		return TRUE;
	}

    // Appends the string szMessage to the web server log for the current
    // request.
    // Returns TRUE on success, FALSE on failure.
    // Equivalent to the HSE_APPEND_LOG_PARAMETER server support function.
    BOOL AppendToLog(LPCSTR /*szMessage*/, DWORD * /*pdwLen*/) throw()
    {
		LogServerError(_T("IHttpServerContext::AppendToLog not supported in command line mode.\r\n"));
		return FALSE;
    }

	BOOL MapUrlToPathEx(LPCSTR /*szLogicalPath*/, DWORD /*dwLen*/, HSE_URL_MAPEX_INFO * /*pumInfo*/)
	{
		LogServerError(_T("IHttpServerContext::MapUrlToPathEx not supported in command line mode.\r\n"));
		return FALSE;
	}

};





/*
	CSoapDebugExtension -- IIsapiExtension implementation designed to work  with CSoapDebugClient
*/
class CSoapDebugExtension: public IServiceProvider, public IIsapiExtension
{
protected:

	typedef CStencilCache<CWorkerThread<> > stencilCacheType;
	CWorkerThread<> m_WorkerThread;
	CDllCache<CWorkerThread<>, CDllCachePeer> m_DllCache;
	CComObjectGlobal<CStencilCache<CWorkerThread<> > > m_StencilCache;
	CDefaultErrorProvider m_UserErrorProvider;

	CIsapiWorker m_Worker;

	// Dynamic services stuff
	struct ServiceNode
	{
		HINSTANCE hInst;
		IUnknown *punk;
		GUID guidService;
		IID riid;

		ServiceNode() throw()
		{
		}

		ServiceNode(const ServiceNode& that) throw()
			:hInst(that.hInst), punk(that.punk), guidService(that.guidService), riid(that.riid)
		{
		}

		const ServiceNode& operator=(const ServiceNode& that) throw()
		{
			if (this != &that)
			{
				hInst = that.hInst;
				punk = that.punk;
				memcpy(&guidService, &that.guidService, sizeof(guidService));
				memcpy(&riid, &that.riid, sizeof(riid));
			}
			return *this;
		}
	};

	class CServiceEqualHelper
	{
	public:
		static bool IsEqual(const ServiceNode& t1, const ServiceNode& t2)
		{
			return (InlineIsEqualGUID(t1.guidService, t2.guidService) != 0);
		}
	};

	CSimpleArray<ServiceNode, CServiceEqualHelper> m_serviceMap;

public:

	CString m_strErr;
	
	CSoapDebugExtension() throw()
	{
	}

	AtlServerRequest *CreateRequest()
	{
		AtlServerRequest *pRequest = (AtlServerRequest *) malloc(max(sizeof(AtlServerRequest), sizeof(CComObjectNoLock<CServerContext>)));
		if (!pRequest)
			return NULL;
		pRequest->cbSize = sizeof(AtlServerRequest);
		return pRequest;
	}

	void FreeRequest(AtlServerRequest *pRequest)
	{
		if (pRequest)
		{
			if (pRequest->pHandler)
				pRequest->pHandler->Release();
			if (pRequest->pServerContext)
				pRequest->pServerContext->Release();
			if (pRequest->pDllCache && pRequest->hInstDll)
				pRequest->pDllCache->ReleaseModule(pRequest->hInstDll);
		}

		//free(pRequest);
	}

	BOOL Initialize() throw()
	{
		if (!m_Worker.Initialize(static_cast<IIsapiExtension*>(this)))
			return FALSE;

		if (S_OK != m_WorkerThread.Initialize())
			return FALSE;

		if (FAILED(m_DllCache.Initialize(&m_WorkerThread, ATL_DLL_CACHE_TIMEOUT)))
		{
			m_WorkerThread.Shutdown();
			return FALSE;
		}

		if (S_OK != m_StencilCache.Initialize(static_cast<IServiceProvider*>(this), &m_WorkerThread, 
				ATL_STENCIL_CACHE_TIMEOUT, ATL_STENCIL_LIFESPAN))
		{
			m_DllCache.Uninitialize();
			m_WorkerThread.Shutdown();
			return FALSE;
		}

		return TRUE;
	}

	BOOL Uninitialize() throw()
	{
		for (int i=0; i < m_serviceMap.GetSize(); i++)
		{
			ATLASSERT(m_serviceMap[i].punk != NULL);
			m_serviceMap[i].punk->Release();
			m_DllCache.ReleaseModule(m_serviceMap[i].hInst);
		}

		m_WorkerThread.Shutdown();
		m_StencilCache.Uninitialize();
		m_DllCache.Uninitialize();
		m_Worker.Terminate(static_cast<IIsapiExtension*>(this));
		return TRUE;
	}

	void RequestComplete(AtlServerRequest * /*pRequestInfo*/, DWORD /*dwStatus*/, DWORD /*dwSubStatus*/) throw()
	{
	}

	HTTP_CODE GetHandlerName(LPCSTR szFileName, LPSTR szHandlerName) throw()
	{
		return _AtlGetHandlerName(szFileName, szHandlerName);
	}

	HTTP_CODE LoadDispatchFile(LPCSTR szFileName, AtlServerRequest *pRequestInfo) throw()
	{
		CStencil *pStencil = NULL;
		HCACHEITEM hStencil = NULL;
		CHAR szDllPath[MAX_PATH+1];
		CHAR szHandlerName[ATL_MAX_HANDLER_NAME_LEN+1];

		pRequestInfo->pHandler = NULL;
		pRequestInfo->hInstDll = NULL;

		USES_CONVERSION;

		m_StencilCache.LookupStencil(szFileName, &hStencil);
		if (!hStencil)
		{
			char szHandlerDllName[MAX_PATH+ATL_MAX_HANDLER_NAME_LEN+2];
			// not in the cache, so open the file
			HTTP_CODE hcErr = GetHandlerName(szFileName, szHandlerDllName);
			if (hcErr)
				return hcErr;
			DWORD dwDllPathLen = MAX_PATH+1;
			DWORD dwHandlerNameLen = ATL_MAX_HANDLER_NAME_LEN+1;
			if (!_AtlCrackHandler(szHandlerDllName, szDllPath, &dwDllPathLen, szHandlerName, &dwHandlerNameLen))
			{
				HTTP_ERROR(500, ISE_SUBERR_HANDLER_NOT_FOUND);
			}
			ATLASSERT(*szHandlerName);
			ATLASSERT(*szDllPath);
			if (!*szHandlerName)
				return HTTP_ERROR(500, ISE_SUBERR_HANDLER_NOT_FOUND);
		}
		else
		{
			m_StencilCache.GetStencil(hStencil, (void **) &pStencil);
			pStencil->GetHandlerName(szDllPath, szHandlerName);
			m_StencilCache.ReleaseStencil(hStencil);

			if (!*szHandlerName)
				return HTTP_ERROR(500, ISE_SUBERR_BADSRF); // bad srf file
		}
		return LoadRequestHandler(szDllPath, szHandlerName, pRequestInfo->pServerContext, &pRequestInfo->hInstDll, &pRequestInfo->pHandler);
	}


	HTTP_CODE LoadDllHandler(LPCSTR szFileName, AtlServerRequest *pRequestInfo) throw()
    {
        HTTP_CODE hcErr = HTTP_FAIL;
		CHttpRequest Request;
		BOOL bRet = Request.Initialize(pRequestInfo->pServerContext, 0);
        if (bRet)
        {
            LPCSTR szHandler = Request.QueryParams.Lookup("Handler");
            if (!szHandler)
            {
				szHandler = "Default";
            }

			hcErr = LoadRequestHandler(szFileName, szHandler, pRequestInfo->pServerContext, 
				&pRequestInfo->hInstDll, &pRequestInfo->pHandler);
        }
        else
		{
            hcErr = HTTP_ERROR(500, ISE_SUBERR_UNEXPECTED);
		}

        return hcErr;
    }


	BOOL DispatchStencilCall(AtlServerRequest * /*pRequestInfo*/) throw()
	{
		return FALSE;
	}

	virtual void ThreadTerminate(DWORD /*dwThreadId*/) { }
    virtual BOOL QueueRequest(AtlServerRequest * /*pRequestInfo*/) { return FALSE; }
	virtual CIsapiWorker *GetThreadWorker() { return &m_Worker; }
	virtual BOOL SetThreadWorker(CIsapiWorker * /*pWorker*/) { return TRUE; }
	BOOL OnThreadAttach() { return TRUE; }
	void OnThreadTerminate() {}


	BOOL executeSoapRequest(CSoapDebugClient		*pSoapDebugClient)
	{
		pSoapDebugClient->SetPathTranslated(NULL);

		AtlServerRequest RequestInfo;
		AtlServerRequest *pRequestInfo = &RequestInfo;
		pRequestInfo->pServerContext = static_cast<IHttpServerContext*>(pSoapDebugClient);
		pRequestInfo->dwRequestType = ATLSRV_REQUEST_STENCIL;
		pRequestInfo->dwRequestState = ATLSRV_STATE_BEGIN;
		pRequestInfo->pExtension = static_cast<IIsapiExtension*>(this);
		pRequestInfo->pDllCache = static_cast<IDllCache *>(&m_DllCache);
		pRequestInfo->dwStartTicks = 0;

		HTTP_CODE hcErr = HTTP_SUCCESS;
		if (pRequestInfo->dwRequestState == ATLSRV_STATE_BEGIN)
        {
			LPCSTR szFileName = pSoapDebugClient->GetScriptPathTranslated();

            if (!szFileName)
			{
				m_strErr.Format(_T("ERROR: Invalid file: %s"), szFileName);
				RequestComplete(pRequestInfo, 500, 8);
				return FALSE;
			}

			LPCSTR szDot = szFileName + strlen(szFileName)-4;
			if (stricmp(szDot, c_AtlSRFExtension) == 0)
			{
				pRequestInfo->dwRequestType = ATLSRV_REQUEST_STENCIL;
			    hcErr = LoadDispatchFile(szFileName, pRequestInfo);
			}
			else if (_stricmp(szDot, ".dll") == 0)
		    {
                pRequestInfo->dwRequestType = ATLSRV_REQUEST_DLL;
		        hcErr = LoadDllHandler(szFileName, pRequestInfo);
            }
			else
			{
				hcErr = HTTP_FAIL;
			}

			if (hcErr)
			{
				if (hcErr == HTTP_ERROR(500, ISE_SUBERR_BADSRF))
					m_strErr.Format(_T("ERROR: Invalid SRF file: %s"), szFileName);
				else if (hcErr == HTTP_ERROR(500, ISE_SUBERR_READFILEFAIL))
					m_strErr.Format(_T("ERROR: Failed to read SRF file: %s"), szFileName);
				else if (hcErr == HTTP_ERROR(500, ISE_SUBERR_UNEXPECTED))
					m_strErr = _T("ERROR: Unexpected Error Loading DLL");
				RequestComplete(pRequestInfo, HTTP_ERROR_CODE(hcErr), HTTP_SUBERROR_CODE(hcErr));
				return FALSE;
			}

			// initialize the handler
			DWORD dwStatus = 0;

			hcErr = pRequestInfo->pHandler->GetFlags(&dwStatus);
			// Ignoring caching options
			// Log errors on async
			if (dwStatus & ATLSRV_INIT_USEASYNC)
			{
				// TODO: Log error, or come up with a way to make it work
				RequestComplete(pRequestInfo, 500, SUBERR_NONE);
				return FALSE;
			}

			hcErr = pRequestInfo->pHandler->InitializeHandler(pRequestInfo, static_cast<IServiceProvider*>(this));
			if (hcErr == HTTP_SUCCESS)
				hcErr = pRequestInfo->pHandler->HandleRequest(pRequestInfo, static_cast<IServiceProvider*>(this));
		}

        // TODO: andrewla : handle HTTP_SUCCESS_NO_CACHE
        // Also, this model doesn't exactly work -- an asynchronous call can call back at
        // any time, so setting the dwRequestState here could be too late.  Client should probably
        // set it rather than relying on vcisapi to do it.
        if (hcErr == HTTP_SUCCESS_ASYNC || hcErr == HTTP_SUCCESS_ASYNC_DONE)
		{
			// TODO: Log error or fix
		}
        else
		{
			pRequestInfo->pHandler->UninitializeHandler();
		    RequestComplete(pRequestInfo, HTTP_ERROR_CODE(hcErr), HTTP_SUBERROR_CODE(hcErr));
		}

		FreeRequest(pRequestInfo);
		return TRUE;
	}

	HRESULT STDMETHODCALLTYPE QueryInterface(REFIID riid, void **ppv) throw()
	{
		if (!ppv)
			return E_POINTER;
		if (InlineIsEqualGUID(riid, __uuidof(IUnknown)) ||
			InlineIsEqualGUID(riid, __uuidof(IServiceProvider)))
		{
			*ppv = static_cast<IUnknown*>(static_cast<IServiceProvider*>(this));
			AddRef();
			return S_OK;
		}
		if (InlineIsEqualGUID(riid, __uuidof(IIsapiExtension)))
		{
			*ppv = static_cast<IUnknown*>(static_cast<IIsapiExtension*>(this));
			AddRef();
			return S_OK;
		}
		return E_NOINTERFACE;
	}

	virtual HRESULT STDMETHODCALLTYPE QueryService(
		REFGUID guidService,
		REFIID riid,
		void **ppvObject) throw()
	{
		if (!ppvObject)
			return E_POINTER;

		if (InlineIsEqualGUID(guidService, __uuidof(IDllCache)))
			return m_DllCache.QueryInterface(riid, ppvObject);
		else if (InlineIsEqualGUID(guidService, __uuidof(IStencilCache)))
			return m_StencilCache.QueryInterface(riid, ppvObject);

		return E_NOINTERFACE;
	}


	virtual HRESULT AddService(REFGUID guidService, REFIID riid, IUnknown *punk, HINSTANCE hInstance) throw()
	{
		if (!m_DllCache.AddRefModule(hInstance))
			return E_FAIL;
		
		ServiceNode srvNode;
		srvNode.hInst = hInstance;
		srvNode.punk = punk;
		memcpy(&srvNode.guidService, &guidService, sizeof(guidService));
		memcpy(&srvNode.riid, &riid, sizeof(riid));
		
		// if the service is already there, return S_FALSE
		int nIndex = m_serviceMap.Find(srvNode);
		if (nIndex >= 0)
			return S_FALSE;

		if (!m_serviceMap.Add(srvNode))
			return E_OUTOFMEMORY;

		punk->AddRef();
		return S_OK;
	}

	virtual HRESULT RemoveService(REFGUID guidService, REFIID riid) throw()
	{	
		ServiceNode srvNode;
		memcpy(&srvNode.guidService, &guidService, sizeof(guidService));
		memcpy(&srvNode.riid, &riid, sizeof(riid));
		int nIndex = m_serviceMap.Find(srvNode);
		if (nIndex < 0)
			return S_FALSE;

		ATLASSERT(m_serviceMap[nIndex].punk != NULL);
		m_serviceMap[nIndex].punk->Release();

		HINSTANCE hInstRemove = m_serviceMap[nIndex].hInst;

		m_serviceMap.RemoveAt(nIndex);

		if (!m_DllCache.ReleaseModule(hInstRemove))
			return S_FALSE;

		return S_OK;
	}

	HRESULT GetService(REFGUID guidService, REFIID riid, void **ppvObject) throw()
	{
		if (!ppvObject)
			return E_POINTER;

		ServiceNode srvNode;
		memcpy(&srvNode.guidService, &guidService, sizeof(guidService));
		memcpy(&srvNode.riid, &riid, sizeof(riid));
		
		int nIndex = m_serviceMap.Find(srvNode);
		if (nIndex < 0)
			return E_NOINTERFACE;

		ATLASSERT(m_serviceMap[nIndex].punk != NULL);
		return m_serviceMap[nIndex].punk->QueryInterface(riid, ppvObject);
	}

	ULONG STDMETHODCALLTYPE AddRef()
	{
		return 1;
	}
	
	ULONG STDMETHODCALLTYPE Release()
	{
		return 1;
	}

	HTTP_CODE LoadRequestHandler(LPCSTR szDllPath, LPCSTR szHandlerName, IHttpServerContext *pServerContext,
		HINSTANCE *phInstance, IRequestHandler **ppHandler) throw()
	{
		return _AtlLoadRequestHandler(szDllPath, szHandlerName, pServerContext, phInstance, 
			ppHandler, this, static_cast<IDllCache*>(&m_DllCache));
	} // LoadRequestHandler


	HTTP_CODE TransferRequest(
		AtlServerRequest *pRequest, 
		IServiceProvider *pServiceProvider,
		IWriteStream *pWriteStream,
		IHttpRequestLookup *pLookup,
		LPCSTR szNewUrl,
		WORD nCodePage,
		bool bContinueAfterProcess = false,
		CStencilState *pState = NULL)
	{
		return _AtlTransferRequest(pRequest, pServiceProvider, pWriteStream,
			pLookup, szNewUrl, nCodePage, bContinueAfterProcess, pState);
	}
};




inline HRESULT CSoapDebugClient::SendRequest(LPCTSTR tszAction) throw()
{
	//printf("SoapDebugClient : SendRequest, Action = %s\n", szAction);
	CStringA		strContentLength;
	CStringA		strUserAgent;
	CStringA		strHost;
	CStringA		strSoapAction;
	
	strcpy(m_szVerb, "POST");
	strcpy(m_szContentType, "text/xml\r\n");

	LPCSTR			szAction;
#ifdef UNICODE
	CW2A			w2aAction(tszAction);
	szAction	=	w2aAction;
#else
	szAction	=	tszAction;
#endif


	strContentLength.Format("%d\r\n", m_requestStream.m_nBodyLen);
	strUserAgent	=	"VCSoapClient\r\n";
	strHost			=	"NoServer\r\n";



	LPCSTR		pSoapAction	=	strrchr(szAction, '#');
	if( pSoapAction )
	{
		ATLASSERT( strlen(szAction) < ATL_URL_MAX_URL_LENGTH );
		char buff[ATL_URL_MAX_URL_LENGTH + 1];
		strcpy(buff, szAction);
		strSoapAction	=	buff;
	}
	else
		return E_FAIL;

	// Set headers
	m_requestHeaderMap.SetAt( "content-length", strContentLength);
	m_requestHeaderMap.SetAt( "soapaction", strSoapAction);
	m_requestHeaderMap.SetAt( "host", strHost);
	m_requestHeaderMap.SetAt( "user-agent", strUserAgent);
	m_requestHeaderMap.SetAt( "content-type", m_szContentType);


	if( !SUCCEEDED(m_OutFile.Write((void*)HTTP_HEADERS_END, 4)) )
		LogServerError(_T("Error trying to dump the HTTP request\r\n"));

	if( m_logOption & SOAP_DEBUG_LOG_HTTP )
	{
		CStringA		strHttpRequest;
		POSITION		pos;
		CStringA		strName, strValue;

		// dump the HTTP Request
		strHttpRequest.Format("%s	%s?%s %s", m_szVerb, m_dllPath, m_szQueryString, m_szProtocol);
		strHttpRequest	+=	"\r\n";

		// dump the headers
		pos	=	m_requestHeaderMap.GetStartPosition();
		while( pos != NULL )
		{
			m_requestHeaderMap.GetNextAssoc(pos, strName, strValue);
			upcaseHttpHeaderName(strName);

			strHttpRequest	+=	strName;
			strHttpRequest	+=	": ";
			strHttpRequest	+=	strValue;
		}

		strHttpRequest	+=	"\r\n";

		if( !SUCCEEDED(m_OutFile.Write((void*)strHttpRequest.GetBuffer(), strHttpRequest.GetLength())) )
			LogServerError(_T("Error trying to dump the HTTP request\r\n"));
	}
	
	if( m_logOption & SOAP_DEBUG_LOG_SOAP)
	{
		if( !SUCCEEDED(m_OutFile.Write((void*)m_requestStream.m_str.GetBuffer(), m_requestStream.m_str.GetLength())) )
			LogServerError(_T("Error trying to dump the HTTP request\r\n"));

		if( !SUCCEEDED(m_OutFile.Write((void*)"\r\n", 2)) )
			LogServerError(_T("Error trying to dump the HTTP request\r\n"));
	}

	
	//DispatchSoapCall
	HRESULT		hRet	=	S_OK;
	CSoapDebugExtension	theExtension;

	if (!theExtension.Initialize())
	{
		LogServerError(_T("ERROR: Failed to initialize extension\n"));
		return E_FAIL;
	}

	if (!theExtension.executeSoapRequest(this))
	{
		LogServerError(theExtension.m_strErr);
		hRet	=	E_FAIL;
	}

	theExtension.Uninitialize();
	
	if( !SUCCEEDED(m_OutFile.Write((void*)HTTP_HEADERS_END, 4)) )
		LogServerError(_T("Error trying to dump the HTTP request\r\n"));
	return hRet;
}




#endif// SOAP_DEBUG_CLIENT_H_INCLUDED






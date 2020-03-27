// File: SoapTCPClient.h
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
#ifndef _WINSOCKAPI_
	#include <winsock2.h>
#endif
#include <atlspriv.h>


#include "ProtocolConsts.h"
#include "StreamOnCString.h"

#include <iostream>
using namespace std;



// LOG options
class CSoapTCPClient : public ZEvtSyncSocket
{
protected:
	CReadWriteStreamOnCString	m_requestStream;
	CReadWriteStreamOnCString	m_responseStream;
	CString						m_strSrvAddress;
	unsigned short				m_nPort;
	SOAPCLIENT_ERROR			m_errorState;
	CStringA					m_strURL;
public:
	CSoapTCPClient(LPCTSTR szURL = NULL) : m_strURL(CT2A(szURL)), m_errorState(SOAPCLIENT_SUCCESS)
	{
	}

	~CSoapTCPClient() throw()
	{
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

	void	SetTCPSoapServer(LPCTSTR szAddr, unsigned short nPort)
	{
		m_strSrvAddress	=	szAddr;
		m_nPort	=	nPort;
	}
	void CleanupClient() throw()
	{
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
	
	HRESULT SendRequest(LPCTSTR tszAction) throw()
	{
		//printf("SoapDebugClient : SendRequest, Action = %s\n", szAction);
		CAtlIsapiBuffer<>		buffWork;
		ATLASSERT(tszAction != NULL);

		LPCSTR	szAction;

#ifdef UNICODE
		CW2A	w2aAction(tszAction);
		szAction	=	w2aAction;
		
#else
		szAction	=	tszAction;
#endif


		if( strstr(szAction, "SOAPAction:") == szAction )
			szAction	+=	strlen("SOAPAction:");

		while( *szAction	==	' ')
			szAction++;
		

		


		
		if( m_strSrvAddress.IsEmpty() )
		{
			cout	<<	"No server specified. Use SetTCPSoapServer"	<<	endl;	
			return E_FAIL;
		}

		if( !szAction)
		{
			cout	<<	"The SOAPAction parameter is NULL. Cannot prepare request"	<<	endl;	
			return E_POINTER;
		}
		
		// Build the request
		{
			// add header
			buffWork.Append(SOCKET_SOAP_REQUEST_HEADER, SOCKET_SOAP_REQUEST_HEADER_LEN);

			// add size
			DWORD	dwSize;
			dwSize	=	m_strURL.GetLength();
			dwSize	+=	1;
			dwSize	+=	(DWORD)strlen(szAction);
			dwSize	+=	1;
			dwSize	+=	m_requestStream.m_str.GetLength();

			buffWork.Append( (LPCSTR)&dwSize, sizeof(DWORD));

			buffWork.Append( (LPCSTR)m_strURL, m_strURL.GetLength() + 1);
			buffWork.Append( szAction, (int)strlen(szAction) + 1);
			buffWork.Append( (LPCSTR)m_requestStream.m_str, m_requestStream.m_str.GetLength());
		}

		if( !Connect( (LPCTSTR)m_strSrvAddress, m_nPort) )
		{
			
			cout	<<	"Cannot connect to "	<<	(LPCTSTR)m_strSrvAddress	<<	":"	<<	m_nPort	<<	endl;	
			return E_FAIL;
		}

		DWORD	dwWrite;
		dwWrite	=	buffWork.GetLength();
		if( !Write( (const unsigned char*)(LPCSTR)buffWork, &dwWrite) )
		{
			cout	<<		"Error writing to the socket"	<<	endl;
			return E_FAIL;
		}

		buffWork.Empty();

		HRESULT	hRet		=	S_OK;
		bool	bKeepReading	=	true;

		{
			unsigned char	buffRead[SOCKET_BUFFER_SIZE];
			DWORD			dwRead	=	SOCKET_BUFFER_SIZE;
			DWORD			dwPacketSize	=	0;
			DWORD			dwError			=	TCPSOAP_ERROR_INCOMPLETE;
			
			while( bKeepReading)
			{
				bool	bRead	=	Read( buffRead, &dwRead);
				if(!bRead)
				{
					cout	<<	"Error reading from the socket"	<<	endl;
					return E_FAIL;
				}

				buffWork.Append( (LPCSTR)buffRead, dwRead );
				
				if( dwError	== TCPSOAP_ERROR_INCOMPLETE )
				{
					// try to parse the string
					if( buffWork.GetLength() >= SOCKET_SOAP_RESPONSE_HEADER_LEN + sizeof(dwError))
					{
						// check header
						char	header[SOCKET_SOAP_RESPONSE_HEADER_LEN + 1];
						memcpy( header, (LPCSTR)buffWork, SOCKET_SOAP_REQUEST_HEADER_LEN);
						header[SOCKET_SOAP_REQUEST_HEADER_LEN]	=	'\0';

						if( 0 !=	strcmp( header, SOCKET_SOAP_RESPONSE_HEADER))
						{
							// stop reading and fail
							cout	<<	"Incorrect transport header received : "	<<	header	<<	endl;
							bKeepReading	=	false;
							hRet			=	E_FAIL;
						}

						// HeaderOK< get the error
						const	char	*pdwSize	=	NULL;
						pdwSize	=	(LPCSTR)buffWork + SOCKET_SOAP_RESPONSE_HEADER_LEN;
						memcpy( &dwError, pdwSize, sizeof(dwError));

						hRet	=	E_FAIL;
						switch( dwError )
						{
							case TCPSOAP_ERROR_SUCCESS:
								hRet	=	S_OK;
								break;
							case TCPSOAP_ERROR_TRANSPORT:
								cout	<<	"Socket transport error"	<<	endl;
								bKeepReading	=	false;
								break;
							case TCPSOAP_ERROR_PROCESSING:
								cout	<<	"Server processing error (non SOAP)"	<<	endl;
								bKeepReading	=	false;
								break;
							default:
								cout	<<	"Unexpected error message from the server"	<<	endl;
								bKeepReading	=	false;
								break;
						}
					}
				}

				if( dwError == TCPSOAP_ERROR_SUCCESS && dwPacketSize	==	0)
				{
					// error OK and the buffer size is not read yet
					if( buffWork.GetLength() >= SOCKET_SOAP_RESPONSE_HEADER_LEN + 2*sizeof(DWORD))
					{
						// Get the size
						const	char	*pdwSize	=	NULL;
						pdwSize	=	(LPCSTR)buffWork + SOCKET_SOAP_RESPONSE_HEADER_LEN + sizeof(dwError);
						memcpy( &dwPacketSize, pdwSize, sizeof(dwError));
					}

				}

				if( dwPacketSize > 0 )
				{
					DWORD	dwTotalSize	=	SOCKET_SOAP_RESPONSE_HEADER_LEN;
					dwTotalSize	+=	sizeof(dwError);
					dwTotalSize	+=	sizeof(dwPacketSize);
					dwTotalSize	+=	dwPacketSize;

					// IF already read the header, the size and the buffer, then stop reading
					if( dwTotalSize	<= buffWork.GetLength() )
						bKeepReading	=	false;
				}
			}// end while keep reading

			if( hRet	==	S_OK )
			{
				// no error occured
				LPCSTR	strSrc;

				strSrc	=	(LPCSTR)buffWork	+	SOCKET_SOAP_RESPONSE_HEADER_LEN + 2*sizeof(DWORD);
					
				m_responseStream.WriteStream ( strSrc, dwPacketSize, NULL);
			}
			else
				return hRet;
		}

		return S_OK;
		
	}
};




#endif// SOAP_DEBUG_CLIENT_H_INCLUDED






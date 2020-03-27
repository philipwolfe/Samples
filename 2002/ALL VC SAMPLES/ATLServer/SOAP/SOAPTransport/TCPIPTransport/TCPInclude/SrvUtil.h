// File: SrvUtil.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#ifndef UTIL_H_INCLUDED
#define UTIL_H_INCLUDED

#pragma once

#include <iostream>
using namespace std;

#include "ProtocolConsts.h"

namespace TCPUTIL	//rec proxy util
{
	class CRequest
	{
	public:
		// SOAP specific stuff
		
		CAtlIsapiBuffer<>		m_xmlBuffer;
		CStringA				m_strSOAPAction;
		CStringA				m_strURL;				
	public:

		CRequest()
		{
		}

		bool	Load(SOCKET s)
		{
			bool					bRet = true;
			bool					bKeepReading	=	true;
			char					buffRead[SOCKET_BUFFER_SIZE];
			int						iRetVal;
			DWORD					dwPacketSize = 0;
			CAtlIsapiBuffer<>		buffer;
			
			buffer.Empty();
			
			while( bKeepReading )
			{
				DWORD		dwTotalSize	=	0;
				memset(buffRead, 0, SOCKET_BUFFER_SIZE);

				iRetVal	=	::recv( s, buffRead, SOCKET_BUFFER_SIZE - 1, 0);
				
				if( iRetVal == SOCKET_ERROR || iRetVal == 0 )
				{
					cout	<<	"CRequest:failure in reading socket"<<endl;
					return false;
				}

				buffRead[iRetVal] =  0;
				buffer.Append( buffRead, iRetVal );


				if( dwPacketSize == 0 )
				{
					// try to parse the string
					if( buffer.GetLength() >= SOCKET_SOAP_REQUEST_HEADER_LEN + sizeof(DWORD))
					{
						DWORD	dwSize;
						
						// check header
						char	header[SOCKET_SOAP_REQUEST_HEADER_LEN + 1];
						memcpy( header, (LPCSTR)buffer, SOCKET_SOAP_REQUEST_HEADER_LEN);
						header[SOCKET_SOAP_REQUEST_HEADER_LEN]	=	'\0';

						if( 0 !=	strcmp( header, SOCKET_SOAP_REQUEST_HEADER))
						{
							// stop reading and fail
							cout	<<	"CRequest:Bad header"<<header<<endl;
							bKeepReading	=	false;
							bRet			=	false;
						}

						// Header OK, get the size of the buffer
						const	char	*pdwSize	=	NULL;
						pdwSize	=	(LPCSTR)buffer + SOCKET_SOAP_REQUEST_HEADER_LEN;
						memcpy( &dwSize, pdwSize, sizeof(DWORD));
						dwPacketSize	=	dwSize;

						// OK, we have the size too
						if( dwPacketSize == 0 )
						{
							// stop reading and fail
							bKeepReading	=	false;
							bRet			=	false;
						}
					}
				}

				if( dwPacketSize > 0 )
				{
					dwTotalSize	=	SOCKET_SOAP_REQUEST_HEADER_LEN;
					dwTotalSize	+=	sizeof(DWORD);
					dwTotalSize	+=	dwPacketSize;

					// IF already read the header, the size and the buffer, then stop reading
					if( dwTotalSize	<= buffer.GetLength() )
						bKeepReading	=	false;
				}
			}// end while keep reading

			

			if( bRet )
			{
				// everything is read successfully, set the locals
				const char	*pBuff	=	NULL;
				DWORD	dwXMLSize	=	0;
				pBuff	=	(LPCSTR)buffer	+	SOCKET_SOAP_REQUEST_HEADER_LEN + sizeof(DWORD);
				ATLASSERT( strlen(pBuff) );

				dwXMLSize		=	dwPacketSize;
				
				m_strURL		=	pBuff;
				dwXMLSize		-=	(DWORD)(1 + strlen(pBuff) );
				pBuff	+=	(strlen(pBuff) + 1);

				m_strSOAPAction	=	pBuff;
				dwXMLSize		-=	(DWORD)(1 + strlen(pBuff) );
				pBuff	+=	(strlen(pBuff) + 1);

				dwXMLSize		-=	(DWORD)(1 + strlen(pBuff) );
				

				m_xmlBuffer.Append( pBuff, dwXMLSize );
			}
			return bRet;
		}

	};


	class CResponse
	{
	public:
		CAtlIsapiBuffer<>	m_xmlBuffer;
		DWORD				m_dwError;
	public:
		CResponse()
		{
			m_dwError	=	TCPSOAP_ERROR_SUCCESS;
		}
		
		
		bool	Send( SOCKET s)
		{
			DWORD	dwRest;
			char	*pWrite;
			int		iRetVal;
			char	*pHeader	=	NULL;
			DWORD	dwHeaderSize	=	0;

			CAtlIsapiBuffer<>	buff;

/*	<SOCKET_SOAP_RESPONSE_HEADER>
	NNN..N (sizeof(DWORD) error code. If different from TCPSOAP_ERROR_SUCCESS, the rest is ignored)
	NNN..N (sizeof(DWORD) bytes with the size of the following packet)
	<XMLResponsePayload>
	*/
			dwHeaderSize	=	SOCKET_SOAP_RESPONSE_HEADER_LEN + sizeof(m_dwError);
			
			if( m_dwError == TCPSOAP_ERROR_SUCCESS )
				dwHeaderSize	+=	sizeof(DWORD);

			pHeader	=	new char[dwHeaderSize];
			pWrite	=	pHeader;

			// put header
			memcpy( pWrite, SOCKET_SOAP_RESPONSE_HEADER, SOCKET_SOAP_RESPONSE_HEADER_LEN);
			pWrite	+=	SOCKET_SOAP_RESPONSE_HEADER_LEN;

			// put error code
			memcpy( pWrite, &m_dwError, sizeof(m_dwError));
			pWrite	+=	sizeof(m_dwError);

			if( m_dwError == TCPSOAP_ERROR_SUCCESS )
			{
				DWORD	dwXMLSize	=	m_xmlBuffer.GetLength();
				memcpy( pWrite, &dwXMLSize, sizeof(DWORD));
			}

			buff.Append( pHeader, dwHeaderSize);

			if( m_dwError == TCPSOAP_ERROR_SUCCESS )
				buff.Append( (LPCSTR)m_xmlBuffer, m_xmlBuffer.GetLength() );


			dwRest	=	buff.GetLength();


			iRetVal	=	::send( s, (char*)(LPCSTR)buff, dwRest, 0);

			if( iRetVal != SOCKET_ERROR )
			{
				return true;
			}

			return false;
		}


	};
}
#endif  UTIL_H_INCLUDED
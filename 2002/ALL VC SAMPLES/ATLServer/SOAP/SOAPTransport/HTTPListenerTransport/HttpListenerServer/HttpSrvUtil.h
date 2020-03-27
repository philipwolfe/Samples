// File: HttpSrvUtil.h
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

#define	SOCKET_BACKLOG					5
#define	SOCKET_BUFFER_SIZE				2048

#include <atlisapi.h>

#define	HTTP_END_OF_LINE	"\r\n"
#define	HTTP_END_OF_HEADERS	"\r\n\r\n"
#define	HTTP_HEADER_CONTENT_LENGTH	"Content-Length"
#define	HTTP_HEADER_SOAP_ACTION	"SOAPAction"
namespace TCPUTIL	//rec proxy util
{
	enum eREQ_TYPE
	{
		REQ_HTTP_NONE,
		REQ_HTTP_GET,
		REQ_HTTP_POST,
		REQ_HTTP_ERROR
	};

	class CRequest
	{
	public:
		// SOAP specific stuff
		
		CAtlIsapiBuffer<>		m_xmlBuffer;
		CStringA				m_strSOAPAction;
		eREQ_TYPE				m_requestType;
		CStringA				m_strURL;
		CStringA				m_strHttpVer;
		CStringA				m_strFaultDetail;
	public:

		CRequest() : m_requestType(REQ_HTTP_NONE)
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

			CStringA				strVerb;
			
			m_strURL.Empty();
			m_strHttpVer.Empty();
			buffer.Empty();
			m_requestType	=	REQ_HTTP_NONE;
			m_strFaultDetail.Empty();
			
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


				if( (dwPacketSize == 0)  && (m_requestType != REQ_HTTP_GET) )
				{
					LPCSTR	szBuffer		=	buffer;
					LPCSTR	szEndOfFirstLine	=	NULL;
					LPCSTR	szEndHeaders	=	NULL;
					LPCSTR	pCurr			=	szBuffer;
					
					ATLASSERT( szBuffer != NULL );
					szEndOfFirstLine	=	strstr( szBuffer, HTTP_END_OF_LINE);
					
					if( strVerb.IsEmpty() && !szEndOfFirstLine )
					{	
						// Verb not decided yet and cannot be decided this time
						bKeepReading = true;
						continue;
					}

					if( m_requestType	==	REQ_HTTP_NONE )
					{
						// verb not decided yet, but \r\n found -- read verb, URL, HTTP Ver
						while( *pCurr && *pCurr != ' ' )
							strVerb +=	*pCurr++;
						
						if( *pCurr ) 
							pCurr++;
						while( *pCurr && *pCurr != ' ' )
							m_strURL +=	*pCurr++;

						if( *pCurr ) 
							pCurr++;
						while( *pCurr && *pCurr != '\r' )
							m_strHttpVer +=	*pCurr++;

						// Validate the input
						m_requestType	=	REQ_HTTP_ERROR;
						if( strVerb.CompareNoCase("POST") == 0)
							m_requestType	=	REQ_HTTP_POST;
						if( strVerb.CompareNoCase("GET") == 0)
							m_requestType	=	REQ_HTTP_GET;

						if( m_requestType == REQ_HTTP_ERROR)
							m_strFaultDetail	+=	"Not a recognized HTTP Verb &amp;";

						if( m_strURL.IsEmpty() )
						{
							m_requestType	=	REQ_HTTP_ERROR;
							m_strFaultDetail	+=	"Empty URL &amp;";
						}

						if( m_strHttpVer.Compare("HTTP/1.1") != 0 )
						{
							m_requestType	=	REQ_HTTP_ERROR;
							m_strFaultDetail	+=	"Not a recognized HTTP Version (only 1.1 is supported) &amp;";
						}

						if( m_requestType == REQ_HTTP_ERROR )
						{
							bKeepReading	=	false;
							break;
						}
					}

					szEndHeaders	=	strstr(szBuffer, HTTP_END_OF_HEADERS);
					if( !szEndHeaders )
					{
						bKeepReading	=	true;
						continue;
					}
					
					// from now on, the verb is set, the end of headers is found
					if( m_requestType == REQ_HTTP_GET )
					{
						bKeepReading	=	false;
					}

					if( m_requestType == REQ_HTTP_POST )
					{
						// before end of headers, take headers one by one to identify the Content-Length and the SOAPAction, then get the size
						CStringA	strLine;
						pCurr	=	szBuffer;

						while(pCurr <= szEndHeaders )
						{
							if( *pCurr != '\r' )
								// not end of line yet
								strLine	+=	*pCurr ++;
							else
							{
								// one line read. Treat it
								pCurr += 2; // jump over \r\n

								int			iPos	=	strLine.Find(':');
								CStringA	strName, strValue;

								if( iPos > 0 )
								{
									strName		=	strLine.Left( iPos );
									strValue	=	strLine.Right( strLine.GetLength() - iPos - 1);

									strName.Trim();
									strValue.Trim();

									if( strName.Compare(HTTP_HEADER_CONTENT_LENGTH) == 0 )
										dwPacketSize	=	atoi( strValue );

									if( strName.CompareNoCase(HTTP_HEADER_SOAP_ACTION) == 0 )
									{
										char	*buffOut;
										DWORD	dwRetLength = 0;
										buffOut	=	new char[ strlen(strValue) + 1];
										::AtlUnescapeUrl( strValue, buffOut, &dwRetLength, (DWORD)strlen(strValue));
										m_strSOAPAction	=	buffOut;
										delete[]	buffOut;
									}

								}
								strLine.Empty();
							}
						}// end while

						if( dwPacketSize == 0 )
						{
							bKeepReading	=	false;
							m_requestType	=	REQ_HTTP_ERROR;
							m_strFaultDetail	+=	"Content-Length seems to be missing &amp;";
						}
					}// end POST
				}// end packet size....

				if( bRet && dwPacketSize > 0 )
				{
					LPCSTR	szBuffer		=	buffer;
					LPCSTR	szEndHeaders	=	NULL;
					
					szEndHeaders	=	strstr( szBuffer, HTTP_END_OF_HEADERS);
					ATLASSERT( szEndHeaders > 0 );

					dwTotalSize	=	(DWORD)(szEndHeaders - szBuffer);
					dwTotalSize	+=	(DWORD)strlen( HTTP_END_OF_HEADERS);
					dwTotalSize	+=	dwPacketSize;

					// IF already read the header, the size and the buffer, then stop reading
					if( dwTotalSize	<= buffer.GetLength() )
						bKeepReading	=	false;
				}
			}// end while keep reading

			

			if( bRet && (m_requestType == REQ_HTTP_POST) )
			{
				// everything is read successfully, request is POST, set the locals
				
				LPCSTR		szBuffer = buffer;
				LPCSTR		szEndOfHeaders;

				szEndOfHeaders	=	strstr(szBuffer, HTTP_END_OF_HEADERS);
				ATLASSERT( szEndOfHeaders != NULL );
				
				ATLASSERT( buffer.GetLength() >= dwPacketSize + strlen(HTTP_END_OF_HEADERS) + (szEndOfHeaders - szBuffer));
				szBuffer	=	szEndOfHeaders + strlen(HTTP_END_OF_HEADERS);
				
				m_xmlBuffer.Append( szBuffer, dwPacketSize );
			}
			
			return bRet;
		}
	};


	class CResponse
	{
	public:
		CAtlIsapiBuffer<>	m_xmlBuffer;
		UINT				m_httpError;
		UINT				m_httpSubError;
		CStringA			m_strRetString;

	public:
		CResponse()
		{
			m_httpError		=	200;
			m_httpSubError	=	SUBERR_NONE;	
		}
		
		
		bool	Send( SOCKET s)
		{
			DWORD				dwSend;
			int					iRetVal;
			CAtlIsapiBuffer<>	buff;

/*
			HTTP/1.1 200 OK
			Server: Microsoft-IIS/5.0
			Date: Thu, 26 Apr 2001 01:15:11 GMT
			Content-Type: text/xml
			Content-Length: XXXX


*/
			ATLASSERT(m_xmlBuffer.GetLength() > 0 );

			CStringA				strLine;
			LPCSTR					szHeader = NULL;
			CStringA				strSystemTime;
			SYSTEMTIME				sysTime;

			CDefaultErrorProvider::GetErrorText(m_httpError, m_httpSubError, &szHeader, NULL);
			
			if( !szHeader )
				szHeader	=	"ISE Internal Server Error";

			strLine.Format( "HTTP/1.1 %d %s\r\n", m_httpError, szHeader);
			buff.Append( strLine );

			strLine.Format("Server: ATL Server - SoapTransport Sample HTTP Listener\r\n");
			buff.Append( strLine );



			::GetSystemTime( &sysTime );
			SystemTimeToHttpDate(sysTime, strSystemTime);
			strLine.Format("Date: %s\r\n", strSystemTime);
			buff.Append( strLine );

			strLine.Format("Content-Type: text/xml\r\n");
			buff.Append( strLine );

			strLine.Format("Content-Length: %d\r\n", m_xmlBuffer.GetLength());
			buff.Append( strLine );

			// end of headers
			buff.Append("\r\n");
			
			// Append buffer
			buff.Append( m_xmlBuffer, m_xmlBuffer.GetLength() );

			dwSend	=	buff.GetLength();

			iRetVal	=	::send( s, (char*)(LPCSTR)buff, dwSend, 0);

			if( iRetVal != SOCKET_ERROR )
			{
				return true;
			}

			return false;
		}


	};
}
#endif  UTIL_H_INCLUDED
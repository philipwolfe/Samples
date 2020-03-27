// File: HttpSoapListen.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#ifndef	ALTPSERVER_H_INCLUDED
#define ALTPSERVER_H_INCLUDED

#pragma once
#pragma comment(lib, "ws2_32")

#include "HttpSrvUtil.h"
using namespace TCPUTIL;

#include <iostream>
using namespace std;


/*
NOTE : THIS HTTP LISTENER IS NOT INTENDED TO BE USED IN A REAL APPLICATION
	   It is only sample code for implementing HTTP SOAP over TCP/IP without a web server.
	   It does not contain serious error checking and it IS NOT a safe
	   transmission protocol.
	   It ASSUMES that the client side of the communication is sending well 
	   formed requests
*/
template<class TSOAPDispatcher, class TWSDLGenDispatch>
class CSoapHttpListener
{
protected:
	SOCKET									m_listenSocket;

	// stops listening
	HANDLE									m_hStopEvent;

	CComCriticalSection						m_sync;

	struct stConnection
	{
		SOCKET				clientSocket;
		CSoapHttpListener	*pThis;
		bool				bClientDisconnected;
	};


	int										m_iRefCount;


	TWSDLGenDispatch						*m_pWSDLGenDispatch;
	unsigned	int							m_nListeningPort;
public:	

	

	void	AddRef()
	{
		m_sync.Lock();
		m_iRefCount	++;
		m_sync.Unlock();
	}
	
	void	Release()
	{
		m_sync.Lock();
		m_iRefCount	--;
		m_sync.Unlock();
	}
	
	CSoapHttpListener(TWSDLGenDispatch*	pWSDLGenDispatch)
	{
		m_listenSocket	=	NULL;
		m_hStopEvent		=	::CreateEvent( NULL, TRUE, FALSE, NULL);	
		m_iRefCount		=	0;

		m_pWSDLGenDispatch	=	pWSDLGenDispatch;

		m_sync.Init();
	}
	~CSoapHttpListener()
	{
	}

	bool StopListening()
	{
		::SetEvent( m_hStopEvent );
		::closesocket(m_listenSocket);
		::WSACleanup();

		int		iCounter	=		10;

		while( iCounter > 0 )
		{
			Sleep(500);
			iCounter --;
			if( m_iRefCount == 0 )
				break;
		}
		
		::CloseHandle( m_hStopEvent );
		
		return true;
	}


	bool	StartListening(unsigned short nPort)
	{
		 WSADATA		wsaData;
		 SOCKET			listen_socket;
		 sockaddr_in	localAddress;

		 m_nListeningPort	=	nPort;


		if(::WSAStartup(WINSOCK_VERSION,	&wsaData)!=0)
		{
			cout	<<	"WSAStartup failed"	<<endl;
			::WSACleanup();
			return false;
		};

		localAddress.sin_family			=	AF_INET;
		localAddress.sin_addr.s_addr	=	INADDR_ANY;
		localAddress.sin_port			=	htons(nPort);

		
		// Attempt to create a socket
		listen_socket = ::socket(AF_INET,SOCK_STREAM,0);
		
		

		if(	listen_socket==INVALID_SOCKET )
		{
			cout	<<	"socket() failed"	<<	endl;

			::WSACleanup();
			return false;
		}

		// bind to local address
		if(	0 != ::bind(listen_socket, (sockaddr *)&localAddress, sizeof(localAddress)) )
		{
			cout	<<	"bind() failed : WSAGetLastError : "	<<	::WSAGetLastError()<<	endl;
			::WSACleanup();
			return false;	
		}

		// Attempt ot listen
		if( 0 != ::listen(listen_socket, SOCKET_BACKLOG) )
		{
			cout	<<	"listen() failed"	<<	endl;
			::WSACleanup(); 
			return false;
		}
		
		m_listenSocket	=	listen_socket; 
		
		// start the client listener proc
		DWORD		dwThreadId;
		
		AddRef();
		::CreateThread(NULL, 0, AcceptProc, (LPVOID)this, 0, &dwThreadId);
		
		return true;
	}


protected:
	static DWORD __stdcall AcceptProc(LPVOID lpParam)
	{
		CSoapHttpListener		*pThis = (CSoapHttpListener*)lpParam;
		int					iLenFrom;
		bool				bContinue	=	true;

		cout	<<	"Start listening"	<<	endl;
		

		// reset the connect data
		iLenFrom	=	sizeof(sockaddr_in);

		while( bContinue )
		{
			// attempt to accept the connection
			sockaddr_in			saFrom;
			SOCKET				clientSocket;

			clientSocket=	::accept(pThis->m_listenSocket,(struct sockaddr*)&saFrom,	&iLenFrom);
			cout	<<	"accept()"	<<	endl;
			
			
			cout	<<	"Accepted, clientSocket = "	<<	 (unsigned int)clientSocket	<<	endl;

			if( clientSocket == INVALID_SOCKET)
			{
				cout	<<	"accept() failed : WSAGetLastError : "	<<	::WSAGetLastError()	<<	endl;
				break;
			}
			else
			{
				// create a thread to deal with this connection
				HANDLE				hThread;
				DWORD				dwThreadId;
				stConnection		*pConn	=	new stConnection;
				

				memset(pConn, 0, sizeof(stConnection) );
				pConn->clientSocket	=	clientSocket;
				pConn->pThis		=	pThis;


				hThread	=	::CreateThread(NULL, 0, ClientListenerProc, (LPVOID)pConn, 0, &dwThreadId);

				pThis->AddRef();

			}
		}


		cout	<<	"End listening"	<<	endl;
		pThis->Release();

		return	0;
	}



	/*
		Client listener -- 
		- reads the buffer from the request
		- executes the SOAP request
		- takes the response and forwards it to the client
	*/

	static DWORD __stdcall ClientListenerProc(LPVOID	lpParam)
	{
		stConnection	*pConn	=	(stConnection*)lpParam;
		CSoapHttpListener	*pThis	=	pConn->pThis;
		bool			bContinue	=	true;
		CRequest		req;
		CResponse		res;
		unsigned short	nCurrentPort	=	0;


		pConn->bClientDisconnected	=	false;
		
		// Load a request
		bContinue	=	req.Load( pConn->clientSocket);	

		if( !bContinue )
		{
			cout	<<	"ClientListenerProc : recv() failed"	<<	endl;
			::closesocket( pConn->clientSocket);
			pConn->bClientDisconnected	=	true;
		}

		if( bContinue )
		{
			// call base class SOAP Dispatch method
			if( req.m_requestType == REQ_HTTP_GET )
			{
				pThis->prepareGETResponse(req, res);
			}
			else if( req.m_requestType == REQ_HTTP_POST )
			{
				TSOAPDispatcher		dispatcher;
				
				bool	bRet	=	dispatcher.DispatchCall( req.m_strURL, req.m_strSOAPAction, req.m_xmlBuffer, res.m_xmlBuffer);
				if( !bRet )
				{
					if( res.m_xmlBuffer.GetLength() == 0 )
						pThis->prepareErrorResponse(req, res, "Invalid SOAP Request, most probable incorrect SOAPAction");
					res.m_httpError		=	500;
					res.m_httpSubError	=	SUBERR_NONE;
				}
			}
			else
				pThis->prepareErrorResponse(req, res);

			bContinue	=	res.Send(pConn->clientSocket);
			if( !bContinue )
			{
				cout	<<	"ClientListenerProc -- send() failed : WSAGetLastError : "	<< ::WSAGetLastError()	<<	endl;
				::closesocket(pConn->clientSocket);
				pConn->bClientDisconnected	=	true;
			}
		}

		::closesocket(pConn->clientSocket);
		pConn->bClientDisconnected	=	true;


		delete	pConn;
		pThis->Release();
		return	bContinue ? 0 : 1;
	}


	void prepareErrorResponse(CRequest& req, CResponse& res, LPCSTR	szDetailOverride = NULL)
	{
		// error response should be  400, SUBERR_NONE, "Bad Request", IDS_ATLSRV_BAD_REQUEST 
		// but should also be a soap fault for a SOAP Client
		res.m_httpError		=	400;
		res.m_httpSubError	=	SUBERR_NONE;

		CStringA	strSoapFault;

		strSoapFault	+=	"<SOAP:Envelope xmlns:SOAP=\"http://schemas.xmlsoap.org/soap/envelope/\">\r\n";
		strSoapFault	+=	"  <SOAP:Body>\r\n";
		strSoapFault	+=	"   <SOAP:Fault>\r\n";
		strSoapFault	+=	"     <faultcode>SOAP:Client</faultcode>\r\n";
		strSoapFault	+=	"     <faultcode>Invalid Request</faultcode>\r\n";
		strSoapFault	+=	"     <detail>";
		if( szDetailOverride )
			strSoapFault	+=	szDetailOverride;
		else
			strSoapFault	+=	req.m_strFaultDetail;
		strSoapFault	+=	"</detail>\r\n";
		strSoapFault	+=	"   </SOAP:Fault>\r\n";
		strSoapFault	+=	"  </SOAP:Body>\r\n";
		strSoapFault	+=	"</SOAP:Envelope>"; 

		res.m_xmlBuffer.Append(strSoapFault);



	}

	void prepareGETResponse(CRequest& req, CResponse& res)\
	{
		CStringA	strObject, strParams;
		LPCSTR		szURL	=	req.m_strURL;
		char		*pCurr	=	NULL;

		ATLASSERT( szURL );

		if( *szURL == '/' )
			szURL ++;
		
		// the only param separator that is accepted is ?
		pCurr	=	strchr( szURL, '?');
		if( !pCurr )
			strObject	=	szURL;
		else
		{
			// Params!
			strObject.SetString( szURL, (int)(pCurr - szURL));
			pCurr ++;
			strParams	=	pCurr;
		}


		if( strParams.CompareNoCase("wsdl") == 0 )
		{
			// Looking for a WSDL
			HTTP_CODE	hRetVal	=	m_pWSDLGenDispatch->renderWSDL(strObject, res.m_xmlBuffer);
			if( hRetVal != HTTP_SUCCESS )
			{
				res.m_xmlBuffer.Empty();
				prepareErrorResponse(req, res, strObject + " - Error generating the WSDL");
				res.m_httpError	=	(unsigned int)hRetVal;
			}
		}
		else if( strObject.CompareNoCase("disco") == 0 )
		{
			CStringA	strResponse;
			char		hostName[MAX_PATH];

			
			::gethostname( hostName, MAX_PATH);
			ATLASSERT( m_pWSDLGenDispatch != NULL );

			
			strResponse	+=	"<?xml version=\"1.0\" ?>\r\n";
			strResponse	+=	"  <discovery xmlns=\"http://schemas.xmlsoap.org/disco/\">\r\n";
			for( unsigned int uIndex = 0; uIndex < m_pWSDLGenDispatch->getSupportedServicesCount(); uIndex ++)
			{
				CStringA	strWsdlURL;
				CStringA	strServiceID;

				m_pWSDLGenDispatch->getSupportedServiceId( uIndex, strServiceID);

				strWsdlURL.Format("http://%s:%d/%s?wsdl", hostName, m_nListeningPort, strServiceID);
				strResponse	+=	"    <contractRef xmlns=\"http://schemas.xmlsoap.org/disco/scl/\" ref=\"";
				strResponse	+=	strWsdlURL;
				strResponse	+=	"\"/>\r\n";
			}
			strResponse	+=	"</discovery>\r\n";

			res.m_xmlBuffer.Append(strResponse);
		}
		else
		{
			res.m_httpError		=	404;
			res.m_httpSubError	=	SUBERR_NONE;

			CStringA	strSoapFault;

			strSoapFault	+=	"<SOAP:Envelope xmlns:SOAP=\"http://schemas.xmlsoap.org/soap/envelope/\">\r\n";
			strSoapFault	+=	"  <SOAP:Body>\r\n";
			strSoapFault	+=	"   <SOAP:Fault>\r\n";
			strSoapFault	+=	"     <faultcode>SOAP:Client</faultcode>\r\n";
			strSoapFault	+=	"     <faultcode>Invalid Request</faultcode>\r\n";
			strSoapFault	+=	"     <detail>Page not found</detail>\r\n";
			strSoapFault	+=	"   </SOAP:Fault>\r\n";
			strSoapFault	+=	"  </SOAP:Body>\r\n";
			strSoapFault	+=	"</SOAP:Envelope>"; 

			res.m_xmlBuffer.Append(strSoapFault);

		}

	}

};


#endif //ALTPSERVER_H_INCLUDED


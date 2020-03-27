// File: TCPSoapListen.h
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

#include "SrvUtil.h"
using namespace TCPUTIL;

#include <iostream>
using namespace std;

/*
NOTE : THIS TCP LISTENER IS NOT INTENDED TO BE USED IN A REAL APPLICATION
	   It is only sample code for implementing SOAP over TCP/IP.
	   It does not contain serious error checking and it IS NOT a safe
	   transmission protocol.
	   It ASSUMES that the client side of the communication is sending well 
	   formed requests
*/
template<class TSOAPDispatcher>
class CSoapTCPListener
{
protected:
	SOCKET									m_listenSocket;

	// stops listening
	HANDLE									m_hStopEvent;

	CComCriticalSection						m_sync;

	struct stConnection
	{
		SOCKET				clientSocket;
		CSoapTCPListener	*pThis;
		bool				bClientDisconnected;
	};


	int										m_iRefCount;


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
	
	CSoapTCPListener()
	{
		m_listenSocket	=	NULL;
		m_hStopEvent		=	::CreateEvent( NULL, TRUE, FALSE, NULL);	
		m_iRefCount		=	0;



		m_sync.Init();
	}
	~CSoapTCPListener()
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
		CSoapTCPListener		*pThis = (CSoapTCPListener*)lpParam;
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
		CSoapTCPListener	*pThis	=	pConn->pThis;
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
			TSOAPDispatcher		dispatcher;
			bool	bRet	=	dispatcher.DispatchCall( req.m_strURL, req.m_strSOAPAction, req.m_xmlBuffer, res.m_xmlBuffer);
			res.m_dwError	=	bRet ? TCPSOAP_ERROR_SUCCESS : TCPSOAP_ERROR_PROCESSING;

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
};


#endif //ALTPSERVER_H_INCLUDED


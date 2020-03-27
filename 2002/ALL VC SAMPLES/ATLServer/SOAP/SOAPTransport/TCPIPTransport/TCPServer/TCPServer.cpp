// Server.cpp : Defines the entry point for the console application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include <conio.h>
// the header for the Web Service
#include "SimpleSoapSrv.h"
using namespace SimpleSoapAppService;

// Stream Wrapper for an ISAPI Buffer
#include "StreamOnBuff.h"

// SOAP Dispatcher
#include "soapDispatch.h"


// TCP SOAP Listener
#include "TCPSoapListen.h"
const unsigned short g_nListeningPort	=	333;
static DWORD __stdcall waitForUserKeyPressed(LPVOID lpParam)
{
	CSoapTCPListener<CSoapDispatcher>		*pListener	=	NULL;

	pListener	=	reinterpret_cast<CSoapTCPListener<CSoapDispatcher>*>(lpParam);

	getch();
	pListener->StopListening();

	return 0;
}


int main(int argc, char* argv[])
{
	
	CSoapTCPListener<CSoapDispatcher>		listener;
	HANDLE									hUIThread;


	
	
	cout	<<	"Press any key to stop the listener"	<<	endl;
	hUIThread	=	::CreateThread( NULL, 0, waitForUserKeyPressed, (LPVOID)&listener, 0, NULL);
	listener.StartListening(g_nListeningPort);
	

	::WaitForSingleObject( hUIThread, INFINITE);


	return 0;
}



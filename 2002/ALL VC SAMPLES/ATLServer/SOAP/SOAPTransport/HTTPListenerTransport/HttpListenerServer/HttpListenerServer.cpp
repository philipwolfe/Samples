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

// HTTP Listener
#include "HttpSoapListen.h"

// WSDL Generator class
#include "HTTPListenerWSDLGen.h"



unsigned		int			g_nListeningPort	=	333;


class CWSDLGenDispatch
{
public:
	HTTP_CODE	renderWSDL(CStringA& strServiceId, CAtlIsapiBuffer<>&	buffer)
	{
		HTTP_CODE	hRet	=	HTTP_FAIL;

		if( strServiceId.Compare(CSimpleSoapAppService::ServiceName()) == 0 )
		{
			// if trying to render the WSDL for the CSimpleSoapAppService
			CHttpListenerSDLGenerator<CSimpleSoapAppService>	wsdlGen;
			wsdlGen.m_nListeningPort	=	g_nListeningPort;
			CReadWriteStreamOnIsapiBuffer		writeStream;

			writeStream.setBuffer( &buffer );
			hRet	=	wsdlGen.renderWSDL(&writeStream);
		}

		return hRet;
	}

	unsigned int getSupportedServicesCount()
	{
		return 1;//only 1 supported service, SimpleSoapAppService
	}

	bool	getSupportedServiceId(unsigned int iID, CStringA& strServiceID)
	{
		bool	bRet	=	true;
		switch( iID )
		{
		case 0:
			strServiceID	=	CSimpleSoapAppService::ServiceName();
			break;
		default:
			bRet	=	false;
		}

		return bRet;
	}
};

typedef CSoapHttpListener<CSoapDispatcher, CWSDLGenDispatch> HttpListener;

static DWORD __stdcall waitForUserKeyPressed(LPVOID lpParam)
{
	HttpListener	*pListener	=	NULL;

	pListener	=	reinterpret_cast<HttpListener*>(lpParam);

	getch();
	pListener->StopListening();

	return 0;
}

int main(int argc, char* argv[])
{
	
	CWSDLGenDispatch		wsdlGenDispatch;
	HttpListener			listener(&wsdlGenDispatch);
	HANDLE					hUIThread;
	
	cout	<<	"Press any key to stop the listener"	<<	endl;
	hUIThread	=	::CreateThread( NULL, 0, waitForUserKeyPressed, (LPVOID)&listener, 0, NULL);
	listener.StartListening( g_nListeningPort );
	

	::WaitForSingleObject( hUIThread, INFINITE);


	return 0;
}

// MQServer.cpp : Defines the entry point for the console application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"

#include	"soapDispatch.h"
#include	"MQServer.h"


int main(int argc, char* argv[])
{
	CSoapRequestListener<CSoapDispatcher>	listener; 
	CComBSTR								bstrQueue;

	if( argc != 2 )
	{
		printf("Usage : MQServer <machine_name>\n"
			"\t\t<machine_name> : the name of the machine where the message is/should be created\n");
		return 1;
	}

	bstrQueue.Append(argv[1]);
	bstrQueue.Append("\\SOAPRequests");

	
	if( listener.Initialize(bstrQueue) )
	{
		listener.ListenToSoapCalls();
	}

	return 0;
}

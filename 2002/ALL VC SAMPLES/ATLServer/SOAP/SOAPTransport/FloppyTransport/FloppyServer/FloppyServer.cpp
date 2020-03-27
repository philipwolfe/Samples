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

// the header for the Web Service
#include "SimpleSoapSrv.h"
using namespace SimpleSoapAppService;


// SOAP Dispatcher
#include "soapDispatch.h"

#include <iostream>
#include <fstream>
using namespace std;

bool	loadInputFile(CStringA& strURL, CStringA& strSOAPAction, CAtlIsapiBuffer<>& buffReq);
bool	writeOutputFile(CAtlIsapiBuffer<>& buffRes);


int main(int argc, char* argv[])
{
	
	CSoapDispatcher			soapDispatcher;
	CAtlIsapiBuffer<>		buffReq;
	CAtlIsapiBuffer<>		buffRes;
	CStringA				strSOAPAction;
	CStringA				strURL;



	if( loadInputFile( strURL, strSOAPAction, buffReq) )
	{
		cout	<<	endl	<<	"File loaded, start processing..."	<<	endl;
		if( soapDispatcher.DispatchCall( strURL, strSOAPAction, buffReq, buffRes) )
		{
			if( !writeOutputFile(buffRes) )
				cerr	<<	"Failure in writing the response"	<<	endl;
		}
		else
			cerr	<<	"Failure in processing the SOAP request"	<<	endl;

	}
	else
		cerr	<<	"Failure in loading the input file"	<<	endl;
	


	return 0;
}


bool	loadInputFile(CString& strURL, CString& strSOAPAction, CAtlIsapiBuffer<>& buffReq)
{
	char		inputFileName[MAX_PATH];
	bool		bRet = true;
	ifstream	inputStream;
	const	int	maxURLSize = 2048;
	char		szWorkBuffer[maxURLSize];
	
	cout	<<	"Please specify the input file:";
	cin		>>	inputFileName;
	
	inputStream.open( inputFileName);

	if( !inputStream.is_open() )
	{
		cerr	<<	"ERROR - Cannot open request file :"	<<	inputFileName	<<	endl;	
		return false;
	}

	inputStream >> szWorkBuffer;
	strURL	=	szWorkBuffer;


	inputStream >> szWorkBuffer;
	strSOAPAction	=	szWorkBuffer;

	while( !inputStream.eof() )
	{
		memset(szWorkBuffer, 0, maxURLSize);
		inputStream.read(szWorkBuffer, maxURLSize);
		buffReq.Append( szWorkBuffer );
	}

	inputStream.close();

	if( strURL.IsEmpty() )
	{
		cerr	<<	"ERROR - Empty URL(the first line in the input file)"	<<	endl;	
		bRet	=	false;
	}
	else if( strSOAPAction.IsEmpty() )
	{
		cerr	<<	"ERROR - Empty SOAP Action (the second line in the input file)"	<<	endl;	
		bRet	=	false;
	}
	else
	{
		bRet	=	buffReq.GetLength() > 0;
		if( !bRet )
			cerr	<<	"ERROR - Empty XML Request Payload"	<< endl;	
	}

	if( bRet )
	{
		// the stream formats the soap action
		strSOAPAction	+=	"\r\n";
	}
	return bRet;
}





bool	writeOutputFile(CAtlIsapiBuffer<>& buffRes)
{
	char		outputFileName[MAX_PATH];
	bool		bRet = true;
	ofstream	outputStream;
	const	int	maxURLSize = 2048;
	
	cout	<<	"Please specify the output file:";
	cin		>>	outputFileName;
	
	outputStream.open( outputFileName);

	if( !outputStream.is_open() )
	{
		cerr	<<	"ERROR - Cannot open response file :"	<<	outputFileName	<<	endl;	
		return false;
	}

	outputStream	<<	(LPCSTR)buffRes;

	outputStream.close();

	return true;
}

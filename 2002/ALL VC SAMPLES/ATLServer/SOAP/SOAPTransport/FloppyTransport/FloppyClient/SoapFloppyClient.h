// File: SoapFloppyClient.h
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


#include <iostream>
#include <fstream>
#include <conio.h>
using namespace std;


#include "StreamOnCString.h"

// LOG options
class CSoapFloppyClient
{
protected:
	CReadWriteStreamOnCString	m_requestStream;
	CReadWriteStreamOnCString	m_responseStream;
	CStringA					m_strURL;

	SOAPCLIENT_ERROR			m_errorState;

public:
	CSoapFloppyClient(LPCTSTR szURL) : m_strURL(CT2A(szURL)), m_errorState(SOAPCLIENT_SUCCESS)
	{
	}

	~CSoapFloppyClient() throw()
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
		

		if( !writeOutputFile( szAction ) )
		{
			cerr	<<	_T("Error writing request file")	<<	endl;
			return E_FAIL;
		}

		cout	<<	_T("The requests was succesfully created!")	<<	endl;
		cout	<<	_T("Please press any key when the response is available!")	<<	endl;

		getch();


		if( !loadInputFile() )
		{
			cerr	<<	_T("Error reading response file")	<<	endl;
			return E_FAIL;
		}

		return S_OK;
		
	}


protected:
	bool	loadInputFile()
	{
		char		inputFileName[MAX_PATH];
		bool		bRet = true;
		ifstream	inputStream;
		const	int	maxURLSize = 2048;
		char		szWorkBuffer[maxURLSize];
		
		cout	<<	"Please specify the file containing the response:";
		cin		>>	inputFileName;
		
		inputStream.open( inputFileName);

		if( !inputStream.is_open() )
		{
			cerr	<<	"ERROR - Cannot open response file :"	<<	inputFileName	<<	endl;	
			return false;
		}


		while( !inputStream.eof() )
		{
			inputStream.get(szWorkBuffer, maxURLSize, '\0');
			m_responseStream.WriteStream(szWorkBuffer, -1, NULL);
		}

		inputStream.close();
		return bRet;
	}





	bool	writeOutputFile(LPCSTR	szAction)
	{
		char		outputFileName[MAX_PATH];
		bool		bRet = true;
		ofstream	outputStream;
		const		int	maxURLSize = 2048;
		char		szWorkBuffer[maxURLSize];

		
		cout	<<	"Please specify the file to contain the request:";
		cin		>>	outputFileName;
		
		outputStream.open( outputFileName);

		if( !outputStream.is_open() )
		{
			cerr	<<	"ERROR - Cannot open request file :"	<<	outputFileName	<<	endl;	
			return false;
		}

		// inserting the service URL, to be used in dispatching the call to the appropriate service
		outputStream	<<	(LPCSTR)m_strURL	<<	endl;
		
		// inserting the SOAP Action, part of the SOAP request
		outputStream	<<	szAction	<<	endl;
		
		ULONG		ulActualRead	=	0;
		do
		{
			m_requestStream.Read( szWorkBuffer, maxURLSize - 1, &ulActualRead);
			outputStream	<<	(LPCSTR)m_requestStream.m_str;
		}while(ulActualRead == maxURLSize - 1);

		outputStream.close();

		return true;
	}

};




#endif// SOAP_DEBUG_CLIENT_H_INCLUDED






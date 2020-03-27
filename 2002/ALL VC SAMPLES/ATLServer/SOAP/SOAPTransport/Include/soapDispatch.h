// File: soapDispatch.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#ifndef 	SOAPDISPATCH_H_INCLUDED
#define		SOAPDISPATCH_H_INCLUDED

#include	"StreamOnBuff.h"

// include the actual SOAP server
#include	"simpleSoapSrv.h"
using namespace	SimpleSoapAppService;

class CSoapDispatcher
{
protected:
	ISAXXMLReader			*m_pXmlReader;


public:
	CSoapDispatcher():m_pXmlReader(NULL){}
	
	// gets an URL of form http:// ...?Param1=Value1&Handler=Name... and returns Name
	// returns false if the URL does not match  the specified format
	bool	GetServiceNameFromUrl(CStringA& strURL, CString& strServiceName)
	{
		bool	bRet = false;
		int		iPos;
		LPCSTR	pCurr	=	NULL;
		

		// Looking for URL params start
		iPos	=	strURL.Find(_T("?"));
		if( iPos < 0 )
			return bRet;

		pCurr	=	(LPCSTR)strURL	+iPos + 1;
		while( *pCurr && !bRet)
		{
			CStringA	strName, strValue;
			LPCSTR		pStart = pCurr;
			while( *pCurr && (*pCurr != '='))
				pCurr ++;
			strName.SetString( pStart, (int)(pCurr - pStart));
			if( *pCurr )
				pStart = pCurr + 1;
			else
				// setting start on 0
				pStart = pCurr;
			
			while( *pCurr && (*pCurr != '&'))
				pCurr++;

			strValue.SetString( pStart, (int)(pCurr - pStart));
			if( *pCurr)
				// if !=0 , then it is &
				pCurr ++;
			if( strName.CompareNoCase( "Handler") == 0 )
			{
				strServiceName	=	strValue;
				bRet	=	true;
			}
		}
		return bRet;
	}
	
	
	bool	SetXMLReader(ISAXXMLReader	*pReader)
	{
	}
	
	
	bool	DispatchCall(CStringA& strURL, CStringA&	strSOAPAction, CAtlIsapiBuffer<>&	buffReq, CAtlIsapiBuffer<>& buffRes)
	{
		bool	bRet	=	true;
		CoInitialize(NULL);

		
		CReadWriteStreamOnIsapiBuffer		readStr;
		CReadWriteStreamOnIsapiBuffer		writeStr;
		stSoapTransportDescription			transInfo;
		CString strServiceName;

		readStr.setBuffer( &buffReq );
		writeStr.setBuffer( &buffRes );
	

		transInfo.pWriteStream		=	&writeStr;
		transInfo.pReadStream		=	&readStr;
		transInfo.strSOAPAction		=	(LPCSTR)strSOAPAction;
		transInfo.pServiceProvider	=	NULL;

		bRet	=	GetServiceNameFromUrl(strURL, strServiceName);
		

		// if this is a request for CSimpleSoapAppService
		if( strServiceName.CompareNoCase( CSimpleSoapAppService::ServiceName() ) == 0 )
		{
			
			CComObjectNoLock<CSimpleSoapAppService>				srv;
			srv.AddRef();

			bRet	=	true;
			HRESULT	hRet	= S_OK;
			try
			{
				hRet	=	srv.InvokeSoapMethod( &transInfo );
			}
			catch(...)
			{
				bRet	=	false;
			}

			if( !SUCCEEDED(hRet) )
				bRet	=	false;
		}
		// add you own services here

		CoUninitialize();
	
		return bRet;
	}
};



#endif		//SOAPDISPATCH_H_INCLUDED
// File: SOAPTransportSrv.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#ifndef SOAPTRANSPORT_H_INCLUDED
#define SOAPTRANSPORT_H_INCLUDED

struct  stSoapTransportDescription
{
	IWriteStream		*pWriteStream;
	IStream				*pReadStream;
	CStringA			strSOAPAction;	
	IServiceProvider	*pServiceProvider;
};



template <class TSoapServer>
class CSoapTransportHandler:public CSoapHandler<TSoapServer>
{
protected:
	IWriteStream	*m_pWriteStream;
public:


	HRESULT SoapFault(
		SOAP_ERROR_CODE errCode, 
		const wchar_t *wszDetail,
		int cchDetail)
	{
		ATLASSERT( m_pWriteStream != NULL );

		SetHttpError(AtlsHttpError(500, SUBERR_NO_PROCESS));

		CSoapFault fault;
		if (wszDetail != NULL)
		{
			if (cchDetail < 0)
			{
				cchDetail = (int) wcslen(wszDetail);
			}

			_ATLTRY
			{
				fault.m_strDetail.SetString(wszDetail, cchDetail);
			}
			_ATLCATCHALL()
			{

#ifdef ATLSOAP_TRACE_ERRORS
				ATLTRACE( _T("CSoapHandler::SoapFault -- out of memory.\n" ) );
#endif // ATLSOAP_TRACE_ERRORS

				return E_OUTOFMEMORY;
			}
		}

		fault.m_soapErrCode = errCode;
		fault.GenerateFault(m_pWriteStream);
		return S_OK;
	}


	HTTP_CODE InvokeSoapMethod(stSoapTransportDescription	*pTransInfo) throw()
	{
		SetHttpError(HTTP_SUCCESS);
		
		m_pWriteStream	=	pTransInfo->pWriteStream;

		HRESULT hr = InitializeSOAP(pTransInfo->pServiceProvider);
		if (FAILED(hr))
		{
			return SoapFault(SOAP_E_SERVER, NULL, 0);
		}

		// set the header map

		char szBuf[ATL_URL_MAX_URL_LENGTH+1];

		{
			// drop the last "
			strncpy( szBuf, pTransInfo->strSOAPAction, ATL_URL_MAX_URL_LENGTH);
			szBuf[ATL_URL_MAX_URL_LENGTH]	=	'\0';
			szBuf[strlen(szBuf)]	=	'\0';
			char *szMethod = strrchr(szBuf, '#');
			if (szMethod != NULL)
			{
				_ATLTRY
				{
					// ignore return code here (REVIEW above)
					SetSoapMapFromName(CA2W( szMethod+1 ), -1, GetNamespaceUri(), -1, true);
				}
				_ATLCATCHALL()
				{
					UninitializeSOAP();
					return HTTP_ERROR(500, ISE_SUBERR_OUTOFMEM);
				}
			}
		}
	

		hr = BeginParse(pTransInfo->pReadStream);
		if (FAILED(hr))
		{
			UninitializeSOAP();
			return SoapFault(SOAP_E_CLIENT, NULL, 0);
		}

		hr = CallFunctionInternal();
		if (FAILED(hr))
		{
			Cleanup();
			GenerateAppError(pTransInfo->pWriteStream, hr);
			UninitializeSOAP();
			return HTTP_ERROR(500, SUBERR_NO_PROCESS);
		}

		hr = GenerateResponse(pTransInfo->pWriteStream);
		Cleanup();
		if (FAILED(hr))
		{
			return SoapFault(SOAP_E_SERVER, NULL, 0);
		}

		UninitializeSOAP();
		return HTTP_SUCCESS;
	}
};

#endif	SOAPTRANSPORT_H_INCLUDED
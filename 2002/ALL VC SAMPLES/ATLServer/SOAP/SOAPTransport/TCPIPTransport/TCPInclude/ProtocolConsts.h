// File: ProtocolConsts.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#define	SOCKET_BACKLOG					5
#define	SOCKET_BUFFER_SIZE				2048
#define	SOCKET_SOAP_REQUEST_HEADER		"SOAPREQ"
#define	SOCKET_SOAP_REQUEST_HEADER_LEN	7
#define	SOCKET_SOAP_RESPONSE_HEADER		"SOAPRES"
#define	SOCKET_SOAP_RESPONSE_HEADER_LEN	7

// OK, no error in processing
#define	TCPSOAP_ERROR_SUCCESS			0

// some error occured in transport
#define TCPSOAP_ERROR_TRANSPORT			1

// some error occured in processing - exception caucht or other non-SOAP thing
#define TCPSOAP_ERROR_PROCESSING		2


// incomplete buffer
#define TCPSOAP_ERROR_INCOMPLETE		3

/*
TCPIP format of the request:
===========================
	<SOCKET_SOAP_REQUEST_HEADER>
	NNN..N (sizeof(DWORD) bytes with the size of the following packet)
	<SOAPAction> followed by
	<\0> followed by 
	<XMLRequestPayload>

TCPIP format of the response:
===========================
	<SOCKET_SOAP_RESPONSE_HEADER>
	NNN..N (sizeof(DWORD) error code. If different from TCPSOAP_ERROR_SUCCESS, the rest is ignored)
	NNN..N (sizeof(DWORD) bytes with the size of the following packet)
	<XMLResponsePayload>

*/
	

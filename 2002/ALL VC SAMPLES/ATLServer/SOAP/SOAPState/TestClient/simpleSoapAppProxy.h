//
// sproxy.exe generated file
// do not modify this file
//
// Created: 04/25/2001@03:28:11
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include <atlsoap.h>

namespace SStateService
{

enum eState { eOBJECT_NOT_FOUND = 0, eEXISTING_OBJECT = 1, eNEW_OBJECT = 2, };

template <typename TClient = CSoapSocketClientT<> >
class CSStateServiceT : 
	public TClient, 
	public CSoapRootHandler
{
public:

	//
	// SOAP headers
	//
	
	BSTR m_bstrStorageKey;

protected:

	const _soapmap ** GetFunctionMap();
	const _soapmap ** GetHeaderMap();
	void * GetHeaderValue();
	const wchar_t * GetNamespaceUri();
	const char * GetServiceName();
	const char * GetNamespaceUriA();
	HRESULT CallFunction(
		void *pvParam, 
		const wchar_t *wszLocalName, int cchLocalName,
		size_t nItem);
	HRESULT GetClientReader(ISAXXMLReader **ppReader);

public:

	HRESULT __stdcall QueryInterface(REFIID riid, void **ppv)
	{
		if (ppv == NULL)
		{
			return E_POINTER;
		}

		*ppv = NULL;

		if (InlineIsEqualGUID(riid, IID_IUnknown) ||
			InlineIsEqualGUID(riid, IID_ISAXContentHandler))
		{
			*ppv = static_cast<ISAXContentHandler *>(this);
			return S_OK;
		}

		return E_NOINTERFACE;
	}

	ULONG __stdcall AddRef()
	{
		return 1;
	}

	ULONG __stdcall Release()
	{
		return 1;
	}

	CSStateServiceT(ISAXXMLReader *pReader = NULL)
		:TClient(_T("http://localhost/SoapState/SState.dll?Handler=Default"))
	{
		SetClient(true);
		SetReader(pReader);
	}
	
	~CSStateServiceT()
	{
		Uninitialize();
	}
	
	void Uninitialize()
	{
		UninitializeSOAP();
	}	

	HRESULT destroyPersistSoapServer(
		BSTR bstrUser, 
		BSTR bstrPwd
	);

	HRESULT initPersistSoapServer(
		BSTR bstrUser, 
		BSTR bstrPwd, 
		eState* __retval
	);

	HRESULT setPersistSoapServerTimeout(
		unsigned int dwTimeoutSecs
	);

	HRESULT HelloWorld(
		BSTR bstrInput, 
		BSTR* __retval
	);
};

typedef CSStateServiceT<> CSStateService;

__if_not_exists(__eState_entries)
{
extern __declspec(selectany) const _soapmapentry __eState_entries[] =
{
	{ 0xEF0EBFC7, "eOBJECT_NOT_FOUND", L"eOBJECT_NOT_FOUND", sizeof("eOBJECT_NOT_FOUND")-1, 0, SOAPFLAG_FIELD, 0, NULL, NULL, -1 },
	{ 0xEDE0CFE6, "eEXISTING_OBJECT", L"eEXISTING_OBJECT", sizeof("eEXISTING_OBJECT")-1, 1, SOAPFLAG_FIELD, 0, NULL, NULL, -1 },
	{ 0xD6ADB185, "eNEW_OBJECT", L"eNEW_OBJECT", sizeof("eNEW_OBJECT")-1, 2, SOAPFLAG_FIELD, 0, NULL, NULL, -1 },
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __eState_map =
{
	0xF1B84146,
	"eState",
	L"eState",
	sizeof("eState")-1,
	sizeof("eState")-1,
	SOAPMAP_ENUM,
	__eState_entries,
	sizeof(eState),
	1,
	-1,
	SOAPFLAG_NONE,
	0x9AA02F94,
	NULL,
	NULL,
	0};
}

struct __CSStateService_destroyPersistSoapServer_struct
{
	BSTR bstrUser;
	BSTR bstrPwd;
};

extern __declspec(selectany) const _soapmapentry __CSStateService_destroyPersistSoapServer_entries[] =
{

	{
		0x1C72AE1A, 
		"bstrUser", 
		L"bstrUser", 
		sizeof("bstrUser")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CSStateService_destroyPersistSoapServer_struct, bstrUser),
		NULL,
		NULL,
		-1,
	},
	{
		0x8C7F83E6, 
		"bstrPwd", 
		L"bstrPwd", 
		sizeof("bstrPwd")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CSStateService_destroyPersistSoapServer_struct, bstrPwd),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSStateService_destroyPersistSoapServer_map =
{
	0xFD12319E,
	"destroyPersistSoapServer",
	L"destroyPersistSoapServer",
	sizeof("destroyPersistSoapServer")-1,
	sizeof("destroyPersistSoapServer")-1,
	SOAPMAP_FUNC,
	__CSStateService_destroyPersistSoapServer_entries,
	sizeof(__CSStateService_destroyPersistSoapServer_struct),
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x9AA02F94,
	"urn:SStateService",
	L"urn:SStateService",
	sizeof("urn:SStateService")-1
};

extern __declspec(selectany) const _soapmapentry __CSStateService_destroyPersistSoapServer_atlsoapheader_entries[] =
{
	{
		0x6B88C445,
		"m_bstrStorageKey",
		L"m_bstrStorageKey",
		sizeof("m_bstrStorageKey")-1,
		SOAPTYPE_STRING,
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_NULLABLE,
		offsetof(CSStateService, m_bstrStorageKey),
		NULL,
		NULL,
		-1,
	},
	{
		0x6B88C445,
		"m_bstrStorageKey",
		L"m_bstrStorageKey",
		sizeof("m_bstrStorageKey")-1,
		SOAPTYPE_STRING,
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_NULLABLE,
		offsetof(CSStateService, m_bstrStorageKey),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSStateService_destroyPersistSoapServer_atlsoapheader_map = 
{
	0xFD12319E,
	"destroyPersistSoapServer",
	L"destroyPersistSoapServer",
	sizeof("destroyPersistSoapServer")-1,
	sizeof("destroyPersistSoapServer")-1,
	SOAPMAP_HEADER,
	__CSStateService_destroyPersistSoapServer_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE,
	0x9AA02F94,
	"urn:SStateService",
	L"urn:SStateService",
	sizeof("urn:SStateService")-1
};

struct __CSStateService_initPersistSoapServer_struct
{
	BSTR bstrUser;
	BSTR bstrPwd;
	eState __retval;
};

extern __declspec(selectany) const _soapmapentry __CSStateService_initPersistSoapServer_entries[] =
{

	{
		0x1C72AE1A, 
		"bstrUser", 
		L"bstrUser", 
		sizeof("bstrUser")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CSStateService_initPersistSoapServer_struct, bstrUser),
		NULL,
		NULL,
		-1,
	},
	{
		0x8C7F83E6, 
		"bstrPwd", 
		L"bstrPwd", 
		sizeof("bstrPwd")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CSStateService_initPersistSoapServer_struct, bstrPwd),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSStateService_initPersistSoapServer_struct, __retval),
		NULL,
		&__eState_map,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSStateService_initPersistSoapServer_map =
{
	0x319A0C08,
	"initPersistSoapServer",
	L"initPersistSoapServer",
	sizeof("initPersistSoapServer")-1,
	sizeof("initPersistSoapServer")-1,
	SOAPMAP_FUNC,
	__CSStateService_initPersistSoapServer_entries,
	sizeof(__CSStateService_initPersistSoapServer_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x9AA02F94,
	"urn:SStateService",
	L"urn:SStateService",
	sizeof("urn:SStateService")-1
};

extern __declspec(selectany) const _soapmapentry __CSStateService_initPersistSoapServer_atlsoapheader_entries[] =
{
	{
		0x6B88C445,
		"m_bstrStorageKey",
		L"m_bstrStorageKey",
		sizeof("m_bstrStorageKey")-1,
		SOAPTYPE_STRING,
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_NULLABLE,
		offsetof(CSStateService, m_bstrStorageKey),
		NULL,
		NULL,
		-1,
	},
	{
		0x6B88C445,
		"m_bstrStorageKey",
		L"m_bstrStorageKey",
		sizeof("m_bstrStorageKey")-1,
		SOAPTYPE_STRING,
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_NULLABLE,
		offsetof(CSStateService, m_bstrStorageKey),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSStateService_initPersistSoapServer_atlsoapheader_map = 
{
	0x319A0C08,
	"initPersistSoapServer",
	L"initPersistSoapServer",
	sizeof("initPersistSoapServer")-1,
	sizeof("initPersistSoapServer")-1,
	SOAPMAP_HEADER,
	__CSStateService_initPersistSoapServer_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE,
	0x9AA02F94,
	"urn:SStateService",
	L"urn:SStateService",
	sizeof("urn:SStateService")-1
};

struct __CSStateService_setPersistSoapServerTimeout_struct
{
	unsigned int dwTimeoutSecs;
};

extern __declspec(selectany) const _soapmapentry __CSStateService_setPersistSoapServerTimeout_entries[] =
{

	{
		0x75C47A90, 
		"dwTimeoutSecs", 
		L"dwTimeoutSecs", 
		sizeof("dwTimeoutSecs")-1, 
		SOAPTYPE_UNSIGNEDINT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSStateService_setPersistSoapServerTimeout_struct, dwTimeoutSecs),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSStateService_setPersistSoapServerTimeout_map =
{
	0xEA316E47,
	"setPersistSoapServerTimeout",
	L"setPersistSoapServerTimeout",
	sizeof("setPersistSoapServerTimeout")-1,
	sizeof("setPersistSoapServerTimeout")-1,
	SOAPMAP_FUNC,
	__CSStateService_setPersistSoapServerTimeout_entries,
	sizeof(__CSStateService_setPersistSoapServerTimeout_struct),
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x9AA02F94,
	"urn:SStateService",
	L"urn:SStateService",
	sizeof("urn:SStateService")-1
};

extern __declspec(selectany) const _soapmapentry __CSStateService_setPersistSoapServerTimeout_atlsoapheader_entries[] =
{
	{
		0x6B88C445,
		"m_bstrStorageKey",
		L"m_bstrStorageKey",
		sizeof("m_bstrStorageKey")-1,
		SOAPTYPE_STRING,
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_NULLABLE,
		offsetof(CSStateService, m_bstrStorageKey),
		NULL,
		NULL,
		-1,
	},
	{
		0x6B88C445,
		"m_bstrStorageKey",
		L"m_bstrStorageKey",
		sizeof("m_bstrStorageKey")-1,
		SOAPTYPE_STRING,
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_NULLABLE,
		offsetof(CSStateService, m_bstrStorageKey),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSStateService_setPersistSoapServerTimeout_atlsoapheader_map = 
{
	0xEA316E47,
	"setPersistSoapServerTimeout",
	L"setPersistSoapServerTimeout",
	sizeof("setPersistSoapServerTimeout")-1,
	sizeof("setPersistSoapServerTimeout")-1,
	SOAPMAP_HEADER,
	__CSStateService_setPersistSoapServerTimeout_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE,
	0x9AA02F94,
	"urn:SStateService",
	L"urn:SStateService",
	sizeof("urn:SStateService")-1
};

struct __CSStateService_HelloWorld_struct
{
	BSTR bstrInput;
	BSTR __retval;
};

extern __declspec(selectany) const _soapmapentry __CSStateService_HelloWorld_entries[] =
{

	{
		0xA9ECBD0B, 
		"bstrInput", 
		L"bstrInput", 
		sizeof("bstrInput")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CSStateService_HelloWorld_struct, bstrInput),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CSStateService_HelloWorld_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSStateService_HelloWorld_map =
{
	0x46BA99FC,
	"HelloWorld",
	L"HelloWorld",
	sizeof("HelloWorld")-1,
	sizeof("HelloWorld")-1,
	SOAPMAP_FUNC,
	__CSStateService_HelloWorld_entries,
	sizeof(__CSStateService_HelloWorld_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x9AA02F94,
	"urn:SStateService",
	L"urn:SStateService",
	sizeof("urn:SStateService")-1
};

extern __declspec(selectany) const _soapmapentry __CSStateService_HelloWorld_atlsoapheader_entries[] =
{
	{
		0x6B88C445,
		"m_bstrStorageKey",
		L"m_bstrStorageKey",
		sizeof("m_bstrStorageKey")-1,
		SOAPTYPE_STRING,
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_NULLABLE,
		offsetof(CSStateService, m_bstrStorageKey),
		NULL,
		NULL,
		-1,
	},
	{
		0x6B88C445,
		"m_bstrStorageKey",
		L"m_bstrStorageKey",
		sizeof("m_bstrStorageKey")-1,
		SOAPTYPE_STRING,
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_NULLABLE,
		offsetof(CSStateService, m_bstrStorageKey),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSStateService_HelloWorld_atlsoapheader_map = 
{
	0x46BA99FC,
	"HelloWorld",
	L"HelloWorld",
	sizeof("HelloWorld")-1,
	sizeof("HelloWorld")-1,
	SOAPMAP_HEADER,
	__CSStateService_HelloWorld_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE,
	0x9AA02F94,
	"urn:SStateService",
	L"urn:SStateService",
	sizeof("urn:SStateService")-1
};
extern __declspec(selectany) const _soapmap * __CSStateService_funcs[] =
{
	&__CSStateService_destroyPersistSoapServer_map,
	&__CSStateService_initPersistSoapServer_map,
	&__CSStateService_setPersistSoapServerTimeout_map,
	&__CSStateService_HelloWorld_map,
	NULL
};

extern __declspec(selectany) const _soapmap * __CSStateService_headers[] =
{
	&__CSStateService_destroyPersistSoapServer_atlsoapheader_map,
	&__CSStateService_initPersistSoapServer_atlsoapheader_map,
	&__CSStateService_setPersistSoapServerTimeout_atlsoapheader_map,
	&__CSStateService_HelloWorld_atlsoapheader_map,
	NULL
};

template <typename TClient>
inline HRESULT CSStateServiceT<TClient>::destroyPersistSoapServer(
		BSTR bstrUser, 
		BSTR bstrPwd
	)
{
	HRESULT __atlsoap_hr = InitializeSOAP(NULL);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_INITIALIZE_ERROR);
		return __atlsoap_hr;
	}
	
	CleanupClient();

	CComPtr<IStream> __atlsoap_spReadStream;
	__CSStateService_destroyPersistSoapServer_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.bstrUser = bstrUser;
	__params.bstrPwd = bstrPwd;

	__atlsoap_hr = SetClientStruct(&__params, 0);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_OUTOFMEMORY);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = GenerateResponse(GetWriteStream());
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_GENERATE_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#destroyPersistSoapServer\"\r\n"));
	if (FAILED(__atlsoap_hr))
	{
		goto __skip_cleanup;
	}
	__atlsoap_hr = GetReadStream(&__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_READ_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CSStateServiceT<TClient>::initPersistSoapServer(
		BSTR bstrUser, 
		BSTR bstrPwd, 
		eState* __retval
	)
{
	HRESULT __atlsoap_hr = InitializeSOAP(NULL);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_INITIALIZE_ERROR);
		return __atlsoap_hr;
	}
	
	CleanupClient();

	CComPtr<IStream> __atlsoap_spReadStream;
	__CSStateService_initPersistSoapServer_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.bstrUser = bstrUser;
	__params.bstrPwd = bstrPwd;

	__atlsoap_hr = SetClientStruct(&__params, 1);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_OUTOFMEMORY);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = GenerateResponse(GetWriteStream());
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_GENERATE_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#initPersistSoapServer\"\r\n"));
	if (FAILED(__atlsoap_hr))
	{
		goto __skip_cleanup;
	}
	__atlsoap_hr = GetReadStream(&__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_READ_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	*__retval = __params.__retval;
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CSStateServiceT<TClient>::setPersistSoapServerTimeout(
		unsigned int dwTimeoutSecs
	)
{
	HRESULT __atlsoap_hr = InitializeSOAP(NULL);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_INITIALIZE_ERROR);
		return __atlsoap_hr;
	}
	
	CleanupClient();

	CComPtr<IStream> __atlsoap_spReadStream;
	__CSStateService_setPersistSoapServerTimeout_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.dwTimeoutSecs = dwTimeoutSecs;

	__atlsoap_hr = SetClientStruct(&__params, 2);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_OUTOFMEMORY);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = GenerateResponse(GetWriteStream());
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_GENERATE_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#setPersistSoapServerTimeout\"\r\n"));
	if (FAILED(__atlsoap_hr))
	{
		goto __skip_cleanup;
	}
	__atlsoap_hr = GetReadStream(&__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_READ_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CSStateServiceT<TClient>::HelloWorld(
		BSTR bstrInput, 
		BSTR* __retval
	)
{
	HRESULT __atlsoap_hr = InitializeSOAP(NULL);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_INITIALIZE_ERROR);
		return __atlsoap_hr;
	}
	
	CleanupClient();

	CComPtr<IStream> __atlsoap_spReadStream;
	__CSStateService_HelloWorld_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.bstrInput = bstrInput;

	__atlsoap_hr = SetClientStruct(&__params, 3);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_OUTOFMEMORY);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = GenerateResponse(GetWriteStream());
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_GENERATE_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#HelloWorld\"\r\n"));
	if (FAILED(__atlsoap_hr))
	{
		goto __skip_cleanup;
	}
	__atlsoap_hr = GetReadStream(&__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_READ_ERROR);
		goto __skip_cleanup;
	}
	
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	*__retval = __params.__retval;
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
ATL_NOINLINE inline const _soapmap ** CSStateServiceT<TClient>::GetFunctionMap()
{
	return __CSStateService_funcs;
}

template <typename TClient>
ATL_NOINLINE inline const _soapmap ** CSStateServiceT<TClient>::GetHeaderMap()
{
	return __CSStateService_headers;
}

template <typename TClient>
ATL_NOINLINE inline void * CSStateServiceT<TClient>::GetHeaderValue()
{
	return this;
}

template <typename TClient>
ATL_NOINLINE inline const wchar_t * CSStateServiceT<TClient>::GetNamespaceUri()
{
	return L"urn:SStateService";
}

template <typename TClient>
ATL_NOINLINE inline const char * CSStateServiceT<TClient>::GetServiceName()
{
	return NULL;
}

template <typename TClient>
ATL_NOINLINE inline const char * CSStateServiceT<TClient>::GetNamespaceUriA()
{
	return "urn:SStateService";
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CSStateServiceT<TClient>::CallFunction(
	void *, 
	const wchar_t *, int,
	size_t)
{
	return E_NOTIMPL;
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CSStateServiceT<TClient>::GetClientReader(ISAXXMLReader **ppReader)
{
	if (ppReader == NULL)
	{
		return E_INVALIDARG;
	}
	
	CComPtr<ISAXXMLReader> spReader = GetReader();
	if (spReader.p != NULL)
	{
		*ppReader = spReader.Detach();
		return S_OK;
	}
	return TClient::GetClientReader(ppReader);
}

} // namespace SStateService

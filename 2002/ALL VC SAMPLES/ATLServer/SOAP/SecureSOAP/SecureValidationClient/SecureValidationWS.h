//
// sproxy.exe generated file
// do not modify this file
//
// Created: 04/25/2001@04:10:19
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

namespace SecureValidationService
{

template <typename TClient = CSoapSocketClientT<> >
class CSecureValidationServiceT : 
	public TClient, 
	public CSoapRootHandler
{
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

	CSecureValidationServiceT(ISAXXMLReader *pReader = NULL)
		:TClient(_T("https://someServer/someVPath/SecureValidation.dll?Handler=SecureValidationService"))
	{
		SetClient(true);
		SetReader(pReader);
	}
	
	~CSecureValidationServiceT()
	{
		Uninitialize();
	}
	
	void Uninitialize()
	{
		UninitializeSOAP();
	}	

	HRESULT validateUser(
		BSTR bstrUserName, 
		BSTR bstrPwd, 
		bool* pbRetVal, 
		BSTR* pbstrErrorInfo
	);
};

typedef CSecureValidationServiceT<> CSecureValidationService;

struct __CSecureValidationService_validateUser_struct
{
	BSTR bstrUserName;
	BSTR bstrPwd;
	bool pbRetVal;
	BSTR pbstrErrorInfo;
};

extern __declspec(selectany) const _soapmapentry __CSecureValidationService_validateUser_entries[] =
{

	{
		0x541C9BBB, 
		"bstrUserName", 
		L"bstrUserName", 
		sizeof("bstrUserName")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CSecureValidationService_validateUser_struct, bstrUserName),
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
		offsetof(__CSecureValidationService_validateUser_struct, bstrPwd),
		NULL,
		NULL,
		-1,
	},
	{
		0x9B442980, 
		"pbRetVal", 
		L"pbRetVal", 
		sizeof("pbRetVal")-1, 
		SOAPTYPE_BOOLEAN, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSecureValidationService_validateUser_struct, pbRetVal),
		NULL,
		NULL,
		-1,
	},
	{
		0x73F44E61, 
		"pbstrErrorInfo", 
		L"pbstrErrorInfo", 
		sizeof("pbstrErrorInfo")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CSecureValidationService_validateUser_struct, pbstrErrorInfo),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSecureValidationService_validateUser_map =
{
	0x1E401F69,
	"validateUser",
	L"validateUser",
	sizeof("validateUser")-1,
	sizeof("validateUser")-1,
	SOAPMAP_FUNC,
	__CSecureValidationService_validateUser_entries,
	sizeof(__CSecureValidationService_validateUser_struct),
	2,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0xEC318E72,
	"urn:SecureValidationService",
	L"urn:SecureValidationService",
	sizeof("urn:SecureValidationService")-1
};

extern __declspec(selectany) const _soapmapentry __CSecureValidationService_validateUser_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSecureValidationService_validateUser_atlsoapheader_map = 
{
	0x1E401F69,
	"validateUser",
	L"validateUser",
	sizeof("validateUser")-1,
	sizeof("validateUser")-1,
	SOAPMAP_HEADER,
	__CSecureValidationService_validateUser_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE,
	0xEC318E72,
	"urn:SecureValidationService",
	L"urn:SecureValidationService",
	sizeof("urn:SecureValidationService")-1
};
extern __declspec(selectany) const _soapmap * __CSecureValidationService_funcs[] =
{
	&__CSecureValidationService_validateUser_map,
	NULL
};

extern __declspec(selectany) const _soapmap * __CSecureValidationService_headers[] =
{
	&__CSecureValidationService_validateUser_atlsoapheader_map,
	NULL
};

template <typename TClient>
inline HRESULT CSecureValidationServiceT<TClient>::validateUser(
		BSTR bstrUserName, 
		BSTR bstrPwd, 
		bool* pbRetVal, 
		BSTR* pbstrErrorInfo
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
	__CSecureValidationService_validateUser_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.bstrUserName = bstrUserName;
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#validateUser\"\r\n"));
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

	*pbRetVal = __params.pbRetVal;
	*pbstrErrorInfo = __params.pbstrErrorInfo;
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
ATL_NOINLINE inline const _soapmap ** CSecureValidationServiceT<TClient>::GetFunctionMap()
{
	return __CSecureValidationService_funcs;
}

template <typename TClient>
ATL_NOINLINE inline const _soapmap ** CSecureValidationServiceT<TClient>::GetHeaderMap()
{
	return __CSecureValidationService_headers;
}

template <typename TClient>
ATL_NOINLINE inline void * CSecureValidationServiceT<TClient>::GetHeaderValue()
{
	return this;
}

template <typename TClient>
ATL_NOINLINE inline const wchar_t * CSecureValidationServiceT<TClient>::GetNamespaceUri()
{
	return L"urn:SecureValidationService";
}

template <typename TClient>
ATL_NOINLINE inline const char * CSecureValidationServiceT<TClient>::GetServiceName()
{
	return NULL;
}

template <typename TClient>
ATL_NOINLINE inline const char * CSecureValidationServiceT<TClient>::GetNamespaceUriA()
{
	return "urn:SecureValidationService";
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CSecureValidationServiceT<TClient>::CallFunction(
	void *, 
	const wchar_t *, int,
	size_t)
{
	return E_NOTIMPL;
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CSecureValidationServiceT<TClient>::GetClientReader(ISAXXMLReader **ppReader)
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

} // namespace SecureValidationService

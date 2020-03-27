//
// sproxy.exe generated file
// do not modify this file
//
// Created: 04/25/2001@11:58:24
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

namespace PoolAsyncSoapService
{

template <typename TClient = CSoapSocketClientT<> >
class CPoolAsyncSoapServiceT : 
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

	CPoolAsyncSoapServiceT(ISAXXMLReader *pReader = NULL)
		:TClient(_T("http://localhost/PooledAsync/PooledAsyncSoapSrv.dll?Handler=Default"))
	{
		SetClient(true);
		SetReader(pReader);
	}
	
	~CPoolAsyncSoapServiceT()
	{
		Uninitialize();
	}
	
	void Uninitialize()
	{
		UninitializeSOAP();
	}	

	HRESULT performStringOperation(
		BSTR bstrInput, 
		BSTR* __retval
	);
};

typedef CPoolAsyncSoapServiceT<> CPoolAsyncSoapService;

struct __CPoolAsyncSoapService_performStringOperation_struct
{
	BSTR bstrInput;
	BSTR __retval;
};

extern __declspec(selectany) const _soapmapentry __CPoolAsyncSoapService_performStringOperation_entries[] =
{

	{
		0xA9ECBD0B, 
		"bstrInput", 
		L"bstrInput", 
		sizeof("bstrInput")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CPoolAsyncSoapService_performStringOperation_struct, bstrInput),
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
		offsetof(__CPoolAsyncSoapService_performStringOperation_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CPoolAsyncSoapService_performStringOperation_map =
{
	0x3BAAB6C3,
	"performStringOperation",
	L"performStringOperation",
	sizeof("performStringOperation")-1,
	sizeof("performStringOperation")-1,
	SOAPMAP_FUNC,
	__CPoolAsyncSoapService_performStringOperation_entries,
	sizeof(__CPoolAsyncSoapService_performStringOperation_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0xE988F68B,
	"urn:PoolAsyncSoapService",
	L"urn:PoolAsyncSoapService",
	sizeof("urn:PoolAsyncSoapService")-1
};

extern __declspec(selectany) const _soapmapentry __CPoolAsyncSoapService_performStringOperation_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CPoolAsyncSoapService_performStringOperation_atlsoapheader_map = 
{
	0x3BAAB6C3,
	"performStringOperation",
	L"performStringOperation",
	sizeof("performStringOperation")-1,
	sizeof("performStringOperation")-1,
	SOAPMAP_HEADER,
	__CPoolAsyncSoapService_performStringOperation_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE,
	0xE988F68B,
	"urn:PoolAsyncSoapService",
	L"urn:PoolAsyncSoapService",
	sizeof("urn:PoolAsyncSoapService")-1
};
extern __declspec(selectany) const _soapmap * __CPoolAsyncSoapService_funcs[] =
{
	&__CPoolAsyncSoapService_performStringOperation_map,
	NULL
};

extern __declspec(selectany) const _soapmap * __CPoolAsyncSoapService_headers[] =
{
	&__CPoolAsyncSoapService_performStringOperation_atlsoapheader_map,
	NULL
};

template <typename TClient>
inline HRESULT CPoolAsyncSoapServiceT<TClient>::performStringOperation(
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
	__CPoolAsyncSoapService_performStringOperation_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.bstrInput = bstrInput;

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#performStringOperation\"\r\n"));
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
ATL_NOINLINE inline const _soapmap ** CPoolAsyncSoapServiceT<TClient>::GetFunctionMap()
{
	return __CPoolAsyncSoapService_funcs;
}

template <typename TClient>
ATL_NOINLINE inline const _soapmap ** CPoolAsyncSoapServiceT<TClient>::GetHeaderMap()
{
	return __CPoolAsyncSoapService_headers;
}

template <typename TClient>
ATL_NOINLINE inline void * CPoolAsyncSoapServiceT<TClient>::GetHeaderValue()
{
	return this;
}

template <typename TClient>
ATL_NOINLINE inline const wchar_t * CPoolAsyncSoapServiceT<TClient>::GetNamespaceUri()
{
	return L"urn:PoolAsyncSoapService";
}

template <typename TClient>
ATL_NOINLINE inline const char * CPoolAsyncSoapServiceT<TClient>::GetServiceName()
{
	return NULL;
}

template <typename TClient>
ATL_NOINLINE inline const char * CPoolAsyncSoapServiceT<TClient>::GetNamespaceUriA()
{
	return "urn:PoolAsyncSoapService";
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CPoolAsyncSoapServiceT<TClient>::CallFunction(
	void *, 
	const wchar_t *, int,
	size_t)
{
	return E_NOTIMPL;
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CPoolAsyncSoapServiceT<TClient>::GetClientReader(ISAXXMLReader **ppReader)
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

} // namespace PoolAsyncSoapService

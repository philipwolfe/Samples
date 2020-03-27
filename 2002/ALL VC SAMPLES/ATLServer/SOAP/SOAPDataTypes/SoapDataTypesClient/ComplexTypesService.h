//
// sproxy.exe generated file
// do not modify this file
//
// Created: 05/17/2001@18:40:11
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

namespace ComplexTypesService
{

struct stComplex
{
	int iID;
	BSTR bstrData;
};

struct stNested
{
	int iExtValue;
	stComplex innerStruct;
};

struct stEmbeddedArr
{
	BSTR bstrVal;
	int nCount;
	int *arValues;
};

template <typename TClient = CSoapSocketClientT<> >
class CComplexTypesServiceT : 
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

	CComplexTypesServiceT(ISAXXMLReader *pReader = NULL)
		:TClient(_T("http://localhost/SoapDataTypes/SoapDataTypes.dll?Handler=ComplexTypes"))
	{
		SetClient(true);
		SetReader(pReader);
	}
	
	~CComplexTypesServiceT()
	{
		Uninitialize();
	}
	
	void Uninitialize()
	{
		UninitializeSOAP();
	}	

	HRESULT sample_fixedSize_Array(
		int arIn[2], 
		int __retval[2]
	);

	HRESULT sample_dynamicSize_Array(
		int* arIn, int arIn_nSizeIs, 
		int** __retval, int* __retval_nSizeIs
	);

	HRESULT sample_NestedStruct(
		stNested inStruct, 
		stNested* __retval
	);

	HRESULT sample_struct(
		stComplex inStruct, 
		stComplex* __retval
	);

	HRESULT sample_structArray(
		stComplex* arIn, int arIn_nSizeIs, 
		stComplex** __retval, int* __retval_nSizeIs
	);

	HRESULT sample_NestedArray(
		stEmbeddedArr inStruct, 
		stEmbeddedArr* __retval
	);
};

typedef CComplexTypesServiceT<> CComplexTypesService;

__if_not_exists(__stComplex_entries)
{
extern __declspec(selectany) const _soapmapentry __stComplex_entries[] =
{
	{ 
		0x0001C856, 
		"iID", 
		L"iID", 
		sizeof("iID")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(stComplex, iID),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x1C6910F5, 
		"bstrData", 
		L"bstrData", 
		sizeof("bstrData")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_FIELD | SOAPFLAG_NULLABLE, 
		offsetof(stComplex, bstrData),
		NULL, 
		NULL, 
		-1 
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __stComplex_map =
{
	0x92196FFF,
	"stComplex",
	L"stComplex",
	sizeof("stComplex")-1,
	sizeof("stComplex")-1,
	SOAPMAP_STRUCT,
	__stComplex_entries,
	sizeof(stComplex),
	2,
	-1,
	SOAPFLAG_NONE,
	0x5C7EF26D,
	NULL,
	NULL,
	0};
}

__if_not_exists(__stNested_entries)
{
extern __declspec(selectany) const _soapmapentry __stNested_entries[] =
{
	{ 
		0x9EF6E477, 
		"iExtValue", 
		L"iExtValue", 
		sizeof("iExtValue")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD, 
		offsetof(stNested, iExtValue),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0xC48115C1, 
		"innerStruct", 
		L"innerStruct", 
		sizeof("innerStruct")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_FIELD, 
		offsetof(stNested, innerStruct),
		NULL, 
		&__stComplex_map, 
		-1 
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __stNested_map =
{
	0xC04D3EEA,
	"stNested",
	L"stNested",
	sizeof("stNested")-1,
	sizeof("stNested")-1,
	SOAPMAP_STRUCT,
	__stNested_entries,
	sizeof(stNested),
	2,
	-1,
	SOAPFLAG_NONE,
	0x5C7EF26D,
	NULL,
	NULL,
	0};
}

__if_not_exists(__stEmbeddedArr_entries)
{
extern __declspec(selectany) const _soapmapentry __stEmbeddedArr_entries[] =
{
	{ 
		0x8C7F9A9E, 
		"bstrVal", 
		L"bstrVal", 
		sizeof("bstrVal")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_FIELD | SOAPFLAG_NULLABLE, 
		offsetof(stEmbeddedArr, bstrVal),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x0592BD57, 
		"nCount", 
		L"nCount", 
		sizeof("nCount")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD | SOAPFLAG_SIZEIS, 
		offsetof(stEmbeddedArr, nCount),
		NULL, 
		NULL, 
		-1 
	},
	{ 
		0x9C14DE43, 
		"arValues", 
		L"arValues", 
		sizeof("arValues")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_FIELD | SOAPFLAG_DYNARR | SOAPFLAG_NULLABLE, 
		offsetof(stEmbeddedArr, arValues),
		NULL, 
		NULL, 
		1 
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __stEmbeddedArr_map =
{
	0x506FB856,
	"stEmbeddedArr",
	L"stEmbeddedArr",
	sizeof("stEmbeddedArr")-1,
	sizeof("stEmbeddedArr")-1,
	SOAPMAP_STRUCT,
	__stEmbeddedArr_entries,
	sizeof(stEmbeddedArr),
	3,
	-1,
	SOAPFLAG_NONE,
	0x5C7EF26D,
	NULL,
	NULL,
	0};
}

extern __declspec(selectany) const int __CComplexTypesService_sample_fixedSize_Array_arIn_dims[] = {1, 2, };

extern __declspec(selectany) const int __CComplexTypesService_sample_fixedSize_Array___retval_dims[] = {1, 2, };

struct __CComplexTypesService_sample_fixedSize_Array_struct
{
	int arIn[2];
	int __retval[2];
};

extern __declspec(selectany) const _soapmapentry __CComplexTypesService_sample_fixedSize_Array_entries[] =
{

	{
		0x00371F8A, 
		"arIn", 
		L"arIn", 
		sizeof("arIn")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_FIXEDARR | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CComplexTypesService_sample_fixedSize_Array_struct, arIn),
		__CComplexTypesService_sample_fixedSize_Array_arIn_dims,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_FIXEDARR | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CComplexTypesService_sample_fixedSize_Array_struct, __retval),
		__CComplexTypesService_sample_fixedSize_Array___retval_dims,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CComplexTypesService_sample_fixedSize_Array_map =
{
	0x562996EA,
	"sample_fixedSize_Array",
	L"sample_fixedSize_Array",
	sizeof("sample_fixedSize_Array")-1,
	sizeof("sample_fixedSize_Array")-1,
	SOAPMAP_FUNC,
	__CComplexTypesService_sample_fixedSize_Array_entries,
	sizeof(__CComplexTypesService_sample_fixedSize_Array_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x5C7EF26D,
	"urn:ComplexTypesService",
	L"urn:ComplexTypesService",
	sizeof("urn:ComplexTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CComplexTypesService_sample_fixedSize_Array_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CComplexTypesService_sample_fixedSize_Array_atlsoapheader_map = 
{
	0x562996EA,
	"sample_fixedSize_Array",
	L"sample_fixedSize_Array",
	sizeof("sample_fixedSize_Array")-1,
	sizeof("sample_fixedSize_Array")-1,
	SOAPMAP_HEADER,
	__CComplexTypesService_sample_fixedSize_Array_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x5C7EF26D,
	"urn:ComplexTypesService",
	L"urn:ComplexTypesService",
	sizeof("urn:ComplexTypesService")-1
};

struct __CComplexTypesService_sample_dynamicSize_Array_struct
{
	int *arIn;
	int __arIn_nSizeIs;
	int *__retval;
	int ____retval_nSizeIs;
};

extern __declspec(selectany) const _soapmapentry __CComplexTypesService_sample_dynamicSize_Array_entries[] =
{

	{
		0x00371F8A, 
		"arIn", 
		L"arIn", 
		sizeof("arIn")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_DYNARR | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CComplexTypesService_sample_dynamicSize_Array_struct, arIn),
		NULL,
		NULL,
		0+1,
	},
	{
		0x00371F8A,
		"__arIn_nSizeIs",
		L"__arIn_nSizeIs",
		sizeof("__arIn_nSizeIs")-1,
		SOAPTYPE_INT,
		SOAPFLAG_NOMARSHAL,
		offsetof(__CComplexTypesService_sample_dynamicSize_Array_struct, __arIn_nSizeIs),
		NULL,
		NULL,
		-1
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_DYNARR | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CComplexTypesService_sample_dynamicSize_Array_struct, __retval),
		NULL,
		NULL,
		2+1,
	},
	{
		0x11515F60,
		"__return_nSizeIs",
		L"__return_nSizeIs",
		sizeof("__return_nSizeIs")-1,
		SOAPTYPE_INT,
		SOAPFLAG_NOMARSHAL,
		offsetof(__CComplexTypesService_sample_dynamicSize_Array_struct, ____retval_nSizeIs),
		NULL,
		NULL,
		-1
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CComplexTypesService_sample_dynamicSize_Array_map =
{
	0x788BB39F,
	"sample_dynamicSize_Array",
	L"sample_dynamicSize_Array",
	sizeof("sample_dynamicSize_Array")-1,
	sizeof("sample_dynamicSize_Array")-1,
	SOAPMAP_FUNC,
	__CComplexTypesService_sample_dynamicSize_Array_entries,
	sizeof(__CComplexTypesService_sample_dynamicSize_Array_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x5C7EF26D,
	"urn:ComplexTypesService",
	L"urn:ComplexTypesService",
	sizeof("urn:ComplexTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CComplexTypesService_sample_dynamicSize_Array_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CComplexTypesService_sample_dynamicSize_Array_atlsoapheader_map = 
{
	0x788BB39F,
	"sample_dynamicSize_Array",
	L"sample_dynamicSize_Array",
	sizeof("sample_dynamicSize_Array")-1,
	sizeof("sample_dynamicSize_Array")-1,
	SOAPMAP_HEADER,
	__CComplexTypesService_sample_dynamicSize_Array_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x5C7EF26D,
	"urn:ComplexTypesService",
	L"urn:ComplexTypesService",
	sizeof("urn:ComplexTypesService")-1
};

struct __CComplexTypesService_sample_NestedStruct_struct
{
	stNested inStruct;
	stNested __retval;
};

extern __declspec(selectany) const _soapmapentry __CComplexTypesService_sample_NestedStruct_entries[] =
{

	{
		0xC49633FC, 
		"inStruct", 
		L"inStruct", 
		sizeof("inStruct")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CComplexTypesService_sample_NestedStruct_struct, inStruct),
		NULL,
		&__stNested_map,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CComplexTypesService_sample_NestedStruct_struct, __retval),
		NULL,
		&__stNested_map,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CComplexTypesService_sample_NestedStruct_map =
{
	0x6FE718C9,
	"sample_NestedStruct",
	L"sample_NestedStruct",
	sizeof("sample_NestedStruct")-1,
	sizeof("sample_NestedStruct")-1,
	SOAPMAP_FUNC,
	__CComplexTypesService_sample_NestedStruct_entries,
	sizeof(__CComplexTypesService_sample_NestedStruct_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x5C7EF26D,
	"urn:ComplexTypesService",
	L"urn:ComplexTypesService",
	sizeof("urn:ComplexTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CComplexTypesService_sample_NestedStruct_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CComplexTypesService_sample_NestedStruct_atlsoapheader_map = 
{
	0x6FE718C9,
	"sample_NestedStruct",
	L"sample_NestedStruct",
	sizeof("sample_NestedStruct")-1,
	sizeof("sample_NestedStruct")-1,
	SOAPMAP_HEADER,
	__CComplexTypesService_sample_NestedStruct_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x5C7EF26D,
	"urn:ComplexTypesService",
	L"urn:ComplexTypesService",
	sizeof("urn:ComplexTypesService")-1
};

struct __CComplexTypesService_sample_struct_struct
{
	stComplex inStruct;
	stComplex __retval;
};

extern __declspec(selectany) const _soapmapentry __CComplexTypesService_sample_struct_entries[] =
{

	{
		0xC49633FC, 
		"inStruct", 
		L"inStruct", 
		sizeof("inStruct")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CComplexTypesService_sample_struct_struct, inStruct),
		NULL,
		&__stComplex_map,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CComplexTypesService_sample_struct_struct, __retval),
		NULL,
		&__stComplex_map,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CComplexTypesService_sample_struct_map =
{
	0xC10A6386,
	"sample_struct",
	L"sample_struct",
	sizeof("sample_struct")-1,
	sizeof("sample_struct")-1,
	SOAPMAP_FUNC,
	__CComplexTypesService_sample_struct_entries,
	sizeof(__CComplexTypesService_sample_struct_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x5C7EF26D,
	"urn:ComplexTypesService",
	L"urn:ComplexTypesService",
	sizeof("urn:ComplexTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CComplexTypesService_sample_struct_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CComplexTypesService_sample_struct_atlsoapheader_map = 
{
	0xC10A6386,
	"sample_struct",
	L"sample_struct",
	sizeof("sample_struct")-1,
	sizeof("sample_struct")-1,
	SOAPMAP_HEADER,
	__CComplexTypesService_sample_struct_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x5C7EF26D,
	"urn:ComplexTypesService",
	L"urn:ComplexTypesService",
	sizeof("urn:ComplexTypesService")-1
};

struct __CComplexTypesService_sample_structArray_struct
{
	stComplex *arIn;
	int __arIn_nSizeIs;
	stComplex *__retval;
	int ____retval_nSizeIs;
};

extern __declspec(selectany) const _soapmapentry __CComplexTypesService_sample_structArray_entries[] =
{

	{
		0x00371F8A, 
		"arIn", 
		L"arIn", 
		sizeof("arIn")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_DYNARR | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CComplexTypesService_sample_structArray_struct, arIn),
		NULL,
		&__stComplex_map,
		0+1,
	},
	{
		0x00371F8A,
		"__arIn_nSizeIs",
		L"__arIn_nSizeIs",
		sizeof("__arIn_nSizeIs")-1,
		SOAPTYPE_INT,
		SOAPFLAG_NOMARSHAL,
		offsetof(__CComplexTypesService_sample_structArray_struct, __arIn_nSizeIs),
		NULL,
		NULL,
		-1
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_DYNARR | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CComplexTypesService_sample_structArray_struct, __retval),
		NULL,
		&__stComplex_map,
		2+1,
	},
	{
		0x11515F60,
		"__return_nSizeIs",
		L"__return_nSizeIs",
		sizeof("__return_nSizeIs")-1,
		SOAPTYPE_INT,
		SOAPFLAG_NOMARSHAL,
		offsetof(__CComplexTypesService_sample_structArray_struct, ____retval_nSizeIs),
		NULL,
		NULL,
		-1
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CComplexTypesService_sample_structArray_map =
{
	0x236C3525,
	"sample_structArray",
	L"sample_structArray",
	sizeof("sample_structArray")-1,
	sizeof("sample_structArray")-1,
	SOAPMAP_FUNC,
	__CComplexTypesService_sample_structArray_entries,
	sizeof(__CComplexTypesService_sample_structArray_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x5C7EF26D,
	"urn:ComplexTypesService",
	L"urn:ComplexTypesService",
	sizeof("urn:ComplexTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CComplexTypesService_sample_structArray_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CComplexTypesService_sample_structArray_atlsoapheader_map = 
{
	0x236C3525,
	"sample_structArray",
	L"sample_structArray",
	sizeof("sample_structArray")-1,
	sizeof("sample_structArray")-1,
	SOAPMAP_HEADER,
	__CComplexTypesService_sample_structArray_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x5C7EF26D,
	"urn:ComplexTypesService",
	L"urn:ComplexTypesService",
	sizeof("urn:ComplexTypesService")-1
};

struct __CComplexTypesService_sample_NestedArray_struct
{
	stEmbeddedArr inStruct;
	stEmbeddedArr __retval;
};

extern __declspec(selectany) const _soapmapentry __CComplexTypesService_sample_NestedArray_entries[] =
{

	{
		0xC49633FC, 
		"inStruct", 
		L"inStruct", 
		sizeof("inStruct")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CComplexTypesService_sample_NestedArray_struct, inStruct),
		NULL,
		&__stEmbeddedArr_map,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CComplexTypesService_sample_NestedArray_struct, __retval),
		NULL,
		&__stEmbeddedArr_map,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CComplexTypesService_sample_NestedArray_map =
{
	0x9D440D63,
	"sample_NestedArray",
	L"sample_NestedArray",
	sizeof("sample_NestedArray")-1,
	sizeof("sample_NestedArray")-1,
	SOAPMAP_FUNC,
	__CComplexTypesService_sample_NestedArray_entries,
	sizeof(__CComplexTypesService_sample_NestedArray_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x5C7EF26D,
	"urn:ComplexTypesService",
	L"urn:ComplexTypesService",
	sizeof("urn:ComplexTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CComplexTypesService_sample_NestedArray_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CComplexTypesService_sample_NestedArray_atlsoapheader_map = 
{
	0x9D440D63,
	"sample_NestedArray",
	L"sample_NestedArray",
	sizeof("sample_NestedArray")-1,
	sizeof("sample_NestedArray")-1,
	SOAPMAP_HEADER,
	__CComplexTypesService_sample_NestedArray_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x5C7EF26D,
	"urn:ComplexTypesService",
	L"urn:ComplexTypesService",
	sizeof("urn:ComplexTypesService")-1
};
extern __declspec(selectany) const _soapmap * __CComplexTypesService_funcs[] =
{
	&__CComplexTypesService_sample_fixedSize_Array_map,
	&__CComplexTypesService_sample_dynamicSize_Array_map,
	&__CComplexTypesService_sample_NestedStruct_map,
	&__CComplexTypesService_sample_struct_map,
	&__CComplexTypesService_sample_structArray_map,
	&__CComplexTypesService_sample_NestedArray_map,
	NULL
};

extern __declspec(selectany) const _soapmap * __CComplexTypesService_headers[] =
{
	&__CComplexTypesService_sample_fixedSize_Array_atlsoapheader_map,
	&__CComplexTypesService_sample_dynamicSize_Array_atlsoapheader_map,
	&__CComplexTypesService_sample_NestedStruct_atlsoapheader_map,
	&__CComplexTypesService_sample_struct_atlsoapheader_map,
	&__CComplexTypesService_sample_structArray_atlsoapheader_map,
	&__CComplexTypesService_sample_NestedArray_atlsoapheader_map,
	NULL
};

template <typename TClient>
inline HRESULT CComplexTypesServiceT<TClient>::sample_fixedSize_Array(
		int arIn[2], 
		int __retval[2]
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
	__CComplexTypesService_sample_fixedSize_Array_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	memcpy(__params.arIn, arIn, 2*sizeof(int));

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_fixedSize_Array\"\r\n"));
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
	
	// cleanup any in/out-params and out-headers from previous calls
	Cleanup();
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	memcpy(__retval, __params.__retval, 2*sizeof(int));
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CComplexTypesServiceT<TClient>::sample_dynamicSize_Array(
		int* arIn, int __arIn_nSizeIs, 
		int** __retval, int* ____retval_nSizeIs
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
	__CComplexTypesService_sample_dynamicSize_Array_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.arIn = arIn;
	__params.__arIn_nSizeIs = __arIn_nSizeIs;

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_dynamicSize_Array\"\r\n"));
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
	
	// cleanup any in/out-params and out-headers from previous calls
	Cleanup();
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	*__retval = __params.__retval;
	*____retval_nSizeIs = __params.____retval_nSizeIs;
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CComplexTypesServiceT<TClient>::sample_NestedStruct(
		stNested inStruct, 
		stNested* __retval
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
	__CComplexTypesService_sample_NestedStruct_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inStruct = inStruct;

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_NestedStruct\"\r\n"));
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
	
	// cleanup any in/out-params and out-headers from previous calls
	Cleanup();
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
inline HRESULT CComplexTypesServiceT<TClient>::sample_struct(
		stComplex inStruct, 
		stComplex* __retval
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
	__CComplexTypesService_sample_struct_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inStruct = inStruct;

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_struct\"\r\n"));
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
	
	// cleanup any in/out-params and out-headers from previous calls
	Cleanup();
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
inline HRESULT CComplexTypesServiceT<TClient>::sample_structArray(
		stComplex* arIn, int __arIn_nSizeIs, 
		stComplex** __retval, int* ____retval_nSizeIs
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
	__CComplexTypesService_sample_structArray_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.arIn = arIn;
	__params.__arIn_nSizeIs = __arIn_nSizeIs;

	__atlsoap_hr = SetClientStruct(&__params, 4);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_structArray\"\r\n"));
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
	
	// cleanup any in/out-params and out-headers from previous calls
	Cleanup();
	__atlsoap_hr = BeginParse(__atlsoap_spReadStream);
	if (FAILED(__atlsoap_hr))
	{
		SetClientError(SOAPCLIENT_PARSE_ERROR);
		goto __cleanup;
	}

	*__retval = __params.__retval;
	*____retval_nSizeIs = __params.____retval_nSizeIs;
	goto __skip_cleanup;
	
__cleanup:
	Cleanup();
__skip_cleanup:
	ResetClientState(true);
	memset(&__params, 0x00, sizeof(__params));
	return __atlsoap_hr;
}

template <typename TClient>
inline HRESULT CComplexTypesServiceT<TClient>::sample_NestedArray(
		stEmbeddedArr inStruct, 
		stEmbeddedArr* __retval
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
	__CComplexTypesService_sample_NestedArray_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inStruct = inStruct;

	__atlsoap_hr = SetClientStruct(&__params, 5);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_NestedArray\"\r\n"));
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
	
	// cleanup any in/out-params and out-headers from previous calls
	Cleanup();
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
ATL_NOINLINE inline const _soapmap ** CComplexTypesServiceT<TClient>::GetFunctionMap()
{
	return __CComplexTypesService_funcs;
}

template <typename TClient>
ATL_NOINLINE inline const _soapmap ** CComplexTypesServiceT<TClient>::GetHeaderMap()
{
	return __CComplexTypesService_headers;
}

template <typename TClient>
ATL_NOINLINE inline void * CComplexTypesServiceT<TClient>::GetHeaderValue()
{
	return this;
}

template <typename TClient>
ATL_NOINLINE inline const wchar_t * CComplexTypesServiceT<TClient>::GetNamespaceUri()
{
	return L"urn:ComplexTypesService";
}

template <typename TClient>
ATL_NOINLINE inline const char * CComplexTypesServiceT<TClient>::GetServiceName()
{
	return NULL;
}

template <typename TClient>
ATL_NOINLINE inline const char * CComplexTypesServiceT<TClient>::GetNamespaceUriA()
{
	return "urn:ComplexTypesService";
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CComplexTypesServiceT<TClient>::CallFunction(
	void *, 
	const wchar_t *, int,
	size_t)
{
	return E_NOTIMPL;
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CComplexTypesServiceT<TClient>::GetClientReader(ISAXXMLReader **ppReader)
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

} // namespace ComplexTypesService

inline HRESULT AtlCleanupValue<ComplexTypesService::stComplex>(ComplexTypesService::stComplex *pVal)
{
	pVal;
	AtlCleanupValue(&pVal->iID);
	AtlCleanupValue(&pVal->bstrData);
	return S_OK;
}

inline HRESULT AtlCleanupValueEx<ComplexTypesService::stComplex>(ComplexTypesService::stComplex *pVal, IAtlMemMgr *pMemMgr)
{
	pVal;
	pMemMgr;
	
	AtlCleanupValueEx(&pVal->iID, pMemMgr);
	AtlCleanupValueEx(&pVal->bstrData, pMemMgr);
	return S_OK;
}

inline HRESULT AtlCleanupValue<ComplexTypesService::stNested>(ComplexTypesService::stNested *pVal)
{
	pVal;
	AtlCleanupValue(&pVal->iExtValue);
	AtlCleanupValue(&pVal->innerStruct);
	return S_OK;
}

inline HRESULT AtlCleanupValueEx<ComplexTypesService::stNested>(ComplexTypesService::stNested *pVal, IAtlMemMgr *pMemMgr)
{
	pVal;
	pMemMgr;
	
	AtlCleanupValueEx(&pVal->iExtValue, pMemMgr);
	AtlCleanupValueEx(&pVal->innerStruct, pMemMgr);
	return S_OK;
}

inline HRESULT AtlCleanupValue<ComplexTypesService::stEmbeddedArr>(ComplexTypesService::stEmbeddedArr *pVal)
{
	pVal;
	AtlCleanupValue(&pVal->bstrVal);
	AtlCleanupValue(&pVal->nCount);
	AtlCleanupArray(pVal->arValues, pVal->nCount);
	return S_OK;
}

inline HRESULT AtlCleanupValueEx<ComplexTypesService::stEmbeddedArr>(ComplexTypesService::stEmbeddedArr *pVal, IAtlMemMgr *pMemMgr)
{
	pVal;
	pMemMgr;
	
	AtlCleanupValueEx(&pVal->bstrVal, pMemMgr);
	AtlCleanupValueEx(&pVal->nCount, pMemMgr);
	AtlCleanupArrayEx(pVal->arValues, pVal->nCount, pMemMgr);
	return S_OK;
}

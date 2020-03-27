//
// sproxy.exe generated file
// do not modify this file
//
// Created: 05/17/2001@18:40:30
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

namespace SoapDataTypesService
{

enum eEnum { eSECOND = 0, eFIRST = 1, };

template <typename TClient = CSoapSocketClientT<> >
class CSoapDataTypesServiceT : 
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

	CSoapDataTypesServiceT(ISAXXMLReader *pReader = NULL)
		:TClient(_T("http://localhost/SoapDataTypes/SoapDataTypes.dll?Handler=Default"))
	{
		SetClient(true);
		SetReader(pReader);
	}
	
	~CSoapDataTypesServiceT()
	{
		Uninitialize();
	}
	
	void Uninitialize()
	{
		UninitializeSOAP();
	}	

	HRESULT sample_Enum(
		eEnum inEnum, 
		eEnum* __retval
	);

	HRESULT sample_UnsignedInt64(
		unsigned __int64 inUInt64, 
		unsigned __int64* __retval
	);

	HRESULT sample_UnsignedInt32(
		unsigned int inUInt32, 
		unsigned int* __retval
	);

	HRESULT sample_Int(
		int inInt, 
		int* __retval
	);

	HRESULT sample_UnsignedInt8(
		unsigned char inUInt8, 
		unsigned char* __retval
	);

	HRESULT sample_UnsignedInt(
		unsigned int inUInt, 
		unsigned int* __retval
	);

	HRESULT sample_Char(
		char inChar, 
		char* __retval
	);

	HRESULT sample_Int16(
		short inInt16, 
		short* __retval
	);

	HRESULT sample_Double(
		double inDouble, 
		double* __retval
	);

	HRESULT sample_UnsignedInt16(
		unsigned short inUInt16, 
		unsigned short* __retval
	);

	HRESULT sample_WChar(
		unsigned short inWChar, 
		unsigned short* __retval
	);

	HRESULT sample_bool(
		bool inBool, 
		bool* __retval
	);

	HRESULT sample_Int8(
		char inInt8, 
		char* __retval
	);

	HRESULT sample_Short(
		short inShort, 
		short* __retval
	);

	HRESULT sample_Float(
		float inFloat, 
		float* __retval
	);

	HRESULT sample_Int64(
		__int64 inInt64, 
		__int64* __retval
	);

	HRESULT sample_BLOB(
		ATLSOAP_BLOB inBlob, 
		ATLSOAP_BLOB* __retval
	);

	HRESULT sample_Int32(
		int inInt32, 
		int* __retval
	);

	HRESULT sample_BSTR(
		BSTR inBSTR, 
		BSTR* __retval
	);
};

typedef CSoapDataTypesServiceT<> CSoapDataTypesService;

__if_not_exists(__eEnum_entries)
{
extern __declspec(selectany) const _soapmapentry __eEnum_entries[] =
{
	{ 0x255CD6E1, "eSECOND", L"eSECOND", sizeof("eSECOND")-1, 0, SOAPFLAG_FIELD, 0, NULL, NULL, -1 },
	{ 0xF0B52A4D, "eFIRST", L"eFIRST", sizeof("eFIRST")-1, 1, SOAPFLAG_FIELD, 0, NULL, NULL, -1 },
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __eEnum_map =
{
	0x074B647A,
	"eEnum",
	L"eEnum",
	sizeof("eEnum")-1,
	sizeof("eEnum")-1,
	SOAPMAP_ENUM,
	__eEnum_entries,
	sizeof(eEnum),
	1,
	-1,
	SOAPFLAG_NONE,
	0x95F78D02,
	NULL,
	NULL,
	0};
}

struct __CSoapDataTypesService_sample_Enum_struct
{
	eEnum inEnum;
	eEnum __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Enum_entries[] =
{

	{
		0xFCDBEB0C, 
		"inEnum", 
		L"inEnum", 
		sizeof("inEnum")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Enum_struct, inEnum),
		NULL,
		&__eEnum_map,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNK, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Enum_struct, __retval),
		NULL,
		&__eEnum_map,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Enum_map =
{
	0xD27923F6,
	"sample_Enum",
	L"sample_Enum",
	sizeof("sample_Enum")-1,
	sizeof("sample_Enum")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_Enum_entries,
	sizeof(__CSoapDataTypesService_sample_Enum_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Enum_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Enum_atlsoapheader_map = 
{
	0xD27923F6,
	"sample_Enum",
	L"sample_Enum",
	sizeof("sample_Enum")-1,
	sizeof("sample_Enum")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_Enum_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_UnsignedInt64_struct
{
	unsigned __int64 inUInt64;
	unsigned __int64 __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_UnsignedInt64_entries[] =
{

	{
		0xC6342BC1, 
		"inUInt64", 
		L"inUInt64", 
		sizeof("inUInt64")-1, 
		SOAPTYPE_UNSIGNEDLONG, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_UnsignedInt64_struct, inUInt64),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNSIGNEDLONG, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_UnsignedInt64_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_UnsignedInt64_map =
{
	0x8964EBF3,
	"sample_UnsignedInt64",
	L"sample_UnsignedInt64",
	sizeof("sample_UnsignedInt64")-1,
	sizeof("sample_UnsignedInt64")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_UnsignedInt64_entries,
	sizeof(__CSoapDataTypesService_sample_UnsignedInt64_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_UnsignedInt64_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_UnsignedInt64_atlsoapheader_map = 
{
	0x8964EBF3,
	"sample_UnsignedInt64",
	L"sample_UnsignedInt64",
	sizeof("sample_UnsignedInt64")-1,
	sizeof("sample_UnsignedInt64")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_UnsignedInt64_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_UnsignedInt32_struct
{
	unsigned int inUInt32;
	unsigned int __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_UnsignedInt32_entries[] =
{

	{
		0xC6342B5C, 
		"inUInt32", 
		L"inUInt32", 
		sizeof("inUInt32")-1, 
		SOAPTYPE_UNSIGNEDINT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_UnsignedInt32_struct, inUInt32),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNSIGNEDINT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_UnsignedInt32_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_UnsignedInt32_map =
{
	0x8964EB8E,
	"sample_UnsignedInt32",
	L"sample_UnsignedInt32",
	sizeof("sample_UnsignedInt32")-1,
	sizeof("sample_UnsignedInt32")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_UnsignedInt32_entries,
	sizeof(__CSoapDataTypesService_sample_UnsignedInt32_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_UnsignedInt32_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_UnsignedInt32_atlsoapheader_map = 
{
	0x8964EB8E,
	"sample_UnsignedInt32",
	L"sample_UnsignedInt32",
	sizeof("sample_UnsignedInt32")-1,
	sizeof("sample_UnsignedInt32")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_UnsignedInt32_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_Int_struct
{
	int inInt;
	int __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Int_entries[] =
{

	{
		0x07A9A3C2, 
		"inInt", 
		L"inInt", 
		sizeof("inInt")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Int_struct, inInt),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Int_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Int_map =
{
	0x3CAE676C,
	"sample_Int",
	L"sample_Int",
	sizeof("sample_Int")-1,
	sizeof("sample_Int")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_Int_entries,
	sizeof(__CSoapDataTypesService_sample_Int_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Int_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Int_atlsoapheader_map = 
{
	0x3CAE676C,
	"sample_Int",
	L"sample_Int",
	sizeof("sample_Int")-1,
	sizeof("sample_Int")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_Int_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_UnsignedInt8_struct
{
	unsigned char inUInt8;
	unsigned char __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_UnsignedInt8_entries[] =
{

	{
		0x99666DEF, 
		"inUInt8", 
		L"inUInt8", 
		sizeof("inUInt8")-1, 
		SOAPTYPE_UNSIGNEDBYTE, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_UnsignedInt8_struct, inUInt8),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNSIGNEDBYTE, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_UnsignedInt8_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_UnsignedInt8_map =
{
	0x7886EFE1,
	"sample_UnsignedInt8",
	L"sample_UnsignedInt8",
	sizeof("sample_UnsignedInt8")-1,
	sizeof("sample_UnsignedInt8")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_UnsignedInt8_entries,
	sizeof(__CSoapDataTypesService_sample_UnsignedInt8_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_UnsignedInt8_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_UnsignedInt8_atlsoapheader_map = 
{
	0x7886EFE1,
	"sample_UnsignedInt8",
	L"sample_UnsignedInt8",
	sizeof("sample_UnsignedInt8")-1,
	sizeof("sample_UnsignedInt8")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_UnsignedInt8_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_UnsignedInt_struct
{
	unsigned int inUInt;
	unsigned int __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_UnsignedInt_entries[] =
{

	{
		0xFCE412D7, 
		"inUInt", 
		L"inUInt", 
		sizeof("inUInt")-1, 
		SOAPTYPE_UNSIGNEDINT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_UnsignedInt_struct, inUInt),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNSIGNEDINT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_UnsignedInt_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_UnsignedInt_map =
{
	0xF4231E89,
	"sample_UnsignedInt",
	L"sample_UnsignedInt",
	sizeof("sample_UnsignedInt")-1,
	sizeof("sample_UnsignedInt")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_UnsignedInt_entries,
	sizeof(__CSoapDataTypesService_sample_UnsignedInt_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_UnsignedInt_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_UnsignedInt_atlsoapheader_map = 
{
	0xF4231E89,
	"sample_UnsignedInt",
	L"sample_UnsignedInt",
	sizeof("sample_UnsignedInt")-1,
	sizeof("sample_UnsignedInt")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_UnsignedInt_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_Char_struct
{
	char inChar;
	char __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Char_entries[] =
{

	{
		0xFCDAB635, 
		"inChar", 
		L"inChar", 
		sizeof("inChar")-1, 
		SOAPTYPE_BYTE, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Char_struct, inChar),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_BYTE, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Char_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Char_map =
{
	0xD277EF1F,
	"sample_Char",
	L"sample_Char",
	sizeof("sample_Char")-1,
	sizeof("sample_Char")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_Char_entries,
	sizeof(__CSoapDataTypesService_sample_Char_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Char_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Char_atlsoapheader_map = 
{
	0xD277EF1F,
	"sample_Char",
	L"sample_Char",
	sizeof("sample_Char")-1,
	sizeof("sample_Char")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_Char_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_Int16_struct
{
	short inInt16;
	short __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Int16_entries[] =
{

	{
		0x98A1A2C9, 
		"inInt16", 
		L"inInt16", 
		sizeof("inInt16")-1, 
		SOAPTYPE_SHORT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Int16_struct, inInt16),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_SHORT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Int16_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Int16_map =
{
	0x21E5F8F3,
	"sample_Int16",
	L"sample_Int16",
	sizeof("sample_Int16")-1,
	sizeof("sample_Int16")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_Int16_entries,
	sizeof(__CSoapDataTypesService_sample_Int16_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Int16_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Int16_atlsoapheader_map = 
{
	0x21E5F8F3,
	"sample_Int16",
	L"sample_Int16",
	sizeof("sample_Int16")-1,
	sizeof("sample_Int16")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_Int16_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_Double_struct
{
	double inDouble;
	double __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Double_entries[] =
{

	{
		0xA13FAD72, 
		"inDouble", 
		L"inDouble", 
		sizeof("inDouble")-1, 
		SOAPTYPE_DOUBLE, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Double_struct, inDouble),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_DOUBLE, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Double_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Double_map =
{
	0x530EC8DC,
	"sample_Double",
	L"sample_Double",
	sizeof("sample_Double")-1,
	sizeof("sample_Double")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_Double_entries,
	sizeof(__CSoapDataTypesService_sample_Double_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Double_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Double_atlsoapheader_map = 
{
	0x530EC8DC,
	"sample_Double",
	L"sample_Double",
	sizeof("sample_Double")-1,
	sizeof("sample_Double")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_Double_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_UnsignedInt16_struct
{
	unsigned short inUInt16;
	unsigned short __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_UnsignedInt16_entries[] =
{

	{
		0xC6342B1E, 
		"inUInt16", 
		L"inUInt16", 
		sizeof("inUInt16")-1, 
		SOAPTYPE_UNSIGNEDSHORT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_UnsignedInt16_struct, inUInt16),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNSIGNEDSHORT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_UnsignedInt16_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_UnsignedInt16_map =
{
	0x8964EB50,
	"sample_UnsignedInt16",
	L"sample_UnsignedInt16",
	sizeof("sample_UnsignedInt16")-1,
	sizeof("sample_UnsignedInt16")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_UnsignedInt16_entries,
	sizeof(__CSoapDataTypesService_sample_UnsignedInt16_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_UnsignedInt16_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_UnsignedInt16_atlsoapheader_map = 
{
	0x8964EB50,
	"sample_UnsignedInt16",
	L"sample_UnsignedInt16",
	sizeof("sample_UnsignedInt16")-1,
	sizeof("sample_UnsignedInt16")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_UnsignedInt16_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_WChar_struct
{
	unsigned short inWChar;
	unsigned short __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_WChar_entries[] =
{

	{
		0x998738EC, 
		"inWChar", 
		L"inWChar", 
		sizeof("inWChar")-1, 
		SOAPTYPE_UNSIGNEDSHORT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_WChar_struct, inWChar),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_UNSIGNEDSHORT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_WChar_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_WChar_map =
{
	0x22CB8F16,
	"sample_WChar",
	L"sample_WChar",
	sizeof("sample_WChar")-1,
	sizeof("sample_WChar")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_WChar_entries,
	sizeof(__CSoapDataTypesService_sample_WChar_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_WChar_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_WChar_atlsoapheader_map = 
{
	0x22CB8F16,
	"sample_WChar",
	L"sample_WChar",
	sizeof("sample_WChar")-1,
	sizeof("sample_WChar")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_WChar_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_bool_struct
{
	bool inBool;
	bool __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_bool_entries[] =
{

	{
		0xFCDA4963, 
		"inBool", 
		L"inBool", 
		sizeof("inBool")-1, 
		SOAPTYPE_BOOLEAN, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_bool_struct, inBool),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_BOOLEAN, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_bool_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_bool_map =
{
	0xD2890E6D,
	"sample_bool",
	L"sample_bool",
	sizeof("sample_bool")-1,
	sizeof("sample_bool")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_bool_entries,
	sizeof(__CSoapDataTypesService_sample_bool_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_bool_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_bool_atlsoapheader_map = 
{
	0xD2890E6D,
	"sample_bool",
	L"sample_bool",
	sizeof("sample_bool")-1,
	sizeof("sample_bool")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_bool_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_Int8_struct
{
	char inInt8;
	char __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Int8_entries[] =
{

	{
		0xFCDE1C3A, 
		"inInt8", 
		L"inInt8", 
		sizeof("inInt8")-1, 
		SOAPTYPE_BYTE, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Int8_struct, inInt8),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_BYTE, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Int8_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Int8_map =
{
	0xD27B5524,
	"sample_Int8",
	L"sample_Int8",
	sizeof("sample_Int8")-1,
	sizeof("sample_Int8")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_Int8_entries,
	sizeof(__CSoapDataTypesService_sample_Int8_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Int8_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Int8_atlsoapheader_map = 
{
	0xD27B5524,
	"sample_Int8",
	L"sample_Int8",
	sizeof("sample_Int8")-1,
	sizeof("sample_Int8")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_Int8_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_Short_struct
{
	short inShort;
	short __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Short_entries[] =
{

	{
		0x995340E7, 
		"inShort", 
		L"inShort", 
		sizeof("inShort")-1, 
		SOAPTYPE_SHORT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Short_struct, inShort),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_SHORT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Short_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Short_map =
{
	0x22979711,
	"sample_Short",
	L"sample_Short",
	sizeof("sample_Short")-1,
	sizeof("sample_Short")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_Short_entries,
	sizeof(__CSoapDataTypesService_sample_Short_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Short_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Short_atlsoapheader_map = 
{
	0x22979711,
	"sample_Short",
	L"sample_Short",
	sizeof("sample_Short")-1,
	sizeof("sample_Short")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_Short_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_Float_struct
{
	float inFloat;
	float __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Float_entries[] =
{

	{
		0x986A31AD, 
		"inFloat", 
		L"inFloat", 
		sizeof("inFloat")-1, 
		SOAPTYPE_FLOAT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Float_struct, inFloat),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_FLOAT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Float_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Float_map =
{
	0x21AE87D7,
	"sample_Float",
	L"sample_Float",
	sizeof("sample_Float")-1,
	sizeof("sample_Float")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_Float_entries,
	sizeof(__CSoapDataTypesService_sample_Float_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Float_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Float_atlsoapheader_map = 
{
	0x21AE87D7,
	"sample_Float",
	L"sample_Float",
	sizeof("sample_Float")-1,
	sizeof("sample_Float")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_Float_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_Int64_struct
{
	__int64 inInt64;
	__int64 __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Int64_entries[] =
{

	{
		0x98A1A36C, 
		"inInt64", 
		L"inInt64", 
		sizeof("inInt64")-1, 
		SOAPTYPE_LONG, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Int64_struct, inInt64),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_LONG, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Int64_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Int64_map =
{
	0x21E5F996,
	"sample_Int64",
	L"sample_Int64",
	sizeof("sample_Int64")-1,
	sizeof("sample_Int64")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_Int64_entries,
	sizeof(__CSoapDataTypesService_sample_Int64_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Int64_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Int64_atlsoapheader_map = 
{
	0x21E5F996,
	"sample_Int64",
	L"sample_Int64",
	sizeof("sample_Int64")-1,
	sizeof("sample_Int64")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_Int64_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_BLOB_struct
{
	ATLSOAP_BLOB inBlob;
	ATLSOAP_BLOB __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_BLOB_entries[] =
{

	{
		0xFCDA3C96, 
		"inBlob", 
		L"inBlob", 
		sizeof("inBlob")-1, 
		SOAPTYPE_BASE64BINARY, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_BLOB_struct, inBlob),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_BASE64BINARY, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_BLOB_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_BLOB_map =
{
	0xD276E920,
	"sample_BLOB",
	L"sample_BLOB",
	sizeof("sample_BLOB")-1,
	sizeof("sample_BLOB")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_BLOB_entries,
	sizeof(__CSoapDataTypesService_sample_BLOB_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_BLOB_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_BLOB_atlsoapheader_map = 
{
	0xD276E920,
	"sample_BLOB",
	L"sample_BLOB",
	sizeof("sample_BLOB")-1,
	sizeof("sample_BLOB")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_BLOB_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_Int32_struct
{
	int inInt32;
	int __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Int32_entries[] =
{

	{
		0x98A1A307, 
		"inInt32", 
		L"inInt32", 
		sizeof("inInt32")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Int32_struct, inInt32),
		NULL,
		NULL,
		-1,
	},
	{
		0x11515F60, 
		"return", 
		L"return", 
		sizeof("return")-1, 
		SOAPTYPE_INT, 
		SOAPFLAG_NONE | SOAPFLAG_OUT | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
		offsetof(__CSoapDataTypesService_sample_Int32_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Int32_map =
{
	0x21E5F931,
	"sample_Int32",
	L"sample_Int32",
	sizeof("sample_Int32")-1,
	sizeof("sample_Int32")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_Int32_entries,
	sizeof(__CSoapDataTypesService_sample_Int32_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_Int32_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_Int32_atlsoapheader_map = 
{
	0x21E5F931,
	"sample_Int32",
	L"sample_Int32",
	sizeof("sample_Int32")-1,
	sizeof("sample_Int32")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_Int32_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

struct __CSoapDataTypesService_sample_BSTR_struct
{
	BSTR inBSTR;
	BSTR __retval;
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_BSTR_entries[] =
{

	{
		0xFCD9CEB2, 
		"inBSTR", 
		L"inBSTR", 
		sizeof("inBSTR")-1, 
		SOAPTYPE_STRING, 
		SOAPFLAG_NONE | SOAPFLAG_IN | SOAPFLAG_RPC | SOAPFLAG_ENCODED | SOAPFLAG_NULLABLE,
		offsetof(__CSoapDataTypesService_sample_BSTR_struct, inBSTR),
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
		offsetof(__CSoapDataTypesService_sample_BSTR_struct, __retval),
		NULL,
		NULL,
		-1,
	},
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_BSTR_map =
{
	0xD277079C,
	"sample_BSTR",
	L"sample_BSTR",
	sizeof("sample_BSTR")-1,
	sizeof("sample_BSTR")-1,
	SOAPMAP_FUNC,
	__CSoapDataTypesService_sample_BSTR_entries,
	sizeof(__CSoapDataTypesService_sample_BSTR_struct),
	1,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};

extern __declspec(selectany) const _soapmapentry __CSoapDataTypesService_sample_BSTR_atlsoapheader_entries[] =
{
	{ 0x00000000 }
};

extern __declspec(selectany) const _soapmap __CSoapDataTypesService_sample_BSTR_atlsoapheader_map = 
{
	0xD277079C,
	"sample_BSTR",
	L"sample_BSTR",
	sizeof("sample_BSTR")-1,
	sizeof("sample_BSTR")-1,
	SOAPMAP_HEADER,
	__CSoapDataTypesService_sample_BSTR_atlsoapheader_entries,
	0,
	0,
	-1,
	SOAPFLAG_NONE | SOAPFLAG_RPC | SOAPFLAG_ENCODED,
	0x95F78D02,
	"urn:SoapDataTypesService",
	L"urn:SoapDataTypesService",
	sizeof("urn:SoapDataTypesService")-1
};
extern __declspec(selectany) const _soapmap * __CSoapDataTypesService_funcs[] =
{
	&__CSoapDataTypesService_sample_Enum_map,
	&__CSoapDataTypesService_sample_UnsignedInt64_map,
	&__CSoapDataTypesService_sample_UnsignedInt32_map,
	&__CSoapDataTypesService_sample_Int_map,
	&__CSoapDataTypesService_sample_UnsignedInt8_map,
	&__CSoapDataTypesService_sample_UnsignedInt_map,
	&__CSoapDataTypesService_sample_Char_map,
	&__CSoapDataTypesService_sample_Int16_map,
	&__CSoapDataTypesService_sample_Double_map,
	&__CSoapDataTypesService_sample_UnsignedInt16_map,
	&__CSoapDataTypesService_sample_WChar_map,
	&__CSoapDataTypesService_sample_bool_map,
	&__CSoapDataTypesService_sample_Int8_map,
	&__CSoapDataTypesService_sample_Short_map,
	&__CSoapDataTypesService_sample_Float_map,
	&__CSoapDataTypesService_sample_Int64_map,
	&__CSoapDataTypesService_sample_BLOB_map,
	&__CSoapDataTypesService_sample_Int32_map,
	&__CSoapDataTypesService_sample_BSTR_map,
	NULL
};

extern __declspec(selectany) const _soapmap * __CSoapDataTypesService_headers[] =
{
	&__CSoapDataTypesService_sample_Enum_atlsoapheader_map,
	&__CSoapDataTypesService_sample_UnsignedInt64_atlsoapheader_map,
	&__CSoapDataTypesService_sample_UnsignedInt32_atlsoapheader_map,
	&__CSoapDataTypesService_sample_Int_atlsoapheader_map,
	&__CSoapDataTypesService_sample_UnsignedInt8_atlsoapheader_map,
	&__CSoapDataTypesService_sample_UnsignedInt_atlsoapheader_map,
	&__CSoapDataTypesService_sample_Char_atlsoapheader_map,
	&__CSoapDataTypesService_sample_Int16_atlsoapheader_map,
	&__CSoapDataTypesService_sample_Double_atlsoapheader_map,
	&__CSoapDataTypesService_sample_UnsignedInt16_atlsoapheader_map,
	&__CSoapDataTypesService_sample_WChar_atlsoapheader_map,
	&__CSoapDataTypesService_sample_bool_atlsoapheader_map,
	&__CSoapDataTypesService_sample_Int8_atlsoapheader_map,
	&__CSoapDataTypesService_sample_Short_atlsoapheader_map,
	&__CSoapDataTypesService_sample_Float_atlsoapheader_map,
	&__CSoapDataTypesService_sample_Int64_atlsoapheader_map,
	&__CSoapDataTypesService_sample_BLOB_atlsoapheader_map,
	&__CSoapDataTypesService_sample_Int32_atlsoapheader_map,
	&__CSoapDataTypesService_sample_BSTR_atlsoapheader_map,
	NULL
};

template <typename TClient>
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_Enum(
		eEnum inEnum, 
		eEnum* __retval
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
	__CSoapDataTypesService_sample_Enum_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inEnum = inEnum;

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_Enum\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_UnsignedInt64(
		unsigned __int64 inUInt64, 
		unsigned __int64* __retval
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
	__CSoapDataTypesService_sample_UnsignedInt64_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inUInt64 = inUInt64;

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_UnsignedInt64\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_UnsignedInt32(
		unsigned int inUInt32, 
		unsigned int* __retval
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
	__CSoapDataTypesService_sample_UnsignedInt32_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inUInt32 = inUInt32;

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_UnsignedInt32\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_Int(
		int inInt, 
		int* __retval
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
	__CSoapDataTypesService_sample_Int_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inInt = inInt;

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_Int\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_UnsignedInt8(
		unsigned char inUInt8, 
		unsigned char* __retval
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
	__CSoapDataTypesService_sample_UnsignedInt8_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inUInt8 = inUInt8;

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_UnsignedInt8\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_UnsignedInt(
		unsigned int inUInt, 
		unsigned int* __retval
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
	__CSoapDataTypesService_sample_UnsignedInt_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inUInt = inUInt;

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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_UnsignedInt\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_Char(
		char inChar, 
		char* __retval
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
	__CSoapDataTypesService_sample_Char_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inChar = inChar;

	__atlsoap_hr = SetClientStruct(&__params, 6);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_Char\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_Int16(
		short inInt16, 
		short* __retval
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
	__CSoapDataTypesService_sample_Int16_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inInt16 = inInt16;

	__atlsoap_hr = SetClientStruct(&__params, 7);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_Int16\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_Double(
		double inDouble, 
		double* __retval
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
	__CSoapDataTypesService_sample_Double_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inDouble = inDouble;

	__atlsoap_hr = SetClientStruct(&__params, 8);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_Double\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_UnsignedInt16(
		unsigned short inUInt16, 
		unsigned short* __retval
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
	__CSoapDataTypesService_sample_UnsignedInt16_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inUInt16 = inUInt16;

	__atlsoap_hr = SetClientStruct(&__params, 9);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_UnsignedInt16\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_WChar(
		unsigned short inWChar, 
		unsigned short* __retval
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
	__CSoapDataTypesService_sample_WChar_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inWChar = inWChar;

	__atlsoap_hr = SetClientStruct(&__params, 10);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_WChar\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_bool(
		bool inBool, 
		bool* __retval
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
	__CSoapDataTypesService_sample_bool_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inBool = inBool;

	__atlsoap_hr = SetClientStruct(&__params, 11);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_bool\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_Int8(
		char inInt8, 
		char* __retval
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
	__CSoapDataTypesService_sample_Int8_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inInt8 = inInt8;

	__atlsoap_hr = SetClientStruct(&__params, 12);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_Int8\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_Short(
		short inShort, 
		short* __retval
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
	__CSoapDataTypesService_sample_Short_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inShort = inShort;

	__atlsoap_hr = SetClientStruct(&__params, 13);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_Short\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_Float(
		float inFloat, 
		float* __retval
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
	__CSoapDataTypesService_sample_Float_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inFloat = inFloat;

	__atlsoap_hr = SetClientStruct(&__params, 14);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_Float\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_Int64(
		__int64 inInt64, 
		__int64* __retval
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
	__CSoapDataTypesService_sample_Int64_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inInt64 = inInt64;

	__atlsoap_hr = SetClientStruct(&__params, 15);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_Int64\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_BLOB(
		ATLSOAP_BLOB inBlob, 
		ATLSOAP_BLOB* __retval
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
	__CSoapDataTypesService_sample_BLOB_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inBlob = inBlob;

	__atlsoap_hr = SetClientStruct(&__params, 16);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_BLOB\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_Int32(
		int inInt32, 
		int* __retval
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
	__CSoapDataTypesService_sample_Int32_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inInt32 = inInt32;

	__atlsoap_hr = SetClientStruct(&__params, 17);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_Int32\"\r\n"));
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
inline HRESULT CSoapDataTypesServiceT<TClient>::sample_BSTR(
		BSTR inBSTR, 
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
	__CSoapDataTypesService_sample_BSTR_struct __params;
	memset(&__params, 0x00, sizeof(__params));
	__params.inBSTR = inBSTR;

	__atlsoap_hr = SetClientStruct(&__params, 18);
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
	
	__atlsoap_hr = SendRequest(_T("SOAPAction: \"#sample_BSTR\"\r\n"));
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
ATL_NOINLINE inline const _soapmap ** CSoapDataTypesServiceT<TClient>::GetFunctionMap()
{
	return __CSoapDataTypesService_funcs;
}

template <typename TClient>
ATL_NOINLINE inline const _soapmap ** CSoapDataTypesServiceT<TClient>::GetHeaderMap()
{
	return __CSoapDataTypesService_headers;
}

template <typename TClient>
ATL_NOINLINE inline void * CSoapDataTypesServiceT<TClient>::GetHeaderValue()
{
	return this;
}

template <typename TClient>
ATL_NOINLINE inline const wchar_t * CSoapDataTypesServiceT<TClient>::GetNamespaceUri()
{
	return L"urn:SoapDataTypesService";
}

template <typename TClient>
ATL_NOINLINE inline const char * CSoapDataTypesServiceT<TClient>::GetServiceName()
{
	return NULL;
}

template <typename TClient>
ATL_NOINLINE inline const char * CSoapDataTypesServiceT<TClient>::GetNamespaceUriA()
{
	return "urn:SoapDataTypesService";
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CSoapDataTypesServiceT<TClient>::CallFunction(
	void *, 
	const wchar_t *, int,
	size_t)
{
	return E_NOTIMPL;
}

template <typename TClient>
ATL_NOINLINE inline HRESULT CSoapDataTypesServiceT<TClient>::GetClientReader(ISAXXMLReader **ppReader)
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

} // namespace SoapDataTypesService

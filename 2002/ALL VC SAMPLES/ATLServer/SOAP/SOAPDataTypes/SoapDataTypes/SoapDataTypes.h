// SoapDataTypes.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

namespace SoapDataTypesService
{
// all struct, enum, and typedefs for your webservice should go inside the namespace
typedef enum
{
	eFIRST,
	eSECOND
}eEnum;

// ISoapDataTypesService - web service interface declaration
//
[
	uuid("B9B122B8-A91B-455C-B004-D68DAB683B00"), 
	object
]
__interface ISoapDataTypesService
{
	// Sample Web Service methods for the basic types supported in SOAP
	// 
	[id(1)]		HRESULT	sample_BLOB([in]ATLSOAP_BLOB	inBlob, [out, retval]ATLSOAP_BLOB* pOutBlob);
	[id(2)]		HRESULT sample_bool([in]bool inBool, [out, retval]bool *pOutBool);
	[id(3)]		HRESULT sample_BSTR([in]BSTR inBSTR, [out, retval]BSTR* pOutBSTR);
	[id(4)]		HRESULT sample_Char([in]char inChar, [out, retval]char* pOutChar);
	[id(5)]		HRESULT sample_Double([in]double inDouble, [out, retval]double* pOutDouble);
	[id(6)]		HRESULT sample_Enum([in]eEnum inEnum, [out, retval]eEnum* pOutEnum);
	[id(7)]		HRESULT sample_Float([in]float inFloat, [out, retval]float* pOutFloat);
	[id(8)]		HRESULT sample_Int([in]int inInt, [out, retval]int* pOutInt);
	[id(9)]		HRESULT sample_Int8([in]__int8 inInt8, [out, retval]__int8 *pOutInt8);
	[id(10)]	HRESULT sample_Int16([in]__int16 inInt16, [out, retval]__int16 *pOutInt16);
	[id(11)]	HRESULT sample_Int32([in]__int32 inInt32, [out, retval]__int32 *pOutInt32);
	[id(12)]	HRESULT sample_Int64([in]__int64 inInt64, [out, retval]__int64 *pOutInt64);
	[id(13)]	HRESULT sample_Short([in]short inShort, [out, retval]short *pOutShort);
	[id(14)]	HRESULT sample_UnsignedInt([in]unsigned int inUInt, [out, retval]unsigned int* pOutUInt);
	[id(15)]	HRESULT sample_UnsignedInt8([in]unsigned __int8 inUInt8, [out, retval]unsigned __int8 *pOutUInt8);
	[id(16)]	HRESULT sample_UnsignedInt16([in]unsigned __int16 inUInt16, [out, retval]unsigned __int16 *pOutUInt16);
	[id(17)]	HRESULT sample_UnsignedInt32([in]unsigned __int32 inUInt32, [out, retval]unsigned __int32 *pOutUInt32);
	[id(18)]	HRESULT sample_UnsignedInt64([in]unsigned __int64 inUInt64, [out, retval]unsigned __int64 *pOutUInt64);
	[id(19)]	HRESULT sample_WChar([in]wchar_t inWChar, [out, retval]wchar_t	* pOutWChar);
};


// SoapDataTypesService - web service implementation
//
[
	request_handler(name="Default", sdl="GenSoapDataTypesServiceWSDL"),
	soap_handler(
		name="SoapDataTypesService", 
		namespace="urn:SoapDataTypesService",
		protocol="soap"
	)
]
class CSoapDataTypesService :
	public ISoapDataTypesService
{
public:
protected:
	// This is a sample web service method that shows how to use the 
	// basic types supported by ATLS SOAP implementation
	
	[soap_method]
	/*[id(1)]*/		HRESULT	sample_BLOB(/*[in]*/ATLSOAP_BLOB	inBlob, /*[out, retval]*/ATLSOAP_BLOB* pOutBlob)
	{
		pOutBlob->size	=	inBlob.size;
		pOutBlob->data	=	(unsigned char*)malloc(inBlob.size*sizeof(unsigned char));

		if( pOutBlob->data != NULL )
		{
			memcpy( pOutBlob->data, inBlob.data, inBlob.size);
			return S_OK;
		}
		return E_OUTOFMEMORY;
	}



	[soap_method]
	/*[id(2)]*/		HRESULT sample_bool(/*[in]*/bool inBool, /*[out, retval]*/bool *pOutBool)
	{
		*pOutBool	=	inBool;
		return S_OK;
	}



	[soap_method]
	/*[id(3)]*/		HRESULT sample_BSTR(/*[in]*/BSTR inBSTR, /*[out, retval]*/BSTR* pOutBSTR)
	{
		CComBSTR	bstrInput( inBSTR);
		*pOutBSTR	=	bstrInput.Detach();
		return S_OK;
	}



	[soap_method]
	/*[id(4)]*/		HRESULT sample_Char(/*[in]*/char inChar, /*[out, retval]*/char* pOutChar)
	{
		*pOutChar	=	inChar;
		return S_OK;
	}



	[soap_method]
	/*[id(5)]*/		HRESULT sample_Double(/*[in]*/double inDouble, /*[out, retval]*/double* pOutDouble)
	{
		*pOutDouble	=	inDouble;
		return S_OK;
	}



	[soap_method]
	/*[id(6)]*/		HRESULT sample_Enum(/*[in]*/eEnum inEnum, /*[out, retval]*/eEnum* pOutEnum)
	{
		*pOutEnum	=	inEnum;
		return S_OK;
	}



	[soap_method]
	/*[id(7)]*/		HRESULT sample_Float(/*[in]*/float	inFloat, /*[out, retval]*/float* pOutFloat)
	{
		*pOutFloat	=	inFloat;
		return S_OK;
	}

	
	[soap_method]
	/*[id(8)]*/		HRESULT sample_Int(/*[in]*/int inInt, /*[out, retval]*/int* pOutInt)
	{
		*pOutInt	=	inInt;
		return S_OK;
	}

	
	
	[soap_method]
	/*[id(9)]*/		HRESULT sample_Int8(/*[in]*/__int8 inInt8, /*[out, retval]*/__int8 *pOutInt8)
	{
		*pOutInt8 =	inInt8;
		return S_OK;
	}

	
	[soap_method]
	/*[id(10)]*/	HRESULT sample_Int16(/*[in]*/__int16 inInt16, /*[out, retval]*/__int16 *pOutInt16)
	{
		*pOutInt16	=	inInt16;
		return S_OK;
	}

	
	[soap_method]
	/*[id(11)]*/	HRESULT sample_Int32(/*[in]*/__int32 inInt32, /*[out, retval]*/__int32 *pOutInt32)
	{
		*pOutInt32	=	inInt32;
		return S_OK;
	}

	
	[soap_method]
	/*[id(12)]*/	HRESULT sample_Int64(/*[in]*/__int64 inInt64, /*[out, retval]*/__int64 *pOutInt64)
	{
		*pOutInt64 =	inInt64;
		return S_OK;
	}

	
	[soap_method]
	/*[id(13)]*/	HRESULT sample_Short(/*[in]*/short inShort, /*[out, retval]*/short *pOutShort)
	{
		*pOutShort	=	inShort;
		return S_OK;
	}

	
	[soap_method]
	/*[id(14)]*/	HRESULT sample_UnsignedInt(/*[in]*/unsigned int inUInt, /*[out, retval]*/unsigned int* pOutUInt)
	{
		*pOutUInt	=	inUInt;
		return S_OK;
	}

	
	[soap_method]
	/*[id(15)]*/	HRESULT sample_UnsignedInt8(/*[in]*/unsigned __int8 inUInt8, /*[out, retval]*/unsigned __int8 *pOutUInt8)
	{
		*pOutUInt8	=	inUInt8;
		return S_OK;
	}

	
	[soap_method]
	/*[id(16)]*/	HRESULT sample_UnsignedInt16(/*[in]*/unsigned __int16 inUInt16, /*[out, retval]*/unsigned __int16 *pOutUInt16)
	{
		*pOutUInt16	=	inUInt16;
		return S_OK;
	}

	
	[soap_method]
	/*[id(17)]*/	HRESULT sample_UnsignedInt32(/*[in]*/unsigned __int32 inUInt32, /*[out, retval]*/unsigned __int32 *pOutUInt32)
	{
		*pOutUInt32	=	inUInt32;
		return S_OK;
	}

	
	[soap_method]
	/*[id(18)]*/	HRESULT sample_UnsignedInt64(/*[in]*/unsigned __int64 inUInt64, /*[out, retval]*/unsigned __int64 *pOutUInt64)
	{
		*pOutUInt64	=	inUInt64;
		return S_OK;
	}

	
	[soap_method]
	/*[id(19)]*/	HRESULT sample_WChar(/*[in]*/wchar_t inWChar, /*[out, retval]*/wchar_t	* pOutWChar)
	{
		*pOutWChar	=	inWChar;
		return S_OK;
	}
}; // class CSoapDataTypesService


// Complex Types service

struct stComplex
{
	int		iID;
	BSTR	bstrData;
};

struct stNested
{
	int			iExtValue;
	stComplex	innerStruct;
};

struct stEmbeddedArr
{
	BSTR	bstrVal;
	int		nCount;
	[size_is(nCount)]int*	arValues;
};

// ISoapDataTypesService - web service interface declaration
//
[
	uuid("C11CA007-117F-4864-9CE7-01C0931B6378"), 
	object
]
__interface IComplexTypesService
{
	// Sample Web Service methods for the basic types supported in SOAP
	// 
	[id(1)]		HRESULT	sample_struct([in]stComplex	inStruct, [out, retval]stComplex* pOutStruct);
	[id(2)]		HRESULT sample_fixedSize_Array([in]int	arIn[2], [out, retval]int	arOut[2]);
	[id(3)]		HRESULT sample_dynamicSize_Array([in]int	sizeIn, [in, size_is(sizeIn)]int*	arIn, [out]int* sizeOut, [out, retval, size_is(*sizeOut)]int** pArOut);
	[id(4)]		HRESULT sample_structArray([in]int sizeIn, [in, size_is(sizeIn)]stComplex	*arIn, [out]int* sizeOut, [out, retval, size_is(*sizeOut)]stComplex** pArOut);
	[id(5)]		HRESULT	sample_NestedStruct([in]stNested	inStruct, [out, retval]stNested* pOutStruct);
	[id(6)]		HRESULT sample_NestedArray([in]stEmbeddedArr inStruct, [out, retval]stEmbeddedArr* pOutStruct);
};


// SoapDataTypesService - web service implementation
//
[
	request_handler(name="ComplexTypes", sdl="GenComplexTypesServiceWSDL"),
	soap_handler(
		name="ComplexTypesService", 
		namespace="urn:ComplexTypesService",
		protocol="soap"
	)
]
class CComplexTypesService :
	public IComplexTypesService
{
public:
	[soap_method]
	HRESULT	sample_struct(/*[in]*/stComplex	inStruct, /*[out, retval]*/stComplex* pOutStruct)
	{
		CComBSTR	bstrTemp;
		pOutStruct->iID	=	inStruct.iID;
		bstrTemp.Append( inStruct.bstrData);
		pOutStruct->bstrData	=	bstrTemp.Detach();
		
		return S_OK;
	}

	[soap_method]
	HRESULT sample_fixedSize_Array(/*[in]*/int	arIn[2], /*[out, retval]*/int	arOut[2])
	{
		for( int iIndex = 0; iIndex < 2; iIndex ++ )
		{
			arOut[iIndex] = arIn[iIndex] + 1;
		}
		return S_OK;
	}

	[soap_method]
	HRESULT sample_dynamicSize_Array(/*[in]*/int	sizeIn, /*[in, size_is(sizeIn)]*/int*	arIn, /*[out]*/int* sizeOut, /*[out, retval, size_is(*sizeOut)]*/int** pArOut)
	{
		
		*sizeOut	=	sizeIn + 1;
		// the memory manager MUST be used, so that the buffer is deallocated after marshalling
		*pArOut		=	(int*)GetMemMgr()->Allocate( *sizeOut * sizeof(int));
		for( int iIndex = 0; iIndex <  sizeIn; iIndex ++ )
		{
			(*pArOut)[iIndex] = arIn[iIndex];
		}
		// adding an extra element
		(*pArOut)[sizeIn]	=	0;
		return S_OK;
	}

	[soap_method]
	HRESULT sample_structArray(/*[in]*/int sizeIn, /*[in, size_is(sizeIn)]*/stComplex	*arIn, /*[out]*/int* sizeOut, /*[out, retval, size_is(*sizeOut)]*/stComplex** pArOut)
	{
		*sizeOut	=	sizeIn;
		// the memory manager MUST be used, so that the buffer is deallocated after marshalling
		*pArOut		=	(stComplex*)GetMemMgr()->Allocate( *sizeOut * sizeof(stComplex));
		for( int iIndex = 0; iIndex <  sizeIn; iIndex ++ )
		{
			CComBSTR	bstrTemp;
			(*pArOut)[iIndex].iID = arIn[iIndex].iID;
			bstrTemp.Append( arIn[iIndex].bstrData);
			(*pArOut)[iIndex].bstrData	=	bstrTemp.Detach();
		}
		// adding an extra element

		return S_OK;
	}

	[soap_method]
	HRESULT	sample_NestedStruct(/*[in]*/stNested	inStruct, /*[out, retval]*/stNested* pOutStruct)
	{
		pOutStruct->iExtValue	=	inStruct.iExtValue;
		pOutStruct->innerStruct.iID	=	inStruct.innerStruct.iID;
		pOutStruct->innerStruct.bstrData=	inStruct.innerStruct.bstrData;
		return S_OK;
	}

	[soap_method]
	HRESULT sample_NestedArray(/*[in]*/stEmbeddedArr inStruct, /*[out, retval]*/stEmbeddedArr* pOutStruct)
	{
		CComBSTR	bstrTemp;
		bstrTemp.Append( inStruct.bstrVal);
		pOutStruct->bstrVal	=	bstrTemp.Detach();

		pOutStruct->nCount	=	inStruct.nCount;

		// the memory manager MUST be used, so that the buffer is deallocated after marshalling
		pOutStruct->arValues		=	(int*)GetMemMgr()->Allocate( pOutStruct->nCount* sizeof(int));
		for( int iIndex = 0; iIndex <  inStruct.nCount; iIndex ++ )
		{
			pOutStruct->arValues[iIndex] = inStruct.arValues[iIndex];
		}

		return S_OK;
	}

};//class CComplexTypesService

} // namespace SoapDataTypesService

// File: SoapDataTypesClient.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#define _WIN32_WINDOWS 0x0500
#include "SoapDataTypesService.h"
#include "ComplexTypesService.h"

#include <windows.h>
#include <stdio.h>
#include <iostream>

using namespace std;
using namespace SoapDataTypesService;
using namespace ComplexTypesService;



// function to pack the SOAP method invocations for the Data Types
void	invokeDataTypesMethods();

// function to pack the SOAP method invocations for the aggregated Types
void	invokeDataAggregMethods();


void	displayBanner()
{
	cout	<<	"ATL Server Samples : SoapDataTypesClient "	<<	endl;
}

void main()
{
	

	displayBanner();
	
	CoInitialize(NULL);
	
	cout	<<"Invoking methods using simple types"	<<	endl;
	cout	<<"==================================="	<<	endl;
	invokeDataTypesMethods();

	cout	<<endl	<<	endl;
	
	cout	<<"Invoking methods complex simple types"	<<	endl;
	cout	<<"==================================="	<<	endl;
	invokeDataAggregMethods();


	CoUninitialize();
}




// function to pack the SOAP method invocations for the Data Types
void	invokeDataTypesMethods()
{
	CSoapDataTypesService		srv;
	HRESULT						hRet;

	cout	<<	endl	<< "Invoking sample methods for basic data types :"	<<	endl << endl;

	cout	<<	"BLOB binary type :"	<<	endl;
	{
		ATLSOAP_BLOB	blobIn, blobOut;
		
		
		blobIn.size		=	1024;
		blobIn.data		=	(unsigned char*)malloc(blobIn.size*sizeof(unsigned char));
		memset(blobIn.data, 0xFF, blobIn.size);

		hRet = srv.sample_BLOB(blobIn, &blobOut);

		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			if( ( blobIn.size	!=	blobOut.size ) ||
				( memcmp( blobIn.data, blobOut.data, blobIn.size ) != 0 ) )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;

			free(blobOut.data);
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
		free(blobIn.data);
	}
	cout	<<	endl;
	
	
	cout	<<	"bool type :"	<<	endl;
	{
		bool	in, out;
		in	=	true;		
		hRet = srv.sample_bool(in, &out);
		cout	<<	"IN Value : "	<<	(LPCSTR)(in?"true":"false")	<< endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	(LPCSTR)(out?"true":"false")	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;


	cout	<<	"BSTR type :"	<<	endl;
	{
		BSTR	in, out;
		in	=	::SysAllocString(L"Hello");		
		hRet = srv.sample_BSTR(in, &out);
		CW2A	strIn(in);
		cout	<<	"IN Value : "	<<	(LPCSTR)strIn	<< endl;
		if( SUCCEEDED(hRet) )
		{
			CW2A	strOut(out);
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	(LPCSTR)strOut	<< endl;
			if ( wcscmp( in, out) != 0 )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
			::SysFreeString( out );
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
		::SysFreeString( in );
	}
	cout	<<	endl;


	cout	<<	"char type :"	<<	endl;
	{
		char	in, out;
		in	=	'a';		
		hRet = srv.sample_Char(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;


	cout	<<	"double type :"	<<	endl;
	{
		double	in, out;
		in	=	1.2345e12;		
		hRet = srv.sample_Double(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;

	cout	<<	"enum type :"	<<	endl;
	{
		eEnum	in, out;
		in	=	eFIRST;		
		hRet = srv.sample_Enum(in, &out);
		CStringA	strEnumVal = "Unknown value";
		switch( in )
		{
			case eFIRST:
				strEnumVal	=	"eFIRST";break;
			case eSECOND:
				strEnumVal	=	"eSECOND";break;
		}
		cout	<<	"IN Value : "	<<	strEnumVal << endl;
		if( SUCCEEDED(hRet) )
		{
			strEnumVal = "Unknown value";
			switch( out )
			{
				case eFIRST:
					strEnumVal	=	"eFIRST";break;
				case eSECOND:
					strEnumVal	=	"eSECOND";break;
			}
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	strEnumVal << endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;

	cout	<<	"float type :"	<<	endl;
	{
		float	in, out;
		in	=	(float)1.2345e12;		
		hRet = srv.sample_Float(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;



	cout	<<	"int type :"	<<	endl;
	{
		int	in, out;
		in	=	10;		
		hRet = srv.sample_Int(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;


	cout	<<	"int8 type :"	<<	endl;
	{
		__int8	in, out;
		in	=	10;		
		hRet = srv.sample_Int8(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;

	cout	<<	"int16 type :"	<<	endl;
	{
		__int16	in, out;
		in	=	10;		
		hRet = srv.sample_Int16(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;

	cout	<<	"int32 type :"	<<	endl;
	{
		__int32	in, out;
		in	=	10;		
		hRet = srv.sample_Int32(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;

	cout	<<	"int64 type :"	<<	endl;
	{
		__int64	in, out;
		in	=	10;		
		hRet = srv.sample_Int64(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;




	cout	<<	"short type :"	<<	endl;
	{
		short	in, out;
		in	=	10;		
		hRet = srv.sample_Short(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;


	cout	<<	"unsigned int type :"	<<	endl;
	{
		unsigned  int	in, out;
		in	=	10;		
		hRet = srv.sample_UnsignedInt(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;


	cout	<<	"unsigned int8 type :"	<<	endl;
	{
		unsigned __int8	in, out;
		in	=	10;		
		hRet = srv.sample_UnsignedInt8(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;

	cout	<<	"unsigned int16 type :"	<<	endl;
	{
		unsigned __int16	in, out;
		in	=	10;		
		hRet = srv.sample_UnsignedInt16(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;

	cout	<<	"unsigned int32 type :"	<<	endl;
	{
		unsigned __int32	in, out;
		in	=	10;		
		hRet = srv.sample_UnsignedInt32(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;

	cout	<<	"unsigned int64 type :"	<<	endl;
	{
		unsigned __int64	in, out;
		in	=	10;		
		hRet = srv.sample_UnsignedInt64(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;




	cout	<<	"wchar_t type :"	<<	endl;
	{
		wchar_t	in, out;
		in	=	0xabab;		
		hRet = srv.sample_WChar(in, &out);
		cout	<<	"IN Value : "	<<	in << endl;
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			cout	<<	"OUT Value : "	<<	out	<< endl;
			if ( in !=	out )
				cout	<<	"Return value is DIFFERENT - Possible data corruption!"	<<	endl;
			else
				cout	<<	"Return value is the same - Data transmitted correctly!"	<<	endl;
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;

	srv.Cleanup();

}

// function to pack the SOAP method invocations for the aggregated Types
void	invokeDataAggregMethods()
{
	CComplexTypesService	srv;
	HRESULT					hRet;

	cout	<<	"Struct"	<<	endl;
	{
		stComplex	in, out;

		in.iID	=	1;
		in.bstrData	=	::SysAllocString(L"StructField");

		hRet = srv.sample_struct(in, &out);
		printf("IN: {%d %ls}\n", in.iID, in.bstrData);
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			printf("OUT: {%d %ls}\n", in.iID, in.bstrData);
			// MUST use AtlCleanupValue to clean the memory allocated by the marshaller to fill the struct
			AtlCleanupValue(&out);
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;

	cout	<<	"Fixed size array"	<<	endl;
	{
		int		in[2];
		int		out[2];


		in[0]	=		0;
		in[1]	=		1;
		
		hRet = srv.sample_fixedSize_Array(in, out);
		printf("IN: [%d %d]\n", in[0], in[1]);
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			printf("OUT: [%d %d]\n", out[0], out[1]);

			AtlCleanupArray(out, 2);
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
	}
	cout	<<	endl;

	cout	<<	"Dynamic size array"	<<	endl;
	{
		int		*in;
		int		*out;
		int		inSize, outSize;
		int		iIndex;

		inSize	=	2;
		in	=	new int[inSize];
		for( iIndex = 0; iIndex < inSize; iIndex ++ )
			in[iIndex] = iIndex;
		
		hRet = srv.sample_dynamicSize_Array(in, inSize, &out, &outSize);
		printf("IN: [");
		for( iIndex = 0; iIndex < inSize; iIndex ++ )
			printf("%d ", in[iIndex]);
		printf("]\n");

		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;

			printf("OUT: [");
			for( iIndex = 0; iIndex < inSize; iIndex ++ )
				printf("%d ", in[iIndex]);
			printf("]\n");
			
			// MUST use AtlCleanupArray to clean the memory allocated by the marshaller to fill the array
			AtlCleanupArray(out, outSize);
			
			// MUST free, because AtlCleanupArray only 'cleans' the array (clears the array members), it does not free the array
			free(out);
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
		// clean the input array
		delete[]	in;
	}
	cout	<<	endl;


	cout	<<	"Struct array"	<<	endl;
	{
		stComplex		*in;
		stComplex		*out;
		int		inSize, outSize;
		int		iIndex;

		inSize	=	2;
		in	=	new stComplex[inSize];
		for( iIndex = 0; iIndex < inSize; iIndex ++ )
		{
			in[iIndex].iID = iIndex;
			in[iIndex].bstrData	=	::SysAllocString(L"StructData");
		}
		
		hRet = srv.sample_structArray(in, inSize, &out, &outSize);
		printf("IN: [");
		for( iIndex = 0; iIndex < inSize; iIndex ++ )
			printf("{%d %ls} ", in[iIndex].iID, in[iIndex].bstrData);
		printf("]\n");

		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;

			printf("OUT: [");
			for( iIndex = 0; iIndex < inSize; iIndex ++ )
				printf("{%d %ls} ", in[iIndex].iID, in[iIndex].bstrData);
			printf("]\n");
			
			// MUST use AtlCleanupArray to clean the memory allocated by the marshaller to fill the array
			AtlCleanupArray(out, outSize);
			
			// MUST free, because AtlCleanupArray only 'cleans' the array (clears the array members), it does not free the array
			free(out);
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
		// clean the input array
		for( iIndex = 0; iIndex < inSize; iIndex ++ )
			::SysFreeString( in[iIndex].bstrData);
		// clean the input array
		delete[]	in;
	}
	cout	<<	endl;

	cout	<<	"Nested Struct"	<<	endl;
	{
		stNested	in, out;

		in.iExtValue	=	1;
		in.innerStruct.iID	=	1;
		in.innerStruct.bstrData	=	::SysAllocString(L"InnerStructField");

		hRet = srv.sample_NestedStruct(in, &out);
		printf("IN: {%d {%d %ls}}\n",in.iExtValue,  in.innerStruct.iID, in.innerStruct.bstrData);
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			printf("OUT: {%d {%d %ls}}\n",out.iExtValue,  out.innerStruct.iID, out.innerStruct.bstrData);
			// MUST use AtlCleanupValue to clean the memory allocated by the marshaller to fill the struct
			AtlCleanupValue(&out);
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
		::SysFreeString( in.innerStruct.bstrData);
	}
	cout	<<	endl;

/*
	[id(6)]		HRESULT sample_NestedArray([in]stEmbeddedArr inStruct, [out, retval]stEmbeddedArr* pOutStruct);
*/
	cout	<<	"Nested Array"	<<	endl;
	{
		stEmbeddedArr	in, out;
		int				iIndex;

		in.bstrVal	=	::SysAllocString(L"StructData");
		in.nCount	=	5;
		in.arValues	=	new int[ in.nCount ];
		for( iIndex = 0; iIndex < in.nCount; iIndex ++ )
			in.arValues[iIndex] = iIndex;

		hRet = srv.sample_NestedArray(in, &out);
		printf("IN: {%ls %d [",in.bstrVal, in.nCount);
		for( iIndex = 0; iIndex < in.nCount; iIndex ++ )
			printf("%d ", in.arValues[iIndex]);
		printf("]\n"); 
		if( SUCCEEDED(hRet) )
		{
			cout	<<	"Soap call  : PASSED!"	<<	endl;
			printf("OUT: {%ls %d [",out.bstrVal, out.nCount);
			for( iIndex = 0; iIndex < out.nCount; iIndex ++ )
				printf("%d ", out.arValues[iIndex]);
			printf("]\n"); 

			// MUST use AtlCleanupValue to clean the memory allocated by the marshaller to fill the struct
			AtlCleanupValue(&out);
		}
		else
		{
			cout	<<	"Soap call : FAILED! Error code : "	<<	srv.GetClientError() << endl;
		}
		delete[]	in.arValues;
		::SysFreeString( in.bstrVal );
	}
	cout	<<	endl;
}

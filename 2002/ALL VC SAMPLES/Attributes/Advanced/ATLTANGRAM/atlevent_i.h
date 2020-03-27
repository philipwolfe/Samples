///////////////////////////////////////////////////////////
//
// AtlEvent_i.idl - Interface description IAtlTangramModelEvent 
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once


/////////////////////////////////////////////////////////////
// IATLTangramModelEvent
// {4A6E83B0-B0F4-11d0-B69F-00A0C903487A}
[
	object,
	uuid(42143AD2-B9A1-4AA0-B6F9-C0986556E062),
	helpstring("ITangramModelEvent Interface"),
	pointer_default(unique)
]
__interface IATLTangramModelEvent: IUnknown
{
	HRESULT OnModelChange() ;
};


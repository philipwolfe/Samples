// D3D.cpp : Implementation of CDirect3D
//
// This is a part of the Active Template Library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Active Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Active Template Library product.

#include "stdafx.h"
#include "Direct3D.h"
#include "D3DAtl.h"

/////////////////////////////////////////////////////////////////////////////
// CDirect3D

STDMETHODIMP CDirect3D::InterfaceSupportsErrorInfo(REFIID riid)
{
	static const IID* arr[] =
	{
		&IID_IDirect3D,
	};

	for (int i=0; i < sizeof(arr)/sizeof(arr[0]); i++)
	{
		if (InlineIsEqualGUID(*arr[i],riid))
			return S_OK;
	}

	return S_FALSE;
}

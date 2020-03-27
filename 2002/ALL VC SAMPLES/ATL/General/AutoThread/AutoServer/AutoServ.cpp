// AutoServ.cpp : Implementation of CAutoServ
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
#include "AutoServer.h"
#include "AutoServ.h"

/////////////////////////////////////////////////////////////////////////////
// CAutoServ


STDMETHODIMP CAutoServ::Sleep(long delay)
{
	//put this thread to sleep for a bit.
	::Sleep(delay);
	return S_OK;
}

// LabObj.cpp : Implementation of CLabradorApp and DLL registration.
//
// This is a part of the ActiveX Template Library.
// Copyright (C) 1996 Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// ActiveX Template Library Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// ActiveX Template Library product.

#include "prelab.h"
#include "Labrador.h"
#include "LabObj.h"
#include <wchar.h>


/////////////////////////////////////////////////////////////////////////////
//  CLabrador Interface Implementation

CLabrador::CLabrador()
{
    wcscpy(m_szPetName, L"Fido");
    wcscpy(m_szSpeciesName, L"Warthog");
    m_bIsAlive = TRUE;
    m_bIsBarking = FALSE;
}

/////////////////////////////////////////////////////////////////////////////
//  IDog Implementation

STDMETHODIMP CLabrador::GetPetName(MY_BSTR pStr)
{
    if (pStr)
        wcscpy(pStr, m_szPetName);
    return (HRESULT)NOERROR;
}

STDMETHODIMP CLabrador::SetPetName(MY_BSTR pStr)
{
    if (pStr)
    {
        wcscpy(m_szPetName, pStr);
        return S_OK;
    }
    return E_POINTER;
}

STDMETHODIMP CLabrador::IsBarking(BOOL* pBool)
{
    if (pBool)
    {
        *pBool = m_bIsBarking;
        return S_OK;
    }
    return E_POINTER;
}

/////////////////////////////////////////////////////////////////////////////
//  IMammal Implementation

STDMETHODIMP CLabrador::GetSpeciesName(MY_BSTR pStr)
{
    if (pStr != NULL)
        wcscpy(pStr, m_szSpeciesName);
    return (HRESULT)NOERROR;
}

STDMETHODIMP CLabrador::IsAlive(BOOL* pBool)
{
    if (pBool)
    {
        *pBool = m_bIsAlive;
        return S_OK;
    }
    return E_POINTER;
}

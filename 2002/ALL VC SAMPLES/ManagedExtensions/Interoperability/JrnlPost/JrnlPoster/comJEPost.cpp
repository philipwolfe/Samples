//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//
// comJEPost.cpp : Implementation of CcomJEPost
//
// Contains the implementation of the CcomJEPost class.  This class is our wrapper 
// that allows COM clients to access our native business logic, which is accessed here
// via the pointer member pJEPost.

#include "stdafx.h"
#include "comJEPost.h"


// CcomJEPost
CcomJEPost::CcomJEPost()
{
	pJEPost = new JE::JEPost();
}

CcomJEPost::~CcomJEPost() {
	delete pJEPost;
}

STDMETHODIMP CcomJEPost::OpenTransaction(BSTR GLDescr)
{
	pJEPost->OpenTransaction(GLDescr);
	return S_OK;
}

STDMETHODIMP CcomJEPost::AddEntry(BSTR GLAccount, float nAmount)
{
	if (pJEPost->AddEntry(GLAccount, nAmount))
		return S_OK;
	else
		return E_FAIL;
}

STDMETHODIMP CcomJEPost::Verify(void)
{
	if (pJEPost->Verify())
		return S_OK;
	else
		return E_FAIL;
}

STDMETHODIMP CcomJEPost::Commit(void)
{
	if (pJEPost->Commit())
		return S_OK;
	else
		return E_FAIL;
}

STDMETHODIMP CcomJEPost::Abort(void)
{
	pJEPost->Abort();
	return S_OK;
}

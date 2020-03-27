//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//
// comJEPost.h
//
// Contains the declaration of the CcomJEPost class.  This class is our wrapper 
// that allows COM clients to access our native business logic.


#pragma once
#include "resource.h"       // main symbols
#include "JEPost.h"

// IcomJEPost
[
	object,
	uuid("FA81C300-6943-405D-A378-4FF5600078EC"),
	dual,	helpstring("IcomJEPost Interface"),
	pointer_default(unique)
]
__interface IcomJEPost : IDispatch
{

	[id(1), helpstring("method OpenTransaction")] HRESULT OpenTransaction([in] BSTR GLDescr);

	[id(2), helpstring("method AddEntry")] HRESULT AddEntry([in] BSTR GLAccount, [in] float nAmount);

	[id(3), helpstring("method Verify")] HRESULT Verify(void);

	[id(4), helpstring("method Commit")] HRESULT Commit(void);

	[id(5), helpstring("method Abort")] HRESULT Abort(void);
};



// CcomJEPost

[
	coclass,
	threading("apartment"),
	vi_progid("JrnlPoster.comJEPost"),
	progid("JrnlPoster.comJEPost.1"),
	version(1.0),
	uuid("14D9692C-E3FD-4751-BB55-8DE6E07E8D64"),
	helpstring("comJEPost Class")
]
class ATL_NO_VTABLE CcomJEPost : 
	public IcomJEPost
{
private:
	JE::JEPost* pJEPost;	// pointer to our native business logic class.
public:
	CcomJEPost();
	~CcomJEPost();

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}
	
	void FinalRelease() 
	{
	}

public:

	STDMETHOD(OpenTransaction)(BSTR GLDescr);
	STDMETHOD(AddEntry)(BSTR bstrGLAccount, float nAmount);
	STDMETHOD(Verify)(void);
	STDMETHOD(Commit)(void);
	STDMETHOD(Abort)(void);
};


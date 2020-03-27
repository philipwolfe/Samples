// Subtracter.h : Declaration of the CSubtracter

#pragma once
#include "resource.h"       // main symbols



// CSubtracter

class ATL_NO_VTABLE CSubtracter : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CSubtracter, &CLSID_Subtracter>,
	public IDispatchImpl<ISubtracter, &IID_ISubtracter, &LIBID_MathLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CSubtracter()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_SUBTRACTER)


BEGIN_COM_MAP(CSubtracter)
	COM_INTERFACE_ENTRY(ISubtracter)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}
	
	void FinalRelease() 
	{
	}

public:

	STDMETHOD(Subtract)(long lMinuend, long lSubtrahend, long* plResidual);
};

OBJECT_ENTRY_AUTO(__uuidof(Subtracter), CSubtracter)

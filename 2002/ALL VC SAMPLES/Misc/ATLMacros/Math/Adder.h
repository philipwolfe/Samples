// Adder.h : Declaration of the CAdder

#pragma once
#include "resource.h"       // main symbols



// CAdder

class ATL_NO_VTABLE CAdder : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CAdder, &CLSID_Adder>,
	public IDispatchImpl<IAdder, &IID_IAdder, &LIBID_MathLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CAdder()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_ADDER)


BEGIN_COM_MAP(CAdder)
	COM_INTERFACE_ENTRY(IAdder)
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

	STDMETHOD(Add)(short sAddend1, short sAddend2, long* plSum);
};

OBJECT_ENTRY_AUTO(__uuidof(Adder), CAdder)

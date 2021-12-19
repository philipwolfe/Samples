// Connect.h : Declaration of the CConnect

#pragma once
#include "resource.h" 			// main symbols

/////////////////////////////////////////////////////////////////////////////
// CConnect


class ATL_NO_VTABLE CConnect : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CConnect, &CLSID_$SAFEOBJNAME$>,
//BEGIN NOT VSOnly
	public IDispatchImpl<IDTExtensibility2, &IID_IDTExtensibility2, &LIBID_EnvDTE, 7, 0>	//TODO: Change this from LIBID_EnvDTE to the LIBID for msaddndr
//END NOT VSOnly
//BEGIN VSOnly
//BEGIN VSCommand
	public IDispatchImpl<IDTCommandTarget, &IID_IDTCommandTarget, &LIBID_EnvDTE, 7, 0>,
//END VSCommand
	public IDispatchImpl<IDTExtensibility2, &IID_IDTExtensibility2, &LIBID_EnvDTE, 7, 0>
//END VSOnly
{
public:

	DECLARE_NO_REGISTRY()
//BEGIN NOT VSCommand
  BEGIN_COM_MAP(CConnect)
    COM_INTERFACE_ENTRY(IDispatch)
    COM_INTERFACE_ENTRY(IDTExtensibility2)
  END_COM_MAP()
//END NOT VSCommand
//BEGIN VSCommand
	HRESULT InternalQueryInterface(CConnect*, const _ATL_INTMAP_ENTRY*, REFIID iid, void** ppvObject)
	{
	    if(iid == IID_IUnknown)
	    {
	      InternalAddRef();
	      *ppvObject = GetUnknown();
	      return S_OK;
	    }
	    else if(iid == IID_IDispatch)
	    {
	      InternalAddRef();
	      *ppvObject = (void*)(IDispatch*)(IDTExtensibility2*)this; //Return the IDispatch offered from IDTExtensibility2
	      return S_OK;
	    }
	    else if(iid == IID_IDTCommandTarget)
	    {
	      InternalAddRef();
	      *ppvObject = (void*)(IDTCommandTarget*)this;
	      return S_OK;
	    }
	    else if(iid == IID_IDTExtensibility2)
	    {
	      InternalAddRef();
	      *ppvObject = (void*)(IDTExtensibility2*)this;
	      return S_OK;
	    }
	    else
	      return E_NOINTERFACE;
	}

BEGIN_COM_MAP(CConnect)
	COM_INTERFACE_ENTRY2(IDispatch, IDTExtensibility2)
	COM_INTERFACE_ENTRY(IDTCommandTarget)
END_COM_MAP()
//END VSCommand
	STDMETHOD(OnConnection)(IDispatch * Application, ext_ConnectMode ConnectMode, IDispatch *AddInInst, SAFEARRAY **custom); 
	STDMETHOD(OnDisconnection)(ext_DisconnectMode RemoveMode, SAFEARRAY **custom );
	STDMETHOD(OnAddInsUpdate)(SAFEARRAY **custom );
	STDMETHOD(OnStartupComplete)(SAFEARRAY **custom );
	STDMETHOD(OnBeginShutdown)(SAFEARRAY **custom );
//BEGIN VSCommand
	STDMETHOD(QueryStatus)(BSTR CmdName, vsCommandStatusTextWanted NeededText, vsCommandStatus *StatusOption, VARIANT *CommandText);		
	STDMETHOD(Exec)(BSTR CmdName, vsCommandExecOption ExecuteOption, VARIANT *VariantIn, VARIANT *VariantOut, VARIANT_BOOL *Handled);
//END VSCommand
//BEGIN VSOnly
private:
	CComQIPtr<_DTE> m_pDTE;
//END VSOnly
};


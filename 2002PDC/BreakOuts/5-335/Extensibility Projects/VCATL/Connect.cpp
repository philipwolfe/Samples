// Connect.cpp : Implementation of CConnect

#include "stdafx.h"
#include "AddIn_h.h"
#include "Connect.h"

/////////////////////////////////////////////////////////////////////////////
// CConnect

STDMETHODIMP CConnect::OnConnection(IDispatch *Application, ext_ConnectMode ConnectMode, IDispatch *AddInInst, SAFEARRAY ** /*custom*/ )
{
	//BEGIN VSOnly
	//BEGIN NOT VSCommand
	m_pDTE = Application;
	return S_OK;
	//END NOT VSCommand
	//BEGIN VSCommand
	HRESULT hr = S_OK;
	m_pDTE = Application;
	if(ConnectMode == ext_cm_UISetup)
	{
		HRESULT hr = S_OK;
		CComBSTR bstrCommandName(L"Connect");
		CComQIPtr<AddIn> pAddin(AddInInst);
		CComPtr<Commands> pCommands;
		CComPtr<_CommandBars> pCommandBars;
		CComPtr<CommandBarControl> pCommandBarControl;
		CComPtr<Command> pCreatedCommand;
		CComPtr<CommandBar> pMenuBarCommandBar;
		TCHAR szMenuName[50];
		TCHAR szMenuItemCaption[50];
		
		//By default, a button is created under the "Tools" menu item. However, if you wish to
		//	change this default, or if the target system is non-English (and you are not using a Satellite DLL), 
		//	you will need to change this. It can be changed by modifying the stringtable item IDS_MENUNAME to 
		//	the desired menu name.
		LoadString(_Module.GetResourceInstance(), IDS_MENUNAME, szMenuName, sizeof(szMenuName));
		LoadString(_Module.GetResourceInstance(), IDS_MENUCAPTION, szMenuItemCaption, sizeof(szMenuItemCaption));
		
		//Add a named command...
		IfFailGo(m_pDTE->get_Commands(&pCommands));
		if(SUCCEEDED(pCommands->AddNamedCommand(pAddin, bstrCommandName, bstrCommandName, bstrCommandName, VARIANT_TRUE, 12, NULL, vsCommandDisabledFlagsEnabled, &pCreatedCommand)))
		{
			//Add a button to the tools menu bar.
			IfFailGo(m_pDTE->get_CommandBars(&pCommandBars));
			IfFailGo(pCommandBars->get_Item(CComVariant(szMenuName), &pMenuBarCommandBar));
			IfFailGo(pCreatedCommand->AddControl(pMenuBarCommandBar, 1, &pCommandBarControl));
		}
		return S_OK;
	}
Error:
	return hr;
	//END VSCommand
	//END VSOnly
}

STDMETHODIMP CConnect::OnDisconnection(ext_DisconnectMode /*RemoveMode*/, SAFEARRAY ** /*custom*/ )
{
	return S_OK;
}

STDMETHODIMP CConnect::OnAddInsUpdate (SAFEARRAY ** /*custom*/ )
{
	return S_OK;
}

STDMETHODIMP CConnect::OnStartupComplete (SAFEARRAY ** /*custom*/ )
{
	return S_OK;
}

STDMETHODIMP CConnect::OnBeginShutdown (SAFEARRAY ** /*custom*/ )
{
	return S_OK;
}
//BEGIN VSCommand
STDMETHODIMP CConnect::QueryStatus(BSTR CmdName, vsCommandStatusTextWanted NeededText, vsCommandStatus *StatusOption, VARIANT *CommandText)
{
	*StatusOption = (vsCommandStatus)(vsCommandStatusEnabled+vsCommandStatusSupported);
	return S_OK;
}

STDMETHODIMP CConnect::Exec(BSTR CmdName, vsCommandExecOption ExecuteOption, VARIANT *VariantIn, VARIANT *VariantOut, VARIANT_BOOL *Handled)
{
	return S_OK;
}
//END VSCommand
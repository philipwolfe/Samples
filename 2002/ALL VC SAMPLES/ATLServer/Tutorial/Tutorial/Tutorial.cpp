// tutorial.cpp : Defines the entry point for the DLL application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "tutorial.h"
#include "Helpers.h"

// For custom assert and trace handling with WebDbg.exe
#ifdef _DEBUG
CDebugReportHook g_ReportHook;
#endif

#include "tutorial.h"
[ module(name = "tutorial", type = "dll") ]
class CDllMainOverride
{
public:
	BOOL WINAPI DllMain(DWORD dwReason, LPVOID lpReserved)
	{
#if defined(_M_IX86)
		if (dwReason == DLL_PROCESS_ATTACH)
		{
			// stack overflow handler
			_set_security_error_handler( AtlsSecErrHandlerFunc );
		}
#endif
		return __super::DllMain(dwReason, lpReserved);
	}
};

[ emitidl(restricted) ];


          
HTTP_CODE CTutorialHandler::ValidateAndExchange()
{
	using VCUE::OpenCommandRowset;
	using VCUE::SendError;
	using VCUE::GetSession;
	using VCUE::GetLoginId;
	using VCUE::ItemIsPresent;

	// Set the content-type of the response.
	m_HttpResponse.SetContentType("text/html");

	// Get the session ID of the current user.
	LPCSTR szSessionId = GetLoginId(m_HttpRequest);
	if (!szSessionId)
	{
		// User doesn't have valid cookie, redirect to login page.
		m_HttpResponse.Redirect("login.srf");
		return HTTP_SUCCESS_NO_PROCESS;
	}

	// Get the session corresponding to this ID.
	HRESULT hr = GetSession(m_spServiceProvider, szSessionId, &m_spSession);
	if (FAILED(hr))
	{
		return SendError(m_HttpResponse, "An error occurred while obtaining the session object.");
	}

	// Get our form data
	const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();
	if (FormFields.GetCount())
	{
		hr = E_UNEXPECTED;

		if (ItemIsPresent(FormFields, "AddToCart"))
			hr = AddToCart();		
	}
	
	// Start to get the product information from the database.
	hr = OpenCommandRowset(m_spServiceProvider, m_cmdGetStock);
	if (FAILED(hr))
	{
		return SendError(m_HttpResponse, "An error occurred accessing the database.");
	}

    return HTTP_SUCCESS;
}

HTTP_CODE CTutorialHandler::OnGetNextProduct()
{
	using VCUE::SendError;

	// Move to the next row in the result set.
	HRESULT hr = m_cmdGetStock.MoveNext();
	
	if (FAILED(hr) || (!m_cmdGetStock.AllMembersOk()))
	{	
		return SendError(m_HttpResponse, "An error occurred while accessing the database.");
	}

	// HTTP_SUCCESS continues the loop
	// HTTP_S_FALSE terminates the loop
	return (hr == S_OK) ? HTTP_SUCCESS : HTTP_S_FALSE;
}

HTTP_CODE CTutorialHandler::OnProductName()
{
	// The product name was retrieved from the database by a prior call to OnGetNextProduct.
	m_HttpResponse << m_cmdGetStock.m_Name;
	return HTTP_SUCCESS;
}

HTTP_CODE CTutorialHandler::OnProductDescription()
{
	// The product description was retrieved from the database by a prior call to OnGetNextProduct.
	m_HttpResponse << m_cmdGetStock.m_Description;
	return HTTP_SUCCESS;
}

HTTP_CODE CTutorialHandler::OnProductPrice()
{
	// The product price was retrieved from the database by a prior call to OnGetNextProduct.
	m_HttpResponse << "$" << m_cmdGetStock.m_Price;
	return HTTP_SUCCESS;
}

HTTP_CODE CTutorialHandler::OnProductQuantity()
{
	// The quantity of the product in the user's shopping cart is retrieved from session state
	// using the product ID set by a prior call to OnGetNextProduct.

	long lQuantity = 0;

	// Check whether the session state contains a purchase request for this product.
	// The name of the session variable is the ID of the product.
	CStringA strProductId;
	strProductId.Format("%ld", m_cmdGetStock.m_Id);

	CComVariant varQuantity;
	HRESULT hr = m_spSession->GetVariable(strProductId, &varQuantity);
	if (S_OK == hr)
	{
		// Expect variables to be stored as long (VT_I4)
		if (V_VT(&varQuantity) == VT_I4)
			lQuantity = V_I4(&varQuantity);
	}

	m_HttpResponse << lQuantity;
	return HTTP_SUCCESS;
}

HTTP_CODE CTutorialHandler::OnProductId()
{
	// The product ID was retrieved from the database by a prior call to OnGetNextProduct.
	m_HttpResponse << m_cmdGetStock.m_Id;
	return HTTP_SUCCESS;
}

HRESULT CTutorialHandler::AddToCart()
{
	HRESULT hr = E_UNEXPECTED;
	const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();

	LPCSTR szQuantity = FormFields.Lookup("Quantity");
	LPCSTR szProductId = FormFields.Lookup("ProductId");

	if (szQuantity && szProductId)
	{
		// Build a regular expression for matching decimal integers
		CRegularExpression regularExpression;
		if (regularExpression.Parse("^\\d+$") == REPARSE_ERROR_OK)
		{
			// Both product ID and quantity should be decimal integers
			CMatchContext matchContext;
			if (regularExpression.Match(szProductId, &matchContext) && regularExpression.Match(szQuantity, &matchContext))
			{
				CComVariant varQuantity = szQuantity;
				// Ensure that quantities are stored as long (VT_I4) values.
				hr = varQuantity.ChangeType(VT_I4);
				if (SUCCEEDED(hr))
				{
					if (V_I4(&varQuantity))
					{
						// If quantity is not zero, set the session variable.
						hr = m_spSession->SetVariable(szProductId, varQuantity);
					}
					else
					{
						// If the quantity is zero, remove the variable from session state.
						m_spSession->RemoveVariable(szProductId);
					}
				}
			}
		}
	}

	return hr;
}
// File: Cart.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "StdAfx.h"
#include "Cart.h"
#include "Helpers.h"

void CCartHandler::Clear()
{
	// Clear raw data members.
	m_lTotalCost = 0;
	m_lQuantity = 0;
	m_hSession = NULL;
	m_posSession = NULL;
	m_szProductId[0] = '\0';
}

HTTP_CODE CCartHandler::ValidateAndExchange()
{
	using VCUE::OpenCommandRowset;
	using VCUE::SendError;
	using VCUE::GetSession;
	using VCUE::GetLoginId;

	// Initialize members.
	Clear();

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

	// Get the session.
	HRESULT hr = GetSession(m_spServiceProvider, szSessionId, &m_spSession);
	if (FAILED(hr))
	{
		return SendError(m_HttpResponse, "An error occurred while obtaining the session object.");
	}

	// Start to get the purchase information from session state.
	hr = m_spSession->BeginVariableEnum(&m_posSession, &m_hSession);
	if (FAILED(hr))
	{
		return SendError(m_HttpResponse, "An error occurred while preparing to enumerate session variables.");
	}

	// Build a regular expression for matching decimal integers
	if (m_reProductIdValidator.Parse("^\\d+$") != REPARSE_ERROR_OK)
	{
		return SendError(m_HttpResponse, "An error occurred while parsing a regular expression.");
	}

	// Start to get the product information from the database.
	hr = OpenCommandRowset(m_spServiceProvider, m_cmdGetStock);
	if (FAILED(hr))
	{
		return SendError(m_HttpResponse, "An error occurred accessing the database.");
	}

	return HTTP_SUCCESS;
}

HTTP_CODE CCartHandler::OnGetNextPurchase()
{
	using VCUE::SendError;

	// Iteration has finished if the POSITION is NULL.
	if (!m_posSession)
		return HTTP_S_FALSE;

	// Initialize data members.
	m_lQuantity = 0;
	m_szProductId[0] = 0;
	
	// Get the next variable from session state.
	CComVariant varQuantity;
	HRESULT hr = m_spSession->GetNextVariable(&m_posSession, &varQuantity, m_hSession, m_szProductId, sizeof(m_szProductId));
	
	while (S_OK == hr)
	{
		// Check the the variable name is a decimal integer using the regular expression
		// prepared earlier.
		CMatchContext matchContext;
		if (m_reProductIdValidator.Match(m_szProductId, &matchContext))	
		{
			// Check that the variable value is a variant of type long (VT_I4).
			if (VT_I4 == V_VT(&varQuantity))
			{
				// Save the quantity.
				m_lQuantity = V_I4(&varQuantity);
				
				// Save the product ID.
				long lProductId = atol(m_szProductId);

				// Move to start of products
				hr = m_cmdGetStock.MoveFirst();
				
				while ((S_OK == hr) && m_cmdGetStock.AllMembersOk())
				{
					// Check whether the current products match.
					if (m_cmdGetStock.m_Id == lProductId)
					{
						// Found the product. Increase the total cost of the purchases.
						m_lTotalCost += m_cmdGetStock.m_Price * m_lQuantity;
						return HTTP_SUCCESS;
					}

					// Loop through remaining products until we find the product
					// or the end of the result set is reached.
					hr = m_cmdGetStock.MoveNext();
				}

				return SendError(m_HttpResponse, "An error occurred. Session variable does not correspond to product in the database.");
			}
		}

		// No more session variables.
		if (!m_posSession)
			return HTTP_S_FALSE;

		// The previous session variable wasn't a purchased item.
		// Get the next session variable and try again.
		varQuantity.Clear();
		hr = m_spSession->GetNextVariable(&m_posSession, &varQuantity, m_hSession, m_szProductId, sizeof(m_szProductId));
	}

	return HTTP_S_FALSE;
}

HTTP_CODE CCartHandler::OnProductPurchaseSummary()
{
	// Output the purchase summary of the current product.
	m_HttpResponse << m_lQuantity << " x " << m_cmdGetStock.m_Name << " at $" << m_cmdGetStock.m_Price;		
	return HTTP_SUCCESS;
}

HTTP_CODE CCartHandler::OnTotal()
{
	// Output the total cost.
	m_HttpResponse << "$" << m_lTotalCost;
	return HTTP_SUCCESS;
}
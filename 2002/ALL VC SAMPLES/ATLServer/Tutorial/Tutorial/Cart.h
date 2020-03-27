// File: Cart.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "Commands.h"

[ request_handler("Cart") ]
class CCartHandler
{
public:
	// Regular expression for validating product IDs retrieved from session state
	CRegularExpression m_reProductIdValidator;

	// The total cost of the items in the cart.
	long m_lTotalCost;

	// The quantity of the current item.
	long m_lQuantity;

	// The ID of the current item.
	char m_szProductId[MAX_VARIABLE_NAME_LENGTH];

	// The command object used to retrieve information about 
	// the products from the database. The members contain
	// information about the current product.
	CCommandGetStock m_cmdGetStock;

	// The session containing information about the current user.
	CComPtr<ISession> m_spSession;

	// The enumeration handle and current position of the purchase info
	HSESSIONENUM m_hSession;
	POSITION m_posSession;

	void Clear();

	HTTP_CODE ValidateAndExchange();

	[tag_name(name="GetNextPurchase")]
	HTTP_CODE OnGetNextPurchase();

	[tag_name(name="ProductPurchaseSummary")]
	HTTP_CODE OnProductPurchaseSummary();

	[tag_name(name="Total")]
	HTTP_CODE OnTotal();
};

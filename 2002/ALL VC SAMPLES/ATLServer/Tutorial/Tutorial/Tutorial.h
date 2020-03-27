// tutorial.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "Commands.h"

[ request_handler("Default") ]
class CTutorialHandler
{
public :
	// The command object used to retrieve information about 
	// the products from the database. The members contain
	// information about the current product.
	CCommandGetStock m_cmdGetStock;
	
	// The session containing information about the current user.
	CComPtr<ISession> m_spSession;

	HTTP_CODE ValidateAndExchange();

	HRESULT AddToCart();

	[tag_name(name="GetNextProduct")]
	HTTP_CODE OnGetNextProduct();

	[tag_name(name="ProductName")]
	HTTP_CODE OnProductName();

	[tag_name(name="ProductDescription")]
	HTTP_CODE OnProductDescription();

	[tag_name(name="ProductPrice")]
	HTTP_CODE OnProductPrice();

	[tag_name(name="ProductQuantity")]
	HTTP_CODE OnProductQuantity();

	[tag_name(name="ProductId")]
	HTTP_CODE OnProductId();

}; // class CTutorialHandler


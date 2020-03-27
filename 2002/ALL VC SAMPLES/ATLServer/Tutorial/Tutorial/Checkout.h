// File: Checkout.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "PerfService.h"

[ request_handler("Checkout") ]
class CCheckoutHandler
{
public:
	HTTP_CODE ValidateAndExchange();
	HRESULT CommitOrder(IServiceProvider* pServiceProvider, ISession* pSession, const CStringA& strUserName);
	HRESULT GetPerformanceService(ITutorialPerformanceService** ppService);
};
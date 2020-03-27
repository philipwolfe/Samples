// File: Login.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

[ request_handler("Login") ]
class CLoginHandler
{
public:
	// Keeps track of 
	CStringA m_strStatus;

	HTTP_CODE ValidateAndExchange();

	[tag_name(name="Status")]
	HTTP_CODE OnStatus();

	[tag_name(name="Debug")]
	HTTP_CODE OnDebug();
};

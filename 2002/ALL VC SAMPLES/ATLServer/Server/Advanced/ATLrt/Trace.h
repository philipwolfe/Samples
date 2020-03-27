// File: Trace.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "stdafx.h"

// Trace is a simple tracing class that we used during testing.
class Trace
{
public:
	Trace(void);
	virtual ~Trace(void);
	
	static void TraceMsg(LPCSTR msg)
	{
		#ifdef _DEBUG
			ATLTRACE(msg);
		#endif
	}
};

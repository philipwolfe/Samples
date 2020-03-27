// File: CmdResultsMap.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "stdafx.h"
#include "CmdResult.h"
#include "Trace.h"

// CmdResultsMap is a light wrapper around CAtlMap.  We use this class to store CmdResult
// objects by key.  The key used is the results attribute value specified in the {{Execute}}
// tag.
class CmdResultsMap : public CAtlMap<CStringA, CmdResult, CStringElementTraits<CStringA> >
{
public:
	CmdResultsMap();
	virtual ~CmdResultsMap();
	
	CmdResultsMap& operator=(const CmdResultsMap& c);	

	void Merge(CmdResultsMap& mapToMerge);
};

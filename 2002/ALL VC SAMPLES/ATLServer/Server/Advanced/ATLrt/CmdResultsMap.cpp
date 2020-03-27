// File: CmdResultsMap.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include "CmdResultsMap.h"

CmdResultsMap::CmdResultsMap() : CAtlMap<CStringA, CmdResult, CStringElementTraits<CStringA> >()
{
	Trace::TraceMsg("CmdResultsMap constructor");
}

CmdResultsMap::~CmdResultsMap()
{
	Trace::TraceMsg("CmdResultsMap destructor");
	RemoveAll();
}

CmdResultsMap& CmdResultsMap::operator=(const CmdResultsMap& c)
{
	Trace::TraceMsg("CmdResultsMap = operator");
	
	RemoveAll();
	POSITION begin = c.GetStartPosition();
	int num = c.GetCount();
	
	for (int i = 0; i < num; i++)
	{
		const CmdResultsMap::CPair *pair = c.GetNext(begin);			
		SetAt(pair->m_key, pair->m_value);
	}
	
	return (*this);
}

void CmdResultsMap::Merge(CmdResultsMap& mapToMerge)
{
	// get all keys to merge
	POSITION mergeKeyBegin = mapToMerge.GetStartPosition();
	CPair *mergeNode = NULL;
	
	while (mergeKeyBegin)
	{
		mergeNode = mapToMerge.GetNext(mergeKeyBegin);
		
		// override or add the new key name and value
		this->SetAt(mergeNode->m_key, mergeNode->m_value);
	}
}
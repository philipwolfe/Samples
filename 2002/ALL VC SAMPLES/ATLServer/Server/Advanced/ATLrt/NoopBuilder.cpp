// File: NoopBuilder.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "StdAfx.h"
#include "noopbuilder.h"

NoopBuilder::NoopBuilder(void)
{}

NoopBuilder::~NoopBuilder(void)
{}

void NoopBuilder::AddColumnValue(CStringA& value)
{}

void NoopBuilder::SetReturnValue(CStringA& value)
{}

void NoopBuilder::AddOutputParamValue(CStringA& value)
{}

void NoopBuilder::DoneRow()
{}

void NoopBuilder::DoneResultSet()
{}

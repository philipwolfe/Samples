//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//
// netJEPost.h
//
// This is the managed wrapper that will allow managed clients to access our
// business logic without incuring the performance penalty of a COM/COM+ interop
// transition.

#include "JEPost.h"
#using <mscorlib.dll>
using namespace System;

// netJEPost is the Managed class that managed clients will access.
public __gc class netJEPost {
private:
	JE::JEPost* pJEpost;	// pointer to unmanaged business logic class.
public:
	BOOL OpenTransaction(String* strDescr);
	BOOL AddEntry(String* strGLAccount, float fAmt);
	BOOL Verify();
	BOOL Commit();
	void Abort();
	netJEPost();
	~netJEPost();
};
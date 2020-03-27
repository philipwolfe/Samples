///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Description: Unspecified exception's handling in .NET
//
///////////////////////////////////////////////////////////////////////////////

#using<mscorlib.dll>
using namespace System;

void func() {
	throw; // throws unspecified exception
}

int main(void) {
	try {
		func();
	} catch(Exception* e) { // ... can be used instead if no info about the exception is needed.
		Console::WriteLine(e->ToString());
	}
	return 0;
}

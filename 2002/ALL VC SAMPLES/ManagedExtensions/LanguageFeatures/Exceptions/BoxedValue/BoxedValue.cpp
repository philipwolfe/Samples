///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Description: Throw/catch a boxed value type.
//
///////////////////////////////////////////////////////////////////////////////

#using <mscorlib.dll>
using namespace System;

__value struct V {
	int m_i;
	String* m_str;
};

void func() {
	V v;
	v.m_i  = 1;
	v.m_str = S"boxed value type";
	throw (__box(v));
}

int main() {
	try {
		func();
	}
	catch ( __box V *pbV) {
		Console::Write(S"Caught a {0}:", pbV->m_str);
		Console::WriteLine(pbV->m_i);
	}

	return 0;
}

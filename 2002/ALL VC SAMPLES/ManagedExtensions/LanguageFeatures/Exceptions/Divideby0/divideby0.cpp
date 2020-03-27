///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Description: Shows how .NET throws an exception when trying to divide to zero.
//
///////////////////////////////////////////////////////////////////////////////

#using <mscorlib.dll>

int main() {
	try {
		int j = 0;
		int i = 1/j;
	}
	catch (System::Exception* e) {
		System::Console::Write(S"Caught exception: ");
		System::Console::WriteLine(e->ToString());
	}
	return 0;
}

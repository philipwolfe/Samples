// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"

#using <mscorlib.dll>

using namespace System;

// Import our C# class
#using "../bin/MyCSClass.dll"
using namespace MyCSClass;

// Import our VB class
#using "../bin/MyVBClass.dll"
using namespace MyVBClass;

__gc class CPPClass : public MyCSClass::CSClass
{
public:
	virtual int MyVirtualMethod(int n)
	{
		return n*n*n;
	}
};

// This is the entry point for this application
#ifdef _UNICODE
int wmain(void)
#else
int main(void)
#endif
{
	Console::WriteLine("Creating C# and VB components:\n");

	CSClass *cs = new CSClass();
	int result = cs->MyMethod("Hello World");
	Console::WriteLine("CSClass::MyMethod(""Hello World"") returned {0}",  result.ToString());

	VBClass *vb = new VBClass();
	vb->DisplayMessage(S"Hello from MC++");

	Console::WriteLine("\nCreating a C++ class derived from a C# component\n");

	CPPClass *cpp = new CPPClass();

	Console::WriteLine("Demonstrating the C# and C++ override of the same function\n");
	result = cs->MyVirtualMethod(2);
	Console::WriteLine("CSClass::MyMethod(2) returned {0}",  result.ToString());

	result = cpp->MyVirtualMethod(2);
	Console::WriteLine("CPPClass::MyMethod(2) returned {0}",  result.ToString());

	Console::WriteLine("\nDemonstrating the C++ derived class calling a base class function\n");
	result = cpp->MyMethod("Hello World");
	Console::WriteLine("CPPClass::MyMethod(""Hello World"") returned {0}",  result.ToString());



	Console::Write("Press Enter to continue");
	Console::ReadLine();
	return 0;
}
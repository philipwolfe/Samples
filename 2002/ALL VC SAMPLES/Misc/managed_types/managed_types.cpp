// This is the main project file for VC++ application project 
// generated using an Application Wizard.
//


#include <stdio.h>
#using <mscorlib.dll>

using namespace System;

__gc class MyClass
{
   public: 
       int ID;
};

// This is the entry point for this application
int main(void)
{
	// Construct Strings

	//String s = "This will not compile";
	String* s1 = new String("This is an ANSI string");
	String* s2 = "Another string";

	s1 = "This is an ANSI string";
	Console::WriteLine(s1);

	s1 = L"This is a UNICODE string";
	Console::WriteLine(s1);

	s1 = S"This is a .NET string";
	Console::WriteLine(s1);

	printf("This is a C++ string\n");
	//printf(S"This will not compile");


	// Test the equivalence of string pointers

	s1 = S"This is a .NET string";
	s2 = S"This is a .NET string";
	if (s1 == s2)
		printf("s1 == s2\n");
	else
		printf("s1 != s2\n");


	s1 = "This is a C++ literal string";
	s2 = "This is a C++ literal string";
	if (s1 == s2)
		printf("s1 == s2\n");
	else
		printf("s1 != s2\n");


	// Test our managed class
	Console::WriteLine("Creating a managed class");
	MyClass* mc = new MyClass;
	Console::WriteLine("mc->ID has been initialised to {0}", mc->ID.ToString());

	mc->ID = 5;
	Console::WriteLine("mc->ID is now {0}", mc->ID.ToString());


	// Test __pin 
	MyClass __pin* pMC = mc;
	printf("The pinned value of mc is %d\n", pMC->ID);


	Console::Write("\n\nPress Enter to continue");
	Console::ReadLine();
    return 0;
}
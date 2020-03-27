// This is the main project file for VC++ application project 
// generated using an Application Wizard.
//

#include "stdafx.h"

#using <mscorlib.dll>

using namespace System;

// Declare a new value type (will be allocated on the stack)
__value struct Complex
{
	double real;
	double imaginary;

	virtual String *ToString()
	{
		return String::Format("{0} + {1}i", real.ToString("N2"), 
			                           imaginary.ToString("N2"));
	}
};

// This is the entry point for this application
#ifdef _UNICODE
int wmain(void)
#else
int main(void)
#endif
{
	// declare and work with a value type
	Console::WriteLine("Demonstration of a value type declarion and creation\n");

	Complex z;
	Console::WriteLine("z is initialized to {0}", z.ToString());

	z.real = 1.0;
	z.imaginary = -3.1415;

	Console::WriteLine("z is now {0}", z.ToString());

	// Boxing demonstration
	Console::WriteLine("\nDemonstration of boxing\n");
	Object* obj = __box(z.real);
	Console::WriteLine("The boxed value of z.real is {0}", obj);

	// Accessing data fields of a boxed structure
	Console::WriteLine("\nDemonstration accessing data fields in a boxed type\n");
	__box Complex* pZ = __box(z);
	pZ->real = 4;
	Console::WriteLine("The boxed value of pZ->real is {0}", pZ->real.ToString());

	// Unboxing demonstration
	Console::WriteLine("\nDemonstration of unboxing\n");
	Complex w = * dynamic_cast<Complex*>(pZ);
	Console::WriteLine("The unboxed value of w.real is {0}", w.real.ToString());


	Console::Write("Press Enter to continue");
	Console::ReadLine();

	return 0;
}
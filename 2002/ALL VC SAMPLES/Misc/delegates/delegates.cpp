// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"

#using <mscorlib.dll>

using namespace System;

// Declare a delegate
__delegate int MyDelegate(String *str);

// Create a simple managed reference class
__gc class MyClass 
{
public:
    int MethodA(String *str) 
	{
		Console::WriteLine(S"MyClass::MethodA - The value of str is: {0}", str);
		return str->Length;
    }

    int MethodB(String* str) 
	{
		Console::WriteLine(S"MyClass::MethodB - The value of str is: {0}", str);
		return str->Length * 2;
    }
};

// This is the entry point for this application
#ifdef _UNICODE
int wmain(void)
#else
int main(void)
#endif
{
	Console::WriteLine("Demonstration of a single cast delegate\n");

	// Create an instance of our guinea pig class
	MyClass *pMC = new MyClass();

	// Create a delegate that will call methods of our class using the
	// object created above
	MyDelegate *pDelegate = new MyDelegate(pMC, &MyClass::MethodA);

	// Invoke the class' method using the delegate - this will work perfectly
	pDelegate->Invoke("Invoking MethodA");

	// Create another delegate and test
	MyDelegate *pDelegate2 = new MyDelegate(pMC, &MyClass::MethodB);
	pDelegate2->Invoke("Invoking MethodB");

	Console::WriteLine("\nDemonstration of a multi cast delegate\n");

	// Combine the two delegates into a single multi-cast delegate
	MyDelegate *pMultiDelegate = static_cast<MyDelegate *>(Delegate::Combine(pDelegate, pDelegate2));
	pMultiDelegate->Invoke("Invoking Multicast delegate");

	Console::WriteLine("\nDemonstration of type safety\n");

	// The code below will not compile, since MethodA requires a String*
	//pDelegate->Invoke(42);

	// This will not compile, since MethodA returns an int
	//String *s = pDelegate->Invoke("Invoking MethodA");

	// Now test the return results of delegates for type safety
	int nResult = pDelegate->Invoke("Invoking single case delegate");
	Console::WriteLine("pDelegate->Invoke returned {0}\n", nResult.ToString());

	nResult = pMultiDelegate->Invoke("Invoking multicast delegate");
	Console::WriteLine("pMultiDelegate->Invoke returned {0}\n", nResult.ToString());

	Console::Write("\n\nPress Enter to continue");
	Console::ReadLine();

	return 0;
}
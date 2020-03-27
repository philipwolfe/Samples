///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2001.  All rights reserved.
//
//  Run: cl /clr UsingMCppGCRoot.cpp
//
//  Description: Shows how to embed a __gc pointer in an unmanaged class
//
///////////////////////////////////////////////////////////////////////////////

// unmanaged include
#include <iostream>
using std::cout;
using std::endl;

// managed include
#include "vcclr.h"

// managed imports
#using <mscorlib.dll>
using namespace System;
using namespace System::Runtime::InteropServices;

// unmanaged C++ class
class CSimple
{
public:
	CSimple(char *);
	char * GetStr(void);
	void SetStr(char *);
private:
	// use of the gcroot template allows us to embed a __gc
	// pointer in an unmanaged class
	gcroot<String*> m_str;
};

CSimple::CSimple(char * str)
{
	m_str = new String(str);
}

char * CSimple::GetStr(void)
{
	char * pStr = 0;

	try
	{
		// copies the contents of m_str into the Windows global heap,
		// converting to ANSI format on-the-fly. It allocates
		// the required native heap memory
		pStr = static_cast<char*>(Marshal::StringToHGlobalAnsi(m_str).ToPointer());
	}
	// m_str is null
	catch (ArgumentException* e)
	{
		Console::WriteLine(e->ToString());
	}
	// could not allocate enough memory on native heap
	catch (OutOfMemoryException* e)
	{
		Console::WriteLine(e->ToString());
	}

	return pStr;
}

void CSimple::SetStr(char * str)
{
	m_str = new String(str);
}

int main(void)
{
	CSimple simple("Hello, World!");

	char * pStr = simple.GetStr();

	cout << pStr << endl;

	// deallocate memory from Windows global heap for the string
	Marshal::FreeHGlobal(pStr);
	pStr = 0;

	simple.SetStr("... and farewell.");
	
	pStr = simple.GetStr();

	cout << pStr << endl;

	// deallocate memory from Windows global heap for the string
	Marshal::FreeHGlobal(pStr);
	pStr = 0;

}

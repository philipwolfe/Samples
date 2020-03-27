#using <mscorlib.dll>
using namespace System;

#include <iostream>
using std::cout; using std::endl;

#include "substring.h"

public __gc class substring_w
{
public:
	String * find_suffix(String * s, int pos)
	{
		int length = s->Length;
		char * in_string = new char[length+1];
		for(unsigned short i = 0; i<length; i++)
		{
			in_string[i] = (char)s->Chars[i];
		}
		in_string[length] = '\0';
		substring s0 = substring(in_string);
		delete [] in_string;
		return s0.suffix(pos);
}
	
};


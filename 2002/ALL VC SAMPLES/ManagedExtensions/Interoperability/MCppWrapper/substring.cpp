// substring.cpp : Defines the entry point for the DLL application.
//
#include <windows.h>
#include "stdafx.h"

#pragma warning( disable : 4091 )
BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 )
{
    return TRUE;
}
 __declspec(dllexport) 
	class substring
{
public:
	__declspec(dllexport) substring();
	__declspec(dllexport) substring(const char * const);
	__declspec(dllexport) ~substring();

	__declspec(dllexport) const char * getstring() const {return str;}
	__declspec(dllexport) char * suffix(int n);
private:
	char * str;
	unsigned short len;
};

substring::substring()
{
	str = (char *)LocalAlloc(0, sizeof(char));
	str[0] = '\0';
	len = 0;
}

substring::substring(const char * const str0)
{
	len = (unsigned short)strlen(str0);
	str = (char *) LocalAlloc(0, sizeof(char)*(len+1));
	for(unsigned short i = 0; i < len; i++)
		str[i] = str0[i];
	str[i] = '\0';
}

char * substring::suffix(int pos)
{ 
	unsigned short suffix_length;
	pos--; 
	if (pos < 0) pos = 0;
	suffix_length = len - pos + 1;
	
	if (suffix_length > 0)
	{ 
		char * suff = new char[suffix_length];
		for(unsigned short i = pos; i < len+1; i++)
			suff[i - pos] = str[i];
		return suff;
	} else 
		return 0;
}

substring::~substring()
{
	LocalFree(str);
	len = 0;
}


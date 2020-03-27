// clstencil.cpp : Defines the entry point for the console application.
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "stdafx.h"
#include <stdio.h>

CComModule _Module;

void PrintUsage(LPCSTR lpszErrorText=NULL);
bool GetParameters(int argc, char *argv[], 
				   LPTSTR *ppszInputFile, 
				   LPTSTR *ppszOutputFile, 
				   LPTSTR *ppszQueryString,
				   LPTSTR *ppszFormInput, 
				   LPTSTR *ppszErrorLog,
				   LPTSTR *ppszContentType,
				   LPTSTR *ppszVerb,
				   LPBOOL pbNoLogo);

int main(int argc, char* argv[])
{
	LPTSTR szInputFile = NULL;
	LPTSTR szOutputFile = NULL;
	LPTSTR szQueryString = NULL;
	LPTSTR szFormInput = NULL;
	LPTSTR szErrorLog = NULL;
	LPTSTR szContentType = NULL;
	LPTSTR szVerb = NULL;
	BOOL bNoLogo = FALSE;
	
	if (argc < 3)
	{
		CStringA str;
		Emit(str, IDS_INVALID_ARGS);
		PrintUsage(str);
		return 1;
	}
	
	CoInitialize(NULL);

	if (!GetParameters(argc, argv, &szInputFile, &szOutputFile, &szQueryString, &szFormInput, &szErrorLog, &szContentType, &szVerb, &bNoLogo))
	{
		return 1;
	}

	CStringA strHeader;
	if (bNoLogo == FALSE)
	{
		Emit(strHeader, IDS_HEADER);
		printf((LPCSTR) strHeader);
	}

	_Module.Init(NULL, GetModuleHandle(NULL));

	CSProcExtension extension;
	if (!extension.Initialize())
	{
		CStringA str;
		Emit(str, IDS_INIT_FAILED);
		printf((LPCSTR) str);
		_Module.Term();
		return 1;
	}

	if (!extension.DispatchStencilCall(szInputFile, szOutputFile, szQueryString, szErrorLog, szFormInput, szContentType, szVerb))
		printf("%s\n", (LPCSTR) extension.m_strErr);

	extension.Uninitialize();
	_Module.Term();
	CoUninitialize();

	return 0;
}


void PrintUsage(LPCSTR lpszErrorText)
{
	CStringA strBuffer;
	if (lpszErrorText && *lpszErrorText)
	{
		Emit(strBuffer, IDS_ERROR, lpszErrorText);
		printf((LPCSTR) strBuffer);
	}

	Emit(strBuffer, IDS_USAGE);
	printf((LPCSTR) strBuffer);
}

bool GetParameters(int argc, char *argv[], 
				   LPTSTR *ppszInputFile, 
				   LPTSTR *ppszOutputFile, 
				   LPTSTR *ppszQueryString,
				   LPTSTR *ppszFormInput, 
				   LPTSTR *ppszErrorLog,
				   LPTSTR *ppszContentType,
				   LPTSTR *ppszVerb,
				   LPBOOL pbNoLogo)
{
	for (int i = 1; i < argc; i++)
	{
		if (i == (argc-1))
			return false;
		if (argv[i][0] != '-')
			return false;

		char ch = argv[i][1];
		switch (ch)
		{
			case 'n' : case 'N':
			{
				*pbNoLogo = TRUE;
				continue;
			}
			case 'i' : case 'I' :
			{
				*ppszInputFile = argv[++i];
				continue;
			}
			case 'o' : case 'O' :
			{
				*ppszOutputFile = argv[++i];
				continue;
			}
			case 'q' : case 'Q' :
			{
				*ppszQueryString = argv[++i];
				continue;
			}
			case 'f' : case 'F':
			{
				*ppszFormInput = argv[++i];
				continue;
			}
			case 'e' : case 'E':
			{
				*ppszErrorLog = argv[++i];
				continue;
			}
			case 'c' : case 'C':
			{
				*ppszContentType = argv[++i];
				continue;
			}
			case 'v' : case 'V':
			{
				*ppszVerb = argv[++i];
				continue;
			}
			default:
			{
				CStringA str;
				Emit(str, IDS_UNKNOWN_PARAM, argv[i]);
				PrintUsage(str);
				return false;
			}
		}
	}

	if (*ppszInputFile == NULL)
	{
		CStringA str;
		Emit(str, IDS_INPUT_FILE);
		PrintUsage(str);
		return false;
	}

	// fix up the query quoted query string
	if (*ppszQueryString != NULL)
	{
		int n = (int) strlen(*ppszQueryString);
		(*ppszQueryString)[n] = 0;
	}

	// fix up the query quoted content-type string
	if (*ppszContentType != NULL)
	{
		int n = (int) strlen(*ppszContentType);
		(*ppszContentType)[n] = 0;
	}

	return true;
}
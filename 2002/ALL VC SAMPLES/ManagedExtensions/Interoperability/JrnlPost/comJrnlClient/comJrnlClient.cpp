//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//
// comJrnlClient.cpp
//
// Implements our COM client.


// #import imports declerations from the type library and allows us to access
// the coclass and its interface methods.

#ifdef _DEBUG
#import "..\JrnlPoster\debug\JrnlPoster.dll" no_namespace
#else
#import "..\JrnlPoster\release\JrnlPoster.dll" no_namespace
#endif

#include <stdio.h>
#include <TCHAR.h>

// A global structure for initializing COM. At startup, the constructor calls
// CoInitialize.  At shutdown, the descructor calls CoUninitialize.
struct StartUpCom {
    StartUpCom() { CoInitialize(NULL); }
    ~StartUpCom() { CoUninitialize(); }
} _global_com_inst;

// Dumps error information to the screen.
void dump_com_error(_com_error &e)
{
    _tprintf(_T("Oops - hit an error!\n"));
    _tprintf(_T("\a\tCode = %08lx\n"), e.Error());
    _tprintf(_T("\tCode meaning = %s\n"), e.ErrorMessage());
    _bstr_t bstrSource(e.Source());
    _bstr_t bstrDescription(e.Description());
    _tprintf(_T("\tSource = %s\n"), (LPCTSTR) bstrSource);
    _tprintf(_T("\tDescription = %s\n"), (LPCTSTR) bstrDescription);
}

// Entry point
void main() {
	try {
		// IcomJEPostPtr is a smart pointer created by the compiler when it read
		// in the type library for jrnlPoster.dll. For more information, take
		// a look at the Compiler COM Samples.
		IcomJEPostPtr pJEPost(L"JrnlPoster.comJEPost");	// Instantiate the COM object

		// Call the raw IcomJEPost interface methods.
		pJEPost->raw_OpenTransaction(L"JE pizza actuals adjustment");
		pJEPost->raw_AddEntry(L"111212", 98.50);
		pJEPost->raw_AddEntry(L"111213", -98.50);
		pJEPost->raw_Commit();
	}
	catch(_com_error& e) {
			dump_com_error(e);
	}

}


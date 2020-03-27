//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//
// netJEPost.cpp
//
// Contains the implementation of the managed wrapper class netJEPost. 
// netJEPost will be instantiated by managed clients and used to access 
// the business logic.
//

#include "stdafx.h"
#include "JEPost.h"
#include "netJEPost.h"

netJEPost::netJEPost() {
	pJEpost = new JE::JEPost;	// create an instance of our business logic class
}

netJEPost::~netJEPost() {
	if (pJEpost) {
		delete pJEpost; // delete this instance of our business logic class
	}
}

BOOL netJEPost::OpenTransaction(String* strDescr) {
	// Convert the managed string that comes from our COM+ clients to an unmanaged
	// a wchar_t that will be passed to our native class.
	System::IntPtr intptrDescr = 
		System::Runtime::InteropServices::Marshal::StringToHGlobalAuto(strDescr);

	// Call the OpenTransaction method on our instantiation of the native business 
	// logic class.
	BOOL bRet = pJEpost->OpenTransaction((wchar_t*) intptrDescr.ToPointer());
	
	// When we converted strDescr, memory was allocated by the StringToCoTaskMemAuto
	// function.  We now call FreeHGlobal to free the allocated memory.
	System::Runtime::InteropServices::Marshal::FreeHGlobal(intptrDescr);	// free up memory allocated by marshal
	return bRet;
}

BOOL netJEPost::AddEntry(String* strGLAccount, float fAmt) {
	// Convert the managed string that comes from our COM+ clients to an unmanaged
	// a wchar_t that will be passed to our native class.
	System::IntPtr intptrGLAccount = 
		System::Runtime::InteropServices::Marshal::StringToHGlobalAuto(strGLAccount);

	// Call the AddEntry method on our instantiation of the native business 
	// logic class.
	BOOL bRet = pJEpost->AddEntry((wchar_t*) intptrGLAccount.ToPointer(), fAmt);

	// When we converted strDescr, memory was allocated by the StringToCoTaskMemAuto
	// function.  We now call FreeHGlobal to free the allocated memory.
	System::Runtime::InteropServices::Marshal::FreeHGlobal(intptrGLAccount);
	return bRet;
}

BOOL netJEPost::Verify() {
	// Call the Verify method on our instantiation of the native business 
	// logic class.
	return pJEpost->Verify();
}

BOOL netJEPost::Commit() {
	// Call the Commit method on our instantiation of the native business 
	// logic class.
	return pJEpost->Commit();
}

void netJEPost::Abort() {
	// Call the Abort method on our instantiation of the native business 
	// logic class.
	pJEpost->Abort();
}

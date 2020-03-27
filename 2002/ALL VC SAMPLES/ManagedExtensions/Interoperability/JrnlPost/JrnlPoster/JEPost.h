//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//
// JEPost.h
//
// JEPost contains the class definition for our business logic class.
//
#pragma once
#include <windows.h>

namespace JE {
	const int MAXENTRIES = 200;	// maximum number of journal entries in one batch
	const int ACCOUNTSZ = 10;	// The size of an account number
	const int DESCRSZ = 50;		// The size of the description of an entry
	class JEPost {
	private:
		struct JE {				// Journal entry structure, account# and amount
			wchar_t wcszGLAccount[ACCOUNTSZ];
			float fAmount;
		};
		BOOL bTransactionIsOpen;	// is this transaction open?
		wchar_t wcszDescription[DESCRSZ];	// description of journal entry batch
		int nNumEntries;					// number of entries in this batch
		JE JournalEntries[MAXENTRIES];		// array to hold JEs
	public:
		JEPost();
		BOOL OpenTransaction(const wchar_t *wcszDescr);
		BOOL AddEntry(const wchar_t *wcszGLAccount, float fAmt);
		BOOL Verify();
		BOOL Commit();
		void Abort();
	};
}
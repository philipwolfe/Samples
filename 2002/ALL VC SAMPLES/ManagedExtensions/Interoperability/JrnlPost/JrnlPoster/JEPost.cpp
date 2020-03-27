//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//
// JEPost.cpp 
//
// Contains the implementation of our native business logic.
//

#include "stdafx.h"
#include <wchar.h>
#include <string.h>
#include "JEPost.h"
namespace JE {
	// ctor
	JEPost::JEPost() : nNumEntries(0), bTransactionIsOpen(FALSE) {
	}

	// validate description and open transaction
	BOOL JEPost::OpenTransaction(const wchar_t* wcszDescr) {
		if (!wcszDescr) {	// is this description null?
			::MessageBox(NULL, "Description must not be null!", "OpenTransaction Error", MB_OK);
			return FALSE;		// yes, early out
		}
		if ( (wcslen(wcszDescr) + 1) > DESCRSZ) {	// is the descr too long?
			::MessageBox(NULL, "Description string is too long!", "OpenTransaction Error", MB_OK);
			return FALSE;								// yes, early out
		}
		wcscpy(this->wcszDescription, wcszDescr);	// save the description
		this->bTransactionIsOpen = TRUE;			// flag transaction as open
		wchar_t wcszMsg[DESCRSZ + 30];				// format an informational message
		swprintf(wcszMsg, L"Transaction: \"%s\" is Open!", this->wcszDescription);
		::MessageBoxW(NULL, wcszMsg, L"OpenTransaction", MB_OK);
		return TRUE;
	}

	BOOL JEPost::AddEntry(const wchar_t *wcszGLAccount, float fAmt) {

		// is the account number too long?
		if ( (!wcszGLAccount) || ( (wcslen(wcszGLAccount) + 1) > ACCOUNTSZ) ) {
			::MessageBox(NULL, "Invalid GL Account number!", "AddEntry Error", MB_OK);
			return FALSE;		// yes, earlyout
		}
		if (this->bTransactionIsOpen == FALSE) {	// has the transaction been opened?
			::MessageBox(NULL, "Must open transaction first!", "AddEntry Error", MB_OK);
			return FALSE;								// no, early out
		}
		else {											// yes, add the entry
			wcscpy(JournalEntries[nNumEntries].wcszGLAccount, wcszGLAccount);
			JournalEntries[nNumEntries].fAmount = fAmt;
			nNumEntries++;
			return TRUE;
		}
	}

	BOOL JEPost::Verify() {
		if (this->bTransactionIsOpen == FALSE) {	// is this transaction open?
			::MessageBox(NULL, "Must open transaction first!", "Verify Error", MB_OK);
			return FALSE;								// no, early out
		}
		float fAccum = 0;								// clear the accumulator
		for (int i = 0; i < nNumEntries; i++) {		
			fAccum += JournalEntries[i].fAmount;	// sum all entries
		}

		if (fAccum != 0) {		// are we in balance?
			::MessageBox(NULL, "Journal Entry is out of balance!", "Verification Error", MB_OK);
			return FALSE;			// no, say so and early out
		}

		wchar_t wcszMsg[DESCRSZ + 30];	// format and output validation message
		swprintf(wcszMsg, L"Transaction: \"%s\" is validated!", this->wcszDescription);
		::MessageBoxW(NULL, wcszMsg, L"Validated", MB_OK);
		return TRUE;
	}

	BOOL JEPost::Commit() {
		if (this->bTransactionIsOpen == FALSE) {	// is this transaction open?
			::MessageBox(NULL, "Must open transaction first!", "Commit Error", MB_OK);
			return FALSE;								// no, early out
		}
		if ( Verify() ) {							// is this transaction in balance?
			wchar_t wcszMsg[DESCRSZ + 30];			//   yes, commit it.
			swprintf(wcszMsg, L"Transaction: \"%s\" Committed!", this->wcszDescription);
			::MessageBoxW(NULL, wcszMsg, L"Committed", MB_OK);
			this->bTransactionIsOpen=FALSE;
			return TRUE;
		}
		else {										//   no, abort transaction
			Abort();
			return FALSE;
		}
	}

	void JEPost::Abort() {
		::MessageBox(NULL, "Transaction Aborted!", "Commit", MB_OK);
		this->bTransactionIsOpen = FALSE;	// close the transaction
		nNumEntries = 0;					// reset number of entries to 0
	}
}
// ==============================================================================
// Filename: Account.h
//
// Summary:  managed cpp definition of the account class for the bank sample
// Classes:  Account.cpp
//
// This file is part of the Microsoft COM+ Samples
//
// Copyright (C) 1995-1999 Microsoft Corporation. All rights reserved
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information reagrding Microsoft code samples.
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//

namespace VC7Bank
{
	[
    	ComEmulateAttribute("VC7Bank.AccountOrig"), 
	    GuidAttribute("FB5E110D-F7DC-4c94-9DFF-61F79D91DD0D") //,
//        TransactionAttribute(TransactionOption::Required)
	]
    public __gc class Account
    {
    public:
		Account() {}
    };

    // Internal Class
	[
		ComVisibleAttribute(false)
	]
    public __gc	class AccountOrig : public IAccount
    {
    public:
		AccountOrig() {}

    public:
		String* Post (int lngAccountNo, int lngAmount);

    private:
			String* truePost (int lngAccountNo, int lngAmount);
	};
}
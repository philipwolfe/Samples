// ==============================================================================
// Filename: MoveMoney.h
//
// Summary:  managed cpp definition of the MoveMoney class for the bank sample
// Classes:  MoveMoney
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
        ComEmulate("VC7Bank.MoveMoneyOrig"),
        GuidAttribute("A1149302-66E5-4ee9-AACB-4EEAAC51EFB0")   //,
//        Transaction(TransactionOption.Required)
    ]
    public __gc class MoveMoney
    {
    public:
        MoveMoney() {};
    };

	[
		ComVisibleAttribute(false)
	]
    public __gc class MoveMoneyOrig : public IMoveMoney
    {
    public:
        MoveMoneyOrig() {};
	public:
        String* Perform (int lngPrimeAccount, int lngSecondAccount, int lngAmount, int tranType);

    private:
        String* truePerform (int lngPrimeAccount, int lngSecondAccount, int lngAmount, int tranType);
	};
}
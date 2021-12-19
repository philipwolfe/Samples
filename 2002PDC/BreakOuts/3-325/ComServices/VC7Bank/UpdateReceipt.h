// ==============================================================================
// Filename: UpdateReceipt.h
//
// Summary:  managed cpp definition of the UpdateReceipt class for the bank sample
// Classes:  UpdateReceipt.cs
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
        ComEmulate("VC7Bank.UpdateReceiptOrig"),
        GuidAttribute("6E407A60-17F3-4097-8805-E5BDDF3B77F1") //,
//        Transaction(TransactionOption.Required)
    ]
    public __gc	class UpdateReceipt
    {
	public:
        UpdateReceipt() { }
    };

	[
		ComVisibleAttribute(false)
	]
    public __gc class UpdateReceiptOrig : public IUpdateReceipt
    {
	public:
        int Update ();
	private:
		int trueUpdate();
    };
}
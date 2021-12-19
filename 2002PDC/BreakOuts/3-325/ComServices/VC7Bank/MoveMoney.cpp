// ==============================================================================
// Filename: MoveMoney.cs
//
// Summary:  C# implememtation of the MoveMoney class for the bank sample
// Classes:  MoveMoney.cs
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

// import mscorlib definitions
#using "mscorlib.dll"
using namespace System;
using namespace System::Runtime::InteropServices;

// import definitions for ComServices support
#using "Microsoft.ComServices.dll"
using namespace Microsoft::ComServices;

//import definitions for ADO
#using "adodb.dll"
using namespace ADODB;

// import definition for account typelibrary
#using "account.dll"
using namespace ACCOUNTCom;

#define null 0

#include "account.h"
#include "getreceipt.h"
#include "movemoney.h"

namespace VC7Bank
{

    String* MoveMoneyOrig::Perform (int lngPrimeAccount, int lngSecondAccount, int lngAmount, int tranType)
    {
        String* result;
        bool bSuccess = false;

        // First of all, get the object context
        try
        {
            // Check for security
            if ((lngAmount > 500 || lngAmount < -500) && !ContextUtil::IsCallerInRole ("Managers"))
                throw new COMException ("Need 'Managers' role for amounts over $500");

            // Call the true function
            result = truePerform (lngPrimeAccount, lngSecondAccount, lngAmount, tranType);

            bSuccess = true;
            return result;
        }

        // Upon exit, always call SetComplete if happy, or SetAbort if unhappy.
        // We do this because we never save state across method calls.
        __finally
        {
            if (bSuccess)
                ContextUtil::SetComplete();
            else
                ContextUtil::SetAbort();
        }
    }

    // F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
    //
    // Function: Perform
    //
    // TruePerform() is the function that performs the actual work for the Account class.
    // If an error occurs during execution, it will throw a COMException for Perform()
    // to handle.
    //
    // Args:     lngPrimeAccount -   "From" Account
    //           lngSecondAccount -  "To" Account
    //           lngAmount -         Amount of transaction
    //           lngTranType -       Transaction Type
    //                               (1 = Withdrawal,
    //                                2 = Deposit,
    //                                3 = Transfer)
    //
    // Returns:  String -        Account Balance
    //
    // F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---

    String* MoveMoneyOrig::truePerform (int lngPrimeAccount, int lngSecondAccount, int lngAmount, int tranType)
    {
        String* result;
        IAccount* objAccount = null;
        IGetReceipt* objReceipt = null;

        try
        {
            // Create the account object
            //objAccount = (IAccount) MyContext.GetContext().CreateInstance(clsid, iid);
            objAccount = dynamic_cast<IAccount __gc *>(new Account());
            switch (tranType)
            {
            case 1:     // debit
                result = objAccount->Post (lngPrimeAccount, (- lngAmount));
                break;

            case 2:     // credit
                result = objAccount->Post (lngPrimeAccount, lngAmount);
                break;

            case 3:     // transfer
                result = objAccount->Post (lngPrimeAccount, (- lngAmount));
				result = String::Concat(result,  S"    ", objAccount->Post (lngSecondAccount, lngAmount));
                break;

            default:
                throw new COMException ("Invalid transaction type");
            }

            // Get the receipt for the transaction
            //objReceipt = (IGetReceipt) ((IObjectContext)MyContext.GetContext()).CreateInstance(rclsid, riid);
            objReceipt = dynamic_cast<IGetReceipt __gc *>(new GetReceipt());
            int iReceiptNo = objReceipt->GetNextReceipt ();
            result = String::Concat(result,  S"; Receipt No:  ", Int32::ToString(iReceiptNo));
            return result;
        }

        __finally
        {
            // The following code is not strictly necessary. By calling ComLib.release here,
            // the object counts seen in the MTX explorer remain correct. Without these release
            // calls, the objects used here would not get released until after the next time
            // the runtime garbage collector runs. No other ill effect would be caused by omitting
            // this code.

            // Note that this code will be executed regardless of whether we leave this
            // method via return or via an exception.
//                if (objAccount != null) Marshal.ReleaseComObject (objAccount);
//                if (objReceipt != null) Marshal.ReleaseComObject (objReceipt);
        }
    }
}
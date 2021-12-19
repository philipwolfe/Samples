// ==============================================================================
// Filename: Account.cpp
//
// Summary:  managed cpp implememtation of the account class for the bank sample
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

// import mscorlib definitions
#using "mscorlib.dll"
using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Runtime::CompilerServices;

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

[assembly::AssemblyKeyFileAttribute("../common/testkey.snk")];


namespace VC7Bank
{

    String* AccountOrig::Post (int lngAccountNo, int lngAmount)
    {
        String* result;
        bool bSuccess = false;

        try
        {
            // Check for security
            if ((lngAmount > 500 || lngAmount < -500) && !ContextUtil::IsCallerInRole ("Managers"))
                throw new Exception ("Need 'Managers' role for amounts over $500");

            result = truePost (lngAccountNo, lngAmount);

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
    // Function: TruePost
    //
    // TruePost() is the function that performs the actual work for the Account class.
    // If an error occurs during execution, it will throw a ComFailException for Post() to
    // handle.
    //
    // Args:     lngAccountNo -    Account to be posted
    //           lngAmount -     Amount to be posted
    // Returns:  String -        Account Balance
    //
    // F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---

	String* AccountOrig::truePost (int lngAccountNo, int lngAmount)
    {
        _Recordset* adoRsBalance  = null;
        _Connection* adoConn = null;
        Field* pField = null;
        Fields* pFields = null;
        String* result;

        try
        {
            // Create ADOConnection object and initialize the connection

            adoConn = dynamic_cast<_Connection __gc *>(new __Connection());
            String* vDSN = "FILEDSN=BankSample";

			adoConn->Open (vDSN, null, null, (int)CommandTypeEnum::adCmdUnspecified);

            // Obtain the desired recordset with an SQL query
            Object*  vRowCount = new Object();
            String* strSQL = String::Concat(S"UPDATE Account SET Balance = Balance +",
											Int32::ToString(lngAmount),
											S"WHERE AccountNo =",
											Int32::ToString(lngAccountNo));

	TryAgain:
			try
			{
				adoConn->Execute (strSQL, &vRowCount, (int)ExecuteOptionEnum::adExecuteNoRecords);
			}
			catch(Exception*)
			{
				
//					ICreateTable* ct = dynamic_cast<ICreateTable __gc*>(new CreateTable());
//					ct->CreateAccount();
//					goto TryAgain;
			}

            // See whether the record is present.
            if ((Int32 __gc *)vRowCount == 0)
			{
				String* msg = String::Concat(S"%s %s %s", 
											 S"Error. Account", 
											 Int32::ToString(lngAccountNo), 
											 S"not on file.");
				throw new Exception(msg);
			}

            strSQL = String::Concat(S"SELECT Balance FROM Account WHERE AccountNo = ", 
									Int32::ToString(lngAccountNo));
            adoRsBalance = adoConn->Execute (strSQL, &vRowCount, - 1);

            // Get the appropriate fields
            pFields = adoRsBalance->Fields;
            pField = pFields->get_Item(S"Balance");
            int lngBalance  = reinterpret_cast<int>(dynamic_cast<Int32*>(pField->Value));

            // Check if account is overdrawn, then prepare return string
            if ((lngBalance) < 0)
			{
				String* msg = String::Concat(S"Error. Account", 
											 Int32::ToString(lngAccountNo), 
											 S"would be overdrawn by",
											 Int32::ToString((int)lngBalance), 
											 S". Balance is still ",
											 Int32::ToString((int)lngBalance - (int)lngAmount), 
											 S".");
				throw new Exception(msg);
			}
            if (lngAmount > 0)
                result = "Credit to";
            else
                result = "Debit from";

			String::Concat(result, 
						  S" account ", 
						  Int32::ToString(lngAccountNo),
						  S", balance is $",
						  Int32::ToString(lngBalance),
						  S".  (VC7)");
            return result;
        }
        __finally
        {
            // cleanup that needs to occur whether we leave via a return or an exception.
//                if (adoRsBalance != null)
//                {
//                    if (adoRsBalance->State == (int)ObjectStateEnum::adStateOpen)
//                        adoRsBalance->Close();

//					Marshal::ReleaseComObject(adoRsBalance);
//                }

//                if (adoConn != null)
//                {
//                    if (adoConn->State == (int)ObjectStateEnum::adStateOpen)
//                        adoConn->Close();

//					Marshal::ReleaseComObject(adoConn);
//                }
        }
    }
}
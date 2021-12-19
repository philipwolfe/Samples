// ==============================================================================
// Filename: UpdateReceipt.cpp
//
// Summary:  managed cpp implememtation of the UpdateReceipt class for the bank sample
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

namespace VC7Bank
{

    [
        ComEmulate("VC7Bank.UpdateReceiptOrig"),
        GuidAttribute("D4CBC7CE-3545-4e4b-BDBB-1120E3858648") //,
//        TransactionAttribute(TransactionOption.Required)
    ]
    public __gc
    class UpdateReceipt
    {
        public:
        UpdateReceipt()
        {
        }
    };

	[
		ComVisibleAttribute(false)
	]
    public __gc
    class UpdateReceiptOrig : public IUpdateReceipt
    {

        // F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
        //
        // Function: Update
        //
        // Update() performs error handling for TrueUpdate().  If TrueUpdate() throws an
        // exception, then Update() will call SetAbort() and pass the exception up
        // to the caller.  Otherwise, Update() will simply call SetComplete() and return.
        //
        // Args:     None
        // Returns:  Long -  next receipt value
        //            -1 if Error
        //
        // F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---

    public:
        int Update ()
        {

            int result;
            bool bSuccess = false;

            try
            {
                // Call the true function
                result = trueUpdate();
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
        // Function: trueUpdate
        //
        // trueUpdate() is the function that performs the actual work for the Account class.
        // If an error occurs during execution, it will throw a COMException for Update()
        // to handle.
        //
        // Args:     None
        // Returns:  Long -  next receipt value
        //            -1 if Error
        //
        // F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---

    private:
        int trueUpdate()
        {
            _Connection* adoConn = null;
            _Recordset* adoRsReceipt = null;
            Field* pField = null;
            Fields* pFields = null;

            try
            {
                // Create ADOConnection object and initialize the connection
                adoConn = dynamic_cast<_Connection __gc *>(new __Connection());
                String* vDSN = "FILEDSN=BankSample";
                adoConn->Open (vDSN, null, null, (int)CommandTypeEnum::adCmdUnspecified);

                // Obtain the desired recordset with an SQL query
                Object*  vAdoNull = new Object();
                String*  strSQL = "Update Receipt set NextReceipt = NextReceipt + 100";

		TryAgain:
				try
				{
                    adoConn->Execute (strSQL, &vAdoNull, (int)ExecuteOptionEnum::adExecuteNoRecords);
				}
				catch(Exception*)
				{
//					ICreateTable ct = (ICreateTable)new CreateTable();
//					ct.CreateReceipt();
//					goto TryAgain;
				}

                strSQL = "Select NextReceipt from Receipt";
                adoRsReceipt = adoConn->Execute (strSQL, &vAdoNull, - 1);

                // Get the appropriate fields
                pFields = adoRsReceipt->Fields;

                // Get the appropriate fields
                pFields = adoRsReceipt->Fields;
                pField = pFields->get_Item(new String("NextReceipt"));
                return reinterpret_cast<int>(dynamic_cast<Int32*>(pField->Value));
            }

            __finally
            {
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
    };
}
// ==============================================================================
// Filename: UpdateReceipt.cs
//
// Summary:  C# implememtation of the UpdateReceipt class for the bank sample
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


namespace CSharpBank
{
    using System;
    using System.Runtime.InteropServices;
    using ACCOUNTCom;
    using Microsoft.ComServices;
    using ADODB;

    [
     ComEmulate("CSharpBank.UpdateReceiptOrig"),
     Transaction(TransactionOption.Required),
     GuidAttribute("f914d0e3-1f5a-44a8-b838-28a825908d0a")
    ]
    public class UpdateReceipt
    {
        public UpdateReceipt()
        {
        }
    }

    internal class UpdateReceiptOrig : IUpdateReceipt
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

        public int Update ()
        {

            int result;
            bool bSuccess = false;

            // First of all, get the object context
            IObjectContext ctxObject = (IObjectContext)ContextUtil.ObjectContext;

            try
            {
                // Call the true function
                result = trueUpdate ();

                bSuccess = true;
                return result;
            }

            // Upon exit, always call SetComplete if happy, or SetAbort if unhappy.
            // We do this because we never save state across method calls.
            finally
            {
                if (ctxObject !=null)
                {
                    if (bSuccess)
                        ctxObject.SetComplete();
                    else
                        ctxObject.SetAbort();
                }
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

        private int trueUpdate ()
        {

            _Connection adoConn = null;
            _Recordset adoRsReceipt = null;
            Field pField = null;
            Fields pFields = null;

            try
            {
                // Create ADOConnection object and initialize the connection
                adoConn = (_Connection) new __Connection();
                String vDSN = "FILEDSN=BankSample";
                adoConn.Open (vDSN, null, null, (int)CommandTypeEnum.adCmdUnspecified);

                // Obtain the desired recordset with an SQL query
                Object  vAdoNull = new Object();

                String strSQL = "Update Receipt set NextReceipt = NextReceipt + 100";

		TryAgain:
				try
				{
					adoConn.Execute (strSQL, ref vAdoNull, (int)ExecuteOptionEnum.adExecuteNoRecords);
				}
				catch(Exception)
				{
					ICreateTable ct = (ICreateTable)new CreateTable();
					ct.CreateReceipt();
					goto TryAgain;
				}

                strSQL = "Select NextReceipt from Receipt";
                adoRsReceipt = adoConn.Execute (strSQL, ref vAdoNull, - 1);

                // Get the appropriate fields
                pFields = adoRsReceipt.Fields;

                // Get the appropriate field
                int lngNextReceipt;


                pField = pFields["NextReceipt"];
                lngNextReceipt = (int)pField.Value;

                return(int)lngNextReceipt;
            }

            finally
            {
                // cleanup that needs to occur whether we leave via a return or an exception.
                if (adoRsReceipt != null)
                {
                    if (adoRsReceipt.State == (int)ObjectStateEnum.adStateOpen)
                        adoRsReceipt.Close();
                    Marshal.ReleaseComObject(adoRsReceipt);
                }

                if (adoConn != null)
                {
                    if (adoConn.State == (int)ObjectStateEnum.adStateOpen)
                        adoConn.Close();
                    Marshal.ReleaseComObject (adoConn);
                }
            }
        }
    }
}
// ==============================================================================
// Filename: Account.cs
//
// Summary:  C# implememtation of the account class for the bank sample
// Classes:  Account.cs
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
    using Microsoft.ComServices;
    using System.Runtime.InteropServices;
    using ACCOUNTCom;
    using ADODB;

    [
	ComEmulate("CSharpBank.AccountOrig"), 
	GuidAttribute("B9E8F6DE-94EE-4aa9-B2E4-3B0B08585500"), 
	Transaction(TransactionOption.Required)
    ]
    public class Account
    {
        public Account()
        {
        }
    }

    // Internal Class
    internal class AccountOrig : IAccount
    {

        // F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
        //
        // Function: Post
        //
        // Post() performs error handling for TruePost().  If Truepost() throws an exception,
        // then Post() will call SetAbort() and pass the exception up to the caller.  Otherwise,
        // Post() will simply call SetComplete() and return.
        //
        // Args:     lngAccountNo -    Account to be posted
        //           lngAmount -     Amount to be posted
        // Returns:  String -        Account Balance
        //
        // F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---

        public String Post (int lngAccountNo, int lngAmount)
        {

            String result;
            bool bSuccess = false;


            // First of all, get the object context
            IObjectContext ctxObject = (IObjectContext)ContextUtil.ObjectContext;

            try
            {



                // Check for security
                if ((lngAmount > 500 || lngAmount < -500) && !ContextUtil.IsCallerInRole ("Managers"))
                    throw new Exception ("Need 'Managers' role for amounts over $500");

                result = truePost (lngAccountNo, lngAmount);

                bSuccess = true;
                return result;
            }

            // Upon exit, always call SetComplete if happy, or SetAbort if unhappy.
            // We do this because we never save state across method calls.
            finally
            {

                if (ctxObject!=null)
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

        private String truePost (int lngAccountNo, int lngAmount) {

            _Recordset adoRsBalance  = null;
            _Connection adoConn = null;
            Field pField = null;
            Fields pFields = null;
            String result;

            try
            {
                // Create ADOConnection object and initialize the connection

                adoConn = (_Connection) new __Connection();
                String vDSN = "FILEDSN=BankSample";

				adoConn.Open (vDSN, null, null, (int)CommandTypeEnum.adCmdUnspecified);

                // Obtain the desired recordset with an SQL query
                Object  vRowCount = new Object();
                String strSQL = "UPDATE Account SET Balance = Balance + " + lngAmount +
                                " WHERE AccountNo = " + lngAccountNo;

		TryAgain:
				try
				{
					adoConn.Execute (strSQL, ref vRowCount, (int)ExecuteOptionEnum.adExecuteNoRecords);
				}
				catch(Exception)
				{
					
					ICreateTable ct = (ICreateTable)new CreateTable();
					ct.CreateAccount();
					goto TryAgain;
				}

                // See whether the record is present.
                if ((int)vRowCount == 0)
                    throw new Exception ("Error. Account " + lngAccountNo + " not on file.");


                strSQL = "SELECT Balance FROM Account WHERE AccountNo = " + lngAccountNo;
                adoRsBalance = adoConn.Execute (strSQL, ref vRowCount, - 1);

                // Get the appropriate fields
                pFields = adoRsBalance.Fields;

                pField = pFields["Balance"];
                int lngBalance  = (int)pField.Value;

                // Check if account is overdrawn, then prepare return string
                if ((lngBalance) < 0)
                    throw new Exception("Error. Account " + lngAccountNo + " would be overdrawn by "
                                        + (-lngBalance) + ". Balance is still " + (lngBalance - lngAmount) + ".");

                if (lngAmount > 0)
                    result = "Credit to";
                else
                    result = "Debit from";
                result += " account " + lngAccountNo + ", balance is $" + lngBalance + ".  (C#)";

                return result;
            }

            finally
            {
                // cleanup that needs to occur whether we leave via a return or an exception.
                if (adoRsBalance != null)
                {
                    if (adoRsBalance.State == (int)ObjectStateEnum.adStateOpen)
                        adoRsBalance.Close();

                    Marshal.ReleaseComObject(adoRsBalance);
                }

                if (adoConn != null)
                {
                    if (adoConn.State == (int)ObjectStateEnum.adStateOpen)
                        adoConn.Close();

                    Marshal.ReleaseComObject(adoConn);
                }
            }
        }
    }



}
// ==============================================================================
// Filename: GetReceipt.cs
//
// Summary:  C# implememtation of the GetReceipt class for the bank sample
// Classes:  GetReceipt.cs
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
     ComEmulate("CSharpBank.GetReceiptOrig"),
     GuidAttribute("B9E8F6DE-94EE-4aa9-B2E4-3B0B08585485"),
     Transaction(TransactionOption.Supported)
    ]
    public class GetReceipt
    {
        public GetReceipt()
        {
        }
    }

    internal class GetReceiptOrig : IGetReceipt
    {


        // F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
        //
        // Function: GetNextReceipt
        //
        // GetNextReceipt() performs error handling for TrueGetNextReceipt().  If TrueGetNextReceipt()
        // throws an exception, then GetNextReceipt() will call SetAbort() and pass the exception up
        // to the caller.  Otherwise, GetNextReceipt() will simply call SetComplete() and return.
        //
        // Args:     None
        // Returns:  Long -  next receipt value
        //
        // F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---

        public int GetNextReceipt () {

            bool bSuccess = false;
            int result;


            // First of all, get the object context
            IObjectContext ctxObject = (IObjectContext)ContextUtil.ObjectContext;

            try
            {
                // Call the true function
                result = trueGetNextReceipt ();

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
        // Function: trueGetNextReceipt
        //
        // trueGetNextReceipt() is the function that performs the actual work for the Account class.
        // If an error occurs during execution, it will throw a COMException for GetNextReceipt()
        // to handle.

        // For exposition purposes, two versions of this function are given. You can uncomment either one
        // of these routines.

        // The first version of trueGetNextReceipt uses the COM+ Shared Property Manager to hold the
        // shared state. The Shared Property Manager allows one to share state across all instances of
        // components that are in the same package, regardless of what language and tools were used to
        // implement each component. It is also hard to create race conditions with the Shared Property Manager.
        // This example also shows that the interface the Shared Property Manager.

        // The second version of trueGetNextReceipt uses static variables to hold the shared state,
        // and a static synchronized method to access and update them. Correctly writing code like this also
        // requires a full understanding of static members and methods, of synchronized methods, and of
        // how the two interact. It's relatively easy to get code like this wrong, but this example is
        // simple enough that the code is attractive in this case.
        //
        // Args:     None
        // Returns:  Long -  next receipt value
        //
        // F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---


        // trueGetNextReceipt using COM+ Shared Properties:
        private int trueGetNextReceipt () {

            SharedPropertyGroupManager spmMgr = null;
            SharedPropertyGroup spmGroup = null;
            SharedProperty spmPropNextReceipt = null;
            SharedProperty spmPropMaxNum = null;

            IUpdateReceipt objReceiptUpdate = null;

            try
            {
                // Create SPM group manager
                //spmMgr = (ISharedPropertyGroupManager) Context.getObjectContext().CreateInstance
                //  (SharedPropertyGroupManager.clsid, ISharedPropertyGroupManager.iid);
                spmMgr = new SharedPropertyGroupManager();

                // Prepare primnitive types that can be passed in by reference, as per the
                // function declarations generated by the Type Library Wizard for the
                // "Shared Property Manager Type Library."
                bool bExists = false;
                PropertyLockMode iLockMode;  //= new int [1];
                PropertyReleaseMode iReleaseMode;//  = new int [1];

                //iLockMode [0] = ISharedPropertyGroupManager.LOCKMODE_METHOD;
                iLockMode  = PropertyLockMode.Method;
                //iReleaseMode [0] = ISharedPropertyGroupManager.RELEASEMODE_PROCESS;
                iReleaseMode  = PropertyReleaseMode.Process;

                // Create the shared property group
                spmGroup = spmMgr.CreatePropertyGroup ("Receipt", ref iLockMode, ref iReleaseMode, out bExists);

                // Create the properties
                spmPropNextReceipt = spmGroup.CreateProperty("Next", out bExists);
                spmPropMaxNum = spmGroup.CreateProperty("MaxNum", out bExists);

                // Call GetNextReceipt() if necessary
                if (((int)spmPropNextReceipt.Value) >= ((int)spmPropMaxNum.Value))
                {

					objReceiptUpdate = (IUpdateReceipt)new UpdateReceipt();
                    int iRet = objReceiptUpdate.Update ();

                    // Update Next
                    spmPropNextReceipt.Value =  (iRet);
                    //spmPropNextReceipt.setValue(vRet);

                    //spmPropMaxNum.setValue (vRet);
                    spmPropMaxNum.Value = (iRet + 100);
                }

                int vfoo = (((int)spmPropNextReceipt.Value) + 1);
                //spmPropNextReceipt.setValue (vRet);
                spmPropNextReceipt.Value = (vfoo);

                // We are finished and happy
                return(int)spmPropNextReceipt.Value;
            }

            finally
            {
                // The following code is not strictly necessary. By calling ComLib.release here,
                // the object counts seen in the MTX explorer remain correct. Without these release
                // calls, the objects used here would not get released until after the next time
                // the garbage collector runs. No other ill effect would be caused by omitting
                // this code.

                // Note that this code will be executed regardless of whether we leave this
                // method via return or via an exception.
                //if (spmMgr             != null) Marshal.ReleaseComObject (spmMgr);
                //if (spmGroup           != null) Marshal.ReleaseComObject (spmGroup);
                //if (spmPropNextReceipt != null) Marshal.ReleaseComObject(spmPropNextReceipt);
                //if (spmPropMaxNum      != null) Marshal.ReleaseComObject (spmPropMaxNum);
                //if (objReceiptUpdate   != null) Marshal.ReleaseComObject (objReceiptUpdate);
            }
        }



    }
}
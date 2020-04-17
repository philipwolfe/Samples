//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Sample.Transaction.NestedTransactionScopeActivitySample
{
    using System;
    using System.Activities;
    using System.Activities.Statements;

    sealed class PrintTransactionId : NativeActivity
    {
        protected override void Execute(ActivityExecutionContext context)
        {
            //Access to the current transaction in Workflow is through the GetCurrentTransaction method on a RuntimeTransactionHandle
            RuntimeTransactionHandle rth = new RuntimeTransactionHandle();
            rth = context.Properties.Find(rth.ExecutionPropertyName) as RuntimeTransactionHandle;
            Console.WriteLine("    TransactionID: " + rth.GetCurrentTransaction(context).TransactionInformation.LocalIdentifier.ToString());
        }
    }
}

//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Sample.Transaction.TransactedParallelConvoy.Common
{
    using System;
    using System.Activities;

    public sealed class PrintTxDistributedID : NativeActivity
    {
        public String Source { get; set; }

        protected override void Execute(ActivityExecutionContext context)
        {
            RuntimeTransactionHandle rth = new RuntimeTransactionHandle();
            rth = context.Properties.Find(rth.ExecutionPropertyName) as RuntimeTransactionHandle;
            Guid distroID = rth.GetCurrentTransaction(context).TransactionInformation.DistributedIdentifier;
            if (distroID == null)
            {
                Console.WriteLine("There is no distributed identifier");
            }
            else
            {
                Console.WriteLine(this.Source + "The distributed identifier is: " + distroID);
            }
        }
    }
}

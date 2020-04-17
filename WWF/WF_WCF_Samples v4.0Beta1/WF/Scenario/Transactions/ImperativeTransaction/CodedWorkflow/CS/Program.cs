//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Sample.Transaction.ImperativeTransactionSample
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.Collections.Generic;
    using System.Transactions;
    using System.Threading;

    sealed class Program
    {
        static void Main()
        {
            Console.WriteLine("Sample begins.");
            using (TransactionScope txScope = new TransactionScope())
            {                
                Console.WriteLine("TransactionScope constructed.");

                //The local ID of the current transaction
                Console.WriteLine("Tx local ID: " + Transaction.Current.TransactionInformation.LocalIdentifier.ToString());

                Console.WriteLine("\nLaunching WF using WorkflowInvoker.");

                //Launch my workflow. WorkflowInvoker is the only way to implicitly flow a current transaction into a new workflow
                new WorkflowInvoker(BuildWF()).BeginInvoke(null, null);

                txScope.Complete();
                txScope.Dispose();
            };
            
            Console.WriteLine("\nSample complete. Press ENTER to exit");
            Console.ReadLine();
        }

        static WorkflowElement BuildWF()
        {
            return new Sequence
            {
                Activities =
                {
                    new WriteLine { Text = "    Workflow - Start" },

                    new PrintTxID(),

                    new TransactionScopeActivity
                    {
                        Body = new Sequence
                        {
                            Activities = 
                            {
                                new WriteLine { Text = "    Workflow - Begin TransactionScopeActivity" },

                                new PrintTxID(),

                                new WriteLine { Text = "    Workflow - End TransactionScopeActivity" },
                            }
                        },
                    },

                    new WriteLine { Text = "    Workflow - End" },
                }
            };
        }

        class PrintTxID : NativeActivity
        {
            protected override void Execute(ActivityExecutionContext context)
            {
                //In workflow access to the current transaction is through the runtime transaction handle
                RuntimeTransactionHandle rth = new RuntimeTransactionHandle();
                Transaction tx = null;
                rth = context.Properties.Find(rth.ExecutionPropertyName) as RuntimeTransactionHandle;

                if (rth != null)
                {
                    tx = rth.GetCurrentTransaction(context);
                }
                
                if (tx == null)
                {
                    Console.WriteLine("    Workflow - There is no current transaction.");
                }
                else
                {
                    Console.WriteLine("    Workflow - Tx local ID: " + rth.GetCurrentTransaction(context).TransactionInformation.LocalIdentifier);
                }
            }
        }
    }    
}

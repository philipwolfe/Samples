//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Sample.Transaction.NestedTransactionScopeActivitySample
{
    using System;
    using System.Activities;
    using System.Activities.Statements;

    sealed class TransactionScopeTest : Activity
    {       
        protected override WorkflowElement CreateBody()
        {           
            return new Sequence
            {
                Activities =
                {
                    new WriteLine { Text = "    Begin TransactionScopeTest" },

                    new TransactionScopeActivity
                    {
                        Body = new Sequence
                        {
                            Activities = 
                            {
                                new WriteLine { Text = "    Begin TransactionScopeTest TransactionScopeActivity" },

                                new PrintTransactionId(),
                                
                                new WriteLine { Text = "    End TransactionScopeTest TransactionScopeActivity" },
                            },
                        },                                                        
                    },

                    new WriteLine { Text = "    End TransactionScopeTest" },
                }
            };
        }
    }
}

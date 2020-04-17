//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Activities;
using System.Activities.Statements;
using Microsoft.Samples.Scenarios.Common.Activities;

namespace Microsoft.Samples.WorkflowModel
{
    class Program
    {
        static void Main()
        {
            WorkflowElement mySequence = CreateMySequence();

            WorkflowInvoker.Invoke(mySequence);

            WorkflowElement myWhile = CreateMyWhile();

            WorkflowInvoker.Invoke(myWhile);

            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }

        private static WorkflowElement CreateMyWhile()
        {
            Variable<int> count = new Variable<int> { Default = 1 };

            return new MyWhile
            {
                Variables = { count },
                Condition = ValueExpression.Create((env) => count.Get(env) < 3),
                Body = new Sequence
                {
                    Activities = {
                        new WriteLine { Text = ValueExpression.Create((env) => "Hello from while loop " + count.Get(env).ToString()) },
                        new Assign<int> { To = count, Value = ValueExpression.Create((env) => count.Get(env)+ 1) }}
                }
            };
        }

        private static WorkflowElement CreateMySequence()
        {
            Variable<int> count = new Variable<int> { Default = 1 };

            return new MySequence
            {
                Variables = { count },
                Activities = {
                    new WriteLine { Text = ValueExpression.Create((env) => "Hello from sequence count is " + count.Get(env).ToString())},
                    new Assign<int> { To = count, Value = ValueExpression.Create((env) => count.Get(env)+ 1)},
                    new WriteLine { Text = ValueExpression.Create((env) => "Hello from sequence count is " + count.Get(env).ToString())}}
            };
        }
    }
}
//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.Activities
{
    using System;
    using System.Activities;
    using System.Activities.Statements;

    class Program
    {
        static void Main()
        {
            ShowDateTime workflow1 = new ShowDateTime();
            WorkflowInvoker.Invoke(workflow1);

            Variable<string> str = new Variable<string>();
            ShowDateTimeAsAction workflow2 = new ShowDateTimeAsAction()
            {
                CustomAction = new ActivityAction<string>()
                {
                    Argument = str,
                    Handler = new WriteLine()
                    {
                        Text = new InArgument<string>(str)
                    }
                }
            };

            WorkflowInvoker.Invoke(workflow2);

            Console.WriteLine("Hit <enter> to exit...");
            Console.ReadLine();
        }
    }
}

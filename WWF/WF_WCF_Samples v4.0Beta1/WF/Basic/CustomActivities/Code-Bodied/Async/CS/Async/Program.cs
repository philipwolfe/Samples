//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.WorkflowModel
{
    using System;
    using System.Activities;

    class Program
    {
        static void Main()
        {
            FileWriter writer = new FileWriter();
            WorkflowInvoker.Invoke(writer);

            Console.WriteLine("Hit <enter> to exit...");
            Console.ReadLine();
        }
    }
}

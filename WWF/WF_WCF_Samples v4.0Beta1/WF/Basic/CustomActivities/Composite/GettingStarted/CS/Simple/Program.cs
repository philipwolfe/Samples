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
            WorkflowInvoker.Invoke(new Rhyme());
            
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }
    }
}

//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.ExecutionProperties
{
    using System;
    using System.Activities;
    using System.Xaml;

    class Program
    {
        static void Main()
        {
            WorkflowElement workflow = (WorkflowElement)XamlServices.Load("ThreeColors.xaml");
            WorkflowInvoker.Invoke(workflow);

            Console.WriteLine("Press <enter> to exit");
            Console.ReadLine();
        }
    }
}

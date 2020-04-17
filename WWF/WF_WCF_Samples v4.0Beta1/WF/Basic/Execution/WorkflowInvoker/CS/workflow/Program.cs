//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Activities.Statements;

namespace Microsoft.Samples.WorkflowModel
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1, y = 2;

            Console.WriteLine("Invoking Add");

            IDictionary<string, object> results = WorkflowInvoker.Invoke(new Add(), new Dictionary<string, object> { { "X", x }, { "Y", y } });

            Console.WriteLine("{0} + {1} = {2}", x, y, results["Result"]);
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }
    }
}

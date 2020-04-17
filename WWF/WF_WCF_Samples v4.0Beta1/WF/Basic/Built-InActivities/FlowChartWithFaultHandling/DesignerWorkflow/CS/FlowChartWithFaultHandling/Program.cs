//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
namespace Microsoft.Samples.FlowChartWithFaultHandling
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.Collections.Generic;

    // Show how to create a FlowChart that handles faults using a TryCatch activity
    // To demonstrate this issue, a flowchart workflow to handle promotions is created
    // in CreateFlowchartWithFaults method. The following Promotion Codes are used 
    //      Single: Single
    //      MNK:    Married (No Kids)
    //      MWK:    Married (With Kids)
    class Program
    {
        static void Main(string[] args)
        {
            // no fault expected
            Console.WriteLine("Invoke with Promo Code {0}, number of kids {1}", "Single", 0);
            IDictionary<string, object> inputs = new Dictionary<string, object>() { { "promoCode", "Single" }, { "numberOfKids", 0 } };
            WorkflowInvoker.Invoke(new PromotionalDiscountWorkflow(), inputs);

            // no fault expected
            Console.WriteLine("Invoke with Promo Code {0}, number of kids {1}", "MNK", 0);
            inputs = new Dictionary<string, object>() { { "promoCode", "MNK" }, { "numberOfKids", 0 } };
            WorkflowInvoker.Invoke(new PromotionalDiscountWorkflow(), inputs);

            // no fault expected
            Console.WriteLine("Invoke with Promo Code {0}, number of kids {1}", "MWK", 2);
            inputs = new Dictionary<string, object>() { { "promoCode", "MWK" }, { "numberOfKids", 2 } };
            WorkflowInvoker.Invoke(new PromotionalDiscountWorkflow(), inputs);

            //fault expected
            Console.WriteLine("Invoke with Promo Code {0}, number of kids {1}", "MWK", 0);
            inputs = new Dictionary<string, object>() { { "promoCode", "MWK" }, { "numberOfKids", 0 } };
            WorkflowInvoker.Invoke(new PromotionalDiscountWorkflow(), inputs);

            // wait for user input
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }
}

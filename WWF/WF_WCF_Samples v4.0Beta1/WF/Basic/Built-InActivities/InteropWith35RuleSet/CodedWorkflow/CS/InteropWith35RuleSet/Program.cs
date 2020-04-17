//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using Microsoft.Samples.TravelRuleLibrary;

namespace Microsoft.Samples.InteropWith35RuleSet
{
    // This sample shows how to use InteropActivity to invoke a ruleset defined
    // using .NET 3.x Policity/Rules activity
    class Program
    {
        static void Main(string[] args)        
        {
            IDictionary<string, object> results = WorkflowInvoker.Invoke(CreateRulesInterop());

            // wait for user input
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }

        private static WorkflowElement CreateRulesInterop()
        {
            //Create the variables needed to be passed into the 35 Ruleset
            Variable<int> discountLevel = new Variable<int> { Default = 1 };
            Variable<double> discountPoints = new Variable<double> { Default = 0.0 };
            Variable<string> destination = new Variable<string> { Default = "London" };
            Variable<double> price = new Variable<double> { Default = 1000.0 };

            Sequence result = new Sequence
            {
                Variables = {discountLevel, discountPoints, destination, price},
                Activities =
                {
                    new WriteLine { Text = new InArgument<string>(env => string.Format("Price before applying Discount Rules = {0}", price.Get(env).ToString())) },
                    new WriteLine { Text = "Invoking Discount Rules defined in .NET 3.5"},
                    new Interop()
                    {
                        Body = typeof(TravelRuleSet),
                        Properties =
                        {
                            //These bind to the dependency properties of the 35 custom ruleset
                            { "DiscountLevel", new InOutArgument<int>(discountLevel) },
                            { "DiscountPoints", new InOutArgument<double>(discountPoints) },
                            { "Destination", new InOutArgument<string>(destination) },
                            { "Price", new InOutArgument<double>(price) }
                        }
                    },
                    new WriteLine {Text = new InArgument<string>(env => string.Format("Price after applying Discount Rules = {0}", price.Get(env).ToString())) }
                }
            };
            return result;
        }
    }         
}

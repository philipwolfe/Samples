//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Samples.DynamicActivityCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 3, 5, 7, 9, 11 };

            //if numbers are input from command line use those
            if (args.Length > 0)
            {
                Console.WriteLine("Using numbers passed in as command line arguments");
                numbers.Clear();
            }
            else
            {
                Console.WriteLine("No numbers passed in as command line arguments. Using default list of numbers...");
            }

            foreach (string arg in args)
            {
                try
                {
                    numbers.Add(Convert.ToInt32(arg));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            Console.WriteLine("Input values:");
            foreach (int i in numbers)
            {
                Console.WriteLine("\tValue = " + i);
            }
            //Invoke a DynamicActivity that takes in a list of values as input and returns average
            IDictionary<string, object> results = WorkflowInvoker.Invoke(CreateAverageCalculationWorkflow(), new Dictionary<string, object> { { "Numbers", numbers } });

            Console.WriteLine("The average calculated is = " + results["Average"]);
            Console.Read();
        }

        static WorkflowElement CreateAverageCalculationWorkflow()
        {
            var iterationVariable = new Variable<int>() { Name = "iterationVariable" };
            var accumulator = new Variable<int>() { Default = 0, Name = "accumulator" };

            //Define the Input and Output arguments that the DynamicActivity binds to
            InArgument<List<int>> numbers = new InArgument<List<int>>();
            OutArgument<double> average = new OutArgument<double>();

            var result = new Variable<double>() { Name = "result" };

            return new DynamicActivity()
            {
                DisplayName = "Find average",
                Properties = 
                {
                    new ActivityProperty
                    {
                        Name = "Numbers",
                        Type = typeof(InArgument<IEnumerable<int>>),
                        Value = numbers
                    },
                    new ActivityProperty
                    {
                        Name = "Average",
                        Type = typeof(OutArgument<double>),
                        Value = average
                    }
                },
                Body = () =>
                new Sequence
                {
                    Variables = {result, accumulator},
                    Activities =
                    {
                        new ForEach<int>
                        {
                            Values = new InArgument<IEnumerable<int>> (new ArgumentValue<IEnumerable<int>> { ArgumentName = "Numbers" }),

                            Body = new ActivityAction<int>
                            {
                                Argument = iterationVariable,
                                Handler = new Assign<int>
                                {
                                    To = new OutArgument<int>(accumulator),
                                    Value = new InArgument<int>(env => iterationVariable.Get(env) +  accumulator.Get(env))
                                }
                            }
                        },
                        //calculate the average and assign to the output argument
                        new Assign<double>
                        {
                            To = new OutArgument<double>(new ArgumentReference<double> { ArgumentName = "Average" }),
                            Value = new InArgument<double>(env => accumulator.Get(env) / numbers.Get(env).Count<int>())
                        }
                    }
                }
            };

        }
    }
}

//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.SwitchRange
{
using System;
using System.Activities;
using System.Activities.Statements;

class Program
{
    //Call SwitchRange activity with an input value to switch against
    static void Main(string[] args)
    {
        Console.WriteLine("Calling a correctly defined SwitchRange with all the ranges correctly defined");
        InvokeValidSwitchRange("Foo");
        Console.WriteLine();

        try
        {
            Console.WriteLine("Calling an incorrectly defined SwitchRange - Some ranges incorrectly defined");
            InvokeInvalidSwitchRangeInvalidRanges("Foo");
        }
        catch (ValidationException ve)
        {
            Console.WriteLine("Validation Error: "+ve.Message);
            Console.WriteLine();
        }

        try
        {
            Console.WriteLine("Calling an incorrectly defined SwitchRange - Expression unspecified");
            InvokeInvalidSwitchRangeExpressionUnspecified("Foo");
        }
        catch (ValidationException ve)
        {
            Console.WriteLine("Validation Error: " + ve.Message);
            Console.WriteLine();
        }
        Console.ReadKey();
    }

    //Invoke a correctly constructed SwitchRange activity
    private static void InvokeValidSwitchRange(String value)
    {
        Console.WriteLine("Test SwitchRange with a value of " + value);
        WorkflowElement switchRange = new SwitchRange<string>()
        {
            DisplayName = "TestSwitchRange",
            Expression = new InArgument<string>(value),
            Cases = 
            {
                new CaseRange<string>                    
                {
                    From = "a",
                    To = "c",
                    Action = new WriteLine
                    {
                        Text = "Case a-c selected",
                    }
                },
                new CaseRange<string>
                {
                    From = "d",
                    To = "g",
                    Action = new WriteLine
                    {
                        Text = "Case d-g selected",
                    }
                },
                new CaseRange<string>
                {
                    From = "h",
                    To = "z",
                    Action = new WriteLine
                    {
                        Text = "Case h-z selected",
                    }
                }
            },
            Default = new WriteLine { Text = "Default Case selected" }
        };

        // execute the workflow element
        WorkflowInvoker.Invoke(switchRange);
    }

    //Invoke a SwitchRange activity with invalid Ranges
    private static void InvokeInvalidSwitchRangeInvalidRanges(String value)
    {
        Console.WriteLine("Test SwitchRange with a value of " + value);
        WorkflowElement switchRange = new SwitchRange<string>()
        {
            DisplayName = "TestSwitchRange",
            Expression = new InArgument<string>(value),
            Cases = 
            {
                new CaseRange<string>                    
                {
                    From = "a",
                    Action = new WriteLine
                    {
                        Text = "Case a-c selected",
                    }
                },
                new CaseRange<string>
                {
                    From = "d",
                    To = "g",
                    Action = new WriteLine
                    {
                        Text = "Case d-g selected",
                    }
                },
                new CaseRange<string>
                {
                    From = "h",
                    To = "z",
                    Action = new WriteLine
                    {
                        Text = "Case h-z selected",
                    }
                }
            },
            Default = new WriteLine { Text = "Default Case selected" }
        };

        // execute the workflow element
        WorkflowInvoker.Invoke(switchRange);
    }

    //Invoke a SwitchRange where the Expression is unspecified
    private static void InvokeInvalidSwitchRangeExpressionUnspecified(String value)
    {
        Console.WriteLine("Test SwitchRange with a value of " + value);
        WorkflowElement switchRange = new SwitchRange<string>()
        {
            DisplayName = "TestSwitchRange",
            Cases = 
            {
                new CaseRange<string>                    
                {
                    From = "a",
                    To = "c",
                    Action = new WriteLine
                    {
                        Text = "Case a-c selected",
                    }
                },
                new CaseRange<string>
                {
                    From = "d",
                    To = "g",
                    Action = new WriteLine
                    {
                        Text = "Case d-g selected",
                    }
                },
                new CaseRange<string>
                {
                    From = "h",
                    To = "z",
                    Action = new WriteLine
                    {
                        Text = "Case h-z selected",
                    }
                }
            },
            Default = new WriteLine { Text = "Default Case selected" }
        };

        // execute the workflow element
        WorkflowInvoker.Invoke(switchRange);
    }
}
}

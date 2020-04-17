//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Activities.Statements;
using System.Activities;
using System.Threading;

namespace Microsoft.Samples.RangeEnumeration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Step by +1 
            Console.WriteLine("Stepping by 1 starting...");
            WorkflowInvoker.Invoke(StepByOne());
            Console.WriteLine("Run complete");
            Console.WriteLine();

            // Step by +3
            Console.WriteLine("Step by 3 starting...");
            WorkflowInvoker.Invoke(StepByThree());
            Console.WriteLine("Run complete");
            Console.WriteLine();

            // Step by -1 
            Console.WriteLine("Step by -1 starting...");
            WorkflowInvoker.Invoke(BackStepByOne());
            Console.WriteLine("Run complete");
            Console.WriteLine();

            // Step by -3
            Console.WriteLine("Step is -3 starting...");
            WorkflowInvoker.Invoke(BackStepByThree());
            Console.WriteLine("Run complete");
            Console.WriteLine();

            // Out of range with positive step 
            Console.WriteLine("Out of range with positive step starting...");
            WorkflowInvoker.Invoke(OutOfRangeWithPositiveStep());
            Console.WriteLine("Run complete");
            Console.WriteLine();

            // Out of range with negative step
            Console.WriteLine("Out of range with negative step starting...");
            WorkflowInvoker.Invoke(OutOfRangeWithNegativeStep());
            Console.WriteLine("Run complete");
            Console.WriteLine();

            // Null body
            Console.WriteLine("Null body starting...");
            WorkflowInvoker.Invoke(NullBody());
            Console.WriteLine("Run complete");
            Console.WriteLine();

            Console.WriteLine("Press <return> to continue...");
            Console.Read();
        }

        // Step by +1
        private static RangeEnumeration StepByOne()
        {
            Variable<int> loopVariable = new Variable<int>();
            return new RangeEnumeration
            {
                Start = 1,
                Stop = 5,
                Step = 1,
                Body = new ActivityAction<int>
                {
                    Argument = loopVariable,
                    Handler = new WriteLine
                    {
                        Text = ValueExpression.Create<string>((env) => "This is " + loopVariable.Get(env).ToString()),
                    },
                }
            };
        }

        // Step by +3
        private static RangeEnumeration StepByThree()
        {
            Variable<int> loopVariable = new Variable<int>();
            return new RangeEnumeration
            {
                Start = 1,
                Stop = 5,
                Step = 3,
                Body = new ActivityAction<int>
                {
                    Argument = loopVariable,
                    Handler = new WriteLine
                    {
                        Text = ValueExpression.Create<string>((env) => "This is " + loopVariable.Get(env).ToString()),
                    },
                }
            };
        }

        // Step by -1
        private static RangeEnumeration BackStepByOne()
        {
            Variable<int> loopVariable = new Variable<int>();
            return new RangeEnumeration
            {
                Start = 5,
                Stop = 1,
                Step = -1,
                Body = new ActivityAction<int>
                {
                    Argument = loopVariable,
                    Handler = new WriteLine
                    {
                        Text = ValueExpression.Create<string>((env) => "This is " + loopVariable.Get(env).ToString()),
                    },
                }
            };
        }

        // Step by -3
        private static RangeEnumeration BackStepByThree()
        {
            Variable<int> loopVariable = new Variable<int>();
            return new RangeEnumeration
            {
                Start = 5,
                Stop = 1,
                Step = -3,
                Body = new ActivityAction<int>
                {
                    Argument = loopVariable,
                    Handler = new WriteLine
                    {
                        Text = ValueExpression.Create<string>((env) => "This is " + loopVariable.Get(env).ToString()),
                    },
                }
            };
        }

        // Can't reach end point with a positive step
        private static RangeEnumeration OutOfRangeWithPositiveStep()
        {
            Variable<int> loopVariable = new Variable<int>();
            return new RangeEnumeration
            {
                Start = 5,
                Stop = 1,
                Step = 1,
                Body = new ActivityAction<int>
                {
                    Argument = loopVariable,
                    Handler = new WriteLine
                    {
                        Text = ValueExpression.Create<string>((env) => "This is " + loopVariable.Get(env).ToString()),
                    },
                }
            };
        }

        // Can't reach end point with a negative step
        private static RangeEnumeration OutOfRangeWithNegativeStep()
        {
            Variable<int> loopVariable = new Variable<int>();
            return new RangeEnumeration
            {
                Start = 1,
                Stop = 5,
                Step = -1,
                Body = new ActivityAction<int>
                {
                    Argument = loopVariable,
                    Handler = new WriteLine
                    {
                        Text = ValueExpression.Create<string>((env) => "This is " + loopVariable.Get(env).ToString()),
                    },
                }
            };
        }

        private static RangeEnumeration NullBody()
        {
            Variable<int> loopVariable = new Variable<int>();
            return new RangeEnumeration
            {
                Start = 1,
                Stop = 10000,
                Step = 1,
            };
        }
    }
}

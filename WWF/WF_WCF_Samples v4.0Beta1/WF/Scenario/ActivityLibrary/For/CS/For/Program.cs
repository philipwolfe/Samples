//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Activities;
using System.Activities.Statements;
using System.Threading;

namespace Microsoft.Samples.For
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Normal iteration
            Console.WriteLine("Normal iteration: Iterate from 5 to 9...");
            WorkflowInvoker.Invoke(Normal());
            Console.WriteLine("Run completed");
            Console.WriteLine();

            // Increment the variable inside the body
            Console.WriteLine("Increment the variable inside the For body as well...");
            WorkflowInvoker.Invoke(BodyIncrease());
            Console.WriteLine("Run completed");
            Console.WriteLine();

            // No body
            Console.WriteLine("Test null body starting...");
            WorkflowInvoker.Invoke(NullBody());
            Console.WriteLine("Run completed");
            Console.WriteLine();

            Console.WriteLine("Press <return> to continue...");
            Console.Read();
        }

        private static For Normal()
        {
            Variable<int> loopVariable = new Variable<int>();

            return new For()
            {
                Variables = { loopVariable },

                // Start from 5
                InitAction = new Assign()
                {
                    To = new OutArgument<int>(loopVariable),
                    Value = new InArgument<int>(5),
                },

                // Increment
                IterationAction = new Assign
                {
                    To = new OutArgument<int>(loopVariable),
                    Value = new InArgument<int>((env) => loopVariable.Get(env) + 1),
                },

                // Condition: <10
                Condition = ValueExpression.Create<bool>((env) => loopVariable.Get(env) < 10),
                Body = new WriteLine
                {
                    Text = ValueExpression.Create<string>((env) => "This is " + loopVariable.Get(env).ToString()),
                },
            };
        }

        private static For BodyIncrease()
        {
            Variable<int> loopVariable = new Variable<int>();

            return new For
            {
                Variables = { loopVariable },

                // Start from 5
                InitAction = new Assign
                {
                    To = new OutArgument<int>(loopVariable),
                    Value = new InArgument<int>(5),
                },

                // Increment
                IterationAction = new Assign
                {
                    To = new OutArgument<int>(loopVariable),
                    Value = new InArgument<int>((env) => loopVariable.Get(env) + 1),
                },

                // Condition: <10
                Condition = ValueExpression.Create<bool>((env) => loopVariable.Get(env) < 10),
                Body = new Sequence
                {
                    Activities = 
					{
						new WriteLine 
						{
							Text = ValueExpression.Create<string>((env) => "This is " + loopVariable.Get(env).ToString()),
						},
            			// Increment the variable inside the body
            			new Assign
						{
              				To = new OutArgument<int>(loopVariable),
              				Value = new InArgument<int>((env) => loopVariable.Get(env) + 1),
            			}
          			},
                },
            };
        }

        private static For NullBody()
        {
            Variable<int> loopVariable = new Variable<int>();
            return new For
            {
                Variables = { loopVariable },

                InitAction = new Assign
                {
                    To = new OutArgument<int>(loopVariable),
                    Value = new InArgument<int>(5),
                },

                IterationAction = new Assign
                {
                    To = new OutArgument<int>(loopVariable),
                    Value = new InArgument<int>((env) => loopVariable.Get(env) + 1),
                },

                Condition = ValueExpression.Create<bool>((env) => loopVariable.Get(env) < 10),

                // Body is not defined
            };
        }
    }
}

//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Sample.Transaction.NestedTransactionScopeActivitySample
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.Threading;

    class Program
    {
        static ManualResetEvent syncEvent = new ManualResetEvent(false);
            
        static void Main(string[] args)
        {
            WorkflowInstance instance;

            //Scenario One: This scenario will illustrate the requires semantic of the TransactionScopeActivity. The workflow author does not know
            //when using the TransactionScopeTest activity if it contains another TransactionScopeActivity. When the TransactionScopeActivity in the
            //TransactionScopeTest runs it will detect and use the ambient transaction.
            Console.WriteLine("Scenario One - Successful execution");
            new WorkflowInvoker(ScenarioOne()).Invoke();

            //Scenario Two: The transaction will timeout after the delay has run for two seconds because the timeout on the inner TransactionScopeActivity
            //is set to two seconds. The smallest timeout in scope will be respected.
            Console.WriteLine("\n\nScenario Two - Inner timerout less than outer timerout, inner timeout exceeded");
            instance = new WorkflowInstance(ScenarioTwo());
            instance.OnAborted = Program.OnAborted;
            instance.OnCompleted = Program.OnCompleted;
            instance.OnUnhandledException = Program.OnUnhandledException;
            instance.Run();
            syncEvent.WaitOne();

            //Scenario Two: The transaction will timeout but since the two second timeout of the inner TransactionScopeActivity no longer applies 
            //the transaction will timeout at five seconds when the outer TransactionScopeActivity timeout is exceded.
            Console.WriteLine("\n\nScenario Three - Inner timeout less than outer timeout, outer timeout exceeded");
            instance = new WorkflowInstance(ScenarioThree());
            instance.OnAborted = Program.OnAborted;
            instance.OnCompleted = Program.OnCompleted;
            instance.OnUnhandledException = Program.OnUnhandledException;
            syncEvent.Reset();
            instance.Run();
            syncEvent.WaitOne();

            //Scenario Four: There will be a runtime exception because there is a mismatch between the AbortInstanceOnTransactionFailure flags
            //are different. If the flag of a nested TransactionScopeActivity is explicitly set it must match the flag of the root TransactionScopeActivity
            Console.WriteLine("\n\nScenario Four - AbortInstanceOnTransactionFailure are different");
            instance = new WorkflowInstance(ScenarioFour());
            instance.OnAborted = Program.OnAborted;
            instance.OnCompleted = Program.OnCompleted;
            instance.OnUnhandledException = Program.OnUnhandledException;
            syncEvent.Reset();
            instance.Run();
            syncEvent.WaitOne();

            Console.WriteLine("\nPress ENTER to exit");
            Console.ReadLine();
        }

        static WorkflowElement ScenarioOne()
        {
            return new Sequence
            {
                Activities =
                {
                    new WriteLine { Text = "    Begin workflow" },

                    new TransactionScopeActivity
                    {
                        Body = new Sequence
                        {
                            Activities = 
                            {
                                new WriteLine { Text = "    Begin TransactionScopeActivity" },

                                new PrintTransactionId(),
                                
                                new TransactionScopeTest(),

                                new WriteLine { Text = "    End TransactionScopeActivity" },
                            },
                        },
                    },

                    new WriteLine { Text = "    End workflow" },
                }
            };
        }

        static WorkflowElement ScenarioTwo()
        {
            return new Sequence
            {
                Activities =
                {
                    new WriteLine { Text = "    Begin workflow" },

                    new TransactionScopeActivity
                    {
                        Body = new Sequence
                        {
                            Activities = 
                            {
                                new WriteLine { Text = "    Begin TransactionScopeActivity" },

                                new PrintTransactionId(),
                                
                                new TransactionScopeActivity
                                {
                                    Body = new Delay { Duration = TimeSpan.FromSeconds(5) },
                                    Timeout = TimeSpan.FromSeconds(2),
                                },

                                new WriteLine { Text = "    End TransactionScopeActivity" },
                            },
                        },
                        Timeout = TimeSpan.FromSeconds(10),
                    },

                    new WriteLine { Text = "    End workflow" },
                }
            };
        }

        static WorkflowElement ScenarioThree()
        {
            return new Sequence
            {
                Activities =
                {
                    new WriteLine { Text = "    Begin workflow" },

                    new TransactionScopeActivity
                    {
                        Body = new Sequence
                        {
                            Activities = 
                            {
                                new WriteLine { Text = "    Begin TransactionScopeActivity" },

                                new PrintTransactionId(),
                                
                                new TransactionScopeActivity
                                {
                                    Body = new WriteLine { Text = "    Inner TransactionScopeActivity" },
                                    Timeout = TimeSpan.FromSeconds(2),
                                },

                                new Delay { Duration = TimeSpan.FromSeconds(10) },

                                new WriteLine { Text = "    End TransactionScopeActivity" },
                            },
                        },
                        Timeout = TimeSpan.FromSeconds(5),
                    },

                    new WriteLine { Text = "    End workflow" },
                }
            };
        }

        static WorkflowElement ScenarioFour()
        {
            return new Sequence
            {
                Activities =
                {
                    new WriteLine { Text = "    Begin workflow" },

                    new TransactionScopeActivity
                    {
                        Body = new Sequence
                        {
                            Activities = 
                            {
                                new WriteLine { Text = "    Begin TransactionScopeActivity" },

                                new PrintTransactionId(),
                                
                                new TransactionScopeActivity
                                {
                                    Body = new WriteLine { Text = "Inner TransactionScopeActivity" },
                                    AbortInstanceOnTransactionFailure = true,                                    
                                },

                                new WriteLine { Text = "    End TransactionScopeActivity" },
                            },
                        },
                        AbortInstanceOnTransactionFailure = false,
                    },

                    new WriteLine { Text = "    End workflow" },
                }
            };
        }

        static void OnAborted(WorkflowAbortedEventArgs e)
        {
            Console.WriteLine("Workflow aborted because: " + e.Reason.Message);
            syncEvent.Set();
        }

        static void OnCompleted(WorkflowCompletedEventArgs e)
        {
            syncEvent.Set();
        }

        static UnhandledExceptionAction OnUnhandledException(WorkflowUnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Unhandled exception: " + e.UnhandledException.Message);
            syncEvent.Set(); 
            return UnhandledExceptionAction.Terminate;
        }        
    }
}

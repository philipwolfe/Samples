//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Compensation.CancellationSample
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using Parallel = System.Activities.Statements.Parallel;

    class Program
    {        
        static WorkflowElement ExceptionCausingCustomCancellation()
        {
            // Declaring a set of tokens that can be used to refer to a particular unit of compensable work
            Variable<CompensationToken> tokenA = new Variable<CompensationToken>
            {
                Name = "Token A",
            };
            Variable<CompensationToken> tokenB = new Variable<CompensationToken>
            {
                Name = "Token B",
            };
            Variable<CompensationToken> tokenC = new Variable<CompensationToken>
            {
                Name = "Token C",
            };

            return new TryCatch
            {
                Try = new Sequence
                {
                    Activities = 
                    {
                        // Root CompensableActivity
                        new CompensableActivity
                        {  
                             Variables =
                             {
                                   tokenA,
                                   tokenB,
                                   tokenC
                             },

                            Body = new Sequence
                            {
                                Activities = 
                                {                        
                                    new WriteLine { Text = " Entering Top Level Activity" },

                                    // First CompensableActivity
                                    new CompensableActivity
                                    {                                            
                                        Body = new WriteLine { Text = " CompensableActivity: Do First Action" },                                            

                                        ConfirmationHandler = new WriteLine { Text = " CompensableActivity: Confirm First Action" },
                                        CompensationHandler = new WriteLine { Text = " CompensableActivity: Compensate First Action" },                       
                                        CancellationHandler = new WriteLine { Text = " CompensableActivity: Cancel First Action" },
                                        Result = tokenA
                                    },

                                    // Second CompensableActivity
                                    new CompensableActivity
                                    {
                                        Body = new WriteLine { Text = " CompensableActivity: Do Second Action" },

                                        ConfirmationHandler = new WriteLine { Text = " CompensableActivity: Confirm Second Action" },
                                        CompensationHandler = new WriteLine { Text = " CompensableActivity: Compensate Second Action" },
                                        CancellationHandler = new WriteLine { Text = " CompensableActivity: Cancel Second Action" },
                                        Result = tokenB
                                    },

                                    // Third CompensableActivity
                                    new CompensableActivity
                                    {
                                        Body = new Sequence
                                        {
                                            Activities =
                                            {
                                                new WriteLine { Text = " CompensableActivity: Third Activity is about to throw an exception " },
                                                new Throw { Exception = new InArgument<Exception>(new ApplicationException(" Something unexpected happened")),},
                                            }
                                        },
                                        ConfirmationHandler = new WriteLine { Text = " CompensableActivity: Confirm Third Action" },
                                        CompensationHandler = new WriteLine { Text = " CompensableActivity: Compensate Third Action" },
                                        CancellationHandler = new Sequence
                                        {
                                            Activities = 
                                            {
                                                new WriteLine { Text = " Cancel Activity: Cancel Third Action" },                                                    
                                            }
                                        },                                                                                
                                        Result = tokenC
                                    },

                                  new WriteLine { Text = " End of Body of Top Level Activity" }
                                }                       
                            },
                            CompensationHandler = new WriteLine { Text = " CompensableActivity: Compensate Top Level Activity" },
                            ConfirmationHandler = new WriteLine { Text = " CompensableActivity: Confirm Top Level Activity " },                        
                            CancellationHandler = new Sequence 
                            {     
                                Activities = 
                                {                                                                                                                
                                    new Compensate 
                                    {
                                        Target = tokenA
                                    },
                                    new Compensate 
                                    {
                                        Target = tokenB
                                    },                                    
                                }
                            },                                                            
                        }
                    }                     
                },

                Catches = 
                {
                    new Catch<ApplicationException>
                    {
                        Action = new ActivityAction<ApplicationException>
                        {                             
                            Handler = new Sequence 
                            {     
                                Activities = 
                                {
                                    new WriteLine { Text = " Can write more code here for catching the exception.. " }                                                    
                                }
                            }
                        }                                                                     
                     } 
                }                                                                                              
            };
        }
        
        static WorkflowElement CancellingActivityInvokesCustomCancellation()
        {                       
            return new Parallel
            {
                // Timeout from branch causes other branch to cancel.
                CompletionCondition = true, 

                Branches =  
                {                     
                    // Delay Branch
                    new Sequence
                    {
                        Activities = 
                        { 
                            new Delay
                            {
                                Duration = TimeSpan.FromSeconds(2)
                            },                                                                                  
                            new WriteLine { Text = "Timeout from first branch; causing other branch to cancel.." },                            
                        }
                    },
 
                    new Sequence
                    { 
                        Activities = 
                        {                                                                                                                                                         
                            new CompensableActivity
                            {                                                                                                                          
                                Body = new Sequence()
                                {

                                    Activities = 
                                    {  
                                       new WriteLine { Text = " Entering Top Level Activity" },

                                       // First CompensableActivity
                                       new CompensableActivity
                                        {                                            
                                            Body = new WriteLine { Text = " CompensableActivity: Do First Action" },                                            

                                            ConfirmationHandler = new WriteLine { Text = " CompensableActivity: Confirm First Action" },
                                            CompensationHandler = new WriteLine { Text = " CompensableActivity: Compensate First Action" },                       
                                            CancellationHandler = new WriteLine { Text = " CompensableActivity: Concellation First Action" },                                           
                                        },

                                        // Second CompensableActivity
                                        new CompensableActivity
                                        {
                                            Body = new WriteLine { Text = " CompensableActivity: Do Second Action" },

                                            ConfirmationHandler = new WriteLine { Text = " CompensableActivity: Confirm Second Action" },
                                            CompensationHandler = new WriteLine { Text = " CompensableActivity: Compensate Second Action" },
                                            CancellationHandler = new WriteLine { Text = " CompensableActivity: Concellation Second Action" },                                            
                                        },  
 
                                        // Third CompensableActivity
                                        new CompensableActivity
                                        {
                                            Body = new Sequence {
                                                Activities = {
                                                    new Delay
                                                    {
                                                        Duration = TimeSpan.FromSeconds(3)
                                                    },
                                                    new WriteLine { Text = " CompensableActivity: Do Third Action" },                                                
                                                }
                                            },

                                            ConfirmationHandler = new WriteLine { Text = " CompensableActivity: Confirm Third Action" },
                                            CompensationHandler = new WriteLine { Text = " CompensableActivity: Compensate Third Action" },
                                            CancellationHandler = new WriteLine { Text = " CompensableActivity: Concellation Third Action" },                                            
                                        },                                                                                                                   
                                    }
                                },
                                CompensationHandler = new WriteLine { Text = " CompensableActivity: Compensate Top Level Activity " },                                
                                ConfirmationHandler = new WriteLine { Text = " CompensableActivity: Confirm Top Level Activity " },
                                CancellationHandler = new WriteLine { Text = " CompensableActivity: Cancel Top Level Activity " },                                                                
                            } 
                        }     
                    }
                }
            };
        }

        static void Main()
        {
            // Executing with cancellation where the order of process is changed. This scenario is intended to
            // demonstrate how cancellation works when the cause of the cancellaiton is an exception in the body of a compensable activity. 
            Console.WriteLine("************ Scenario 1 - Execution with Cancellation changing order ************");
            new WorkflowInvoker(ExceptionCausingCustomCancellation()).Invoke();

            // Executing with cancellation where the first branch timeout before the rest of the other branch 
            // completes. This scenario is intended to demonstrate how cancellation works if the activity is cancelled from an external source.             
            Console.WriteLine("************ Scenario 2 - Execution with Cancellation with Delay ************");
            new WorkflowInvoker(CancellingActivityInvokesCustomCancellation()).Invoke();
            
            Console.WriteLine("\nPress ENTER to exit");
            Console.ReadLine();
        }
    }
}
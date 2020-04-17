//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Sample.Compensation.AutoConfirmSample
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.Collections.Generic;
    using System.Threading;
    using System.IO;
    using System.Xaml;

    public class Program
    {
        static void Main()
        {
            WorkflowInstance instance;
            AutoResetEvent resetEvent = new AutoResetEvent(false);
            
            //Executing a sequence of four CompensableActivities. The second and third CA are nested in a 
            //AutoConfirmScope which will automatically confirm both CA when the CA completes. The first
            //and fourth CA will be confirmed once the workflow ends.
            Console.WriteLine("\nExecution with success:");
            new WorkflowInvoker(AutoConfirmScopeNormalExecution()).Invoke();
            
            //Executing a sequence of four CompensableActivities. The second and third CA are nested in a 
            //AutoConfirmScope which will automatically confirm both CA when the CA completes. An exception
            //occurs after the fourth CA. Since the first and fourth CA completed successfully and because the
            //workflow terminates with an exception they will be compensated. Since the second and third have
            //already been compensated nothing further will happen to them.
            Console.WriteLine("\nExecution with exception after the AutoConfirmScope:");
            instance = new WorkflowInstance(ExceptionAfterAutoConfirmScope());
            instance.OnCompleted = delegate(WorkflowCompletedEventArgs e) { resetEvent.Set(); };
            instance.OnUnhandledException = delegate(WorkflowUnhandledExceptionEventArgs e)
            {
                Console.WriteLine(e.UnhandledException.Message);
                return UnhandledExceptionAction.Cancel;
            };
            instance.Run();
            resetEvent.WaitOne();
            
            //Executing a sequence of four CompensableActivities. An exception occurs after the second
            //CompensableActivity has successfully completed causing the workflow to terminate. Since
            //the first two CompensableActivities have completed they will be compensated. The third and
            //fourth haven't executed so nothing will happen to them.
            Console.WriteLine("\nExecution with exception in the AutoConfirmScope:");
            instance = new WorkflowInstance(ExceptionInAutoConfirmScope());
            instance.OnCompleted = delegate(WorkflowCompletedEventArgs e) { resetEvent.Set(); };
            instance.OnUnhandledException = delegate(WorkflowUnhandledExceptionEventArgs e)
            {
                Console.WriteLine(e.UnhandledException.Message);
                return UnhandledExceptionAction.Cancel;
            }; 
            instance.Run();
            resetEvent.WaitOne();
          
            Console.WriteLine("\nPress ENTER to exit");
            Console.ReadLine();
        }

        static WorkflowElement AutoConfirmScopeNormalExecution()
        {
            return new Sequence()
            {
                Activities =
                {
                    new WriteLine() { Text = "Workflow begins" },
                    
                    new CompensableActivity()
                    {
                        Body = new WriteLine() { Text = "CompensableActivity1: Body" },
                        CompensationHandler = new WriteLine() { Text = "CompensableActivity1: Compensation Handler" },
                        ConfirmationHandler = new WriteLine() { Text = "CompensableActivity1: Confirmation Handler" },
                    },
             
                    new AutoConfirmScope()
                    {
                        Body = new Sequence()
                        {
                            Activities = 
                            {
                                new CompensableActivity()
                                {
                                    Body = new WriteLine() { Text = "CompensableActivity2: Body" },
                                    CompensationHandler = new WriteLine() { Text = "CompensableActivity2: Compensation Handler" },
                                    ConfirmationHandler = new WriteLine() { Text = "CompensableActivity2: Confirmation Handler" },
                                },
                            },
                        },
                    },

                    new CompensableActivity()
                    {
                        Body = new WriteLine() { Text = "CompensableActivity3: Body" },
                        CompensationHandler = new WriteLine() { Text = "CompensableActivity3: Compensation Handler" },
                        ConfirmationHandler = new WriteLine() { Text = "CompensableActivity3: Confirmation Handler" },
                    },

                    new WriteLine() { Text = "Workflow ends" },
                },
            };
        }

        static WorkflowElement ExceptionAfterAutoConfirmScope()
        {
            return new Sequence()
            {
                Activities =
                {
                    new WriteLine() { Text = "Workflow begins" },

                    new CompensableActivity()
                    {
                        Body = new WriteLine() { Text = "CompensableActivity1: Body" },
                        CompensationHandler = new WriteLine() { Text = "CompensableActivity1: Compensation Handler" },
                        ConfirmationHandler = new WriteLine() { Text = "CompensableActivity1: Confirmation Handler" },
                    },

                    new AutoConfirmScope()
                    {
                        Body = new Sequence()
                        {
                            Activities = 
                            {
                                new CompensableActivity()
                                {
                                    Body = new WriteLine() { Text = "CompensableActivity2: Body" },
                                    CompensationHandler = new WriteLine() { Text = "CompensableActivity2: Compensation Handler" },
                                    ConfirmationHandler = new WriteLine() { Text = "CompensableActivity2: Confirmation Handler" },
                                },

                                new CompensableActivity()
                                {
                                    Body = new WriteLine() { Text = "CompensableActivity3: Body" },
                                    CompensationHandler = new WriteLine() { Text = "CompensableActivity3: Compensation Handler" },
                                    ConfirmationHandler = new WriteLine() { Text = "CompensableActivity3: Confirmation Handler" },
                                },
                            },
                        },
                    },

                    new CompensableActivity()
                    {
                        Body = new WriteLine() { Text = "CompensableActivity4: Body" },
                        CompensationHandler = new WriteLine() { Text = "CompensableActivity4: Compensation Handler" },
                        ConfirmationHandler = new WriteLine() { Text = "CompensableActivity4: Confirmation Handler" },
                    },

                    new Throw()
                    {
                        Exception = new ApplicationException("Something unexpected happened"),
                    },

                    new WriteLine() { Text = "Workflow ends" },
                },
            };
        }

        static WorkflowElement ExceptionInAutoConfirmScope()
        {
            return new Sequence()
            {
                Activities =
                {
                    new WriteLine() { Text = "Workflow begins" },

                    new CompensableActivity()
                    {
                        Body = new WriteLine() { Text = "CompensableActivity1: Body" },
                        CompensationHandler = new WriteLine() { Text = "CompensableActivity1: Compensation Handler" },
                        ConfirmationHandler = new WriteLine() { Text = "CompensableActivity1: Confirmation Handler" },
                    },

                    new AutoConfirmScope()
                    {
                        Body = new Sequence()
                        {
                            Activities = 
                            {
                                new CompensableActivity()
                                {
                                    Body = new WriteLine() { Text = "CompensableActivity2: Body" },
                                    CompensationHandler = new WriteLine() { Text = "CompensableActivity2: Compensation Handler" },
                                    ConfirmationHandler = new WriteLine() { Text = "CompensableActivity2: Confirmation Handler" },
                                },

                                new Throw()
                                {
                                    Exception = new ApplicationException("Something unexpected happened"),
                                },

                                new CompensableActivity()
                                {
                                    Body = new WriteLine() { Text = "CompensableActivity3: Body" },
                                    CompensationHandler = new WriteLine() { Text = "CompensableActivity3: Compensation Handler" },
                                    ConfirmationHandler = new WriteLine() { Text = "CompensableActivity3: Confirmation Handler" },
                                },
                            },
                        },
                    },

                    new CompensableActivity()
                    {
                        Body = new WriteLine() { Text = "CompensableActivity4: Body" },
                        CompensationHandler = new WriteLine() { Text = "CompensableActivity4: Compensation Handler" },
                        ConfirmationHandler = new WriteLine() { Text = "CompensableActivity4: Confirmation Handler" },
                    },

                    new WriteLine() { Text = "Workflow ends" },
                },
            };
        }
    }
}

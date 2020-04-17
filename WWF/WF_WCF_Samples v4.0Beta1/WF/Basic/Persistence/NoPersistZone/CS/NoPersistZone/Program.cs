//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Activities;
using System.Activities.Statements;
using System.IO;
using System.ServiceModel.Persistence;
using System.Threading;

namespace Microsoft.Samples.NoPersistZone
{
    class Program
    {
        static void Main()
        {
            AutoResetEvent resetEvent = new AutoResetEvent(false);

            WorkflowElement program = CreateProgram();
            WorkflowInstance instance = StartWorkflowInstance(program, resetEvent);

            Interact(instance, resetEvent);

            // Open the file where the workflow wrote its output
            //System.Diagnostics.Process.Start("out.txt");
        }

        static WorkflowElement CreateProgram()
        {
            Variable<TextWriter> writer = new Variable<TextWriter>();
            Variable<string> input = new Variable<string> { Name = "input" };

            Sequence s = new Sequence()
            {
                Activities =
                {
                    new NoPeristZone()
                    {
                        Body = new TryCatch()
                        {
                            Variables = { writer },
                            Try = new Sequence() 
                            {
                                Activities =
                                {
                                    new CreateTextWriter()
                                    {
                                        // Output will appear in the out.txt file in the directory where the program runs
                                        Filename = "out.txt",
                                        Result = writer
                                    },
                                    new While()
                                    {
                                        Variables = { input },
                                        Condition = new VisualBasicValue<bool> { ExpressionText = "input <> \"exit\"" },
                                        Body = new Sequence()
                                        {
                                            Activities =
                                            {
                                                new If()
                                                {
                                                    Condition = new VisualBasicValue<bool> { ExpressionText = "input <> Nothing" },
                                                    Then = new WriteLine
                                                    {
                                                        Text = new VisualBasicValue<string> { ExpressionText = "\"Echo: \" & input" },
                                                        TextWriter = writer
                                                    }
                                                },
                                                new ReadLine()
                                                {
                                                    BookmarkName = "inputBookmark",
                                                    Result = input
                                                },
                                            }
                                        }
                                    }
                                }
                            },
                            Finally = new Dispose() { Target = writer }
                        }
                    }
                }
            };

            return s;
        }

        static WorkflowInstance StartWorkflowInstance(WorkflowElement program, AutoResetEvent resetEvent)
        {
            WorkflowInstance instance = new WorkflowInstance(program);
            instance.Extensions.Add(CreatePersistenceProvider(instance.Id));
            ResumeWorkflowInstance(instance, resetEvent);

            return instance;
        }

        static PersistenceProvider CreatePersistenceProvider(Guid id)
        {
            return new FilePersistenceProvider(id.ToString() + ".data", id);
        }

        static void ResumeWorkflowInstance(WorkflowInstance instance, AutoResetEvent resetEvent)
        {
            instance.OnCompleted = delegate(WorkflowCompletedEventArgs e)
            {
                Console.WriteLine("Workflow completed in state " + e.CompletionState);

                if (e.TerminationException != null)
                {
                    Console.WriteLine("Termination exception: " + e.TerminationException);
                }

                resetEvent.Set();
            };
            instance.OnUnloaded = delegate()
            {
                resetEvent.Set();
            };

            instance.Run();
        }

        static void Interact(WorkflowInstance instance, AutoResetEvent resetEvent)
        {
            Console.WriteLine("Workflow is ready for input");
            Console.WriteLine("Special commands: 'unload', 'exit'");

            bool done = false;
            while (!done)
            {
                string s = Console.ReadLine();
                if (s.Equals("unload"))
                {
                    try
                    {
                        // attempt to unload will fail if the workflow is idle within a NoPersistZone
                        instance.Unload(TimeSpan.FromSeconds(5));
                        done = true;
                    }
                    catch (TimeoutException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    instance.ResumeBookmark("inputBookmark", s);
                    if (s.Equals("exit"))
                    {
                        done = true;
                    }
                }
            }
            resetEvent.WaitOne();
        }
    }
}

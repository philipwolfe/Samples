//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Activities;
using System.Activities.Statements;
using System.Activities.DynamicUpdate;
using System.Activities.Hosting;
using System.Collections.Generic;
using System.ServiceModel.Persistence;
using System.Threading;

namespace Microsoft.Samples.DynamicUpdate
{
    class Program
    {
        static void Main()
        {
            AutoResetEvent resetEvent = new AutoResetEvent(false);

            Console.WriteLine("Starting a workflow instance...");
            WorkflowElement program = CreateProgram();
            WorkflowInstance instance = StartWorkflowInstance(program, resetEvent);

            // resume some bookmarks, then unload
            Interact(instance, resetEvent);

            Console.WriteLine("Hit <enter> to initiate dynamic update");
            Console.ReadLine();

            Console.WriteLine("Modifying program...");
            WorkflowElement modifiedProgram = ModifyProgram(CreateProgram());

            Console.WriteLine("Applying program changes to workflow instance...");
            ApplyProgramChanges(instance.Id, modifiedProgram);

            Console.WriteLine("Resuming workflow instance with modified program...");
            instance = LoadAndResumeWorkflowInstance(instance.Id, modifiedProgram, resetEvent);

            // resume some more bookmarks, then exit
            Interact(instance, resetEvent);
        }

        static WorkflowElement CreateProgram()
        {
            Variable<string> input = new Variable<string> { Name = "input" };

            return new While()
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
                                Text = new VisualBasicValue<string> { ExpressionText = "\"Original echo: \" & input" }
                            }
                        },
                        new ReadLine()
                        {
                            BookmarkName = "inputBookmark",
                            Result = input
                        },
                    }
                }
            };
        }

        static WorkflowInstance StartWorkflowInstance(WorkflowElement program, AutoResetEvent resetEvent)
        {
            WorkflowInstance instance = new WorkflowInstance(program);
            instance.Extensions.Add(CreatePersistenceProvider(instance.Id));
            ResumeWorkflowInstance(instance, resetEvent);

            return instance;
        }

        static WorkflowElement ModifyProgram(WorkflowElement program)
        {
            DynamicUpdateServices.PrepareForUpdate(program);

            While w = program as While;
            Sequence s = w.Body as Sequence;
            s.Activities.Add(
                new WriteLine()
                {
                    Text = new VisualBasicValue<string> { ExpressionText = "\"Dynamically added echo: \" & input" }
                }
            );

            DynamicUpdateServices.FinalizeUpdate(w);

            return w;
        }

        static void ApplyProgramChanges(Guid id, WorkflowElement modifiedProgram)
        {
            PersistenceProvider provider = CreatePersistenceProvider(id);
            object instanceState = provider.Load(TimeSpan.FromSeconds(30));

            IList<DynamicUpdateError> errors = DynamicUpdateServices.UpdateInstance(modifiedProgram, (IRuntimeState)instanceState);

            if (errors.Count > 0)
            {
                Console.WriteLine("Errors in dynamic update: ");
                foreach (DynamicUpdateError error in errors)
                {
                    Console.WriteLine(error);
                }

                return;
            }

            provider.Update(instanceState, TimeSpan.FromSeconds(30));
        }

        static WorkflowInstance LoadAndResumeWorkflowInstance(Guid id, WorkflowElement program, AutoResetEvent resetEvent)
        {
            WorkflowInstance instance = WorkflowInstance.Load(program, CreatePersistenceProvider(id));
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

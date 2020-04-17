//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel.Persistence;
using System.Threading;

namespace Microsoft.Samples.WF.WorkflowInstances
{
    class Program
    {
        static SqlPersistenceProviderFactory persistenceProviderFactory;
        static Guid id = Guid.NewGuid();
        static WorkflowElement workflow = CreateWorkflow();

        const int totalSteps = 3;
        const string echoPromptBookmark = "EchoPrompt1";

        static void Main()
        {
            SetupPersistence();

            Run();

            ClosePersistence();

            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }

        static void Run()
        {
            AutoResetEvent instanceUnloaded = new AutoResetEvent(false);
            WorkflowInstance instance = new WorkflowInstance(workflow, id);
            instance.Extensions.Add(persistenceProviderFactory.CreateProvider(id));
            SetupInstance(instance, instanceUnloaded);

            instance.Run();
            StepCountExtension stepCountExtension = instance.GetExtension<StepCountExtension>();
            instanceUnloaded.WaitOne();

            while (stepCountExtension.CurrentCount < totalSteps)
            {
                instance = WorkflowInstance.Load(workflow, persistenceProviderFactory.CreateProvider(id));                
                SetupInstance(instance, instanceUnloaded);
                string input = Console.ReadLine();

                instance.ResumeBookmark(echoPromptBookmark, input);
                stepCountExtension = instance.GetExtension<StepCountExtension>();
                instanceUnloaded.WaitOne();
            }
        }

        static void SetupInstance(WorkflowInstance instance, AutoResetEvent instanceUnloaded)
        {
            instance.OnIdle = () => IdleAction.Unload;
            instance.OnUnloaded = () => instanceUnloaded.Set();
            instance.OnUnhandledException = (wueea) => { Console.WriteLine(wueea.UnhandledException); return UnhandledExceptionAction.Terminate; };
        }

        static Sequence CreateWorkflow()
        {
            Variable<int> count = new Variable<int> { Name = "count", Default = totalSteps };
            Variable<int> stepsCounted = new Variable<int> { Name = "stepsCounted" };

            return new Sequence()
            {
                Variables = { count, stepsCounted },
                Activities = { 
                    new While {
                        Condition = ValueExpression.Create((env) => count.Get(env) > 0),
                        Body = new Sequence {
                            Activities = {
                                new EchoPrompt {BookmarkName = echoPromptBookmark },
                                new IncrementStepCount(),
                                new Assign<int>{ To = new OutArgument<int>(count), Value = new InArgument<int>((env) => count.Get(env) - 1)}
                            }
                        }
                    },
                    new GetCurrentStepCount {Result = new OutArgument<int>(stepsCounted )},
                    new WriteLine { Text = new InArgument<string>((env) => "there were " + stepsCounted.Get(env) + " steps in this program")}}
            };
        }

        static void SetupPersistence()
        {
            persistenceProviderFactory = new SqlPersistenceProviderFactory(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\SampleInstanceStore.mdf;Integrated Security=True", false, false, TimeSpan.FromSeconds(60));
            persistenceProviderFactory.Open();
        }

        static void ClosePersistence()
        {
            persistenceProviderFactory.Close();
        }
    }
}

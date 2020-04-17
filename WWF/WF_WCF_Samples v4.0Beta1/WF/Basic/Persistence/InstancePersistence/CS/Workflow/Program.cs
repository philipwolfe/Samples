//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.ServiceModel.Persistence;
using System.Threading;
using System.Activities;
using System.Activities.Statements;

namespace Microsoft.Samples.Activities
{
    class Program
    {
        static SqlPersistenceProviderFactory persistenceProviderFactory;
        static ManualResetEvent instanceCompleted = new ManualResetEvent(false);
        static ManualResetEvent instanceIdle = new ManualResetEvent(false);
        static AutoResetEvent instanceUnloaded = new AutoResetEvent(false);
        static WorkflowElement activity = CreateWorkflow();
        static Guid id;

        const string readLineBookmark = "ReadLine1";

        static void Main()
        {
            SetupPersistence();

            StartAndUnload();
            LoadAndComplete();

            ClosePersistence();

            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }

        static void StartAndUnload()
        {
            WorkflowInstance instance = new WorkflowInstance(activity);
            id = instance.Id;

            instance.Extensions.Add(persistenceProviderFactory.CreateProvider(id));

            //returning IdleAction.Unload instructs the WorkflowInstance to persists instance state and remove it from memory
            instance.OnIdle = () => IdleAction.Unload;
            instance.OnUnloaded = () => instanceUnloaded.Set();

            //Calling persist here captures the instance durably before it has been started
            instance.Persist();

            instance.Run();

            instanceUnloaded.WaitOne();
        }

        static void LoadAndComplete()
        {
            string input = Console.ReadLine();

            PersistenceProvider persistenceProvider = persistenceProviderFactory.CreateProvider(id);
            WorkflowInstance instance = WorkflowInstance.Load(activity, persistenceProvider);
            instance.Extensions.Add(persistenceProvider);

            instance.OnUnloaded = () => instanceUnloaded.Set();

            instance.ResumeBookmark(readLineBookmark, input);

            //PersistenceProvider.Delete is called when the workflow completes
            instanceUnloaded.WaitOne();
        }

        static Sequence CreateWorkflow()
        {
            Variable<string> response = new Variable<string>();

            return new Sequence()
            {
                Variables = { response },
                Activities = { 
                        new WriteLine(){
                            Text = new InArgument<string>("What is your name?")},
                        new ReadLine(){ 
                            BookmarkName = readLineBookmark, 
                            Result = new OutArgument<string>(response)},
                        new WriteLine(){
                            Text = new InArgument<string>((env) => "Hello " + response.Get(env))}}
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

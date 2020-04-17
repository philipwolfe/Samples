//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.WorkflowModel
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Activities;
    using System.Xaml;
    using System.Threading;
	using System.Reflection;
	
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //loading PresentationFramework so Xaml can resolve its types
            Assembly.Load("PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL");

            RunUnderApplication(XamlServices.Load(File.OpenRead("ShowWindow.xaml")) as WorkflowElement);
       
            Console.WriteLine("Press [ENTER] to quit");
            Console.ReadLine();

        }

        static void RunUnderApplication(WorkflowElement workflowElement)
        {
            Application application = new System.Windows.Application() { ShutdownMode = ShutdownMode.OnExplicitShutdown };
            application.Startup += delegate
            {
                WorkflowInstance instance = new WorkflowInstance(workflowElement, SynchronizationContext.Current);
                instance.OnCompleted = delegate(WorkflowCompletedEventArgs e)
                {
                    application.Shutdown();
                };
                instance.Run();
            };
            application.Run();
        }

    }
}

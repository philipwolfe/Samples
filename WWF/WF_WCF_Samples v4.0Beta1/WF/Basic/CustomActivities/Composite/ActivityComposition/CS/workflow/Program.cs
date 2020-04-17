//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.Activities
{
    using System;
    using System.Activities;
    using System.IO;
    using System.Threading;
    using System.Xaml;


    class Program
    {
        static void Main(string[] args)
        {
            ManualResetEvent workflowCompleted = new ManualResetEvent(false);
            ManualResetEvent workflowIdled = new ManualResetEvent(false);

            WorkflowElement activity;

            using (Stream stream = File.OpenRead("Program.xaml"))
            {
                activity = WorkflowXamlServices.Load(stream);
                stream.Close();
            }

            WorkflowInstance instance = new WorkflowInstance(activity);

            instance.OnCompleted = workflowCompletedEventArgs => workflowCompleted.Set();

            instance.OnIdle = () =>
            {
                workflowIdled.Set();
                return IdleAction.Nothing;
            };

            instance.Run();

            while (true)
            {
                string input = Console.ReadLine();

                workflowIdled.Reset();

                instance.ResumeBookmark("PromptBookmark", input);

                int signalled = WaitHandle.WaitAny(new WaitHandle[] { workflowCompleted, workflowIdled });

                if (signalled == 0)
                {
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press [ENTER] to exit.");

            Console.ReadLine();
        }
    }
}

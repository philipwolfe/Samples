//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading;
using System.Activities;
using System.Activities.Statements;

namespace Microsoft.Samples.Activities.PowerShellTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            AutoResetEvent syncEvent = new AutoResetEvent(false);

            WorkflowInstance myInstance = new WorkflowInstance(new Sequence1());

            myInstance.OnCompleted = delegate(WorkflowCompletedEventArgs e)
            {
                running = false;
                syncEvent.Set(); 
            };

            myInstance.OnIdle = delegate()
            {
                syncEvent.Set();
                return IdleAction.Nothing;
            };

            myInstance.OnUnhandledException = delegate(WorkflowUnhandledExceptionEventArgs e)
            {
                Console.WriteLine(e.UnhandledException.ToString());
                return UnhandledExceptionAction.Terminate;
            };

            myInstance.OnAborted = delegate(WorkflowAbortedEventArgs e)
            {
                Console.WriteLine(e.Reason);
                syncEvent.Set();
            };

            myInstance.Run();

            // main loop (manages bookmarks)
            while (running)
            {
                if (!syncEvent.WaitOne(10, false))
                {
                    if (running)
                    {
                        if (myInstance.GetAllBookmarks().Count > 0)
                        {
                            string bookmarkName = myInstance.GetAllBookmarks()[0].BookmarkName;
                            myInstance.ResumeBookmark(bookmarkName, Console.ReadLine());
                            syncEvent.WaitOne();
                        }
                    }
                }
            }

            System.Console.WriteLine("The program has ended. Please press <enter> to continue...");
            System.Console.ReadKey();
        }
    }
}

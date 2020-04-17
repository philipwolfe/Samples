namespace Microsoft.Samples.GuessingGame
{
    using System;
    using System.Activities;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            // create the workflow instance and start its execution
            AutoResetEvent syncEvent = new AutoResetEvent(false);
            WorkflowInstance instance = new WorkflowInstance(new GuessingGameWF());
            instance.OnCompleted = delegate(WorkflowCompletedEventArgs e) { running = false; syncEvent.Set(); };
            instance.OnIdle = delegate()
            {
                syncEvent.Set();
                return IdleAction.Nothing;
            };
            instance.Run();

            // main loop (manages bookmarks)
            while (running)
            {
                if (!syncEvent.WaitOne(10, false))
                {
                    if (running)
                    {
                        if (instance.GetAllBookmarks().Count > 0)
                        {
                            string bookmarkName = instance.GetAllBookmarks()[0].BookmarkName;
                            instance.ResumeBookmark(bookmarkName, Console.ReadLine());
                            syncEvent.WaitOne();
                        }
                    }
                }
            }

            // wait for user input
            Console.ReadKey();
        }        
    }
}

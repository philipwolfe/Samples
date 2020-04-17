//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Bookmarks
{
    using System;
    using System.Collections;
    using System.Activities;
    using System.Activities.Statements;
    using System.Threading;
    using System.Xml;

    class Program
    {
        static WorkflowElement CreateWorkflow()
        {
            Variable<string> x = new Variable<string>();
            Variable<string> y = new Variable<string>();
            Variable<string> z = new Variable<string>();

            return new Sequence
            {
                Variables = { x, y, z },
                Activities = 
                {
                    new System.Activities.Statements.Parallel
                    {
                        Branches =
                        {
                            new Read<string>() { BookmarkName = "x", Result = x },
                            new Read<string>() { BookmarkName = "y", Result = y },
                            new Read<string>() { BookmarkName = "z", Result = z }                           
                        }
                    },
                    new WriteLine()
                    { 
                        Text = new InArgument<string>((env) => x.Get(env) + y.Get(env) + z.Get(env)) 
                    }
                }
            };
        }

        static void Main()
        {
            ManualResetEvent completionEvent = new ManualResetEvent(false);
            AutoResetEvent idleEvent = new AutoResetEvent(false);

            WorkflowElement workflow = CreateWorkflow();
            WorkflowInstance instance = new WorkflowInstance(workflow);
            instance.OnIdle += delegate
            {
                idleEvent.Set();
                return IdleAction.Nothing;
            };
            instance.OnCompleted += delegate
            {
                completionEvent.Set();
            };

            instance.Run();

            bool lastBookmark = false;
            while (!lastBookmark)
            {
                idleEvent.WaitOne();

                IList bookmarks = instance.GetAllBookmarks();
                if (bookmarks == null || bookmarks.Count == 0)
                {
                    break;
                }

                lastBookmark = (bookmarks.Count == 1);

                while (true)
                {
                    Console.Write("Bookmarks:");
                    foreach (BookmarkInfo info in bookmarks)
                    {
                        Console.Write(" '" + info.BookmarkName + "'");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Enter the name of the bookmark to resume");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the payload for the bookmark '{0}'", name);
                    string str = Console.ReadLine();

                    try
                    {
                        instance.ResumeBookmark(name, str);
                        break;
                    }
                    catch (BookmarkNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            completionEvent.WaitOne();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}

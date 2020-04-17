//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.IO;
using System.Threading;
using System.Activities;
using System.Activities.Statements;

namespace Microsoft.Samples.Pick
{
    public class PickSample
    {
        static WorkflowInstance instance;

        public static void Main(string[] args)
        {
            Thread readLineThread = new Thread(new ThreadStart(ReadTextFromConsole));
            readLineThread.IsBackground = true;

            Console.WriteLine("What is you name? (You have 5 seconds to answer)");

            // Create the workflow instance and start its execution
            AutoResetEvent syncEvent = new AutoResetEvent(false);
            instance = new WorkflowInstance(CreateWF());
            instance.OnCompleted = delegate(WorkflowCompletedEventArgs e)
            {
                Console.WriteLine("The workflow has completed");
                syncEvent.Set();

                if (readLineThread.IsAlive && readLineThread != null)
                {
                    readLineThread.Abort();
                }

            };
            instance.OnIdle = delegate()
            {
                syncEvent.Set();
                return IdleAction.Nothing;
            };

            readLineThread.Start();
            instance.Run();

            syncEvent.WaitOne();

            Console.WriteLine("Press <return> to continue...");
            Console.ReadLine();
        }

        public static void ReadTextFromConsole()
        {
            string text = Console.ReadLine();
            instance.ResumeBookmark("name", text);
        }

        private static WorkflowElement CreateWF()
        {
            Variable<string> name = new Variable<string>();
            // Body
            Sequence body = new Sequence()
            {
                Variables = { name },
                Activities = 
               {
                   new System.Activities.Statements.Pick
                    {
                       Branches = 
                       {
                           new PickBranch
                            {
                               Trigger = new ReadLine
                                {
                                   Result = name,
                                   BookmarkName = "name"
                                },
                               Action = new WriteLine 
                               { 
                                   Text = ValueExpression.Create(ctx => "Hello " + 
                                       name.Get(ctx)) 
                               }
                           },
                           new PickBranch
                            {
                               Trigger = new Delay
                                {
                                   Duration = new TimeSpan(0, 0, 5)
                               },
                               Action = new WriteLine
                                {
                                   Text = "Time is up."
                                }
                           }
                       }
                   }
               }
            };

            return body;
        }
    }
}

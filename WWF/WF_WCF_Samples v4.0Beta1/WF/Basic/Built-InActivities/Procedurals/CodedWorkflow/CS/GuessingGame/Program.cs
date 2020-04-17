//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.ProceduralActivities.GuessingGame
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            // create the workflow instance and start its execution
            AutoResetEvent syncEvent = new AutoResetEvent(false);
            WorkflowInstance instance = new WorkflowInstance(CreateGuessingGameWF());
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

        // Create a number guessing game workflow program. This workflow
        // combines several out of the box activities (Sequence, If, 
        // WriteLine, Assign, While, TryCatch, Switch, Expressions) 
        // and two custom activities included in this project (ReadLine and PromptIt).
        static WorkflowElement CreateGuessingGameWF()
        {
            Variable<int> attempts = new Variable<int>() { Name = "attempts", Default = 0 };
            Variable<int> numberToGuess = new Variable<int>() { Name = "numberToGuess" };
            Variable<int> numberFromUser = new Variable<int>() { Name = "numberFromUser" };
            Variable<bool> finished = new Variable<bool>() { Name = "finished", Default = false };            

            return
                new Sequence()
                {
                    DisplayName = "Main Sequence",
                    Variables = { numberToGuess, finished, numberFromUser, attempts },
                    Activities =
                    {
                        new WriteLine() { Text = "Starting Game..." },
                        new Assign<int>()
                        {
                            DisplayName = "Set Random Number to Guess",
                            To = new OutArgument<int>(numberToGuess),
                            Value = new InArgument<int>(env => new Random().Next(1, 100))
                        },
                        new While()
                        {
                            DisplayName = "Main Loop",
                            Condition = ValueExpression.Create<bool>(env => !finished.Get(env)),                        
                            Body = new Sequence()
                            {
                                Activities = 
                                {
                                    new Assign<int>()
                                    {
                                        DisplayName = "Increment Attempts",
                                        To = new OutArgument<int>(attempts),
                                        Value = new InArgument<int>(env => attempts.Get(env) + 1)
                                    },
                                    new TryCatch()
                                    {                                        
                                        Try = 
                                        new Sequence
                                        {
                                            DisplayName = "Try Catch (getting valid user input)",
                                            Activities =
                                            {
                                                new PromptInt()
                                                {
                                                    DisplayName = "Prompt Value to User",
                                                    Text = "What is your guess?",
                                                    Result = new OutArgument<int>(numberFromUser)
                                                },
                                                new Switch<int>()
                                                {
                                                    DisplayName = "Verify Value from User",
                                                    Expression = ValueExpression.Create<int>( env => numberFromUser.Get(env).CompareTo(numberToGuess.Get(env)) ),
                                                    Cases = 
                                                    {
                                                        { 0, new Assign<bool>()
                                                            {
                                                                To = new OutArgument<bool>(finished),
                                                                Value = true
                                                            }
                                                        },
                                                        {  1, new WriteLine() { Text = "    Try a lower number number..." } }, 
                                                        { -1, new WriteLine() { Text = "    Try a higher number" } }
                                                    }
                                                }
                                            }
                                        },
                                        Catches =
                                        {
                                            new Catch<Exception>()
                                            {
                                                Action = new ActivityAction<Exception>
                                                {
                                                    DisplayName = "Wrong Input",
                                                    Handler = new WriteLine() { Text = "   Hey! You must enter a integer number." }
                                                }
                                            }
                                        }
                                    }                                    
                                }
                            }
                        },
                        new If()
                        {
                            DisplayName = "Display Final Message",
                            Condition = ValueExpression.Create<bool>(env => attempts.Get(env) < 7),
                            Then = new WriteLine() { Text = new InArgument<string>(env => string.Format("Congratulations, you've found it in {0} attempts!!!", attempts.Get(env))) },
                            Else = new WriteLine() { Text = new InArgument<string>(env => string.Format("You've found it in {0} attempts...You need more practice!", attempts.Get(env))) }
                        }
                    }
            };
        }
    }
}
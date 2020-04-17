//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Activities;
using System.Activities.Statements;

namespace Microsoft.Samples.GuessingGame
{
    public sealed class PromptInt : Activity
    {
        public InArgument<string> Text { get; set; }
        public OutArgument<int> Result { get; set; }

        protected override WorkflowElement CreateBody()
        {
            Variable<string> tmp = new Variable<string>();
            return
                new Sequence()
                {
                    Variables = { tmp },
                    Activities = 
                    {
                        new WriteLine() { Text = new InArgument<string>(env => this.Text.Get(env)) } ,
                        new ReadLine() 
                        { 
                             BookmarkName = new InArgument<string>(env => "Prompt-" + Text.Get(env)),
                             Result= new OutArgument<string>(tmp)                              
                        },
                        new Assign<int>
                        {
                             Value= new InArgument<int>(env => Convert.ToInt32(tmp.Get(env))),
                             To = new OutArgument<int>(env => this.Result.Get(env))
                        }
                    }
                };
        }
    }
}

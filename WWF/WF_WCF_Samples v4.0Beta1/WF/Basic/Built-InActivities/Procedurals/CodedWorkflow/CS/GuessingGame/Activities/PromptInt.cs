//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.ProceduralActivities.GuessingGame
{
    using System;
    using System.Activities;
    using System.Activities.Statements;

    /// <summary>
    /// This activity presents some text to the user and prompts for an Int value. 
    /// To achieve this goal, this activity leverages other existing activities
    /// (ReadLine and WriteLine).
    /// </summary>
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

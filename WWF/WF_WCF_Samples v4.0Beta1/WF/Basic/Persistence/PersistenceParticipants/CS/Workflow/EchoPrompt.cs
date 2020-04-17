//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;

namespace Microsoft.Samples.WF.WorkflowInstances
{
    public sealed class EchoPrompt: NativeActivity
    {
        WriteLine output;
        Variable<string> outputText = new Variable<string> { Name = "outputText" };

        [IsRequired]
        public InArgument<string> BookmarkName { get; set; }

        protected override void OnGetPrivateVariables(IList<Variable> variables)
        {
            variables.Add(outputText);
        }

        protected override void OnGetPrivateChildren(IList<WorkflowElement> children, DeclaredEnvironment environment)
        {
            this.output = new WriteLine { Text = new InArgument<string>(outputText) };
            children.Add(this.output);
        }

        protected override void Execute(ActivityExecutionContext context)
        {
            string name = this.BookmarkName.Get(context);
            
            this.outputText.Set(context, "Please enter a value: ");            
            context.ScheduleActivity(output);
            context.CreateNamedBookmark(name, new BookmarkCallback(OnReadComplete));
        }

        void OnReadComplete(ActivityExecutionContext context, Bookmark bookmark, object state)
        {
            string input = state as string; 
            
            if (input == null)
            {
                throw new Exception(string.Format("EchoPrompt {0}: EchoPrompt must be resumed with a non-null string", this.DisplayName));
            }

            this.outputText.Set(context, "you said: " + input);
            context.ScheduleActivity(output);
        }
    }
}


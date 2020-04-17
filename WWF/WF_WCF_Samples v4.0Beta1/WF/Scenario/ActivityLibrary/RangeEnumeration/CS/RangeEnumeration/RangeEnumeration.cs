//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Activities;
using System.Activities.Statements;
using System.Windows.Markup;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Microsoft.Samples.RangeEnumeration
{
    // Custom Activity RangeEnumeration
    [ContentProperty("Body")]
    public sealed class RangeEnumeration : NativeActivity
    {
        private Variable<int> loopVariable;
        private Variable<bool> onBreak;
        private InvokeAction<int> invokeBody;

        public RangeEnumeration()
        {
            this.onBreak = new Variable<bool>();
            this.loopVariable = new Variable<int>();
            this.invokeBody = new InvokeAction<int>
            {
                Argument = this.loopVariable,
            };
        }

        [DefaultValue(null)]
        public InArgument<int> Start { get; set; }

        [DefaultValue(null)]
        public InArgument<int> Stop { get; set; }

        [DefaultValue(null)]
        public InArgument<int> Step { get; set; }

        // The loop body
        [DefaultValue(null)]
        public ActivityAction<int> Body { get; set; }

        protected override void OnGetChildren(IList<WorkflowElement> children)
        {
            if (this.Body != null && this.Body.Handler != null)
            {
                this.invokeBody.Action = this.Body;
                children.Add(this.invokeBody);
            }
        }

        protected override void OnGetEnvironmentVariables(IList<Variable> variables)
        {
            variables.Add(this.onBreak);
            variables.Add(this.loopVariable);
        }

        protected override void Execute(ActivityExecutionContext context)
        {
            int start = this.Start.Get(context);
            int stop = this.Stop.Get(context);
            int step = this.Step.Get(context);

            if (this.Body != null && this.Body.Handler != null && Condition(start, stop, step))
            {
                this.loopVariable.Set(context, start);
                RunIteration(context, null);
            }
        }

        // Add step value to loop variable after loop body is executed.
        void AddStep(ActivityExecutionContext context, ActivityInstance completedInstance)
        {
            int value = this.loopVariable.Get(context);
            int step = this.Step.Get(context);
            value += step;
            this.loopVariable.Set(context, value);
            int stop = this.Stop.Get(context);

            if (Condition(value, stop, step) && !this.onBreak.Get(context))
            {
                RunIteration(context, completedInstance);
            }
            else
            {
                if (completedInstance != null)
                {
                    if (context.ExecutingActivityInstance.HasCancelBeenRequested &&
                       (completedInstance.State == ActivityInstanceState.Faulted ||
                        completedInstance.State == ActivityInstanceState.Canceled))
                    {
                        // Cancel the last iteration.
                        context.MarkCanceled();
                    }
                }
            }
        }

        bool Condition(int start, int stop, int step)
        {
            return (step > 0 && start <= stop) ||
              (step < 0 && start >= stop) ||
              (step == 0);
        }

        void RunIteration(ActivityExecutionContext context, ActivityInstance completedInstance)
        {
            if (context.ExecutingActivityInstance.HasCancelBeenRequested)
            {
                context.MarkCanceled();
                return;
            }
            context.ScheduleActivity(this.invokeBody, this.AddStep);
        }
    }
}

//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Collections.ObjectModel;

namespace Microsoft.Samples.Scenarios.Common.Activities
{
    public sealed class MyWhile : NativeActivity
    {
        public MyWhile()
        {
            this.Variables = new Collection<Variable>();
        }
        
        public Collection<Variable> Variables { get; set; }
        public WorkflowElement<bool> Condition  { get; set; }
        public WorkflowElement Body { get; set; }

        protected override void OnGetArguments(IList<RuntimeArgument> arguments)
        {
            // no arguments are available on Sequence
        }
        
        protected override void OnOpen(DeclaredEnvironment environment)
        {
            base.OnOpen(environment);

            if (this.Condition == null)
            {
                throw new ValidationException(string.Format("While {0} requires a Condition", this.DisplayName));
            }
        }

        protected override void Execute(ActivityExecutionContext context)
        {
            InternalExecute(context, null);
        }

        void InternalExecute(ActivityExecutionContext context, ActivityInstance instance)
        {
            context.ScheduleActivity(this.Condition, new CompletionCallback<bool>(OnEvaluateConditionCompleted));
        }

        void OnEvaluateConditionCompleted(ActivityExecutionContext context, ActivityInstance instance, bool result)
        {
            if (result)
            {
                if (this.Body != null)
                {
                    context.ScheduleActivity(this.Body, InternalExecute);
                }
            }

        }
    }
}

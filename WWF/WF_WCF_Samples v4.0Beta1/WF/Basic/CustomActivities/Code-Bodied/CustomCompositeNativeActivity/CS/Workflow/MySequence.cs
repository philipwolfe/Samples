//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Samples.Scenarios.Common.Activities
{
    using System;
    using System.Activities;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public sealed class MySequence : NativeActivity
    {
        Collection<WorkflowElement> children;
        Collection<Variable> variables;
        Variable<int> currentIndex;
        CompletionCallback onChildComplete;

        public MySequence()
            : base()
        {
            this.children = new Collection<WorkflowElement>();
            this.variables = new Collection<Variable>();
            this.currentIndex = new Variable<int>();
        }

        public Collection<WorkflowElement> Activities
        {
            get
            {
                return this.children;
            }
        }

        public Collection<Variable> Variables
        {
            get
            {
                return this.variables;
            }
        }

        protected override void OnGetArguments(IList<RuntimeArgument> arguments)
        {
            // no arguments are available on Sequence
        }

        protected override void OnGetEnvironmentVariables(IList<Variable> variables)
        {
            foreach (Variable variable in this.variables)
            {
                variables.Add(variable);
            }
        }

        protected override void OnGetPrivateVariables(IList<Variable> variables)
        {
            variables.Add(this.currentIndex);
        }

        protected override void Execute(
            ActivityExecutionContext context)
        {
            InternalExecute(context, null);
        }

        void InternalExecute(ActivityExecutionContext context, ActivityInstance instance)
        {
            int currentActivityIndex = this.currentIndex.Get(context);
            if (currentActivityIndex == Activities.Count)
            {
                return;
            }

            if (this.onChildComplete == null)
            {
                this.onChildComplete = new CompletionCallback(InternalExecute);
            }

            WorkflowElement nextChild = Activities[currentActivityIndex];
            context.ScheduleActivity(nextChild, this.onChildComplete);

            this.currentIndex.Set(context, ++currentActivityIndex);
        }
    }
}

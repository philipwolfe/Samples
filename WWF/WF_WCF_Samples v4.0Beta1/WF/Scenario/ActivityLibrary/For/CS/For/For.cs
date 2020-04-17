//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Activities;
using System.Windows.Markup;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Activities.Validation;

namespace Microsoft.Samples.For
{
    [ContentProperty("Body")]
    public sealed class For : NativeActivity
    {
        private CompletionCallback onInitComplete;
        private CompletionCallback<bool> onConditionComplete;
        private CompletionCallback onIterationComplete;
        private CompletionCallback onBodyComplete;

        private Collection<Variable> variables;

        public For()
            : base()
        {
        }

        // InitAction for "For", eg. (int i=0;...)
        [DefaultValue(null)]
        public WorkflowElement InitAction { get; set; }

        // IterationAction for "For", eg. for(...;...;i++)
        [DefaultValue(null)]
        public WorkflowElement IterationAction { get; set; }

        // The loop body
        [DefaultValue(null)]
        public WorkflowElement Body { get; set; }

        // The loop condition, eg. for(...; i<10; ...)
        [DefaultValue(null)]
        public WorkflowElement<bool> Condition { get; set; }

        // The variables can be accessed by loop body, InitAction, IterationAction and Condition
        public Collection<Variable> Variables
        {
            get
            {
                if (this.variables == null)
                {
                    this.variables = new DesignTimeAwareCollection<Variable>(this);
                }
                return this.variables;
            }
        }

        protected override void OnGetEnvironmentVariables(IList<Variable> variables)
        {
            if (this.variables != null)
            {
                foreach (Variable variable in this.variables)
                {
                    variables.Add(variable);
                }
            }
        }

        protected override void OnOpen(DeclaredEnvironment environment)
        {
            if (this.Condition == null)
            {
                throw new ValidationException("The Condition property of For is required.");
            }

            base.OnOpen(environment);
        }

        protected override void OnGetConstraints(IList<Constraint> constraints)
        {
            Variable<For> activity = new Variable<For> { Name = "constraintArg" };
            constraints.Add(
                new Constraint<For>
                {
                    Body = new ActivityAction<For,ValidationContext>
                    {
                        Argument1 = activity,
                        Handler = new AssertValidation
                        {
                            Assertion = ValueExpression.Create(ctx => activity.Get(ctx).Condition != null),
                            Message = ValueExpression.Create(ctx => "The Condition property of For is required.")
                        }
                    }
                });
        }

        protected override void Execute(ActivityExecutionContext context)
        {
            if (this.InitAction != null)
            {
                if (this.onInitComplete == null)
                {
                    this.onInitComplete = new CompletionCallback(OnInitCompleted);
                }

                context.ScheduleActivity(this.InitAction, this.onInitComplete);
            }
            else if (this.Condition != null)
            {
                ScheduleCondition(context);
            }
            else if (this.Body != null)
            {
                ScheduleBody(context);
            }
            else if (this.IterationAction != null)
            {
                ScheduleIteration(context);
            }
        }

        void OnInitCompleted(ActivityExecutionContext context, ActivityInstance completedInstance)
        {
            if (this.Condition != null)
            {
                ScheduleCondition(context);
            }
            else if (this.Body != null)
            {
                ScheduleBody(context);
            }
            else if (this.IterationAction != null)
            {
                ScheduleIteration(context);
            }
        }

        void ScheduleCondition(ActivityExecutionContext context)
        {
            if (this.onConditionComplete == null)
            {
                this.onConditionComplete = new CompletionCallback<bool>(OnConditionComplete);
            }

            context.ScheduleActivity(this.Condition, this.onConditionComplete);
        }

        void OnConditionComplete(ActivityExecutionContext context, ActivityInstance completedInstance, bool result)
        {
            if (result)
            {
                if (this.Body != null)
                {
                    ScheduleBody(context);
                }
                else if (this.IterationAction != null)
                {
                    ScheduleIteration(context);
                }
                else
                {
                    ScheduleCondition(context);
                }
            }
        }

        void ScheduleBody(ActivityExecutionContext context)
        {
            if (this.onBodyComplete == null)
            {
                this.onBodyComplete = new CompletionCallback(OnBodyComplete);
            }

            context.ScheduleActivity(this.Body, this.onBodyComplete);
        }

        // After InitAction, IterationAction or Condition evaluation,  try to run iteration.
        void OnBodyComplete(ActivityExecutionContext context, ActivityInstance completedInstance)
        {
            if (this.IterationAction != null)
            {
                ScheduleIteration(context);
            }
            else if (this.Condition != null)
            {
                ScheduleCondition(context);
            }
            else
            {
                ScheduleBody(context);
            }
        }

        void ScheduleIteration(ActivityExecutionContext context)
        {
            if (this.onIterationComplete == null)
            {
                this.onIterationComplete = new CompletionCallback(OnIterationComplete);
            }

            context.ScheduleActivity(this.IterationAction, this.onIterationComplete);
        }

        void OnIterationComplete(ActivityExecutionContext context, ActivityInstance completedInstance)
        {
            if (this.Condition != null)
            {
                ScheduleCondition(context);
            }
            else if (this.Body != null)
            {
                ScheduleBody(context);
            }
            else
            {
                ScheduleIteration(context);
            }
        }
    }
}
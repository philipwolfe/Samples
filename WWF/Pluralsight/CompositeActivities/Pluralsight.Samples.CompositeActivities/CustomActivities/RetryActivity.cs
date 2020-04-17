using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace CustomActivities
{
    [Designer(typeof(RetryActivityDesigner), typeof(IDesigner))]
	public partial class RetryActivity: CompositeActivity
	{

        private int curRetryIndex;

        [Browsable(false)]
        public int CurrentRetryAttempt
        {
            get { return curRetryIndex; }
            set { curRetryIndex = value; }
        }

        
        public static DependencyProperty RetryCountProperty = System.Workflow.ComponentModel.DependencyProperty.Register("RetryCount", typeof(int), typeof(RetryActivity), new PropertyMetadata(0));

        [Description("The number of times the execution should be retried")]
        [Category("Retry")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int RetryCount
        {
            get
            {
                return ((int)(base.GetValue(RetryActivity.RetryCountProperty)));
            }
            set
            {
                base.SetValue(RetryActivity.RetryCountProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            if (EnabledActivities.Count == 0)
                return ActivityExecutionStatus.Closed;

            BeginIteration(executionContext);
            return ActivityExecutionStatus.Executing;
        }

        private void BeginIteration(ActivityExecutionContext executionContext)
        {
            Activity child = EnabledActivities[0];
            ActivityExecutionContext newContext = executionContext.ExecutionContextManager.CreateExecutionContext(child);
            newContext.Activity.Closed += new EventHandler<ActivityExecutionStatusChangedEventArgs>(child_Closed);
            newContext.Activity.Faulting += new EventHandler<ActivityExecutionStatusChangedEventArgs>(Activity_Faulting);
            newContext.ExecuteActivity(newContext.Activity);
        }

        void Activity_Faulting(object sender, ActivityExecutionStatusChangedEventArgs e)
        {
            e.Activity.Faulting -= Activity_Faulting;
            if(CurrentRetryAttempt < RetryCount)
                e.Activity.SetValue(ActivityExecutionContext.CurrentExceptionProperty, null);
        }

        void child_Closed(object sender, ActivityExecutionStatusChangedEventArgs e)
        {
            ActivityExecutionContext thisContext = sender as ActivityExecutionContext;
            ActivityExecutionContext childContext = thisContext.ExecutionContextManager.GetExecutionContext(e.Activity);
            e.Activity.Closed -= child_Closed;

            thisContext.ExecutionContextManager.CompleteExecutionContext(childContext);

            //if the child completed successfully, then we can close
            if (e.ExecutionResult == ActivityExecutionResult.Succeeded)
            {
                this.SetValue(ActivityExecutionContext.CurrentExceptionProperty, null);
                thisContext.CloseActivity();
                return;
            }

            //otherwise, if we are not done retrying
            //we need to execute again and make sure to clean up errors
            if (CurrentRetryAttempt++ < RetryCount)
            {
                this.SetValue(ActivityExecutionContext.CurrentExceptionProperty, null);
                BeginIteration(thisContext);
                return;
            }
            else
            {
                //if we are done retrying, then we should let the exceptions bubble up
                thisContext.CloseActivity();
            }
        }
  
	}
}

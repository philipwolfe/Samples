using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace CustomActivities
{
    [Designer(typeof(PartialCompletionActivityDesigner), typeof(IDesigner))]
    [ToolboxItem(typeof(PartialCompletionToolboxItem))]
    [ActivityValidator(typeof(PartialCompletionActivityValidator))]
	public partial class PartialCompletionActivity: CompositeActivity
	{
        private int reqComp;

        public int RequiredCompletions
        {
            get { return reqComp; }
            set { reqComp = value; }
        }

        int numClosed = 0;

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            if (EnabledActivities.Count == 0)
                return ActivityExecutionStatus.Closed;

            foreach (Activity child in EnabledActivities)
            {
                child.Closed += new EventHandler<ActivityExecutionStatusChangedEventArgs>(child_Closed);
                executionContext.ExecuteActivity(child);
            }

            return ActivityExecutionStatus.Executing;

        }

        void child_Closed(object sender, ActivityExecutionStatusChangedEventArgs e)
        {
            ActivityExecutionContext context = sender as ActivityExecutionContext;
            e.Activity.Closed -= child_Closed;

            if (++numClosed >= RequiredCompletions)
            {
                bool canClose = true;

                foreach (Activity child in EnabledActivities)
                {
                    if (child.ExecutionStatus != ActivityExecutionStatus.Closed)
                    {
                        canClose = false;
                        context.CancelActivity(child);
                    }
                }

                if (canClose)
                    context.CloseActivity();

            }

        }

	}
}

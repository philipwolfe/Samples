using System;
using System.Workflow.ComponentModel;
using System.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.ComponentModel.Design;

 
namespace EssentialWF.Activities {
    [Designer(typeof(SequenceDesigner),typeof(IDesigner))]
    public class Sequence : CompositeActivity {
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {
            if (this.EnabledActivities.Count == 0) return ActivityExecutionStatus.Closed;

            Activity child = this.EnabledActivities[0];
            child.Closed += ContinueAt;
            context.ExecuteActivity(child);

            return ActivityExecutionStatus.Executing;
        }

        void ContinueAt(object sender, ActivityExecutionStatusChangedEventArgs e) {
            e.Activity.Closed -= ContinueAt;

            ActivityExecutionContext context = sender as ActivityExecutionContext;

            if (this.ExecutionStatus == ActivityExecutionStatus.Executing) {
                int index = this.EnabledActivities.IndexOf(e.Activity);

                if (index == this.EnabledActivities.Count - 1)
                    context.CloseActivity();
                else {
                    Activity child = this.EnabledActivities[index + 1];

                    child.Closed += ContinueAt;
                    context.ExecuteActivity(child);
                }
            }
        }
        //cancellation/fault handling
        //...
    }
}

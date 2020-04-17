using System;
using System.Collections;
using System.Workflow.ComponentModel;

namespace EssentialWF.Activities { 
    public class Interleave : CompositeActivity {

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {
            if (this.EnabledActivities.Count == 0) 
                return ActivityExecutionStatus.Closed;

            ArrayList list = new ArrayList(this.EnabledActivities);
            //shuffle this list to cause interleavings of immidiate children...

            for (int n = 0; n < list.Count; ++n) {
                Activity child = list[n] as Activity;

                child.Closed += ContinueAt;
                context.ExecuteActivity(child);
            }

            return ActivityExecutionStatus.Executing;
        }

        void ContinueAt(object sender,  ActivityExecutionStatusChangedEventArgs e) {
            e.Activity.Closed -= ContinueAt;

            ActivityExecutionContext context = sender as ActivityExecutionContext;

            if (this.ExecutionStatus == ActivityExecutionStatus.Executing) {
                foreach (Activity child in this.EnabledActivities) {
                    if (child.ExecutionStatus != ActivityExecutionStatus.Closed)
                        return;
                }
                context.CloseActivity();
            }
            // canceling or faulting
            else  {
                 bool okToClose = true;
                 foreach (Activity child in this.EnabledActivities) {
                     ActivityExecutionStatus status = child.ExecutionStatus;
                     if (status == ActivityExecutionStatus.Executing) {
                         okToClose = false;
                         context.CancelActivity(child);
                     }
                     else if ((status != ActivityExecutionStatus.Closed) ||
                       (status != ActivityExecutionStatus.Initialized)) {
                         okToClose = false;
                     }
                 }
                 if (okToClose)
                     context.CloseActivity();
             }
        }
        protected override ActivityExecutionStatus Cancel(ActivityExecutionContext context) {
            bool okToClose = true;

            for (int n = 0; n < EnabledActivities.Count; n++) {
                Activity child = EnabledActivities[n];
                
                if (child.ExecutionStatus == ActivityExecutionStatus.Executing) {
                    context.CancelActivity(child);
                    okToClose = false;
                }
                else if ((child.ExecutionStatus != ActivityExecutionStatus.Initialized) && (child.ExecutionStatus != ActivityExecutionStatus.Closed)) {
                    okToClose = false;
                }
            }

            if (okToClose)
                return ActivityExecutionStatus.Closed;

            return ActivityExecutionStatus.Canceling;
        }
    }
}



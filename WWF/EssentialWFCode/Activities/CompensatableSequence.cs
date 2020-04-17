using System;
using System.Workflow.ComponentModel;

namespace EssentialWF.Activities {
    public class CompensatableSequence : Sequence, ICompensatableActivity {
        ActivityExecutionStatus ICompensatableActivity.Compensate(ActivityExecutionContext context) {
            return ActivityExecutionStatus.Closed;
        }
    }
}
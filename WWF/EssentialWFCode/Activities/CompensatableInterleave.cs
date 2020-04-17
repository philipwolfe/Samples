using System;
using System.Workflow.ComponentModel;

namespace EssentialWF.Activities {

    public class CompensatableInterleave : Interleave, ICompensatableActivity {
        ActivityExecutionStatus ICompensatableActivity.Compensate(ActivityExecutionContext context) {
            return ActivityExecutionStatus.Closed;
        }
    }
}

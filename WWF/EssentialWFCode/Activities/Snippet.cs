using System;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;

namespace EssentialWF.Activities {
    public class Snippet : Activity {
        public event EventHandler ExecuteSnippet;
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext) {
            if (ExecuteSnippet != null)
                ExecuteSnippet(this, EventArgs.Empty);

            return ActivityExecutionStatus.Closed;
        }
    }
}
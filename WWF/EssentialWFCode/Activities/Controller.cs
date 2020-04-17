using System;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;

namespace EssentialWF.Activities {

    public class Controller : CompositeActivity  {
        protected override void Initialize(IServiceProvider provider){
            WorkflowQueuingService qService = provider.GetService(typeof(WorkflowQueuingService)) as WorkflowQueuingService;
            WorkflowQueue queue = qService.CreateWorkflowQueue(this.Name, false);
        }
        protected override void Uninitialize(IServiceProvider provider) {
            WorkflowQueuingService qService = provider.GetService(typeof(WorkflowQueuingService)) as WorkflowQueuingService;
            qService.DeleteWorkflowQueue(this.Name);
        }
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {
            WorkflowQueuingService qService = context.GetService(typeof(WorkflowQueuingService)) as WorkflowQueuingService;
            WorkflowQueue queue = qService.GetWorkflowQueue(this.Name);
            queue.QueueItemAvailable += this.ResumeAt;

            return ActivityExecutionStatus.Executing;
        }

        void ResumeAt(object sender, QueueEventArgs e) {
            ActivityExecutionContext context = sender as ActivityExecutionContext;
            WorkflowQueuingService qService = context.GetService(typeof(WorkflowQueuingService)) as WorkflowQueuingService;
            WorkflowQueue queue = qService.GetWorkflowQueue(this.Name);

            string s = (string)queue.Dequeue();

            if (s != null) {
                if (s.StartsWith("execute")) {
                    // command will be something like 'execute w1'
                    string[] tokens = s.Split(new char[] { ' ' });
                    string name = tokens[1];
                    Activity child = GetChildActivity(name);
                    if (child != null) {
                        ActivityExecutionContextManager manager = context.ExecutionContextManager;
                        ActivityExecutionContext c = manager.CreateExecutionContext(child);

                        c.Activity.Closed += this.ContinueAt;
                        c.ExecuteActivity(c.Activity);
                    }
                }
            }
        }

        void ContinueAt(object sender, ActivityExecutionStatusChangedEventArgs e) {
            ActivityExecutionContext context = sender as ActivityExecutionContext;
            ActivityExecutionContextManager manager = context.ExecutionContextManager;
            ActivityExecutionContext c = manager.GetExecutionContext(e.Activity);
            manager.CompleteExecutionContext(c, false);
        }

        private Activity GetChildActivity(string name) {
            foreach (Activity child in EnabledActivities) {
                if (child.Name.Equals(name))
                    return child;
                }
                return null;
            }
        // Cancellation logic
        //    ...
    }
}

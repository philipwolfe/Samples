using System;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;

namespace EssentialWF.Activities {
  public class ReadLine : Activity {
    private string text;
    public string Text {
      get { return this.text; }
    }

    protected override void Initialize(IServiceProvider provider) {
      WorkflowQueuingService qService =(WorkflowQueuingService)provider.GetService(typeof(WorkflowQueuingService));
      if (!qService.Exists(this.Name))
        qService.CreateWorkflowQueue(this.Name, true);
    }

    protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {
      WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();

      WorkflowQueue queue = qService.GetWorkflowQueue(Name);
      if (queue.Count > 0) {
        this.text = (string)queue.Dequeue();
        return ActivityExecutionStatus.Closed;
      }

      queue.QueueItemAvailable += this.ContinueAt;
      return ActivityExecutionStatus.Executing;
    }

    void ContinueAt(object sender, QueueEventArgs e) {
      ActivityExecutionContext context = sender as ActivityExecutionContext;

      WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();

      WorkflowQueue queue = qService.GetWorkflowQueue(Name);
      this.text = (string)queue.Dequeue();
      context.CloseActivity();
    }

    protected override void Uninitialize(IServiceProvider provider) {
      WorkflowQueuingService qService = (WorkflowQueuingService)provider.GetService(typeof(WorkflowQueuingService));

      if (qService.Exists(this.Name))
        qService.DeleteWorkflowQueue(this.Name);
    }
  }
}

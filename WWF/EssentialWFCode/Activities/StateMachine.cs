using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;

namespace EssentialWF.Activities
{
  public class Arc { }
  public class StateMachineAction { }
  public class StateMachine : CompositeActivity
  {
    public StateMachine()
      : base()
    {
      base.SetReadOnlyPropertyValue(StatesProperty,
        new List<string>());

      base.SetReadOnlyPropertyValue(ArcsProperty,
        new List<Arc>());
    }

    public static readonly DependencyProperty
      StatesProperty = DependencyProperty.Register(
        "States",
        typeof(List<string>),
        typeof(StateMachine),
        new PropertyMetadata(DependencyPropertyOptions.Metadata
          | DependencyPropertyOptions.ReadOnly,
          new Attribute[] { 
            new DesignerSerializationVisibilityAttribute(
              DesignerSerializationVisibility.Content) }
        )
      );

    public static readonly DependencyProperty
      ArcsProperty = DependencyProperty.Register(
        "Arcs",
        typeof(List<Arc>),
        typeof(StateMachine),
        new PropertyMetadata(DependencyPropertyOptions.Metadata 
          | DependencyPropertyOptions.ReadOnly,
          new Attribute[] { 
            new DesignerSerializationVisibilityAttribute(
              DesignerSerializationVisibility.Content) }
        )
      );

    [DesignerSerializationVisibility(
      DesignerSerializationVisibility.Content)]
    public List<string> States
    {
      get { return GetValue(StatesProperty) as List<string>; }
    }

    [DesignerSerializationVisibility(
      DesignerSerializationVisibility.Content)]
    public List<Arc> Arcs
    {
      get { return GetValue(ArcsProperty) as List<Arc>; }
    }

    private string currentState;
    private Arc currentArc;
    private List<string> history;

    protected override void Initialize(
      IServiceProvider provider)
    {
      this.currentState = "NONE";
      this.currentArc = null;
      this.history = new List<string>();

      WorkflowQueuingService qService = 
        provider.GetService(typeof(WorkflowQueuingService)) 
          as WorkflowQueuingService;
      if (!qService.Exists(this.Name))
        qService.CreateWorkflowQueue(this.Name, false);

      base.Initialize(provider);
    }

    protected override void Uninitialize(
      IServiceProvider provider)
    {
      this.currentState = "NONE";
      this.currentArc = null;
      this.history = null;

      WorkflowQueuingService qService = 
        provider.GetService(typeof(WorkflowQueuingService))
          as WorkflowQueuingService;
      if (qService.Exists(this.Name))
        qService.DeleteWorkflowQueue(this.Name);

      base.Uninitialize(provider);
    }

    protected override ActivityExecutionStatus Execute(
      ActivityExecutionContext context)
    {
      if (EnabledActivities.Count == 0)
        return ActivityExecutionStatus.Closed; 
      
      this.currentState = "START";
      history.Add(currentState);

      WorkflowQueuingService qService = 
        context.GetService<WorkflowQueuingService>();
      WorkflowQueue queue = qService.GetWorkflowQueue(this.Name);
      queue.QueueItemAvailable += this.ResumeAt;

      return ActivityExecutionStatus.Executing;
    }

    void ResumeAt(object sender, QueueEventArgs e)
    {
      ActivityExecutionContext context = 
        sender as ActivityExecutionContext;
      WorkflowQueuingService qService = 
        context.GetService<WorkflowQueuingService>();
      WorkflowQueue queue = qService.GetWorkflowQueue(this.Name);

      object obj = queue.Dequeue();
      StateMachineAction action = obj as StateMachineAction;

      if (action != null)
      {
        if (currentArc != null)
        {
          // state transition in progress
          Console.WriteLine("action rejected");
          return;
        }

        Arc proposed = null;
        foreach (Arc arc in this.Arcs)
        {
          // Find the right arc
          if (arc.ActivityName.Equals(action.ActivityName)
            && arc.From.Equals(this.currentState))
          {
            proposed = arc;
            break;
          }
        }

        if (proposed == null)
        {
          Console.WriteLine("action not valid: " + action.ActivityName);
          return;
        }

        foreach (Activity child in EnabledActivities)
        {
          if (child.Name.Equals(proposed.ActivityName))
          {
            currentArc = proposed;
            Run(context, child, proposed.InputProp, action.Input);
            return;
          }
        }
      }
      else // query
      {
        StateMachineQuery query = obj as StateMachineQuery;
        if (query != null)
        {
          Console.WriteLine("--QueryResults--");
          Console.WriteLine("Current State: " + this.currentState);
          Console.WriteLine("Current Transition: " +
            ((currentArc == null) ? "-none-" : 
           (currentArc.ActivityName + "<" + 
            currentArc.From + "," + currentArc.To + ">"))
          );
          Console.Write("History: ");
          foreach (string s in this.history)
            Console.Write(s + (s.Equals("END") ? "" : "->"));
          Console.Write("\n");
          if (currentArc == null)
          {
            Console.WriteLine("Possible Transitions:");
            foreach (Arc arc in this.Arcs)
            {
              if (arc.From.Equals(this.currentState))
                Console.WriteLine(" " + arc.ActivityName + 
                 "<" + arc.From + "," + arc.To + ">" + 
                 " Input=" + arc.InputProp);
            }
          }
        }

        else
        {
          Console.WriteLine("unrecognized input: " + obj.ToString());
        }
      }
    }

    private void Run(ActivityExecutionContext context,
      Activity child, string propName, object propValue)
    {
      ActivityExecutionContextManager manager = 
        context.ExecutionContextManager;
      ActivityExecutionContext c = 
        manager.CreateExecutionContext(child);

      // Use reflection to set the input property value
      object o = c.Activity;
      o.GetType().GetProperty(propName).GetSetMethod().
        Invoke(o, new object[] { propValue });

      c.Activity.Closed += ContinueAt;
      c.ExecuteActivity(c.Activity);
    }

    void ContinueAt(object sender,
      ActivityExecutionStatusChangedEventArgs e)
    {
      e.Activity.Closed -= this.ContinueAt;
      ActivityExecutionContext context =
        sender as ActivityExecutionContext;

      ActivityExecutionContextManager manager = 
        context.ExecutionContextManager;
      ActivityExecutionContext c = 
        manager.GetExecutionContext(e.Activity);
      manager.CompleteExecutionContext(c, false);

      currentState = this.currentArc.To;
      history.Add(currentState);
      currentArc = null;

      if (currentState.Equals("END"))
        context.CloseActivity();
    }

    // Cancellation logic
    //...
  }
}

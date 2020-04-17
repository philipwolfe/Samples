using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Workflow.ComponentModel;

namespace EssentialWF.Activities {
    public class Graph : CompositeActivity {
        // All transitions must be true for a join
        // to take place
        private Dictionary<string, bool> transitionStatus;

        // If true, we have hit an exit activity and are
        // in the process of cancelling other activities
        private bool exiting;

        public Graph() : base() {   
            base.SetReadOnlyPropertyValue(Graph.ArcsProperty,new List<Arc>());
        }

        public static readonly DependencyProperty ArcsProperty = DependencyProperty.Register("Arcs",typeof(List<Arc>),typeof(Graph),new PropertyMetadata(DependencyPropertyOptions.Metadata | DependencyPropertyOptions.ReadOnly, new Attribute[] { new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content) }));

        // Attached to exactly one child activity
        public static readonly DependencyProperty IsEntryProperty = DependencyProperty.RegisterAttached("IsEntry",typeof(bool),typeof(Graph),new PropertyMetadata(DependencyPropertyOptions.Metadata));

        public static object GetIsEntry(object dependencyObject) {
            DependencyObject o = dependencyObject as DependencyObject;
            return o.GetValue(Graph.IsEntryProperty);
        }

        public static void SetIsEntry(object dependencyObject, object value) {
              DependencyObject o = dependencyObject as DependencyObject;
              o.SetValue(Graph.IsEntryProperty, value);
        }

        // Attached to zero or more child activities
        public static readonly DependencyProperty IsExitProperty =DependencyProperty.RegisterAttached("IsExit",typeof(bool),typeof(Graph),new PropertyMetadata(DependencyPropertyOptions.Metadata));
        public static object GetIsExit(object dependencyObject) {
              DependencyObject o = dependencyObject as DependencyObject;
              return o.GetValue(Graph.IsExitProperty);
        }

        public static void SetIsExit(object dependencyObject, object value){
              DependencyObject o = dependencyObject as DependencyObject;
              o.SetValue(Graph.IsExitProperty, value);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<Arc> Arcs {
            get { return GetValue(ArcsProperty) as List<Arc>; }
        }

        protected override void Initialize(IServiceProvider provider) {
          exiting = false;
          transitionStatus = new Dictionary<string, bool>();
          foreach (Arc arc in this.Arcs) {
              transitionStatus.Add(arc.name, false);
          }
          base.Initialize(provider);
        }

        protected override void Uninitialize(IServiceProvider provider) {
          transitionStatus = null;
          base.Uninitialize(provider);
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {
          if (EnabledActivities.Count == 0)
            return ActivityExecutionStatus.Closed;

          foreach (Activity child in EnabledActivities) {
            // Graph validation logic ensures one entry activity
            bool entry = (bool)Graph.GetIsEntry(child);
            if (entry){
              Run(context, child);
              break;
            }
          }
          return ActivityExecutionStatus.Executing;
        }

        private void Run(ActivityExecutionContext context, Activity child)
        {
          // we don't necessarily need to dynamically
          // create an AEC, but let's do it anyway
          // so we can more easily add looping later

          ActivityExecutionContextManager manager = context.ExecutionContextManager;
          ActivityExecutionContext c = manager.CreateExecutionContext(child);
          
          c.Activity.Closed += this.ContinueAt;
          c.ExecuteActivity(c.Activity);
        }

        void ContinueAt(object sender, ActivityExecutionStatusChangedEventArgs e) {
            e.Activity.Closed -= this.ContinueAt;
            ActivityExecutionContext context = sender as ActivityExecutionContext;

            // get the name before completing the AEC
            string completedChildName = e.Activity.Name;
            bool exitNow = (bool)Graph.GetIsExit(e.Activity);

            ActivityExecutionContextManager manager = context.ExecutionContextManager;
            ActivityExecutionContext c = manager.GetExecutionContext(e.Activity);
            manager.CompleteExecutionContext(c, false);

            if (exiting || exitNow) {
                // no executing child activities
                if (manager.ExecutionContexts.Count == 0)
                  context.CloseActivity();

                // just completed an exit activity
                else if (exitNow) {
                  exiting = true;
                  foreach (ActivityExecutionContext ctx in manager.ExecutionContexts) {
                    if (ctx.Activity.ExecutionStatus == ActivityExecutionStatus.Executing) {
                      ctx.CancelActivity(ctx.Activity);
                    }
                  }
                }
            }
            else {
                // mark all outgoing transitions as true
                foreach (Arc arc in this.Arcs) {
                  if (arc.FromActivity.Equals(completedChildName))
                    this.transitionStatus[arc.name] = true;
                }

                foreach (Activity child in EnabledActivities) {
                  bool entry = (bool)Graph.GetIsEntry(child);

                  if (!entry) {
                    // a child activity can run only
                    // if all incoming transitions are true
                    // and it is not the entry activity
                    bool canrun = true;
                    foreach (Arc arc in this.Arcs) {
                      if (arc.ToActivity.Equals(child.Name))
                        if (transitionStatus[arc.name] == false)
                          canrun = false;
                    }

                    if (canrun) {
                      // when we run a child activity,
                      // mark its incoming transitions as false
                      foreach (Arc arc in this.Arcs) {
                        if (arc.ToActivity.Equals(child.Name))
                          transitionStatus[arc.name] = false;
                      }
                      Run(context, child);
                    }
                  }
              }
            }
        }

        // Cancellation logic
        //    ...
    }
    public class Arc : DependencyObject {
        internal string name;

        public Arc() : base() {
          name = Guid.NewGuid().ToString();
        }

        public Arc(string from, string to) : this() {
          this.FromActivity = from;
          this.ToActivity = to;
        }

        public static readonly DependencyProperty
          FromActivityProperty = DependencyProperty.Register("FromActivity",typeof(string),typeof(Arc),new PropertyMetadata(DependencyPropertyOptions.Metadata));

        public static readonly DependencyProperty
          ToActivityProperty = DependencyProperty.Register("ToActivity",typeof(string),typeof(Arc),new PropertyMetadata(DependencyPropertyOptions.Metadata));

        public string FromActivity {
          get { return GetValue(FromActivityProperty) as string; }
          set { SetValue(FromActivityProperty, value); }
        }

        public string ToActivity {
          get { return GetValue(ToActivityProperty) as string; }
          set { SetValue(ToActivityProperty, value); }
        }
    }
}

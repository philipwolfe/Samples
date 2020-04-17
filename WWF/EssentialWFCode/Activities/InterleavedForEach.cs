using System;
using System.Collections;
using System.Workflow.ComponentModel;

namespace EssentialWF.Activities {
    public class InterleavedForEach : CompositeActivity {
        int totalCount = 0;
        int closedCount = 0;
        public static readonly DependencyProperty IterationVariableProperty =DependencyProperty.RegisterAttached("IterationVariable",typeof(object),typeof(InterleavedForEach));

        public static object GetIterationVariable(DependencyObject dependencyObject) {
          return dependencyObject.GetValue(IterationVariableProperty);
        }

        public static void SetIterationVariable(DependencyObject dependencyObject,object value) {
          dependencyObject.SetValue(IterationVariableProperty, value);
        }

        public static readonly DependencyProperty CollectionProperty = DependencyProperty.Register("Collection",typeof(IEnumerable),typeof(InterleavedForEach));
            
        public IEnumerable Collection {
          get { return (IEnumerable) GetValue(CollectionProperty); }
          set { SetValue(CollectionProperty, value); }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {
            if (Collection == null)
              return ActivityExecutionStatus.Closed;

            Activity template = this.EnabledActivities[0];
            ActivityExecutionContextManager manager = 
                    context.ExecutionContextManager;

            foreach (object item in Collection) {
              totalCount++;
              ActivityExecutionContext newContext =
                 manager.CreateExecutionContext(template);
              Activity newActivity = newContext.Activity;

              InterleavedForEach.SetIterationVariable(newActivity, item);

              newActivity.Closed += this.ContinueAt;
              newContext.ExecuteActivity(newActivity);
            }

            if (totalCount == 0)
                return ActivityExecutionStatus.Closed;

            return ActivityExecutionStatus.Executing;
        }

        void ContinueAt(object sender, ActivityExecutionStatusChangedEventArgs e) {
            e.Activity.Closed -= this.ContinueAt;

            ActivityExecutionContext context = sender as ActivityExecutionContext;
            ActivityExecutionContextManager manager = context.ExecutionContextManager;

            ActivityExecutionContext innerContext = manager.GetExecutionContext(e.Activity);
            manager.CompleteExecutionContext(innerContext);

            if (totalCount == ++closedCount)
                context.CloseActivity();
        }
    
        public Activity[] ActiveIterations {
          get {
              if (this.EnabledActivities.Count > 0) {
                  Activity template = EnabledActivities[0];
                  return GetDynamicActivities(template);
              }
              return null;
          }
        }
    }
}

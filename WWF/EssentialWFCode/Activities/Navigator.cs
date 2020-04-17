using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Workflow.ComponentModel;

namespace EssentialWF.Activities {
    public class Navigator : CompositeActivity {
        public static readonly DependencyProperty StartWithProperty = DependencyProperty.Register("StartWith",typeof(string),typeof(Navigator));

        public string StartWith {
          get { return (string) GetValue(StartWithProperty); }
          set { SetValue(StartWithProperty, value); }
        }

        public static readonly DependencyProperty NavigateToProperty = DependencyProperty.RegisterAttached("NavigateTo",  typeof(string),typeof(Navigator));
        public static object GetNavigateTo(object dependencyObject) {
          DependencyObject o = dependencyObject as DependencyObject;
          return o.GetValue(NavigateToProperty);
        }

        public static void SetNavigateTo(object dependencyObject, object value) {
          DependencyObject o = dependencyObject as DependencyObject;
          o.SetValue(Navigator.NavigateToProperty, value);
        }

        public static readonly DependencyProperty NavigatingEvent = DependencyProperty.Register("Navigating",  typeof(EventHandler<NavigatorEventArgs>), typeof(Navigator));
        public event EventHandler<NavigatorEventArgs> Navigating {
          add { base.AddHandler(NavigatingEvent, value); }
          remove { base.RemoveHandler(NavigatingEvent, value); }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {
            if (this.TryNavigatingTo(context, this.StartWith))
            return ActivityExecutionStatus.Executing;

            return ActivityExecutionStatus.Closed;
        }

        private bool TryNavigatingTo(ActivityExecutionContext context,  string nextActivityName) {
            ActivityExecutionContextManager manager = context.ExecutionContextManager;

            List<Activity> history = new List<Activity>();
            foreach (Guid ctxid in manager.PersistedExecutionContexts) {
            ActivityExecutionContext serializedContext = manager.GetPersistedExecutionContext(ctxid);
            history.Add(serializedContext.Activity);

            // GetPersistedExecutionContext above removed the context
            // so we need to explicitly add it back
            context.ExecutionContextManager.
              CompleteExecutionContext(serializedContext, true);
            }

            NavigatorEventArgs args = new NavigatorEventArgs(history.AsReadOnly());
            RaiseGenericEvent(Navigator.NavigatingEvent, this, args);

            Activity nextActivity = null;
            if (args.NavigateTo != null)
            nextActivity = args.NavigateTo;
            else if (!string.IsNullOrEmpty(nextActivityName))
            nextActivity = this.GetActivityByName(nextActivityName);

            if (nextActivity != null) {
                ActivityExecutionContext innerContext =  manager.CreateExecutionContext(nextActivity);
                innerContext.Activity.Closed += this.ContinueAt;
                innerContext.ExecuteActivity(innerContext.Activity);
                return true;
            }
            return false;
        }

        private void ContinueAt(Object sender, ActivityExecutionStatusChangedEventArgs e) {
            ActivityExecutionContext context = sender as ActivityExecutionContext;
            ActivityExecutionContextManager manager = context.ExecutionContextManager;

            ActivityExecutionContext innerContext =  manager.GetExecutionContext(e.Activity);

            //first, unsubscribe to the inner context's activity
            innerContext.Activity.Closed -= this.ContinueAt;

            //remove the inner context and serialize it
            manager.CompleteExecutionContext(innerContext, true);

            string nextActivityName = Navigator.GetNavigateTo(
            innerContext.Activity) as string;

            if (!this.TryNavigatingTo(context, nextActivityName))
                context.CloseActivity();
        }

        // Cancellation logic
        //    ...
    }
  
    public class NavigatorEventArgs : EventArgs {
        private ReadOnlyCollection<Activity> history = null;
        private Activity navigateTo = null;

        internal NavigatorEventArgs(ReadOnlyCollection<Activity> history) { 
          this.history = history; 
        }

        public Activity NavigateTo {
          get { return navigateTo; }
          set { navigateTo = value; }
        }

        public ReadOnlyCollection<Activity> History {
          get { return this.history; }
        }
    }
}

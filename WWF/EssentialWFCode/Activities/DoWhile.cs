using System;
using System.Workflow.ComponentModel;
  
namespace EssentialWF.Activities {
    public class DoWhile : CompositeActivity  {
        public static readonly DependencyProperty CompletionConditionProperty = DependencyProperty.Register("CompletionCondition",typeof(ActivityCondition),typeof(DoWhile),new PropertyMetadata(DependencyPropertyOptions.Metadata));

        public ActivityCondition CompletionCondition {
            get { return GetValue(CompletionConditionProperty) as ActivityCondition; }
            set { SetValue(CompletionConditionProperty, value); }
        }
            
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {
            ExecuteBody(context);
            return ActivityExecutionStatus.Executing;
        }

        void ExecuteBody(ActivityExecutionContext context) {
            ActivityExecutionContextManager manager = context.ExecutionContextManager;

            Activity template = this.EnabledActivities[0];

            ActivityExecutionContext newContext = manager.CreateExecutionContext(template);
            Activity newActivity = newContext.Activity;

            newActivity.Closed += this.ContinueAt;
            newContext.ExecuteActivity(newActivity);
        }

        void ContinueAt(object sender, ActivityExecutionStatusChangedEventArgs e) {
            e.Activity.Closed -= this.ContinueAt;
            ActivityExecutionContext context = sender as ActivityExecutionContext;
            ActivityExecutionContextManager manager = context.ExecutionContextManager;
            ActivityExecutionContext innerContext = manager.GetExecutionContext(e.Activity);

            manager.CompleteExecutionContext(innerContext);

            if (this.ExecutionStatus == ActivityExecutionStatus.Executing) {
            if ((CompletionCondition == null) || (CompletionCondition.Evaluate(this, context)))
              ExecuteBody(context);
            else
              context.CloseActivity();
            }
        }
        //cancellation/fault handling logic omitted
        //...
    }
}

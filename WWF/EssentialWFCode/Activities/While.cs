using System;
using System.Workflow.ComponentModel;

namespace EssentialWF.Activities {
    public sealed class ConstantCondition : ActivityCondition 
    {
      public static readonly DependencyProperty BooleanValueProperty = DependencyProperty.Register("BooleanValue",typeof(bool), typeof(ConstantCondition),new PropertyMetadata(DependencyPropertyOptions.Metadata));
      public bool BooleanValue {
        get {return (bool)GetValue(BooleanValueProperty);}
        set { SetValue(BooleanValueProperty, value); }
      }
      public override bool Evaluate(Activity activity, IServiceProvider provider) {
        return this.BooleanValue;
      }
    }

    public sealed class ConstantLoopCondition : ActivityCondition {
        private int counter = 0;
        public static readonly DependencyProperty MaxCountProperty = DependencyProperty.Register("MaxCount",typeof(int),typeof(ConstantLoopCondition),new PropertyMetadata(DependencyPropertyOptions.Metadata));
        public int MaxCount {
            get {return (int)GetValue(MaxCountProperty); }
            set { SetValue(MaxCountProperty,value); }
        }
	
        public override bool Evaluate(Activity activity, IServiceProvider provider) {
            return counter++ < this.MaxCount;
        }
    }

    public class While : CompositeActivity {
        public static readonly DependencyProperty ConditionProperty = DependencyProperty.Register("Condition",typeof(ActivityCondition),typeof(While),new PropertyMetadata(DependencyPropertyOptions.Metadata));
        public ActivityCondition Condition {
            get {
                return GetValue(ConditionProperty)
            as ActivityCondition;
            }

            set { SetValue(ConditionProperty, value); }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {
            if (Condition != null && Condition.Evaluate(this, context)) {
                ExecuteBody(context);
                return ActivityExecutionStatus.Executing;
            }

            return ActivityExecutionStatus.Closed;
        }

        void ExecuteBody(ActivityExecutionContext context) {
            ActivityExecutionContextManager manager = context.ExecutionContextManager;
            ActivityExecutionContext newContext = manager.CreateExecutionContext(EnabledActivities[0]);
            Activity newActivity = newContext.Activity;

            newActivity.Closed += this.ContinueAt;
            newContext.ExecuteActivity(newActivity);
        }

        void ContinueAt(object sender,ActivityExecutionStatusChangedEventArgs e) {
            e.Activity.Closed -= this.ContinueAt;
            ActivityExecutionContext context = sender as ActivityExecutionContext;
            ActivityExecutionContextManager manager = context.ExecutionContextManager;
            ActivityExecutionContext innerContext = manager.GetExecutionContext(e.Activity);
            manager.CompleteExecutionContext(innerContext);

            if (this.ExecutionStatus == ActivityExecutionStatus.Executing && Condition != null && Condition.Evaluate(this, context))
                ExecuteBody(context);
            else
                context.CloseActivity();
        }
    }
}

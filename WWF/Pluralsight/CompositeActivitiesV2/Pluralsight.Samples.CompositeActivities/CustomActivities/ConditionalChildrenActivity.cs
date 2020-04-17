using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Collections.ObjectModel;

namespace CustomActivities
{
    [Designer(typeof(ConditionalChildrenActivityDesigner))]
    public partial class ConditionalChildrenActivity : System.Workflow.ComponentModel.CompositeActivity, IActivityEventListener<ActivityExecutionStatusChangedEventArgs>
	{
        //the dependency property that we attach to child activities
        public static DependencyProperty WhenConditionProperty = System.Workflow.ComponentModel.DependencyProperty.RegisterAttached("WhenCondition", typeof(ActivityCondition), typeof(ConditionalChildrenActivity),new PropertyMetadata(null,DependencyPropertyOptions.Metadata));//, new GetValueOverride(GetWhenCondition), new SetValueOverride(SetWhenCondition)));

        public static object GetWhenCondition(object target)
        {
            if (target as DependencyObject == null)
                throw new ArgumentException("object must be a dependency object");

            return ((DependencyObject)target).GetValue(ConditionalChildrenActivity.WhenConditionProperty);
        }

        public static void SetWhenCondition(object target, object value)
        {
            if (target == null || value == null)
                throw new ArgumentNullException();

            ((DependencyObject)target).SetValue(ConditionalChildrenActivity.WhenConditionProperty, value);
        }
		public ConditionalChildrenActivity()
		{
			InitializeComponent();
		}

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {

            if (EnabledActivities.Count == 0)
                return ActivityExecutionStatus.Closed;
            Activity nextActivity = FindNextExecutableActivity(executionContext);

            if (nextActivity == null)
                return ActivityExecutionStatus.Closed;
            else
            {
                nextActivity.RegisterForStatusChange(Activity.ClosedEvent, this);
                executionContext.ExecuteActivity(nextActivity);
                return ActivityExecutionStatus.Executing;
            }
        }

        /// <summary>
        /// Finds the next activity to execute basd on the 
        /// activities that have closed and the conditions on 
        /// the remaining activities.  
        /// </summary>
        /// <param name="executionContext">The current execution contenxt</param>
        /// <returns>The next activity to execute or null if no activities remain.</returns>
        private Activity FindNextExecutableActivity(ActivityExecutionContext executionContext)
        {
            int startingIndex = 0;

            for (int activityIndex = EnabledActivities.Count -1; activityIndex >= 0; activityIndex--)
            {
                if (EnabledActivities[activityIndex].ExecutionStatus == ActivityExecutionStatus.Closed)
                {
                    //if this is the last activity, we have no more
                    if (activityIndex == EnabledActivities.Count - 1)
                        return null;
                    else
                    {
                        //set the index at which to start looking for the next activity
                        startingIndex = activityIndex + 1;
                    }
                }
            }
                //find the next activity that can execute
                for (int findIndex = startingIndex; findIndex < EnabledActivities.Count; findIndex++)
                {
                    //if there is no condition, then assume this can run and return it
                    ActivityCondition condition = EnabledActivities[findIndex].GetValue(ConditionalChildrenActivity.WhenConditionProperty) as ActivityCondition;
                    if(condition == null)
                    {
                        return EnabledActivities[findIndex];
                    }
                    else if(condition.Evaluate(EnabledActivities[findIndex], executionContext))
                    {
                        return EnabledActivities[findIndex];
                    }
                }

               return null;
                
            
        }

        #region IActivityEventListener<ActivityExecutionStatusChangedEventArgs> Members

        void IActivityEventListener<ActivityExecutionStatusChangedEventArgs>.OnEvent(object sender, ActivityExecutionStatusChangedEventArgs e)
        {
            ActivityExecutionContext context = sender as ActivityExecutionContext;
            Activity closedActivity = e.Activity;
            closedActivity.UnregisterForStatusChange(Activity.ClosedEvent, this);

            Activity nextActivity = FindNextExecutableActivity(context);
            if (nextActivity == null)
                context.CloseActivity();
            else
            {
                nextActivity.RegisterForStatusChange(Activity.ClosedEvent, this);
                context.ExecuteActivity(nextActivity);
            }
        }

        #endregion
    }
}

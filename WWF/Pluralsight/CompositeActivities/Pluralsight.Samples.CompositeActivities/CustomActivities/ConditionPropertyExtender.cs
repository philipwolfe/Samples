using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Workflow.ComponentModel;

namespace CustomActivities
{
    /// <summary>
    /// Provides the WhenCondition property to the child activities.
    /// </summary>
    [ProvideProperty("WhenCondition", typeof(Activity))]
	class ConditionPropertyExtender : IExtenderProvider
	{
        /// <summary>
        /// Indicates whether this extender can extend the given activity
        /// </summary>
        /// <param name="extendee">The activity to be extended</param>
        /// <returns>true if the activity is a child of the ConditionalChildrenActivity, false if not.</returns>
        public bool CanExtend(object extendee)
        {
            if (extendee != null && extendee is Activity)
            {
                return ((Activity)extendee).Parent is ConditionalChildrenActivity;
            }

            return false;
        }


        /// <summary>
        /// The "property getter" for the WhenCondition property
        /// </summary>
        /// <param name="activity">The activity from which to get the value</param>
        /// <returns>The value of the property, or null if the value does not exist.</returns>
        [Category("Conditions"),
        Description("Determines whether the activity will be executed."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ActivityCondition GetWhenCondition(Activity activity)
        {
            if(activity.Parent is ConditionalChildrenActivity)
                return (ActivityCondition)activity.GetValue(ConditionalChildrenActivity.WhenConditionProperty);

            return null;
        }

        /// <summary>
        /// The property "setter" for the when condition property.
        /// </summary>
        /// <param name="activity">The activity on which to set the value</param>
        /// <param name="handler">The value to be set.</param>
        [Category("Conditions"),
            Description("Determines whether the activity will be executed.")]
        public void SetWhenCondition(Activity activity, ActivityCondition handler)
        {
            if(activity.Parent is ConditionalChildrenActivity)
                activity.SetValue(ConditionalChildrenActivity.WhenConditionProperty, handler);

        }
    }
}

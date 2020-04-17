//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation Sample Code.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;

namespace SynchronizationActivities
{
    /// <summary>
	/// WaitFor activity is for pausing one branch of a parallel
    /// until an activity in another branch begins or completes.
    /// </summary>
	[ToolboxItem(typeof(ActivityToolboxItem))]
	[ActivityValidator(typeof(WaitForValidator))]
    [Designer(typeof(WaitForDesigner), typeof(IDesigner))]
    public sealed partial class WaitFor : Activity
    {
        private string activity = string.Empty;
        private string status = "Closed";

        [Category("WaitFor")]
        [Description("The activity that will be retried")]
        [TypeConverter(typeof(WaitForStatusTypeConverter))]
        public string Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }

        [Category("WaitFor")]
        [Description("The activity that will be retried")]
        [TypeConverter(typeof(WaitForActivityTypeConverter))]
        public string Activity
        {
            get
            {
                return this.activity;
            }

            set
            {
                this.activity = value;
            }
        }

        public WaitFor()
        {
            InitializeComponent();
        }

        internal ICollection GetPropertyValues(IServiceProvider serviceProvider, PropertyDescriptor propertyDesc)
        {
            if (propertyDesc == null)
                throw new ArgumentNullException("propertyDesc");

            ArrayList values = new ArrayList();
            if (propertyDesc.Name == "Activity")
            {
                values = GetActivities(this, string.Empty);
                values.Remove(this.QualifiedName);
            }
            else if (propertyDesc.Name == "Status")
            {
                values.Add("Closed");
                values.Add("Executing");
            }
            return values;
        }

        //  Returns all the activities that can this WaitFor can wait for
        //  When initially call the second parameter should be an empty string.
        internal ArrayList GetActivities(Activity activity, string id)
        {
            ArrayList activities = new ArrayList();

            if (activity.Parent != null)
            {
                if (activity.Parent.GetType() == typeof(SequenceActivity))
                {
                    if (activity.Parent.Parent != null && activity.Parent.Parent is ParallelActivity)
                    {
                        foreach (Activity child in activity.Parent.Parent.Activities)
                        {
                            if (child != activity.Parent)
                            { 
                                activities.AddRange(GetActivities(child, activity.QualifiedName));
                            }
                        }
                        
                    }
                }
                else if (activity.Parent is ParallelActivity)
                {
                    if (activity.GetType() == typeof(SequenceActivity))
                    {
                        foreach (Activity child in ((SequenceActivity)activity).Activities)
                        {
                            if (child is WaitFor)
                            {
                                if (((WaitFor)child).activity != string.Empty)
                                {
                                    bool found = false;

                                    //  Need to get the activity with QualifiedID id
                                    Activity toWaitFor = GetActivity(child, id);

                                    //  Find all activities below it and compare their
                                    //  Qualified IDs to ((WaitFor)child).activity
                                    //  If we find it there then break.
                                    CompositeActivity parent = toWaitFor.Parent;

                                    for (int i = parent.Activities.IndexOf(toWaitFor) + 1; i < parent.Activities.Count; ++i)
                                    {
                                        if (parent.Activities[i].QualifiedName == ((WaitFor)child).activity)
                                        {
                                            found = true;
                                            break;
                                        }
                                    }
                                    if (found)
                                    {
                                        break;
                                    }
                                }
                            }
                            activities.Add(child.QualifiedName);
                        }
                    }
                }
            }

            return activities;
        }

        internal Activity GetActivity(Activity sybling, string id)
        {
            CompositeActivity parallel = sybling.Parent.Parent;

            foreach (CompositeActivity sequence in parallel.Activities)
            {
                foreach (Activity child in sequence.Activities)
                {
                    if (child.QualifiedName == id)
                    {
                        return child;
                    }
                }
            }
            return null;
        }

		private Activity GetExecutableActivity(string id)
		{
			CompositeActivity parallel = this.Parent.Parent;

			foreach (CompositeActivity sequence in parallel.EnabledActivities)
			{
				foreach (Activity child in sequence.EnabledActivities)
				{
					if (child.QualifiedName == id)
					{
						return child;
					}
				}
			}
			return null;
		}

		protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
		{
			ActivityExecutionStatus status;
			Activity activity = GetExecutableActivity(this.Activity);

			switch (activity.ExecutionStatus)
			{
				case ActivityExecutionStatus.Executing:
                    if (this.Status == "Closed")
					{
						activity.StatusChanged += this.OnStatusChangeHandler;
						status = ActivityExecutionStatus.Executing;
					}
					else
					{
						status = ActivityExecutionStatus.Closed;
					}
					break;
				case ActivityExecutionStatus.Closed:
					status = ActivityExecutionStatus.Closed;
					break;
				default:
					activity.StatusChanged += this.OnStatusChangeHandler;
					status = ActivityExecutionStatus.Executing;
					break;
			}

			return status;
		}

		void OnStatusChangeHandler(Object sender, ActivityExecutionStatusChangedEventArgs args)
		{
			ActivityExecutionContext context = (ActivityExecutionContext)sender;

			WaitFor waitFor = context.Activity as WaitFor;
			Activity activityWaitingFor = args.Activity;
			bool removeSub = true;

			switch (args.ExecutionStatus)
			{
				case ActivityExecutionStatus.Executing:
					if (waitFor.Status == "Closed")
					{
						removeSub = false;
					}
					break;
				default:
					break;
			}

			if (removeSub)
			{
				activityWaitingFor.StatusChanged -= this.OnStatusChangeHandler;
				context.CloseActivity();
			}
		}
    }

    public class WaitForActivityTypeConverter : TypeConverter
    {
        public WaitForActivityTypeConverter()
        {
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            WaitFor waitFor = context.Instance as WaitFor;

            if (waitFor == null)
                throw new ArgumentException("context.Instance is not a WaitFor");

            return new StandardValuesCollection(waitFor.GetPropertyValues(null, context.PropertyDescriptor));
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }
    }

    public class WaitForStatusTypeConverter : TypeConverter
    {
        public WaitForStatusTypeConverter()
        {
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            WaitFor waitFor = context.Instance as WaitFor;

            if (waitFor == null)
                throw new ArgumentException("context.Instance is not a WaitFor");

            return new StandardValuesCollection(waitFor.GetPropertyValues(null, context.PropertyDescriptor));
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }

    /// <summary>
    /// Summary description for WaitForValidator.
    /// This is the validator for the activity. 
    /// </summary>
    public sealed class WaitForValidator : ActivityValidator
    {
        //  TODO: Add logic to check for un even amount in each branch.
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection validationErrors = new ValidationErrorCollection(base.Validate(manager, obj));

            WaitFor waitFor = (WaitFor)obj;

            if (waitFor.Parent != null)
            {
                bool activityInSameBranch = false;

                if (waitFor.Activity == string.Empty)
                {
                    validationErrors.Add(CreateValidationError("Property Activity not set", "Activity"));
                }
                else
                {
                    if (waitFor.GetActivities(waitFor, string.Empty).IndexOf(waitFor.Activity) < 0)
                    {
                        if (waitFor.Parent.GetType() == typeof(SequenceActivity) && waitFor.Parent.Parent is ParallelActivity)
                        {
                            //  Is it in the same branch or is it blocking
                            //  First loop through all syblings and see if it
                            //  is in the same branch.
                            bool found = false;
                            foreach (Activity sybling in waitFor.Parent.Activities)
                            {
                                if (sybling.QualifiedName == waitFor.Activity)
                                {
                                    activityInSameBranch = true;
                                    found = true;
                                    break;
                                }
                            }

                            if (found)
                            {
                                if (activityInSameBranch)
                                {
                                    validationErrors.Add(CreateValidationError("The activity you are waiting for can not be in the same branch.", "Activity"));
                                }
                                else
                                {
                                    validationErrors.Add(CreateValidationError("The activity you are waiting for is blocked by another WaitFor activity.", "Activity"));
                                }
                            }
                            else
                            {
                                validationErrors.Add(CreateValidationError("'" + waitFor.Activity + "' is not a valid activity to wait for.", "Activity"));
                            }
                        }
                        else
                        {
                            validationErrors.Add(CreateValidationError("You can not wait for activity '" + waitFor.Activity + "'.", "Activity"));
                        }
                    }
                    else
                    {
                        Activity sybling = waitFor.GetActivity(waitFor, waitFor.Activity);
                        if (sybling is WaitFor)
                        {
                            if (((WaitFor)sybling).Status == "Closed" && waitFor.Status == "Closed")
                            {
                                validationErrors.Add(CreateValidationError("If two WaitFor activities are waiting for each other only one can have the status set to Completed.", "WaitForStatus"));
                            }
                        }
                    }
                }

                if (waitFor.Status != "Closed" && waitFor.Status != "Executing")
                {
                    if (waitFor.Status == string.Empty)
                    {
                        validationErrors.Add(CreateValidationError("Property WaitForStatus not set", "Activity"));
                    }
                    else
                    {
                        validationErrors.Add(CreateValidationError("'" + waitFor.Status + "' is not a valid status.", "Activity"));
                    }
                }

                if (waitFor.Parent.GetType() == typeof(SequenceActivity))
                {
                    if (!(waitFor.Parent.Parent is ParallelActivity))
                    {
                        validationErrors.Add(new ValidationError("Parent of WaitFor activity must be a Sequence whose parent is a Parallel.", 0x708));
                    }
                }
                else
                {
                    validationErrors.Add(new ValidationError("Parent of WaitFor activity must be a Sequence.", 0x709));
                } 
            }

            return validationErrors;
        }

        private ValidationError CreateValidationError(string errorString, string property)
        {
			ValidationError validationError = null;
			if (string.IsNullOrEmpty(property))
            {
                validationError = new ValidationError(errorString, 0x70A);
            }
			else
			{
				validationError = new ValidationError(errorString, 0x70B, false, property);
			}
			return validationError;
        }
    }

    /// <summary>
    /// Summary description for WaitForDesigner.
    ///This is a designtime activity designer class. This class is responsible for rendering of the activities
    /// </summary>
    //TODO: Associate theme with the designer, theme specified will be used to render you designer
    [ActivityDesignerTheme(typeof(ActivityDesignerTheme),
    Xml = "<?Mapping XmlNamespace=\"ComponentModel\" ClrNamespace=\"System.Workflow.ComponentModel.Design\" Assembly=\"System.Workflow.ComponentModel\" ?>" +
        "<ActivityDesignerTheme xmlns=\"ComponentModel\"" +
        " ApplyTo=\"Microsoft.WinOE.Test.CustomActivity.WaitForDesigner\"" +
        " ShowDropShadow=\"False\"" +
        " ConnectorStartCap=\"None\"" +
        " ConnectorEndCap=\"None\"" +
        " ForeColor=\"0xFF008080\"" +
        " BorderColor=\"0xFF00E0E0\"" +
        " BorderStyle=\"Dash\"" +
        " BackColorStart=\"LightBlue\"" +
        " BackColorEnd=\"Yellow\"" +
        " BackgroundStyle=\"Vertical\"" + 
        " />")]
    internal sealed class WaitForDesigner : ActivityDesigner
    {
        public WaitForDesigner()
        {
        }

		public override bool CanBeParentedTo(CompositeActivityDesigner parentActivityDesigner)
        {
			if (parentActivityDesigner == null)
				throw new ArgumentNullException("parentActivityDesigner");

            if (parentActivityDesigner.Activity is SequenceActivity && parentActivityDesigner.Activity.Parent is ParallelActivity)
			{
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

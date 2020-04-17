//--------------------------------------------------------------------------------
// This file is part of the Windows Workflow Foundation Sample Code
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Design;
using System.Collections;
using System.Drawing.Design;

namespace SwitchActivity
{
    [Designer(typeof(SwitchDesigner), typeof(IDesigner))]
    public partial class Switch : CompositeActivity, IActivityEventListener<ActivityExecutionStatusChangedEventArgs> 
	{
		public Switch()
		{
			InitializeComponent();
		}

        public static DependencyProperty ExpressionProperty = DependencyProperty.Register("Expression", typeof(object), typeof(Switch), new PropertyMetadata(null));
                
        [Description("Expression that cases will compare against to determine which will run.")]
        [Category("Activity")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public object Expression
        {
            get
            {
                return base.GetValue(Switch.ExpressionProperty);
            }
            set
            {
                base.SetValue(Switch.ExpressionProperty, value);
            }
        }

        public static DependencyProperty CasesProperty = DependencyProperty.RegisterAttached("Cases", typeof(object), typeof(Switch), new PropertyMetadata(null), typeof(CasesValidator));

        public static object GetCasesProperty(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(CasesProperty) as object;
        }

        public static void SetCasesProperty(DependencyObject depedencyObject, object value)
        {
            depedencyObject.SetValue(CasesProperty, value);
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            Switch switchAct = executionContext.Activity as Switch;
            int childCount = switchAct.EnabledActivities.Count;
            if (childCount > 0)
            {
                bool runIt = false;

                for(int i = 0;i < childCount;++i)
                {
                    object casesValues = GetCasesProperty(switchAct.EnabledActivities[i]);
                    if (casesValues == null)
                        runIt = (i == childCount - 1);
                    else
                    {
                        if (casesValues.GetType().IsArray)
                        {
                            foreach (object casesValue in (casesValues as Array))
                            {
                                if ((i == (childCount - 1) && casesValue == null) || casesValue.Equals(switchAct.Expression))
                                {
                                    runIt = true;
                                    break;
                                }                            
                            }                                
                        }
                        else
                            runIt = ((i == (childCount - 1) && casesValues == null) || casesValues.Equals(switchAct.Expression));    
                    }

                    if (runIt)
                    {
                        switchAct.EnabledActivities[i].RegisterForStatusChange(Activity.ClosedEvent, this);
                        executionContext.ExecuteActivity(switchAct.EnabledActivities[i]);
                        return ActivityExecutionStatus.Executing;
                    }
                }
            }
            return ActivityExecutionStatus.Closed;
        }

        protected override void Initialize(IServiceProvider provider)
        {
            ActivityExecutionContext context = provider as ActivityExecutionContext;
            Switch switchAct = context.Activity as Switch;
            Hashtable caseValues = new Hashtable();

            object expression = switchAct.Expression;

            if (expression == null)
                throw new InvalidOperationException("The Expression property's value can not be null.");
            else if (!expression.GetType().IsPrimitive && expression.GetType() != typeof(string) && !expression.GetType().IsEnum)
                throw new InvalidOperationException("The Expression property's value must be a string, enum or a primitive type.");

            foreach (Activity child in switchAct.Activities)
            {
                object objs = Switch.GetCasesProperty(child);
                if (objs == null)
                {
                    if (switchAct.Activities.IndexOf(child) != switchAct.Activities.Count - 1)
                        throw new InvalidOperationException("Cases property must be set on all but the last child of a Switch.  For the last child it is optional.");
                }
                else
                {
                    if (objs.GetType().IsArray)
                    {
                        foreach (object obj in (objs as Array))
                        {
                            try
                            {
                                //  Inexpensive way to make sure the value are unique.
                                if (obj != null)
                                    caseValues.Add(obj, null);
                            }
                            catch (ArgumentException)
                            {
                                throw new ArgumentException(string.Format("The value for any Cases property must be unique. '{0}' has already been used.", obj.ToString()));
                            }

                            if (obj == null)
                            {
                                if (switchAct.Activities.IndexOf(child) != switchAct.Activities.Count - 1)
                                    throw new InvalidOperationException("Only the last Cases property can be null or contain a null value.  This is the equal to the default case.");
                                else if (expression.GetType() != obj.GetType() && !obj.GetType().IsAssignableFrom(expression.GetType()))
                                    throw new InvalidOperationException("The Cases property has to be the same or assignable to the type of the parent Switch activity's Expression property.");
                            }
                        }
                    }
                    else
                    {
                        if (expression.GetType() != objs.GetType() && !objs.GetType().IsAssignableFrom(expression.GetType()))
                            throw new InvalidOperationException("The Cases property has to be the same or assignable to the type of the parent Switch activity's Expression property.");
                    }
                }
            }

            base.Initialize(provider);
        }

        #region IActivityEventListener<ActivityExecutionStatusChangedEventArgs> Members

        void IActivityEventListener<ActivityExecutionStatusChangedEventArgs>.OnEvent(object sender, ActivityExecutionStatusChangedEventArgs e)
        {
            ActivityExecutionContext executionContext = ((ActivityExecutionContext)(sender));
            e.Activity.UnregisterForStatusChange(Activity.ClosedEvent, this);
            executionContext.CloseActivity();
        }

        #endregion
    }

    public class SwitchDesigner : ParallelActivityDesigner
    {
        protected override void Initialize(Activity activity)
        {
            base.Initialize(activity);

            IExtenderListService extenderListService = (IExtenderListService)GetService(typeof(IExtenderListService));
            if (extenderListService != null)
            {
                bool foundExtender = false;
                foreach (IExtenderProvider extenderProvider in extenderListService.GetExtenderProviders())
                {
                    if (extenderProvider.GetType() == typeof(CasesExtenderProvider))
                        foundExtender = true;
                }

                if (!foundExtender)
                {
                    IExtenderProviderService extenderProviderService = (IExtenderProviderService)GetService(typeof(IExtenderProviderService));
                    if (extenderProviderService != null)
                        extenderProviderService.AddExtenderProvider(new CasesExtenderProvider());
                }
            }
        }
    }

    [ProvideProperty("Cases", typeof(Activity))]
    class CasesExtenderProvider : IExtenderProvider
    {
        [CategoryAttribute("Switch"),]
        [DescriptionAttribute("If any of the values in Cases equals the Switch's Expression then this activity will be run.")]
        [TypeConverter(typeof(ActivityBindTypeConverter))]
        public object GetCases(Activity theActivity)
        {
            object value = null;

            if (theActivity.Parent is Switch)
            {
                if (theActivity.IsBindingSet(Switch.CasesProperty))
                    value = theActivity.GetBinding(Switch.CasesProperty) as object;
                else
                    value = theActivity.GetValue(Switch.CasesProperty) as object;
            }

            return value;
        }

        public void SetCases(Activity theActivity, object value)
        {
            if (theActivity.Parent is Switch)
            {
                if (value is ActivityBind)
                    theActivity.SetBinding(Switch.CasesProperty, value as ActivityBind);
                else
                    theActivity.SetValue(Switch.CasesProperty, value);
            }
        }

        bool IExtenderProvider.CanExtend(object extendee)
        {
            return (extendee is Activity) && (((Activity)extendee).Parent is Switch);
        }
    }

    public class CasesValidator : Validator
    {
        public override ValidationErrorCollection  Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors = base.Validate(manager, obj);

            Activity activity = manager.Context[typeof(Activity)] as Activity;
            if (activity != null)
            {
                Switch switchAct = activity.Parent as Switch;
                if (switchAct == null)
                    errors.Add(new ValidationError("The Cases property can only be set on a direct child of a Switch activity.", 123, false, "Cases")); 
            }

            return errors;
        }
    }
}

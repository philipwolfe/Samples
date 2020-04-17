using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Workflow.Runtime.Hosting;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Reflection;

namespace CallWorkflowActivityLibrary
{
  
    public class CallWorkflowDesigner : ActivityDesigner
    {
        protected override void OnActivityChanged(ActivityChangedEventArgs e)
        {
            if (e.Member.Name == "Type")
                TypeDescriptor.Refresh(e.Activity);
            else
                base.OnActivityChanged(e);
        }
        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
            CallWorkflowActivity a = this.Activity as CallWorkflowActivity;
            if (a.Type != null)
            {
                //get the properties and add them as properties
                PropertyInfo[] pis = a.Type.GetProperties();
                foreach (PropertyInfo pi in pis)
                {
                    if (pi.DeclaringType == a.Type)
                    {
                        //add a new parameter
                        properties[pi.Name] = new CallWorkflowParameterBindingPropertyDescriptor(pi.Name, pi.PropertyType, new Attribute[] { new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden), new BrowsableAttribute(true), new CategoryAttribute("Parameters"), new EditorAttribute(typeof(BindUITypeEditor), typeof(UITypeEditor)) });
                    }
                }

            }
        }
    }
    public class CallWorkflowParameterBindingPropertyDescriptor : PropertyDescriptor
    {
        Type _type = null;

        public CallWorkflowParameterBindingPropertyDescriptor(string propertyName, Type parameterType, Attribute[] attrs)
            : base(propertyName, attrs)
        {
            this._type = parameterType;
        }


        public override TypeConverter Converter
        {
            get
            {
                return new ActivityBindTypeConverter();
            }
        }
        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override Type ComponentType
        {
            get
            {

                return typeof(CallWorkflowActivity);
            }
        }

        public override object GetValue(object component)
        {
            WorkflowParameterBindingCollection parameters = ((CallWorkflowActivity)component).Parameters;
            if (parameters != null && parameters.Contains(this.Name))
            {
                if (parameters[this.Name].IsBindingSet(WorkflowParameterBinding.ValueProperty))
                    return parameters[this.Name].GetBinding(WorkflowParameterBinding.ValueProperty);
                else
                    return parameters[this.Name].GetValue(WorkflowParameterBinding.ValueProperty);
            }
            return null;
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get
            {
                if (_type != null)
                    return _type;
                else
                    return typeof(ActivityBind);
            }
        }

        public override void ResetValue(object component)
        {

        }

        public override void SetValue(object component, object value)
        {
            if (component != null)
            {
                ISite site = GetSite(component);
                IComponentChangeService changeService = null;
                if (site != null)
                    changeService = (IComponentChangeService)site.GetService(typeof(IComponentChangeService));
                // Raise the OnComponentChanging event
                changeService.OnComponentChanging(component, this);

                // Save the old value
                object oldValue = GetValue(component);

                try
                {
                    WorkflowParameterBindingCollection parameters = ((CallWorkflowActivity)component).Parameters;
                    if (parameters != null)
                    {
                        if (value == null)
                            // Remove the binding from the ParameterBindings collection
                            parameters.Remove(this.Name);
                        else
                        {
                            // Add the binding to the ParameterBindings collection
                            WorkflowParameterBinding binding = null;
                            if (parameters.Contains(this.Name))
                                binding = parameters[this.Name];
                            else
                            {
                                binding = new WorkflowParameterBinding(this.Name);
                                parameters.Add(binding);
                            }

                            // Set the binding value on the ParameterBindings collection correspondent binding item
                            if (value is ActivityBind)
                                binding.SetBinding(WorkflowParameterBinding.ValueProperty, value as ActivityBind);
                            else
                                binding.SetValue(WorkflowParameterBinding.ValueProperty, value);
                        }
                    }
                    // Raise the OnValueChanged event
                    OnValueChanged(component, EventArgs.Empty);
                }
                catch (Exception)
                {
                    value = oldValue;
                    throw;
                }
                finally
                {
                    if (changeService != null)
                        // Raise the OnComponentChanged event
                        changeService.OnComponentChanged(component, this, oldValue, value);
                }
            }
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
    }

}

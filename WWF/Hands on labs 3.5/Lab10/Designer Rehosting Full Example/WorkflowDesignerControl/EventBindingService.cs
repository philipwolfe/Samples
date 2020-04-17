//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs
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

namespace WorkflowDesignerControl
{
    #region Using StateMents
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.ComponentModel.Design;
    using System.ComponentModel;
    using System.Globalization;
    using System.Collections;
    using System.Workflow.ComponentModel.Compiler;
    using System.CodeDom;
    using System.Reflection;
    using System.Workflow.ComponentModel.Design;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Serialization;
    #endregion

    #region Class EventBindingService
    internal class EventBindingService : IEventBindingService
    {
        private WorkflowLoader loader;
        private IServiceProvider serviceProvider;

        public EventBindingService(IServiceProvider provider, WorkflowLoader loader)
        {
            this.loader = loader;
            this.serviceProvider = provider;
        }

        public string CreateUniqueMethodName(IComponent component, EventDescriptor e)
        {
            return e.DisplayName;
        }

        public ICollection GetCompatibleMethods(EventDescriptor e)
        {
            return new ArrayList();
        }

        public EventDescriptor GetEvent(PropertyDescriptor property)
        {
            return (property is EventPropertyDescriptor) ? ((EventPropertyDescriptor)property).EventDescriptor : null;
        }

        public PropertyDescriptorCollection GetEventProperties(EventDescriptorCollection events)
        {
            return new PropertyDescriptorCollection(new PropertyDescriptor[] { }, true);
        }

        public PropertyDescriptor GetEventProperty(EventDescriptor e)
        {
            return new EventPropertyDescriptor(e, this, this.serviceProvider);
        }

        public bool ShowCode()
        {
            return false;
        }

        public bool ShowCode(int lineNumber)
        {
            return false;
        }

        public bool ShowCode(IComponent component, EventDescriptor e)
        {
            return false;
        }

        protected void UseMethod(IComponent component, EventDescriptor e, string methodName)
        {
            if (!String.IsNullOrEmpty(methodName))
            {
                Generate(component, e, methodName, true);
            }
        }

        protected void FreeMethod(IComponent component, EventDescriptor e, string methodName)
        {
            if (!String.IsNullOrEmpty(methodName))
            {
                Generate(component, e, methodName, false);
            }
        }

        /// <summary>
        /// Generate the method and add to code compile unit
        /// </summary>
        /// <param name="component"></param>
        /// <param name="e"></param>
        /// <param name="methodName"></param>
        /// <param name="addMethod"></param>
        private void Generate(IComponent component, EventDescriptor e, string methodName, bool addMethod)
        {
            TypeProvider typeProvider = (TypeProvider)this.serviceProvider.GetService(typeof(ITypeProvider));
            CodeCompileUnit ccu = this.loader.CodeBesideCCU;

            Type delegateType = e.EventType;
            MethodInfo invokeInfo = delegateType.GetMethod("Invoke");

            Type returnType = invokeInfo.ReturnType;

            MemberAttributes modifiers = MemberAttributes.Private;
            PropertyDescriptor modifiersProp = TypeDescriptor.GetProperties(component)["DefaultEventModifiers"];
            if (modifiersProp != null && modifiersProp.PropertyType == typeof(MemberAttributes))
            {
                modifiers = (MemberAttributes)modifiersProp.GetValue(component);
            }

            CodeParameterDeclarationExpressionCollection paramCollection = new CodeParameterDeclarationExpressionCollection();
            foreach (ParameterInfo paramInfo in invokeInfo.GetParameters())
            {
                CodeParameterDeclarationExpression codeParamExpression = new CodeParameterDeclarationExpression();
                codeParamExpression.Name = paramInfo.Name;
                codeParamExpression.Type = new CodeTypeReference(paramInfo.ParameterType);

                paramCollection.Add(codeParamExpression);
            }

            // create code member method
            CodeMemberMethod method = new CodeMemberMethod();
            method.Name = methodName;
            method.Parameters.AddRange(paramCollection);
            method.ReturnType = new CodeTypeReference(returnType);
            method.Attributes = modifiers;

            if (addMethod)
                // The assumption here is that we have only one namespace and type being designed
                ccu.Namespaces[0].Types[0].Members.Add(method);
            else
                ccu.Namespaces[0].Types[0].Members.Remove(method);

            typeProvider.RefreshCodeCompileUnit(this.loader.CodeBesideCCU, new EventHandler(RefreshCCU));
        }

        private void RefreshCCU(object sender, EventArgs e)
        {
            //We dont want to do anything here
        }


        private class EventPropertyDescriptor : PropertyDescriptor
        {
            private EventDescriptor eventDescriptor;
            private IServiceProvider serviceProvider;
            private EventBindingService eventSvc;
            private TypeConverter converter;
            private bool useMethodCalled = false;

            public EventDescriptor EventDescriptor
            {
                get
                {
                    return this.eventDescriptor;
                }
            }

            public EventPropertyDescriptor(EventDescriptor eventDesc, EventBindingService eventSvc, IServiceProvider serviceProvider)
                : base(eventDesc, null)
            {
                this.eventDescriptor = eventDesc;
                this.eventSvc = eventSvc;
                this.serviceProvider = serviceProvider;
            }

            public override Type ComponentType
            {
                get
                {
                    return this.eventDescriptor.ComponentType;
                }
            }
            public override Type PropertyType
            {
                get
                {
                    return this.eventDescriptor.EventType;
                }
            }

            public override TypeConverter Converter
            {
                get
                {
                    if (this.converter == null)
                        this.converter = new XomlEventConverter(this.eventDescriptor);

                    return this.converter;
                }
            }

            public override bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            public override bool CanResetValue(object component)
            {
                return false;
            }

            public override object GetValue(object component)
            {
                string value = null;
                DependencyObject dependencyObject = component as DependencyObject;
                if (dependencyObject != null)
                {
                    Hashtable dynamicEvents = dependencyObject.GetValue(WorkflowMarkupSerializer.EventsProperty) as Hashtable;
                    if (dynamicEvents != null)
                    {
                        if (dynamicEvents.ContainsKey(this.eventDescriptor.Name))
                            value = dynamicEvents[this.eventDescriptor.Name] as string;
                    }
                    else
                    {
                        DependencyProperty dependencyEvent = DependencyProperty.FromName(this.eventDescriptor.Name, dependencyObject.GetType());
                        MethodInfo getInvocationListMethod = dependencyObject.GetType().GetMethod("System.Workflow.ComponentModel.IDependencyObjectAccessor.GetInvocationList", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                        if (getInvocationListMethod != null && dependencyEvent != null && dependencyEvent.IsEvent)
                        {
                            MethodInfo boundGetInvocationListMethod = getInvocationListMethod.MakeGenericMethod(new Type[] { dependencyEvent.PropertyType });
                            if (boundGetInvocationListMethod != null)
                            {
                                Delegate[] delegates = boundGetInvocationListMethod.Invoke(dependencyObject, new object[] { dependencyEvent }) as Delegate[];
                                if (delegates != null && delegates.Length > 0 && delegates[0].Method != null)
                                    value = delegates[0].Method.Name;
                            }
                        }
                    }
                }

                return value;
            }

            public override void ResetValue(object component)
            {
                SetValue(component, null);
            }

            public override void SetValue(object component, object value)
            {
                if (IsReadOnly)
                    throw new ArgumentException(this.eventDescriptor.Name);

                if (value != null && !(value is string))
                    throw new ArgumentException(this.eventDescriptor.Name);

                if (component is DependencyObject)
                {
                    string name = value as string;
                    DependencyObject dependencyObject = component as DependencyObject;
                    string oldName = null;
                    if (dependencyObject.GetValue(WorkflowMarkupSerializer.EventsProperty) == null)
                        dependencyObject.SetValue(WorkflowMarkupSerializer.EventsProperty, new Hashtable());

                    Hashtable dynamicEvents = dependencyObject.GetValue(WorkflowMarkupSerializer.EventsProperty) as Hashtable;
                    if (dynamicEvents.ContainsKey(this.eventDescriptor.Name))
                        oldName = dynamicEvents[this.eventDescriptor.Name] as string;

                    if (oldName != null && name != null && oldName.Equals(name, StringComparison.Ordinal))
                    {
                        foreach (string methodName in this.eventSvc.GetCompatibleMethods(this.eventDescriptor))
                        {
                            if (methodName.Equals(name, StringComparison.CurrentCulture))
                                return;
                        }
                    }
                    else if (oldName == name)
                    {
                        return;
                    }

                    IDesignerHost host = this.serviceProvider.GetService(typeof(IDesignerHost)) as IDesignerHost;
                    if (host == null)
                        throw new InvalidOperationException(typeof(IDesignerHost).FullName);

                    if (!String.IsNullOrEmpty(name))
                    {
                        if (name.StartsWith("@"))
                            throw new InvalidOperationException(name);

                        Activity rootActivity = host.RootComponent as Activity;
                        if (rootActivity != null)
                        {
                            // make sure the name doesn't conflict with an existing member in the code-beside.
                            MemberInfo matchingMember = null;
                            Type designedType = Helpers.GetDataSourceClass(rootActivity, this.serviceProvider);
                            if (designedType != null)
                            {
                                WorkflowLoader loader = this.serviceProvider.GetService(typeof(WorkflowLoader)) as WorkflowLoader;
                                foreach (MemberInfo memberInfo in designedType.GetMembers(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                                {
                                    if (memberInfo.Name.Equals(name, StringComparison.Ordinal))
                                    {
                                        matchingMember = memberInfo;
                                        break;
                                    }
                                }
                            }

                            if (matchingMember != null)
                            {
                                if (!(matchingMember is MethodInfo))
                                    throw new InvalidOperationException(designedType.FullName);
                            }
                            else
                            {
                                // make sure the name doesn't conflict with an existing activity.
                                IIdentifierCreationService idService = this.serviceProvider.GetService(typeof(IIdentifierCreationService)) as IIdentifierCreationService;
                                if (idService != null)
                                    idService.ValidateIdentifier(rootActivity, name);
                            }
                        }
                    }

                    // If there is a designer host, create a transaction.
                    DesignerTransaction trans = null;
                    if (host != null)
                        trans = host.CreateTransaction(name);

                    try
                    {
                        IComponentChangeService change = this.serviceProvider.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
                        if (change != null)
                        {
                            try
                            {
                                change.OnComponentChanging(component, this);
                                change.OnComponentChanging(component, this.eventDescriptor);
                            }
                            catch (CheckoutException coEx)
                            {
                                if (coEx == CheckoutException.Canceled)
                                    return;
                                throw;
                            }
                        }

                        if (name != null)
                        {
                            if (host.RootComponent != null)
                            {
                                if (!this.useMethodCalled && !string.IsNullOrEmpty(oldName))
                                    eventSvc.UseMethod((IComponent)component, eventDescriptor, oldName);

                                eventSvc.UseMethod((IComponent)component, eventDescriptor, name);
                                this.useMethodCalled = true;
                            }
                        }

                        if (oldName != null && host.RootComponent != null)
                            eventSvc.FreeMethod((IComponent)component, eventDescriptor, oldName);

                        dynamicEvents[this.eventDescriptor.Name] = name;

                        if (change != null)
                        {
                            change.OnComponentChanged(component, this.eventDescriptor, null, null);
                            change.OnComponentChanged(component, this, oldName, name);
                        }

                        OnValueChanged(component, EventArgs.Empty);

                        if (trans != null)
                            trans.Commit();
                    }
                    finally
                    {
                        if (trans != null)
                            ((IDisposable)trans).Dispose();
                    }
                }
            }

            public override bool ShouldSerializeValue(object component)
            {
                return true;
            }

            private class XomlEventConverter : TypeConverter
            {

                private EventDescriptor evt;

                internal XomlEventConverter(EventDescriptor evt)
                {
                    this.evt = evt;
                }

                public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
                {
                    if (sourceType == typeof(string))
                        return true;

                    return base.CanConvertFrom(context, sourceType);
                }

                public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
                {
                    if (destinationType == typeof(string))
                        return true;

                    return base.CanConvertTo(context, destinationType);
                }

                public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
                {
                    if (value == null)
                        return value;

                    if (value is string)
                    {
                        if (((string)value).Length == 0)
                            return null;

                        return value;
                    }
                    return base.ConvertFrom(context, culture, value);
                }

                public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
                {
                    if (destinationType == typeof(string))
                        return (value == null || !(value is string)) ? string.Empty : value;

                    return base.ConvertTo(context, culture, value, destinationType);
                }

                public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
                {
                    string[] eventMethods = null;

                    if (context != null)
                    {
                        IEventBindingService ebs = (IEventBindingService)context.GetService(typeof(IEventBindingService));
                        if (ebs != null)
                        {
                            try
                            {
                                ICollection methods = ebs.GetCompatibleMethods(evt);
                                eventMethods = new string[methods.Count];
                                int i = 0;
                                foreach (string s in methods)
                                    eventMethods[i++] = s;
                            }
                            catch (Exception)
                            {
                                //Failed to get methods. return empty list
                            }
                        }
                    }

                    return new StandardValuesCollection(eventMethods);
                }

                public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
                {
                    return false;
                }

                public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
                {
                    return true;
                }
            }
        }
    }
    #endregion
}

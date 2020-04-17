using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Design;
using Microsoft.Workflow.Samples.Administration;

namespace Microsoft.Workflow.Samples.WorkflowManager.DesignerHosting
{
    #region Class WorkflowDesignSurface
    /// <summary>
    /// Design Surface is used to provide services.
    /// </summary>
    internal sealed class WorkflowDesignSurface : DesignSurface
    {
        private TypeDescriptorFilterService typeDescriptorFilter = null;
        private bool readOnly;

        internal WorkflowDesignSurface(IServiceProvider serviceProvider)
        {
            this.readOnly = true;

            this.ServiceContainer.AddService(typeof(IMenuCommandService), new MenuCommandService(this.ServiceContainer));
            this.ServiceContainer.AddService(typeof(IToolboxService), new Toolbox(this.ServiceContainer));

            TypeProvider typeProvider = new TypeProvider(serviceProvider);
            typeProvider.AddAssemblyReference(typeof(string).Assembly.Location);
            typeProvider.AddAssemblyReference(typeof(ParallelActivity).Assembly.Location);
            typeProvider.AddAssemblyReference(typeof(WorkflowCompiler).Assembly.Location);
            typeProvider.AddAssemblyReference(typeof(ActivityMarkupWithChanges).Assembly.Location);

            //getting custom assembly references
            try
            {
                List<ReferenceAssembly> assemblyReferences = ConfigurationManager.GetSection("Microsoft.Workflow.Samples.DynamicUpdate/assemblyReferences") as List<ReferenceAssembly>;
                if (assemblyReferences != null)
                    foreach (ReferenceAssembly referenceAssembly in assemblyReferences)
                        typeProvider.AddAssemblyReference(referenceAssembly.AssemblyPath);
            }
            catch
            {
            }

            this.ServiceContainer.AddService(typeof(ITypeProvider), typeProvider, true);
            this.ServiceContainer.AddService(typeof(IWorkflowCompilerOptionsService), new WorkflowCompilerOptionsService());
            this.ServiceContainer.AddService(typeof(IMemberCreationService), new MemberCreationService());
            this.ServiceContainer.AddService(typeof(IEventBindingService), new EventBindingService());
            this.ServiceContainer.AddService(typeof(IExtendedUIService), new ExtUIService());

            this.typeDescriptorFilter = new TypeDescriptorFilterService(this.ServiceContainer);
            this.typeDescriptorFilter.ReadOnly = this.readOnly;

            IComponentChangeService componentChangeService = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            if (componentChangeService != null)
                componentChangeService.ComponentAdded += new ComponentEventHandler(OnComponentAdded);

            WorkflowInstanceManager.NewAssemblyLoaded += new EventHandler(NewAssemblyLoaded);
            foreach (string assembly in WorkflowInstanceManager.GetLoadedAssemblies())
            {
                NewAssemblyLoaded(this, new AssemblyLoadedEventArgs(assembly));
            }
            WorkflowInstanceManager.UpdateLoadedAssemlbiesList();
        }

        private void NewAssemblyLoaded(object sender, EventArgs e)
        {
            AssemblyLoadedEventArgs assemblyLoadedEventArgs = e as AssemblyLoadedEventArgs;

            TypeProvider typeProvider = this.ServiceContainer.GetService(typeof(ITypeProvider)) as TypeProvider;
            typeProvider.AddAssemblyReference(assemblyLoadedEventArgs.Path);
        }

        protected override void Dispose(bool disposing)
        {
            IComponentChangeService componentChangeService = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            if (componentChangeService != null)
                componentChangeService.ComponentAdded -= new ComponentEventHandler(OnComponentAdded);

            WorkflowInstanceManager.NewAssemblyLoaded -= new EventHandler(NewAssemblyLoaded);

            base.Dispose(disposing);
        }

        private void OnComponentAdded(object sender, ComponentEventArgs eventArgs)
        {
            //root component should always be readonly
            if (this.readOnly || (eventArgs.Component is Activity && ((Activity)eventArgs.Component).Parent == null))
                MakePropertiesReadOnly(this, eventArgs.Component);
        }

        internal static void MakePropertiesReadOnly(IServiceProvider serviceProvider, object topComponent)
        {
            Queue nestedComponents = new Queue();
            nestedComponents.Enqueue(topComponent);

            while (nestedComponents.Count > 0)
            {
                object component = nestedComponents.Dequeue();

                //add custom readonly type descriptor to the component (to set ForceReadonly flag in the property grid)
                TypeDescriptor.AddProvider(new ReadonlyTypeDescriptonProvider(TypeDescriptor.GetProvider(component)), component);

                //now go through all the properties and add custom readonly type descriptor to all composite ones
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(component, new Attribute[] { BrowsableAttribute.Yes });
                foreach (PropertyDescriptor property in properties)
                {
                    if (!property.PropertyType.IsPrimitive)
                    {
                        object decl = property.GetValue(component);
                        if (decl != null)
                        {
                            TypeConverter converter = TypeDescriptor.GetConverter(decl);
                            TypeDescriptorContext context = new TypeDescriptorContext(serviceProvider, property, component);
                            if (converter.GetPropertiesSupported(context))
                            {
                                TypeDescriptor.AddProvider(new ReadonlyTypeDescriptonProvider(TypeDescriptor.GetProvider(decl)), decl);
                                nestedComponents.Enqueue(decl);
                            }
                        }
                    }
                }
            }
        }

        public bool ReadOnly
        {
            get { return this.readOnly; }
            set
            {
                this.readOnly = value;
                this.typeDescriptorFilter.ReadOnly = this.readOnly;
            }
        }
    }
    #endregion

    #region Class WorkflowCompilerOptionsService
    /// <summary>
    /// Dummy implmentation of WorkflowCompilerOptionsService, this is useful when the workflow has code beside file.
    /// In current scenario of this sample we do not have code beside file.
    /// </summary>
    internal class WorkflowCompilerOptionsService : IWorkflowCompilerOptionsService
    {
        public WorkflowCompilerOptionsService()
        {
        }

        string IWorkflowCompilerOptionsService.RootNamespace
        {
            get { return String.Empty; }
        }

        bool IWorkflowCompilerOptionsService.CheckTypes
        {
            get { return false; }
        }


        string IWorkflowCompilerOptionsService.Language
        {
            get { return "CSharp"; }
        }
    }
    #endregion

    #region Class MemberCreationService
    internal sealed class MemberCreationService : IMemberCreationService
    {
        #region IMemberCreationService Members

        public void CreateField(string className, string fieldName, Type fieldType, Type[] genericParameterTypes, MemberAttributes attributes, CodeSnippetExpression initializationExpression, bool overwriteExisting)
        {
        }

        public void CreateAttribute(string className, Type type, CodeExpression[] attributeParameters, bool overwriteExisting)
        {
        }

        public void CreateEvent(string className, string name, Type type, AttributeInfo[] attributes, bool emitDependencyProperty)
        {
        }

        public void CreateField(Activity dataContext, string fieldName, Type type, Type[] genericParameterTypes, MemberAttributes memberAttributes, CodeSnippetExpression initExpression, bool overwriteExisting)
        {
        }

        public void CreateMethod(Activity dataContext, string methodName, Type delegateType, MemberAttributes memberAttributes)
        {
        }

        public void CreateProperty(string className, string name, Type type, AttributeInfo[] attributes, bool emitDependencyProperty, bool isMetaProperty, bool isAttached, Type ownerType, bool isReadOnly)
        {
        }

        public void CreateTypeDeclaration(CodeTypeDeclaration typeDeclaration, CodeConstructor constructor)
        {
        }

        public void RemoveAttribute(string className, Type type)
        {
        }

        public void RemoveEvent(string className, string name, Type type)
        {
        }

        public void RemoveField(string className, string fieldName)
        {
        }

        public void RemoveProperty(string className, string name, Type type)
        {
        }

        public void ResumeChanges()
        {
        }

        public void ShowCode()
        {
        }

        public void ShowCode(Activity dataContext, string methodName, Type delegateType)
        {
        }

        public void SuspendChanges()
        {
        }

        public void UpdateBaseType(string className, Type baseType)
        {
        }

        public void UpdateEvent(string className, string oldName, Type oldType, string name, Type type, AttributeInfo[] attributes, bool emitDependencyProperty, bool isMetaProperty)
        {
        }

        public void UpdateProperty(string className, string oldName, Type oldType, string name, Type type, AttributeInfo[] attributes, bool emitDependencyProperty, bool isMetaProperty)
        {
        }

        public void UpdateTypeName(string oldClassName, string newClassName)
        {
        }

        #endregion
    }
    #endregion

    #region Class EventBindingService
    internal class EventBindingService : IEventBindingService
    {
        public EventBindingService()
        {
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
            return new EventPropertyDescriptor(e);
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

        private class EventPropertyDescriptor : PropertyDescriptor
        {
            private EventDescriptor eventDescriptor;

            public EventDescriptor EventDescriptor
            {
                get { return this.eventDescriptor; }
            }

            public EventPropertyDescriptor(EventDescriptor eventDescriptor)
                : base(eventDescriptor, null)
            {
                this.eventDescriptor = eventDescriptor;
            }

            public override Type ComponentType
            {
                get { return this.eventDescriptor.ComponentType; }
            }
            public override Type PropertyType
            {
                get { return this.eventDescriptor.EventType; }
            }

            public override bool IsReadOnly
            {
                get { return true; }
            }

            public override bool CanResetValue(object component)
            {
                return false;
            }

            public override object GetValue(object component)
            {
                return null;
            }

            public override void ResetValue(object component)
            {
            }

            public override void SetValue(object component, object value)
            {
            }

            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
        }
    }
    #endregion

    #region Class TypeDescriptorFilterService
    internal class TypeDescriptorFilterService : ITypeDescriptorFilterService
    {
        private ServiceContainer serviceContainer;
        private ITypeDescriptorFilterService previousFilter;
        private bool readOnly;

        internal TypeDescriptorFilterService(ServiceContainer serviceContainer)
        {
            this.readOnly = true;
            this.serviceContainer = serviceContainer;
            this.previousFilter = this.serviceContainer.GetService(typeof(ITypeDescriptorFilterService)) as ITypeDescriptorFilterService;
            this.serviceContainer.RemoveService(typeof(ITypeDescriptorFilterService));
            this.serviceContainer.AddService(typeof(ITypeDescriptorFilterService), this);
        }

        bool ITypeDescriptorFilterService.FilterAttributes(IComponent component, IDictionary attributes)
        {
            if (this.previousFilter != null)
                return this.previousFilter.FilterAttributes(component, attributes);
            else
                return true;
        }

        bool ITypeDescriptorFilterService.FilterEvents(IComponent component, IDictionary events)
        {
            if (this.previousFilter != null)
                return this.previousFilter.FilterEvents(component, events);
            else
                return true;
        }

        bool ITypeDescriptorFilterService.FilterProperties(IComponent component, IDictionary properties)
        {
            bool cache = true;

            if (this.previousFilter != null)
                cache = this.previousFilter.FilterProperties(component, properties);

            //Make all the properties readonly here
            ArrayList keys = new ArrayList(properties.Keys);
            foreach (object key in keys)
            {
                PropertyDescriptor realPropertyDescriptor = properties[key] as PropertyDescriptor;
                if (realPropertyDescriptor != null && this.ReadOnly)
                {
                    properties[key] = new ReadonlyPropertyDescriptor(realPropertyDescriptor);
                }
            }

            return cache;
        }

        public bool ReadOnly
        {
            get { return this.readOnly; }
            set { this.readOnly = value; }
        }
    }
    #endregion

    #region Class ReadonlyPropertyDescriptor
    internal sealed class ReadonlyPropertyDescriptor : PropertyDescriptor
    {
        private PropertyDescriptor realPropertyDescriptor;

        internal ReadonlyPropertyDescriptor(PropertyDescriptor descriptor)
            : base(descriptor, null)
        {
            this.realPropertyDescriptor = descriptor;
        }

        public override string Category
        {
            get { return this.realPropertyDescriptor.Category; }
        }
        public override AttributeCollection Attributes
        {
            get
            {
                ArrayList collection = new ArrayList();
                foreach (Attribute attribute in this.realPropertyDescriptor.Attributes)
                {
                    //should not have any editor attribute and only one readonly attribute
                    if (!(attribute is EditorAttribute || attribute is ReadOnlyAttribute))
                        collection.Add(attribute);
                }
                collection.Add(new ReadOnlyAttribute(true));
                AttributeCollection newCollection = new AttributeCollection((Attribute[])collection.ToArray(typeof(Attribute)));
                return newCollection;
            }
        }
        public override TypeConverter Converter
        {
            get { return this.realPropertyDescriptor.Converter; }
        }
        public override string Description
        {
            get { return this.realPropertyDescriptor.Description; }
        }
        public override Type ComponentType
        {
            get { return this.realPropertyDescriptor.ComponentType; }
        }
        public override Type PropertyType
        {
            get { return this.realPropertyDescriptor.PropertyType; }
        }
        public override bool IsReadOnly
        {
            get { return true; }
        }
        public override void ResetValue(object component)
        {
            this.realPropertyDescriptor.ResetValue(component);
        }
        public override bool CanResetValue(object component)
        {
            return this.realPropertyDescriptor.CanResetValue(component);
        }
        public override bool ShouldSerializeValue(object component)
        {
            return this.realPropertyDescriptor.ShouldSerializeValue(component);
        }
        public override object GetValue(object component)
        {
            return this.realPropertyDescriptor.GetValue(component);
        }
        public override void SetValue(object component, object value)
        {
            //This is readonly property descriptor
            Debug.Assert(false, "SetValue should not be called on readonly property!");
        }
    }
    #endregion

    #region Class ReadonlyTypeDescriptorProvider
    internal sealed class ReadonlyTypeDescriptonProvider : TypeDescriptionProvider
    {
        internal ReadonlyTypeDescriptonProvider(TypeDescriptionProvider realProvider)
            : base(realProvider)
        {
        }

        public override ICustomTypeDescriptor GetTypeDescriptor(Type type, object instance)
        {
            ICustomTypeDescriptor realTypeDescriptor = base.GetTypeDescriptor(type, instance);
            ICustomTypeDescriptor readonlyTypeDescriptor = new ReadonlyTypeDescriptor(realTypeDescriptor);
            return readonlyTypeDescriptor;
        }
    }
    #endregion

    #region Class ReadonlyTypeDescriptor
    internal sealed class ReadonlyTypeDescriptor : CustomTypeDescriptor
    {
        internal ReadonlyTypeDescriptor(ICustomTypeDescriptor realTypeDescriptor)
            : base(realTypeDescriptor)
        {
        }

        public override AttributeCollection GetAttributes()
        {
            ArrayList collection = new ArrayList();
            foreach (Attribute attribute in base.GetAttributes())
            {
                //should not have any editor attribute and only one readonly attribute
                if (!(attribute is EditorAttribute || attribute is ReadOnlyAttribute))
                    collection.Add(attribute);
            }
            collection.Add(new ReadOnlyAttribute(true));
            AttributeCollection newCollection = new AttributeCollection((Attribute[])collection.ToArray(typeof(Attribute)));
            return newCollection;
        }

        public override PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection properties = base.GetProperties();

            ArrayList readonlyProperties = new ArrayList();
            foreach (PropertyDescriptor property in properties)
            {
                BrowsableAttribute browsable = property.Attributes[typeof(BrowsableAttribute)] as BrowsableAttribute;
                if (browsable.Browsable && !(property is ReadonlyPropertyDescriptor))
                    readonlyProperties.Add(new ReadonlyPropertyDescriptor(property));
                else
                    readonlyProperties.Add(property);
            }

            return new PropertyDescriptorCollection((PropertyDescriptor[])readonlyProperties.ToArray(typeof(PropertyDescriptor)));
        }
    }
    #endregion

    #region Class TypeDescriptorContext
    internal sealed class TypeDescriptorContext : ITypeDescriptorContext
    {
        private IServiceProvider serviceProvider;
        private PropertyDescriptor propDesc;
        private object instance;

        public TypeDescriptorContext(IServiceProvider serviceProvider, PropertyDescriptor propDesc, object instance)
        {
            this.serviceProvider = serviceProvider;
            this.propDesc = propDesc;
            this.instance = instance;
        }

        public IContainer Container
        {
            get { return (IContainer)this.serviceProvider.GetService(typeof(IContainer)); }
        }
        public object Instance
        {
            get { return this.instance; }
        }
        public PropertyDescriptor PropertyDescriptor
        {
            get { return this.propDesc; }
        }
        public object GetService(Type serviceType)
        {
            return this.serviceProvider.GetService(serviceType);
        }

        public bool OnComponentChanging()
        {
            IComponentChangeService componentChangeService = (IComponentChangeService)this.serviceProvider.GetService(typeof(IComponentChangeService));
            if (componentChangeService != null)
            {
                try
                {
                    componentChangeService.OnComponentChanging(this.instance, this.propDesc);
                }
                catch (CheckoutException ce)
                {
                    if (ce == CheckoutException.Canceled)
                        return false;
                    throw ce;
                }
            }
            return true;
        }
        public void OnComponentChanged()
        {
            IComponentChangeService componentChangeService = (IComponentChangeService)this.serviceProvider.GetService(typeof(IComponentChangeService));
            if (componentChangeService != null)
                componentChangeService.OnComponentChanged(this.instance, this.propDesc, null, null);
        }
    }
    #endregion

    #region class ExtUIService
    class ExtUIService : IExtendedUIService
    {
        public void AddAssemblyReference(AssemblyName assemblyName)
        {
        }
        public void AddDesignerActions(DesignerAction[] actions)
        {
        }
        public DialogResult AddWebReference(out Uri url, out Type proxyClass)
        {
            url = new Uri("microsoft.com");
            proxyClass = null;
            return DialogResult.Cancel;
        }
        public Type GetProxyClassForUrl(Uri url)
        {
            return null;
        }
        public Uri GetUrlForProxyClass(Type proxyClassName)
        {
            return new Uri("someclass");
        }
        public Dictionary<string, Type> GetXsdProjectItemsInfo()
        {
            Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
            return dictionary;
        }
        public bool NavigateToProperty(string propName)
        {
            return false;
        }
        public void ReferenceAssembly(AssemblyName assemblyName)
        {
        }
        public void RemoveDesignerActions()
        {
        }
        public void ShowToolsOptions()
        {
        }
        public ITypeDescriptorContext GetSelectedPropertyContext()
        {
            return null;
        }
    }
    #endregion
}
#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel.Design;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Collections;
using System.Workflow.ComponentModel;
using System.ComponentModel.Design.Serialization;
using Microsoft.Workflow.DesignerHosting;
using System.Diagnostics;

#endregion

namespace TrackingShell.Design
{
	//internal class ReadOnlyDesignerHostHelper
	//{
	//    public static IWorkflowRootDesigner LoadHostedWorkflow(IServiceProvider provider)
	//    {
	//        Loader loader = new Loader();
	//        InvokedServiceDesignSurface readOnlyDesignSurface = new InvokedServiceDesignSurface(provider);
	//        readOnlyDesignSurface.BeginLoad(loader);
	//        return DesignerHelpers.GetSafeRootDesigner(readOnlyDesignSurface.GetService(typeof(IDesignerHost)) as IServiceProvider);
	//    }

	//    #region Classes needed for hosting the loaded designer

	//    #region Class InvokedServiceDesignSurface
	//    private sealed class InvokedServiceDesignSurface : DesignSurface
	//    {
	//        private TypeDescriptorFilterService typeDescriptorFilter = new TypeDescriptorFilterService();

	//        internal InvokedServiceDesignSurface(IServiceProvider serviceProvider)
	//            //: base(parentDesigner.Component.Site)
	//        {
	//            if (ServiceContainer != null)
	//            {
	//                ServiceContainer.RemoveService(typeof(ISelectionService));

	//                ServiceContainer.RemoveService(typeof(ITypeDescriptorFilterService));
	//                ServiceContainer.AddService(typeof(ITypeDescriptorFilterService), typeDescriptorFilter);

	//                IComponentChangeService componentChangeService = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
	//                if (componentChangeService != null)
	//                    componentChangeService.ComponentAdded += new ComponentEventHandler(OnComponentAdded);
	//            }
	//        }

	//        protected override void Dispose(bool disposing)
	//        {
	//            IComponentChangeService componentChangeService = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
	//            if (componentChangeService != null)
	//                componentChangeService.ComponentAdded -= new ComponentEventHandler(OnComponentAdded);

	//            base.Dispose(disposing);
	//        }
		
	//        private void OnComponentAdded(object sender, ComponentEventArgs eventArgs)
	//        {
	//            MakePropertiesReadOnly(this, eventArgs.Component);
	//        }

	//        internal static void MakePropertiesReadOnly(IServiceProvider serviceProvider, object topComponent)
	//        {
	//            Queue nestedComponents = new Queue();
	//            nestedComponents.Enqueue(topComponent);

	//            while (nestedComponents.Count > 0)
	//            {
	//                object component = nestedComponents.Dequeue();

	//                //add custom readonly type descriptor to the component (to set ForceReadonly flag in the property grid)
	//                TypeDescriptor.AddProvider(new ReadonlyTypeDescriptonProvider(TypeDescriptor.GetProvider(component)), component);

	//                //now go through all the properties and add custom readonly type descriptor to all composite ones
	//                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(component, new Attribute[] { BrowsableAttribute.Yes });
	//                foreach (PropertyDescriptor property in properties)
	//                {
	//                    if (!property.PropertyType.IsPrimitive)
	//                    {
	//                        object decl = property.GetValue(component);
	//                        if (decl != null)
	//                        {
	//                            TypeConverter converter = TypeDescriptor.GetConverter(decl);
	//                            TypeDescriptorContext context = new TypeDescriptorContext(serviceProvider, property, component);
	//                            if (converter.GetPropertiesSupported(context))
	//                            {
	//                                TypeDescriptor.AddProvider(new ReadonlyTypeDescriptonProvider(TypeDescriptor.GetProvider(decl)), decl);
	//                                nestedComponents.Enqueue(decl);
	//                            }
	//                        }
	//                    }
	//                }
	//            }
	//        }

	//        #region TypeDescriptorFilterService
	//        internal sealed class TypeDescriptorFilterService : ITypeDescriptorFilterService
	//        {
	//            internal TypeDescriptorFilterService()
	//            {
	//            }

	//            bool ITypeDescriptorFilterService.FilterAttributes(IComponent component, IDictionary attributes)
	//            {
	//                if (component == null)
	//                    throw new ArgumentNullException("component");

	//                if (attributes == null)
	//                    throw new ArgumentNullException("attributes");

	//                IDesigner designer = DesignerHelpers.GetSafeDesigner(component);
	//                if (designer is IDesignerFilter)
	//                {
	//                    ((IDesignerFilter)designer).PreFilterAttributes(attributes);
	//                    ((IDesignerFilter)designer).PostFilterAttributes(attributes);
	//                }

	//                return (designer != null);
	//            }

	//            bool ITypeDescriptorFilterService.FilterEvents(IComponent component, IDictionary events)
	//            {
	//                if (component == null)
	//                    throw new ArgumentNullException("component");

	//                if (events == null)
	//                    throw new ArgumentNullException("events");

	//                IDesigner designer = DesignerHelpers.GetSafeDesigner(component);
	//                if (designer is IDesignerFilter)
	//                {
	//                    ((IDesignerFilter)designer).PreFilterEvents(events);
	//                    ((IDesignerFilter)designer).PostFilterEvents(events);
	//                }

	//                return (designer != null);
	//            }

	//            bool ITypeDescriptorFilterService.FilterProperties(IComponent component, IDictionary properties)
	//            {
	//                if (component == null)
	//                    throw new ArgumentNullException("component");

	//                if (properties == null)
	//                    throw new ArgumentNullException("properties");

	//                IDesigner designer = DesignerHelpers.GetSafeDesigner(component);
	//                if (designer is IDesignerFilter)
	//                {
	//                    ((IDesignerFilter)designer).PreFilterProperties(properties);
	//                    ((IDesignerFilter)designer).PostFilterProperties(properties);
	//                }

	//                //Make all the properties readonly here
	//                ArrayList keys = new ArrayList(properties.Keys);
	//                foreach (object key in keys)
	//                {
	//                    PropertyDescriptor realPropertyDescriptor = properties[key] as PropertyDescriptor;
	//                    if (realPropertyDescriptor != null)
	//                    {
	//                        BrowsableAttribute browsable = realPropertyDescriptor.Attributes[typeof(BrowsableAttribute)] as BrowsableAttribute;
	//                        if (browsable.Browsable)
	//                            properties[key] = new ReadonlyPropertyDescriptor(realPropertyDescriptor);
	//                    }
	//                }

	//                return (designer != null);
	//            }
	//        }
	//        #endregion
	//    }
	//    #endregion

	//    #region Class TypeDescriptorContext
	//    internal sealed class TypeDescriptorContext : ITypeDescriptorContext
	//    {
	//        private IServiceProvider serviceProvider;
	//        private PropertyDescriptor propDesc;
	//        private object instance;

	//        public TypeDescriptorContext(IServiceProvider serviceProvider, PropertyDescriptor propDesc, object instance)
	//        {
	//            this.serviceProvider = serviceProvider;
	//            this.propDesc = propDesc;
	//            this.instance = instance;
	//        }

	//        public IContainer Container
	//        {
	//            get
	//            {
	//                return (IContainer)this.serviceProvider.GetService(typeof(IContainer));
	//            }
	//        }
	//        public object Instance
	//        {
	//            get
	//            {
	//                return this.instance;
	//            }
	//        }
	//        public PropertyDescriptor PropertyDescriptor
	//        {
	//            get
	//            {
	//                return this.propDesc;
	//            }
	//        }
	//        public object GetService(Type serviceType)
	//        {
	//            return this.serviceProvider.GetService(serviceType);
	//        }

	//        public bool OnComponentChanging()
	//        {
	//            IComponentChangeService componentChangeService = (IComponentChangeService)this.serviceProvider.GetService(typeof(IComponentChangeService));
	//            if (componentChangeService != null)
	//            {
	//                try
	//                {
	//                    componentChangeService.OnComponentChanging(this.instance, this.propDesc);
	//                }
	//                catch (CheckoutException ce)
	//                {
	//                    if (ce == CheckoutException.Canceled)
	//                        return false;
	//                    throw ce;
	//                }
	//            }

	//            return true;
	//        }
	//        public void OnComponentChanged()
	//        {
	//            IComponentChangeService componentChangeService = (IComponentChangeService)this.serviceProvider.GetService(typeof(IComponentChangeService));
	//            if (componentChangeService != null)
	//                componentChangeService.OnComponentChanged(this.instance, this.propDesc, null, null);
	//        }
	//    }
	//        #endregion


	//    #region Class ReadonlyTypeDescriptorProvider
	//    internal sealed class ReadonlyTypeDescriptonProvider : TypeDescriptionProvider
	//    {
	//        internal ReadonlyTypeDescriptonProvider(TypeDescriptionProvider realProvider)
	//            : base(realProvider)
	//        {
	//        }

	//        public override ICustomTypeDescriptor GetTypeDescriptor(Type type, object instance)
	//        {
	//            ICustomTypeDescriptor realTypeDescriptor = base.GetTypeDescriptor(type, instance);
	//            ICustomTypeDescriptor readonlyTypeDescriptor = new ReadonlyTypeDescriptor(realTypeDescriptor);
	//            return readonlyTypeDescriptor;
	//        }
	//    }
	//       #endregion

	//    #region Class ReadonlyTypeDescriptor
	//    internal sealed class ReadonlyTypeDescriptor : CustomTypeDescriptor
	//    {
	//        internal ReadonlyTypeDescriptor(ICustomTypeDescriptor realTypeDescriptor)
	//            : base(realTypeDescriptor)
	//        {
	//        }

	//        public override AttributeCollection GetAttributes()
	//        {
	//            ArrayList collection = new ArrayList();
	//            foreach (Attribute attribute in base.GetAttributes())
	//            {
	//                //should not have any editor attribute and only one readonly attribute
	//                if (!(attribute is EditorAttribute || attribute is ReadOnlyAttribute))
	//                    collection.Add(attribute);
	//            }
	//            collection.Add(new ReadOnlyAttribute(true));
	//            AttributeCollection newCollection = new AttributeCollection((Attribute[])collection.ToArray(typeof(Attribute)));
	//            return newCollection;
	//        }

	//        public override PropertyDescriptorCollection GetProperties()
	//        {
	//            PropertyDescriptorCollection properties = base.GetProperties();

	//            ArrayList readonlyProperties = new ArrayList();
	//            foreach (PropertyDescriptor property in properties)
	//            {
	//                BrowsableAttribute browsable = property.Attributes[typeof(BrowsableAttribute)] as BrowsableAttribute;
	//                if (browsable.Browsable)
	//                    readonlyProperties.Add(new ReadonlyPropertyDescriptor(property));
	//                else
	//                    readonlyProperties.Add(property);
	//            }

	//            return new PropertyDescriptorCollection((PropertyDescriptor[])readonlyProperties.ToArray(typeof(PropertyDescriptor)));
	//        }
	//    }
	//       #endregion

	//    #region Class ReadonlyPropertyDescriptor
	//    internal sealed class ReadonlyPropertyDescriptor : PropertyDescriptor
	//    {
	//        private PropertyDescriptor realPropertyDescriptor;

	//        internal ReadonlyPropertyDescriptor(PropertyDescriptor desc)
	//            : base(desc, null)
	//        {
	//            this.realPropertyDescriptor = desc;
	//        }

	//        public override string Category
	//        {
	//            get
	//            {
	//                return this.realPropertyDescriptor.Category;
	//            }
	//        }
	//        public override AttributeCollection Attributes
	//        {
	//            get
	//            {
	//                ArrayList collection = new ArrayList();
	//                foreach (Attribute attribute in this.realPropertyDescriptor.Attributes)
	//                {
	//                    //should not have any editor attribute and only one readonly attribute
	//                    if (!(attribute is EditorAttribute || attribute is ReadOnlyAttribute))
	//                        collection.Add(attribute);
	//                }
	//                collection.Add(new ReadOnlyAttribute(true));
	//                AttributeCollection newCollection = new AttributeCollection((Attribute[])collection.ToArray(typeof(Attribute)));
	//                return newCollection;
	//            }
	//        }
	//        public override TypeConverter Converter
	//        {
	//            get
	//            {
	//                return this.realPropertyDescriptor.Converter;
	//            }
	//        }
	//        public override string Description
	//        {
	//            get
	//            {
	//                return this.realPropertyDescriptor.Description;
	//            }
	//        }
	//        public override Type ComponentType
	//        {
	//            get
	//            {
	//                return this.realPropertyDescriptor.ComponentType;
	//            }
	//        }
	//        public override Type PropertyType
	//        {
	//            get
	//            {
	//                return this.realPropertyDescriptor.PropertyType;
	//            }
	//        }
	//        public override bool IsReadOnly
	//        {
	//            get
	//            {
	//                return true;
	//            }
	//        }
	//        public override void ResetValue(object component)
	//        {
	//            this.realPropertyDescriptor.ResetValue(component);
	//        }
	//        public override bool CanResetValue(object component)
	//        {
	//            return this.realPropertyDescriptor.CanResetValue(component);
	//        }
	//        public override bool ShouldSerializeValue(object component)
	//        {
	//            return this.realPropertyDescriptor.ShouldSerializeValue(component);
	//        }
	//        public override object GetValue(object component)
	//        {
	//            return this.realPropertyDescriptor.GetValue(component);
	//        }
	//        public override void SetValue(object component, object value)
	//        {
	//            //This is readonly property descriptor
	//            Debug.Assert(false, "SetValue should not be called on readonly property!");
	//        }
	//    }
	//    #endregion

	//    #endregion
	//}
}

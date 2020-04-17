using System;
using System.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Drawing.Design;
using System.Workflow.ComponentModel.Compiler;
using System.ComponentModel.Design;
using System.Collections.Generic;
using Microsoft.VisualStudio.Shell.Design;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;
using EnvDTE;
using System.Reflection;
using System.Diagnostics;

namespace TypeBrowserLibrary
{
	/// <summary>
	/// Editor that allows selection of a type from the current project or a reference in the project.
	/// </summary>
	public class TypeBrowser : UITypeEditor
	{
		TypeBrowserEditor editor = new TypeBrowserEditor();
		ContextProxy flyweight;

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			// Use flyweight pattern to improve performance. It's guaranteed that no more than one instance of 
			// this editor can ever be used at the same time. (it's modal)
			if (flyweight == null)
			{
				flyweight = new ContextProxy(context);
			}
			else
			{
				flyweight.SetContext(context);	
			}

			return editor.EditValue(flyweight, flyweight, value);
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext typeDescriptorContext)
		{
			return editor.GetEditStyle(typeDescriptorContext);
		}

		private class ContextProxy : ITypeDescriptorContext
		{
			ITypeProvider typeProvider;
			ITypeDescriptorContext realContext;

			public ContextProxy(ITypeDescriptorContext realContext)
			{
				this.realContext = realContext;
			}

			internal void SetContext(ITypeDescriptorContext context)
			{
				this.realContext = context;
			}

			#region ITypeDescriptorContext Members

			public IContainer Container
			{
				get { return realContext.Container; }
			}

			public object Instance
			{
				get { return realContext.Instance; }
			}

			public void OnComponentChanged()
			{
				realContext.OnComponentChanged();
			}

			public bool OnComponentChanging()
			{
				return realContext.OnComponentChanging();
			}

			public PropertyDescriptor PropertyDescriptor
			{
				get
				{
					return realContext.PropertyDescriptor;
				}
			}

			private class TypeFilterPropertyDescriptor : PropertyDescriptor, ITypeFilterProvider
			{
				PropertyDescriptor descriptor;
				ITypeFilterProvider filterProvider;

				public TypeFilterPropertyDescriptor(PropertyDescriptor descriptor, ITypeFilterProvider filterProvider) : base(descriptor)
				{
					this.descriptor = descriptor;
					this.filterProvider = filterProvider;
				}

				#region PropertyDescriptor Members

				public override bool CanResetValue(object component)
				{
					return descriptor.CanResetValue(component);
				}

				public override Type ComponentType
				{
					get { return descriptor.ComponentType; }
				}

				public override object GetValue(object component)
				{
					return descriptor.GetValue(component);
				}

				public override bool IsReadOnly
				{
					get { return descriptor.IsReadOnly; }
				}

				public override Type PropertyType
				{
					get { return descriptor.PropertyType; }
				}

				public override void ResetValue(object component)
				{
					descriptor.ResetValue(component);
				}

				public override void SetValue(object component, object value)
				{
					descriptor.SetValue(component, value);
				}

				public override bool ShouldSerializeValue(object component)
				{
					return descriptor.ShouldSerializeValue(component);
				} 

				#endregion

				#region ITypeFilterProvider Members

				public bool CanFilterType(Type type, bool throwOnError)
				{
					return filterProvider.CanFilterType(type, throwOnError);
				}

				public string FilterDescription
				{
					get { return filterProvider.FilterDescription; }
				}

				#endregion
			}

			#endregion

			#region IServiceProvider Members

			public object GetService(Type serviceType)
			{
				if (serviceType == typeof(ITypeProvider))
				{
					if (typeProvider == null) typeProvider = new CustomTypeProvider(this);

					return typeProvider;
				}

				return realContext.GetService(serviceType);
			}

			#endregion
		}

		private class CustomTypeProvider : ITypeProvider
		{
			Dictionary<string, Type> availableTypes;

			public CustomTypeProvider(IServiceProvider provider)
			{
				DynamicTypeService typeService = (DynamicTypeService)provider.GetService(typeof(DynamicTypeService));
				Debug.Assert(typeService != null, "No dynamic type service registered.");

				IVsHierarchy hier = VsHelper.GetCurrentHierarchy(provider);
				Debug.Assert(hier != null, "No active hierarchy is selected.");

				ITypeDiscoveryService discovery = typeService.GetTypeDiscoveryService(hier);
				Project dteProject = VsHelper.ToDteProject(hier);

				availableTypes = new Dictionary<string, Type>();
				foreach (Type type in discovery.GetTypes(typeof(object), false))
				{
					if (!availableTypes.ContainsKey(type.FullName))
					{
						if (type.Assembly.GetName().Name != (string)dteProject.Properties.Item("AssemblyName").Value)
						{
							availableTypes.Add(type.FullName, type);
						}
						else
						{
							availableTypes.Add(type.FullName, new ProjectType(type));
						}
					}
				}
			}

			private class ProjectType : TypeDelegator
			{
				public ProjectType(Type delegatingType) : base(delegatingType) { }

				public override Assembly Assembly
				{
					get { return null; }
				}
			}

			#region ITypeProvider Members

			public Type GetType(string name, bool throwOnError)
			{
				if (String.IsNullOrEmpty(name))
				{
					return null;
				}

				if (availableTypes.ContainsKey(name))
				{
					Type type = availableTypes[name];
					if (type is TypeDelegator)
					{
						return ((TypeDelegator)type).UnderlyingSystemType;
					}
					else
					{
						return type;
					}
				}
				else
				{
					if (throwOnError)
					{
						throw new TypeLoadException();
					}
					else
					{
						return null;
					}
				}
			}

			public Type GetType(string name)
			{
				return GetType(name, false);
			}

			public Type[] GetTypes()
			{
				Type[] result = new Type[availableTypes.Count];
				availableTypes.Values.CopyTo(result, 0);

				return result;
			}

			public System.Reflection.Assembly LocalAssembly
			{
				// TODO
				get { return this.GetType().Assembly; }
			}

			public System.Collections.Generic.IDictionary<object, Exception> TypeLoadErrors
			{
				get { return new Dictionary<object, Exception>(); }
			}

			public event EventHandler TypeLoadErrorsChanged;

			public event EventHandler TypesChanged;

            public ICollection<Assembly> ReferencedAssemblies
            {
                get { throw new NotImplementedException(); }
            }
			#endregion
		}

        #region Dummy services for type browser initialization

        private class DummyDictionaryService : IDictionaryService
        {
            private Dictionary<object, object> dict = new Dictionary<object, object>();

            #region IDictionaryService Members

            public object GetKey(object value)
            {
                throw new NotImplementedException();
            }

            public object GetValue(object key)
            {
                if (dict.ContainsKey(key))
                {
                    return dict[key];
                }
                return null;
            }

            public void SetValue(object key, object value)
            {
                if (dict.ContainsKey(key))
                {
                    dict[key] = value;
                }
                else
                {
                    dict.Add(key, value);
                }
            }

            #endregion
        }

        private class DummyDesignerHost : IDesignerHost
        {
            #region IDesignerHost Members

            public void Activate()
            {
                throw new NotImplementedException();
            }

#pragma warning disable 67
            public event EventHandler Activated;
#pragma warning restore 67

            public IContainer Container
            {
                get { return new Container(); }
            }

            public IComponent CreateComponent(Type componentClass, string name)
            {
                throw new NotImplementedException();
            }

            public IComponent CreateComponent(Type componentClass)
            {
                throw new NotImplementedException();
            }

            public DesignerTransaction CreateTransaction(string description)
            {
                throw new NotImplementedException();
            }

            public DesignerTransaction CreateTransaction()
            {
                throw new NotImplementedException();
            }
#pragma warning disable 67
            public event EventHandler Deactivated;
#pragma warning restore 67

            public void DestroyComponent(IComponent component)
            {
                throw new NotImplementedException();
                
            }

            public IDesigner GetDesigner(IComponent component)
            {
                throw new NotImplementedException();
            }

            public Type GetType(string typeName)
            {
                throw new NotImplementedException();
            }

            public bool InTransaction
            {
                get { throw new NotImplementedException(); }
            }

#pragma warning disable 67
            public event EventHandler LoadComplete;
#pragma warning restore 67

            public bool Loading
            {
                get { throw new NotImplementedException(); }
            }

            public IComponent RootComponent
            {
                get { return new Component(); }
            }

            public string RootComponentClassName
            {
                get { throw new NotImplementedException(); }
            }

#pragma warning disable 67
            public event DesignerTransactionCloseEventHandler TransactionClosed;

            public event DesignerTransactionCloseEventHandler TransactionClosing;
#pragma warning restore 67

            public string TransactionDescription
            {
                get { throw new NotImplementedException(); }
            }

#pragma warning disable 67
            public event EventHandler TransactionOpened;

            public event EventHandler TransactionOpening;
#pragma warning restore 67

            #endregion

            #region IServiceContainer Members

            public void AddService(Type serviceType, ServiceCreatorCallback callback, bool promote)
            {
                throw new NotImplementedException();
            }

            public void AddService(Type serviceType, ServiceCreatorCallback callback)
            {
                throw new NotImplementedException();
            }

            public void AddService(Type serviceType, object serviceInstance, bool promote)
            {
                throw new NotImplementedException();
            }

            public void AddService(Type serviceType, object serviceInstance)
            {
                throw new NotImplementedException();
            }

            public void RemoveService(Type serviceType, bool promote)
            {
                throw new NotImplementedException();
            }

            public void RemoveService(Type serviceType)
            {
                throw new NotImplementedException();
            }

            #endregion

            #region IServiceProvider Members

            public object GetService(Type serviceType)
            {
                return null;
            }

            #endregion
        }

        private class DummyWorkflowDesignerLoader : WorkflowDesignerLoader
        {
            public override string FileName
            {
                get { throw new NotImplementedException(); }
            }

            public override System.IO.TextReader GetFileReader(string filePath)
            {
                throw new NotImplementedException();
            }

            public override System.IO.TextWriter GetFileWriter(string filePath)
            {
                throw new NotImplementedException();
            }
        }

        #endregion
	}
}


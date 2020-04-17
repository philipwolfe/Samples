//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
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

namespace WorkflowImageProvider.WorkflowDesigner
{
	using System;
	using System.IO;
	using System.ComponentModel;
	using System.ComponentModel.Design;
	using System.ComponentModel.Design.Serialization;
	using System.Workflow.ComponentModel;
	using System.Workflow.ComponentModel.Compiler;
	using System.Workflow.ComponentModel.Design;
	using System.Workflow.ComponentModel.Serialization;
	using System.Collections;
	using System.Collections.Generic;
	using System.Drawing.Design;
	using System.Xml;

	internal sealed class WorkflowDesignerLoader : System.Workflow.ComponentModel.Design.WorkflowDesignerLoader
	{
		private string xoml = string.Empty;

		/// <summary>
		/// Initializes a new instance of the <see cref="WorkflowLoader"/> class.
		/// </summary>
		internal WorkflowDesignerLoader()
		{
		}

		/// <summary>
		/// Initializes the <see cref="T:System.Workflow.ComponentModel.Design.WorkflowDesignerLoader"></see> with any services required by the designer loader host.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();

			IDesignerLoaderHost host = LoaderHost;
			if (host != null)
			{
				host.RemoveService(typeof(IIdentifierCreationService));
				host.AddService(typeof(IIdentifierCreationService), new IdentifierCreationService(host));
				host.AddService(typeof(IMenuCommandService), new WorkflowMenuCommandService(host));
				//host.AddService(typeof(IToolboxService), new Toolbox(host));
				TypeProvider typeProvider = new TypeProvider(host);
				typeProvider.AddAssemblyReference(typeof(string).Assembly.Location);
				host.AddService(typeof(ITypeProvider), typeProvider, true);
				host.AddService(typeof(IEventBindingService), new EventBindingService());
			}
		}

		/// <summary>
		/// Releases all resources used by the <see cref="T:System.Workflow.ComponentModel.Design.WorkflowDesignerLoader"></see>.
		/// </summary>
		public override void Dispose()
		{
			IDesignerLoaderHost host = LoaderHost;
			if (host != null)
			{
				host.RemoveService(typeof(IIdentifierCreationService));
				host.RemoveService(typeof(IMenuCommandService));
				host.RemoveService(typeof(IToolboxService));
				host.RemoveService(typeof(ITypeProvider), true);
				host.RemoveService(typeof(IWorkflowCompilerOptionsService));
				host.RemoveService(typeof(IEventBindingService));
			}

			base.Dispose();
		}

		/// <summary>
		/// When overridden in a derived class, causes <see cref="T:System.Workflow.ComponentModel.Design.WorkflowDesignerLoader"></see> to reload the designer.
		/// </summary>
		public override void ForceReload()
		{
		}

		/// <summary>
		/// Gets the default namespace.
		/// </summary>
		/// <value>The default namespace.</value>
		public string DefaultNamespace
		{
			get
			{
				return "SampleNamespace";
			}
		}

		/// <summary>
		/// Gets or sets the xoml.
		/// </summary>
		/// <value>The xoml.</value>
		public string Xoml
		{
			get
			{
				return this.xoml;
			}

			set
			{
				this.xoml = value;
			}
		}

		private Type workflowType = null;

		/// <summary>
		/// Gets or sets the type of the workflow.
		/// </summary>
		/// <value>The type of the workflow.</value>
		public Type WorkflowType
		{
			get { return workflowType; }
			set { workflowType = value; }
		}

		private string xomlFile = string.Empty;

		/// <summary>
		/// Gets or sets the path to the xoml file.
		/// </summary>
		/// <value>The path to the xoml file.</value>
		public string XomlFile
		{
			get
			{
				return this.xomlFile;
			}
			set
			{
				this.xomlFile = value;
			}
		}

		/// <summary>
		/// When overridden in a derived class, gets the file name of the designer to load.
		/// </summary>
		/// <value></value>
		/// <returns>A string that contains the file name of the designer to load.</returns>
		public override string FileName
		{
			get { return string.Empty; }
		}

		/// <summary>
		/// When overridden in a derived class, retrieves an object that <see cref="T:System.Workflow.ComponentModel.Design.WorkflowDesignerLoader"></see> uses to read from the specified file.
		/// </summary>
		/// <param name="filePath">A string that contains a path to the file to read from.</param>
		/// <returns>
		/// A <see cref="T:System.IO.TextReader"></see> to read the specified file.
		/// </returns>
		public override TextReader GetFileReader(string filePath)
		{
			return new StreamReader(new FileStream(filePath, FileMode.OpenOrCreate));
		}

		/// <summary>
		/// When overridden in a derived class, gets an object that the <see cref="T:System.Workflow.ComponentModel.Design.WorkflowDesignerLoader"></see> uses to write to the specified file.
		/// </summary>
		/// <param name="filePath">A string that contains the path to the file to write to.</param>
		/// <returns>
		/// A <see cref="T:System.IO.TextWriter"></see> to write to the file.
		/// </returns>
		public override TextWriter GetFileWriter(string filePath)
		{
			// clsoe the handle
			return new StreamWriter(new FileStream(filePath, FileMode.OpenOrCreate));
		}

		/// <summary>
		/// Loads the designer from a design document.
		/// </summary>
		/// <param name="serializationManager">Class that implements the <see cref="T:System.ComponentModel.Design.Serialization.IDesignerSerializationManager"></see> interface, which manages design-time serialization.</param>
		protected override void PerformLoad(IDesignerSerializationManager serializationManager)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			Activity rootActivity = null;
			//First see if we have a workflow type
			if (WorkflowType != null)
			{
				rootActivity = (Activity)Activator.CreateInstance(WorkflowType);
			}
			else
			{
				// Create a text reader out of the doc data, and ask
				TextReader reader = new StringReader(this.xoml);
				try
				{
					using (XmlReader xmlReader = XmlReader.Create(reader))
					{
						WorkflowMarkupSerializer xomlSerializer = new WorkflowMarkupSerializer();
						rootActivity = xomlSerializer.Deserialize(xmlReader) as Activity;
					}
				}
				finally
				{
					reader.Close();
				}
			}

			if (rootActivity != null && designerHost != null)
			{
				AddObjectGraphToDesignerHost(designerHost, rootActivity);
			}
		}

		/// <summary>
		/// Flushes the given IDesignerSerializationManager, it is the developers choice where to flush this, we ignore it.
		/// </summary>
		/// <param name="manager">The manager.</param>
		protected override void PerformFlush(IDesignerSerializationManager manager)
		{
		}

		/// <summary>
		/// Serializes our root-component to disc.
		/// </summary>
		public void PerformFlush()
		{
			IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));

			if (host != null && host.RootComponent != null)
			{
				Activity service = host.RootComponent as Activity;

				if (service != null)
				{
					using (XmlWriter writer = XmlWriter.Create(this.xomlFile))
					{
						WorkflowMarkupSerializer xomlSerializer = new WorkflowMarkupSerializer();
						xomlSerializer.Serialize(writer, service);
					}
				}
			}
		}

		/// <summary>
		/// Adds the object graph to designer host.
		/// </summary>
		/// <param name="designerHost">The designer host.</param>
		/// <param name="activity">The activity.</param>
		private static void AddObjectGraphToDesignerHost(IDesignerHost designerHost, Activity activity)
		{
			Guid Definitions_Class = new Guid("3FA84B23-B15B-4161-8EB8-37A54EFEEFC7");

			if (designerHost == null)
				throw new ArgumentNullException("designerHost");
			if (activity == null)
				throw new ArgumentNullException("activity");

			string rootSiteName = activity.QualifiedName;
			if (activity.Parent == null)
			{
				string fullClassName = activity.UserData[Definitions_Class] as string;
				if (fullClassName == null)
					fullClassName = activity.GetType().FullName;
				rootSiteName = (fullClassName.LastIndexOf('.') != -1) ? fullClassName.Substring(fullClassName.LastIndexOf('.') + 1) : fullClassName;
				designerHost.Container.Add(activity, rootSiteName);
			}
			else
			{
				designerHost.Container.Add(activity, activity.QualifiedName);
			}

			if (activity is CompositeActivity)
			{
				foreach (Activity activity2 in GetNestedActivities(activity as CompositeActivity))
					designerHost.Container.Add(activity2, activity2.QualifiedName);
			}
		}

		/// <summary>
		/// Gets the nested activities.
		/// </summary>
		/// <param name="compositeActivity">The composite activity.</param>
		/// <returns></returns>
		private static Activity[] GetNestedActivities(CompositeActivity compositeActivity)
		{
			if (compositeActivity == null)
				throw new ArgumentNullException("compositeActivity");

			IList<Activity> childActivities = null;
			ArrayList nestedActivities = new ArrayList();
			Queue compositeActivities = new Queue();
			compositeActivities.Enqueue(compositeActivity);
			while (compositeActivities.Count > 0)
			{
				CompositeActivity compositeActivity2 = (CompositeActivity)compositeActivities.Dequeue();
				childActivities = compositeActivity2.Activities;

				foreach (Activity activity in childActivities)
				{
					nestedActivities.Add(activity);
					if (activity is CompositeActivity)
						compositeActivities.Enqueue(activity);
				}
			}
			return (Activity[])nestedActivities.ToArray(typeof(Activity));
		}

		/// <summary>
		/// Destroys the object graph from designer host.
		/// </summary>
		/// <param name="designerHost">The designer host.</param>
		/// <param name="activity">The activity.</param>
		internal static void DestroyObjectGraphFromDesignerHost(IDesignerHost designerHost, Activity activity)
		{
			if (designerHost == null)
				throw new ArgumentNullException("designerHost");
			if (activity == null)
				throw new ArgumentNullException("activity");

			designerHost.DestroyComponent(activity);

			if (activity is CompositeActivity)
			{
				foreach (Activity activity2 in GetNestedActivities(activity as CompositeActivity))
					designerHost.DestroyComponent(activity2);
			}
		}
	}
}

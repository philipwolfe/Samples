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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.Activities;
using System.Workflow.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Workflow.ComponentModel.Serialization;
using System.Xml;
using System.CodeDom.Compiler;
using System.Workflow.Runtime;
using System.Drawing.Imaging;

namespace WorkflowImageProvider.WorkflowDesigner
{
	public partial class WorkflowDesignerControl : UserControl, IDisposable, IServiceProvider
	{
		/// <summary>
		/// workflowView, implements the control that renders a visual representation 
		/// of the process flow described in the workflow definition
		/// </summary>
		private WorkflowView workflowView;
		/// <summary>
		/// DesignSurface provides a self-contained environment to display the designer 
		/// components. This is ultimately what the user perceives as a designer. This 
		/// class is used to access the root designer associated with the 
		/// workflow definition.
		/// </summary>
		private DesignSurface designSurface;
		/// <summary>
		/// loader, an implementation of a designer loader that developers will subclass 
		/// to implement custom loading and unloading logic
		/// </summary>
		private WorkflowDesignerLoader workflowDesignerLoader;

		/// <summary>
		/// the sequential activity will be loaded into this variable
		/// </summary>
		SequentialWorkflowActivity workflow = null;
		internal static readonly string XomlExample = @"<SequentialWorkflowActivity x:Class=""HelloWorld.HelloWorldWorkflow"" x:Name=""HelloWorldWorkflow"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/workflow"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
                                                <CodeActivity x:Name=""CodeActivity1"" ExecuteCode=""CodeActivity1_ExecuteCode""/>
                                                <x:Code>
                                                <![CDATA[
                                                void CodeActivity1_ExecuteCode(object o,EventArgs e)
                                                {
	                                                System.Console.WriteLine(""Hello World"");
                                                }
                                                ]]>
                                                </x:Code>
                                                </SequentialWorkflowActivity>";

		/// <summary>
		/// Initializes a new instance of the <see cref="WorkflowDesignerControl"/> class.
		/// </summary>
		public WorkflowDesignerControl()
		{
			InitializeComponent();

			WorkflowTheme.CurrentTheme.ReadOnly = false;
			WorkflowTheme.CurrentTheme.AmbientTheme.ShowConfigErrors = false;
		}

		/// <summary>
		/// Gets or sets the path to the xoml file.
		/// </summary>
		/// <value>The path to the xoml file.</value>
		public string XomlFile
		{
			get
			{
				return this.workflowDesignerLoader.XomlFile;
			}
			set
			{
				this.workflowDesignerLoader.XomlFile = value;
			}
		}

		/// <summary>
		/// Saves an image of the System.Workflow.ComponentModel.Design.WorkflowView
		/// to the specified file using the specified image format.
		/// </summary>
		/// <param name="s">The System.IO.Stream to save the workflow view image to.</param>
		/// <param name="format">The System.Drawing.Imaging.ImageFormat to use to save the workflow view image.</param>
		public void SaveWorkflowImage(Stream s, ImageFormat format)
		{
			this.workflowView.SaveWorkflowImage(s, format);
		}

		/// <summary>
		/// Gets or sets the xoml.
		/// <para>
		/// Note: Set will load the given XOML into the designer.
		/// </para>
		/// </summary>
		/// <value>The xoml.</value>
		public string Xoml
		{
			get
			{
				string xoml = string.Empty;
				if (this.workflowDesignerLoader != null)
				{
					try
					{
						this.workflowDesignerLoader.Flush();
						xoml = this.workflowDesignerLoader.Xoml;
					}
					catch
					{
					}
				}
				return xoml;
			}
			set
			{
				try
				{
					if (!String.IsNullOrEmpty(value))
						LoadWorkflow(value);
				}
				catch
				{
				}
			}
		}

		/// <summary>
		/// Gets the name of the workflow.
		/// </summary>
		/// <value>The name of the workflow.</value>
		public string WorkflowName
		{
			get
			{
				return this.workflow == null ? string.Empty : this.workflow.Name;
			}
		}

		/// <summary>
		/// Disposes the specified disposing.
		/// </summary>
		/// <param name="disposing">if set to <c>true</c> then we are disposing.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				UnloadWorkflow();
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Gets the service object of the specified type.
		/// </summary>
		/// <param name="serviceType">An object that specifies the type of service object to get.</param>
		/// <returns>
		/// A service object of type serviceType.-or- null if there is no service object of type serviceType.
		/// </returns>
		new public object GetService(Type serviceType)
		{
			return (this.workflowView != null) ? ((IServiceProvider)this.workflowView).GetService(serviceType) : null;
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.UserControl.Load"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			ShowDefaultWorkflow();
		}

		/// <summary>
		/// Loads the workflow into the designer.
		/// </summary>
		/// <param name="xoml">The xoml which describes the root component and any child components.</param>
		private void LoadWorkflow(string xoml)
		{
			SuspendLayout();

			DesignSurface tempDesignSurface = new DesignSurface();
			WorkflowDesignerLoader tempWorkflowDesignerLoader = new WorkflowDesignerLoader();
			tempWorkflowDesignerLoader.Xoml = xoml;

			/* load the design surface using the loader. This will call the PerformLoad 
			 * method on the loader, create the activity tree and add the corresponding 
			 * designer components to the designer host 
			 */
			tempDesignSurface.BeginLoad(tempWorkflowDesignerLoader);

			/* Get the designer host and retrieve the corresponding root component */
			IDesignerHost designerHost = tempDesignSurface.GetService(typeof(IDesignerHost)) as IDesignerHost;

			/* The DesignerHost class acts as a service container and service provider that various 
			 * services are added to and accessed. Developers add custom implementation of a service 
			 * or use the default one that is provided. Once the design surface is loaded, using the 
			 * WorkflowView control, the user can drag drop activities into it and define a workflow. 
			 */

			if (designerHost != null && designerHost.RootComponent != null)
			{
				/* Get the designer associated with the root component */
				IRootDesigner rootDesigner = designerHost.GetDesigner(designerHost.RootComponent) as IRootDesigner;
				if (rootDesigner != null)
				{
					UnloadWorkflow();

					this.designSurface = tempDesignSurface;
					this.workflowDesignerLoader = tempWorkflowDesignerLoader;

					/* Assign the default view of the rootdesigner to WorkflowView */
					this.workflowView = rootDesigner.GetView(ViewTechnology.Default) as WorkflowView;

					/* Add the workflow view control to the controll */
					this.pnlDesigner.Controls.Add(this.workflowView);
					this.workflowView.Dock = DockStyle.Fill;
					this.workflowView.TabIndex = 1;
					this.workflowView.TabStop = true;
					this.workflowView.HScrollBar.TabStop = false;
					this.workflowView.VScrollBar.TabStop = false;
					this.workflowView.Focus();
				}
			}
			ResumeLayout(true);
		}

		/// <summary>
		/// Unloads the workflow from the designer
		/// </summary>
		private void UnloadWorkflow()
		{
			IDesignerHost designerHost = GetService(typeof(IDesignerHost)) as IDesignerHost;
			if (designerHost != null && designerHost.Container.Components.Count > 0)
				WorkflowDesignerLoader.DestroyObjectGraphFromDesignerHost(designerHost, designerHost.RootComponent as Activity);

			if (this.designSurface != null)
			{
				this.designSurface.Dispose();
				this.designSurface = null;
			}

			if (this.workflowView != null)
			{
				Controls.Remove(this.workflowView);
				this.workflowView.Dispose();
				this.workflowView = null;
			}
		}

		/// <summary>
		/// Shows the default workflow.
		/// <para>
		/// We simply feed the workflow designer our very simple SequentialWorkflowActivity
		/// </para>
		/// </summary>
		private void ShowDefaultWorkflow()
		{
			this.Xoml = XomlExample;
		}

		/// <summary>
		/// Gets the RootActivity from the provided Child activity.
		/// </summary>
		/// <param name="child">The child.</param>
		/// <returns></returns>
		internal Activity GetRoot(Activity child)
		{
			Activity temp = child;
			while (temp.Parent != null)
			{
				temp = temp.Parent;
			}
			return temp;
		}

		/// <summary>
		/// Gets the parent activity for a StateMachineWorkflowActivity.
		/// </summary>
		/// <param name="child">The child.</param>
		/// <returns></returns>
		internal Activity[] GetStateParentActivity(Activity child)
		{
			if (child.Parent == null)
				return new Activity[] { null, null };
			Activity activity1 = child;
			Activity temp = null;
			while (activity1.GetType() != typeof(StateActivity) || activity1.Parent == null)
			{
				temp = activity1;
				activity1 = activity1.Parent;

			}
			return new Activity[] { activity1, temp };

		}

		/// <summary>
		/// Highlights the provided activity.
		/// </summary>
		/// <param name="activityName">Name of the activity to highlight.</param>
		public void HighlightActivity(string activityName)
		{
			ISelectionService selectionService = (ISelectionService)designSurface.GetService(typeof(ISelectionService));
			IReferenceService referenceService = (IReferenceService)designSurface.GetService(typeof(IReferenceService));

			if (selectionService != null && referenceService != null)
			{
				Activity activityComponent = (Activity)referenceService.GetReference(activityName);

				if (activityComponent != null)
				{

					IDesignerHost designerHost = designSurface.GetService(typeof(IDesignerHost)) as IDesignerHost;
					if (designerHost != null)
					{

						Activity root = GetRoot(activityComponent);
						bool statemachine = root is StateMachineWorkflowActivity;

						if (statemachine)
						{
							Activity[] parents = GetStateParentActivity(activityComponent);
							Activity state = parents[1];
							Activity pstate = parents[0];
							if (state != null && pstate != null)
							{
								ActivityDesigner sd = designerHost.GetDesigner(state) as ActivityDesigner;
								FreeformActivityDesigner parentd = designerHost.GetDesigner(pstate) as FreeformActivityDesigner;
								parentd.EnsureVisibleContainedDesigner(sd);
							}
						}

						ActivityDesigner ad = designerHost.GetDesigner(activityComponent) as ActivityDesigner;
						//ad.DesignerTheme.BackColorEnd = Color.OrangeRed;
						//ad.DesignerTheme.BackColorStart = Color.OrangeRed;
						selectionService.SetSelectedComponents(new IComponent[] { activityComponent as IComponent }, SelectionTypes.Primary);
						workflowView.PerformLayout(true);
					}
				}
			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			try
			{
				HighlightActivity(toolStripComboBox1.SelectedText);
			}
			catch
			{
			}
		}
	}
}

//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
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
using System.Reflection;

namespace WorkflowDesignerControl
{
    public partial class WorkflowDesignerControl : UserControl, IDisposable, IServiceProvider
    {
        private WorkflowView workflowView;
        private DesignSurface designSurface;
        private WorkflowLoader loader;
        static Assembly inMemoryAssembly;
        private WorkflowRuntime workflowRuntime;
        SequentialWorkflowActivity workflow;

        private const string AdditionalAssembies = "ActivityLibrary.dll";

        public WorkflowDesignerControl()
        {
            InitializeComponent();

            WorkflowTheme.CurrentTheme.ReadOnly = false;
            WorkflowTheme.CurrentTheme.AmbientTheme.ShowConfigErrors = false;
            WorkflowTheme.CurrentTheme.ReadOnly = true;

            this.propertyGrid.BackColor = BackColor;
            this.propertyGrid.Font = WorkflowTheme.CurrentTheme.AmbientTheme.Font;

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (inMemoryAssembly.FullName == args.Name)
            {
                return inMemoryAssembly;
            }
            else
            {
                return null;
            }
        }

        public string XomlFile
        {
            get
            {
                return this.loader.XomlFile;
            }
            set
            {
                this.loader.XomlFile = value;
            }
        }

        public string Xoml
        {
            get
            {
                string xoml = string.Empty;
                if (this.loader != null)
                {
                    try
                    {
                        this.loader.Flush();
                        xoml = this.loader.Xoml;
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

        public string WorkflowName
        {
            get
            {
                return this.workflow == null ? string.Empty : this.workflow.Name;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                UnloadWorkflow();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        new public object GetService(Type serviceType)
        {
            return (this.workflowView != null) ? ((IServiceProvider)this.workflowView).GetService(serviceType) : null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ShowDefaultWorkflow();
        }

        private void LoadWorkflow(string xoml)
        {
            SuspendLayout();

            DesignSurface designSurface = new DesignSurface();
            WorkflowLoader loader = new WorkflowLoader();
            loader.Xoml = xoml;
            designSurface.BeginLoad(loader);

            IDesignerHost designerHost = designSurface.GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (designerHost != null && designerHost.RootComponent != null)
            {
                IRootDesigner rootDesigner = designerHost.GetDesigner(designerHost.RootComponent) as IRootDesigner;
                if (rootDesigner != null)
                {
                    UnloadWorkflow();

                    this.designSurface = designSurface;
                    this.loader = loader;
                    this.workflowView = rootDesigner.GetView(ViewTechnology.Default) as WorkflowView;
                    this.workflowViewSplitter.Panel1.Controls.Add(this.workflowView);
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

        private void UnloadWorkflow()
        {
            IDesignerHost designerHost = GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (designerHost != null && designerHost.Container.Components.Count > 0)
                WorkflowLoader.DestroyObjectGraphFromDesignerHost(designerHost, designerHost.RootComponent as Activity);

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

        private void ShowDefaultWorkflow()
        {
            this.workflow = new SequentialWorkflowActivity();
            workflow.Name = "CustomWorkflow";

            this.LoadWorkflow();
        }

        private void LoadWorkflow()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
                {
                    WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
                    serializer.Serialize(xmlWriter, workflow);
                    this.Xoml = stringWriter.ToString();
                }
            }
        }

        public void ProcessZoom(int zoomFactor)
        {
            this.workflowView.Zoom = zoomFactor;
            this.workflowView.Update();
        }

    }
}

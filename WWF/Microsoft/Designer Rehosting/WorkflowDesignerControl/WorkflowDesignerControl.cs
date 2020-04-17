//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
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
using System.CodeDom;
using System.CodeDom.Compiler;

namespace WorkflowDesignerControl
{
    public partial class WorkflowDesignerControl : UserControl, IDisposable, IServiceProvider, ISite
    {
        private WorkflowView            workflowView;
        private DesignSurface           designSurface;
        private WorkflowLoader          loader;
        private string typeName;
        private string nameSpace;

        public WorkflowDesignerControl()
        {
            InitializeComponent();

            ToolboxService toolbox = new ToolboxService(this);
            this.propertyGridSplitter.Panel1.Controls.Add(toolbox);
            toolbox.Dock = DockStyle.Fill;
            toolbox.BackColor = BackColor;
            toolbox.Font = WorkflowTheme.CurrentTheme.AmbientTheme.Font;

            WorkflowTheme.CurrentTheme.ReadOnly = false;
            WorkflowTheme.CurrentTheme.AmbientTheme.ShowConfigErrors = false;
            WorkflowTheme.CurrentTheme.ReadOnly = true;

            this.propertyGrid.BackColor = BackColor;
            this.propertyGrid.Font = WorkflowTheme.CurrentTheme.AmbientTheme.Font;
            this.propertyGrid.Site = this;
        }



        public string NameSpace
        {
            get { return nameSpace; }
            set { nameSpace = value; }
        }

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
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

        
        public WorkflowView WorkflowView
        {
            get { return this.workflowView; }
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

        public void LoadWorkflow(string xoml)
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
                    this.propertyGrid.Site = designerHost.RootComponent.Site;

                    ISelectionService selectionService = GetService(typeof(ISelectionService)) as ISelectionService;
                    if (selectionService != null)
                        selectionService.SelectionChanged += new EventHandler(OnSelectionChanged);
                }
            }

            ResumeLayout(true);

            // Add the code compile unit for the xaml file
            TypeProvider typeProvider = (TypeProvider)GetService(typeof(ITypeProvider));
            this.loader.XamlCodeCompileUnit = new CodeCompileUnit();
            this.loader.XamlCodeCompileUnit.Namespaces.Add(Helpers.GenerateCodeFromXomlDocument(Helpers.GetRootActivity(xoml), this, ref this.nameSpace, ref this.typeName));
            typeProvider.AddCodeCompileUnit(this.loader.XamlCodeCompileUnit);
        }

        private void UnloadWorkflow()
        {
            IDesignerHost designerHost = GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (designerHost != null && designerHost.Container.Components.Count > 0)
                WorkflowLoader.DestroyObjectGraphFromDesignerHost(designerHost, designerHost.RootComponent as Activity);

            ISelectionService selectionService = GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null)
                selectionService.SelectionChanged -= new EventHandler(OnSelectionChanged);

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

        public void ShowDefaultWorkflow()
        {
            SequentialWorkflowActivity workflow = new SequentialWorkflowActivity();
            //StateMachineWorkflowActivity workflow = new StateMachineWorkflowActivity();
            workflow.Name = "Workflow1";
            workflow.SetValue(WorkflowMarkupSerializer.XClassProperty, "foo.Workflow1");
            XmlWriter xmlWriter = XmlTextWriter.Create(@"C:\Myfile.xoml");
            WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
            serializer.Serialize(xmlWriter, workflow);
            xmlWriter.Close();
            LoadWorkflow(@"C:\Myfile.xoml");
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            ISelectionService selectionService = GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null)
                this.propertyGrid.SelectedObjects = new ArrayList(selectionService.GetSelectedComponents()).ToArray();
        }


        public void InvokeStandardCommand(CommandID cmd)
        {
            IMenuCommandService menuService = GetService(typeof(IMenuCommandService)) as IMenuCommandService;
            if (menuService != null)
                menuService.GlobalInvoke(cmd);
        }

        /// <summary>
        /// Save the file. We also refresh the type provider when we save the file
        /// </summary>
        /// <param name="filePath">The path of the file to save</param>
        public void Save(string filePath)
        {
            if (this.loader != null)
            {
                if (filePath != null && filePath != string.Empty)
                    this.loader.Xoml = filePath;
                this.loader.Flush();
            }

            // Referesh the code compile unit every time the file is saved
            TypeProvider typeProvider = (TypeProvider)GetService(typeof(ITypeProvider));
            typeProvider.RemoveCodeCompileUnit(this.loader.XamlCodeCompileUnit);
            this.loader.XamlCodeCompileUnit = new CodeCompileUnit();
            this.loader.XamlCodeCompileUnit.Namespaces.Add(Helpers.GenerateCodeFromXomlDocument(Helpers.GetRootActivity(filePath != null ? filePath : this.loader.Xoml), this, ref this.nameSpace, ref this.typeName));
            typeProvider.AddCodeCompileUnit(this.loader.XamlCodeCompileUnit);
        }

        /// <summary>
        /// Compile the workflow along with the code beside file and the rules file if they exist
        /// </summary>
        public void CompileWorkflow()
        {
            if (string.IsNullOrEmpty(this.loader.Xoml))
                return;
            
            if (!File.Exists(this.loader.Xoml))
            {
                MessageBox.Show(this, "Cannot locate XAML file: " + Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), this.loader.Xoml), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // If everything is Ok then save the files before compiling
            this.Save(this.loader.Xoml);

            Cursor cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // Check for code beside file and rules file

                WorkflowCompiler compiler = new WorkflowCompiler();
                WorkflowCompilerParameters parameters = new WorkflowCompilerParameters();

                string codeBesideFile = Path.Combine(Path.GetDirectoryName(this.loader.Xoml), Path.GetFileNameWithoutExtension(this.loader.Xoml) + ".cs");
                string rulesFile = Path.Combine(Path.GetDirectoryName(this.loader.Xoml), Path.GetFileNameWithoutExtension(this.loader.Xoml) + ".rules");

                ArrayList files = new ArrayList();
                files.Add(this.loader.Xoml);

                if (File.Exists(codeBesideFile))
                    files.Add(codeBesideFile);

                if (File.Exists(rulesFile))
                {
                    // adding the rules file to the resources
                    string resources = @"/resource:" + rulesFile + "," + this.NameSpace + "." + this.TypeName + "." + "rules";
                    parameters.CompilerOptions += resources;
                }

                object[] objArray = new object[] { };
                objArray = files.ToArray();

                string[] strArr = new string[objArray.Length];
                Array.Copy(objArray, 0, strArr, 0, objArray.Length);

                // Compile the workflow
                                
                parameters.OutputAssembly = "CustomWorkflow" + Guid.NewGuid().ToString() + ".dll";
                WorkflowCompilerResults results = compiler.Compile(parameters, strArr);

                StringBuilder errors = new StringBuilder();
                foreach (CompilerError compilerError in results.Errors)
                {
                    errors.Append(compilerError.ToString() + '\n');
                }

                if (errors.Length != 0)
                {
                    MessageBox.Show(this, errors.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(this, "Workflow compiled successfully. Compiled assembly: \n" + results.CompiledAssembly.GetName(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                this.Cursor = cursor;
            }
        }

        /// <summary>
        /// We listen to the event when the property browser gets the focus and save the xaml
        /// Reason: This is done to support using activities in the rule set editor. In VS, the xaml file is 
        /// flushed when the application is idle or when you save or change the view to new file. Only after the
        /// file is flushed, the type provider is updated with the contents of the xaml file. Hence in this case
        /// we listen to the event where the property grid receives the focus and do a save. This will update the
        /// type provider with the contents of the xaml file (i.e the activities present in the xaml) and the activities
        /// can now be used in the rule editor which works off the type provider. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void propertyGrid_GotFocus(object sender, System.EventArgs e)
        {
            this.Save(this.loader.Xoml);
        }

        #region ISite Members

        public IComponent Component
        {
            get { return this; }
        }

        public new bool DesignMode
        {
            get { return true; }
        }

        #endregion
    }
}

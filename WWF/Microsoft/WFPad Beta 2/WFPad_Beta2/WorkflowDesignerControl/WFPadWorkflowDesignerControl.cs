//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
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
using System.CodeDom.Compiler;
using System.Workflow.Runtime;
using System.Reflection;

namespace WFPadWorkflowDesignerControl
{
    public partial class WFPadWorkflowDesignerControl : UserControl, IDisposable, IServiceProvider
    {
        private WorkflowView workflowView;
        private DesignSurface designSurface;
        private WorkflowLoader loader;
        private WorkflowCompilerResults compilerResults;
        private WorkflowRuntime workflowRuntime;
        private Activity currentWorkflow;
        private const string AdditionalAssembies = "";

        public WFPadWorkflowDesignerControl()
        {
            InitializeComponent();

            Toolbox toolbox = new Toolbox(this);
            this.propertyGridSplitter.Panel1.Controls.Add(toolbox);
            toolbox.Dock = DockStyle.Fill;
            toolbox.BackColor = BackColor;
            toolbox.Font = WorkflowTheme.CurrentTheme.AmbientTheme.Font; 

            WorkflowTheme.CurrentTheme.ReadOnly = false;
            WorkflowTheme.CurrentTheme.AmbientTheme.ShowConfigErrors = false;
            WorkflowTheme.CurrentTheme.ReadOnly = true;

            this.propertyGrid.BackColor = BackColor;
            this.propertyGrid.Font = WorkflowTheme.CurrentTheme.AmbientTheme.Font;
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
                return this.currentWorkflow == null ? string.Empty : this.currentWorkflow.Name;
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
            LoadNewSequentialWorkflow();
        }

        /// <summary>
        /// Loads a workflow onto the design surface using the specified workflow type
        /// </summary>
        /// <param name="xoml">Type to load</param>
        /// <returns>ICollection containing loading errors or null if none </returns>
        private ICollection LoadWorkflow(Type workflowType)
        {
            WorkflowLoader loader = new WorkflowLoader();
            loader.WorkflowType = workflowType;

            return LoadWorkflow(loader);
        }

        /// <summary>
        /// Loads a workflow onto the design surface using the specified Xaml
        /// </summary>
        /// <param name="xoml">Xaml to load</param>
        /// <returns>ICollection containing loading errors or null if none </returns>
        private ICollection LoadWorkflow(string xoml)
        {
            WorkflowLoader loader = new WorkflowLoader();
            loader.Xoml = xoml;
            return LoadWorkflow(loader);
        }

        private ICollection LoadWorkflow(WorkflowLoader loader)
        {
            SuspendLayout();

            DesignSurface designSurface = new DesignSurface();
            designSurface.BeginLoad(loader);
            if (designSurface.LoadErrors.Count > 0)
                return designSurface.LoadErrors;

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
                    this.splitContainer1.Panel1.Controls.Add(this.workflowView);
                    this.workflowView.Dock = DockStyle.Fill;
                    this.workflowView.TabIndex = 1;
                    this.workflowView.TabStop = true;
                    this.workflowView.HScrollBar.TabStop = false;
                    this.workflowView.VScrollBar.TabStop = false;
                    this.workflowView.Focus();

                    ISelectionService selectionService = GetService(typeof(ISelectionService)) as ISelectionService;
                    IComponentChangeService changeService = GetService(typeof(IComponentChangeService)) as IComponentChangeService;

                    if (selectionService != null)
                    {
                        selectionService.SelectionChanged += new EventHandler(OnSelectionChanged);
                    }

                    if (changeService != null)
                    {
                        changeService.ComponentAdded += new ComponentEventHandler(changeService_ComponentAdded);
                        changeService.ComponentChanged += new ComponentChangedEventHandler(changeService_ComponentChanged);
                        changeService.ComponentRemoved += new ComponentEventHandler(changeService_ComponentRemoved);
                        changeService.ComponentRename += new ComponentRenameEventHandler(changeService_ComponentRename);
                    }
                }
            }

            ResumeLayout(true);

            if (btnAutoSynch.Checked == true)
            {
                this.xomlView.Text = GetCurrentXoml();
            }

            return null;
        }

        void changeService_ComponentRename(object sender, ComponentRenameEventArgs e)
        {
            if (btnAutoSynch.Checked == true)
            {
                this.xomlView.Text = GetCurrentXoml();
            }
        }

        void changeService_ComponentRemoved(object sender, ComponentEventArgs e)
        {
            if (btnAutoSynch.Checked == true)
            {
                this.xomlView.Text = GetCurrentXoml();
            }
        }

        void changeService_ComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            if (btnAutoSynch.Checked == true)
            {
                this.xomlView.Text = GetCurrentXoml();
            }
        }

        void changeService_ComponentAdded(object sender, ComponentEventArgs e)
        {
            if (btnAutoSynch.Checked == true)
            {
                this.xomlView.Text = GetCurrentXoml();
            }
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

        public void LoadNewStateMachineWorkflow()
        {
            this.currentWorkflow = new StateMachineWorkflowActivity();
            currentWorkflow.Name = "CustomStateMachineWorkflow";

            this.LoadWorkflow();
            this.xomlView.Text = GetCurrentXoml();
        }

        public void LoadNewSequentialWorkflow()
        {
            this.currentWorkflow = new SequentialWorkflowActivity();
            currentWorkflow.Name = "CustomSequentialWorkflow";

            this.LoadWorkflow();
            this.xomlView.Text = GetCurrentXoml();
        }

        private void LoadWorkflow()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
                {
                    WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
                    serializer.Serialize(xmlWriter, currentWorkflow);
                    this.Xoml = stringWriter.ToString();
                }
            }
        }

        public void FitToPage()
        {
            this.workflowView.FitToScreenSize();
            this.workflowView.Update();
        }

        public void ProcessZoom(int zoomFactor)
        {
        
            this.workflowView.Zoom = zoomFactor;
            this.workflowView.Update();
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            ISelectionService selectionService = GetService(typeof(ISelectionService)) as ISelectionService;

            if (selectionService != null)
            {
                this.propertyGrid.SelectedObjects = new ArrayList(selectionService.GetSelectedComponents()).ToArray();
            }
        }

        public void DeleteSelected()
        {
            ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));

            if (selectionService != null)
            {
                if (selectionService.PrimarySelection is Activity)
                {
                    Activity activity = (Activity)selectionService.PrimarySelection;

                    if (activity.Name != this.WorkflowName)
                    {
                        activity.Parent.Activities.Remove(activity);
                        this.workflowView.Update();
                    }
                }
            }
        }

        public void LoadExistingWorkflow()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xoml files (*.xoml)|*.xoml|Assemblies (*.exe;*.dll)|*.exe;*.dll|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog.FileName) == ".exe" || Path.GetExtension(openFileDialog.FileName) == ".dll")
                {
                    LoadAssemblyWorkflows(openFileDialog.FileName);
                    return;
                }

                using (XmlReader xmlReader = XmlReader.Create(openFileDialog.FileName))
                {
                    WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
                    this.currentWorkflow = (SequentialWorkflowActivity)serializer.Deserialize(xmlReader);
                    this.LoadWorkflow();

                    this.XomlFile = openFileDialog.FileName;
                    this.Text = "WFPad (Beta2 ) -- [" + openFileDialog.FileName + "]";
                }
            }
        }

        private string GetWorkflowXoml(Type workflowType)
        {
            WorkflowMarkupSerializer ser = new WorkflowMarkupSerializer();
            StringWriter sw = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(sw);

            try
            {
                Activity root = (Activity)Activator.CreateInstance(workflowType);
                ser.Serialize(xmlWriter, root);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                workflowRuntime.StopRuntime();
                sw.Close();
            }

            return sw.ToString();
        }

        private void LoadAssemblyWorkflows(string assemblyPath)
        {
            Assembly asm = Assembly.LoadFile(assemblyPath);
            if (asm == null)
            {
                MessageBox.Show("Cannot load assembly", "WFPad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Type> workflowTypes = new List<Type>();
            foreach (Type t in asm.GetTypes())
            {
                if (t.IsSubclassOf(typeof(SequentialWorkflowActivity)) || t.IsSubclassOf(typeof(StateMachineWorkflowActivity)))
                {
                    workflowTypes.Add(t);
                }
            }

            if (workflowTypes.Count == 0)
            {
                MessageBox.Show("Could not find any workflows in this assembly", "WFPad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Type selectedType = workflowTypes[0];

            if( workflowTypes.Count > 1 )
            {
                // let user choose which workflow to open
                ChooseWorkflow chooseForm = new ChooseWorkflow();
                chooseForm.Types = workflowTypes;
                chooseForm.ShowDialog();
                selectedType = chooseForm.SelectedType;
            }

            ICollection errors = LoadWorkflow(selectedType);

            if (errors != null)
            {
                StringBuilder errorList = new StringBuilder();
                errorList.Append("Could not load workflow:\n\n");
                foreach (Exception error in errors)
                {
                    errorList.Append(error.Message);
                }

                MessageBox.Show(errorList.ToString(), "WFPad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveFile()
        {
            if (this.XomlFile.Length != 0)
            {
                this.SaveExistingWorkflow(this.XomlFile);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "xoml files (*.xoml)|*.xoml|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.SaveExistingWorkflow(saveFileDialog.FileName);
                    this.Text = "Designer Hosting Sample -- [" + saveFileDialog.FileName + "]";
                }
            }
        }

        internal void SaveExistingWorkflow(string filePath)
        {
            if (this.designSurface != null && this.loader != null)
            {
                this.XomlFile = filePath;
                this.loader.PerformFlush();
            }
        }

        public string GetCurrentXoml()
        {
            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));
            
            if (host != null && host.RootComponent != null)
            {
                Activity service = host.RootComponent as Activity;

                if (service != null)
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        using (XmlWriter writer = XmlWriter.Create(sw))
                        {
                            WorkflowMarkupSerializer xomlSerializer = new WorkflowMarkupSerializer();
                            xomlSerializer.Serialize(writer, service);
                        }

                        return sw.ToString();
                    }
                }
            }

            return "";
        }

        public bool Save()
        {
            return this.Save(true);
        }

        public bool Save(bool showMessage)
        {
            Cursor cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            bool saveOK = true;

            try
            {
                // Save the workflow first, and capture the filePath of the workflow
                this.SaveFile();

                XmlDocument doc = new XmlDocument();
                doc.Load(this.XomlFile);
                XmlAttribute attrib = doc.CreateAttribute("x", "Class", "http://schemas.microsoft.com/winfx/2006/xaml");
                attrib.Value = string.Format("{0}.{1}", this.GetType().Namespace, this.WorkflowName);
                doc.DocumentElement.Attributes.Append(attrib);
                doc.Save(this.XomlFile);

                if (showMessage)
                {
                    MessageBox.Show(this, "Workflow generated successfully. Generated xoml file:\n" + Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), this.XomlFile), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                saveOK = false;
            }
            finally
            {
                this.Cursor = cursor;
            }

            return saveOK;
        }

        public bool Compile()
        {
            return this.Compile(true);
        }

        public bool Compile(bool showMessage)
        {
            if (string.IsNullOrEmpty(this.XomlFile))
            {
                this.Save(false);
            }

            if (!File.Exists(this.XomlFile))
            {
                MessageBox.Show(this, "Cannot locate xoml file: " + Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), XomlFile), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool compileOK = true;

            Cursor cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Compile the workflow
                String[] assemblyNames = { AdditionalAssembies };
                WorkflowCompiler compiler = new WorkflowCompiler();
                WorkflowCompilerParameters parameters = new WorkflowCompilerParameters(assemblyNames);
                parameters.OutputAssembly = string.Format("{0}.dll", this.WorkflowName);
                compilerResults = compiler.Compile(parameters, this.XomlFile);

                StringBuilder errors = new StringBuilder();
                foreach (CompilerError compilerError in compilerResults.Errors)
                {
                    errors.Append(compilerError.ToString() + '\n');
                }

                if (errors.Length != 0)
                {
                    MessageBox.Show(this, errors.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    compileOK = false;
                }
                else if (showMessage)
                {
                    MessageBox.Show(this, "Workflow compiled successfully. Compiled assembly:\n" + compilerResults.CompiledAssembly.GetName(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                this.Cursor = cursor;
            }

            return compileOK;
        }

        public bool Run()
        {
            if (this.compilerResults == null)
            {
                if (!this.Compile(false))
                {
                    return false;
                }
            }

            // Start the runtime engine
            if (this.workflowRuntime == null)
            {
                this.workflowRuntime = new WorkflowRuntime();
            }

            workflowRuntime.StartRuntime();
            workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(workflowRuntime_WorkflowCompleted);
            workflowRuntime.CreateWorkflow((compilerResults.CompiledAssembly.GetType(string.Format("{0}.{1}", this.GetType().Namespace, this.WorkflowName)))).Start();

            return true;
        }

        void workflowRuntime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            this.workflowRuntime.StopRuntime();
            this.workflowRuntime.Dispose();
            this.workflowRuntime = null;
        }

        private void btnAutoSynch_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAutoSynch.Checked == true)
            {
                btnGetXaml.Enabled = false;
            }
            else
            {
                btnGetXaml.Enabled = true;
            }
        }

        private void btnGetXaml_Click(object sender, EventArgs e)
        {
            this.xomlView.Text = GetCurrentXoml();
        }

        private void btnApplyXaml_Click(object sender, EventArgs e)
        {
            ICollection errors = LoadWorkflow(this.xomlView.Text);
            if (errors != null )
            {
                StringBuilder errorList = new StringBuilder();
                errorList.Append("Could not load workflow:\n\n");
                foreach (Exception error in errors)
                {
                    errorList.Append(error.Message);
                }

                MessageBox.Show(errorList.ToString(), "WFPad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.xomlView.Text = GetCurrentXoml();
            }
        }
    }
}

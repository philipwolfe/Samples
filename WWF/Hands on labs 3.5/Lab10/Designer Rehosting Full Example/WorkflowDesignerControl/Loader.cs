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
    using System.Workflow.Activities;
    using System.Xml;
    using System.Text;
    using System.CodeDom;
    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    using System.Windows.Forms;

    #region WorkflowLoader
    internal sealed class WorkflowLoader : WorkflowDesignerLoader
    {
        #region Members
        private string xoml = string.Empty;
        private StringBuilder tempRulesStream = null;
        
        // we maintain two code compile units :1 for code beside file and 1 for xaml file
        private CodeCompileUnit codeBesideccu;
        private CodeCompileUnit xamlccu;
        #endregion

        #region ctor
        internal WorkflowLoader()
        {
            // Create the code compile unit 

            codeBesideccu = new CodeCompileUnit();
            codeBesideccu.ReferencedAssemblies.Add("System.Workflow.Activities");
            CodeNamespace ns = new CodeNamespace("foo");
            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("System.ComponentModel"));
            ns.Imports.Add(new CodeNamespaceImport("System.ComponentModel.Design"));
            ns.Imports.Add(new CodeNamespaceImport("System.Workflow.ComponentModel.Design"));
            ns.Imports.Add(new CodeNamespaceImport("System.Workflow.ComponentModel"));
            ns.Imports.Add(new CodeNamespaceImport("System.Workflow.ComponentModel.Serialization"));
            ns.Imports.Add(new CodeNamespaceImport("System.Workflow.ComponentModel.Compiler"));
            ns.Imports.Add(new CodeNamespaceImport("System.Drawing"));
            ns.Imports.Add(new CodeNamespaceImport("System.Collections"));
            ns.Imports.Add(new CodeNamespaceImport("System.Workflow.Activities"));
            ns.Imports.Add(new CodeNamespaceImport("System.Workflow.ComponentModel"));
            ns.Imports.Add(new CodeNamespaceImport("System.Workflow.Runtime"));
            codeBesideccu.Namespaces.Add(ns);
            CodeTypeDeclaration ctd = new CodeTypeDeclaration("Workflow1");
            ctd.BaseTypes.Add("System.Workflow.Activities.SequentialWorkflowActivity");
            ctd.IsPartial = true;
            ctd.Attributes = MemberAttributes.Public;
            ns.Types.Add(ctd);
        }

        #endregion

        #region Overrides from WorkflowDesignerLoader
        protected override void Initialize()
        {
            base.Initialize();

            // Add all the services to the loaderhost
            IDesignerLoaderHost host = LoaderHost;
            if (host != null)
            {
                this.SetBaseComponentClassName("foo.Workflow1");
                host.AddService(typeof(IMenuCommandService), new WorkflowMenuCommandService(host));
                host.AddService(typeof(IToolboxService), new ToolboxService(host));
                TypeProvider typeProvider = new TypeProvider(host);
                typeProvider.AddCodeCompileUnit(this.CodeBesideCCU);
                typeProvider.AddAssemblyReference(typeof(System.EventHandler).Assembly.Location);
                typeProvider.AddAssemblyReference(typeof(System.ComponentModel.AttributeCollection).Assembly.Location);
                typeProvider.AddAssemblyReference(typeof(System.Workflow.ComponentModel.CompositeActivity).Assembly.Location);
                typeProvider.AddAssemblyReference(typeof(System.Workflow.Activities.SequentialWorkflowActivity).Assembly.Location);
                
                host.AddService(typeof(ITypeProvider), typeProvider, true);
                host.AddService(typeof(IMemberCreationService), new MemberCreationService(host, this));
                host.AddService(typeof(IPropertyValueUIService), new PropertyValueUIService());
                host.AddService(typeof(IEventBindingService), new EventBindingService(host,this));
            }
        }

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

        public override TextReader GetFileReader(string filePath)
        {
            if (this.tempRulesStream != null)
                return new StringReader(this.tempRulesStream.ToString());
            else
                return null;
        }

        public override TextWriter GetFileWriter(string filePath)
        {
            this.tempRulesStream = new StringBuilder();
            return new StringWriter(this.tempRulesStream);
        }

        public override string FileName
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Note: In case of state machine workflows we need to load the layout from the layout file in the 
        /// OnEndLoad method. This is because the layout file is applied to the designer components which are
        /// created in PerformLoad and are available only on the OnEndLoad method
        /// </summary>
        /// <param name="successful"></param>
        /// <param name="errors"></param>
        protected override void OnEndLoad(bool successful, ICollection errors)
        {
            base.OnEndLoad(successful, errors);

            // Load the layout if it exists
            string layoutFile = Path.Combine(Path.GetDirectoryName(this.xoml), Path.GetFileNameWithoutExtension(this.xoml) + ".layout");
            if (File.Exists(layoutFile))
            {
                IList loaderrors = null;
                using (XmlReader xmlReader = XmlReader.Create(layoutFile))
                    LoadDesignerLayout(xmlReader, out loaderrors);
            }
        }

        /// <summary>
        /// Load the workflow : This will create the activity tree and its corresponding Designer tree
        /// </summary>
        /// <param name="serializationManager"></param>
        protected override void PerformLoad(IDesignerSerializationManager serializationManager)
        {
            base.PerformLoad(serializationManager);
            IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));

            // get the root activity and add the corresponding object graph to the designer host
            XmlReader  reader = new XmlTextReader(this.xoml);
            Activity rootActivity = null;
            try
            {
                WorkflowMarkupSerializer xomlSerializer = new WorkflowMarkupSerializer();
                rootActivity = xomlSerializer.Deserialize(reader) as Activity;
            }
            finally
            {
                reader.Close();
            }

            if (rootActivity != null && designerHost != null)
            {
                AddObjectGraphToDesignerHost(designerHost, rootActivity);
                Type companionType = rootActivity.GetValue(WorkflowMarkupSerializer.XClassProperty) as Type;
                if (companionType != null)
                    SetBaseComponentClassName(companionType.FullName);
            }

            designerHost.Activate();
            // Read from rules file if one exists
            string rulesFile = Path.Combine(Path.GetDirectoryName(this.xoml), Path.GetFileNameWithoutExtension(this.xoml) + ".rules");
            if (File.Exists(rulesFile))
            {
                StreamReader rulesReader = new StreamReader(rulesFile);
                this.tempRulesStream = new StringBuilder(rulesReader.ReadToEnd());
                rulesReader.Close();
            }

        }

        public override void Flush()
        {
            PerformFlush(null);
        }

        /// <summary>
        /// Save the Xaml file and flush the code compile unit into a .CS file
        /// </summary>
        /// <param name="manager"></param>
        protected override void PerformFlush(IDesignerSerializationManager manager)
        {
            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));
            Activity rootActivity = host.RootComponent as Activity;
            if (host != null && host.RootComponent != null)
            {

                if (rootActivity != null)
                {
                    XmlTextWriter xmlWriter = new XmlTextWriter(this.xoml, Encoding.Default);
                    try
                    {
                        WorkflowMarkupSerializer xomlSerializer = new WorkflowMarkupSerializer();
                        xomlSerializer.Serialize(xmlWriter, rootActivity);
                    }
                    finally
                    {
                        xmlWriter.Close();
                    }
                }
            }

            string codeBesideFile = Path.Combine(Path.GetDirectoryName(this.xoml), Path.GetFileNameWithoutExtension(this.xoml) + ".cs");
            
            // Flush CS code
            CSharpCodeProvider provider = new CSharpCodeProvider();
            ICodeGenerator generator = provider.CreateGenerator();

            // Just chooses some formatting options, like four space indenting
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BlankLinesBetweenMembers = true;
            options.BracingStyle = "C";
            options.ElseOnClosing = false;
            options.IndentString = "    ";

            StreamWriter writer = new StreamWriter(codeBesideFile);
            generator.GenerateCodeFromCompileUnit(this.CodeBesideCCU, writer, options);
            writer.Close();

            // Flush the rules file
            if (this.tempRulesStream != null)
            {
                string rulesFile = Path.Combine(Path.GetDirectoryName(this.xoml), Path.GetFileNameWithoutExtension(this.xoml) + ".rules");
                using (StreamWriter rulesWriter = new StreamWriter(rulesFile))
                {
                    rulesWriter.Write(this.tempRulesStream.ToString());
                }
            }

            #region State Machine Workflow specific code
            // Need to save the layout in case of State Machine Workflow

            //string layoutFile = Path.Combine(Path.GetDirectoryName(this.xoml), Path.GetFileNameWithoutExtension(this.xoml) + ".layout");
            //ActivityDesigner rootdesigner = host.GetDesigner(rootActivity) as ActivityDesigner;
            //XmlWriter layoutwriter = XmlWriter.Create(layoutFile);
            //IList errors = null;
            //SaveDesignerLayout(layoutwriter, rootdesigner, out errors);
            //layoutwriter.Close();

            #endregion
        }

        #endregion

        #region Public properties
        public string DefaultNamespace
        {
            get
            {
                return "foo";
            }
        }

        public CodeCompileUnit CodeBesideCCU
        {
            get { return codeBesideccu; }
            set { codeBesideccu = value; }
        }

        public CodeCompileUnit XamlCodeCompileUnit
        {
            get { return xamlccu; }
            set { xamlccu = value; }
        }

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

        #endregion

        #region Private helpers
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

        #endregion

    }
    #endregion
}

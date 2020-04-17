//-------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved
//-------------------------------------------------------------------

using System;
using System.Windows;
using System.Activities.Design;
using System.Activities.Statements;
using System.Activities.Core.Design;
using System.Activities.Design.Metadata;
using System.ComponentModel;

namespace Microsoft.Samples.UsingWorkflowItemPresenter
{
    public partial class RehostingWfDesigner : Window
    {
        public RehostingWfDesigner()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            // register metadata
            (new DesignerMetadata()).Register();
            RegisterCustomMetadata();
            // add custom activity to toolbox
            Toolbox.Categories.Add(new ToolboxCategoryItemsCollection("Custom activities"));
            Toolbox.Categories[1].Add(new ToolboxItemWrapper(typeof(SimpleNativeActivity)));

            // create the workflow designer
            WorkflowDesigner wd = new WorkflowDesigner();
            wd.Load(new Sequence());
            DesignerBorder.Child = wd.View;
            PropertyBorder.Child = wd.PropertyInspectorView;
     
        }

        void RegisterCustomMetadata()
        {
            AttributeTableBuilder builder = new AttributeTableBuilder();
            builder.AddCustomAttributes(typeof(SimpleNativeActivity), new DesignerAttribute(typeof(SimpleNativeDesigner)));
            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}

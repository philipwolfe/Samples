//--------------------------------------------------------------------------------
// This file is part of the Windows Workflow Foundation Sample Code
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
using System.ComponentModel;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Drawing.Design;
using System.Collections.Generic;
using System.Collections;

namespace CustomInvokeWorkflowActivityLibrary
{
    public partial class CustomInvokeWorkflowActivity : Activity, ITypeFilterProvider
      {
        public static readonly DependencyProperty TargetWorkflowProperty = DependencyProperty.Register("TargetWorkflow", typeof(Type), typeof(CustomInvokeWorkflowActivity), new PropertyMetadata(null));
        public static readonly DependencyProperty ParametersProperty = DependencyProperty.Register("Parameters", typeof(Dictionary<string, object>), typeof(CustomInvokeWorkflowActivity), new PropertyMetadata(DependencyPropertyOptions.ReadOnly, new Attribute[] { new BrowsableAttribute(false), new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content) }));
        public static readonly DependencyProperty InstanceIdProperty = DependencyProperty.Register("InstanceId", typeof(Guid), typeof(CustomInvokeWorkflowActivity));
        public static DependencyProperty BeforeInvokedEvent = DependencyProperty.Register("BeforeInvoked", typeof(EventHandler), typeof(CustomInvokeWorkflowActivity));
        public static DependencyProperty AfterInvokingEvent = DependencyProperty.Register("AfterInvoking", typeof(EventHandler), typeof(CustomInvokeWorkflowActivity));

        
        public CustomInvokeWorkflowActivity()
        {
            base.SetReadOnlyPropertyValue(ParametersProperty, new Dictionary<string, object>());
            InitializeComponent();
        }
 
        #region Designer generated code
 
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // CustomInvokeWorkflowActivity
            // 
            this.Name = "CustomInvokeWorkflowActivity";
 
        }
 
        #endregion

        [Category("Activity")]
        [Description("InstanceId of workflow that is invoked")]
        public Guid InstanceId
        {
            get
            {
                return (Guid)base.GetValue(InstanceIdProperty);
            }
            set
            {
                base.SetValue(InstanceIdProperty, value);
            }
        }

        [Category("Activity")]
        [Description("Type of workflow to invoke")]
        [Editor(typeof(TypeBrowserEditor), typeof(UITypeEditor))]
        [DefaultValue(null)]
        public Type TargetWorkflow
        {
            get
            {
                return base.GetValue(TargetWorkflowProperty) as Type;
            }
            set
            {
                base.SetValue(TargetWorkflowProperty, value);
            }
        }

        [Description("This event will be invoked before the target workflow is invoked.")]
        [Category("Handlers")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event EventHandler BeforeInvoked
        {
            add
            {
                base.AddHandler(CustomInvokeWorkflowActivity.BeforeInvokedEvent, value);
            }
            remove
            {
                base.RemoveHandler(CustomInvokeWorkflowActivity.BeforeInvokedEvent, value);
            }
        }

        [Description("This event will be invoked after the target workflow is invoked.")]
        [Category("Handlers")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event EventHandler AfterInvoking
        {
            add
            {
                base.AddHandler(CustomInvokeWorkflowActivity.AfterInvokingEvent, value);
            }
            remove
            {
                base.RemoveHandler(CustomInvokeWorkflowActivity.AfterInvokingEvent, value);
            }
        }
 
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Browsable(false)]
        public Dictionary<string, object> Parameters
        {
            get
            {
                return base.GetValue(ParametersProperty) as Dictionary<string, object>;
            }
        }        
 
        #region ITypeFilterProvider Members
 
        bool ITypeFilterProvider.CanFilterType(Type type, bool throwOnError)
        {
            bool canFilterType = TypeProvider.IsAssignable(typeof(Activity), type) && type != typeof(Activity) && !type.IsAbstract;
            
            if (throwOnError && !canFilterType)
                throw new Exception("Type does not derive from Activity");
 
            return canFilterType;
        }
 
        string ITypeFilterProvider.FilterDescription
        {
            get 
            {
                return "Select a Type that derives from Activity.";
            }
        }
 
        #endregion
 
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            this.RaiseEvent(CustomInvokeWorkflowActivity.BeforeInvokedEvent, this , new EventArgs());
            
            if (this.TargetWorkflow == null)
                throw new InvalidOperationException("TargetWorkflow property must be set to a valid Type that derives from Activity.");
            
            IStartWorkflow startWorkflow = executionContext.GetService(typeof(IStartWorkflow)) as IStartWorkflow;

            Guid instanceId = startWorkflow.StartWorkflow(this.TargetWorkflow, this.Parameters);

            base.SetValue(InstanceIdProperty, instanceId);

            this.RaiseEvent(CustomInvokeWorkflowActivity.AfterInvokingEvent, this, new EventArgs());

            return ActivityExecutionStatus.Closed;
        }
    }
}


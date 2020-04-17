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
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace CustomInvokeWorkflowActivitySample
{
	public sealed partial class InvokedWorkflow: SequentialWorkflowActivity
	{
		public InvokedWorkflow()
		{
			InitializeComponent();
		}

        public static DependencyProperty MyPropertyProperty = System.Workflow.ComponentModel.DependencyProperty.Register("MyProperty", typeof(string), typeof(InvokedWorkflow), new PropertyMetadata(string.Empty));

        [Description("Property to test parameters.")]
        [Category("Workflow")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string MyProperty
        {
            get
            {
                return ((string)(base.GetValue(InvokedWorkflow.MyPropertyProperty)));
            }
            set
            {
                base.SetValue(InvokedWorkflow.MyPropertyProperty, value);
            }
        }

        private void TraceIt(object sender, EventArgs e)
        {
            Console.WriteLine(string.Format("Within the invoked workflow.  MyProperty = '{0}'.", MyProperty));
        }
	}

}

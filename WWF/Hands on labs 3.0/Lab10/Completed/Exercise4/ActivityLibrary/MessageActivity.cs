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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace ActivityLibrary
{
    public partial class MessageActivity : System.Workflow.ComponentModel.Activity
	{
		public MessageActivity()
		{
			InitializeComponent();
		}

        public static DependencyProperty MessageProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Message", typeof(string), typeof(MessageActivity));

        [Description("The Message to display in the MessageBox")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Message
        {
            get
            {
                return ((string)(base.GetValue(MessageActivity.MessageProperty)));
            }
            set
            {
                base.SetValue(MessageActivity.MessageProperty, value);
            }
        }


        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            MessageBox.Show(this.Message);

            return ActivityExecutionStatus.Closed;
        }
	}
}

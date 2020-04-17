//--------------------------------------------------------------------------------
// This file is a Windows Workflow Foundation "Sample" built by
// Customer Support & Services
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
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace CustomWorkflowTypes
{
    public partial class ConsoleWriteLineActivity : System.Workflow.ComponentModel.Activity
	{
		public ConsoleWriteLineActivity()
		{
			InitializeComponent();
		}

        public static DependencyProperty MessageProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Message", typeof(string), typeof(ConsoleWriteLineActivity));

        [Description("Please specify a message")]
        [Category("Custom Properties")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Message
        {
            get
            {
                return ((string)(base.GetValue(ConsoleWriteLineActivity.MessageProperty)));
            }
            set
            {
                base.SetValue(ConsoleWriteLineActivity.MessageProperty, value);
            }
        }

        public static DependencyProperty InvokingEvent = DependencyProperty.Register("Invoking", typeof(EventHandler), typeof(ConsoleWriteLineActivity));

        [Description("Please specify a hander that will be called before the activity executes")]
        [Category("Custom Properties")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public event EventHandler Invoking
        {
            add
            {
                base.AddHandler(ConsoleWriteLineActivity.InvokingEvent, value);
            }
            remove
            {
                base.RemoveHandler(ConsoleWriteLineActivity.InvokingEvent, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            base.RaiseEvent(InvokingEvent, this, EventArgs.Empty);
            Console.WriteLine(Message);
            return ActivityExecutionStatus.Closed;
        }
	}
}

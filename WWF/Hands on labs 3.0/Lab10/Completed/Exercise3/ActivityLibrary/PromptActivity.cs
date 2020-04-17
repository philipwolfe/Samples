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
    public partial class PromptActivity : System.Workflow.ComponentModel.Activity
	{
        public PromptActivity()
		{
			InitializeComponent();
		}

        private string question;

        public string Question
        {
            get { return question; }
            set { question = value; }
        }

        public static DependencyProperty AnswerProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Answer", typeof(string), typeof(PromptActivity));

        [Description("The answer to the question")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Answer
        {
            get
            {
                return ((string)(base.GetValue(PromptActivity.AnswerProperty)));
            }
            set
            {
                base.SetValue(PromptActivity.AnswerProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            PromptForm form = new PromptForm(this.question);
            form.ShowDialog();

            this.Answer = form.Answer;

            return ActivityExecutionStatus.Closed;
        }
	}
}

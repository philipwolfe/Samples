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
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.CodeDom;

namespace DynamicUpdateChangingRules
{
	public sealed partial class DynamicRulesWorkflow: SequentialWorkflowActivity
	{
        int runCounter = 0;

        public static DependencyProperty AmountProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Amount", typeof(Int32), typeof(DynamicRulesWorkflow));

        [Description("This is the description which appears in the Property Browser")]
        [Category("This is the category which will be displayed in the Property Browser")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Int32 Amount
        {
            get
            {
                return ((Int32)(base.GetValue(DynamicRulesWorkflow.AmountProperty)));
            }
            set
            {
                base.SetValue(DynamicRulesWorkflow.AmountProperty, value);
            }
        }

		public DynamicRulesWorkflow()
		{
			InitializeComponent();
		}

        private void ReRun(object sender, ConditionalEventArgs e)
        {
            e.Result = (runCounter < 2);
            runCounter++;
        }

        private void initAmount_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Loop {0}", runCounter);
        }

        private void getManagerApproval_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("\tInside ifElseBranch1: Amount is \'{0}\', Get Manager Approval", Amount);
        }

        private void getVPApproval_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("\tInside ifElseBranch2: Amount is \'{0}\', Get VP Approval", Amount);
        }
	}

}

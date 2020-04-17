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

namespace DynamicUpdateInWorkflow
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

		private void CheckAmount(object sender, ConditionalEventArgs e)
		{
			if (Amount >= 1000)
				e.Result = true;
			else
				e.Result = false;

			Console.WriteLine("\tCheckAmount : amount \'{0}\' result \'{1}\'", Amount, e.Result);

		}

		private void AddApproval(object sender, EventArgs e)
		{
			InvokeWorkflowActivity invokeNewStepWorkflow = new InvokeWorkflowActivity();

			// use WorkflowChanges class to author dynamic change
			WorkflowChanges changes = new WorkflowChanges(this);

			// setup to invoke NewStepWorkflow type
			Type type = typeof(DynamicUpdateInWorkflow.Workflow2);

			invokeNewStepWorkflow.Name = "Workflow2";
			invokeNewStepWorkflow.TargetWorkflow = type;

			// insert invokeNewStepWorkflow in ifElseApproval 
			// transient activity collection

			CompositeActivity ifElse = changes.TransientWorkflow.Activities["ifElseActivity1"] as CompositeActivity;
			CompositeActivity branch1 = ifElse.Activities["ifElseBranchActivity1"] as CompositeActivity;
			branch1.Activities.Add(invokeNewStepWorkflow);

			// apply transient changes to instance
			this.ApplyWorkflowChanges(changes);
			Console.WriteLine("\tAdded a new step from within workflow");

		}

		private void PurchaseOrderCreate(object sender, EventArgs e)
		{
			Console.WriteLine("\tCreating Purchase Order");
		}

		public static DependencyProperty AmountProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Amount", typeof(System.Int32), typeof(Workflow1));

		[Description("This is the description which appears in the Property Browser")]
		[Category("This is the category which will be displayed in the Property Browser")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public System.Int32 Amount
		{
			get
			{
				return ((System.Int32)(base.GetValue(Workflow1.AmountProperty)));
			}
			set
			{
				base.SetValue(Workflow1.AmountProperty, value);
			}
		}
	}

}

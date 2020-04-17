//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
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
using Workflows.WorkItemsDataSetTableAdapters;

namespace Workflows
{
	/// <summary>
	/// Saves a <see cref="WorkItemsDataSet"/>'s changes.
	/// </summary>
	public partial class SaveWorkItems : System.Workflow.ComponentModel.Activity
	{
		public SaveWorkItems()
		{
			InitializeComponent();
		}

		public static DependencyProperty WorkItemsProperty = System.Workflow.ComponentModel.DependencyProperty.Register("WorkItems", typeof(WorkItemsDataSet), typeof(SaveWorkItems));

		[Description("The work items to be saved.")]
		[Category("Parameters")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public WorkItemsDataSet WorkItems
		{
			get { return ((WorkItemsDataSet)(base.GetValue(SaveWorkItems.WorkItemsProperty))); }
			set { base.SetValue(SaveWorkItems.WorkItemsProperty, value); }
		}

		protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
		{
			if (WorkItems != null)
				using (WorkItemsTableAdapter workItemsAdapter = new WorkItemsTableAdapter())
					workItemsAdapter.Update(WorkItems);

			return base.Execute(executionContext);
		}
	}
}

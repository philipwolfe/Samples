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
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using ExpenseLocalServices;

namespace ExpenseCompositeActivities
{
	[ToolboxItemAttribute(typeof(ActivityToolboxItem))]
	public partial class Activity1 : Sequence
	{
		public Activity1()
		{
			InitializeComponent();
		}

		public static DependencyProperty invokeMethodActivity1_CorrelationReferenceProperty = DependencyProperty.Register("invokeMethodActivity1_CorrelationReference", typeof(System.Workflow.Runtime.Messaging.CorrelationReference), typeof(ExpenseCompositeActivities.Activity1));

		[DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
		[ValidationVisibilityAttribute(ValidationVisibility.Optional)]
		[BrowsableAttribute(true)]
		[CategoryAttribute("Activity")]
		public System.Workflow.Runtime.Messaging.CorrelationReference invokeMethodActivity1_CorrelationReference
		{
			get
			{
				return ((System.Workflow.Runtime.Messaging.CorrelationReference)(base.GetValue(ExpenseCompositeActivities.Activity1.invokeMethodActivity1_CorrelationReferenceProperty)));
			}
			set
			{
				base.SetValue(ExpenseCompositeActivities.Activity1.invokeMethodActivity1_CorrelationReferenceProperty, value);
			}
		}

		public static DependencyProperty ReportProperty = DependencyProperty.Register("Report", typeof(ExpenseLocalServices.ExpenseReport), typeof(ExpenseCompositeActivities.Activity1));

		[DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
		[ValidationVisibilityAttribute(ValidationVisibility.Optional)]
		[BrowsableAttribute(true)]
		[CategoryAttribute("Parameters")]
		public ExpenseLocalServices.ExpenseReport Report
		{
			get
			{
				return ((ExpenseLocalServices.ExpenseReport)(base.GetValue(ExpenseCompositeActivities.Activity1.ReportProperty)));
			}
			set
			{
				base.SetValue(ExpenseCompositeActivities.Activity1.ReportProperty, value);
			}
		}
	}
}

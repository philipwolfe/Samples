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
using System.Reflection;
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
	public partial class Activity1
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
			System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
			System.Workflow.ComponentModel.ParameterBinding parameterbinding1 = new System.Workflow.ComponentModel.ParameterBinding();
			this.invokeMethodActivity1 = new System.Workflow.Activities.InvokeMethodActivity();
			// 
			// invokeMethodActivity1
			// 
			activitybind1.ID = "/Parent";
			activitybind1.Path = "invokeMethodActivity1_CorrelationReference";
			this.invokeMethodActivity1.CorrelationReference = activitybind1;
			this.invokeMethodActivity1.ID = "invokeMethodActivity1";
			this.invokeMethodActivity1.InterfaceType = typeof(ExpenseLocalServices.IExpenseService);
			this.invokeMethodActivity1.MethodName = "ApproveExpenseReport";
			activitybind2.ID = "/Parent";
			activitybind2.Path = "Report";
			parameterbinding1.ParameterName = "report";
			parameterbinding1.SetBinding(System.Workflow.ComponentModel.ParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.Bind)(activitybind2)));
			this.invokeMethodActivity1.ParameterBindings.Add(parameterbinding1);
			// 
			// Activity1
			// 
			this.Activities.Add(this.invokeMethodActivity1);

		}

		#endregion

		[LockedActivityAttribute(true, false)]
		private InvokeMethodActivity invokeMethodActivity1;
	}
}

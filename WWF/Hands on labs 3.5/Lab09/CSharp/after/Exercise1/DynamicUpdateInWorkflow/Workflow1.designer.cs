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
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace DynamicUpdateInWorkflow
{
	partial class Workflow1
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
			this.CanModifyActivities = true;
			System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
			this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
			this.ifElseBranchActivity1 = new System.Workflow.Activities.IfElseBranchActivity();
			this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
			this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
			// 
			// codeActivity1
			// 
			this.codeActivity1.Name = "codeActivity1";
			this.codeActivity1.ExecuteCode += new System.EventHandler(this.AddApproval);
			// 
			// ifElseBranchActivity1
			// 
			this.ifElseBranchActivity1.Activities.Add(this.codeActivity1);
			codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.CheckAmount);
			this.ifElseBranchActivity1.Condition = codecondition1;
			this.ifElseBranchActivity1.Name = "ifElseBranchActivity1";
			// 
			// codeActivity2
			// 
			this.codeActivity2.Name = "codeActivity2";
			this.codeActivity2.ExecuteCode += new System.EventHandler(this.PurchaseOrderCreate);
			// 
			// ifElseActivity1
			// 
			this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity1);
			this.ifElseActivity1.Name = "ifElseActivity1";
			// 
			// Workflow1
			// 
			this.Activities.Add(this.ifElseActivity1);
			this.Activities.Add(this.codeActivity2);
			this.Name = "Workflow1";
			this.CanModifyActivities = false;

		}

		#endregion

		private IfElseBranchActivity ifElseBranchActivity1;
		private CodeActivity codeActivity1;
		private CodeActivity codeActivity2;
		private IfElseActivity ifElseActivity1;




	}
}

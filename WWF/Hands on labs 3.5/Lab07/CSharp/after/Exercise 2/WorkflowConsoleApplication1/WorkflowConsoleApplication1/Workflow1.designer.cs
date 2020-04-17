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

namespace WorkflowConsoleApplication1
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
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.replicatorActivity1 = new System.Workflow.Activities.ReplicatorActivity();
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // replicatorActivity1
            // 
            this.replicatorActivity1.Activities.Add(this.codeActivity1);
            this.replicatorActivity1.ExecutionType = System.Workflow.Activities.ExecutionType.Sequence;
            this.replicatorActivity1.Name = "replicatorActivity1";
            this.replicatorActivity1.ChildInitialized += new System.EventHandler<System.Workflow.Activities.ReplicatorChildEventArgs>(this.childInitialized);
            this.replicatorActivity1.Initialized += new System.EventHandler(this.replicatorActivity1_Initialized);
            this.replicatorActivity1.ChildCompleted += new System.EventHandler<System.Workflow.Activities.ReplicatorChildEventArgs>(this.childCompleted);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.replicatorActivity1);
            this.Name = "Workflow1";
            this.Completed += new System.EventHandler(this.workflowCompleted);
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeActivity1;
        private ReplicatorActivity replicatorActivity1;




    }
}

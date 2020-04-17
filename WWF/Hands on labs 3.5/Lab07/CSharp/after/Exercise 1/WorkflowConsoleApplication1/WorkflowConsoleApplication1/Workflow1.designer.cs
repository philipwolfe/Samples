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
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition3 = new System.Workflow.Activities.CodeCondition();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.conditionedActivityGroup1 = new System.Workflow.Activities.ConditionedActivityGroup();
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.evenCondition);
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity2_ExecuteCode);
            this.codeActivity2.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, codecondition1);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.oddCondition);
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            this.codeActivity1.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, codecondition2);
            // 
            // conditionedActivityGroup1
            // 
            this.conditionedActivityGroup1.Activities.Add(this.codeActivity1);
            this.conditionedActivityGroup1.Activities.Add(this.codeActivity2);
            this.conditionedActivityGroup1.Name = "conditionedActivityGroup1";
            codecondition3.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.timeToExit);
            this.conditionedActivityGroup1.UntilCondition = codecondition3;
            // 
            // Workflow1
            // 
            this.Activities.Add(this.conditionedActivityGroup1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeActivity2;
        private CodeActivity codeActivity1;
        private ConditionedActivityGroup conditionedActivityGroup1;








    }
}

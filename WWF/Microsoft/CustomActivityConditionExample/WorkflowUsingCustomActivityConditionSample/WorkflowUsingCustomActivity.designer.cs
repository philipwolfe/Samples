//--------------------------------------------------------------------------------
// This file is part of the Windows Workflow Foundation Sample Code
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

namespace WorkflowUsingCustomActivityConditionSample
{
	partial class WorkflowUsingCustomActivity
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
            CustomActivityLibrary.CustomActivityCondition customactivitycondition1 = new CustomActivityLibrary.CustomActivityCondition();
            CustomActivityLibrary.CustomActivityCondition customactivitycondition2 = new CustomActivityLibrary.CustomActivityCondition();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.customActivityWithCustomActivityCondition2 = new CustomActivityLibrary.CustomActivityWithCustomActivityCondition();
            this.customActivityWithCustomActivityCondition1 = new CustomActivityLibrary.CustomActivityWithCustomActivityCondition();
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // customActivityWithCustomActivityCondition2
            // 
            this.customActivityWithCustomActivityCondition2.Activities.Add(this.codeActivity2);
            customactivitycondition1.CustomCondition = "Bar";
            this.customActivityWithCustomActivityCondition2.MyCustomCondition = customactivitycondition1;
            this.customActivityWithCustomActivityCondition2.Name = "customActivityWithCustomActivityCondition2";
            // 
            // customActivityWithCustomActivityCondition1
            // 
            this.customActivityWithCustomActivityCondition1.Activities.Add(this.codeActivity1);
            customactivitycondition2.CustomCondition = "Foo";
            this.customActivityWithCustomActivityCondition1.MyCustomCondition = customactivitycondition2;
            this.customActivityWithCustomActivityCondition1.Name = "customActivityWithCustomActivityCondition1";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.customActivityWithCustomActivityCondition1);
            this.Activities.Add(this.customActivityWithCustomActivityCondition2);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeActivity1;
        private CodeActivity codeActivity2;
        private CustomActivityLibrary.CustomActivityWithCustomActivityCondition customActivityWithCustomActivityCondition2;
        private CustomActivityLibrary.CustomActivityWithCustomActivityCondition customActivityWithCustomActivityCondition1;
    }
}

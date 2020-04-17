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

namespace CustomTypeSerialization.SampleWorkflows
{
	partial class CodeWorkflow
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
            this.customActivityWithCustomType1 = new CustomTypeSerialization.ActivityWithCustomType.CustomActivityWithCustomType();
            // 
            // customActivityWithCustomType1
            // 
            this.customActivityWithCustomType1.MyDependencyProperty = new CustomTypeSerialization.ActivityWithCustomType.MyType("first", "second");
            this.customActivityWithCustomType1.MyNormalProperty = new CustomTypeSerialization.ActivityWithCustomType.MyType("uno", "dos");
            this.customActivityWithCustomType1.Name = "customActivityWithCustomType1";
            // 
            // CodeWorkflowWithCustomType
            // 
            this.Activities.Add(this.customActivityWithCustomType1);
            this.Name = "CodeWorkflowWithCustomType";
            this.CanModifyActivities = false;

		}

		#endregion

        private CustomTypeSerialization.ActivityWithCustomType.CustomActivityWithCustomType customActivityWithCustomType1;






    }
}

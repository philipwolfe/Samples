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

namespace SampleApplication
{
	partial class SampleWorkflow
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
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.LaunchNotepad = new DiagnosticsActivities.ProcessActivity();
            // 
            // LaunchNotepad
            // 
            this.LaunchNotepad.Arguments = "";
            this.LaunchNotepad.CreateNoWindow = true;
            this.LaunchNotepad.EventSubscriptionId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.LaunchNotepad.FileName = "notepad.exe";
            this.LaunchNotepad.Name = "LaunchNotepad";
            this.LaunchNotepad.RedirectStandardError = false;
            this.LaunchNotepad.RedirectStandardInput = false;
            this.LaunchNotepad.RedirectStandardOutput = false;
            this.LaunchNotepad.Timeout = false;
            activitybind1.Name = "SampleWorkflow";
            activitybind1.Path = "timeoutLength";
            this.LaunchNotepad.UseShellExecute = false;
            this.LaunchNotepad.SetBinding(DiagnosticsActivities.ProcessActivity.TimeoutLengthProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // SampleWorkflow
            // 
            this.Activities.Add(this.LaunchNotepad);
            this.Name = "SampleWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private DiagnosticsActivities.ProcessActivity LaunchNotepad;




    }
}

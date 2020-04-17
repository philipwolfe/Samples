//---------------------------------------------------------------------
//  This file is part of the NetFx3.com web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------
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

namespace ActivityLibrary1
{
	public sealed partial class Workflow1
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.CanModifyActivities = true;
			this.delayActivity2 = new System.Workflow.Activities.DelayActivity();
			this.suspendActivity1 = new System.Workflow.ComponentModel.SuspendActivity();
			this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
			this.sequenceActivity2 = new System.Workflow.Activities.SequenceActivity();
			this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
			this.parallelActivity1 = new System.Workflow.Activities.ParallelActivity();
			this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
			// 
			// delayActivity2
			// 
			this.delayActivity2.Name = "delayActivity2";
			this.delayActivity2.TimeoutDuration = System.TimeSpan.Parse("00:00:01");
			// 
			// suspendActivity1
			// 
			this.suspendActivity1.Name = "suspendActivity1";
			// 
			// delayActivity1
			// 
			this.delayActivity1.Name = "delayActivity1";
			this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:01");
			// 
			// sequenceActivity2
			// 
			this.sequenceActivity2.Activities.Add(this.delayActivity2);
			this.sequenceActivity2.Name = "sequenceActivity2";
			// 
			// sequenceActivity1
			// 
			this.sequenceActivity1.Activities.Add(this.delayActivity1);
			this.sequenceActivity1.Activities.Add(this.suspendActivity1);
			this.sequenceActivity1.Name = "sequenceActivity1";
			// 
			// parallelActivity1
			// 
			this.parallelActivity1.Activities.Add(this.sequenceActivity1);
			this.parallelActivity1.Activities.Add(this.sequenceActivity2);
			this.parallelActivity1.Name = "parallelActivity1";
			// 
			// codeActivity1
			// 
			this.codeActivity1.Name = "codeActivity1";
			this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
			// 
			// Workflow1
			// 
			this.Activities.Add(this.codeActivity1);
			this.Activities.Add(this.parallelActivity1);
			this.Name = "Workflow1";
			this.CanModifyActivities = false;

		}

		#endregion

		private CodeActivity codeActivity1;
		private ParallelActivity parallelActivity1;
		private SequenceActivity sequenceActivity1;
		private DelayActivity delayActivity1;
		private SuspendActivity suspendActivity1;
		private DelayActivity delayActivity2;
		private SequenceActivity sequenceActivity2;
	}
}

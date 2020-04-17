//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Beta 2 Hands on Labs
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

namespace LongRunningWorkflow
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
            this.BeforeBranch = new System.Workflow.Activities.CodeActivity();
            this.parallelActivity1 = new System.Workflow.Activities.ParallelActivity();
            this.AfterBranch = new System.Workflow.Activities.CodeActivity();
            this.factoringSequence = new System.Workflow.Activities.SequenceActivity();
            this.delaySequence = new System.Workflow.Activities.SequenceActivity();
            this.BeforeDelay = new System.Workflow.Activities.CodeActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.AfterDelay = new System.Workflow.Activities.CodeActivity();
            this.factorPrimesActivity1 = new LongRunningWorkflow.FactorPrimesActivity();
            // 
            // BeforeBranch
            // 
            this.BeforeBranch.Name = "BeforeBranch";
            this.BeforeBranch.ExecuteCode += new System.EventHandler(this.BeforeBranch_Execute);
            // 
            // parallelActivity1
            // 
            this.parallelActivity1.Activities.Add(this.factoringSequence);
            this.parallelActivity1.Activities.Add(this.delaySequence);
            this.parallelActivity1.Name = "parallelActivity1";
            // 
            // AfterBranch
            // 
            this.AfterBranch.Name = "AfterBranch";
            this.AfterBranch.ExecuteCode += new System.EventHandler(this.AfterBranch_Execute);
            // 
            // factoringSequence
            // 
            this.factoringSequence.Activities.Add(this.factorPrimesActivity1);
            this.factoringSequence.Name = "factoringSequence";
            // 
            // delaySequence
            // 
            this.delaySequence.Activities.Add(this.BeforeDelay);
            this.delaySequence.Activities.Add(this.delayActivity1);
            this.delaySequence.Activities.Add(this.AfterDelay);
            this.delaySequence.Name = "delaySequence";
            // 
            // BeforeDelay
            // 
            this.BeforeDelay.Name = "BeforeDelay";
            this.BeforeDelay.ExecuteCode += new System.EventHandler(this.BeforeDelay_Execute);
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:05");
            // 
            // AfterDelay
            // 
            this.AfterDelay.Name = "AfterDelay";
            this.AfterDelay.ExecuteCode += new System.EventHandler(this.AfterDelay_Execute);
            // 
            // factorPrimesActivity1
            // 
            this.factorPrimesActivity1.Name = "factorPrimesActivity1";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.BeforeBranch);
            this.Activities.Add(this.parallelActivity1);
            this.Activities.Add(this.AfterBranch);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private ParallelActivity parallelActivity1;
        private SequenceActivity factoringSequence;
        private CodeActivity BeforeDelay;
        private DelayActivity delayActivity1;
        private CodeActivity AfterDelay;
        private CodeActivity BeforeBranch;
        private CodeActivity AfterBranch;
        private FactorPrimesActivity factorPrimesActivity1;
        private SequenceActivity delaySequence;


    }
}

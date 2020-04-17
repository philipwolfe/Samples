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

namespace LongRunningWorkflow
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
            this.AfterDelay = new System.Workflow.Activities.CodeActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.BeforeDelay = new System.Workflow.Activities.CodeActivity();
            this.FactoringComplete = new System.Workflow.Activities.HandleExternalEventActivity();
            this.BeginFactoring = new System.Workflow.Activities.CallExternalMethodActivity();
            this.delaySequence = new System.Workflow.Activities.SequenceActivity();
            this.factoringSequence = new System.Workflow.Activities.SequenceActivity();
            this.AfterBranch = new System.Workflow.Activities.CodeActivity();
            this.parallelActivity1 = new System.Workflow.Activities.ParallelActivity();
            this.BeforeBranch = new System.Workflow.Activities.CodeActivity();
            // 
            // AfterDelay
            // 
            this.AfterDelay.Name = "AfterDelay";
            this.AfterDelay.ExecuteCode += new System.EventHandler(this.AfterDelay_Execute);
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:05");
            // 
            // BeforeDelay
            // 
            this.BeforeDelay.Name = "BeforeDelay";
            this.BeforeDelay.ExecuteCode += new System.EventHandler(this.BeforeDelay_Execute);
            // 
            // FactoringComplete
            // 
            this.FactoringComplete.EventName = "FactoredPrimes";
            this.FactoringComplete.InterfaceType = typeof(LongRunningWorkflow.IPrimeFactoring);
            this.FactoringComplete.Name = "FactoringComplete";
            // 
            // BeginFactoring
            // 
            this.BeginFactoring.InterfaceType = typeof(LongRunningWorkflow.IPrimeFactoring);
            this.BeginFactoring.MethodName = "FactorPrimes";
            this.BeginFactoring.Name = "BeginFactoring";
            // 
            // delaySequence
            // 
            this.delaySequence.Activities.Add(this.BeforeDelay);
            this.delaySequence.Activities.Add(this.delayActivity1);
            this.delaySequence.Activities.Add(this.AfterDelay);
            this.delaySequence.Name = "delaySequence";
            // 
            // factoringSequence
            // 
            this.factoringSequence.Activities.Add(this.BeginFactoring);
            this.factoringSequence.Activities.Add(this.FactoringComplete);
            this.factoringSequence.Name = "factoringSequence";
            // 
            // AfterBranch
            // 
            this.AfterBranch.Name = "AfterBranch";
            this.AfterBranch.ExecuteCode += new System.EventHandler(this.AfterBranch_Execute);
            // 
            // parallelActivity1
            // 
            this.parallelActivity1.Activities.Add(this.factoringSequence);
            this.parallelActivity1.Activities.Add(this.delaySequence);
            this.parallelActivity1.Name = "parallelActivity1";
            // 
            // BeforeBranch
            // 
            this.BeforeBranch.Name = "BeforeBranch";
            this.BeforeBranch.ExecuteCode += new System.EventHandler(this.BeforeBranch_Execute);
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

        private SequenceActivity delaySequence;
        private SequenceActivity factoringSequence;
        private DelayActivity delayActivity1;
        private HandleExternalEventActivity FactoringComplete;
        private CallExternalMethodActivity BeginFactoring;
        private CodeActivity AfterDelay;
        private CodeActivity BeforeDelay;
        private CodeActivity AfterBranch;
        private CodeActivity BeforeBranch;
        private ParallelActivity parallelActivity1;


    }
}

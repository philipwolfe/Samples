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

namespace DynamicUpdateChangingRules
{
	public sealed partial class DynamicRulesWorkflow
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.while1 = new System.Workflow.Activities.WhileActivity();
            this.sequence1 = new System.Workflow.Activities.SequenceActivity();
            this.initAmount = new System.Workflow.Activities.CodeActivity();
            this.ifElse1 = new System.Workflow.Activities.IfElseActivity();
            this.delay1 = new System.Workflow.Activities.DelayActivity();
            this.ifElseBranch1 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranch2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.getManagerApproval = new System.Workflow.Activities.CodeActivity();
            this.getVPApproval = new System.Workflow.Activities.CodeActivity();
            // 
            // while1
            // 
            this.while1.Activities.Add(this.sequence1);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ReRun);
            this.while1.Condition = codecondition1;
            this.while1.Name = "while1";
            // 
            // sequence1
            // 
            this.sequence1.Activities.Add(this.initAmount);
            this.sequence1.Activities.Add(this.ifElse1);
            this.sequence1.Activities.Add(this.delay1);
            this.sequence1.Name = "sequence1";
            // 
            // initAmount
            // 
            this.initAmount.Name = "initAmount";
            this.initAmount.ExecuteCode += new System.EventHandler(this.initAmount_ExecuteCode);
            // 
            // ifElse1
            // 
            this.ifElse1.Activities.Add(this.ifElseBranch1);
            this.ifElse1.Activities.Add(this.ifElseBranch2);
            this.ifElse1.Name = "ifElse1";
            // 
            // delay1
            // 
            this.delay1.Name = "delay1";
            this.delay1.TimeoutDuration = System.TimeSpan.Parse("00:00:02");
            // 
            // ifElseBranch1
            // 
            this.ifElseBranch1.Activities.Add(this.getManagerApproval);
            ruleconditionreference1.ConditionName = "Condition1";
            this.ifElseBranch1.Condition = ruleconditionreference1;
            this.ifElseBranch1.Name = "ifElseBranch1";
            // 
            // ifElseBranch2
            // 
            this.ifElseBranch2.Activities.Add(this.getVPApproval);
            this.ifElseBranch2.Name = "ifElseBranch2";
            // 
            // getManagerApproval
            // 
            this.getManagerApproval.Name = "getManagerApproval";
            this.getManagerApproval.ExecuteCode += new System.EventHandler(this.getManagerApproval_ExecuteCode);
            // 
            // getVPApproval
            // 
            this.getVPApproval.Name = "getVPApproval";
            this.getVPApproval.ExecuteCode += new System.EventHandler(this.getVPApproval_ExecuteCode);
            // 
            // DynamicRulesWorkflow
            // 
            this.Activities.Add(this.while1);
            this.Name = "DynamicRulesWorkflow";
            this.CanModifyActivities = false;

		}

		#endregion

        private WhileActivity while1;
        private SequenceActivity sequence1;
        private CodeActivity initAmount;
        private IfElseActivity ifElse1;
        private IfElseBranchActivity ifElseBranch1;
        private CodeActivity getManagerApproval;
        private IfElseBranchActivity ifElseBranch2;
        private CodeActivity getVPApproval;
        private DelayActivity delay1;







    }
}

﻿//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Workflow.Activities;

namespace Microsoft.Samples.Workflow.IfElseActivityWithRules
{
    public sealed partial class IfElseWorkflow
    {
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.VPApproval = new System.Workflow.Activities.CodeActivity();
            this.ManagerApproval = new System.Workflow.Activities.CodeActivity();
            this.ifElseBranch2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranch1 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElse1 = new System.Workflow.Activities.IfElseActivity();
            // 
            // VPApproval
            // 
            this.VPApproval.Name = "VPApproval";
            this.VPApproval.ExecuteCode += new System.EventHandler(this.VPApprovalHandler);
            // 
            // ManagerApproval
            // 
            this.ManagerApproval.Name = "ManagerApproval";
            this.ManagerApproval.ExecuteCode += new System.EventHandler(this.ManagerApprovalHandler);
            // 
            // ifElseBranch2
            // 
            this.ifElseBranch2.Activities.Add(this.VPApproval);
            this.ifElseBranch2.Name = "ifElseBranch2";
            // 
            // ifElseBranch1
            // 
            this.ifElseBranch1.Activities.Add(this.ManagerApproval);
            ruleconditionreference1.ConditionName = "OrderValueCheck";
            this.ifElseBranch1.Condition = ruleconditionreference1;
            this.ifElseBranch1.Name = "ifElseBranch1";
            // 
            // ifElse1
            // 
            this.ifElse1.Activities.Add(this.ifElseBranch1);
            this.ifElse1.Activities.Add(this.ifElseBranch2);
            this.ifElse1.Name = "ifElse1";
            // 
            // IfElseWorkflow
            // 
            this.Activities.Add(this.ifElse1);
            this.Name = "IfElseWorkflow";
            this.CanModifyActivities = false;

        }

        private IfElseActivity ifElse1;
        private IfElseBranchActivity ifElseBranch1;
        private CodeActivity ManagerApproval;
        private IfElseBranchActivity ifElseBranch2;
        private CodeActivity VPApproval;
    }
}


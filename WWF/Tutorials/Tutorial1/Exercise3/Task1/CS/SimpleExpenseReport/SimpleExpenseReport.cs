//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
using System;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Workflow.ComponentModel;

namespace Microsoft.Samples.Workflow.Tutorials.SequentialWorkflow
{
    [ExternalDataExchange]
    public interface IExpenseReportService
    {
        void GetLeadApproval( string message );
        void GetManagerApproval( string message );
        event EventHandler<ExternalDataEventArgs> ExpenseReportApproved;
        event EventHandler<ExternalDataEventArgs> ExpenseReportRejected;
    }

    public class ExpenseReportWorkflow : SequentialWorkflowActivity
    {
        private IfElseActivity evaluateExpenseReportAmount;
        private IfElseBranchActivity ifNeedsLeadApproval;
        private IfElseBranchActivity elseNeedsManagerApproval;
        private CallExternalMethodActivity invokeGetLeadApproval;
        private CallExternalMethodActivity invokeGetManagerApproval;

        private int reportAmount = 0;
        private string reportResult = "";

        public int Amount
        {
            set
            {
                this.reportAmount = value;
            }
        }

        public string Result
        {
            get
            {
                return this.reportResult;
            }
        }

        public ExpenseReportWorkflow()
        {        
            InitializeComponent();
        }

        private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            this.evaluateExpenseReportAmount = new IfElseActivity();
            this.ifNeedsLeadApproval = new IfElseBranchActivity();
            this.elseNeedsManagerApproval = new IfElseBranchActivity();
            this.invokeGetLeadApproval = new CallExternalMethodActivity();
            this.invokeGetManagerApproval = new CallExternalMethodActivity();
            CodeCondition ifElseLogicStatement = new CodeCondition();
            WorkflowParameterBinding workflowparameterbinding1 = 
                new WorkflowParameterBinding();
            WorkflowParameterBinding workflowparameterbinding2 = 
                new WorkflowParameterBinding();
            // 
            // EvaluateExpenseReportAmount
            // 
            this.evaluateExpenseReportAmount.Activities.Add(this.ifNeedsLeadApproval);
            this.evaluateExpenseReportAmount.Activities.Add
                (this.elseNeedsManagerApproval);
            this.evaluateExpenseReportAmount.Name = "evaluateExpenseReportAmount";
            // 
            // ifNeedsLeadApproval
            // 
            this.ifNeedsLeadApproval.Activities.Add(this.invokeGetLeadApproval);
            ifElseLogicStatement.Condition += new 
                System.EventHandler<ConditionalEventArgs>(this.DetermineApprovalContact);
            this.ifNeedsLeadApproval.Condition = ifElseLogicStatement;
            this.ifNeedsLeadApproval.Name = "ifNeedsLeadApproval";
            // 
            // elseNeedsManagerApproval
            // 
            this.elseNeedsManagerApproval.Activities.Add(this.invokeGetManagerApproval);
            this.elseNeedsManagerApproval.Name = "elseNeedsManagerApproval";
            // 
            // invokeGetLeadApproval
            // 
            this.invokeGetLeadApproval.InterfaceType = typeof(IExpenseReportService);
            this.invokeGetLeadApproval.MethodName = "GetLeadApproval";
            this.invokeGetLeadApproval.Name = "invokeGetLeadApproval";
            workflowparameterbinding1.ParameterName = "message";
            workflowparameterbinding1.Value = "Lead approval needed";
            this.invokeGetLeadApproval.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // invokeGetManagerApproval
            // 
            this.invokeGetManagerApproval.InterfaceType = typeof(IExpenseReportService);
            this.invokeGetManagerApproval.MethodName = "GetManagerApproval";
            this.invokeGetManagerApproval.Name = "invokeGetManagerApproval";
            workflowparameterbinding2.ParameterName = "message";
            workflowparameterbinding2.Value = "Manager approval needed";
            this.invokeGetManagerApproval.ParameterBindings.Add
                (workflowparameterbinding2);
            // 
            // ExpenseReportWorkflow
            // 
            this.Activities.Add(this.evaluateExpenseReportAmount);
            this.Name = "ExpenseReportWorkflow";
            this.CanModifyActivities = false;
        }

        void DetermineApprovalContact(object sender, ConditionalEventArgs e)
        {
            if (this.reportAmount < 1000)
            {
                e.Result = true;
            }
            else
            {
                e.Result = false;
            }
        }
    }
}

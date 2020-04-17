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
        void GetLeadApproval(string message);
        void GetManagerApproval(string message);
        event EventHandler<ExternalDataEventArgs> ExpenseReportApproved;
        event EventHandler<ExternalDataEventArgs> ExpenseReportRejected;
    }

    public class ExpenseReportWorkflow : SequentialWorkflowActivity
    {
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
            this.Name = "ExpenseReportWorkflow";
            this.CanModifyActivities = false;
        }
    }
}

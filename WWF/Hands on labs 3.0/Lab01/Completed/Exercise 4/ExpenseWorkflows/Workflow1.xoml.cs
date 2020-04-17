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
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace ExpenseWorkflows
{
	public partial class Workflow1 : SequentialWorkflowActivity
	{
        public string ReportEmployeeId = default(System.String);
        public string ManagerEmployeeId = default(System.String);
        public ExpenseLocalServices.ExpenseReportReviewedEventArgs reviewArgs =
            default(ExpenseLocalServices.ExpenseReportReviewedEventArgs);


        public int amount = default(System.Int32);
        public ExpenseLocalServices.ExpenseReportSubmittedEventArgs reportArgs = default(ExpenseLocalServices.ExpenseReportSubmittedEventArgs);
       
        private void ReportSubmitted_Invoked(object sender, ExternalDataEventArgs e)
        {
            Console.WriteLine("ReportSubmitted_Invoked");

            this.amount = this.reportArgs.Report.Amount;

            this.ReportEmployeeId = this.reportArgs.Report.EmployeeId;
        }

        private void IfReportApproved_Condition(object sender, ConditionalEventArgs e)
        {
            e.Result = this.reviewArgs.Review.Approved;
        }
	}
}
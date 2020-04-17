//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
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
using System.Workflow.Activities;

using ExpenseLocalServices;

namespace ExpenseWorkflows
{
	public partial class SequentialWorkflow : SequentialWorkflowActivity
	{
        public int amount = default(Int32);
        public bool AutoApproved = default(bool);

	    public string ReportEmployeeId = default(String);
        public string ManagerEmployeeId = default(String);

        public ExpenseReportSubmittedEventArgs reportArgs =
            default(ExpenseReportSubmittedEventArgs);
        public ExpenseReportReviewedEventArgs reviewArgs =
            default(ExpenseReportReviewedEventArgs);
    
        private void ReportSubmitted_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.amount = this.reportArgs.Report.Amount;
            this.ReportEmployeeId = this.reportArgs.Report.EmployeeId;
        }
	}
}

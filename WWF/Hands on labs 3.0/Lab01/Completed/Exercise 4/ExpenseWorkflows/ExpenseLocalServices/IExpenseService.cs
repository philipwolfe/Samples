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
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;

namespace ExpenseLocalServices
{
    [ExternalDataExchangeAttribute()]
	public interface IExpenseService
	{
		void ApproveExpenseReport(ExpenseReport report);

		void RejectExpenseReport(ExpenseReport report);

		void RequestManagerApproval(ExpenseLocalServices.ExpenseReport report, string ManagerEmployeeId);

		event EventHandler<ExpenseReportSubmittedEventArgs> ExpenseReportSubmitted;

		event EventHandler<ExpenseReportReviewedEventArgs> ExpenseReportReviewed;
	}

	[Serializable]
	public class ExpenseReportSubmittedEventArgs : ExternalDataEventArgs
	{
		public ExpenseReportSubmittedEventArgs(System.Guid InstanceId) : base(InstanceId) 
		{
		}

		private ExpenseReport report;

		public ExpenseReport Report
		{
			get { return report; }
			set { report = value; }
		}
	}

	[Serializable]
	public class ExpenseReportReviewedEventArgs : ExternalDataEventArgs
	{
		public ExpenseReportReviewedEventArgs(Guid InstanceId, ExpenseReport report, ExpenseReportReview review) 
			: base(InstanceId) 
		{
			this.report = report;
			this.review = review;
		}

		private ExpenseReport report;

		public ExpenseReport Report
		{
			get { return report; }
			set { report = value; }
		}

		private ExpenseReportReview review;

		public ExpenseReportReview Review
		{
			get { return review; }
			set { review = value; }
		}
	}
}

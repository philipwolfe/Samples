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
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

namespace ExpenseLocalServices
{
	public class ExpenseLocalService : IExpenseService
	{
		private WorkflowRuntime _wfruntime;
		private Type _ActivatingWorkflow;
		List<ExpenseReport> _ExpenseReports;

        public ExpenseLocalService(WorkflowRuntime workflowRuntime, Type activatingWorkflow)
        {
			// Store references to both the WorkflowServiceContainer and the Activating Workflow type
			// ...in member variables so we can use them later in this Local Service.  
			_wfruntime = workflowRuntime;
			_ActivatingWorkflow = activatingWorkflow;

			// Create a new List for storing the Expense Reports in memory
			_ExpenseReports = new List<ExpenseReport>();

        }

		#region IExpenseService Members

		void IExpenseService.ApproveExpenseReport(ExpenseReport report)
		{
			// Update the status for the specified report
			UpdateReportStatus(report, StatusEnum.Approved);
		}

		void IExpenseService.RequestManagerApproval(ExpenseReport report, string ManagerEmployeeId)
		{
            // Update the status for the specified report 
			UpdateReportStatus(report, StatusEnum.InReview);
		}

		void IExpenseService.RejectExpenseReport(ExpenseReport report)
		{
            // Update the status for the specified report 
			UpdateReportStatus(report, StatusEnum.Rejected);
		}

		public event EventHandler<ExpenseReportSubmittedEventArgs> ExpenseReportSubmitted;
		public event EventHandler<ExpenseReportReviewedEventArgs> ExpenseReportReviewed;
		#endregion

		private void UpdateReportStatus(ExpenseReport report, StatusEnum status)
		{
			// Find the report specified in our local data cache
			ExpenseReport foundReport = this.GetExpenseReport(report.ExpenseReportId);

			// If we can't find the report, then throw an exception
			if (foundReport == null)
			{
				throw new System.ApplicationException("Unable to find the specified Expense Report");
			}

			// Update the status for the found report
			foundReport.Status = status;
		}
		

		public ExpenseReport GetExpenseReport(System.Guid ExpenseReportId)
		{
			foreach (ExpenseReport report in _ExpenseReports)
			{
				if (report.ExpenseReportId.Equals(ExpenseReportId))
				{
					return report;
				}
			}
			return null;
		}

		public void RaiseExpenseReportSubmittedEvent(System.Guid InstanceId, ExpenseReport report)
		{
			// Start the Expense Reporting workflow
			_wfruntime.CreateWorkflow(this._ActivatingWorkflow, new Dictionary<string,object>(), InstanceId).Start();

			// Create the EventArgs for this event
			ExpenseReportSubmittedEventArgs e = new ExpenseReportSubmittedEventArgs(InstanceId);
			e.Report = report;

			// Raise the ExpenseReportSubmitted event
			if (this.ExpenseReportSubmitted != null)
				this.ExpenseReportSubmitted(null, e);

			// Add the Expense Report to the List
			_ExpenseReports.Add(report);
		}


		public void RaiseExpenseReportReviewedEvent(System.Guid InstanceId, ExpenseReport report, ExpenseReportReview review)
		{

			// Determine the new status for the reviewed report
			StatusEnum status = StatusEnum.InReview;

			if (review.Approved)
			{
				status = StatusEnum.Approved;
			}
			else
			{
				status = StatusEnum.Rejected;
			}

			// Update the status of the report 
			this.UpdateReportStatus(report, status);


			// Create the EventArgs for this event
			ExpenseReportReviewedEventArgs e =
				new ExpenseReportReviewedEventArgs(InstanceId, report, review);

			// Raise the ExpenseReportReviewed event
			if (this.ExpenseReportReviewed != null)
				this.ExpenseReportReviewed(null, e);
		}

		public List<ExpenseReport> GetExpenseReportsList()
		{
			// Return the list of ExpenseReports we've been maintaining in memory
			return _ExpenseReports;
		}
	}
}

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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Runtime;

using ExpenseContracts;

namespace ExpenseLocalServices
{
    /// <summary>
    /// This class is used to interact, primarily through raising events with the Workflow instance.
    /// It is providing an implementation of the contract defined in IExpenseLocalService
    /// </summary>
    public class ExpenseLocalService : IExpenseLocalService
    {
        public event EventHandler<ExpenseReportSubmittedEventArgs> ExpenseReportSubmitted;
        public event EventHandler<ExpenseReportReviewedEventArgs> ExpenseReportReviewed;

        public event EventHandler<ManagerApprovalRequestedEventArgs> ManagerApprovalRequested;
        public event EventHandler<ManagerReviewedEventArgs> ManagerReviewed;
        
        private List<ExpenseReport> expenseReports;

        public ExpenseLocalService(WorkflowRuntime workflowRuntime)
        {
            expenseReports = new List<ExpenseReport>();
        }

        /// <summary>
        /// Raises an event out of the service to indicate that a manager is required
        /// to review an expense report
        /// </summary>
        void IExpenseLocalService.RequestManagerApproval(ExpenseReport report, string ManagerEmployeeId)
        {
            UpdateReportStatus(report, ExpenseReportStatus.InReview, null);
            
            ManagerApprovalRequestedEventArgs e =
                new ManagerApprovalRequestedEventArgs(report);

            if (ManagerApprovalRequested != null)
            {
                ManagerApprovalRequested(null, e);
            }
        }
        
        /// <summary>
        /// Raises an event to the workflow to indicate that a manager has reviewed
        /// an expense report and approved it
        /// </summary>
        void IExpenseLocalService.ApproveExpenseReport(ExpenseReport report)
        {
            UpdateReportStatus(report, ExpenseReportStatus.Approved, null);            
            
            report.Status = ExpenseReportStatus.Approved;
            
            ManagerReviewedEventArgs e =
                new ManagerReviewedEventArgs(report);

            if (ManagerReviewed != null)
            {
                ManagerReviewed(null, e);
            }
        }

        /// <summary>
        /// Raises an event to the workflow to indicate that a manager has reviewed
        /// an expense report and rejected it
        /// </summary>
        void IExpenseLocalService.RejectExpenseReport(ExpenseReport report)
        {
            UpdateReportStatus(report, ExpenseReportStatus.Rejected, null);
            
            report.Status = ExpenseReportStatus.Rejected;
            
            ManagerReviewedEventArgs e =
                new ManagerReviewedEventArgs(report);

            if (ManagerReviewed != null)
            {
                ManagerReviewed(null, e);
            }
        }

        public ExpenseReport GetExpenseReport(Guid expenseReportId)
        {
            ExpenseReport foundReport = null;

            foreach (ExpenseReport report in expenseReports)
            {
                if (report.ExpenseReportId.Equals(expenseReportId))
                {
                    foundReport = report;
                    break;
                }
            }

            return foundReport;
        }

        private void UpdateReportStatus(ExpenseReport report, ExpenseReportStatus status, ArrayList errors)
        {
            ExpenseReport foundReport = GetExpenseReport(report.ExpenseReportId);

            if (foundReport == null)
            {
                throw new ApplicationException("Unable to find the specified Expense Report");
            }

            foundReport.Status = status;

            string outputMessage = "";

            if (status == ExpenseReportStatus.Approved)
            {
                outputMessage = string.Format("Expense Report {0} was approved.",
                                              foundReport.ExpenseReportId.ToString());
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (status == ExpenseReportStatus.Rejected)
            {
                string errorsMessage = "";

                if (errors != null)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (string error in errors)
                    {
                        sb.AppendLine(error);
                    }
                    errorsMessage = sb.ToString();
                }

                outputMessage = string.Format("Expense Report {0} was rejected. {1}",
                                              foundReport.ExpenseReportId.ToString(), errorsMessage);
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine(outputMessage);
            Console.ResetColor();
        }

        /// <summary>
        /// Raises an event to the workflow to indicate that someone has submitted
        /// an expense report
        /// </summary>
        public void RaiseExpenseReportSubmittedEvent(Guid workflowInstanceId, ExpenseReport report)
        {
            ExpenseReportSubmittedEventArgs e =
                new ExpenseReportSubmittedEventArgs(workflowInstanceId);
            e.Report = report;

            if (ExpenseReportSubmitted != null)
            {
                ExpenseReportSubmitted(null, e);
            }

            expenseReports.Add(report);
        }

        /// <summary>
        /// Raises an event out of the service to indicate that a manager has reviewed
        /// an expense report
        /// </summary>
        public void RaiseExpenseReportReviewedEvent(Guid workflowInstanceId,
                                                    ExpenseReport report, ExpenseReportReview review)
        {
            ExpenseReport foundReport = GetExpenseReport(report.ExpenseReportId);
            ExpenseReportStatus currentStatus = foundReport.Status;

            if (currentStatus != ExpenseReportStatus.InReview)
            {
                return;
            }

            ExpenseReportReviewedEventArgs e =
                new ExpenseReportReviewedEventArgs(workflowInstanceId, report, review);

            if (ExpenseReportReviewed != null)
            {
                ExpenseReportReviewed(null, e);
            }
        }

        public List<ExpenseReport> GetExpenseReports()
        {
            return expenseReports;
        }
    }    
}
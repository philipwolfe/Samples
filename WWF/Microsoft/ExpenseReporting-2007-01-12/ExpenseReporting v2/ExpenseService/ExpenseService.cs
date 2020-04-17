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
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using System.Workflow.Activities;
using System.Workflow.Runtime;
using System.Threading;

using ExpenseContracts;
using ExpenseLocalServices;
using WcfExtensions;

namespace ExpenseServices
{
    /// <summary>
    /// This class provides an implementation of all of the service contracts
    /// which make up the Expense Reporting business process and acts as an
    /// entry point to our workflow
    /// </summary>
    /// <remarks>
    /// The service declares a behavior of InstanceContextMode.Single which
    /// means
    /// </remarks>
    [ServiceBehavior(
        InstanceContextMode=InstanceContextMode.Single)]
    public class ExpenseService : 
        IExpenseService,
        IExpenseServiceClient,
        IExpenseServiceManager
    {
        private WorkflowRuntime workflowRuntime;
        private ExpenseLocalService expenseLocalService;
        private Dictionary<Guid, IExpenseServiceClientCallback> clients;
        
        public ExpenseService()
        {
            clients = new Dictionary<Guid, IExpenseServiceClientCallback>();
        }
        
        /// <summary>
        /// Returns a set of all current expense reports
        /// </summary>
        public GetExpenseReportsResponse GetExpenseReports()
        {
            return new GetExpenseReportsResponse(expenseLocalService.GetExpenseReports());
        }

        /// <summary>
        /// Returns a specifically requested expense report.
        /// </summary>
        /// <param name="getExpenseReportRequest">The message det</param>
        /// <returns></returns>
        public GetExpenseReportResponse GetExpenseReport(GetExpenseReportRequest getExpenseReportRequest)
        {
            return new GetExpenseReportResponse(
                expenseLocalService.GetExpenseReport(getExpenseReportRequest.ExpenseReportId));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="submitExpenseReportRequest">Message containing the details of the expense report being submitted</param>
        /// <returns>A SubmitExpenseReportResponse object which gives the identifier of the submitted expense report</returns>
        public SubmitExpenseReportResponse SubmitExpenseReport(SubmitExpenseReportRequest submitExpenseReportRequest)
        {
            try
            {
                Console.WriteLine("Expense Report Submitted: {0}, {1}, {2}",
                                  submitExpenseReportRequest.Report.ExpenseReportId, 
                                  submitExpenseReportRequest.Report.Amount, 
                                  submitExpenseReportRequest.Report.EmployeeId);
                
                SetUpWorkflowEnvironment();

                // Create a new instance of the SequentialWorkflow and submit it to the WorkflowRuntime

                Guid workflowInstanceId = submitExpenseReportRequest.Report.ExpenseReportId;

                Assembly asm =
                    Assembly.Load("ExpenseWorkflows");
                Type workflowType = asm.GetType("ExpenseWorkflows.SequentialWorkflow");

                WorkflowInstance workflowInstance =
                    workflowRuntime.CreateWorkflow(workflowType, null, workflowInstanceId);
                workflowInstance.Start();

                expenseLocalService.RaiseExpenseReportSubmittedEvent(
                    workflowInstanceId, submitExpenseReportRequest.Report);

                // Register the current caller for any callbacks associated with this workflow

                IExpenseServiceClientCallback caller =
                    OperationContext.Current.GetCallbackChannel<IExpenseServiceClientCallback>();

                if (caller != null)
                {
                    if (!clients.ContainsKey(submitExpenseReportRequest.Report.ExpenseReportId))
                        clients.Add(submitExpenseReportRequest.Report.ExpenseReportId, caller);
                }

                return new SubmitExpenseReportResponse(workflowInstanceId);
            }
            catch (Exception excp)
            {
                Console.WriteLine("The following exception occured: " + excp.ToString());
                throw;
            }
        }

        public SubmitReviewedExpenseReportResponse SubmitReviewedExpenseReport(
            SubmitReviewedExpenseReportRequest submitReviewedExpenseReportRequest)
        {
            try
            {
                Console.WriteLine("Expense Report Reviewed: {0}, {1}, {2}, Approved:{3}",
                                  submitReviewedExpenseReportRequest.Report.ExpenseReportId, 
                                  submitReviewedExpenseReportRequest.Report.Amount, 
                                  submitReviewedExpenseReportRequest.Report.EmployeeId,
                                  submitReviewedExpenseReportRequest.Review.Approved);

                Guid workflowInstanceId = submitReviewedExpenseReportRequest.Report.ExpenseReportId;

                expenseLocalService.RaiseExpenseReportReviewedEvent(
                    workflowInstanceId, submitReviewedExpenseReportRequest.Report, submitReviewedExpenseReportRequest.Review);

                return new SubmitReviewedExpenseReportResponse(workflowInstanceId);
            }
            catch (Exception excp)
            {
                Console.WriteLine("The following exception occured: " + excp.ToString());
                throw;
            }
        }

        /// <summary>
        /// Calls back to the Manager Application over its client callback channel
        /// </summary>
        /// <remarks>
        /// This is done using a background worker thread
        /// </remarks>
        private void expenseLocalService_ManagerApprovalRequested(object sender, ManagerApprovalRequestedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(
                delegate
                {
                    IExpenseServiceManagerApplication proxy =
                        new ChannelFactory<IExpenseServiceManagerApplication>("ExpenseServiceManagerApplication").CreateChannel();
                    proxy.ExpenseReportSubmitted(new ExpenseReportSubmittedRequest(e.Report));
                }
            );
        }

        /// <summary>
        /// Calls back to a client application to indicate that an expense report that
        /// they are interested in has been reviewed. Additionally we update the manager
        /// at this stage as well, as they might not have directly been involved the review.
        /// </summary>
        /// <remarks>
        /// This is done using a background worker thread
        /// </remarks>
        private void ExpenseLocalService_ManagerReviewedOrTimeout(object sender, ManagerReviewedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(
                delegate
                {
                    // We find the client callback instance by checking the clients collection
                    // for the given ExpenseReportId. The callback instance which we retrieved and stored 
                    // during <x> can be referenced and used from here.

                    if (clients.ContainsKey(e.Report.ExpenseReportId))
                    {
                        IExpenseServiceClientCallback callback;
                        if (clients.TryGetValue(e.Report.ExpenseReportId, out callback))
                            callback.ExpenseReportReviewed(new ExpenseReportReviewedRequest(e.Report));
                    }

                    // We also update the manager through our channel to the manager

                    IExpenseServiceManagerApplication proxy =
                        new ChannelFactory<IExpenseServiceManagerApplication>("ExpenseServiceManagerApplication").CreateChannel();
                    proxy.ExpenseReportReviewed(new ExpenseReportReviewedRequest(e.Report));
                }
            );
        }
        
        /// <summary>
        /// Ensures that the instance of ExpenseLocalService has been initialized
        /// and added to the workflow's data exchange
        /// </summary>
        /// <remarks>
        /// There will only be a single instance of this object in activation
        /// at any point in time.
        /// </remarks>
        private void SetUpWorkflowEnvironment()
        {
            if (expenseLocalService == null)
            {
                WfWcfExtension extension =
                    OperationContext.Current.Host.Extensions.Find<WfWcfExtension>();

                workflowRuntime = extension.WorkflowRuntime;

                // We will try and fetch the instance from the active WorkflowRuntime's
                // ExtenalDataExchangeService and if it currently does not have an
                // activated instance, we will create a new instance and add it.

                ExternalDataExchangeService dataExchangeService =
                    workflowRuntime.GetService<ExternalDataExchangeService>();

                expenseLocalService =
                    (ExpenseLocalService)dataExchangeService.GetService(typeof(ExpenseLocalService));

                if (expenseLocalService == null)
                {
                    expenseLocalService =
                        new ExpenseLocalService(workflowRuntime);
                    dataExchangeService.AddService(expenseLocalService);
                }

                // Events are then wired up to our local event handlers
                expenseLocalService.ManagerApprovalRequested +=
                    new EventHandler<ManagerApprovalRequestedEventArgs>(expenseLocalService_ManagerApprovalRequested);
                expenseLocalService.ManagerReviewed +=
                    new EventHandler<ManagerReviewedEventArgs>(ExpenseLocalService_ManagerReviewedOrTimeout);
            }
        }
    }
}
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
using System.Runtime.Remoting;

using System.Workflow;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;

namespace ExpenseLocalServices
{
	// Well Known Web Service object
	public class ExpenseRemoteService : MarshalByRefObject
	{
		WorkflowRuntime workflowRuntime;
		ExpenseLocalServices.ExpenseLocalService expsvc;

		public ExpenseRemoteService()
		{
			this.StartWorkflowHost();
		}
        
		public System.Guid SubmitExpenseReport(
			ExpenseLocalServices.ExpenseReport report)
		{
            try
			{
				System.Console.WriteLine("Submit Expense Report");

				// Create a new GUID for the WorkflowInstanceID
				System.Guid WorkflowInstanceId = report.ExpenseReportId;

				expsvc.RaiseExpenseReportSubmittedEvent(WorkflowInstanceId, report);

				return WorkflowInstanceId;
			}
			catch (Exception excp)
			{
				System.Console.WriteLine(excp.ToString());
				throw excp;
			}
		}

		public System.Guid ExpenseReportReviewed(
			ExpenseLocalServices.ExpenseReport report, 
			ExpenseLocalServices.ExpenseReportReview review)
		{
			// Create a new GUID for the WorkflowInstanceID
			System.Guid WorkflowInstanceId = report.ExpenseReportId;

			expsvc.RaiseExpenseReportReviewedEvent(WorkflowInstanceId, report, review);

			return WorkflowInstanceId;
		}

		public List<ExpenseReport> GetExpenseReportsList()
		{
			return expsvc.GetExpenseReportsList();
		}

		public ExpenseReport GetExpenseReport(System.Guid ExpenseReportId)
		{
			return expsvc.GetExpenseReport(ExpenseReportId);
		}

		private void StartWorkflowHost()
		{
			// Create a new Workflow Runtime
			workflowRuntime = new WorkflowRuntime();

			// Start the Workflow services
			workflowRuntime.StartRuntime();

			System.Reflection.Assembly assm = System.Reflection.Assembly.Load("ExpenseWorkflows");
			System.Type typRemoteService = assm.GetType("ExpenseWorkflows.Workflow1");


			// Create a new instance of the local service and host it in an ExternalDataExchangeService
			// ...give it a reference to the container and type of workflow
            ExternalDataExchangeService exSvc = new ExternalDataExchangeService();
            workflowRuntime.AddService(exSvc);
            expsvc = new ExpenseLocalServices.ExpenseLocalService(workflowRuntime, typRemoteService);
            exSvc.AddService(expsvc);

            
		}
	}
}

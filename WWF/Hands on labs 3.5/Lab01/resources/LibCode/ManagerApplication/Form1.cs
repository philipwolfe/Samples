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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;


namespace ManagerApplication
{
	public partial class Form1 : Form
	{
		
		public Form1()
		{
			InitializeComponent();

			// Initialize .NET Remoting
			RemotingConfiguration.Configure("ManagerApplication.exe.config");
		}


		private void btnRefresh_Click(object sender, EventArgs e)
		{
			RefreshExpenseReports();
		}

		private void RefreshExpenseReports()
		{
			// Clear the current list
			this.lstvwExpenseReports.Items.Clear();


			// Get the URL for the ExpenseRemoteService
			string strExpenseRemoteServiceUrl =
				ConfigurationManager.AppSettings["ExpenseRemoteServiceUrl"].ToString();

			// Get a reference to the Expense Service through .NET Remoting
			ExpenseLocalServices.ExpenseRemoteService svcExpenseService =
					 (ExpenseLocalServices.ExpenseRemoteService)Activator.GetObject(typeof(ExpenseLocalServices.ExpenseRemoteService),
					 strExpenseRemoteServiceUrl);

			

			// Get the list of current Expense Reports
			List<ExpenseLocalServices.ExpenseReport> reports =
				svcExpenseService.GetExpenseReportsList();

			// Add each Expense Report back into the list with the updated status
			foreach (ExpenseLocalServices.ExpenseReport report in reports)
			{
				this.CreateListViewItem(report);
			}
		}

		private void CreateListViewItem(ExpenseLocalServices.ExpenseReport report)
		{
			// Create a new item for the ExpenseReport
			ListViewItem lvitemExpenseReport =
				this.lstvwExpenseReports.Items.Add(report.ExpenseReportId.ToString(),
												report.ExpenseReportId.ToString(), "");

			// Use the ExpenseReportId as the key & text for the new list item
			lvitemExpenseReport.Text = report.ExpenseReportId.ToString();

			// Add the value for the Amount column
			lvitemExpenseReport.SubItems.Add(report.Amount.ToString());

			// Add the submitted time 
			lvitemExpenseReport.SubItems.Add(report.SubmittedTime.ToString());

			// Add the Submitted By
			lvitemExpenseReport.SubItems.Add(report.SubmittedBy);

			// Add the status
			lvitemExpenseReport.SubItems.Add(report.Status.ToString());
		}

		private void btnApprove_Click(object sender, EventArgs e)
		{
			SubmitExpenseReportReview(true);
		}


		private void btnReject_Click(object sender, EventArgs e)
		{
			SubmitExpenseReportReview(false);
		}


		private void SubmitExpenseReportReview(bool Approved)
		{
			foreach (ListViewItem lstvwitemExpenseReport in this.lstvwExpenseReports.SelectedItems)
			{

				// Get the ExpenseReportId from the selected item in the Listview
				string strExpenseReportId = lstvwitemExpenseReport.Text;
				System.Guid ExpenseReportId = new Guid(strExpenseReportId);

				// Construct the Review for the expense report
				ExpenseLocalServices.ExpenseReportReview review =
					new ExpenseLocalServices.ExpenseReportReview();
				review.Approved = Approved;
				review.ExpenseReportId = ExpenseReportId;
				review.ReviewedBy = "neilhut";



				// Get the URL for the ExpenseRemoteService
				string strExpenseRemoteServiceUrl =
					ConfigurationManager.AppSettings["ExpenseRemoteServiceUrl"].ToString();

				// Get a reference to the Expense Service through .NET Remoting
				ExpenseLocalServices.ExpenseRemoteService svcExpenseService =
						(ExpenseLocalServices.ExpenseRemoteService)Activator.GetObject(typeof(ExpenseLocalServices.ExpenseRemoteService),
						strExpenseRemoteServiceUrl);

				// Get the specific Expense Report
				ExpenseLocalServices.ExpenseReport report =
					svcExpenseService.GetExpenseReport(ExpenseReportId);

				// Submit the review for the Expense Report
				svcExpenseService.ExpenseReportReviewed(report, review);
			}

			// Refresh the list of Expense Reports
			this.RefreshExpenseReports();
		}
	}
}
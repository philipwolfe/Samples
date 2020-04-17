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



namespace ExpenseApplication
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			// Initialize .NET Remoting
			RemotingConfiguration.Configure("ExpenseApplication.exe.config");
		}

		private void button1_Click(object sender, EventArgs e)
		{

			// Create a new Expense Report record using some static data
			ExpenseLocalServices.ExpenseReport report = 
				new ExpenseLocalServices.ExpenseReport();
			report.Amount = System.Convert.ToInt32(this.txtAmount.Text);
			report.EmployeeId = "1";
			report.ExpenseReportId = System.Guid.NewGuid();
			report.SubmittedBy = this.txtSubmittedBy.Text;
			report.SubmittedTime = System.DateTime.Now;


			// Get the URL for the ExpenseRemoteService
			string strExpenseRemoteServiceUrl =
				ConfigurationManager.AppSettings["ExpenseRemoteServiceUrl"].ToString();

			// Get a reference to the Expense Service through .NET Remoting
			ExpenseLocalServices.ExpenseRemoteService svcExpenseService =
					 (ExpenseLocalServices.ExpenseRemoteService)Activator.GetObject(typeof(ExpenseLocalServices.ExpenseRemoteService),
					 strExpenseRemoteServiceUrl);

			// Submit the Expense Report for approval
			svcExpenseService.SubmitExpenseReport(report);

			// Add a new item to the Expense Reports list view
			this.CreateListViewItem(report);

			// Clear the values in the data entry fields
			this.txtAmount.Text = "";
			this.txtSubmittedBy.Text = "";

		}

		private void btnRefresh_Click(object sender, EventArgs e)
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
			lvitemExpenseReport.SubItems.Add(report.SubmittedBy.ToString());

			// Add the status
			lvitemExpenseReport.SubItems.Add(report.Status.ToString());
		}
	}
}
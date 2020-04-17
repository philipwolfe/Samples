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
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;

using ExpenseContracts;

namespace ExpenseApplication
{
    public partial class ClientForm : Form
    {
        private IExpenseServiceClient expenseServiceClient;
        
        public ClientForm()
        {
            InitializeComponent();

            // Create a two-way connection to the ExpenseReporting service
            expenseServiceClient = CreateChannelExpenseServiceClient();
            ((IClientChannel)expenseServiceClient).Open();
        }

        private void btnSubmitReport_Click(object sender, EventArgs e)
        {
            if (!ValidateExpenseReport())
            {
                return;
            }

            btnSubmitReport.Enabled = false;

            ExpenseReport report =
                new ExpenseReport();
            report.Amount = Convert.ToInt32(txtAmount.Text);
            report.EmployeeId = "1"; //hard-coded
            report.ExpenseReportId = Guid.NewGuid();
            report.SubmitterBy = txtSubmittedBy.Text;
            report.SubmittedTime = DateTime.Now;

            Guid erID =
                expenseServiceClient.SubmitExpenseReport(new SubmitExpenseReportRequest(report)).ID;
            toolStripStatusLabel1.Text = "Expense Report was submitted: " + erID.ToString();
            
            CreateListViewItem(report);

            txtAmount.Text = "";
            txtSubmittedBy.Text = "";

            btnSubmitReport.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstvwExpenseReports.Items.Clear();

            List<ExpenseReport> reports =
                expenseServiceClient.GetExpenseReports().Reports;

            foreach (ExpenseReport report in reports)
            {
                CreateListViewItem(report);
            }
        }

        /// <summary>
        /// Creates a new line item for a report and inserts it into the list view
        /// </summary>
        internal void CreateListViewItem(ExpenseReport report)
        {
            toolStripStatusLabel1.Text =
                String.Format("Expense report {0} has been {1}.", report.ExpenseReportId, report.Status);
            
            if(lstvwExpenseReports.Items.ContainsKey(report.ExpenseReportId.ToString()))
            {
                lstvwExpenseReports.Items.RemoveByKey(report.ExpenseReportId.ToString());
            }
                
            ListViewItem lvitemExpenseReport =
                lstvwExpenseReports.Items.Add(report.ExpenseReportId.ToString(),
                                              report.ExpenseReportId.ToString(), "");
            
            lvitemExpenseReport.UseItemStyleForSubItems = false;
            lvitemExpenseReport.Text = report.ExpenseReportId.ToString();
            lvitemExpenseReport.SubItems.Add(report.Amount.ToString());
            lvitemExpenseReport.SubItems.Add(report.SubmittedTime.ToString());
            lvitemExpenseReport.SubItems.Add(report.SubmitterBy.ToString());
           
            ListViewItem.ListViewSubItem lvSubItemStatus =
                new ListViewItem.ListViewSubItem(lvitemExpenseReport, report.Status.ToString());
            if(report.Status == ExpenseReportStatus.Approved)
                lvSubItemStatus.ForeColor = Color.Green;
            else if (report.Status == ExpenseReportStatus.Rejected)
                lvSubItemStatus.ForeColor = Color.Red;
            lvitemExpenseReport.SubItems.Add(lvSubItemStatus);
        }

        /// <summary>
        /// Implements basic entity validation for an ExpenseReport
        /// </summary>
        /// <remarks>Used during data entry</remarks>
        private bool ValidateExpenseReport()
        {
            if (txtAmount.Text.Length == 0)
            {
                MessageBox.Show("The Amount is required.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int reportAmount;

            if (!Int32.TryParse(txtAmount.Text, out reportAmount))
            {
                MessageBox.Show("The Amount is invalid.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Initializes a two-way (duplex) connection to the ExpenseReporting host
        /// service. We also initialize a new instance of our CallbackHandler to recieve
        /// notifications from the host.
        /// </summary>
        /// <returns>An instance implementing the service contract which we can use to interact with the ExpenseReporting host</returns>
        private IExpenseServiceClient CreateChannelExpenseServiceClient()
        {
            InstanceContext context = new InstanceContext(
                new CallbackHandler());

            DuplexChannelFactory<IExpenseServiceClient> factory =
                new DuplexChannelFactory<IExpenseServiceClient>(context, "ExpenseServiceClient");
            IExpenseServiceClient proxy = factory.CreateChannel();

            return proxy;
        }
    }
}
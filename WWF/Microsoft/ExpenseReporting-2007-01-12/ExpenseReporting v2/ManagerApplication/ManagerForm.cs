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
using System.ServiceModel;
using System.Windows.Forms;

using ExpenseContracts;

namespace ManagerApplication
{
    public partial class ManagerForm : Form
    {
        private IExpenseServiceManager expenseServiceManager;
        private ServiceHost sh;
        [ThreadStatic]
        private static ManagerForm form;

        public static ManagerForm Form
        {
            get { return form; }
            set { form = value; }
        }
        
        public ManagerForm()
        {
            InitializeComponent();

            form = this;
            
            // Initialize a new instance of the ServiceHost which will publish
            // the endpoint for our manager application service contract
            sh = new ServiceHost(typeof(ManagerApplicationService));
            sh.Open();
            
            // Create our connection to the ExpenseReporting host
            expenseServiceManager = CreateChannelExpenseServiceManager();
            ((IClientChannel)expenseServiceManager).Open();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshExpenseReports();
        }

        private void RefreshExpenseReports()
        {
            lstvwExpenseReports.Items.Clear();

            List<ExpenseReport> reports =
                expenseServiceManager.GetExpenseReports().Reports;

            foreach (ExpenseReport report in reports)
            {
                CreateListViewItem(report);
            }
        }

        internal void CreateListViewItem(ExpenseReport report)
        {
            toolStripStatusLabel1.Text = "Exponse report submitted: " +
                report.ExpenseReportId;

            if (lstvwExpenseReports.Items.ContainsKey(report.ExpenseReportId.ToString()))
            {
                lstvwExpenseReports.Items.RemoveByKey(report.ExpenseReportId.ToString());
            }

            ListViewItem lvitemExpenseReport =
                lstvwExpenseReports.Items.Add(report.ExpenseReportId.ToString(),
                                              report.ExpenseReportId.ToString(), "");

            lvitemExpenseReport.Text = report.ExpenseReportId.ToString();

            lvitemExpenseReport.SubItems.Add(report.Amount.ToString());
            lvitemExpenseReport.SubItems.Add(report.SubmittedTime.ToString());
            lvitemExpenseReport.SubItems.Add(report.SubmitterBy);
            lvitemExpenseReport.SubItems.Add(report.Status.ToString());

            lstvwExpenseReports.SelectedItems.Clear();
            lstvwExpenseReports.Items[lstvwExpenseReports.Items.Count-1].Selected = true;
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
            foreach (ListViewItem lstvwitemExpenseReport in lstvwExpenseReports.SelectedItems)
            {
                string expenseReportId = lstvwitemExpenseReport.Text;
                Guid expenseReportGuid = new Guid(expenseReportId);

                ExpenseReportReview review =
                    new ExpenseReportReview();
                review.Approved = Approved;
                review.ExpenseReportId = expenseReportGuid;
                review.ReviewedBy = "Big Boss";

                ExpenseReport report =
                    expenseServiceManager.GetExpenseReport(new GetExpenseReportRequest(expenseReportGuid)).Report;

                expenseServiceManager.SubmitReviewedExpenseReport(new SubmitReviewedExpenseReportRequest(report, review));
            }
        }

        private void lstvwExpenseReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvwExpenseReports.SelectedItems.Count == 0)
            {
                return;
            }

            Guid expenseReportId =
                new Guid(lstvwExpenseReports.SelectedItems[0].Text);

            ExpenseReport report =
                expenseServiceManager.GetExpenseReport(new GetExpenseReportRequest(expenseReportId)).Report;

            if (report.Status != ExpenseReportStatus.InReview)
            {
                btnApprove.Enabled = false;
                btnReject.Enabled = false;
            }
            else
            {
                btnApprove.Enabled = true;
                btnReject.Enabled = true;
            }
        }

        /// <summary>
        /// Initializes a connection to the ExpenseReporting host service
        /// </summary>
        /// <returns>An instance implementing the service contract which we can use to interact with the ExpenseReporting host</returns>
        private IExpenseServiceManager CreateChannelExpenseServiceManager()
        {
            ChannelFactory<IExpenseServiceManager> factory =
                new ChannelFactory<IExpenseServiceManager>("ExpenseServiceManager");

            IExpenseServiceManager proxy = factory.CreateChannel();

            return proxy;
        }

        /// <remarks>
        /// Cleans up the ServiceHost instance on completion so that any current
        /// connections are cleanly disconnected.
        /// </remarks>
        private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sh.Close();
        }
    }
}
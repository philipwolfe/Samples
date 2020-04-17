//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;
using System.Threading;

namespace Microsoft.Samples.Workflow.Tutorials.SequentialWorkflow
{
    public class MainForm : Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label approvalState;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Panel panel1;

        private System.ComponentModel.IContainer components = null;

        private WorkflowRuntime workflowRuntime = null;
        private WorkflowInstance workflowInstance = null;

        public MainForm()
        {
            InitializeComponent();

            // Collapse approve/reject panel
            this.Height = this.MinimumSize.Height;

            this.workflowRuntime = new WorkflowRuntime();
            workflowRuntime.StartRuntime();

            workflowRuntime.WorkflowCompleted += new 
                EventHandler<WorkflowCompletedEventArgs>
                (workflowRuntime_WorkflowCompleted);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.approvalState = new System.Windows.Forms.Label();
            this.approveButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.amount = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Amount";
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(13, 70);
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Size = new System.Drawing.Size(162, 20);
            this.result.TabIndex = 1;
            this.result.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Result";
            // 
            // submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(56, 95);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit";
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // approvalState
            // 
            this.approvalState.AutoSize = true;
            this.approvalState.Location = new System.Drawing.Point(10, 9);
            this.approvalState.Name = "approvalState";
            this.approvalState.Size = new System.Drawing.Size(49, 13);
            this.approvalState.TabIndex = 4;
            this.approvalState.Text = "Approval";
            // 
            // approveButton
            // 
            this.approveButton.Enabled = false;
            this.approveButton.Location = new System.Drawing.Point(11, 25);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(75, 23);
            this.approveButton.TabIndex = 0;
            this.approveButton.Text = "Approve";
            this.approveButton.Click += 
                new System.EventHandler(this.approveButton_Click);
            // 
            // rejectButton
            // 
            this.rejectButton.Enabled = false;
            this.rejectButton.Location = new System.Drawing.Point(86, 25);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(75, 23);
            this.rejectButton.TabIndex = 1;
            this.rejectButton.Text = "Reject";
            this.rejectButton.Click += 
                new System.EventHandler(this.rejectButton_Click);
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(13, 29);
            this.amount.MaxLength = 9;
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(162, 20);
            this.amount.TabIndex = 0;
            this.amount.KeyPress += 
                new System.Windows.Forms.KeyPressEventHandler(this.amount_KeyPress);
            this.amount.TextChanged += 
                new System.EventHandler(this.amount_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.approvalState);
            this.panel1.Controls.Add(this.approveButton);
            this.panel1.Controls.Add(this.rejectButton);
            this.panel1.Location = new System.Drawing.Point(7, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 66);
            this.panel1.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AcceptButton = this.submitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 201);
            this.MinimumSize = new System.Drawing.Size(197, 155);
            this.Controls.Add(this.result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Simple Expense Report";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Type type = typeof(ExpenseReportWorkflow);

            // Construct workflow parameters
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("Amount", Int32.Parse(this.amount.Text));

            // Start the workflow
            workflowInstance = workflowRuntime.CreateWorkflow(type, properties);
            workflowInstance.Start();
        }

        void workflowRuntime_WorkflowCompleted(object sender, 
            WorkflowCompletedEventArgs e)
        {
            if (this.result.InvokeRequired)
            {
                this.result.Invoke(new EventHandler<WorkflowCompletedEventArgs>
                    (this.workflowRuntime_WorkflowCompleted), sender, e);
            }
            else
            {
                this.result.Text = e.OutputParameters["Result"].ToString();

                // Clear fields
                this.amount.Text = string.Empty;

                // Disable buttons
                this.approveButton.Enabled = false;
                this.rejectButton.Enabled = false;
            }
        }

        private void approveButton_Click(object sender, EventArgs e)
        {
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && (!Char.IsDigit(e.KeyChar)))
                e.KeyChar = Char.MinValue;            
        }

        private void amount_TextChanged(object sender, EventArgs e)
        {
            submitButton.Enabled = amount.Text.Length > 0;
        }
    }

static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}

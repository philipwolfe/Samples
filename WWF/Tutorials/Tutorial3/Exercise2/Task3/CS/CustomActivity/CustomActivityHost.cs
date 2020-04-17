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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Workflow.Runtime;

namespace Microsoft.Samples.Workflow.Tutorials.CustomActivity
{
    public class MainForm : Form
    {
        private System.Windows.Forms.Label addressCaption;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.TextBox data;
        private System.Windows.Forms.Button goButton;

        private System.ComponentModel.IContainer components = null;

        private WorkflowRuntime workflowRuntime;

        public MainForm()
        {
            InitializeComponent();

            workflowRuntime = new WorkflowRuntime();
            workflowRuntime.StartRuntime();

            workflowRuntime.WorkflowCompleted += 
                new EventHandler<WorkflowCompletedEventArgs>
                (workflowRuntime_WorkflowCompleted);
        }

        private void workflowRuntime_WorkflowCompleted(object sender, 
            WorkflowCompletedEventArgs e)
        {
            // Retrieve the downloaded page data
            if (data.InvokeRequired)
                data.Invoke(new EventHandler<WorkflowCompletedEventArgs>
                    (workflowRuntime_WorkflowCompleted), sender, e);
            else
                data.Text = e.OutputParameters["Data"].ToString();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            Type type = typeof(WebTearWorkflow);
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("Url", address.Text);

            workflowRuntime.CreateWorkflow(type, properties).Start();
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
            this.addressCaption = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.data = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addressCaption
            // 
            this.addressCaption.AutoSize = true;
            this.addressCaption.Location = new System.Drawing.Point(15, 13);
            this.addressCaption.Name = "addressCaption";
            this.addressCaption.Size = new System.Drawing.Size(41, 13);
            this.addressCaption.TabIndex = 0;
            this.addressCaption.Text = "Address";
            // 
            // address
            // 
            this.address.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | 
                System.Windows.Forms.AnchorStyles.Left) | 
                System.Windows.Forms.AnchorStyles.Right)));
            this.address.Location = new System.Drawing.Point(16, 28);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(430, 20);
            this.address.TabIndex = 0;
            this.address.Text = "http://";
            // 
            // data
            // 
            this.data.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top | 
                System.Windows.Forms.AnchorStyles.Bottom) | 
                System.Windows.Forms.AnchorStyles.Left) | 
                System.Windows.Forms.AnchorStyles.Right)));
            this.data.Location = new System.Drawing.Point(15, 55);
            this.data.Multiline = true;
            this.data.Name = "data";
            this.data.ReadOnly = true;
            this.data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.data.Size = new System.Drawing.Size(496, 320);
            this.data.TabIndex = 2;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(462, 25);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(49, 23);
            this.goButton.TabIndex = 1;
            this.goButton.Text = "Go";
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | 
                System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 407);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.data);
            this.Controls.Add(this.address);
            this.Controls.Add(this.addressCaption);
            this.Name = "MainForm";
            this.Text = "Web Tear";
            this.ResumeLayout(false);
            this.PerformLayout();
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

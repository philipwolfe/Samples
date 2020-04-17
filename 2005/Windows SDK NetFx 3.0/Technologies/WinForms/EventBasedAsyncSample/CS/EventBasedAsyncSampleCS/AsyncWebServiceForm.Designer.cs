//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
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
namespace Microsoft.Samples.Windows.Forms.EventBasedAsync
{
    partial class AsyncWebServiceForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsyncWebServiceForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.webServiceOperationToolStripTextProgressPanel = new System.Windows.Forms.ToolStripStatusLabel();
            this.webServiceOperationToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBoxWebServiceCall = new System.Windows.Forms.GroupBox();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.cmbQuestion = new System.Windows.Forms.ComboBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnAskTheQuestion = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtWebServiceUrl = new System.Windows.Forms.TextBox();
            this.groupBoxInstructions = new System.Windows.Forms.GroupBox();
            this.viewWebServiceSourceLinkLabel = new System.Windows.Forms.LinkLabel();
            this.simulateProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.simpleWebService1 = new Microsoft.Samples.Windows.Forms.EventBasedAsync.SimpleWebServices.SimpleWebService();
            this.statusStrip1.SuspendLayout();
            this.groupBoxWebServiceCall.SuspendLayout();
            this.groupBoxInstructions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(350, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.webServiceOperationToolStripTextProgressPanel,
            this.webServiceOperationToolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 267);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(455, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "StatusStrip1";
            // 
            // webServiceOperationToolStripTextProgressPanel
            // 
            this.webServiceOperationToolStripTextProgressPanel.Name = "webServiceOperationToolStripTextProgressPanel";
            this.webServiceOperationToolStripTextProgressPanel.Size = new System.Drawing.Size(38, 17);
            this.webServiceOperationToolStripTextProgressPanel.Text = "Ready";
            // 
            // webServiceOperationToolStripProgressBar
            // 
            this.webServiceOperationToolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.webServiceOperationToolStripProgressBar.Name = "webServiceOperationToolStripProgressBar";
            this.webServiceOperationToolStripProgressBar.Size = new System.Drawing.Size(100, 15);
            this.webServiceOperationToolStripProgressBar.Step = 1;
            this.webServiceOperationToolStripProgressBar.Visible = false;
            // 
            // groupBoxWebServiceCall
            // 
            this.groupBoxWebServiceCall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWebServiceCall.Controls.Add(this.lblAnswer);
            this.groupBoxWebServiceCall.Controls.Add(this.txtAnswer);
            this.groupBoxWebServiceCall.Controls.Add(this.cmbQuestion);
            this.groupBoxWebServiceCall.Controls.Add(this.lblQuestion);
            this.groupBoxWebServiceCall.Controls.Add(this.btnCancel);
            this.groupBoxWebServiceCall.Controls.Add(this.btnAskTheQuestion);
            this.groupBoxWebServiceCall.Controls.Add(this.lblUrl);
            this.groupBoxWebServiceCall.Controls.Add(this.txtWebServiceUrl);
            this.groupBoxWebServiceCall.Location = new System.Drawing.Point(10, 95);
            this.groupBoxWebServiceCall.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.groupBoxWebServiceCall.Name = "groupBoxWebServiceCall";
            this.groupBoxWebServiceCall.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxWebServiceCall.Size = new System.Drawing.Size(435, 160);
            this.groupBoxWebServiceCall.TabIndex = 0;
            this.groupBoxWebServiceCall.TabStop = false;
            this.groupBoxWebServiceCall.Text = "Web Service";
            // 
            // lblAnswer
            // 
            this.lblAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Location = new System.Drawing.Point(7, 107);
            this.lblAnswer.Margin = new System.Windows.Forms.Padding(2, 3, 1, 3);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(45, 13);
            this.lblAnswer.TabIndex = 14;
            this.lblAnswer.Text = "Answer:";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnswer.Location = new System.Drawing.Point(60, 104);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.ReadOnly = true;
            this.txtAnswer.Size = new System.Drawing.Size(365, 20);
            this.txtAnswer.TabIndex = 3;
            // 
            // cmbQuestion
            // 
            this.cmbQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion.FormattingEnabled = true;
            this.cmbQuestion.Items.AddRange(new object[] {
            "What is the answer?",
            "Who am I?",
            "What am I doing here?",
            "Is it better to ask for too much?"});
            this.cmbQuestion.Location = new System.Drawing.Point(61, 46);
            this.cmbQuestion.Margin = new System.Windows.Forms.Padding(0, 2, 3, 3);
            this.cmbQuestion.Name = "cmbQuestion";
            this.cmbQuestion.Size = new System.Drawing.Size(364, 21);
            this.cmbQuestion.TabIndex = 1;
            // 
            // lblQuestion
            // 
            this.lblQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(7, 49);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(2, 3, 1, 3);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(52, 13);
            this.lblQuestion.TabIndex = 11;
            this.lblQuestion.Text = "Question:";
            // 
            // btnAskTheQuestion
            // 
            this.btnAskTheQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAskTheQuestion.Location = new System.Drawing.Point(295, 74);
            this.btnAskTheQuestion.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.btnAskTheQuestion.Name = "btnAskTheQuestion";
            this.btnAskTheQuestion.Size = new System.Drawing.Size(130, 23);
            this.btnAskTheQuestion.TabIndex = 2;
            this.btnAskTheQuestion.Text = "&Ask the Question";
            this.btnAskTheQuestion.Click += new System.EventHandler(this.btnAskTheQuestion_Click);
            // 
            // lblUrl
            // 
            this.lblUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(7, 25);
            this.lblUrl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(23, 13);
            this.lblUrl.TabIndex = 3;
            this.lblUrl.Text = "Url:";
            // 
            // txtWebServiceUrl
            // 
            this.txtWebServiceUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebServiceUrl.Location = new System.Drawing.Point(61, 22);
            this.txtWebServiceUrl.Margin = new System.Windows.Forms.Padding(2, 2, 3, 2);
            this.txtWebServiceUrl.Name = "txtWebServiceUrl";
            this.txtWebServiceUrl.Size = new System.Drawing.Size(364, 20);
            this.txtWebServiceUrl.TabIndex = 0;
            this.txtWebServiceUrl.Text = "http://localhost/samplewebservices/simplewebservice.asmx";
            // 
            // groupBoxInstructions
            // 
            this.groupBoxInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInstructions.Controls.Add(this.viewWebServiceSourceLinkLabel);
            this.groupBoxInstructions.Location = new System.Drawing.Point(8, 13);
            this.groupBoxInstructions.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.groupBoxInstructions.Name = "groupBoxInstructions";
            this.groupBoxInstructions.Padding = new System.Windows.Forms.Padding(9);
            this.groupBoxInstructions.Size = new System.Drawing.Size(437, 76);
            this.groupBoxInstructions.TabIndex = 2;
            this.groupBoxInstructions.TabStop = false;
            this.groupBoxInstructions.Text = "Instructions";
            // 
            // viewWebServiceSourceLinkLabel
            // 
            this.viewWebServiceSourceLinkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewWebServiceSourceLinkLabel.Location = new System.Drawing.Point(9, 22);
            this.viewWebServiceSourceLinkLabel.Name = "viewWebServiceSourceLinkLabel";
            this.viewWebServiceSourceLinkLabel.Size = new System.Drawing.Size(419, 45);
            this.viewWebServiceSourceLinkLabel.TabIndex = 1;
            this.viewWebServiceSourceLinkLabel.TabStop = true;
            this.viewWebServiceSourceLinkLabel.Text = resources.GetString("viewWebServiceSourceLinkLabel.Text");
            this.viewWebServiceSourceLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ViewWebServiceSourceLinkLabel_LinkClicked);
            // 
            // simulateProgressTimer
            // 
            this.simulateProgressTimer.Interval = 120;
            this.simulateProgressTimer.Tick += new System.EventHandler(this.SimulateProgressTimer_Tick);
            // 
            // simpleWebService1
            // 
            this.simpleWebService1.Credentials = null;
            this.simpleWebService1.Url = "http://localhost/samplewebservices/SimpleWebService.asmx";
            this.simpleWebService1.UseDefaultCredentials = false;
            this.simpleWebService1.GetAnswerCompleted += new Microsoft.Samples.Windows.Forms.EventBasedAsync.SimpleWebServices.GetAnswerCompletedEventHandler(this.simpleWebService1_GetAnswerCompleted);
            // 
            // AsyncWebServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 289);
            this.Controls.Add(this.groupBoxInstructions);
            this.Controls.Add(this.groupBoxWebServiceCall);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(463, 301);
            this.Name = "AsyncWebServiceForm";
            this.Text = "Async WebService Sample";
            this.Load += new System.EventHandler(this.AsyncWebServiceForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxWebServiceCall.ResumeLayout(false);
            this.groupBoxWebServiceCall.PerformLayout();
            this.groupBoxInstructions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar webServiceOperationToolStripProgressBar;
        private System.Windows.Forms.GroupBox groupBoxWebServiceCall;
        private System.Windows.Forms.Button btnAskTheQuestion;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtWebServiceUrl;
        private System.Windows.Forms.GroupBox groupBoxInstructions;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.ToolStripStatusLabel webServiceOperationToolStripTextProgressPanel;
        private System.Windows.Forms.ComboBox cmbQuestion;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Timer simulateProgressTimer;
        private Microsoft.Samples.Windows.Forms.EventBasedAsync.SimpleWebServices.SimpleWebService simpleWebService1;
        private System.Windows.Forms.LinkLabel viewWebServiceSourceLinkLabel;

    }
}







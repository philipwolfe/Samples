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

    partial class AsyncWebClientForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsyncWebClientForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.webClientOperationToolStripTextProgressPanel = new System.Windows.Forms.ToolStripStatusLabel();
            this.webClientOperationToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBoxFileDownload = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtToLocation = new System.Windows.Forms.TextBox();
            this.btnDownloadFile = new System.Windows.Forms.Button();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtFromLocation = new System.Windows.Forms.TextBox();
            this.groupBoxInstructions = new System.Windows.Forms.GroupBox();
            this.instructionsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.groupBoxFileDownload.SuspendLayout();
            this.groupBoxInstructions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(128, 73);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.webClientOperationToolStripTextProgressPanel,
            this.webClientOperationToolStripProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 213);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(443, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "StatusStrip1";
            // 
            // webClientOperationToolStripTextProgressPanel
            // 
            this.webClientOperationToolStripTextProgressPanel.Name = "webClientOperationToolStripTextProgressPanel";
            this.webClientOperationToolStripTextProgressPanel.Size = new System.Drawing.Size(0, 17);
            // 
            // webClientOperationToolStripProgressBar
            // 
            this.webClientOperationToolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.webClientOperationToolStripProgressBar.Name = "webClientOperationToolStripProgressBar";
            this.webClientOperationToolStripProgressBar.Size = new System.Drawing.Size(100, 15);
            this.webClientOperationToolStripProgressBar.Step = 1;
            // 
            // groupBoxFileDownload
            // 
            this.groupBoxFileDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFileDownload.Controls.Add(this.btnBrowse);
            this.groupBoxFileDownload.Controls.Add(this.lblTo);
            this.groupBoxFileDownload.Controls.Add(this.btnCancel);
            this.groupBoxFileDownload.Controls.Add(this.txtToLocation);
            this.groupBoxFileDownload.Controls.Add(this.btnDownloadFile);
            this.groupBoxFileDownload.Controls.Add(this.lblFrom);
            this.groupBoxFileDownload.Controls.Add(this.txtFromLocation);
            this.groupBoxFileDownload.Location = new System.Drawing.Point(10, 100);
            this.groupBoxFileDownload.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.groupBoxFileDownload.Name = "groupBoxFileDownload";
            this.groupBoxFileDownload.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxFileDownload.Size = new System.Drawing.Size(418, 104);
            this.groupBoxFileDownload.TabIndex = 0;
            this.groupBoxFileDownload.TabStop = false;
            this.groupBoxFileDownload.Text = "File download";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(335, 46);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "&Browse . . .";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(7, 51);
            this.lblTo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 11;
            this.lblTo.Text = "To:";
            // 
            // txtToLocation
            // 
            this.txtToLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToLocation.Location = new System.Drawing.Point(45, 48);
            this.txtToLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.txtToLocation.Name = "txtToLocation";
            this.txtToLocation.Size = new System.Drawing.Size(284, 20);
            this.txtToLocation.TabIndex = 1;
            this.txtToLocation.Text = "bigdownload.txt";
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Location = new System.Drawing.Point(45, 73);
            this.btnDownloadFile.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(76, 23);
            this.btnDownloadFile.TabIndex = 3;
            this.btnDownloadFile.Text = "&Download";
            this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(7, 25);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 3;
            this.lblFrom.Text = "From:";
            // 
            // txtFromLocation
            // 
            this.txtFromLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromLocation.Location = new System.Drawing.Point(45, 22);
            this.txtFromLocation.Margin = new System.Windows.Forms.Padding(2, 2, 3, 3);
            this.txtFromLocation.Name = "txtFromLocation";
            this.txtFromLocation.Size = new System.Drawing.Size(284, 20);
            this.txtFromLocation.TabIndex = 0;
            this.txtFromLocation.Text = "http://localhost/big.txt";
            // 
            // groupBoxInstructions
            // 
            this.groupBoxInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInstructions.Controls.Add(this.instructionsLinkLabel);
            this.groupBoxInstructions.Location = new System.Drawing.Point(8, 13);
            this.groupBoxInstructions.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.groupBoxInstructions.Name = "groupBoxInstructions";
            this.groupBoxInstructions.Padding = new System.Windows.Forms.Padding(9);
            this.groupBoxInstructions.Size = new System.Drawing.Size(425, 75);
            this.groupBoxInstructions.TabIndex = 1;
            this.groupBoxInstructions.TabStop = false;
            this.groupBoxInstructions.Text = "Instructions";
            // 
            // instructionsLinkLabel
            // 
            this.instructionsLinkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instructionsLinkLabel.Location = new System.Drawing.Point(9, 22);
            this.instructionsLinkLabel.Name = "instructionsLinkLabel";
            this.instructionsLinkLabel.Size = new System.Drawing.Size(407, 44);
            this.instructionsLinkLabel.TabIndex = 6;
            this.instructionsLinkLabel.TabStop = true;
            this.instructionsLinkLabel.Text = resources.GetString("instructionsLinkLabel.Text");
            this.instructionsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.InstructionsLinkLabel_LinkClicked);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.AddExtension = false;
            // 
            // AsyncWebClientForm
            // 
            this.AcceptButton = this.btnDownloadFile;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(443, 235);
            this.Controls.Add(this.groupBoxInstructions);
            this.Controls.Add(this.groupBoxFileDownload);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(451, 269);
            this.Name = "AsyncWebClientForm";
            this.Text = "Async Web Client Sample";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxFileDownload.ResumeLayout(false);
            this.groupBoxFileDownload.PerformLayout();
            this.groupBoxInstructions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar webClientOperationToolStripProgressBar;
        private System.Windows.Forms.GroupBox groupBoxFileDownload;
        private System.Windows.Forms.Button btnDownloadFile;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtFromLocation;
        private System.Windows.Forms.GroupBox groupBoxInstructions;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtToLocation;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.LinkLabel instructionsLinkLabel;
        private System.Windows.Forms.ToolStripStatusLabel webClientOperationToolStripTextProgressPanel;
    }
}



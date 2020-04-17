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

    partial class MainForm {

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
            this.btnAsyncPictureBoxSample = new System.Windows.Forms.Button();
            this.btnAsyncWebClientSample = new System.Windows.Forms.Button();
            this.btnAsyncWebServiceSample = new System.Windows.Forms.Button();
            this.btnBackgroundWorkerSample = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAsyncPictureBoxSample
            // 
            this.btnAsyncPictureBoxSample.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAsyncPictureBoxSample.Location = new System.Drawing.Point(3, 17);
            this.btnAsyncPictureBoxSample.Name = "btnAsyncPictureBoxSample";
            this.btnAsyncPictureBoxSample.Size = new System.Drawing.Size(188, 26);
            this.btnAsyncPictureBoxSample.TabIndex = 0;
            this.btnAsyncPictureBoxSample.Text = "Async &PictureBox sample";
            this.btnAsyncPictureBoxSample.Click += new System.EventHandler(this.btnAsyncPictureBoxSample_Click);
            // 
            // btnAsyncWebClientSample
            // 
            this.btnAsyncWebClientSample.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAsyncWebClientSample.Location = new System.Drawing.Point(3, 77);
            this.btnAsyncWebClientSample.Name = "btnAsyncWebClientSample";
            this.btnAsyncWebClientSample.Size = new System.Drawing.Size(188, 26);
            this.btnAsyncWebClientSample.TabIndex = 1;
            this.btnAsyncWebClientSample.Text = "Async Web &Client sample";
            this.btnAsyncWebClientSample.Click += new System.EventHandler(this.btnAsyncWebClientSample_Click);
            // 
            // btnAsyncWebServiceSample
            // 
            this.btnAsyncWebServiceSample.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAsyncWebServiceSample.Location = new System.Drawing.Point(3, 137);
            this.btnAsyncWebServiceSample.Name = "btnAsyncWebServiceSample";
            this.btnAsyncWebServiceSample.Size = new System.Drawing.Size(188, 26);
            this.btnAsyncWebServiceSample.TabIndex = 2;
            this.btnAsyncWebServiceSample.Text = "Async Web &Service sample";
            this.btnAsyncWebServiceSample.Click += new System.EventHandler(this.btnAsyncWebServiceSample_Click);
            // 
            // btnBackgroundWorkerSample
            // 
            this.btnBackgroundWorkerSample.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBackgroundWorkerSample.Location = new System.Drawing.Point(3, 197);
            this.btnBackgroundWorkerSample.Name = "btnBackgroundWorkerSample";
            this.btnBackgroundWorkerSample.Size = new System.Drawing.Size(188, 26);
            this.btnBackgroundWorkerSample.TabIndex = 3;
            this.btnBackgroundWorkerSample.Text = "&BackgroundWorker sample";
            this.btnBackgroundWorkerSample.Click += new System.EventHandler(this.btnBackgroundWorkerSample_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAsyncPictureBoxSample, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBackgroundWorkerSample, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAsyncWebClientSample, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAsyncWebServiceSample, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(422, 251);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 39);
            this.label4.TabIndex = 7;
            this.label4.Text = "This sample demonstrates how to use the BackgroundWorker component to execute a l" +
                "ong running task in the background.";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "This sample demonstrates how to asynchronously call a Web Service.";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "This sample demonstrates how to asynchronously retrieve a large file from a Web S" +
                "erver using the WebClient component.";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "This sample demonstrates how to asynchronously load an image into a PictureBox co" +
                "ntrol.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 271);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(450, 298);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Event Based Async Samples";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.Button btnAsyncPictureBoxSample;
        private System.Windows.Forms.Button btnAsyncWebClientSample;
        private System.Windows.Forms.Button btnAsyncWebServiceSample;
		private System.Windows.Forms.Button btnBackgroundWorkerSample;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
    }
}


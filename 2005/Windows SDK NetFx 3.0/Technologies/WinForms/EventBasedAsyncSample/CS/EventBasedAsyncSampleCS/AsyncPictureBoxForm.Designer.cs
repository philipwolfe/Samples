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
    partial class AsyncPictureBoxForm {
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
            this.bigImagePictureBox = new System.Windows.Forms.PictureBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.imageLoadProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnLoad = new System.Windows.Forms.Button();
            this.groupBoxInstructions = new System.Windows.Forms.GroupBox();
            this.instructionsLinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bigImagePictureBox)).BeginInit();
            this.groupBoxInstructions.SuspendLayout();
            this.SuspendLayout();
            // 
            // bigImagePictureBox
            // 
            this.bigImagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bigImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bigImagePictureBox.Location = new System.Drawing.Point(11, 119);
            this.bigImagePictureBox.Margin = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.bigImagePictureBox.Name = "bigImagePictureBox";
            this.bigImagePictureBox.Size = new System.Drawing.Size(421, 160);
            this.bigImagePictureBox.TabIndex = 0;
            this.bigImagePictureBox.TabStop = false;
            this.bigImagePictureBox.LoadProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BigImagePictureBox_LoadProgressChanged);
            this.bigImagePictureBox.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.BigImagePictureBox_LoadCompleted);
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Location = new System.Drawing.Point(101, 91);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(165, 20);
            this.txtLocation.TabIndex = 0;
            this.txtLocation.Text = "big.bmp";
            this.txtLocation.TextChanged += new System.EventHandler(this.txtLocation_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(358, 89);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(11, 94);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(86, 13);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Bitmap Location:";
            // 
            // imageLoadProgressBar
            // 
            this.imageLoadProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageLoadProgressBar.Location = new System.Drawing.Point(11, 285);
            this.imageLoadProgressBar.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.imageLoadProgressBar.Name = "imageLoadProgressBar";
            this.imageLoadProgressBar.Size = new System.Drawing.Size(422, 23);
            this.imageLoadProgressBar.Step = 1;
            this.imageLoadProgressBar.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(276, 89);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "&Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // groupBoxInstructions
            // 
            this.groupBoxInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInstructions.Controls.Add(this.instructionsLinkLabel);
            this.groupBoxInstructions.Location = new System.Drawing.Point(8, 11);
            this.groupBoxInstructions.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.groupBoxInstructions.Name = "groupBoxInstructions";
            this.groupBoxInstructions.Padding = new System.Windows.Forms.Padding(9);
            this.groupBoxInstructions.Size = new System.Drawing.Size(425, 72);
            this.groupBoxInstructions.TabIndex = 5;
            this.groupBoxInstructions.TabStop = false;
            this.groupBoxInstructions.Text = "Instructions";
            // 
            // instructionsLinkLabel
            // 
            this.instructionsLinkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instructionsLinkLabel.Location = new System.Drawing.Point(9, 22);
            this.instructionsLinkLabel.Name = "instructionsLinkLabel";
            this.instructionsLinkLabel.Size = new System.Drawing.Size(407, 41);
            this.instructionsLinkLabel.TabIndex = 0;
            this.instructionsLinkLabel.TabStop = true;
            this.instructionsLinkLabel.Text = "For this sample to demo correctly you need to load a large bitmap into the Pictur" +
                "eBox. Click here to generate a large bitmap called \"big.bmp\" in the same locatio" +
                "n as the sample exe.";
            this.instructionsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.InstructionsLinkLabel_LinkClicked);
            // 
            // AsyncPictureBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 316);
            this.Controls.Add(this.groupBoxInstructions);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.imageLoadProgressBar);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.bigImagePictureBox);
            this.MinimumSize = new System.Drawing.Size(451, 350);
            this.Name = "AsyncPictureBoxForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Async PictureBox Sample";
            ((System.ComponentModel.ISupportInitialize)(this.bigImagePictureBox)).EndInit();
            this.groupBoxInstructions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.PictureBox bigImagePictureBox;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ProgressBar imageLoadProgressBar;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.GroupBox groupBoxInstructions;
        private System.Windows.Forms.LinkLabel instructionsLinkLabel;
    }
}


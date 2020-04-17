//--------------------------------------------------------------------------------
// This file is a Windows Workflow Foundation "Sample" built by
// Customer Support & Services
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

namespace NumberGuessFormHost
{
	partial class HostForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboInstanceId = new System.Windows.Forms.ComboBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuess = new System.Windows.Forms.Button();
            this.txtGuess = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRange = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(133, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Begin Game";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboInstanceId);
            this.groupBox1.Controls.Add(this.btnQuit);
            this.groupBox1.Controls.Add(this.txtMsg);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnGuess);
            this.groupBox1.Controls.Add(this.txtGuess);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 236);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game";
            // 
            // cboInstanceId
            // 
            this.cboInstanceId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInstanceId.FormattingEnabled = true;
            this.cboInstanceId.Location = new System.Drawing.Point(118, 13);
            this.cboInstanceId.Name = "cboInstanceId";
            this.cboInstanceId.Size = new System.Drawing.Size(254, 21);
            this.cboInstanceId.TabIndex = 7;
            this.cboInstanceId.SelectedIndexChanged += new System.EventHandler(this.cboInstanceId_SelectedIndexChanged);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(297, 52);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "Quit Game";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(6, 81);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(367, 149);
            this.txtMsg.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Workflow InstanceId";
            // 
            // btnGuess
            // 
            this.btnGuess.Location = new System.Drawing.Point(118, 52);
            this.btnGuess.Name = "btnGuess";
            this.btnGuess.Size = new System.Drawing.Size(75, 23);
            this.btnGuess.TabIndex = 2;
            this.btnGuess.Text = "Go";
            this.btnGuess.UseVisualStyleBackColor = true;
            this.btnGuess.Click += new System.EventHandler(this.btnGuess_Click);
            // 
            // txtGuess
            // 
            this.txtGuess.Location = new System.Drawing.Point(6, 52);
            this.txtGuess.Name = "txtGuess";
            this.txtGuess.Size = new System.Drawing.Size(103, 20);
            this.txtGuess.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter a guess";
            // 
            // cboRange
            // 
            this.cboRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRange.FormattingEnabled = true;
            this.cboRange.Items.AddRange(new object[] {
            "10",
            "100",
            "1000"});
            this.cboRange.Location = new System.Drawing.Point(287, 12);
            this.cboRange.Name = "cboRange";
            this.cboRange.Size = new System.Drawing.Size(98, 21);
            this.cboRange.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Guess a number from 1 to";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 283);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(236, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Create Xaml Activated Sequential Workflows";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 302);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(181, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "Create State Machine Workflows";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // HostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 331);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboRange);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNew);
            this.MaximizeBox = false;
            this.Name = "HostForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGuess;
        private System.Windows.Forms.TextBox txtGuess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.ComboBox cboInstanceId;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
	}
}
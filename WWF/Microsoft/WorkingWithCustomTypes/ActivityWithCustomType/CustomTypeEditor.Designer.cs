//--------------------------------------------------------------------------------
// This file is part of the Windows Workflow Foundation Sample Code
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

namespace CustomTypeSerialization.ActivityWithCustomType
{
	partial class CustomTypeEditor
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblParamOne = new System.Windows.Forms.Label();
            this.lblParamTwo = new System.Windows.Forms.Label();
            this.txtParamOne = new System.Windows.Forms.TextBox();
            this.txtParamTwo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(16, 128);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(111, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(13, 13);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(173, 45);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "This dialog will create a new MyType.  Enter the value for ParamOne and ParamTwo." +
                "";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblParamOne
            // 
            this.lblParamOne.AutoSize = true;
            this.lblParamOne.Location = new System.Drawing.Point(13, 69);
            this.lblParamOne.Name = "lblParamOne";
            this.lblParamOne.Size = new System.Drawing.Size(57, 13);
            this.lblParamOne.TabIndex = 3;
            this.lblParamOne.Text = "ParamOne";
            // 
            // lblParamTwo
            // 
            this.lblParamTwo.AutoSize = true;
            this.lblParamTwo.Location = new System.Drawing.Point(13, 95);
            this.lblParamTwo.Name = "lblParamTwo";
            this.lblParamTwo.Size = new System.Drawing.Size(58, 13);
            this.lblParamTwo.TabIndex = 4;
            this.lblParamTwo.Text = "ParamTwo";
            // 
            // txtParamOne
            // 
            this.txtParamOne.Location = new System.Drawing.Point(86, 66);
            this.txtParamOne.Name = "txtParamOne";
            this.txtParamOne.Size = new System.Drawing.Size(100, 20);
            this.txtParamOne.TabIndex = 5;
            // 
            // txtParamTwo
            // 
            this.txtParamTwo.Location = new System.Drawing.Point(86, 92);
            this.txtParamTwo.Name = "txtParamTwo";
            this.txtParamTwo.Size = new System.Drawing.Size(100, 20);
            this.txtParamTwo.TabIndex = 6;
            // 
            // MyTypeEditor
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(208, 165);
            this.ControlBox = false;
            this.Controls.Add(this.txtParamTwo);
            this.Controls.Add(this.txtParamOne);
            this.Controls.Add(this.lblParamTwo);
            this.Controls.Add(this.lblParamOne);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MyTypeEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MyType Editor Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblParamOne;
        private System.Windows.Forms.Label lblParamTwo;
        internal System.Windows.Forms.TextBox txtParamOne;
        internal System.Windows.Forms.TextBox txtParamTwo;
	}
}
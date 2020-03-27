namespace Transactions
{
	partial class Form1
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
			this.button1 = new System.Windows.Forms.Button();
			this.transDetails = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.IsTransactionSuccess = new System.Windows.Forms.CheckBox();
			this.ClearDetails = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(110, 305);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(84, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Start";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// transDetails
			// 
			this.transDetails.Location = new System.Drawing.Point(12, 27);
			this.transDetails.Multiline = true;
			this.transDetails.Name = "transDetails";
			this.transDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.transDetails.Size = new System.Drawing.Size(370, 242);
			this.transDetails.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(150, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Transaction Details";
			// 
			// IsTransactionSuccess
			// 
			this.IsTransactionSuccess.AutoSize = true;
			this.IsTransactionSuccess.Checked = true;
			this.IsTransactionSuccess.CheckState = System.Windows.Forms.CheckState.Checked;
			this.IsTransactionSuccess.Location = new System.Drawing.Point(12, 275);
			this.IsTransactionSuccess.Name = "IsTransactionSuccess";
			this.IsTransactionSuccess.Size = new System.Drawing.Size(227, 17);
			this.IsTransactionSuccess.TabIndex = 3;
			this.IsTransactionSuccess.Text = "Allow Transaction  to complete successfully";
			// 
			// ClearDetails
			// 
			this.ClearDetails.Location = new System.Drawing.Point(200, 305);
			this.ClearDetails.Name = "ClearDetails";
			this.ClearDetails.Size = new System.Drawing.Size(84, 23);
			this.ClearDetails.TabIndex = 4;
			this.ClearDetails.Text = "Clear Details";
			this.ClearDetails.Click += new System.EventHandler(this.ClearDetails_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 342);
			this.Controls.Add(this.ClearDetails);
			this.Controls.Add(this.IsTransactionSuccess);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.transDetails);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Transaction Sample";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox transDetails;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox IsTransactionSuccess;
		private System.Windows.Forms.Button ClearDetails;
	}
}


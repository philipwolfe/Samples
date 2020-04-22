namespace EventViewer
{
	partial class MessageViewer
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
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.labelComputer = new System.Windows.Forms.Label();
			this.labelSource = new System.Windows.Forms.Label();
			this.labelType = new System.Windows.Forms.Label();
			this.labelDate = new System.Windows.Forms.Label();
			this.textBoxMessage = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Date:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(196, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Source:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Type:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(196, 20);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "Computer::";
			// 
			// labelComputer
			// 
			this.labelComputer.AutoSize = true;
			this.labelComputer.Location = new System.Drawing.Point(270, 20);
			this.labelComputer.Name = "labelComputer";
			this.labelComputer.Size = new System.Drawing.Size(58, 13);
			this.labelComputer.TabIndex = 11;
			this.labelComputer.Text = "Computer::";
			// 
			// labelSource
			// 
			this.labelSource.AutoSize = true;
			this.labelSource.Location = new System.Drawing.Point(270, 3);
			this.labelSource.Name = "labelSource";
			this.labelSource.Size = new System.Drawing.Size(44, 13);
			this.labelSource.TabIndex = 8;
			this.labelSource.Text = "Source:";
			// 
			// labelType
			// 
			this.labelType.AutoSize = true;
			this.labelType.Location = new System.Drawing.Point(52, 20);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(34, 13);
			this.labelType.TabIndex = 14;
			this.labelType.Text = "Type:";
			// 
			// labelDate
			// 
			this.labelDate.AutoSize = true;
			this.labelDate.Location = new System.Drawing.Point(52, 3);
			this.labelDate.Name = "labelDate";
			this.labelDate.Size = new System.Drawing.Size(33, 13);
			this.labelDate.TabIndex = 12;
			this.labelDate.Text = "Date:";
			// 
			// textBoxMessage
			// 
			this.textBoxMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.textBoxMessage.Location = new System.Drawing.Point(0, 34);
			this.textBoxMessage.MaxLength = 8192;
			this.textBoxMessage.Multiline = true;
			this.textBoxMessage.Name = "textBoxMessage";
			this.textBoxMessage.ReadOnly = true;
			this.textBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxMessage.Size = new System.Drawing.Size(373, 134);
			this.textBoxMessage.TabIndex = 16;
			// 
			// MessageViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(373, 168);
			this.Controls.Add(this.textBoxMessage);
			this.Controls.Add(this.labelType);
			this.Controls.Add(this.labelDate);
			this.Controls.Add(this.labelComputer);
			this.Controls.Add(this.labelSource);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Name = "MessageViewer";
			this.Text = "MessageViewer";
			this.Load += new System.EventHandler(this.MessageViewer_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label labelComputer;
		private System.Windows.Forms.Label labelSource;
		private System.Windows.Forms.Label labelType;
		private System.Windows.Forms.Label labelDate;
		private System.Windows.Forms.TextBox textBoxMessage;
	}
}
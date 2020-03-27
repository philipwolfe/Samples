namespace DriveInfoSample
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
			this.drivesOnPc = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.driveReadyStatus = new System.Windows.Forms.Label();
			this.driveName = new System.Windows.Forms.TextBox();
			this.driveVolumeLabel = new System.Windows.Forms.TextBox();
			this.driveFormat = new System.Windows.Forms.TextBox();
			this.driveType = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.driveRootDirectory = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// drivesOnPc
			// 
			this.drivesOnPc.FormattingEnabled = true;
			this.drivesOnPc.Location = new System.Drawing.Point(106, 6);
			this.drivesOnPc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.drivesOnPc.Name = "drivesOnPc";
			this.drivesOnPc.Size = new System.Drawing.Size(47, 24);
			this.drivesOnPc.TabIndex = 0;
			this.drivesOnPc.SelectedIndexChanged += new System.EventHandler(this.drivesOnPc_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 121);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "File System:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(63, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Type:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(86, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "Volume Label:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(58, 209);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Name:";
			// 
			// driveReadyStatus
			// 
			this.driveReadyStatus.AutoSize = true;
			this.driveReadyStatus.Location = new System.Drawing.Point(159, 9);
			this.driveReadyStatus.Name = "driveReadyStatus";
			this.driveReadyStatus.Size = new System.Drawing.Size(62, 16);
			this.driveReadyStatus.TabIndex = 7;
			this.driveReadyStatus.Text = "Not Ready";
			// 
			// driveName
			// 
			this.driveName.Enabled = false;
			this.driveName.Location = new System.Drawing.Point(105, 206);
			this.driveName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.driveName.Name = "driveName";
			this.driveName.Size = new System.Drawing.Size(116, 23);
			this.driveName.TabIndex = 8;
			// 
			// driveVolumeLabel
			// 
			this.driveVolumeLabel.Enabled = false;
			this.driveVolumeLabel.Location = new System.Drawing.Point(106, 42);
			this.driveVolumeLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.driveVolumeLabel.Name = "driveVolumeLabel";
			this.driveVolumeLabel.Size = new System.Drawing.Size(116, 23);
			this.driveVolumeLabel.TabIndex = 9;
			// 
			// driveFormat
			// 
			this.driveFormat.Enabled = false;
			this.driveFormat.Location = new System.Drawing.Point(106, 118);
			this.driveFormat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.driveFormat.Name = "driveFormat";
			this.driveFormat.Size = new System.Drawing.Size(116, 23);
			this.driveFormat.TabIndex = 10;
			// 
			// driveType
			// 
			this.driveType.Enabled = false;
			this.driveType.Location = new System.Drawing.Point(106, 77);
			this.driveType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.driveType.Name = "driveType";
			this.driveType.Size = new System.Drawing.Size(81, 23);
			this.driveType.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 164);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(90, 16);
			this.label6.TabIndex = 12;
			this.label6.Text = "Root Directory:";
			// 
			// driveRootDirectory
			// 
			this.driveRootDirectory.Enabled = false;
			this.driveRootDirectory.Location = new System.Drawing.Point(105, 161);
			this.driveRootDirectory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.driveRootDirectory.Name = "driveRootDirectory";
			this.driveRootDirectory.Size = new System.Drawing.Size(116, 23);
			this.driveRootDirectory.TabIndex = 13;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(12, 9);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 16);
			this.label10.TabIndex = 22;
			this.label10.Text = "Select a Drive:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(672, 346);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.driveRootDirectory);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.driveType);
			this.Controls.Add(this.driveFormat);
			this.Controls.Add(this.driveVolumeLabel);
			this.Controls.Add(this.driveName);
			this.Controls.Add(this.driveReadyStatus);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.drivesOnPc);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DriveInfo Sample";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox drivesOnPc;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label driveReadyStatus;
		private System.Windows.Forms.TextBox driveName;
		private System.Windows.Forms.TextBox driveVolumeLabel;
		private System.Windows.Forms.TextBox driveFormat;
		private System.Windows.Forms.TextBox driveType;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox driveRootDirectory;
		private System.Windows.Forms.Label label10;
	}
}


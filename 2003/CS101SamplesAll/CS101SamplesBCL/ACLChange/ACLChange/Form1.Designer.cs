namespace ACLChange
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
            this.BrowseFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RemoveRule = new System.Windows.Forms.Button();
            this.ACEDetails = new System.Windows.Forms.TreeView();
            this.AddRule = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.FileSystemRightsSelection = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AccessControlTypeSelection = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BrowseFile
            // 
            this.BrowseFile.Location = new System.Drawing.Point(309, 49);
            this.BrowseFile.Name = "BrowseFile";
            this.BrowseFile.Size = new System.Drawing.Size(75, 23);
            this.BrowseFile.TabIndex = 0;
            this.BrowseFile.Text = "Browse";
            this.BrowseFile.Click += new System.EventHandler(this.BrowseFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Name:";
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(71, 23);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(313, 20);
            this.fileName.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RemoveRule);
            this.groupBox1.Controls.Add(this.ACEDetails);
            this.groupBox1.Controls.Add(this.BrowseFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fileName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 331);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Access Security";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Access Rules:";
            // 
            // RemoveRule
            // 
            this.RemoveRule.Location = new System.Drawing.Point(138, 296);
            this.RemoveRule.Name = "RemoveRule";
            this.RemoveRule.Size = new System.Drawing.Size(108, 23);
            this.RemoveRule.TabIndex = 13;
            this.RemoveRule.Text = "Remove Rule";
            this.RemoveRule.Click += new System.EventHandler(this.RemoveRule_Click);
            // 
            // ACEDetails
            // 
            this.ACEDetails.Location = new System.Drawing.Point(13, 91);
            this.ACEDetails.Name = "ACEDetails";
            this.ACEDetails.Size = new System.Drawing.Size(371, 191);
            this.ACEDetails.TabIndex = 5;
            // 
            // AddRule
            // 
            this.AddRule.Location = new System.Drawing.Point(286, 17);
            this.AddRule.Name = "AddRule";
            this.AddRule.Size = new System.Drawing.Size(108, 23);
            this.AddRule.TabIndex = 12;
            this.AddRule.Text = "Add Rule";
            this.AddRule.Click += new System.EventHandler(this.AddRule_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "User Name:";
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(76, 19);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(193, 20);
            this.UserName.TabIndex = 15;
            // 
            // FileSystemRightsSelection
            // 
            this.FileSystemRightsSelection.FormattingEnabled = true;
            this.FileSystemRightsSelection.Location = new System.Drawing.Point(76, 45);
            this.FileSystemRightsSelection.Name = "FileSystemRightsSelection";
            this.FileSystemRightsSelection.Size = new System.Drawing.Size(121, 21);
            this.FileSystemRightsSelection.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Rights:";
            // 
            // AccessControlTypeSelection
            // 
            this.AccessControlTypeSelection.FormattingEnabled = true;
            this.AccessControlTypeSelection.Location = new System.Drawing.Point(76, 72);
            this.AccessControlTypeSelection.Name = "AccessControlTypeSelection";
            this.AccessControlTypeSelection.Size = new System.Drawing.Size(93, 21);
            this.AccessControlTypeSelection.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Type:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AddRule);
            this.groupBox2.Controls.Add(this.UserName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.AccessControlTypeSelection);
            this.groupBox2.Controls.Add(this.FileSystemRightsSelection);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 349);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 106);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Access Rule";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 468);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACL Sample";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button BrowseFile;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox fileName;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button AddRule;
		private System.Windows.Forms.Button RemoveRule;
		private System.Windows.Forms.ComboBox FileSystemRightsSelection;
		private System.Windows.Forms.TextBox UserName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox AccessControlTypeSelection;
		private System.Windows.Forms.TreeView ACEDetails;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
	}
}


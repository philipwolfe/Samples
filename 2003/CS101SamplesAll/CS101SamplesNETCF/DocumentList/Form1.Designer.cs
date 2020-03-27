namespace DocumentList
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
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.FilterComboBox = new System.Windows.Forms.ComboBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.FileContentsTextBox = new System.Windows.Forms.TextBox();
            this.ActionStatusBar = new System.Windows.Forms.StatusBar();
            this.FileDocumentList = new Microsoft.WindowsCE.Forms.DocumentList();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.FilesMenuItem = new System.Windows.Forms.MenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.MenuItem();
            this.CreateMenuItem = new System.Windows.Forms.MenuItem();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Controls.Add(this.FilterComboBox);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(240, 25);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.Label1.Location = new System.Drawing.Point(4, 3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(37, 19);
            this.Label1.Text = "Filter:";
            // 
            // FilterComboBox
            // 
            this.FilterComboBox.Location = new System.Drawing.Point(48, 1);
            this.FilterComboBox.Name = "FilterComboBox";
            this.FilterComboBox.Size = new System.Drawing.Size(192, 22);
            this.FilterComboBox.TabIndex = 3;
            this.FilterComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterComboBox_SelectedIndexChanged);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.FileContentsTextBox);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 154);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(240, 114);
            // 
            // FileContentsTextBox
            // 
            this.FileContentsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileContentsTextBox.Enabled = false;
            this.FileContentsTextBox.Location = new System.Drawing.Point(0, 0);
            this.FileContentsTextBox.Multiline = true;
            this.FileContentsTextBox.Name = "FileContentsTextBox";
            this.FileContentsTextBox.Size = new System.Drawing.Size(240, 114);
            this.FileContentsTextBox.TabIndex = 0;
            // 
            // ActionStatusBar
            // 
            this.ActionStatusBar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.ActionStatusBar.Location = new System.Drawing.Point(0, 134);
            this.ActionStatusBar.Name = "ActionStatusBar";
            this.ActionStatusBar.Size = new System.Drawing.Size(240, 20);
            this.ActionStatusBar.Text = "Status";
            // 
            // FileDocumentList
            // 
            this.FileDocumentList.Dock = System.Windows.Forms.DockStyle.Top;
            this.FileDocumentList.Location = new System.Drawing.Point(0, 25);
            this.FileDocumentList.Name = "FileDocumentList";
            this.FileDocumentList.Size = new System.Drawing.Size(240, 111);
            this.FileDocumentList.TabIndex = 6;
            this.FileDocumentList.DeletingDocument += new Microsoft.WindowsCE.Forms.DocumentListEventHandler(this.FileDocumentList_DeletingDocument);
            this.FileDocumentList.DocumentActivated += new Microsoft.WindowsCE.Forms.DocumentListEventHandler(this.FileDocumentList_DocumentActivated_1);
            this.FileDocumentList.SelectedDirectoryChanged += new System.EventHandler(this.FileDocumentList_SelectedDirectoryChanged);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.FilesMenuItem);
            // 
            // FilesMenuItem
            // 
            this.FilesMenuItem.MenuItems.Add(this.DeleteMenuItem);
            this.FilesMenuItem.MenuItems.Add(this.CreateMenuItem);
            this.FilesMenuItem.Text = "Files";
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Text = "Delete Sample Files";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // CreateMenuItem
            // 
            this.CreateMenuItem.Text = "Create Sample Files";
            this.CreateMenuItem.Click += new System.EventHandler(this.CreateMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.FileDocumentList);
            this.Controls.Add(this.ActionStatusBar);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel2);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Panel2.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel Panel2;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.ComboBox FilterComboBox;
		private System.Windows.Forms.Panel Panel1;
		private System.Windows.Forms.TextBox FileContentsTextBox;
		private System.Windows.Forms.StatusBar ActionStatusBar;
		private Microsoft.WindowsCE.Forms.DocumentList FileDocumentList;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem FilesMenuItem;
		private System.Windows.Forms.MenuItem DeleteMenuItem;
		private System.Windows.Forms.MenuItem CreateMenuItem;
	}
}


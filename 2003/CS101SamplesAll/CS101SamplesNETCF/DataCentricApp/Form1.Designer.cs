namespace DataCentricApp
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.FilesMenuItem = new System.Windows.Forms.MenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.MenuItem();
            this.CreateMenuItem = new System.Windows.Forms.MenuItem();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.PrevNextButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.DeleteMenuItem.Text = "Delete Sample Xml File";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // CreateMenuItem
            // 
            this.CreateMenuItem.Text = "Create Sample Xml File";
            this.CreateMenuItem.Click += new System.EventHandler(this.CreateMenuItem_Click);
            // 
            // StatusBar1
            // 
            this.StatusBar1.Location = new System.Drawing.Point(0, 246);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(240, 22);
            this.StatusBar1.Text = "StatusBar1";
            // 
            // PrevNextButton
            // 
            this.PrevNextButton.Location = new System.Drawing.Point(81, 142);
            this.PrevNextButton.Name = "PrevNextButton";
            this.PrevNextButton.Size = new System.Drawing.Size(72, 20);
            this.PrevNextButton.TabIndex = 18;
            this.PrevNextButton.Text = "Next";
            this.PrevNextButton.Click += new System.EventHandler(this.PrevNextButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(3, 142);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(72, 20);
            this.LoadButton.TabIndex = 17;
            this.LoadButton.Text = "Load";
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // TextBox3
            // 
            this.TextBox3.Enabled = false;
            this.TextBox3.Location = new System.Drawing.Point(54, 105);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(122, 21);
            this.TextBox3.TabIndex = 16;
            // 
            // TextBox2
            // 
            this.TextBox2.Enabled = false;
            this.TextBox2.Location = new System.Drawing.Point(54, 58);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(122, 21);
            this.TextBox2.TabIndex = 15;
            // 
            // TextBox1
            // 
            this.TextBox1.Enabled = false;
            this.TextBox1.Location = new System.Drawing.Point(54, 11);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(122, 21);
            this.TextBox1.TabIndex = 14;
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(3, 106);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(45, 20);
            this.Label3.Text = "Phone";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(3, 59);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(45, 20);
            this.Label2.Text = "Last";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(3, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(45, 20);
            this.Label1.Text = "First";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.PrevNextButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.StatusBar1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem FilesMenuItem;
		private System.Windows.Forms.MenuItem DeleteMenuItem;
		private System.Windows.Forms.MenuItem CreateMenuItem;
		private System.Windows.Forms.StatusBar StatusBar1;
		private System.Windows.Forms.Button PrevNextButton;
		private System.Windows.Forms.Button LoadButton;
		private System.Windows.Forms.TextBox TextBox3;
		private System.Windows.Forms.TextBox TextBox2;
		private System.Windows.Forms.TextBox TextBox1;
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label1;
	}
}


namespace SQLCeResultSetSample
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
			System.Windows.Forms.Button PrevButton;
			System.Windows.Forms.Button SaveButton;
			this.ContactDataGrid = new System.Windows.Forms.DataGrid();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.NextButton = new System.Windows.Forms.Button();
			this.PhoneTextBox = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.DeleteButton = new System.Windows.Forms.Button();
			this.AddButton = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.LastTextBox = new System.Windows.Forms.TextBox();
			this.FirstTextBox = new System.Windows.Forms.TextBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			PrevButton = new System.Windows.Forms.Button();
			SaveButton = new System.Windows.Forms.Button();
			this.Panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// PrevButton
			// 
			PrevButton.Location = new System.Drawing.Point(4, 3);
			PrevButton.Name = "PrevButton";
			PrevButton.Size = new System.Drawing.Size(72, 20);
			PrevButton.TabIndex = 7;
			PrevButton.Text = "<<";
			PrevButton.Click += new System.EventHandler(this.PrevButton_Click);
			// 
			// SaveButton
			// 
			SaveButton.Location = new System.Drawing.Point(28, 95);
			SaveButton.Name = "SaveButton";
			SaveButton.Size = new System.Drawing.Size(192, 20);
			SaveButton.TabIndex = 15;
			SaveButton.Text = "Save Changes to Database";
			SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// ContactDataGrid
			// 
			this.ContactDataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ContactDataGrid.Location = new System.Drawing.Point(0, 151);
			this.ContactDataGrid.Name = "ContactDataGrid";
			this.ContactDataGrid.Size = new System.Drawing.Size(240, 117);
			this.ContactDataGrid.TabIndex = 0;
			this.ContactDataGrid.CurrentCellChanged += new System.EventHandler(this.ContactDataGrid_CurrentCellChanged);
			// 
			// Panel1
			// 
			this.Panel1.Controls.Add(this.NextButton);
			this.Panel1.Controls.Add(PrevButton);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Panel1.Location = new System.Drawing.Point(0, 124);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(240, 27);
			// 
			// NextButton
			// 
			this.NextButton.Location = new System.Drawing.Point(165, 3);
			this.NextButton.Name = "NextButton";
			this.NextButton.Size = new System.Drawing.Size(72, 20);
			this.NextButton.TabIndex = 9;
			this.NextButton.Text = ">>";
			this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
			// 
			// PhoneTextBox
			// 
			this.PhoneTextBox.Location = new System.Drawing.Point(42, 32);
			this.PhoneTextBox.Name = "PhoneTextBox";
			this.PhoneTextBox.Size = new System.Drawing.Size(195, 21);
			this.PhoneTextBox.TabIndex = 12;
			// 
			// Label3
			// 
			this.Label3.Location = new System.Drawing.Point(0, 34);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(47, 20);
			this.Label3.Text = "Phone";
			// 
			// DeleteButton
			// 
			this.DeleteButton.Location = new System.Drawing.Point(148, 59);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(72, 20);
			this.DeleteButton.TabIndex = 14;
			this.DeleteButton.Text = "Delete";
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(27, 59);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(72, 20);
			this.AddButton.TabIndex = 13;
			this.AddButton.Text = "Add";
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point(123, 10);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(29, 20);
			this.Label2.Text = "Last";
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(0, 10);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(31, 20);
			this.Label1.Text = "First";
			// 
			// LastTextBox
			// 
			this.LastTextBox.Location = new System.Drawing.Point(158, 10);
			this.LastTextBox.Name = "LastTextBox";
			this.LastTextBox.Size = new System.Drawing.Size(79, 21);
			this.LastTextBox.TabIndex = 11;
			// 
			// FirstTextBox
			// 
			this.FirstTextBox.Location = new System.Drawing.Point(42, 10);
			this.FirstTextBox.Name = "FirstTextBox";
			this.FirstTextBox.Size = new System.Drawing.Size(75, 21);
			this.FirstTextBox.TabIndex = 10;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(SaveButton);
			this.Controls.Add(this.PhoneTextBox);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.DeleteButton);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.LastTextBox);
			this.Controls.Add(this.FirstTextBox);
			this.Controls.Add(this.Panel1);
			this.Controls.Add(this.ContactDataGrid);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGrid ContactDataGrid;
		private System.Windows.Forms.Panel Panel1;
		private System.Windows.Forms.Button NextButton;
		private System.Windows.Forms.TextBox PhoneTextBox;
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.Button DeleteButton;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.TextBox LastTextBox;
		private System.Windows.Forms.TextBox FirstTextBox;
		private System.Windows.Forms.MainMenu mainMenu1;
	}
}


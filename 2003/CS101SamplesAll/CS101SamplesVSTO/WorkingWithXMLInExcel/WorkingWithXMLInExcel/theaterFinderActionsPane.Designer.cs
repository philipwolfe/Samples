namespace Working_with_XML_in_Excel
{
	partial class theaterFinderActionsPane
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.findTheatersButton = new System.Windows.Forms.Button();
            this.zipCodeTextBox = new System.Windows.Forms.TextBox();
            this.theatersListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radiusComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zip code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Radius:";
            // 
            // findTheatersButton
            // 
            this.findTheatersButton.Location = new System.Drawing.Point(15, 79);
            this.findTheatersButton.Name = "findTheatersButton";
            this.findTheatersButton.Size = new System.Drawing.Size(93, 23);
            this.findTheatersButton.TabIndex = 2;
            this.findTheatersButton.Text = "Find Theaters!";
            this.findTheatersButton.Click += new System.EventHandler(this.findTheatersButton_Click);
            // 
            // zipCodeTextBox
            // 
            this.zipCodeTextBox.Location = new System.Drawing.Point(68, 26);
            this.zipCodeTextBox.Name = "zipCodeTextBox";
            this.zipCodeTextBox.Size = new System.Drawing.Size(69, 20);
            this.zipCodeTextBox.TabIndex = 3;
            this.zipCodeTextBox.Text = "98052";
            // 
            // theatersListBox
            // 
            this.theatersListBox.FormattingEnabled = true;
            this.theatersListBox.Location = new System.Drawing.Point(14, 139);
            this.theatersListBox.Name = "theatersListBox";
            this.theatersListBox.Size = new System.Drawing.Size(166, 82);
            this.theatersListBox.TabIndex = 5;
            this.theatersListBox.Click += new System.EventHandler(this.theatersListBox_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select theater to view movie times:";
            // 
            // radiusComboBox
            // 
            this.radiusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.radiusComboBox.FormattingEnabled = true;
            this.radiusComboBox.Items.AddRange(new object[] {
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50"});
            this.radiusComboBox.Location = new System.Drawing.Point(68, 53);
            this.radiusComboBox.Name = "radiusComboBox";
            this.radiusComboBox.Size = new System.Drawing.Size(69, 21);
            this.radiusComboBox.TabIndex = 7;
            // 
            // theaterFinderActionsPane
            // 
            this.Controls.Add(this.radiusComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.theatersListBox);
            this.Controls.Add(this.zipCodeTextBox);
            this.Controls.Add(this.findTheatersButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.Name = "theaterFinderActionsPane";
            this.Size = new System.Drawing.Size(198, 240);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button findTheatersButton;
        private System.Windows.Forms.TextBox zipCodeTextBox;
		private System.Windows.Forms.ListBox theatersListBox;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox radiusComboBox;
	}
}

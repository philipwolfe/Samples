namespace GeoCache
{
	partial class UserDefinedTypesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDefinedTypesForm));
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLineLabel = new System.Windows.Forms.Label();
            this.longitudeTextBox = new System.Windows.Forms.TextBox();
            this.latitudeTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.enterNewLocationButton = new System.Windows.Forms.Button();
            this.displayRichTextBox = new System.Windows.Forms.RichTextBox();
            this.longitudeLabel = new System.Windows.Forms.Label();
            this.latitudeLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.testResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.timeElapsedLabel = new System.Windows.Forms.Label();
            this.rowsAffectedLabel = new System.Windows.Forms.Label();
            this.descriptionGroupBox.SuspendLayout();
            this.testResultsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Controls.Add(this.descriptionLineLabel);
            this.descriptionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Size = new System.Drawing.Size(582, 192);
            this.descriptionGroupBox.TabIndex = 0;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "Description";
            // 
            // descriptionLineLabel
            // 
            this.descriptionLineLabel.AutoSize = true;
            this.descriptionLineLabel.Location = new System.Drawing.Point(6, 16);
            this.descriptionLineLabel.Name = "descriptionLineLabel";
            this.descriptionLineLabel.Size = new System.Drawing.Size(546, 156);
            this.descriptionLineLabel.TabIndex = 0;
            this.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text");
            // 
            // longitudeTextBox
            // 
            this.longitudeTextBox.Location = new System.Drawing.Point(71, 210);
            this.longitudeTextBox.Name = "longitudeTextBox";
            this.longitudeTextBox.Size = new System.Drawing.Size(100, 20);
            this.longitudeTextBox.TabIndex = 1;
            // 
            // latitudeTextBox
            // 
            this.latitudeTextBox.Location = new System.Drawing.Point(71, 246);
            this.latitudeTextBox.Name = "latitudeTextBox";
            this.latitudeTextBox.Size = new System.Drawing.Size(100, 20);
            this.latitudeTextBox.TabIndex = 2;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(71, 286);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(100, 20);
            this.cityTextBox.TabIndex = 3;
            // 
            // enterNewLocationButton
            // 
            this.enterNewLocationButton.Location = new System.Drawing.Point(13, 324);
            this.enterNewLocationButton.Name = "enterNewLocationButton";
            this.enterNewLocationButton.Size = new System.Drawing.Size(187, 23);
            this.enterNewLocationButton.TabIndex = 4;
            this.enterNewLocationButton.Text = "Enter a New Geocache Location";
            this.enterNewLocationButton.Click += new System.EventHandler(this.enterNewLocationButton_Click);
            // 
            // displayRichTextBox
            // 
            this.displayRichTextBox.Location = new System.Drawing.Point(386, 210);
            this.displayRichTextBox.Name = "displayRichTextBox";
            this.displayRichTextBox.ReadOnly = true;
            this.displayRichTextBox.Size = new System.Drawing.Size(208, 159);
            this.displayRichTextBox.TabIndex = 5;
            this.displayRichTextBox.Text = "";
            // 
            // longitudeLabel
            // 
            this.longitudeLabel.AutoSize = true;
            this.longitudeLabel.Location = new System.Drawing.Point(12, 213);
            this.longitudeLabel.Name = "longitudeLabel";
            this.longitudeLabel.Size = new System.Drawing.Size(53, 13);
            this.longitudeLabel.TabIndex = 6;
            this.longitudeLabel.Text = "Longitude:";
            // 
            // latitudeLabel
            // 
            this.latitudeLabel.AutoSize = true;
            this.latitudeLabel.Location = new System.Drawing.Point(12, 249);
            this.latitudeLabel.Name = "latitudeLabel";
            this.latitudeLabel.Size = new System.Drawing.Size(44, 13);
            this.latitudeLabel.TabIndex = 7;
            this.latitudeLabel.Text = "Latitude:";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(12, 289);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(23, 13);
            this.cityLabel.TabIndex = 8;
            this.cityLabel.Text = "City:";
            // 
            // testResultsGroupBox
            // 
            this.testResultsGroupBox.Controls.Add(this.timeElapsedLabel);
            this.testResultsGroupBox.Controls.Add(this.rowsAffectedLabel);
            this.testResultsGroupBox.Location = new System.Drawing.Point(205, 210);
            this.testResultsGroupBox.Name = "testResultsGroupBox";
            this.testResultsGroupBox.Size = new System.Drawing.Size(175, 159);
            this.testResultsGroupBox.TabIndex = 9;
            this.testResultsGroupBox.TabStop = false;
            this.testResultsGroupBox.Text = "Test Results";
            // 
            // timeElapsedLabel
            // 
            this.timeElapsedLabel.AutoSize = true;
            this.timeElapsedLabel.Location = new System.Drawing.Point(7, 84);
            this.timeElapsedLabel.Name = "timeElapsedLabel";
            this.timeElapsedLabel.Size = new System.Drawing.Size(70, 13);
            this.timeElapsedLabel.TabIndex = 1;
            this.timeElapsedLabel.Text = "Time Elapsed:";
            // 
            // rowsAffectedLabel
            // 
            this.rowsAffectedLabel.AutoSize = true;
            this.rowsAffectedLabel.Location = new System.Drawing.Point(7, 37);
            this.rowsAffectedLabel.Name = "rowsAffectedLabel";
            this.rowsAffectedLabel.Size = new System.Drawing.Size(76, 13);
            this.rowsAffectedLabel.TabIndex = 0;
            this.rowsAffectedLabel.Text = "Rows Affected:";
            // 
            // UserDefinedTypesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 381);
            this.Controls.Add(this.testResultsGroupBox);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.latitudeLabel);
            this.Controls.Add(this.longitudeLabel);
            this.Controls.Add(this.displayRichTextBox);
            this.Controls.Add(this.enterNewLocationButton);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.latitudeTextBox);
            this.Controls.Add(this.longitudeTextBox);
            this.Controls.Add(this.descriptionGroupBox);
            this.Name = "UserDefinedTypesForm";
            this.Text = "User Defined Type Example";
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            this.testResultsGroupBox.ResumeLayout(false);
            this.testResultsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox descriptionGroupBox;
		private System.Windows.Forms.TextBox longitudeTextBox;
		private System.Windows.Forms.TextBox latitudeTextBox;
		private System.Windows.Forms.TextBox cityTextBox;
		private System.Windows.Forms.Button enterNewLocationButton;
		private System.Windows.Forms.RichTextBox displayRichTextBox;
		private System.Windows.Forms.Label longitudeLabel;
		private System.Windows.Forms.Label latitudeLabel;
		private System.Windows.Forms.Label cityLabel;
		private System.Windows.Forms.Label descriptionLineLabel;
		private System.Windows.Forms.GroupBox testResultsGroupBox;
		private System.Windows.Forms.Label timeElapsedLabel;
		private System.Windows.Forms.Label rowsAffectedLabel;
	}
}


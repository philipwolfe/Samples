namespace MultipleActiveResultsSets
{
	partial class multipleActiveResultSetsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(multipleActiveResultSetsForm));
            this.connectionNumberLabel = new System.Windows.Forms.Label();
            this.retrieveDataButton = new System.Windows.Forms.Button();
            this.withMARSRadioButton = new System.Windows.Forms.RadioButton();
            this.withoutMARSRadioButton = new System.Windows.Forms.RadioButton();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.testResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.connectionRequiredTextLabel = new System.Windows.Forms.Label();
            this.timeRequiredTextLabel = new System.Windows.Forms.Label();
            this.displayedDataRichTextBox = new System.Windows.Forms.RichTextBox();
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLineLabel = new System.Windows.Forms.Label();
            this.testResultsGroupBox.SuspendLayout();
            this.descriptionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionNumberLabel
            // 
            this.connectionNumberLabel.AutoSize = true;
            this.connectionNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionNumberLabel.Location = new System.Drawing.Point(8, 97);
            this.connectionNumberLabel.Name = "connectionNumberLabel";
            this.connectionNumberLabel.Size = new System.Drawing.Size(124, 20);
            this.connectionNumberLabel.TabIndex = 3;
            this.connectionNumberLabel.Text = "# Connections";
            // 
            // retrieveDataButton
            // 
            this.retrieveDataButton.Location = new System.Drawing.Point(48, 246);
            this.retrieveDataButton.Name = "retrieveDataButton";
            this.retrieveDataButton.Size = new System.Drawing.Size(97, 23);
            this.retrieveDataButton.TabIndex = 11;
            this.retrieveDataButton.Text = "Retrieve Data";
            this.retrieveDataButton.Click += new System.EventHandler(this.retrieveDataButton_Click);
            // 
            // withMARSRadioButton
            // 
            this.withMARSRadioButton.AutoSize = true;
            this.withMARSRadioButton.Location = new System.Drawing.Point(48, 203);
            this.withMARSRadioButton.Name = "withMARSRadioButton";
            this.withMARSRadioButton.Size = new System.Drawing.Size(176, 17);
            this.withMARSRadioButton.TabIndex = 10;
            this.withMARSRadioButton.Text = "With Multiple Active Result Sets";
            // 
            // withoutMARSRadioButton
            // 
            this.withoutMARSRadioButton.AutoSize = true;
            this.withoutMARSRadioButton.Location = new System.Drawing.Point(48, 179);
            this.withoutMARSRadioButton.Name = "withoutMARSRadioButton";
            this.withoutMARSRadioButton.Size = new System.Drawing.Size(178, 17);
            this.withoutMARSRadioButton.TabIndex = 9;
            this.withoutMARSRadioButton.Text = "W/O Multiple Active Result Sets";
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elapsedTimeLabel.Location = new System.Drawing.Point(9, 42);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(51, 20);
            this.elapsedTimeLabel.TabIndex = 2;
            this.elapsedTimeLabel.Text = "TIME";
            // 
            // testResultsGroupBox
            // 
            this.testResultsGroupBox.Controls.Add(this.connectionNumberLabel);
            this.testResultsGroupBox.Controls.Add(this.elapsedTimeLabel);
            this.testResultsGroupBox.Controls.Add(this.connectionRequiredTextLabel);
            this.testResultsGroupBox.Controls.Add(this.timeRequiredTextLabel);
            this.testResultsGroupBox.Location = new System.Drawing.Point(243, 158);
            this.testResultsGroupBox.Name = "testResultsGroupBox";
            this.testResultsGroupBox.Size = new System.Drawing.Size(135, 208);
            this.testResultsGroupBox.TabIndex = 8;
            this.testResultsGroupBox.TabStop = false;
            this.testResultsGroupBox.Text = "Test Results";
            // 
            // connectionRequiredTextLabel
            // 
            this.connectionRequiredTextLabel.AutoSize = true;
            this.connectionRequiredTextLabel.Location = new System.Drawing.Point(7, 71);
            this.connectionRequiredTextLabel.Name = "connectionRequiredTextLabel";
            this.connectionRequiredTextLabel.Size = new System.Drawing.Size(115, 13);
            this.connectionRequiredTextLabel.TabIndex = 1;
            this.connectionRequiredTextLabel.Text = "Connections Required:";
            // 
            // timeRequiredTextLabel
            // 
            this.timeRequiredTextLabel.AutoSize = true;
            this.timeRequiredTextLabel.Location = new System.Drawing.Point(7, 21);
            this.timeRequiredTextLabel.Name = "timeRequiredTextLabel";
            this.timeRequiredTextLabel.Size = new System.Drawing.Size(79, 13);
            this.timeRequiredTextLabel.TabIndex = 0;
            this.timeRequiredTextLabel.Text = "Time Required:";
            // 
            // displayedDataRichTextBox
            // 
            this.displayedDataRichTextBox.Location = new System.Drawing.Point(389, 158);
            this.displayedDataRichTextBox.Name = "displayedDataRichTextBox";
            this.displayedDataRichTextBox.ReadOnly = true;
            this.displayedDataRichTextBox.Size = new System.Drawing.Size(298, 296);
            this.displayedDataRichTextBox.TabIndex = 7;
            this.displayedDataRichTextBox.Text = "";
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Controls.Add(this.descriptionLineLabel);
            this.descriptionGroupBox.Location = new System.Drawing.Point(48, 21);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Size = new System.Drawing.Size(631, 113);
            this.descriptionGroupBox.TabIndex = 6;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "Description";
            // 
            // descriptionLineLabel
            // 
            this.descriptionLineLabel.AutoSize = true;
            this.descriptionLineLabel.Location = new System.Drawing.Point(6, 16);
            this.descriptionLineLabel.Name = "descriptionLineLabel";
            this.descriptionLineLabel.Size = new System.Drawing.Size(566, 65);
            this.descriptionLineLabel.TabIndex = 0;
            this.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text");
            // 
            // multipleActiveResultSetsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 475);
            this.Controls.Add(this.retrieveDataButton);
            this.Controls.Add(this.withMARSRadioButton);
            this.Controls.Add(this.withoutMARSRadioButton);
            this.Controls.Add(this.testResultsGroupBox);
            this.Controls.Add(this.displayedDataRichTextBox);
            this.Controls.Add(this.descriptionGroupBox);
            this.Name = "multipleActiveResultSetsForm";
            this.Text = "Using Multiple Active Result Sets";
            this.testResultsGroupBox.ResumeLayout(false);
            this.testResultsGroupBox.PerformLayout();
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label connectionNumberLabel;
		private System.Windows.Forms.Button retrieveDataButton;
		private System.Windows.Forms.RadioButton withMARSRadioButton;
		private System.Windows.Forms.RadioButton withoutMARSRadioButton;
		private System.Windows.Forms.Label elapsedTimeLabel;
		private System.Windows.Forms.GroupBox testResultsGroupBox;
		private System.Windows.Forms.Label connectionRequiredTextLabel;
		private System.Windows.Forms.Label timeRequiredTextLabel;
		private System.Windows.Forms.RichTextBox displayedDataRichTextBox;
		private System.Windows.Forms.GroupBox descriptionGroupBox;
        private System.Windows.Forms.Label descriptionLineLabel;
	}
}


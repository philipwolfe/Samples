namespace DistanceCalculator
{
	partial class StoredProcedureUDFForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoredProcedureUDFForm));
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLineLabel = new System.Windows.Forms.Label();
            this.retrieveDataButton = new System.Windows.Forms.Button();
            this.testResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.actionLabel = new System.Windows.Forms.Label();
            this.longitude1TextBox = new System.Windows.Forms.TextBox();
            this.insertNewDataButton = new System.Windows.Forms.Button();
            this.latitude1TextBox = new System.Windows.Forms.TextBox();
            this.longitude2TextBox = new System.Windows.Forms.TextBox();
            this.latitude2TextBox = new System.Windows.Forms.TextBox();
            this.longitude1Label = new System.Windows.Forms.Label();
            this.latitude1Label = new System.Windows.Forms.Label();
            this.longitude2Label = new System.Windows.Forms.Label();
            this.latitude2Label = new System.Windows.Forms.Label();
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.descriptionGroupBox.SuspendLayout();
            this.testResultsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Controls.Add(this.descriptionLineLabel);
            this.descriptionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Size = new System.Drawing.Size(578, 154);
            this.descriptionGroupBox.TabIndex = 0;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "Description";
            // 
            // descriptionLineLabel
            // 
            this.descriptionLineLabel.AutoSize = true;
            this.descriptionLineLabel.Location = new System.Drawing.Point(6, 16);
            this.descriptionLineLabel.Name = "descriptionLineLabel";
            this.descriptionLineLabel.Size = new System.Drawing.Size(530, 117);
            this.descriptionLineLabel.TabIndex = 0;
            this.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text");
            // 
            // retrieveDataButton
            // 
            this.retrieveDataButton.Location = new System.Drawing.Point(12, 417);
            this.retrieveDataButton.Name = "retrieveDataButton";
            this.retrieveDataButton.Size = new System.Drawing.Size(100, 23);
            this.retrieveDataButton.TabIndex = 6;
            this.retrieveDataButton.Text = "Retrieve Data";
            this.retrieveDataButton.Click += new System.EventHandler(this.retrieveDataButton_Click);
            // 
            // testResultsGroupBox
            // 
            this.testResultsGroupBox.Controls.Add(this.elapsedTimeLabel);
            this.testResultsGroupBox.Controls.Add(this.actionLabel);
            this.testResultsGroupBox.Location = new System.Drawing.Point(133, 192);
            this.testResultsGroupBox.Name = "testResultsGroupBox";
            this.testResultsGroupBox.Size = new System.Drawing.Size(153, 248);
            this.testResultsGroupBox.TabIndex = 3;
            this.testResultsGroupBox.TabStop = false;
            this.testResultsGroupBox.Text = "Test Results";
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elapsedTimeLabel.Location = new System.Drawing.Point(6, 68);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(83, 13);
            this.elapsedTimeLabel.TabIndex = 1;
            this.elapsedTimeLabel.Text = "Elapsed Time:";
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionLabel.Location = new System.Drawing.Point(6, 27);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(43, 13);
            this.actionLabel.TabIndex = 0;
            this.actionLabel.Text = "Action:";
            // 
            // longitude1TextBox
            // 
            this.longitude1TextBox.Location = new System.Drawing.Point(12, 212);
            this.longitude1TextBox.Name = "longitude1TextBox";
            this.longitude1TextBox.Size = new System.Drawing.Size(100, 20);
            this.longitude1TextBox.TabIndex = 1;
            // 
            // insertNewDataButton
            // 
            this.insertNewDataButton.Location = new System.Drawing.Point(12, 377);
            this.insertNewDataButton.Name = "insertNewDataButton";
            this.insertNewDataButton.Size = new System.Drawing.Size(100, 23);
            this.insertNewDataButton.TabIndex = 5;
            this.insertNewDataButton.Text = "Insert New Data";
            this.insertNewDataButton.Click += new System.EventHandler(this.insertNewDataButton_Click);
            // 
            // latitude1TextBox
            // 
            this.latitude1TextBox.Location = new System.Drawing.Point(12, 253);
            this.latitude1TextBox.Name = "latitude1TextBox";
            this.latitude1TextBox.Size = new System.Drawing.Size(100, 20);
            this.latitude1TextBox.TabIndex = 2;
            // 
            // longitude2TextBox
            // 
            this.longitude2TextBox.Location = new System.Drawing.Point(12, 295);
            this.longitude2TextBox.Name = "longitude2TextBox";
            this.longitude2TextBox.Size = new System.Drawing.Size(100, 20);
            this.longitude2TextBox.TabIndex = 3;
            // 
            // latitude2TextBox
            // 
            this.latitude2TextBox.Location = new System.Drawing.Point(12, 340);
            this.latitude2TextBox.Name = "latitude2TextBox";
            this.latitude2TextBox.Size = new System.Drawing.Size(100, 20);
            this.latitude2TextBox.TabIndex = 4;
            // 
            // longitude1Label
            // 
            this.longitude1Label.AutoSize = true;
            this.longitude1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longitude1Label.Location = new System.Drawing.Point(11, 190);
            this.longitude1Label.Name = "longitude1Label";
            this.longitude1Label.Size = new System.Drawing.Size(74, 13);
            this.longitude1Label.TabIndex = 3;
            this.longitude1Label.Text = "Longitude 1:";
            // 
            // latitude1Label
            // 
            this.latitude1Label.AutoSize = true;
            this.latitude1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latitude1Label.Location = new System.Drawing.Point(11, 235);
            this.latitude1Label.Name = "latitude1Label";
            this.latitude1Label.Size = new System.Drawing.Size(64, 13);
            this.latitude1Label.TabIndex = 7;
            this.latitude1Label.Text = "Latitude 1:";
            // 
            // longitude2Label
            // 
            this.longitude2Label.AutoSize = true;
            this.longitude2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longitude2Label.Location = new System.Drawing.Point(11, 276);
            this.longitude2Label.Name = "longitude2Label";
            this.longitude2Label.Size = new System.Drawing.Size(74, 13);
            this.longitude2Label.TabIndex = 8;
            this.longitude2Label.Text = "Longitude 2:";
            // 
            // latitude2Label
            // 
            this.latitude2Label.AutoSize = true;
            this.latitude2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latitude2Label.Location = new System.Drawing.Point(11, 318);
            this.latitude2Label.Name = "latitude2Label";
            this.latitude2Label.Size = new System.Drawing.Size(64, 13);
            this.latitude2Label.TabIndex = 9;
            this.latitude2Label.Text = "Latitude 2:";
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.Location = new System.Drawing.Point(308, 192);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.ReadOnly = true;
            this.resultsDataGridView.Size = new System.Drawing.Size(282, 248);
            this.resultsDataGridView.TabIndex = 10;
            this.resultsDataGridView.Text = "dataGridView1";
            // 
            // StoredProcedureUDFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 455);
            this.Controls.Add(this.resultsDataGridView);
            this.Controls.Add(this.insertNewDataButton);
            this.Controls.Add(this.latitude2Label);
            this.Controls.Add(this.longitude2Label);
            this.Controls.Add(this.latitude1Label);
            this.Controls.Add(this.longitude1Label);
            this.Controls.Add(this.latitude2TextBox);
            this.Controls.Add(this.longitude2TextBox);
            this.Controls.Add(this.latitude1TextBox);
            this.Controls.Add(this.testResultsGroupBox);
            this.Controls.Add(this.longitude1TextBox);
            this.Controls.Add(this.retrieveDataButton);
            this.Controls.Add(this.descriptionGroupBox);
            this.Name = "StoredProcedureUDFForm";
            this.Text = "Stored Procedure and User Defined Function Example";
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            this.testResultsGroupBox.ResumeLayout(false);
            this.testResultsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox descriptionGroupBox;
		private System.Windows.Forms.Button retrieveDataButton;
		private System.Windows.Forms.GroupBox testResultsGroupBox;
		private System.Windows.Forms.Label descriptionLineLabel;
		private System.Windows.Forms.Label actionLabel;
		private System.Windows.Forms.TextBox longitude1TextBox;
		private System.Windows.Forms.Button insertNewDataButton;
		private System.Windows.Forms.TextBox latitude1TextBox;
		private System.Windows.Forms.TextBox longitude2TextBox;
		private System.Windows.Forms.TextBox latitude2TextBox;
		private System.Windows.Forms.Label longitude1Label;
		private System.Windows.Forms.Label latitude1Label;
		private System.Windows.Forms.Label longitude2Label;
		private System.Windows.Forms.Label latitude2Label;
		private System.Windows.Forms.DataGridView resultsDataGridView;
		private System.Windows.Forms.Label elapsedTimeLabel;
	}
}


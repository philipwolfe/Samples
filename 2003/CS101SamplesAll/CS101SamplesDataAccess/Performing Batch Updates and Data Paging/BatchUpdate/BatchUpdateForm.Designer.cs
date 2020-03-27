namespace BatchUpdate
{
	partial class batchUpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(batchUpdateForm));
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionLineLabel = new System.Windows.Forms.Label();
            this.batchSizeComboBox = new System.Windows.Forms.ComboBox();
            this.insertDataButton = new System.Windows.Forms.Button();
            this.sampleDataDataGridView = new System.Windows.Forms.DataGridView();
            this.finalResultWebBrowser = new System.Windows.Forms.WebBrowser();
            this.testResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.rowsInsertedLabel = new System.Windows.Forms.Label();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.elapsedTimeTextLabel = new System.Windows.Forms.Label();
            this.chooseBatchSizeLabel = new System.Windows.Forms.Label();
            this.dataSetSizeLabel = new System.Windows.Forms.Label();
            this.dataSetSizeComboBox = new System.Windows.Forms.ComboBox();
            this.descriptionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDataDataGridView)).BeginInit();
            this.testResultsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionGroupBox.Controls.Add(this.label5);
            this.descriptionGroupBox.Controls.Add(this.label4);
            this.descriptionGroupBox.Controls.Add(this.descriptionLineLabel);
            this.descriptionGroupBox.Location = new System.Drawing.Point(12, 21);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Size = new System.Drawing.Size(659, 135);
            this.descriptionGroupBox.TabIndex = 0;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = " ";
            // 
            // descriptionLineLabel
            // 
            this.descriptionLineLabel.AutoSize = true;
            this.descriptionLineLabel.Location = new System.Drawing.Point(12, 16);
            this.descriptionLineLabel.Name = "descriptionLineLabel";
            this.descriptionLineLabel.Size = new System.Drawing.Size(598, 104);
            this.descriptionLineLabel.TabIndex = 0;
            this.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text");
            // 
            // batchSizeComboBox
            // 
            this.batchSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batchSizeComboBox.FormattingEnabled = true;
            this.batchSizeComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "50",
            "100",
            "500"});
            this.batchSizeComboBox.Location = new System.Drawing.Point(13, 233);
            this.batchSizeComboBox.Name = "batchSizeComboBox";
            this.batchSizeComboBox.Size = new System.Drawing.Size(75, 21);
            this.batchSizeComboBox.TabIndex = 2;
            // 
            // insertDataButton
            // 
            this.insertDataButton.Location = new System.Drawing.Point(13, 263);
            this.insertDataButton.Name = "insertDataButton";
            this.insertDataButton.Size = new System.Drawing.Size(75, 23);
            this.insertDataButton.TabIndex = 4;
            this.insertDataButton.Text = "Insert Data";
            this.insertDataButton.Click += new System.EventHandler(this.insertData_Click);
            // 
            // sampleDataDataGridView
            // 
            this.sampleDataDataGridView.Location = new System.Drawing.Point(281, 162);
            this.sampleDataDataGridView.Name = "sampleDataDataGridView";
            this.sampleDataDataGridView.ReadOnly = true;
            this.sampleDataDataGridView.Size = new System.Drawing.Size(175, 220);
            this.sampleDataDataGridView.TabIndex = 5;
            this.sampleDataDataGridView.Text = "dataGridView1";
            // 
            // finalResultWebBrowser
            // 
            this.finalResultWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.finalResultWebBrowser.Location = new System.Drawing.Point(463, 162);
            this.finalResultWebBrowser.Name = "finalResultWebBrowser";
            this.finalResultWebBrowser.Size = new System.Drawing.Size(208, 216);
            this.finalResultWebBrowser.TabIndex = 11;
            // 
            // testResultsGroupBox
            // 
            this.testResultsGroupBox.Controls.Add(this.rowsInsertedLabel);
            this.testResultsGroupBox.Controls.Add(this.elapsedTimeLabel);
            this.testResultsGroupBox.Controls.Add(this.elapsedTimeTextLabel);
            this.testResultsGroupBox.Location = new System.Drawing.Point(141, 162);
            this.testResultsGroupBox.Name = "testResultsGroupBox";
            this.testResultsGroupBox.Size = new System.Drawing.Size(134, 183);
            this.testResultsGroupBox.TabIndex = 7;
            this.testResultsGroupBox.TabStop = false;
            this.testResultsGroupBox.Text = "Test Results";
            // 
            // rowsInsertedLabel
            // 
            this.rowsInsertedLabel.AutoSize = true;
            this.rowsInsertedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowsInsertedLabel.Location = new System.Drawing.Point(4, 111);
            this.rowsInsertedLabel.Name = "rowsInsertedLabel";
            this.rowsInsertedLabel.Size = new System.Drawing.Size(92, 13);
            this.rowsInsertedLabel.TabIndex = 2;
            this.rowsInsertedLabel.Text = "Rows Inserted:";
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elapsedTimeLabel.Location = new System.Drawing.Point(15, 70);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(0, 20);
            this.elapsedTimeLabel.TabIndex = 1;
            // 
            // elapsedTimeTextLabel
            // 
            this.elapsedTimeTextLabel.AutoSize = true;
            this.elapsedTimeTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elapsedTimeTextLabel.Location = new System.Drawing.Point(5, 34);
            this.elapsedTimeTextLabel.Name = "elapsedTimeTextLabel";
            this.elapsedTimeTextLabel.Size = new System.Drawing.Size(87, 13);
            this.elapsedTimeTextLabel.TabIndex = 0;
            this.elapsedTimeTextLabel.Text = "Elapsed Time:";
            // 
            // chooseBatchSizeLabel
            // 
            this.chooseBatchSizeLabel.AutoSize = true;
            this.chooseBatchSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseBatchSizeLabel.Location = new System.Drawing.Point(4, 212);
            this.chooseBatchSizeLabel.Name = "chooseBatchSizeLabel";
            this.chooseBatchSizeLabel.Size = new System.Drawing.Size(118, 13);
            this.chooseBatchSizeLabel.TabIndex = 0;
            this.chooseBatchSizeLabel.Text = "Choose Batch Size:";
            // 
            // dataSetSizeLabel
            // 
            this.dataSetSizeLabel.AutoSize = true;
            this.dataSetSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSetSizeLabel.Location = new System.Drawing.Point(4, 164);
            this.dataSetSizeLabel.Name = "dataSetSizeLabel";
            this.dataSetSizeLabel.Size = new System.Drawing.Size(131, 13);
            this.dataSetSizeLabel.TabIndex = 9;
            this.dataSetSizeLabel.Text = "Choose DataSet Size:";
            // 
            // dataSetSizeComboBox
            // 
            this.dataSetSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataSetSizeComboBox.FormattingEnabled = true;
            this.dataSetSizeComboBox.Location = new System.Drawing.Point(13, 185);
            this.dataSetSizeComboBox.Name = "dataSetSizeComboBox";
            this.dataSetSizeComboBox.Size = new System.Drawing.Size(75, 21);
            this.dataSetSizeComboBox.TabIndex = 10;
            // 
            // batchUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 394);
            this.Controls.Add(this.dataSetSizeComboBox);
            this.Controls.Add(this.dataSetSizeLabel);
            this.Controls.Add(this.chooseBatchSizeLabel);
            this.Controls.Add(this.testResultsGroupBox);
            this.Controls.Add(this.finalResultWebBrowser);
            this.Controls.Add(this.sampleDataDataGridView);
            this.Controls.Add(this.insertDataButton);
            this.Controls.Add(this.batchSizeComboBox);
            this.Controls.Add(this.descriptionGroupBox);
            this.Name = "batchUpdateForm";
            this.Text = "Batch Update Example";
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDataDataGridView)).EndInit();
            this.testResultsGroupBox.ResumeLayout(false);
            this.testResultsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox descriptionGroupBox;
		private System.Windows.Forms.ComboBox batchSizeComboBox;
		private System.Windows.Forms.Button insertDataButton;
		private System.Windows.Forms.DataGridView sampleDataDataGridView;
		private System.Windows.Forms.WebBrowser finalResultWebBrowser;
		private System.Windows.Forms.GroupBox testResultsGroupBox;
		private System.Windows.Forms.Label elapsedTimeLabel;
		private System.Windows.Forms.Label elapsedTimeTextLabel;
		private System.Windows.Forms.Label chooseBatchSizeLabel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label descriptionLineLabel;
        private System.Windows.Forms.Label rowsInsertedLabel;
        private System.Windows.Forms.Label dataSetSizeLabel;
        private System.Windows.Forms.ComboBox dataSetSizeComboBox;
	}
}


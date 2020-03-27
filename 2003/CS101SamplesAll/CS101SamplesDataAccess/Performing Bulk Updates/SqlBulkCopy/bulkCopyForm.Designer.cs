namespace SqlBulkCopy
{
	partial class bulkCopyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bulkCopyForm));
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.o = new System.Windows.Forms.Label();
            this.testResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.rowsCopiedTextLabel = new System.Windows.Forms.Label();
            this.rowsCopiedLabel = new System.Windows.Forms.Label();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.elapsedTimeTextLabel = new System.Windows.Forms.Label();
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.fillTableButton = new System.Windows.Forms.Button();
            this.copyDataButton = new System.Windows.Forms.Button();
            this.fillTableLabel = new System.Windows.Forms.Label();
            this.copyDataLabel = new System.Windows.Forms.Label();
            this.chooseRowsLabel = new System.Windows.Forms.Label();
            this.numberOfRowsComboBox = new System.Windows.Forms.ComboBox();
            this.copyProgressProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.descriptionGroupBox.SuspendLayout();
            this.testResultsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Controls.Add(this.o);
            this.descriptionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Size = new System.Drawing.Size(632, 93);
            this.descriptionGroupBox.TabIndex = 0;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "Description";
            // 
            // o
            // 
            this.o.AutoSize = true;
            this.o.Location = new System.Drawing.Point(6, 18);
            this.o.Name = "o";
            this.o.Size = new System.Drawing.Size(577, 65);
            this.o.TabIndex = 0;
            this.o.Text = resources.GetString("o.Text");
            // 
            // testResultsGroupBox
            // 
            this.testResultsGroupBox.Controls.Add(this.rowsCopiedTextLabel);
            this.testResultsGroupBox.Controls.Add(this.rowsCopiedLabel);
            this.testResultsGroupBox.Controls.Add(this.elapsedTimeLabel);
            this.testResultsGroupBox.Controls.Add(this.elapsedTimeTextLabel);
            this.testResultsGroupBox.Location = new System.Drawing.Point(207, 123);
            this.testResultsGroupBox.Name = "testResultsGroupBox";
            this.testResultsGroupBox.Size = new System.Drawing.Size(121, 217);
            this.testResultsGroupBox.TabIndex = 1;
            this.testResultsGroupBox.TabStop = false;
            this.testResultsGroupBox.Text = "Test Results";
            // 
            // rowsCopiedTextLabel
            // 
            this.rowsCopiedTextLabel.AutoSize = true;
            this.rowsCopiedTextLabel.Location = new System.Drawing.Point(8, 83);
            this.rowsCopiedTextLabel.Name = "rowsCopiedTextLabel";
            this.rowsCopiedTextLabel.Size = new System.Drawing.Size(70, 13);
            this.rowsCopiedTextLabel.TabIndex = 3;
            this.rowsCopiedTextLabel.Text = "Rows Copied";
            // 
            // rowsCopiedLabel
            // 
            this.rowsCopiedLabel.AutoSize = true;
            this.rowsCopiedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowsCopiedLabel.Location = new System.Drawing.Point(6, 112);
            this.rowsCopiedLabel.Name = "rowsCopiedLabel";
            this.rowsCopiedLabel.Size = new System.Drawing.Size(0, 13);
            this.rowsCopiedLabel.TabIndex = 2;
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elapsedTimeLabel.Location = new System.Drawing.Point(8, 57);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.elapsedTimeLabel.TabIndex = 1;
            // 
            // elapsedTimeTextLabel
            // 
            this.elapsedTimeTextLabel.AutoSize = true;
            this.elapsedTimeTextLabel.Location = new System.Drawing.Point(7, 33);
            this.elapsedTimeTextLabel.Name = "elapsedTimeTextLabel";
            this.elapsedTimeTextLabel.Size = new System.Drawing.Size(74, 13);
            this.elapsedTimeTextLabel.TabIndex = 0;
            this.elapsedTimeTextLabel.Text = "Elapsed Time:";
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.Location = new System.Drawing.Point(335, 123);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.ReadOnly = true;
            this.resultsDataGridView.Size = new System.Drawing.Size(309, 232);
            this.resultsDataGridView.TabIndex = 2;
            this.resultsDataGridView.Text = "dataGridView1";
            // 
            // fillTableButton
            // 
            this.fillTableButton.Location = new System.Drawing.Point(12, 187);
            this.fillTableButton.Name = "fillTableButton";
            this.fillTableButton.Size = new System.Drawing.Size(75, 23);
            this.fillTableButton.TabIndex = 5;
            this.fillTableButton.Text = "Fill Data";
            this.fillTableButton.Click += new System.EventHandler(this.fillTableButton_Click);
            // 
            // copyDataButton
            // 
            this.copyDataButton.Location = new System.Drawing.Point(10, 253);
            this.copyDataButton.Name = "copyDataButton";
            this.copyDataButton.Size = new System.Drawing.Size(75, 23);
            this.copyDataButton.TabIndex = 6;
            this.copyDataButton.Text = "Copy Data";
            this.copyDataButton.Click += new System.EventHandler(this.copyDataButton_Click);
            // 
            // fillTableLabel
            // 
            this.fillTableLabel.AutoSize = true;
            this.fillTableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fillTableLabel.Location = new System.Drawing.Point(12, 165);
            this.fillTableLabel.Name = "fillTableLabel";
            this.fillTableLabel.Size = new System.Drawing.Size(104, 13);
            this.fillTableLabel.TabIndex = 7;
            this.fillTableLabel.Text = "Step 2: Fill Table";
            // 
            // copyDataLabel
            // 
            this.copyDataLabel.AutoSize = true;
            this.copyDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyDataLabel.Location = new System.Drawing.Point(11, 226);
            this.copyDataLabel.Name = "copyDataLabel";
            this.copyDataLabel.Size = new System.Drawing.Size(111, 13);
            this.copyDataLabel.TabIndex = 9;
            this.copyDataLabel.Text = "Step 3: Copy Data";
            // 
            // chooseRowsLabel
            // 
            this.chooseRowsLabel.AutoSize = true;
            this.chooseRowsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseRowsLabel.Location = new System.Drawing.Point(12, 118);
            this.chooseRowsLabel.Name = "chooseRowsLabel";
            this.chooseRowsLabel.Size = new System.Drawing.Size(160, 13);
            this.chooseRowsLabel.TabIndex = 10;
            this.chooseRowsLabel.Text = "Step 1: Choose # of Rows:";
            // 
            // numberOfRowsComboBox
            // 
            this.numberOfRowsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numberOfRowsComboBox.FormattingEnabled = true;
            this.numberOfRowsComboBox.Location = new System.Drawing.Point(12, 138);
            this.numberOfRowsComboBox.Name = "numberOfRowsComboBox";
            this.numberOfRowsComboBox.Size = new System.Drawing.Size(121, 21);
            this.numberOfRowsComboBox.TabIndex = 4;
            this.numberOfRowsComboBox.SelectedIndexChanged += new System.EventHandler(this.numberOfRows_SelectedIndexChanged);
            // 
            // copyProgressProgressBar
            // 
            this.copyProgressProgressBar.Location = new System.Drawing.Point(10, 317);
            this.copyProgressProgressBar.Name = "copyProgressProgressBar";
            this.copyProgressProgressBar.Size = new System.Drawing.Size(100, 23);
            this.copyProgressProgressBar.TabIndex = 11;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(12, 301);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(48, 13);
            this.progressLabel.TabIndex = 12;
            this.progressLabel.Text = "Progress";
            // 
            // bulkCopyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 367);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.copyProgressProgressBar);
            this.Controls.Add(this.numberOfRowsComboBox);
            this.Controls.Add(this.chooseRowsLabel);
            this.Controls.Add(this.copyDataLabel);
            this.Controls.Add(this.fillTableLabel);
            this.Controls.Add(this.copyDataButton);
            this.Controls.Add(this.fillTableButton);
            this.Controls.Add(this.resultsDataGridView);
            this.Controls.Add(this.testResultsGroupBox);
            this.Controls.Add(this.descriptionGroupBox);
            this.Name = "bulkCopyForm";
            this.Text = "Using SqlBulkCopy";
            this.Load += new System.EventHandler(this.bulkCopyForm_Load);
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
		private System.Windows.Forms.GroupBox testResultsGroupBox;
		private System.Windows.Forms.Label rowsCopiedTextLabel;
		private System.Windows.Forms.Label rowsCopiedLabel;
		private System.Windows.Forms.Label elapsedTimeLabel;
		private System.Windows.Forms.Label elapsedTimeTextLabel;
		private System.Windows.Forms.DataGridView resultsDataGridView;
		private System.Windows.Forms.Button fillTableButton;
		private System.Windows.Forms.Button copyDataButton;
		private System.Windows.Forms.Label fillTableLabel;
		private System.Windows.Forms.Label copyDataLabel;
		private System.Windows.Forms.Label chooseRowsLabel;
		private System.Windows.Forms.ComboBox numberOfRowsComboBox;
		private System.Windows.Forms.ProgressBar copyProgressProgressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label o;
	}
}


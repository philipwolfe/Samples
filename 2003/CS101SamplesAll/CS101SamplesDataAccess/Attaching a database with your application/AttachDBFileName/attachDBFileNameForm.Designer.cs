namespace AttachDBFileName
{
	partial class attachDBFileNameForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(attachDBFileNameForm));
            this.testResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.rowsAddedLabel = new System.Windows.Forms.Label();
            this.insertMethodLabel = new System.Windows.Forms.Label();
            this.iterationListBox = new System.Windows.Forms.NumericUpDown();
            this.testOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.storedProcedureRadioButton = new System.Windows.Forms.RadioButton();
            this.sqlQueryRadioButton = new System.Windows.Forms.RadioButton();
            this.rowsToAddLabel = new System.Windows.Forms.Label();
            this.attachedDatabaseGroupBox = new System.Windows.Forms.GroupBox();
            this.db2RadioButton = new System.Windows.Forms.RadioButton();
            this.db1RadioButton = new System.Windows.Forms.RadioButton();
            this.testDataDataGridView = new System.Windows.Forms.DataGridView();
            this.firstValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.perfTestDataSet = new AttachDBFileName.PerfTestDataSet();
            this.runTestButton = new System.Windows.Forms.Button();
            this.testDataTableAdapter = new AttachDBFileName.PerfTestDataSetTableAdapters.TestDataTableAdapter();
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLineLabel = new System.Windows.Forms.Label();
            this.insertedRowsGroupBox = new System.Windows.Forms.GroupBox();
            this.testResultsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iterationListBox)).BeginInit();
            this.testOptionsGroupBox.SuspendLayout();
            this.attachedDatabaseGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDataDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfTestDataSet)).BeginInit();
            this.descriptionGroupBox.SuspendLayout();
            this.insertedRowsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // testResultsGroupBox
            // 
            this.testResultsGroupBox.Controls.Add(this.elapsedTimeLabel);
            this.testResultsGroupBox.Controls.Add(this.rowsAddedLabel);
            this.testResultsGroupBox.Controls.Add(this.insertMethodLabel);
            this.testResultsGroupBox.Location = new System.Drawing.Point(401, 102);
            this.testResultsGroupBox.Name = "testResultsGroupBox";
            this.testResultsGroupBox.Size = new System.Drawing.Size(189, 100);
            this.testResultsGroupBox.TabIndex = 47;
            this.testResultsGroupBox.TabStop = false;
            this.testResultsGroupBox.Text = "Test Results";
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Location = new System.Drawing.Point(17, 70);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(66, 13);
            this.elapsedTimeLabel.TabIndex = 2;
            this.elapsedTimeLabel.Text = "Elapsed time:";
            // 
            // rowsAddedLabel
            // 
            this.rowsAddedLabel.AutoSize = true;
            this.rowsAddedLabel.Location = new System.Drawing.Point(17, 47);
            this.rowsAddedLabel.Name = "rowsAddedLabel";
            this.rowsAddedLabel.Size = new System.Drawing.Size(66, 13);
            this.rowsAddedLabel.TabIndex = 1;
            this.rowsAddedLabel.Text = "Rows added:";
            // 
            // insertMethodLabel
            // 
            this.insertMethodLabel.AutoSize = true;
            this.insertMethodLabel.Location = new System.Drawing.Point(17, 24);
            this.insertMethodLabel.Name = "insertMethodLabel";
            this.insertMethodLabel.Size = new System.Drawing.Size(70, 13);
            this.insertMethodLabel.TabIndex = 0;
            this.insertMethodLabel.Text = "Insert method:";
            // 
            // iterationListBox
            // 
            this.iterationListBox.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.iterationListBox.Location = new System.Drawing.Point(109, 24);
            this.iterationListBox.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.iterationListBox.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.iterationListBox.Name = "iterationListBox";
            this.iterationListBox.ReadOnly = true;
            this.iterationListBox.Size = new System.Drawing.Size(48, 20);
            this.iterationListBox.TabIndex = 20;
            this.iterationListBox.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // testOptionsGroupBox
            // 
            this.testOptionsGroupBox.Controls.Add(this.iterationListBox);
            this.testOptionsGroupBox.Controls.Add(this.storedProcedureRadioButton);
            this.testOptionsGroupBox.Controls.Add(this.sqlQueryRadioButton);
            this.testOptionsGroupBox.Controls.Add(this.rowsToAddLabel);
            this.testOptionsGroupBox.Location = new System.Drawing.Point(12, 102);
            this.testOptionsGroupBox.Name = "testOptionsGroupBox";
            this.testOptionsGroupBox.Size = new System.Drawing.Size(178, 100);
            this.testOptionsGroupBox.TabIndex = 46;
            this.testOptionsGroupBox.TabStop = false;
            this.testOptionsGroupBox.Text = "Test Options";
            // 
            // storedProcedureRadioButton
            // 
            this.storedProcedureRadioButton.AutoSize = true;
            this.storedProcedureRadioButton.Checked = true;
            this.storedProcedureRadioButton.Location = new System.Drawing.Point(25, 51);
            this.storedProcedureRadioButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.storedProcedureRadioButton.Name = "storedProcedureRadioButton";
            this.storedProcedureRadioButton.Size = new System.Drawing.Size(103, 17);
            this.storedProcedureRadioButton.TabIndex = 25;
            this.storedProcedureRadioButton.Text = "Stored procedure";
            // 
            // sqlQueryRadioButton
            // 
            this.sqlQueryRadioButton.AutoSize = true;
            this.sqlQueryRadioButton.Location = new System.Drawing.Point(25, 77);
            this.sqlQueryRadioButton.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.sqlQueryRadioButton.Name = "sqlQueryRadioButton";
            this.sqlQueryRadioButton.Size = new System.Drawing.Size(100, 17);
            this.sqlQueryRadioButton.TabIndex = 26;
            this.sqlQueryRadioButton.Text = "SQL Insert query";
            // 
            // rowsToAddLabel
            // 
            this.rowsToAddLabel.AutoSize = true;
            this.rowsToAddLabel.Location = new System.Drawing.Point(25, 26);
            this.rowsToAddLabel.Name = "rowsToAddLabel";
            this.rowsToAddLabel.Size = new System.Drawing.Size(63, 13);
            this.rowsToAddLabel.TabIndex = 31;
            this.rowsToAddLabel.Text = "Rows to add";
            // 
            // attachedDatabaseGroupBox
            // 
            this.attachedDatabaseGroupBox.Controls.Add(this.db2RadioButton);
            this.attachedDatabaseGroupBox.Controls.Add(this.db1RadioButton);
            this.attachedDatabaseGroupBox.Location = new System.Drawing.Point(220, 102);
            this.attachedDatabaseGroupBox.Name = "attachedDatabaseGroupBox";
            this.attachedDatabaseGroupBox.Size = new System.Drawing.Size(131, 44);
            this.attachedDatabaseGroupBox.TabIndex = 48;
            this.attachedDatabaseGroupBox.TabStop = false;
            this.attachedDatabaseGroupBox.Text = "Attached Database";
            // 
            // db2RadioButton
            // 
            this.db2RadioButton.AutoSize = true;
            this.db2RadioButton.Location = new System.Drawing.Point(70, 20);
            this.db2RadioButton.Name = "db2RadioButton";
            this.db2RadioButton.Size = new System.Drawing.Size(42, 17);
            this.db2RadioButton.TabIndex = 1;
            this.db2RadioButton.Text = "DB2";
            this.db2RadioButton.CheckedChanged += new System.EventHandler(this.db2RadioButton_CheckedChanged);
            // 
            // db1RadioButton
            // 
            this.db1RadioButton.AutoSize = true;
            this.db1RadioButton.Checked = true;
            this.db1RadioButton.Location = new System.Drawing.Point(21, 20);
            this.db1RadioButton.Name = "db1RadioButton";
            this.db1RadioButton.Size = new System.Drawing.Size(42, 17);
            this.db1RadioButton.TabIndex = 0;
            this.db1RadioButton.Text = "DB1";
            this.db1RadioButton.CheckedChanged += new System.EventHandler(this.db1RadioButton_CheckedChanged);
            // 
            // testDataDataGridView
            // 
            this.testDataDataGridView.AllowUserToAddRows = false;
            this.testDataDataGridView.AllowUserToDeleteRows = false;
            this.testDataDataGridView.AutoGenerateColumns = false;
            this.testDataDataGridView.BackgroundColor = System.Drawing.Color.Lavender;
            this.testDataDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Lavender;
            this.testDataDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.testDataDataGridView.Columns.Add(this.firstValueDataGridViewTextBoxColumn);
            this.testDataDataGridView.Columns.Add(this.secondValueDataGridViewTextBoxColumn);
            this.testDataDataGridView.Columns.Add(this.dataGridViewTextBoxColumn1);
            this.testDataDataGridView.DataSource = this.TestDataBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.testDataDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.testDataDataGridView.Font = new System.Drawing.Font("Tahoma", 8F);
            this.testDataDataGridView.GridColor = System.Drawing.Color.RoyalBlue;
            this.testDataDataGridView.Location = new System.Drawing.Point(7, 19);
            this.testDataDataGridView.Name = "testDataDataGridView";
            this.testDataDataGridView.ReadOnly = true;
            this.testDataDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.testDataDataGridView.Size = new System.Drawing.Size(375, 121);
            this.testDataDataGridView.TabIndex = 45;
            // 
            // firstValueDataGridViewTextBoxColumn
            // 
            this.firstValueDataGridViewTextBoxColumn.DataPropertyName = "firstValue";
            this.firstValueDataGridViewTextBoxColumn.HeaderText = "firstValue";
            this.firstValueDataGridViewTextBoxColumn.Name = "firstValue";
            this.firstValueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // secondValueDataGridViewTextBoxColumn
            // 
            this.secondValueDataGridViewTextBoxColumn.DataPropertyName = "secondValue";
            this.secondValueDataGridViewTextBoxColumn.HeaderText = "secondValue";
            this.secondValueDataGridViewTextBoxColumn.Name = "secondValue";
            this.secondValueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "timeStamp";
            this.dataGridViewTextBoxColumn1.HeaderText = "timeStamp";
            this.dataGridViewTextBoxColumn1.Name = "timeStamp";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // TestDataBindingSource
            // 
            this.TestDataBindingSource.DataMember = "TestData";
            this.TestDataBindingSource.DataSource = this.perfTestDataSet;
            // 
            // perfTestDataSet
            // 
            this.perfTestDataSet.DataSetName = "PerfTestDataSet";
            // 
            // runTestButton
            // 
            this.runTestButton.Location = new System.Drawing.Point(220, 163);
            this.runTestButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.runTestButton.Name = "runTestButton";
            this.runTestButton.Size = new System.Drawing.Size(130, 31);
            this.runTestButton.TabIndex = 44;
            this.runTestButton.Text = "Run Test";
            this.runTestButton.Click += new System.EventHandler(this.runTestButton_Click);
            // 
            // testDataTableAdapter
            // 
            this.testDataTableAdapter.ClearBeforeFill = true;
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Controls.Add(this.descriptionLineLabel);
            this.descriptionGroupBox.Location = new System.Drawing.Point(12, 4);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Size = new System.Drawing.Size(578, 76);
            this.descriptionGroupBox.TabIndex = 49;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "Description";
            // 
            // descriptionLineLabel
            // 
            this.descriptionLineLabel.AutoSize = true;
            this.descriptionLineLabel.Location = new System.Drawing.Point(6, 16);
            this.descriptionLineLabel.Name = "descriptionLineLabel";
            this.descriptionLineLabel.Size = new System.Drawing.Size(454, 52);
            this.descriptionLineLabel.TabIndex = 0;
            this.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text");
            // 
            // insertedRowsGroupBox
            // 
            this.insertedRowsGroupBox.Controls.Add(this.testDataDataGridView);
            this.insertedRowsGroupBox.Location = new System.Drawing.Point(10, 226);
            this.insertedRowsGroupBox.Name = "insertedRowsGroupBox";
            this.insertedRowsGroupBox.Size = new System.Drawing.Size(402, 151);
            this.insertedRowsGroupBox.TabIndex = 50;
            this.insertedRowsGroupBox.TabStop = false;
            this.insertedRowsGroupBox.Text = "Inserted Rows";
            // 
            // attachDBFileNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 379);
            this.Controls.Add(this.insertedRowsGroupBox);
            this.Controls.Add(this.descriptionGroupBox);
            this.Controls.Add(this.runTestButton);
            this.Controls.Add(this.testResultsGroupBox);
            this.Controls.Add(this.testOptionsGroupBox);
            this.Controls.Add(this.attachedDatabaseGroupBox);
            this.Name = "attachDBFileNameForm";
            this.Text = "Attach Database File Name Example";
            this.Load += new System.EventHandler(this.attachDBFileNameForm_Load);
            this.testResultsGroupBox.ResumeLayout(false);
            this.testResultsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iterationListBox)).EndInit();
            this.testOptionsGroupBox.ResumeLayout(false);
            this.testOptionsGroupBox.PerformLayout();
            this.attachedDatabaseGroupBox.ResumeLayout(false);
            this.attachedDatabaseGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDataDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfTestDataSet)).EndInit();
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            this.insertedRowsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox testResultsGroupBox;
		private System.Windows.Forms.Label elapsedTimeLabel;
		private System.Windows.Forms.Label rowsAddedLabel;
		private System.Windows.Forms.Label insertMethodLabel;
		private System.Windows.Forms.NumericUpDown iterationListBox;
		private System.Windows.Forms.GroupBox testOptionsGroupBox;
		private System.Windows.Forms.RadioButton storedProcedureRadioButton;
		private System.Windows.Forms.RadioButton sqlQueryRadioButton;
		private System.Windows.Forms.Label rowsToAddLabel;
		private System.Windows.Forms.GroupBox attachedDatabaseGroupBox;
		private System.Windows.Forms.RadioButton db2RadioButton;
		private System.Windows.Forms.RadioButton db1RadioButton;
		private System.Windows.Forms.DataGridView testDataDataGridView;
		private System.Windows.Forms.Button runTestButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn firstValueDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn secondValueDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.BindingSource TestDataBindingSource;
		private AttachDBFileName.PerfTestDataSet perfTestDataSet;
		private AttachDBFileName.PerfTestDataSetTableAdapters.TestDataTableAdapter testDataTableAdapter;
		private System.Windows.Forms.GroupBox descriptionGroupBox;
        private System.Windows.Forms.Label descriptionLineLabel;
        private System.Windows.Forms.GroupBox insertedRowsGroupBox;
	}
}


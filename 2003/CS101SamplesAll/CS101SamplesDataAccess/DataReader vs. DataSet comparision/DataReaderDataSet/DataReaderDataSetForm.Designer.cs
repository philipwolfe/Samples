namespace DataReaderDataSet
{
	partial class dataReaderDataSetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dataReaderDataSetForm));
            this.testDataDataGridView = new System.Windows.Forms.DataGridView();
            this.testResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.rowsQueriedLabel = new System.Windows.Forms.Label();
            this.retrieveMethodLabel = new System.Windows.Forms.Label();
            this.stringsRadioButton = new System.Windows.Forms.RadioButton();
            this.runTestButton = new System.Windows.Forms.Button();
            this.testOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.iterations = new System.Windows.Forms.NumericUpDown();
            this.dataReaderRadioButton = new System.Windows.Forms.RadioButton();
            this.dataSetRadioButton = new System.Windows.Forms.RadioButton();
            this.rowsToQueryLabel = new System.Windows.Forms.Label();
            this.integersRadioButton = new System.Windows.Forms.RadioButton();
            this.dataRetrievedGroupBox = new System.Windows.Forms.GroupBox();
            this.testDataDataSet = new DataReaderDataSet.TestDataDataSet();
            this.IntegerDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.integerDataTableAdapter = new DataReaderDataSet.TestDataDataSetTableAdapters.IntegerDataTableAdapter();
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLineLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.testDataDataGridView)).BeginInit();
            this.testResultsGroupBox.SuspendLayout();
            this.testOptionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iterations)).BeginInit();
            this.dataRetrievedGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDataDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntegerDataBindingSource)).BeginInit();
            this.descriptionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // testDataDataGridView
            // 
            this.testDataDataGridView.AllowUserToAddRows = false;
            this.testDataDataGridView.AllowUserToDeleteRows = false;
            this.testDataDataGridView.BackgroundColor = System.Drawing.Color.Lavender;
            this.testDataDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Lavender;
            this.testDataDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.testDataDataGridView.Location = new System.Drawing.Point(28, 243);
            this.testDataDataGridView.Name = "testDataDataGridView";
            this.testDataDataGridView.ReadOnly = true;
            this.testDataDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.testDataDataGridView.Size = new System.Drawing.Size(516, 121);
            this.testDataDataGridView.TabIndex = 50;
            // 
            // testResultsGroupBox
            // 
            this.testResultsGroupBox.Controls.Add(this.elapsedTimeLabel);
            this.testResultsGroupBox.Controls.Add(this.rowsQueriedLabel);
            this.testResultsGroupBox.Controls.Add(this.retrieveMethodLabel);
            this.testResultsGroupBox.Location = new System.Drawing.Point(225, 116);
            this.testResultsGroupBox.Name = "testResultsGroupBox";
            this.testResultsGroupBox.Size = new System.Drawing.Size(189, 100);
            this.testResultsGroupBox.TabIndex = 52;
            this.testResultsGroupBox.TabStop = false;
            this.testResultsGroupBox.Text = "Test Results";
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Location = new System.Drawing.Point(6, 67);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(66, 13);
            this.elapsedTimeLabel.TabIndex = 2;
            this.elapsedTimeLabel.Text = "Elapsed time:";
            // 
            // rowsQueriedLabel
            // 
            this.rowsQueriedLabel.AutoSize = true;
            this.rowsQueriedLabel.Location = new System.Drawing.Point(6, 44);
            this.rowsQueriedLabel.Name = "rowsQueriedLabel";
            this.rowsQueriedLabel.Size = new System.Drawing.Size(73, 13);
            this.rowsQueriedLabel.TabIndex = 1;
            this.rowsQueriedLabel.Text = "Rows Queried:";
            // 
            // retrieveMethodLabel
            // 
            this.retrieveMethodLabel.AutoSize = true;
            this.retrieveMethodLabel.Location = new System.Drawing.Point(6, 21);
            this.retrieveMethodLabel.Name = "retrieveMethodLabel";
            this.retrieveMethodLabel.Size = new System.Drawing.Size(84, 13);
            this.retrieveMethodLabel.TabIndex = 0;
            this.retrieveMethodLabel.Text = "Retrieve method:";
            // 
            // stringsRadioButton
            // 
            this.stringsRadioButton.AutoSize = true;
            this.stringsRadioButton.Checked = true;
            this.stringsRadioButton.Location = new System.Drawing.Point(6, 19);
            this.stringsRadioButton.Name = "stringsRadioButton";
            this.stringsRadioButton.Size = new System.Drawing.Size(53, 17);
            this.stringsRadioButton.TabIndex = 0;
            this.stringsRadioButton.Text = "Strings";
            // 
            // runTestButton
            // 
            this.runTestButton.Location = new System.Drawing.Point(421, 177);
            this.runTestButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.runTestButton.Name = "runTestButton";
            this.runTestButton.Size = new System.Drawing.Size(130, 31);
            this.runTestButton.TabIndex = 49;
            this.runTestButton.Text = "Run Test";
            this.runTestButton.Click += new System.EventHandler(this.runTestButton_Click);
            // 
            // testOptionsGroupBox
            // 
            this.testOptionsGroupBox.Controls.Add(this.iterations);
            this.testOptionsGroupBox.Controls.Add(this.dataReaderRadioButton);
            this.testOptionsGroupBox.Controls.Add(this.dataSetRadioButton);
            this.testOptionsGroupBox.Controls.Add(this.rowsToQueryLabel);
            this.testOptionsGroupBox.Location = new System.Drawing.Point(40, 116);
            this.testOptionsGroupBox.Name = "testOptionsGroupBox";
            this.testOptionsGroupBox.Size = new System.Drawing.Size(178, 100);
            this.testOptionsGroupBox.TabIndex = 51;
            this.testOptionsGroupBox.TabStop = false;
            this.testOptionsGroupBox.Text = "Test Options";
            // 
            // iterations
            // 
            this.iterations.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.iterations.Location = new System.Drawing.Point(107, 19);
            this.iterations.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.iterations.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.iterations.Name = "iterations";
            this.iterations.ReadOnly = true;
            this.iterations.Size = new System.Drawing.Size(48, 20);
            this.iterations.TabIndex = 20;
            this.iterations.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // dataReaderRadioButton
            // 
            this.dataReaderRadioButton.AutoSize = true;
            this.dataReaderRadioButton.Checked = true;
            this.dataReaderRadioButton.Location = new System.Drawing.Point(23, 46);
            this.dataReaderRadioButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.dataReaderRadioButton.Name = "dataReaderRadioButton";
            this.dataReaderRadioButton.Size = new System.Drawing.Size(79, 17);
            this.dataReaderRadioButton.TabIndex = 25;
            this.dataReaderRadioButton.Text = "DataReader";
            // 
            // dataSetRadioButton
            // 
            this.dataSetRadioButton.AutoSize = true;
            this.dataSetRadioButton.Location = new System.Drawing.Point(23, 72);
            this.dataSetRadioButton.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.dataSetRadioButton.Name = "dataSetRadioButton";
            this.dataSetRadioButton.Size = new System.Drawing.Size(60, 17);
            this.dataSetRadioButton.TabIndex = 26;
            this.dataSetRadioButton.Text = "DataSet";
            // 
            // rowsToQueryLabel
            // 
            this.rowsToQueryLabel.AutoSize = true;
            this.rowsToQueryLabel.Location = new System.Drawing.Point(23, 21);
            this.rowsToQueryLabel.Name = "rowsToQueryLabel";
            this.rowsToQueryLabel.Size = new System.Drawing.Size(71, 13);
            this.rowsToQueryLabel.TabIndex = 31;
            this.rowsToQueryLabel.Text = "Rows to query";
            // 
            // integersRadioButton
            // 
            this.integersRadioButton.AutoSize = true;
            this.integersRadioButton.Location = new System.Drawing.Point(64, 19);
            this.integersRadioButton.Name = "integersRadioButton";
            this.integersRadioButton.Size = new System.Drawing.Size(59, 17);
            this.integersRadioButton.TabIndex = 1;
            this.integersRadioButton.Text = "Integers";
            // 
            // dataRetrievedGroupBox
            // 
            this.dataRetrievedGroupBox.Controls.Add(this.integersRadioButton);
            this.dataRetrievedGroupBox.Controls.Add(this.stringsRadioButton);
            this.dataRetrievedGroupBox.Location = new System.Drawing.Point(421, 116);
            this.dataRetrievedGroupBox.Name = "dataRetrievedGroupBox";
            this.dataRetrievedGroupBox.Size = new System.Drawing.Size(131, 42);
            this.dataRetrievedGroupBox.TabIndex = 53;
            this.dataRetrievedGroupBox.TabStop = false;
            this.dataRetrievedGroupBox.Text = "Data Retreived";
            // 
            // testDataDataSet
            // 
            this.testDataDataSet.DataSetName = "TestDataDataSet";
            // 
            // IntegerDataBindingSource
            // 
            this.IntegerDataBindingSource.DataMember = "IntegerData";
            this.IntegerDataBindingSource.DataSource = this.testDataDataSet;
            // 
            // integerDataTableAdapter
            // 
            this.integerDataTableAdapter.ClearBeforeFill = true;
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Controls.Add(this.descriptionLineLabel);
            this.descriptionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Size = new System.Drawing.Size(578, 76);
            this.descriptionGroupBox.TabIndex = 55;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "Description";
            // 
            // descriptionLineLabel
            // 
            this.descriptionLineLabel.AutoSize = true;
            this.descriptionLineLabel.Location = new System.Drawing.Point(6, 16);
            this.descriptionLineLabel.Name = "descriptionLineLabel";
            this.descriptionLineLabel.Size = new System.Drawing.Size(515, 39);
            this.descriptionLineLabel.TabIndex = 0;
            this.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text");
            // 
            // dataReaderDataSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 425);
            this.Controls.Add(this.descriptionGroupBox);
            this.Controls.Add(this.testOptionsGroupBox);
            this.Controls.Add(this.dataRetrievedGroupBox);
            this.Controls.Add(this.testDataDataGridView);
            this.Controls.Add(this.testResultsGroupBox);
            this.Controls.Add(this.runTestButton);
            this.Name = "dataReaderDataSetForm";
            this.Text = "DataReader vs DataSet";
            ((System.ComponentModel.ISupportInitialize)(this.testDataDataGridView)).EndInit();
            this.testResultsGroupBox.ResumeLayout(false);
            this.testResultsGroupBox.PerformLayout();
            this.testOptionsGroupBox.ResumeLayout(false);
            this.testOptionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iterations)).EndInit();
            this.dataRetrievedGroupBox.ResumeLayout(false);
            this.dataRetrievedGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDataDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntegerDataBindingSource)).EndInit();
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView testDataDataGridView;
		private System.Windows.Forms.GroupBox testResultsGroupBox;
		private System.Windows.Forms.Label elapsedTimeLabel;
		private System.Windows.Forms.Label rowsQueriedLabel;
		private System.Windows.Forms.Label retrieveMethodLabel;
		private System.Windows.Forms.RadioButton stringsRadioButton;
		private System.Windows.Forms.Button runTestButton;
		private System.Windows.Forms.GroupBox testOptionsGroupBox;
		private System.Windows.Forms.NumericUpDown iterations;
		private System.Windows.Forms.RadioButton dataReaderRadioButton;
		private System.Windows.Forms.RadioButton dataSetRadioButton;
		private System.Windows.Forms.Label rowsToQueryLabel;
		private System.Windows.Forms.RadioButton integersRadioButton;
		private System.Windows.Forms.GroupBox dataRetrievedGroupBox;
		private TestDataDataSet testDataDataSet;
		private System.Windows.Forms.BindingSource IntegerDataBindingSource;
		private DataReaderDataSet.TestDataDataSetTableAdapters.IntegerDataTableAdapter integerDataTableAdapter;
        private System.Windows.Forms.GroupBox descriptionGroupBox;
		private System.Windows.Forms.Label descriptionLineLabel;
	}
}


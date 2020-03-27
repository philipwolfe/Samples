namespace DataTableDataSet
{
	partial class dataTableDataSetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dataTableDataSetForm));
            this.dataTableDataSetTabControl = new System.Windows.Forms.TabControl();
            this.performanceTabPage = new System.Windows.Forms.TabPage();
            this.descriptionPerformanceGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLineLabel = new System.Windows.Forms.Label();
            this.testResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.rowsInsertedLabel = new System.Windows.Forms.Label();
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.performanceShowRowsButton = new System.Windows.Forms.Button();
            this.performanceAddRowsButton = new System.Windows.Forms.Button();
            this.readWriteTabPage = new System.Windows.Forms.TabPage();
            this.descriptionXMLGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLineXMLLabel = new System.Windows.Forms.Label();
            this.testResults2GroupBox = new System.Windows.Forms.GroupBox();
            this.readWriteTimeLabel = new System.Windows.Forms.Label();
            this.rowsReadWrittenLabel = new System.Windows.Forms.Label();
            this.xmlResultsDataGridView = new System.Windows.Forms.DataGridView();
            this.xmlReadButton = new System.Windows.Forms.Button();
            this.xmlWriteButton = new System.Windows.Forms.Button();
            this.dataViewsTabPage = new System.Windows.Forms.TabPage();
            this.descriptionDataViewGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionDataViewLabel = new System.Windows.Forms.Label();
            this.testResultsDataViewGroupBox = new System.Windows.Forms.GroupBox();
            this.rowsReturnedTimeLabel = new System.Windows.Forms.Label();
            this.rowsReturnedLabel = new System.Windows.Forms.Label();
            this.dataViewDataGridView = new System.Windows.Forms.DataGridView();
            this.dataViewShowDataViewButton = new System.Windows.Forms.Button();
            this.dataViewShowDataSetButton = new System.Windows.Forms.Button();
            this.dataTableDataSetTabControl.SuspendLayout();
            this.performanceTabPage.SuspendLayout();
            this.descriptionPerformanceGroupBox.SuspendLayout();
            this.testResultsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.readWriteTabPage.SuspendLayout();
            this.descriptionXMLGroupBox.SuspendLayout();
            this.testResults2GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xmlResultsDataGridView)).BeginInit();
            this.dataViewsTabPage.SuspendLayout();
            this.descriptionDataViewGroupBox.SuspendLayout();
            this.testResultsDataViewGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTableDataSetTabControl
            // 
            this.dataTableDataSetTabControl.Controls.Add(this.performanceTabPage);
            this.dataTableDataSetTabControl.Controls.Add(this.readWriteTabPage);
            this.dataTableDataSetTabControl.Controls.Add(this.dataViewsTabPage);
            this.dataTableDataSetTabControl.Location = new System.Drawing.Point(13, 13);
            this.dataTableDataSetTabControl.Name = "dataTableDataSetTabControl";
            this.dataTableDataSetTabControl.SelectedIndex = 0;
            this.dataTableDataSetTabControl.Size = new System.Drawing.Size(369, 388);
            this.dataTableDataSetTabControl.TabIndex = 0;
            // 
            // performanceTabPage
            // 
            this.performanceTabPage.Controls.Add(this.descriptionPerformanceGroupBox);
            this.performanceTabPage.Controls.Add(this.testResultsGroupBox);
            this.performanceTabPage.Controls.Add(this.resultsDataGridView);
            this.performanceTabPage.Controls.Add(this.performanceShowRowsButton);
            this.performanceTabPage.Controls.Add(this.performanceAddRowsButton);
            this.performanceTabPage.Location = new System.Drawing.Point(4, 22);
            this.performanceTabPage.Name = "performanceTabPage";
            this.performanceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.performanceTabPage.Size = new System.Drawing.Size(361, 362);
            this.performanceTabPage.TabIndex = 0;
            this.performanceTabPage.Text = "Performance";
            // 
            // descriptionPerformanceGroupBox
            // 
            this.descriptionPerformanceGroupBox.Controls.Add(this.descriptionLineLabel);
            this.descriptionPerformanceGroupBox.Location = new System.Drawing.Point(6, 3);
            this.descriptionPerformanceGroupBox.Name = "descriptionPerformanceGroupBox";
            this.descriptionPerformanceGroupBox.Size = new System.Drawing.Size(329, 91);
            this.descriptionPerformanceGroupBox.TabIndex = 5;
            this.descriptionPerformanceGroupBox.TabStop = false;
            this.descriptionPerformanceGroupBox.Text = "Description";
            // 
            // descriptionLineLabel
            // 
            this.descriptionLineLabel.AutoSize = true;
            this.descriptionLineLabel.Location = new System.Drawing.Point(6, 16);
            this.descriptionLineLabel.Name = "descriptionLineLabel";
            this.descriptionLineLabel.Size = new System.Drawing.Size(300, 52);
            this.descriptionLineLabel.TabIndex = 0;
            this.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text");
            // 
            // testResultsGroupBox
            // 
            this.testResultsGroupBox.Controls.Add(this.elapsedTimeLabel);
            this.testResultsGroupBox.Controls.Add(this.rowsInsertedLabel);
            this.testResultsGroupBox.Location = new System.Drawing.Point(19, 100);
            this.testResultsGroupBox.Name = "testResultsGroupBox";
            this.testResultsGroupBox.Size = new System.Drawing.Size(200, 78);
            this.testResultsGroupBox.TabIndex = 4;
            this.testResultsGroupBox.TabStop = false;
            this.testResultsGroupBox.Text = "Test Results";
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Location = new System.Drawing.Point(11, 46);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(66, 13);
            this.elapsedTimeLabel.TabIndex = 1;
            this.elapsedTimeLabel.Text = "Elapsed time:";
            // 
            // rowsInsertedLabel
            // 
            this.rowsInsertedLabel.AutoSize = true;
            this.rowsInsertedLabel.Location = new System.Drawing.Point(11, 18);
            this.rowsInsertedLabel.Name = "rowsInsertedLabel";
            this.rowsInsertedLabel.Size = new System.Drawing.Size(77, 13);
            this.rowsInsertedLabel.TabIndex = 0;
            this.rowsInsertedLabel.Text = "Rows Inserted: ";
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.Location = new System.Drawing.Point(19, 189);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.ReadOnly = true;
            this.resultsDataGridView.Size = new System.Drawing.Size(316, 150);
            this.resultsDataGridView.TabIndex = 3;
            this.resultsDataGridView.Text = "dataGridView1";
            // 
            // performanceShowRowsButton
            // 
            this.performanceShowRowsButton.Location = new System.Drawing.Point(260, 146);
            this.performanceShowRowsButton.Name = "performanceShowRowsButton";
            this.performanceShowRowsButton.Size = new System.Drawing.Size(75, 23);
            this.performanceShowRowsButton.TabIndex = 2;
            this.performanceShowRowsButton.Text = "Show Rows";
            this.performanceShowRowsButton.Click += new System.EventHandler(this.performanceShowRowsButton_Click);
            // 
            // performanceAddRowsButton
            // 
            this.performanceAddRowsButton.Location = new System.Drawing.Point(260, 100);
            this.performanceAddRowsButton.Name = "performanceAddRowsButton";
            this.performanceAddRowsButton.Size = new System.Drawing.Size(75, 23);
            this.performanceAddRowsButton.TabIndex = 1;
            this.performanceAddRowsButton.Text = "Add Rows";
            this.performanceAddRowsButton.Click += new System.EventHandler(this.performanceAddRowsButton_Click);
            // 
            // readWriteTabPage
            // 
            this.readWriteTabPage.Controls.Add(this.descriptionXMLGroupBox);
            this.readWriteTabPage.Controls.Add(this.testResults2GroupBox);
            this.readWriteTabPage.Controls.Add(this.xmlResultsDataGridView);
            this.readWriteTabPage.Controls.Add(this.xmlReadButton);
            this.readWriteTabPage.Controls.Add(this.xmlWriteButton);
            this.readWriteTabPage.Location = new System.Drawing.Point(4, 22);
            this.readWriteTabPage.Name = "readWriteTabPage";
            this.readWriteTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.readWriteTabPage.Size = new System.Drawing.Size(361, 362);
            this.readWriteTabPage.TabIndex = 1;
            this.readWriteTabPage.Text = "Read/Write XML";
            // 
            // descriptionXMLGroupBox
            // 
            this.descriptionXMLGroupBox.Controls.Add(this.descriptionLineXMLLabel);
            this.descriptionXMLGroupBox.Location = new System.Drawing.Point(16, 13);
            this.descriptionXMLGroupBox.Name = "descriptionXMLGroupBox";
            this.descriptionXMLGroupBox.Size = new System.Drawing.Size(339, 91);
            this.descriptionXMLGroupBox.TabIndex = 10;
            this.descriptionXMLGroupBox.TabStop = false;
            this.descriptionXMLGroupBox.Text = "Description";
            // 
            // descriptionLineXMLLabel
            // 
            this.descriptionLineXMLLabel.AutoSize = true;
            this.descriptionLineXMLLabel.Location = new System.Drawing.Point(4, 16);
            this.descriptionLineXMLLabel.Name = "descriptionLineXMLLabel";
            this.descriptionLineXMLLabel.Size = new System.Drawing.Size(328, 52);
            this.descriptionLineXMLLabel.TabIndex = 0;
            this.descriptionLineXMLLabel.Text = resources.GetString("descriptionLineXMLLabel.Text");
            // 
            // testResults2GroupBox
            // 
            this.testResults2GroupBox.Controls.Add(this.readWriteTimeLabel);
            this.testResults2GroupBox.Controls.Add(this.rowsReadWrittenLabel);
            this.testResults2GroupBox.Location = new System.Drawing.Point(29, 110);
            this.testResults2GroupBox.Name = "testResults2GroupBox";
            this.testResults2GroupBox.Size = new System.Drawing.Size(200, 78);
            this.testResults2GroupBox.TabIndex = 9;
            this.testResults2GroupBox.TabStop = false;
            this.testResults2GroupBox.Text = "Test Results";
            // 
            // readWriteTimeLabel
            // 
            this.readWriteTimeLabel.AutoSize = true;
            this.readWriteTimeLabel.Location = new System.Drawing.Point(11, 46);
            this.readWriteTimeLabel.Name = "readWriteTimeLabel";
            this.readWriteTimeLabel.Size = new System.Drawing.Size(75, 13);
            this.readWriteTimeLabel.TabIndex = 1;
            this.readWriteTimeLabel.Text = "Time Required:";
            // 
            // rowsReadWrittenLabel
            // 
            this.rowsReadWrittenLabel.AutoSize = true;
            this.rowsReadWrittenLabel.Location = new System.Drawing.Point(11, 18);
            this.rowsReadWrittenLabel.Name = "rowsReadWrittenLabel";
            this.rowsReadWrittenLabel.Size = new System.Drawing.Size(104, 13);
            this.rowsReadWrittenLabel.TabIndex = 0;
            this.rowsReadWrittenLabel.Text = "Rows Read/Written: ";
            // 
            // xmlResultsDataGridView
            // 
            this.xmlResultsDataGridView.Location = new System.Drawing.Point(29, 199);
            this.xmlResultsDataGridView.Name = "xmlResultsDataGridView";
            this.xmlResultsDataGridView.ReadOnly = true;
            this.xmlResultsDataGridView.Size = new System.Drawing.Size(316, 150);
            this.xmlResultsDataGridView.TabIndex = 8;
            this.xmlResultsDataGridView.Text = "dataGridView2";
            // 
            // xmlReadButton
            // 
            this.xmlReadButton.Location = new System.Drawing.Point(270, 156);
            this.xmlReadButton.Name = "xmlReadButton";
            this.xmlReadButton.Size = new System.Drawing.Size(75, 23);
            this.xmlReadButton.TabIndex = 7;
            this.xmlReadButton.Text = "Read XML";
            this.xmlReadButton.Click += new System.EventHandler(this.xmlReadButton_Click);
            // 
            // xmlWriteButton
            // 
            this.xmlWriteButton.Location = new System.Drawing.Point(270, 110);
            this.xmlWriteButton.Name = "xmlWriteButton";
            this.xmlWriteButton.Size = new System.Drawing.Size(75, 23);
            this.xmlWriteButton.TabIndex = 6;
            this.xmlWriteButton.Text = "Write XML";
            this.xmlWriteButton.Click += new System.EventHandler(this.xmlWriteButton_Click);
            // 
            // dataViewsTabPage
            // 
            this.dataViewsTabPage.Controls.Add(this.descriptionDataViewGroupBox);
            this.dataViewsTabPage.Controls.Add(this.testResultsDataViewGroupBox);
            this.dataViewsTabPage.Controls.Add(this.dataViewDataGridView);
            this.dataViewsTabPage.Controls.Add(this.dataViewShowDataViewButton);
            this.dataViewsTabPage.Controls.Add(this.dataViewShowDataSetButton);
            this.dataViewsTabPage.Location = new System.Drawing.Point(4, 22);
            this.dataViewsTabPage.Name = "dataViewsTabPage";
            this.dataViewsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.dataViewsTabPage.Size = new System.Drawing.Size(361, 362);
            this.dataViewsTabPage.TabIndex = 2;
            this.dataViewsTabPage.Text = "Data Views";
            // 
            // descriptionDataViewGroupBox
            // 
            this.descriptionDataViewGroupBox.Controls.Add(this.descriptionDataViewLabel);
            this.descriptionDataViewGroupBox.Location = new System.Drawing.Point(16, 13);
            this.descriptionDataViewGroupBox.Name = "descriptionDataViewGroupBox";
            this.descriptionDataViewGroupBox.Size = new System.Drawing.Size(329, 91);
            this.descriptionDataViewGroupBox.TabIndex = 10;
            this.descriptionDataViewGroupBox.TabStop = false;
            this.descriptionDataViewGroupBox.Text = "Description";
            // 
            // descriptionDataViewLabel
            // 
            this.descriptionDataViewLabel.AutoSize = true;
            this.descriptionDataViewLabel.Location = new System.Drawing.Point(6, 16);
            this.descriptionDataViewLabel.Name = "descriptionDataViewLabel";
            this.descriptionDataViewLabel.Size = new System.Drawing.Size(299, 52);
            this.descriptionDataViewLabel.TabIndex = 0;
            this.descriptionDataViewLabel.Text = "This tab shows how you can use the DataView class to display\r\na logical view of a" +
                " DataTable.\r\nClick DataSet to view the original DataTable in the DataSet.\r\nClick" +
                " DataView to view the new DataTable.";
            // 
            // testResultsDataViewGroupBox
            // 
            this.testResultsDataViewGroupBox.Controls.Add(this.rowsReturnedTimeLabel);
            this.testResultsDataViewGroupBox.Controls.Add(this.rowsReturnedLabel);
            this.testResultsDataViewGroupBox.Location = new System.Drawing.Point(29, 110);
            this.testResultsDataViewGroupBox.Name = "testResultsDataViewGroupBox";
            this.testResultsDataViewGroupBox.Size = new System.Drawing.Size(200, 78);
            this.testResultsDataViewGroupBox.TabIndex = 9;
            this.testResultsDataViewGroupBox.TabStop = false;
            this.testResultsDataViewGroupBox.Text = "Test Results";
            // 
            // rowsReturnedTimeLabel
            // 
            this.rowsReturnedTimeLabel.AutoSize = true;
            this.rowsReturnedTimeLabel.Location = new System.Drawing.Point(11, 46);
            this.rowsReturnedTimeLabel.Name = "rowsReturnedTimeLabel";
            this.rowsReturnedTimeLabel.Size = new System.Drawing.Size(75, 13);
            this.rowsReturnedTimeLabel.TabIndex = 1;
            this.rowsReturnedTimeLabel.Text = "Time Required:";
            // 
            // rowsReturnedLabel
            // 
            this.rowsReturnedLabel.AutoSize = true;
            this.rowsReturnedLabel.Location = new System.Drawing.Point(11, 18);
            this.rowsReturnedLabel.Name = "rowsReturnedLabel";
            this.rowsReturnedLabel.Size = new System.Drawing.Size(83, 13);
            this.rowsReturnedLabel.TabIndex = 0;
            this.rowsReturnedLabel.Text = "Rows Returned: ";
            // 
            // dataViewDataGridView
            // 
            this.dataViewDataGridView.Location = new System.Drawing.Point(29, 199);
            this.dataViewDataGridView.Name = "dataViewDataGridView";
            this.dataViewDataGridView.ReadOnly = true;
            this.dataViewDataGridView.Size = new System.Drawing.Size(316, 150);
            this.dataViewDataGridView.TabIndex = 8;
            this.dataViewDataGridView.Text = "dataGridView3";
            // 
            // dataViewShowDataViewButton
            // 
            this.dataViewShowDataViewButton.Location = new System.Drawing.Point(270, 156);
            this.dataViewShowDataViewButton.Name = "dataViewShowDataViewButton";
            this.dataViewShowDataViewButton.Size = new System.Drawing.Size(75, 23);
            this.dataViewShowDataViewButton.TabIndex = 7;
            this.dataViewShowDataViewButton.Text = "DataView";
            this.dataViewShowDataViewButton.Click += new System.EventHandler(this.dataViewShowDataView_Click);
            // 
            // dataViewShowDataSetButton
            // 
            this.dataViewShowDataSetButton.Location = new System.Drawing.Point(270, 110);
            this.dataViewShowDataSetButton.Name = "dataViewShowDataSetButton";
            this.dataViewShowDataSetButton.Size = new System.Drawing.Size(75, 23);
            this.dataViewShowDataSetButton.TabIndex = 6;
            this.dataViewShowDataSetButton.Text = "DataSet";
            this.dataViewShowDataSetButton.Click += new System.EventHandler(this.dataViewShowDataSetButton_Click);
            // 
            // dataTableDataSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 413);
            this.Controls.Add(this.dataTableDataSetTabControl);
            this.Name = "dataTableDataSetForm";
            this.Text = "DataTable and DataSet Enhancements";
            this.dataTableDataSetTabControl.ResumeLayout(false);
            this.performanceTabPage.ResumeLayout(false);
            this.descriptionPerformanceGroupBox.ResumeLayout(false);
            this.descriptionPerformanceGroupBox.PerformLayout();
            this.testResultsGroupBox.ResumeLayout(false);
            this.testResultsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.readWriteTabPage.ResumeLayout(false);
            this.descriptionXMLGroupBox.ResumeLayout(false);
            this.descriptionXMLGroupBox.PerformLayout();
            this.testResults2GroupBox.ResumeLayout(false);
            this.testResults2GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xmlResultsDataGridView)).EndInit();
            this.dataViewsTabPage.ResumeLayout(false);
            this.descriptionDataViewGroupBox.ResumeLayout(false);
            this.descriptionDataViewGroupBox.PerformLayout();
            this.testResultsDataViewGroupBox.ResumeLayout(false);
            this.testResultsDataViewGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewDataGridView)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl dataTableDataSetTabControl;
		private System.Windows.Forms.TabPage performanceTabPage;
		private System.Windows.Forms.TabPage readWriteTabPage;
		private System.Windows.Forms.TabPage dataViewsTabPage;
		private System.Windows.Forms.DataGridView resultsDataGridView;
		private System.Windows.Forms.Button performanceShowRowsButton;
		private System.Windows.Forms.Button performanceAddRowsButton;
		private System.Windows.Forms.GroupBox descriptionPerformanceGroupBox;
        private System.Windows.Forms.GroupBox testResultsGroupBox;
        private System.Windows.Forms.Label descriptionLineLabel;
		private System.Windows.Forms.Label elapsedTimeLabel;
		private System.Windows.Forms.Label rowsInsertedLabel;
        private System.Windows.Forms.GroupBox descriptionXMLGroupBox;
		private System.Windows.Forms.Label descriptionLineXMLLabel;
		private System.Windows.Forms.GroupBox testResults2GroupBox;
		private System.Windows.Forms.Label readWriteTimeLabel;
		private System.Windows.Forms.Label rowsReadWrittenLabel;
		private System.Windows.Forms.DataGridView xmlResultsDataGridView;
		private System.Windows.Forms.Button xmlReadButton;
		private System.Windows.Forms.Button xmlWriteButton;
        private System.Windows.Forms.GroupBox descriptionDataViewGroupBox;
		private System.Windows.Forms.Label descriptionDataViewLabel;
		private System.Windows.Forms.GroupBox testResultsDataViewGroupBox;
		private System.Windows.Forms.Label rowsReturnedTimeLabel;
		private System.Windows.Forms.Label rowsReturnedLabel;
		private System.Windows.Forms.DataGridView dataViewDataGridView;
		private System.Windows.Forms.Button dataViewShowDataViewButton;
		private System.Windows.Forms.Button dataViewShowDataSetButton;
	}
}


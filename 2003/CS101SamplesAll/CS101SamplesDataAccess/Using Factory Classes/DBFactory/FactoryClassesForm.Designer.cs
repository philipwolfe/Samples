namespace DBFactory
{
	partial class factoryClassesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(factoryClassesForm));
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLinesLabel = new System.Windows.Forms.Label();
            this.displayDataGridView = new System.Windows.Forms.DataGridView();
            this.providerComboBox = new System.Windows.Forms.ComboBox();
            this.getDataButton = new System.Windows.Forms.Button();
            this.testResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.connectionStringLabel = new System.Windows.Forms.Label();
            this.connectionStringTextLabel = new System.Windows.Forms.Label();
            this.providerNameLabel = new System.Windows.Forms.Label();
            this.providerLabel = new System.Windows.Forms.Label();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.elapsedTimeTextLabel = new System.Windows.Forms.Label();
            this.chooseDBLabel = new System.Windows.Forms.Label();
            this.descriptionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayDataGridView)).BeginInit();
            this.testResultsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Controls.Add(this.descriptionLinesLabel);
            this.descriptionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Size = new System.Drawing.Size(666, 100);
            this.descriptionGroupBox.TabIndex = 0;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "Description";
            // 
            // descriptionLinesLabel
            // 
            this.descriptionLinesLabel.AutoSize = true;
            this.descriptionLinesLabel.Location = new System.Drawing.Point(6, 16);
            this.descriptionLinesLabel.Name = "descriptionLinesLabel";
            this.descriptionLinesLabel.Size = new System.Drawing.Size(565, 78);
            this.descriptionLinesLabel.TabIndex = 0;
            this.descriptionLinesLabel.Text = resources.GetString("descriptionLinesLabel.Text");
            // 
            // displayDataGridView
            // 
            this.displayDataGridView.Location = new System.Drawing.Point(147, 118);
            this.displayDataGridView.Name = "displayDataGridView";
            this.displayDataGridView.ReadOnly = true;
            this.displayDataGridView.Size = new System.Drawing.Size(509, 99);
            this.displayDataGridView.TabIndex = 1;
            this.displayDataGridView.Text = "dataGridView1";
            // 
            // providerComboBox
            // 
            this.providerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.providerComboBox.FormattingEnabled = true;
            this.providerComboBox.Items.AddRange(new object[] {
            "SQL Server",
            "MS Access"});
            this.providerComboBox.Location = new System.Drawing.Point(12, 149);
            this.providerComboBox.Name = "providerComboBox";
            this.providerComboBox.Size = new System.Drawing.Size(121, 21);
            this.providerComboBox.TabIndex = 3;
            // 
            // getDataButton
            // 
            this.getDataButton.Location = new System.Drawing.Point(33, 183);
            this.getDataButton.Name = "getDataButton";
            this.getDataButton.Size = new System.Drawing.Size(75, 23);
            this.getDataButton.TabIndex = 4;
            this.getDataButton.Text = "Get Data";
            this.getDataButton.Click += new System.EventHandler(this.getDataButton_Click);
            // 
            // testResultsGroupBox
            // 
            this.testResultsGroupBox.Controls.Add(this.connectionStringLabel);
            this.testResultsGroupBox.Controls.Add(this.connectionStringTextLabel);
            this.testResultsGroupBox.Controls.Add(this.providerNameLabel);
            this.testResultsGroupBox.Controls.Add(this.providerLabel);
            this.testResultsGroupBox.Controls.Add(this.elapsedTimeLabel);
            this.testResultsGroupBox.Controls.Add(this.elapsedTimeTextLabel);
            this.testResultsGroupBox.Location = new System.Drawing.Point(5, 221);
            this.testResultsGroupBox.Name = "testResultsGroupBox";
            this.testResultsGroupBox.Size = new System.Drawing.Size(677, 153);
            this.testResultsGroupBox.TabIndex = 5;
            this.testResultsGroupBox.TabStop = false;
            this.testResultsGroupBox.Text = "Test Results";
            // 
            // connectionStringLabel
            // 
            this.connectionStringLabel.AutoEllipsis = false;
            this.connectionStringLabel.AutoSize = false;
            this.connectionStringLabel.Location = new System.Drawing.Point(10, 120);
            this.connectionStringLabel.Name = "connectionStringLabel";
            this.connectionStringLabel.Size = new System.Drawing.Size(600, 30);
            this.connectionStringLabel.TabIndex = 5;
            // 
            // connectionStringTextLabel
            // 
            this.connectionStringTextLabel.AutoSize = true;
            this.connectionStringTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionStringTextLabel.Location = new System.Drawing.Point(26, 96);
            this.connectionStringTextLabel.Name = "connectionStringTextLabel";
            this.connectionStringTextLabel.Size = new System.Drawing.Size(112, 13);
            this.connectionStringTextLabel.TabIndex = 4;
            this.connectionStringTextLabel.Text = "Connection String:";
            // 
            // providerNameLabel
            // 
            this.providerNameLabel.AutoSize = true;
            this.providerNameLabel.Location = new System.Drawing.Point(6, 51);
            this.providerNameLabel.Name = "providerNameLabel";
            this.providerNameLabel.Size = new System.Drawing.Size(0, 13);
            this.providerNameLabel.TabIndex = 3;
            // 
            // providerLabel
            // 
            this.providerLabel.AutoSize = true;
            this.providerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.providerLabel.Location = new System.Drawing.Point(25, 30);
            this.providerLabel.Name = "providerLabel";
            this.providerLabel.Size = new System.Drawing.Size(58, 13);
            this.providerLabel.TabIndex = 2;
            this.providerLabel.Text = "Provider:";
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Location = new System.Drawing.Point(198, 51);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.elapsedTimeLabel.TabIndex = 1;
            // 
            // elapsedTimeTextLabel
            // 
            this.elapsedTimeTextLabel.AutoSize = true;
            this.elapsedTimeTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elapsedTimeTextLabel.Location = new System.Drawing.Point(25, 63);
            this.elapsedTimeTextLabel.Name = "elapsedTimeTextLabel";
            this.elapsedTimeTextLabel.Size = new System.Drawing.Size(87, 13);
            this.elapsedTimeTextLabel.TabIndex = 0;
            this.elapsedTimeTextLabel.Text = "Elapsed Time:";
            // 
            // chooseDBLabel
            // 
            this.chooseDBLabel.AutoSize = true;
            this.chooseDBLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseDBLabel.Location = new System.Drawing.Point(11, 126);
            this.chooseDBLabel.Name = "chooseDBLabel";
            this.chooseDBLabel.Size = new System.Drawing.Size(107, 17);
            this.chooseDBLabel.TabIndex = 0;
            this.chooseDBLabel.Text = "Choose a DB:";
            // 
            // factoryClassesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 389);
            this.Controls.Add(this.chooseDBLabel);
            this.Controls.Add(this.getDataButton);
            this.Controls.Add(this.providerComboBox);
            this.Controls.Add(this.displayDataGridView);
            this.Controls.Add(this.descriptionGroupBox);
            this.Controls.Add(this.testResultsGroupBox);
            this.Name = "factoryClassesForm";
            this.Text = "DbFactory Class Example";
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayDataGridView)).EndInit();
            this.testResultsGroupBox.ResumeLayout(false);
            this.testResultsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox descriptionGroupBox;
		private System.Windows.Forms.DataGridView displayDataGridView;
		private System.Windows.Forms.ComboBox providerComboBox;
		private System.Windows.Forms.Button getDataButton;
		private System.Windows.Forms.GroupBox testResultsGroupBox;
		private System.Windows.Forms.Label elapsedTimeLabel;
		private System.Windows.Forms.Label elapsedTimeTextLabel;
		private System.Windows.Forms.Label connectionStringLabel;
		private System.Windows.Forms.Label connectionStringTextLabel;
		private System.Windows.Forms.Label providerNameLabel;
		private System.Windows.Forms.Label providerLabel;
		private System.Windows.Forms.Label chooseDBLabel;
		private System.Windows.Forms.Label descriptionLinesLabel;
	}
}


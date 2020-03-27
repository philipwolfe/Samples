namespace QueryNotification
{
    partial class NotificationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationForm));
            this.updateButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLineLabel = new System.Windows.Forms.Label();
            this.testResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.actionLabel = new System.Windows.Forms.Label();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.enterIntegerValueLabel = new System.Windows.Forms.Label();
            this.value1TextBox = new System.Windows.Forms.TextBox();
            this.updateComboBox = new System.Windows.Forms.ComboBox();
            this.chooseIDLabel = new System.Windows.Forms.Label();
            this.IDTextLabel = new System.Windows.Forms.Label();
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.descriptionGroupBox.SuspendLayout();
            this.testResultsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(35, 271);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(129, 23);
            this.updateButton.TabIndex = 1;
            this.updateButton.Text = "Update Data";
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(35, 197);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(129, 23);
            this.insertButton.TabIndex = 2;
            this.insertButton.Text = "Insert Data";
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Controls.Add(this.descriptionLineLabel);
            this.descriptionGroupBox.Location = new System.Drawing.Point(35, 12);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Size = new System.Drawing.Size(500, 121);
            this.descriptionGroupBox.TabIndex = 3;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "Description";
            // 
            // descriptionLineLabel
            // 
            this.descriptionLineLabel.AutoSize = true;
            this.descriptionLineLabel.Location = new System.Drawing.Point(6, 16);
            this.descriptionLineLabel.Name = "descriptionLineLabel";
            this.descriptionLineLabel.Size = new System.Drawing.Size(434, 91);
            this.descriptionLineLabel.TabIndex = 0;
            this.descriptionLineLabel.Text = resources.GetString("descriptionLineLabel.Text");
            // 
            // testResultsGroupBox
            // 
            this.testResultsGroupBox.Controls.Add(this.actionLabel);
            this.testResultsGroupBox.Controls.Add(this.elapsedTimeLabel);
            this.testResultsGroupBox.Location = new System.Drawing.Point(186, 155);
            this.testResultsGroupBox.Name = "testResultsGroupBox";
            this.testResultsGroupBox.Size = new System.Drawing.Size(151, 180);
            this.testResultsGroupBox.TabIndex = 4;
            this.testResultsGroupBox.TabStop = false;
            this.testResultsGroupBox.Text = "Test Results";
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionLabel.Location = new System.Drawing.Point(6, 68);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(43, 13);
            this.actionLabel.TabIndex = 1;
            this.actionLabel.Text = "Action:";
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elapsedTimeLabel.Location = new System.Drawing.Point(6, 23);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(83, 13);
            this.elapsedTimeLabel.TabIndex = 0;
            this.elapsedTimeLabel.Text = "Elapsed Time:";
            // 
            // enterIntegerValueLabel
            // 
            this.enterIntegerValueLabel.AutoSize = true;
            this.enterIntegerValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterIntegerValueLabel.Location = new System.Drawing.Point(34, 155);
            this.enterIntegerValueLabel.Name = "enterIntegerValueLabel";
            this.enterIntegerValueLabel.Size = new System.Drawing.Size(135, 13);
            this.enterIntegerValueLabel.TabIndex = 0;
            this.enterIntegerValueLabel.Text = "Enter an Integer Value:";
            // 
            // value1TextBox
            // 
            this.value1TextBox.Location = new System.Drawing.Point(35, 171);
            this.value1TextBox.Name = "value1TextBox";
            this.value1TextBox.Size = new System.Drawing.Size(57, 20);
            this.value1TextBox.TabIndex = 1;
            // 
            // updateComboBox
            // 
            this.updateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.updateComboBox.FormattingEnabled = true;
            this.updateComboBox.Location = new System.Drawing.Point(64, 244);
            this.updateComboBox.Name = "updateComboBox";
            this.updateComboBox.Size = new System.Drawing.Size(56, 21);
            this.updateComboBox.TabIndex = 1;
            // 
            // chooseIDLabel
            // 
            this.chooseIDLabel.AutoSize = true;
            this.chooseIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseIDLabel.Location = new System.Drawing.Point(35, 223);
            this.chooseIDLabel.Name = "chooseIDLabel";
            this.chooseIDLabel.Size = new System.Drawing.Size(144, 13);
            this.chooseIDLabel.TabIndex = 1;
            this.chooseIDLabel.Text = "Choose an ID to Update:";
            // 
            // IDTextLabel
            // 
            this.IDTextLabel.AutoSize = true;
            this.IDTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDTextLabel.Location = new System.Drawing.Point(38, 246);
            this.IDTextLabel.Name = "IDTextLabel";
            this.IDTextLabel.Size = new System.Drawing.Size(20, 13);
            this.IDTextLabel.TabIndex = 0;
            this.IDTextLabel.Text = "ID:";
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.Location = new System.Drawing.Point(344, 155);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.ReadOnly = true;
            this.resultsDataGridView.Size = new System.Drawing.Size(191, 180);
            this.resultsDataGridView.TabIndex = 5;
            this.resultsDataGridView.Text = "dataGridView1";
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 355);
            this.Controls.Add(this.resultsDataGridView);
            this.Controls.Add(this.IDTextLabel);
            this.Controls.Add(this.chooseIDLabel);
            this.Controls.Add(this.updateComboBox);
            this.Controls.Add(this.value1TextBox);
            this.Controls.Add(this.enterIntegerValueLabel);
            this.Controls.Add(this.testResultsGroupBox);
            this.Controls.Add(this.descriptionGroupBox);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.updateButton);
            this.Name = "NotificationForm";
            this.Text = "SQL Notification Services Example";
            this.Load += new System.EventHandler(this.NotificationForm_Load);
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            this.testResultsGroupBox.ResumeLayout(false);
            this.testResultsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.GroupBox descriptionGroupBox;
        private System.Windows.Forms.GroupBox testResultsGroupBox;
        private System.Windows.Forms.Label enterIntegerValueLabel;
        private System.Windows.Forms.TextBox value1TextBox;
        private System.Windows.Forms.ComboBox updateComboBox;
        private System.Windows.Forms.Label chooseIDLabel;
        private System.Windows.Forms.Label IDTextLabel;
        private System.Windows.Forms.DataGridView resultsDataGridView;
        private System.Windows.Forms.Label descriptionLineLabel;
        private System.Windows.Forms.Label elapsedTimeLabel;
        private System.Windows.Forms.Label actionLabel;
    }
}


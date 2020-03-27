namespace XMLDataType
{
	partial class xmlDataTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xmlDataTypeForm));
            this.insertDataButton = new System.Windows.Forms.Button();
            this.schemaDataGridView = new System.Windows.Forms.DataGridView();
            this.showDataButton = new System.Windows.Forms.Button();
            this.collectionListComboBox = new System.Windows.Forms.ComboBox();
            this.showDefinitionButton = new System.Windows.Forms.Button();
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLine1Label = new System.Windows.Forms.Label();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.displayDataLabel = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.definitionLabel = new System.Windows.Forms.Label();
            this.dataLabel = new System.Windows.Forms.Label();
            this.dataRichTextBox = new System.Windows.Forms.RichTextBox();
            this.withoutMarkupRadioButton = new System.Windows.Forms.RadioButton();
            this.withMarkupRadioButton = new System.Windows.Forms.RadioButton();
            this.chooseCategoryLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.schemaDataGridView)).BeginInit();
            this.descriptionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // insertDataButton
            // 
            this.insertDataButton.Location = new System.Drawing.Point(28, 170);
            this.insertDataButton.Name = "insertDataButton";
            this.insertDataButton.Size = new System.Drawing.Size(75, 23);
            this.insertDataButton.TabIndex = 0;
            this.insertDataButton.Text = "Insert Data";
            this.insertDataButton.Click += new System.EventHandler(this.insertDataButton_Click);
            // 
            // schemaDataGridView
            // 
            this.schemaDataGridView.Location = new System.Drawing.Point(216, 148);
            this.schemaDataGridView.Name = "schemaDataGridView";
            this.schemaDataGridView.ReadOnly = true;
            this.schemaDataGridView.Size = new System.Drawing.Size(244, 150);
            this.schemaDataGridView.TabIndex = 1;
            this.schemaDataGridView.Text = "dataGridView1";
            // 
            // showDataButton
            // 
            this.showDataButton.Location = new System.Drawing.Point(12, 299);
            this.showDataButton.Name = "showDataButton";
            this.showDataButton.Size = new System.Drawing.Size(75, 23);
            this.showDataButton.TabIndex = 2;
            this.showDataButton.Text = "Show Data";
            this.showDataButton.Click += new System.EventHandler(this.showDataButton_Click);
            // 
            // collectionListComboBox
            // 
            this.collectionListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.collectionListComboBox.FormattingEnabled = true;
            this.collectionListComboBox.Location = new System.Drawing.Point(12, 135);
            this.collectionListComboBox.Name = "collectionListComboBox";
            this.collectionListComboBox.Size = new System.Drawing.Size(121, 21);
            this.collectionListComboBox.TabIndex = 3;
            // 
            // showDefinitionButton
            // 
            this.showDefinitionButton.Location = new System.Drawing.Point(12, 257);
            this.showDefinitionButton.Name = "showDefinitionButton";
            this.showDefinitionButton.Size = new System.Drawing.Size(127, 23);
            this.showDefinitionButton.TabIndex = 4;
            this.showDefinitionButton.Text = "Show Table Definition";
            this.showDefinitionButton.Click += new System.EventHandler(this.showDefinitionButton_Click);
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Controls.Add(this.descriptionLine1Label);
            this.descriptionGroupBox.Location = new System.Drawing.Point(27, 13);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Size = new System.Drawing.Size(642, 95);
            this.descriptionGroupBox.TabIndex = 5;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "Description";
            // 
            // descriptionLine1Label
            // 
            this.descriptionLine1Label.AutoSize = true;
            this.descriptionLine1Label.Location = new System.Drawing.Point(6, 16);
            this.descriptionLine1Label.Name = "descriptionLine1Label";
            this.descriptionLine1Label.Size = new System.Drawing.Size(585, 65);
            this.descriptionLine1Label.TabIndex = 0;
            this.descriptionLine1Label.Text = resources.GetString("descriptionLine1Label.Text");
            // 
            // resultsLabel
            // 
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultsLabel.Location = new System.Drawing.Point(212, 123);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(75, 20);
            this.resultsLabel.TabIndex = 6;
            this.resultsLabel.Text = "Results:";
            // 
            // displayDataLabel
            // 
            this.displayDataLabel.AutoSize = true;
            this.displayDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayDataLabel.Location = new System.Drawing.Point(12, 212);
            this.displayDataLabel.Name = "displayDataLabel";
            this.displayDataLabel.Size = new System.Drawing.Size(147, 20);
            this.displayDataLabel.TabIndex = 7;
            this.displayDataLabel.Text = "Display the Data:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(556, 148);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(65, 29);
            this.webBrowser1.TabIndex = 17;
            // 
            // definitionLabel
            // 
            this.definitionLabel.AutoSize = true;
            this.definitionLabel.Location = new System.Drawing.Point(390, 130);
            this.definitionLabel.Name = "definitionLabel";
            this.definitionLabel.Size = new System.Drawing.Size(79, 13);
            this.definitionLabel.TabIndex = 10;
            this.definitionLabel.Text = "Definition/Data";
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(643, 130);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(30, 13);
            this.dataLabel.TabIndex = 11;
            this.dataLabel.Text = "Data";
            // 
            // dataRichTextBox
            // 
            this.dataRichTextBox.Location = new System.Drawing.Point(467, 148);
            this.dataRichTextBox.Name = "dataRichTextBox";
            this.dataRichTextBox.ReadOnly = true;
            this.dataRichTextBox.Size = new System.Drawing.Size(202, 150);
            this.dataRichTextBox.TabIndex = 12;
            this.dataRichTextBox.Text = "";
            // 
            // withoutMarkupRadioButton
            // 
            this.withoutMarkupRadioButton.AutoSize = true;
            this.withoutMarkupRadioButton.Checked = true;
            this.withoutMarkupRadioButton.Location = new System.Drawing.Point(508, 305);
            this.withoutMarkupRadioButton.Name = "withoutMarkupRadioButton";
            this.withoutMarkupRadioButton.Size = new System.Drawing.Size(88, 17);
            this.withoutMarkupRadioButton.TabIndex = 14;
            this.withoutMarkupRadioButton.TabStop = true;
            this.withoutMarkupRadioButton.Text = "W/O Markup";
            this.withoutMarkupRadioButton.CheckedChanged += new System.EventHandler(this.withoutMarkup_CheckedChanged);
            // 
            // withMarkupRadioButton
            // 
            this.withMarkupRadioButton.AutoSize = true;
            this.withMarkupRadioButton.Location = new System.Drawing.Point(596, 305);
            this.withMarkupRadioButton.Name = "withMarkupRadioButton";
            this.withMarkupRadioButton.Size = new System.Drawing.Size(86, 17);
            this.withMarkupRadioButton.TabIndex = 15;
            this.withMarkupRadioButton.Text = "With Markup";
            this.withMarkupRadioButton.CheckedChanged += new System.EventHandler(this.withMarkup_CheckedChanged);
            // 
            // chooseCategoryLabel
            // 
            this.chooseCategoryLabel.AutoSize = true;
            this.chooseCategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseCategoryLabel.Location = new System.Drawing.Point(12, 111);
            this.chooseCategoryLabel.Name = "chooseCategoryLabel";
            this.chooseCategoryLabel.Size = new System.Drawing.Size(167, 20);
            this.chooseCategoryLabel.TabIndex = 16;
            this.chooseCategoryLabel.Text = "Choose a Category:";
            // 
            // xmlDataTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 349);
            this.Controls.Add(this.chooseCategoryLabel);
            this.Controls.Add(this.withMarkupRadioButton);
            this.Controls.Add(this.withoutMarkupRadioButton);
            this.Controls.Add(this.dataRichTextBox);
            this.Controls.Add(this.dataLabel);
            this.Controls.Add(this.definitionLabel);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.displayDataLabel);
            this.Controls.Add(this.resultsLabel);
            this.Controls.Add(this.descriptionGroupBox);
            this.Controls.Add(this.showDefinitionButton);
            this.Controls.Add(this.collectionListComboBox);
            this.Controls.Add(this.showDataButton);
            this.Controls.Add(this.schemaDataGridView);
            this.Controls.Add(this.insertDataButton);
            this.Name = "xmlDataTypeForm";
            this.Text = "XML Data Type Example";
            this.Load += new System.EventHandler(this.xmlDataTypeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schemaDataGridView)).EndInit();
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button insertDataButton;
		private System.Windows.Forms.DataGridView schemaDataGridView;
		private System.Windows.Forms.Button showDataButton;
		private System.Windows.Forms.ComboBox collectionListComboBox;
		private System.Windows.Forms.Button showDefinitionButton;
		private System.Windows.Forms.GroupBox descriptionGroupBox;
		private System.Windows.Forms.Label resultsLabel;
		private System.Windows.Forms.Label displayDataLabel;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.Label definitionLabel;
		private System.Windows.Forms.Label dataLabel;
		private System.Windows.Forms.RichTextBox dataRichTextBox;
		private System.Windows.Forms.RadioButton withoutMarkupRadioButton;
        private System.Windows.Forms.RadioButton withMarkupRadioButton;
        private System.Windows.Forms.Label descriptionLine1Label;
		private System.Windows.Forms.Label chooseCategoryLabel;
	}
}


namespace XPathXsL
{
	partial class xpathXslForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xpathXslForm));
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLinesLabel = new System.Windows.Forms.Label();
            this.resultsWebBrowser = new System.Windows.Forms.WebBrowser();
            this.displayDataButton = new System.Windows.Forms.Button();
            this.loadXMLButton = new System.Windows.Forms.Button();
            this.priceChoiceComboBox = new System.Windows.Forms.ComboBox();
            this.choosePriceLabel = new System.Windows.Forms.Label();
            this.greaterThanDollarLabel = new System.Windows.Forms.Label();
            this.testResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.rowsReturned = new System.Windows.Forms.Label();
            this.elapsedTime = new System.Windows.Forms.Label();
            this.rowsReturnedTextLabel = new System.Windows.Forms.Label();
            this.elapsedTimeTextLabel = new System.Windows.Forms.Label();
            this.loadlDataLabel = new System.Windows.Forms.Label();
            this.displayResultsLabel = new System.Windows.Forms.Label();
            this.descriptionGroupBox.SuspendLayout();
            this.testResultsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Controls.Add(this.descriptionLinesLabel);
            this.descriptionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Size = new System.Drawing.Size(694, 100);
            this.descriptionGroupBox.TabIndex = 0;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "Description";
            // 
            // descriptionLinesLabel
            // 
            this.descriptionLinesLabel.AutoSize = true;
            this.descriptionLinesLabel.Location = new System.Drawing.Point(6, 17);
            this.descriptionLinesLabel.Name = "descriptionLinesLabel";
            this.descriptionLinesLabel.Size = new System.Drawing.Size(632, 65);
            this.descriptionLinesLabel.TabIndex = 0;
            this.descriptionLinesLabel.Text = resources.GetString("descriptionLinesLabel.Text");
            // 
            // resultsWebBrowser
            // 
            this.resultsWebBrowser.Location = new System.Drawing.Point(356, 119);
            this.resultsWebBrowser.Name = "resultsWebBrowser";
            this.resultsWebBrowser.Size = new System.Drawing.Size(350, 273);
            // 
            // displayDataButton
            // 
            this.displayDataButton.Location = new System.Drawing.Point(12, 332);
            this.displayDataButton.Name = "displayDataButton";
            this.displayDataButton.Size = new System.Drawing.Size(75, 23);
            this.displayDataButton.TabIndex = 2;
            this.displayDataButton.Text = "Display Data";
            this.displayDataButton.Click += new System.EventHandler(this.displayData_Click);
            // 
            // loadXMLButton
            // 
            this.loadXMLButton.Location = new System.Drawing.Point(12, 168);
            this.loadXMLButton.Name = "loadXMLButton";
            this.loadXMLButton.Size = new System.Drawing.Size(75, 23);
            this.loadXMLButton.TabIndex = 3;
            this.loadXMLButton.Text = "Load XML";
            this.loadXMLButton.Click += new System.EventHandler(this.loadXMLButton_Click);
            // 
            // priceChoiceComboBox
            // 
            this.priceChoiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priceChoiceComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceChoiceComboBox.FormattingEnabled = true;
            this.priceChoiceComboBox.Location = new System.Drawing.Point(58, 236);
            this.priceChoiceComboBox.Name = "priceChoiceComboBox";
            this.priceChoiceComboBox.Size = new System.Drawing.Size(51, 28);
            this.priceChoiceComboBox.TabIndex = 5;
            // 
            // choosePriceLabel
            // 
            this.choosePriceLabel.AutoSize = true;
            this.choosePriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choosePriceLabel.Location = new System.Drawing.Point(10, 194);
            this.choosePriceLabel.Name = "choosePriceLabel";
            this.choosePriceLabel.Size = new System.Drawing.Size(194, 20);
            this.choosePriceLabel.TabIndex = 6;
            this.choosePriceLabel.Text = "Step 2: Choose a Price:";
            // 
            // greaterThanDollarLabel
            // 
            this.greaterThanDollarLabel.AutoSize = true;
            this.greaterThanDollarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greaterThanDollarLabel.Location = new System.Drawing.Point(24, 239);
            this.greaterThanDollarLabel.Name = "greaterThanDollarLabel";
            this.greaterThanDollarLabel.Size = new System.Drawing.Size(30, 20);
            this.greaterThanDollarLabel.TabIndex = 7;
            this.greaterThanDollarLabel.Text = "> $";
            // 
            // testResultsGroupBox
            // 
            this.testResultsGroupBox.Controls.Add(this.rowsReturned);
            this.testResultsGroupBox.Controls.Add(this.elapsedTime);
            this.testResultsGroupBox.Controls.Add(this.rowsReturnedTextLabel);
            this.testResultsGroupBox.Controls.Add(this.elapsedTimeTextLabel);
            this.testResultsGroupBox.Location = new System.Drawing.Point(211, 119);
            this.testResultsGroupBox.Name = "testResultsGroupBox";
            this.testResultsGroupBox.Size = new System.Drawing.Size(128, 145);
            this.testResultsGroupBox.TabIndex = 8;
            this.testResultsGroupBox.TabStop = false;
            this.testResultsGroupBox.Text = "Test Results";
            // 
            // rowsReturned
            // 
            this.rowsReturned.AutoSize = true;
            this.rowsReturned.Location = new System.Drawing.Point(10, 92);
            this.rowsReturned.Name = "rowsReturned";
            this.rowsReturned.Size = new System.Drawing.Size(0, 0);
            this.rowsReturned.TabIndex = 3;
            // 
            // elapsedTime
            // 
            this.elapsedTime.AutoSize = true;
            this.elapsedTime.Location = new System.Drawing.Point(9, 41);
            this.elapsedTime.Name = "elapsedTime";
            this.elapsedTime.Size = new System.Drawing.Size(0, 0);
            this.elapsedTime.TabIndex = 2;
            // 
            // rowsReturnedTextLabel
            // 
            this.rowsReturnedTextLabel.AutoSize = true;
            this.rowsReturnedTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowsReturnedTextLabel.Location = new System.Drawing.Point(6, 65);
            this.rowsReturnedTextLabel.Name = "rowsReturnedTextLabel";
            this.rowsReturnedTextLabel.Size = new System.Drawing.Size(94, 13);
            this.rowsReturnedTextLabel.TabIndex = 1;
            this.rowsReturnedTextLabel.Text = "Rows Returned:";
            // 
            // elapsedTimeTextLabel
            // 
            this.elapsedTimeTextLabel.AutoSize = true;
            this.elapsedTimeTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elapsedTimeTextLabel.Location = new System.Drawing.Point(7, 20);
            this.elapsedTimeTextLabel.Name = "elapsedTimeTextLabel";
            this.elapsedTimeTextLabel.Size = new System.Drawing.Size(83, 13);
            this.elapsedTimeTextLabel.TabIndex = 0;
            this.elapsedTimeTextLabel.Text = "Elapsed Time:";
            // 
            // loadlDataLabel
            // 
            this.loadlDataLabel.AutoSize = true;
            this.loadlDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadlDataLabel.Location = new System.Drawing.Point(10, 132);
            this.loadlDataLabel.Name = "loadlDataLabel";
            this.loadlDataLabel.Size = new System.Drawing.Size(152, 20);
            this.loadlDataLabel.TabIndex = 0;
            this.loadlDataLabel.Text = "Step 1: Load Data";
            // 
            // displayResultsLabel
            // 
            this.displayResultsLabel.AutoSize = true;
            this.displayResultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayResultsLabel.Location = new System.Drawing.Point(12, 294);
            this.displayResultsLabel.Name = "displayResultsLabel";
            this.displayResultsLabel.Size = new System.Drawing.Size(192, 20);
            this.displayResultsLabel.TabIndex = 9;
            this.displayResultsLabel.Text = "Step 3: Display Results";
            // 
            // xpathXslForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 404);
            this.Controls.Add(this.displayResultsLabel);
            this.Controls.Add(this.loadlDataLabel);
            this.Controls.Add(this.testResultsGroupBox);
            this.Controls.Add(this.greaterThanDollarLabel);
            this.Controls.Add(this.choosePriceLabel);
            this.Controls.Add(this.priceChoiceComboBox);
            this.Controls.Add(this.loadXMLButton);
            this.Controls.Add(this.displayDataButton);
            this.Controls.Add(this.resultsWebBrowser);
            this.Controls.Add(this.descriptionGroupBox);
            this.Name = "xpathXslForm";
            this.Text = "XPath and XSLT Transformation Example";
            this.Load += new System.EventHandler(this.XPathXslForm_Load);
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            this.testResultsGroupBox.ResumeLayout(false);
            this.testResultsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox descriptionGroupBox;
		private System.Windows.Forms.WebBrowser resultsWebBrowser;
		private System.Windows.Forms.Button displayDataButton;
		private System.Windows.Forms.Button loadXMLButton;
		private System.Windows.Forms.ComboBox priceChoiceComboBox;
		private System.Windows.Forms.Label choosePriceLabel;
		private System.Windows.Forms.Label greaterThanDollarLabel;
		private System.Windows.Forms.GroupBox testResultsGroupBox;
		private System.Windows.Forms.Label rowsReturned;
		private System.Windows.Forms.Label elapsedTime;
		private System.Windows.Forms.Label rowsReturnedTextLabel;
		private System.Windows.Forms.Label elapsedTimeTextLabel;
		private System.Windows.Forms.Label loadlDataLabel;
        private System.Windows.Forms.Label displayResultsLabel;
        private System.Windows.Forms.Label descriptionLinesLabel;
	}
}


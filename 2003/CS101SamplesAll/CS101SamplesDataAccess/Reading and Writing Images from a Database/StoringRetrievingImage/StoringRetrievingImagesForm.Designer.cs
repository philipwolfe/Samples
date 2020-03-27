namespace StoringRetrievingImage
{
	partial class StoringRetrievingImagesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoringRetrievingImagesForm));
            this.previousLinkLabel = new System.Windows.Forms.LinkLabel();
            this.nextLinkLabel = new System.Windows.Forms.LinkLabel();
            this.insertImageButton = new System.Windows.Forms.Button();
            this.browseImageButton = new System.Windows.Forms.Button();
            this.imageNameTextBox = new System.Windows.Forms.TextBox();
            this.orLabel = new System.Windows.Forms.Label();
            this.getCategoryImagesLabel = new System.Windows.Forms.Label();
            this.browseImageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.getImagesButton = new System.Windows.Forms.Button();
            this.addImageLabel = new System.Windows.Forms.Label();
            this.chooseCategoryLabel = new System.Windows.Forms.Label();
            this.categoriesComboBox = new System.Windows.Forms.ComboBox();
            this.photographNameLabel = new System.Windows.Forms.Label();
            this.photographPictureBox = new System.Windows.Forms.PictureBox();
            this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.descriptionLine1Label = new System.Windows.Forms.Label();
            this.photographNameTextBoxTextBox = new System.Windows.Forms.TextBox();
            this.photographTextLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.photographPictureBox)).BeginInit();
            this.descriptionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // previousLinkLabel
            // 
            this.previousLinkLabel.AutoSize = true;
            this.previousLinkLabel.Location = new System.Drawing.Point(418, 148);
            this.previousLinkLabel.Name = "previousLinkLabel";
            this.previousLinkLabel.Size = new System.Drawing.Size(95, 13);
            this.previousLinkLabel.TabIndex = 27;
            this.previousLinkLabel.TabStop = true;
            this.previousLinkLabel.Text = "<< Previous Image";
            this.previousLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.previousLinkLabel_LinkClicked);
            // 
            // nextLinkLabel
            // 
            this.nextLinkLabel.AutoSize = true;
            this.nextLinkLabel.Location = new System.Drawing.Point(562, 148);
            this.nextLinkLabel.Name = "nextLinkLabel";
            this.nextLinkLabel.Size = new System.Drawing.Size(76, 13);
            this.nextLinkLabel.TabIndex = 26;
            this.nextLinkLabel.TabStop = true;
            this.nextLinkLabel.Text = "Next Image >>";
            this.nextLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nextLinkLabel_LinkClicked);
            // 
            // insertImageButton
            // 
            this.insertImageButton.Location = new System.Drawing.Point(32, 378);
            this.insertImageButton.Name = "insertImageButton";
            this.insertImageButton.Size = new System.Drawing.Size(114, 23);
            this.insertImageButton.TabIndex = 25;
            this.insertImageButton.Text = "Insert New Image";
            this.insertImageButton.Click += new System.EventHandler(this.insertImageButton_Click);
            // 
            // browseImageButton
            // 
            this.browseImageButton.Location = new System.Drawing.Point(205, 312);
            this.browseImageButton.Name = "browseImageButton";
            this.browseImageButton.Size = new System.Drawing.Size(115, 23);
            this.browseImageButton.TabIndex = 24;
            this.browseImageButton.Text = "Browse for Image...";
            this.browseImageButton.Click += new System.EventHandler(this.browseImageButton_Click);
            // 
            // imageNameTextBox
            // 
            this.imageNameTextBox.Location = new System.Drawing.Point(33, 312);
            this.imageNameTextBox.Name = "imageNameTextBox";
            this.imageNameTextBox.Size = new System.Drawing.Size(166, 20);
            this.imageNameTextBox.TabIndex = 23;
            // 
            // orLabel
            // 
            this.orLabel.AutoSize = true;
            this.orLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orLabel.Location = new System.Drawing.Point(68, 264);
            this.orLabel.Name = "orLabel";
            this.orLabel.Size = new System.Drawing.Size(25, 13);
            this.orLabel.TabIndex = 22;
            this.orLabel.Text = "OR";
            // 
            // getCategoryImagesLabel
            // 
            this.getCategoryImagesLabel.AutoSize = true;
            this.getCategoryImagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getCategoryImagesLabel.Location = new System.Drawing.Point(33, 208);
            this.getCategoryImagesLabel.Name = "getCategoryImagesLabel";
            this.getCategoryImagesLabel.Size = new System.Drawing.Size(140, 13);
            this.getCategoryImagesLabel.TabIndex = 21;
            this.getCategoryImagesLabel.Text = "2. Get Category Images";
            // 
            // browseImageOpenFileDialog
            // 
            this.browseImageOpenFileDialog.FileName = "OpenFileDialog1";
            // 
            // getImagesButton
            // 
            this.getImagesButton.Location = new System.Drawing.Point(45, 228);
            this.getImagesButton.Name = "getImagesButton";
            this.getImagesButton.Size = new System.Drawing.Size(75, 23);
            this.getImagesButton.TabIndex = 20;
            this.getImagesButton.Text = "Get Images";
            this.getImagesButton.Click += new System.EventHandler(this.getImagesButton_Click);
            // 
            // addImageLabel
            // 
            this.addImageLabel.AutoSize = true;
            this.addImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addImageLabel.Location = new System.Drawing.Point(34, 285);
            this.addImageLabel.Name = "addImageLabel";
            this.addImageLabel.Size = new System.Drawing.Size(122, 13);
            this.addImageLabel.TabIndex = 19;
            this.addImageLabel.Text = "3. Add a New Image";
            // 
            // chooseCategoryLabel
            // 
            this.chooseCategoryLabel.AutoSize = true;
            this.chooseCategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseCategoryLabel.Location = new System.Drawing.Point(33, 148);
            this.chooseCategoryLabel.Name = "chooseCategoryLabel";
            this.chooseCategoryLabel.Size = new System.Drawing.Size(133, 13);
            this.chooseCategoryLabel.TabIndex = 18;
            this.chooseCategoryLabel.Text = "1. Choose a Category:";
            // 
            // categoriesComboBox
            // 
            this.categoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoriesComboBox.FormattingEnabled = true;
            this.categoriesComboBox.Location = new System.Drawing.Point(34, 172);
            this.categoriesComboBox.Name = "categoriesComboBox";
            this.categoriesComboBox.Size = new System.Drawing.Size(121, 21);
            this.categoriesComboBox.TabIndex = 17;
            // 
            // photographNameLabel
            // 
            this.photographNameLabel.AutoSize = true;
            this.photographNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photographNameLabel.Location = new System.Drawing.Point(513, 335);
            this.photographNameLabel.Name = "photographNameLabel";
            this.photographNameLabel.Size = new System.Drawing.Size(108, 13);
            this.photographNameLabel.TabIndex = 16;
            this.photographNameLabel.Text = "Photograph Name";
            this.photographNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // photographPictureBox
            // 
            this.photographPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.photographPictureBox.Location = new System.Drawing.Point(417, 172);
            this.photographPictureBox.Name = "photographPictureBox";
            this.photographPictureBox.Size = new System.Drawing.Size(217, 151);
            this.photographPictureBox.TabIndex = 15;
            this.photographPictureBox.TabStop = false;
            // 
            // descriptionGroupBox
            // 
            this.descriptionGroupBox.Controls.Add(this.descriptionLine1Label);
            this.descriptionGroupBox.Location = new System.Drawing.Point(34, 28);
            this.descriptionGroupBox.Name = "descriptionGroupBox";
            this.descriptionGroupBox.Size = new System.Drawing.Size(608, 103);
            this.descriptionGroupBox.TabIndex = 14;
            this.descriptionGroupBox.TabStop = false;
            this.descriptionGroupBox.Text = "Description";
            // 
            // descriptionLine1Label
            // 
            this.descriptionLine1Label.AutoSize = true;
            this.descriptionLine1Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionLine1Label.Location = new System.Drawing.Point(3, 16);
            this.descriptionLine1Label.Name = "descriptionLine1Label";
            this.descriptionLine1Label.Size = new System.Drawing.Size(548, 52);
            this.descriptionLine1Label.TabIndex = 0;
            this.descriptionLine1Label.Text = resources.GetString("descriptionLine1Label.Text");
            // 
            // photographNameTextBoxTextBox
            // 
            this.photographNameTextBoxTextBox.Location = new System.Drawing.Point(33, 352);
            this.photographNameTextBoxTextBox.Name = "photographNameTextBoxTextBox";
            this.photographNameTextBoxTextBox.Size = new System.Drawing.Size(287, 20);
            this.photographNameTextBoxTextBox.TabIndex = 28;
            // 
            // photographTextLabel
            // 
            this.photographTextLabel.AutoSize = true;
            this.photographTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photographTextLabel.Location = new System.Drawing.Point(35, 335);
            this.photographTextLabel.Name = "photographTextLabel";
            this.photographTextLabel.Size = new System.Drawing.Size(168, 13);
            this.photographTextLabel.TabIndex = 29;
            this.photographTextLabel.Text = "Enter the Photograph Name:";
            // 
            // StoringRetrievingImagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 413);
            this.Controls.Add(this.photographTextLabel);
            this.Controls.Add(this.photographNameTextBoxTextBox);
            this.Controls.Add(this.nextLinkLabel);
            this.Controls.Add(this.insertImageButton);
            this.Controls.Add(this.browseImageButton);
            this.Controls.Add(this.imageNameTextBox);
            this.Controls.Add(this.orLabel);
            this.Controls.Add(this.getCategoryImagesLabel);
            this.Controls.Add(this.getImagesButton);
            this.Controls.Add(this.addImageLabel);
            this.Controls.Add(this.chooseCategoryLabel);
            this.Controls.Add(this.categoriesComboBox);
            this.Controls.Add(this.photographNameLabel);
            this.Controls.Add(this.photographPictureBox);
            this.Controls.Add(this.descriptionGroupBox);
            this.Controls.Add(this.previousLinkLabel);
            this.Name = "StoringRetrievingImagesForm";
            this.Text = "Storing and Retrieving Images Example";
            this.Load += new System.EventHandler(this.StoringRetrievingImagesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.photographPictureBox)).EndInit();
            this.descriptionGroupBox.ResumeLayout(false);
            this.descriptionGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel previousLinkLabel;
		private System.Windows.Forms.LinkLabel nextLinkLabel;
		private System.Windows.Forms.Button insertImageButton;
		private System.Windows.Forms.Button browseImageButton;
		private System.Windows.Forms.TextBox imageNameTextBox;
		private System.Windows.Forms.Label orLabel;
		private System.Windows.Forms.Label getCategoryImagesLabel;
		private System.Windows.Forms.OpenFileDialog browseImageOpenFileDialog;
		private System.Windows.Forms.Button getImagesButton;
		private System.Windows.Forms.Label addImageLabel;
		private System.Windows.Forms.Label chooseCategoryLabel;
		private System.Windows.Forms.ComboBox categoriesComboBox;
		private System.Windows.Forms.Label photographNameLabel;
		private System.Windows.Forms.PictureBox photographPictureBox;
		private System.Windows.Forms.GroupBox descriptionGroupBox;
		private System.Windows.Forms.TextBox photographNameTextBoxTextBox;
		private System.Windows.Forms.Label photographTextLabel;
        private System.Windows.Forms.Label descriptionLine1Label;
	}
}


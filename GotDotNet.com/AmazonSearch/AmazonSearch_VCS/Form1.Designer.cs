namespace WSFun
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.searchText = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.booksOption = new System.Windows.Forms.RadioButton();
            this.musicOption = new System.Windows.Forms.RadioButton();
            this.dvdOption = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.listPriceLabel = new System.Windows.Forms.Label();
            this.searchResults = new System.Windows.Forms.ListBox();
            this.itemPicture = new System.Windows.Forms.PictureBox();
            this.usedPriceLabel = new System.Windows.Forms.Label();
            this.availabilityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemPicture)).BeginInit();
            this.SuspendLayout();
// 
// label1
// 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
// 
// searchText
// 
            this.searchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchText.AutoSize = false;
            this.searchText.Location = new System.Drawing.Point(60, 21);
            this.searchText.Multiline = true;
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(271, 22);
            this.searchText.TabIndex = 1;
// 
// goButton
// 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.Location = new System.Drawing.Point(356, 22);
            this.goButton.Name = "goButton";
            this.goButton.TabIndex = 2;
            this.goButton.Text = "Go!";
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
// 
// booksOption
// 
            this.booksOption.AutoSize = true;
            this.booksOption.Checked = true;
            this.booksOption.Location = new System.Drawing.Point(60, 53);
            this.booksOption.Name = "booksOption";
            this.booksOption.Size = new System.Drawing.Size(51, 17);
            this.booksOption.TabIndex = 3;
            this.booksOption.TabStop = true;
            this.booksOption.Tag = "books";
            this.booksOption.Text = "Books";
            this.booksOption.CheckedChanged += new System.EventHandler(this.modeChanged);
// 
// musicOption
// 
            this.musicOption.AutoSize = true;
            this.musicOption.Location = new System.Drawing.Point(171, 53);
            this.musicOption.Name = "musicOption";
            this.musicOption.Size = new System.Drawing.Size(49, 17);
            this.musicOption.TabIndex = 4;
            this.musicOption.Tag = "music";
            this.musicOption.Text = "Music";
            this.musicOption.CheckedChanged += new System.EventHandler(this.modeChanged);
// 
// dvdOption
// 
            this.dvdOption.AutoSize = true;
            this.dvdOption.Location = new System.Drawing.Point(280, 53);
            this.dvdOption.Name = "dvdOption";
            this.dvdOption.Size = new System.Drawing.Size(49, 17);
            this.dvdOption.TabIndex = 5;
            this.dvdOption.Tag = "dvd";
            this.dvdOption.Text = "DVDs";
            this.dvdOption.CheckedChanged += new System.EventHandler(this.modeChanged);
// 
// label2
// 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search Results";
// 
// listPriceLabel
// 
            this.listPriceLabel.AutoSize = true;
            this.listPriceLabel.Location = new System.Drawing.Point(13, 198);
            this.listPriceLabel.Name = "listPriceLabel";
            this.listPriceLabel.Size = new System.Drawing.Size(53, 14);
            this.listPriceLabel.TabIndex = 8;
            this.listPriceLabel.Text = "List price:";
            this.listPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// searchResults
// 
            this.searchResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchResults.FormattingEnabled = true;
            this.searchResults.Location = new System.Drawing.Point(13, 109);
            this.searchResults.Name = "searchResults";
            this.searchResults.Size = new System.Drawing.Size(417, 82);
            this.searchResults.TabIndex = 9;
            this.searchResults.SelectedIndexChanged += new System.EventHandler(this.searchResults_SelectedIndexChanged);
// 
// itemPicture
// 
            this.itemPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemPicture.Location = new System.Drawing.Point(280, 198);
            this.itemPicture.Name = "itemPicture";
            this.itemPicture.Size = new System.Drawing.Size(150, 189);
            this.itemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.itemPicture.TabIndex = 10;
            this.itemPicture.TabStop = false;
            this.itemPicture.UseWaitCursor = true;
// 
// usedPriceLabel
// 
            this.usedPriceLabel.AutoSize = true;
            this.usedPriceLabel.Location = new System.Drawing.Point(13, 219);
            this.usedPriceLabel.Name = "usedPriceLabel";
            this.usedPriceLabel.Size = new System.Drawing.Size(61, 14);
            this.usedPriceLabel.TabIndex = 11;
            this.usedPriceLabel.Text = "Used price:";
            this.usedPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// availabilityLabel
// 
            this.availabilityLabel.AutoSize = true;
            this.availabilityLabel.Location = new System.Drawing.Point(13, 240);
            this.availabilityLabel.Name = "availabilityLabel";
            this.availabilityLabel.Size = new System.Drawing.Size(58, 14);
            this.availabilityLabel.TabIndex = 12;
            this.availabilityLabel.Text = "Availability";
            this.availabilityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
// 
// Form1
// 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(442, 399);
            this.Controls.Add(this.availabilityLabel);
            this.Controls.Add(this.usedPriceLabel);
            this.Controls.Add(this.itemPicture);
            this.Controls.Add(this.searchResults);
            this.Controls.Add(this.listPriceLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dvdOption);
            this.Controls.Add(this.musicOption);
            this.Controls.Add(this.booksOption);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Amazon Search";
            ((System.ComponentModel.ISupportInitialize)(this.itemPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.RadioButton booksOption;
        private System.Windows.Forms.RadioButton musicOption;
        private System.Windows.Forms.RadioButton dvdOption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label listPriceLabel;
        private System.Windows.Forms.ListBox searchResults;
        private System.Windows.Forms.PictureBox itemPicture;
        private System.Windows.Forms.Label usedPriceLabel;
        private System.Windows.Forms.Label availabilityLabel;
    }
}


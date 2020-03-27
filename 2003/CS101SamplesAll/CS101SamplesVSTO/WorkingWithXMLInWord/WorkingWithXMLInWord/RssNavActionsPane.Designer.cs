namespace Working_with_XML_in_Word
{
	partial class RssNavActionsPane
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.uRLTextBox = new System.Windows.Forms.TextBox();
			this.goButton = new System.Windows.Forms.Button();
			this.previousEntryButton = new System.Windows.Forms.Button();
			this.nextEntryButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.blogEntryCountLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Blog URL:";
			// 
			// uRLTextBox
			// 
			this.uRLTextBox.Location = new System.Drawing.Point(3, 37);
			this.uRLTextBox.Name = "uRLTextBox";
			this.uRLTextBox.Size = new System.Drawing.Size(136, 20);
			this.uRLTextBox.TabIndex = 1;
			this.uRLTextBox.Text = "http://msdn.microsoft.com/office/rss.xml";
			// 
			// goButton
			// 
			this.goButton.Location = new System.Drawing.Point(144, 35);
			this.goButton.Name = "goButton";
			this.goButton.Size = new System.Drawing.Size(38, 23);
			this.goButton.TabIndex = 2;
			this.goButton.Text = "Go!";
			this.goButton.Click += new System.EventHandler(this.GoButton_Click);
			// 
			// previousEntryButton
			// 
			this.previousEntryButton.Enabled = false;
			this.previousEntryButton.Location = new System.Drawing.Point(13, 91);
			this.previousEntryButton.Name = "previousEntryButton";
			this.previousEntryButton.Size = new System.Drawing.Size(75, 23);
			this.previousEntryButton.TabIndex = 3;
			this.previousEntryButton.Text = "<< Previous";
			this.previousEntryButton.Click += new System.EventHandler(this.PreviousEntryButton_Click);
			// 
			// nextEntryButton
			// 
			this.nextEntryButton.Enabled = false;
			this.nextEntryButton.Location = new System.Drawing.Point(94, 91);
			this.nextEntryButton.Name = "nextEntryButton";
			this.nextEntryButton.Size = new System.Drawing.Size(75, 23);
			this.nextEntryButton.TabIndex = 4;
			this.nextEntryButton.Text = "Next >>";
			this.nextEntryButton.Click += new System.EventHandler(this.NextEntryButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Blog Entry:";
			// 
			// blogEntryCountLabel
			// 
			this.blogEntryCountLabel.AutoSize = true;
			this.blogEntryCountLabel.Location = new System.Drawing.Point(63, 72);
			this.blogEntryCountLabel.Name = "blogEntryCountLabel";
			this.blogEntryCountLabel.Size = new System.Drawing.Size(0, 0);
			this.blogEntryCountLabel.TabIndex = 6;
			// 
			// RssNavActionsPane
			// 
			this.Controls.Add(this.blogEntryCountLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.nextEntryButton);
			this.Controls.Add(this.previousEntryButton);
			this.Controls.Add(this.goButton);
			this.Controls.Add(this.uRLTextBox);
			this.Controls.Add(this.label1);
			this.Name = "RssNavActionsPane";
			this.Size = new System.Drawing.Size(186, 138);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox uRLTextBox;
		private System.Windows.Forms.Button goButton;
		private System.Windows.Forms.Button previousEntryButton;
		private System.Windows.Forms.Button nextEntryButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label blogEntryCountLabel;
	}
}

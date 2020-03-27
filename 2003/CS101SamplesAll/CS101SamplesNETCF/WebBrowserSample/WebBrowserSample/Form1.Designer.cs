namespace WebBrowserSample
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
            this.PocketPCLinkLabel = new System.Windows.Forms.LinkLabel();
            this.LocalContentLinkLabel = new System.Windows.Forms.LinkLabel();
            this.Splitter1 = new System.Windows.Forms.Splitter();
            this.Label1 = new System.Windows.Forms.Label();
            this.GoButton = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.WebBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // PocketPCLinkLabel
            // 
            this.PocketPCLinkLabel.Location = new System.Drawing.Point(0, 46);
            this.PocketPCLinkLabel.Name = "PocketPCLinkLabel";
            this.PocketPCLinkLabel.Size = new System.Drawing.Size(100, 20);
            this.PocketPCLinkLabel.TabIndex = 24;
            this.PocketPCLinkLabel.Text = "PocketPC.COM";
            this.PocketPCLinkLabel.Click += new System.EventHandler(this.PocketPCLinkLabel_Click);
            // 
            // LocalContentLinkLabel
            // 
            this.LocalContentLinkLabel.Location = new System.Drawing.Point(0, 26);
            this.LocalContentLinkLabel.Name = "LocalContentLinkLabel";
            this.LocalContentLinkLabel.Size = new System.Drawing.Size(124, 20);
            this.LocalContentLinkLabel.TabIndex = 23;
            this.LocalContentLinkLabel.Text = "Local Content (Help)";
            this.LocalContentLinkLabel.Click += new System.EventHandler(this.LocalContentLinkLabel_Click);
            // 
            // Splitter1
            // 
            this.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Splitter1.Location = new System.Drawing.Point(0, 90);
            this.Splitter1.Name = "Splitter1";
            this.Splitter1.Size = new System.Drawing.Size(240, 3);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(0, 2);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 20);
            this.Label1.Text = "URL:";
            // 
            // GoButton
            // 
            this.GoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GoButton.Location = new System.Drawing.Point(216, 2);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(24, 20);
            this.GoButton.TabIndex = 22;
            this.GoButton.Text = "GO";
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // URLTextBox
            // 
            this.URLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.URLTextBox.Location = new System.Drawing.Point(40, 2);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(170, 21);
            this.URLTextBox.TabIndex = 21;
            // 
            // WebBrowser1
            // 
            this.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WebBrowser1.Location = new System.Drawing.Point(0, 93);
            this.WebBrowser1.Name = "WebBrowser1";
            this.WebBrowser1.Size = new System.Drawing.Size(240, 175);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.PocketPCLinkLabel);
            this.Controls.Add(this.LocalContentLinkLabel);
            this.Controls.Add(this.Splitter1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.URLTextBox);
            this.Controls.Add(this.WebBrowser1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.LinkLabel PocketPCLinkLabel;
        internal System.Windows.Forms.LinkLabel LocalContentLinkLabel;
        internal System.Windows.Forms.Splitter Splitter1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.MainMenu mainMenu1;
        internal System.Windows.Forms.TextBox URLTextBox;
        internal System.Windows.Forms.WebBrowser WebBrowser1;
    }
}
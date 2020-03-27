namespace ControllingCaching
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
            this.Label3 = new System.Windows.Forms.Label();
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.PolicyDescTextBox = new System.Windows.Forms.TextBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.PolicyComboBox = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(3, 66);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(47, 13);
            this.Label3.TabIndex = 19;
            this.Label3.Text = "Status:";
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBox1.Location = new System.Drawing.Point(6, 95);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.Size = new System.Drawing.Size(780, 307);
            this.RichTextBox1.TabIndex = 17;
            this.RichTextBox1.Text = "";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(49, 66);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(37, 13);
            this.StatusLabel.TabIndex = 18;
            this.StatusLabel.Text = "Status";
            // 
            // PolicyDescTextBox
            // 
            this.PolicyDescTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.PolicyDescTextBox.Location = new System.Drawing.Point(237, 33);
            this.PolicyDescTextBox.Multiline = true;
            this.PolicyDescTextBox.Name = "PolicyDescTextBox";
            this.PolicyDescTextBox.ReadOnly = true;
            this.PolicyDescTextBox.Size = new System.Drawing.Size(549, 56);
            this.PolicyDescTextBox.TabIndex = 16;
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(756, 2);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(30, 23);
            this.GoButton.TabIndex = 12;
            this.GoButton.Text = "GO";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(3, 36);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(85, 13);
            this.Label2.TabIndex = 15;
            this.Label2.Text = "Cache Policy:";
            // 
            // PolicyComboBox
            // 
            this.PolicyComboBox.DropDownHeight = 130;
            this.PolicyComboBox.FormattingEnabled = true;
            this.PolicyComboBox.IntegralHeight = false;
            this.PolicyComboBox.Items.AddRange(new object[] {
            "BypassCache",
            "CacheIfAvailable",
            "CacheOnly",
            "CacheOrNextCacheOnly",
            "Default",
            "NoCacheNoStore",
            "Refresh",
            "Reload",
            "Revalidate"});
            this.PolicyComboBox.Location = new System.Drawing.Point(90, 33);
            this.PolicyComboBox.Name = "PolicyComboBox";
            this.PolicyComboBox.Size = new System.Drawing.Size(141, 21);
            this.PolicyComboBox.TabIndex = 14;
            this.PolicyComboBox.SelectedIndexChanged += new System.EventHandler(this.PolicyComboBox_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(3, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(36, 13);
            this.Label1.TabIndex = 13;
            this.Label1.Text = "URL:";
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(90, 4);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(660, 20);
            this.UrlTextBox.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 416);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.RichTextBox1);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.PolicyDescTextBox);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.PolicyComboBox);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.UrlTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.RichTextBox RichTextBox1;
        internal System.Windows.Forms.Label StatusLabel;
        internal System.Windows.Forms.TextBox PolicyDescTextBox;
        internal System.Windows.Forms.Button GoButton;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox PolicyComboBox;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox UrlTextBox;
    }
}


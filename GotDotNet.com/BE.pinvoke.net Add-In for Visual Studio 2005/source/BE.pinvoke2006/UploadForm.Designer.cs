namespace BE.pinvoke2006
{
    partial class UploadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pinvokelogo = new System.Windows.Forms.PictureBox();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.closeButton = new System.Windows.Forms.Button();
            this.contributeButton = new System.Windows.Forms.Button();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.signaturesTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pinvokelogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.pinvokelogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 45);
            this.panel1.TabIndex = 12;
            // 
            // pinvokelogo
            // 
            this.pinvokelogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pinvokelogo.Image = global::BE.pinvoke2006.Properties.Resources.pinvokelogo;
            this.pinvokelogo.Location = new System.Drawing.Point(12, 3);
            this.pinvokelogo.Name = "pinvokelogo";
            this.pinvokelogo.Size = new System.Drawing.Size(203, 38);
            this.pinvokelogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pinvokelogo.TabIndex = 10;
            this.pinvokelogo.TabStop = false;
            // 
            // logoBox
            // 
            this.logoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logoBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoBox.Image = global::BE.pinvoke2006.Properties.Resources.logo;
            this.logoBox.Location = new System.Drawing.Point(13, 539);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(79, 15);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoBox.TabIndex = 15;
            this.logoBox.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.Location = new System.Drawing.Point(98, 533);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(238, 33);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click here for more information, \r\nsuch as sample code or type definitions";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(680, 536);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 14;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // contributeButton
            // 
            this.contributeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.contributeButton.Enabled = false;
            this.contributeButton.Location = new System.Drawing.Point(599, 536);
            this.contributeButton.Name = "contributeButton";
            this.contributeButton.Size = new System.Drawing.Size(75, 23);
            this.contributeButton.TabIndex = 13;
            this.contributeButton.Text = "Contribute";
            this.contributeButton.UseVisualStyleBackColor = true;
            this.contributeButton.Click += new System.EventHandler(this.contributeButton_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(13, 71);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(319, 21);
            this.usernameTextBox.TabIndex = 18;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.usernameTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Choose a user name to associate with your signatures and types:";
            // 
            // signaturesTextBox
            // 
            this.signaturesTextBox.Location = new System.Drawing.Point(13, 129);
            this.signaturesTextBox.Multiline = true;
            this.signaturesTextBox.Name = "signaturesTextBox";
            this.signaturesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.signaturesTextBox.Size = new System.Drawing.Size(742, 376);
            this.signaturesTextBox.TabIndex = 20;
            this.signaturesTextBox.TextChanged += new System.EventHandler(this.signaturesTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Signatures and Types:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(367, 508);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(388, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "The entire contents of this box will be uploaded to www.pinvoke.net";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(772, 566);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.signaturesTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.contributeButton);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UploadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bernhard Elbl´s pinvoke.net Add-In | Constribute PInvoke Signatures";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pinvokelogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pinvokelogo;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button contributeButton;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox signaturesTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
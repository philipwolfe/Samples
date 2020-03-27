namespace EncryptingDecryptingData {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.closeButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.loadClearDataButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.encryptedFileTextBox = new System.Windows.Forms.TextBox();
            this.clearFileTextBox = new System.Windows.Forms.TextBox();
            this.clearDataTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.workFolderTextBox = new System.Windows.Forms.TextBox();
            this.decryptedFileTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.loadDecryptedDataButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(586, 397);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 14;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.decryptButton.Location = new System.Drawing.Point(381, 397);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(75, 23);
            this.decryptButton.TabIndex = 12;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // loadClearDataButton
            // 
            this.loadClearDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadClearDataButton.Location = new System.Drawing.Point(199, 397);
            this.loadClearDataButton.Name = "loadClearDataButton";
            this.loadClearDataButton.Size = new System.Drawing.Size(95, 23);
            this.loadClearDataButton.TabIndex = 10;
            this.loadClearDataButton.Text = "Show clear data";
            this.loadClearDataButton.UseVisualStyleBackColor = true;
            this.loadClearDataButton.Click += new System.EventHandler(this.loadClearDataButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.encryptButton.Location = new System.Drawing.Point(300, 397);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(75, 23);
            this.encryptButton.TabIndex = 11;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Encrypted file";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Clear data file";
            // 
            // encryptedFileTextBox
            // 
            this.encryptedFileTextBox.Location = new System.Drawing.Point(104, 80);
            this.encryptedFileTextBox.Name = "encryptedFileTextBox";
            this.encryptedFileTextBox.Size = new System.Drawing.Size(557, 20);
            this.encryptedFileTextBox.TabIndex = 6;
            // 
            // clearFileTextBox
            // 
            this.clearFileTextBox.Location = new System.Drawing.Point(104, 54);
            this.clearFileTextBox.Name = "clearFileTextBox";
            this.clearFileTextBox.Size = new System.Drawing.Size(557, 20);
            this.clearFileTextBox.TabIndex = 4;
            this.clearFileTextBox.TextChanged += new System.EventHandler(this.clearFileTextBox_TextChanged);
            // 
            // clearDataTextBox
            // 
            this.clearDataTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clearDataTextBox.Location = new System.Drawing.Point(30, 160);
            this.clearDataTextBox.Multiline = true;
            this.clearDataTextBox.Name = "clearDataTextBox";
            this.clearDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clearDataTextBox.Size = new System.Drawing.Size(631, 225);
            this.clearDataTextBox.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(15, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(662, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Work folder";
            // 
            // workFolderTextBox
            // 
            this.workFolderTextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.workFolderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.workFolderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workFolderTextBox.Location = new System.Drawing.Point(104, 35);
            this.workFolderTextBox.Name = "workFolderTextBox";
            this.workFolderTextBox.ReadOnly = true;
            this.workFolderTextBox.Size = new System.Drawing.Size(557, 12);
            this.workFolderTextBox.TabIndex = 2;
            this.workFolderTextBox.TabStop = false;
            this.workFolderTextBox.Text = "Work folder path goes here.";
            // 
            // decryptedFileTextBox
            // 
            this.decryptedFileTextBox.Location = new System.Drawing.Point(104, 106);
            this.decryptedFileTextBox.Name = "decryptedFileTextBox";
            this.decryptedFileTextBox.Size = new System.Drawing.Size(557, 20);
            this.decryptedFileTextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Decrypted file";
            // 
            // loadDecryptedDataButton
            // 
            this.loadDecryptedDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadDecryptedDataButton.Location = new System.Drawing.Point(462, 397);
            this.loadDecryptedDataButton.Name = "loadDecryptedDataButton";
            this.loadDecryptedDataButton.Size = new System.Drawing.Size(118, 23);
            this.loadDecryptedDataButton.TabIndex = 13;
            this.loadDecryptedDataButton.Text = "Show decrypted data";
            this.loadDecryptedDataButton.UseVisualStyleBackColor = true;
            this.loadDecryptedDataButton.Click += new System.EventHandler(this.loadDecryptedDataButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 432);
            this.Controls.Add(this.loadDecryptedDataButton);
            this.Controls.Add(this.workFolderTextBox);
            this.Controls.Add(this.loadClearDataButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decryptedFileTextBox);
            this.Controls.Add(this.encryptedFileTextBox);
            this.Controls.Add(this.clearFileTextBox);
            this.Controls.Add(this.clearDataTextBox);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(15, 0, 15, 50);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encryption and Decryption";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Button loadClearDataButton;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox encryptedFileTextBox;
        private System.Windows.Forms.TextBox clearFileTextBox;
        private System.Windows.Forms.TextBox clearDataTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox workFolderTextBox;
        private System.Windows.Forms.TextBox decryptedFileTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button loadDecryptedDataButton;
    }
}
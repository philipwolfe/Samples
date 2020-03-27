namespace DataProtectionAPI
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
            this.Label6 = new System.Windows.Forms.Label();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.EncryptedDestinationComboBox = new System.Windows.Forms.ComboBox();
            this.WriteFileTextBox = new System.Windows.Forms.TextBox();
            this.VerifyTextBox = new System.Windows.Forms.TextBox();
            this.RawBytesTextBox = new System.Windows.Forms.TextBox();
            this.EncryptedBytesTextBox = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.DataTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(256, 21);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(71, 13);
            this.Label6.TabIndex = 32;
            this.Label6.Text = "Destination";
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.Location = new System.Drawing.Point(380, 21);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(63, 13);
            this.FileNameLabel.TabIndex = 31;
            this.FileNameLabel.Text = "File Name";
            // 
            // EncryptedDestinationComboBox
            // 
            this.EncryptedDestinationComboBox.FormattingEnabled = true;
            this.EncryptedDestinationComboBox.Items.AddRange(new object[] {
            "Encrypt to Memory",
            "Encrypt to File"});
            this.EncryptedDestinationComboBox.Location = new System.Drawing.Point(256, 37);
            this.EncryptedDestinationComboBox.Name = "EncryptedDestinationComboBox";
            this.EncryptedDestinationComboBox.Size = new System.Drawing.Size(121, 21);
            this.EncryptedDestinationComboBox.TabIndex = 3;
            this.EncryptedDestinationComboBox.SelectedIndexChanged += new System.EventHandler(this.EncryptedDestinationComboBox_SelectedIndexChanged);
            // 
            // WriteFileTextBox
            // 
            this.WriteFileTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.WriteFileTextBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.WriteFileTextBox.Location = new System.Drawing.Point(383, 37);
            this.WriteFileTextBox.Name = "WriteFileTextBox";
            this.WriteFileTextBox.ReadOnly = true;
            this.WriteFileTextBox.Size = new System.Drawing.Size(60, 20);
            this.WriteFileTextBox.TabIndex = 4;
            this.WriteFileTextBox.Text = "Data.dat";
            // 
            // VerifyTextBox
            // 
            this.VerifyTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.VerifyTextBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.VerifyTextBox.Location = new System.Drawing.Point(102, 225);
            this.VerifyTextBox.Name = "VerifyTextBox";
            this.VerifyTextBox.ReadOnly = true;
            this.VerifyTextBox.Size = new System.Drawing.Size(148, 20);
            this.VerifyTextBox.TabIndex = 8;
            // 
            // RawBytesTextBox
            // 
            this.RawBytesTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.RawBytesTextBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.RawBytesTextBox.Location = new System.Drawing.Point(21, 86);
            this.RawBytesTextBox.Multiline = true;
            this.RawBytesTextBox.Name = "RawBytesTextBox";
            this.RawBytesTextBox.ReadOnly = true;
            this.RawBytesTextBox.Size = new System.Drawing.Size(229, 116);
            this.RawBytesTextBox.TabIndex = 5;
            // 
            // EncryptedBytesTextBox
            // 
            this.EncryptedBytesTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.EncryptedBytesTextBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.EncryptedBytesTextBox.Location = new System.Drawing.Point(256, 86);
            this.EncryptedBytesTextBox.Multiline = true;
            this.EncryptedBytesTextBox.Name = "EncryptedBytesTextBox";
            this.EncryptedBytesTextBox.ReadOnly = true;
            this.EncryptedBytesTextBox.Size = new System.Drawing.Size(518, 116);
            this.EncryptedBytesTextBox.TabIndex = 6;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(18, 70);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(67, 13);
            this.Label4.TabIndex = 25;
            this.Label4.Text = "Raw Bytes";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(18, 205);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(143, 13);
            this.Label3.TabIndex = 24;
            this.Label3.Text = "Decrpyt and Verify Data";
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(21, 223);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(75, 23);
            this.DecryptButton.TabIndex = 7;
            this.DecryptButton.Text = "Decrypt";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(253, 70);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(99, 13);
            this.Label2.TabIndex = 22;
            this.Label2.Text = "Encrypted Bytes";
            // 
            // EncryptButton
            // 
            this.EncryptButton.Location = new System.Drawing.Point(175, 37);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(75, 23);
            this.EncryptButton.TabIndex = 2;
            this.EncryptButton.Text = "Encrypt";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // DataTextBox
            // 
            this.DataTextBox.Location = new System.Drawing.Point(21, 37);
            this.DataTextBox.Name = "DataTextBox";
            this.DataTextBox.Size = new System.Drawing.Size(148, 20);
            this.DataTextBox.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(18, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 13);
            this.Label1.TabIndex = 19;
            this.Label1.Text = "Data To Encrpyt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 266);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.EncryptedDestinationComboBox);
            this.Controls.Add(this.WriteFileTextBox);
            this.Controls.Add(this.VerifyTextBox);
            this.Controls.Add(this.RawBytesTextBox);
            this.Controls.Add(this.EncryptedBytesTextBox);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.EncryptButton);
            this.Controls.Add(this.DataTextBox);
            this.Controls.Add(this.Label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label FileNameLabel;
        internal System.Windows.Forms.ComboBox EncryptedDestinationComboBox;
        internal System.Windows.Forms.TextBox WriteFileTextBox;
        internal System.Windows.Forms.TextBox VerifyTextBox;
        internal System.Windows.Forms.TextBox RawBytesTextBox;
        internal System.Windows.Forms.TextBox EncryptedBytesTextBox;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button DecryptButton;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button EncryptButton;
        internal System.Windows.Forms.TextBox DataTextBox;
        internal System.Windows.Forms.Label Label1;

    }
}


namespace IntegratingWindowsFormsIntoOutlook
{
    partial class CustomMailTemplateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dueDateTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendMailButton = new System.Windows.Forms.Button();
            this.cancelMailButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Customer";
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(106, 6);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(159, 21);
            this.customerComboBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Amount Overdue";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(106, 33);
            this.amountTextBox.Mask = "00000";
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(100, 20);
            this.amountTextBox.TabIndex = 5;
            this.amountTextBox.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "&Due date";
            // 
            // dueDateTextBox
            // 
            this.dueDateTextBox.Location = new System.Drawing.Point(106, 59);
            this.dueDateTextBox.Mask = "00/00/0000";
            this.dueDateTextBox.Name = "dueDateTextBox";
            this.dueDateTextBox.Size = new System.Drawing.Size(100, 20);
            this.dueDateTextBox.TabIndex = 7;
            this.dueDateTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "&Message";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(12, 108);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(268, 137);
            this.messageTextBox.TabIndex = 9;
            this.messageTextBox.Text = "Please give your prompt attention to this matter.\r\n\r\nThank you!";
            // 
            // sendMailButton
            // 
            this.sendMailButton.Location = new System.Drawing.Point(12, 251);
            this.sendMailButton.Name = "sendMailButton";
            this.sendMailButton.Size = new System.Drawing.Size(75, 23);
            this.sendMailButton.TabIndex = 10;
            this.sendMailButton.Text = "&Send";
            this.sendMailButton.UseVisualStyleBackColor = true;
            this.sendMailButton.Click += new System.EventHandler(this.sendMailButton_Click);
            // 
            // cancelMailButton
            // 
            this.cancelMailButton.Location = new System.Drawing.Point(205, 251);
            this.cancelMailButton.Name = "cancelMailButton";
            this.cancelMailButton.Size = new System.Drawing.Size(75, 23);
            this.cancelMailButton.TabIndex = 11;
            this.cancelMailButton.Text = "Ca&ncel";
            this.cancelMailButton.UseVisualStyleBackColor = true;
            this.cancelMailButton.Click += new System.EventHandler(this.cancelMailButton_Click);
            // 
            // CustomMailTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 276);
            this.ControlBox = false;
            this.Controls.Add(this.cancelMailButton);
            this.Controls.Add(this.sendMailButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dueDateTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CustomMailTemplateForm";
            this.Text = "Overdue Mail Template";
            this.VisibleChanged += new System.EventHandler(this.CustomMailTemplateForm_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox amountTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox dueDateTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendMailButton;
        private System.Windows.Forms.Button cancelMailButton;
    }
}
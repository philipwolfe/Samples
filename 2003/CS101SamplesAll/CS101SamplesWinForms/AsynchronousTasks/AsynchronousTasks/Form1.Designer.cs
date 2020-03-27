namespace AsynchronousTasks
{
    partial class MainForm
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
            this.textBoxPrime = new System.Windows.Forms.TextBox();
            this.PrimeNumberLabel = new System.Windows.Forms.Label();
            this.nextPrimeButton = new System.Windows.Forms.Button();
            this.nextPrimeAsyncButton = new System.Windows.Forms.Button();
            this.inputString = new System.Windows.Forms.TextBox();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.calcStatusStrip = new System.Windows.Forms.StatusStrip();
            this.calcStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.calcProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.calcStatusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPrime
            // 
            this.textBoxPrime.Location = new System.Drawing.Point(94, 12);
            this.textBoxPrime.Name = "textBoxPrime";
            this.textBoxPrime.Size = new System.Drawing.Size(148, 20);
            this.textBoxPrime.TabIndex = 0;
            this.textBoxPrime.Text = "100000000";
            // 
            // PrimeNumberLabel
            // 
            this.PrimeNumberLabel.AutoSize = true;
            this.PrimeNumberLabel.Location = new System.Drawing.Point(12, 15);
            this.PrimeNumberLabel.Name = "PrimeNumberLabel";
            this.PrimeNumberLabel.Size = new System.Drawing.Size(76, 13);
            this.PrimeNumberLabel.TabIndex = 1;
            this.PrimeNumberLabel.Text = "Prime Number:";
            // 
            // nextPrimeButton
            // 
            this.nextPrimeButton.Location = new System.Drawing.Point(13, 22);
            this.nextPrimeButton.Name = "nextPrimeButton";
            this.nextPrimeButton.Size = new System.Drawing.Size(140, 23);
            this.nextPrimeButton.TabIndex = 2;
            this.nextPrimeButton.Text = "Synchronous";
            this.nextPrimeButton.Click += new System.EventHandler(this.nextPrimeButton_Click);
            // 
            // nextPrimeAsyncButton
            // 
            this.nextPrimeAsyncButton.Location = new System.Drawing.Point(159, 22);
            this.nextPrimeAsyncButton.Name = "nextPrimeAsyncButton";
            this.nextPrimeAsyncButton.Size = new System.Drawing.Size(142, 23);
            this.nextPrimeAsyncButton.TabIndex = 3;
            this.nextPrimeAsyncButton.Text = "Asynchronous";
            this.nextPrimeAsyncButton.Click += new System.EventHandler(this.nextPrimeAsyncButton_Click);
            // 
            // inputString
            // 
            this.inputString.Location = new System.Drawing.Point(12, 148);
            this.inputString.Multiline = true;
            this.inputString.Name = "inputString";
            this.inputString.Size = new System.Drawing.Size(369, 58);
            this.inputString.TabIndex = 4;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(11, 123);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(206, 13);
            this.MessageLabel.TabIndex = 5;
            this.MessageLabel.Text = "Try typing here while a prime is calculated:";
            // 
            // calcStatusStrip
            // 
            this.calcStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calcStatus,
            this.calcProgress});
            this.calcStatusStrip.Location = new System.Drawing.Point(0, 393);
            this.calcStatusStrip.Name = "calcStatusStrip";
            this.calcStatusStrip.Size = new System.Drawing.Size(542, 23);
            this.calcStatusStrip.TabIndex = 6;
            this.calcStatusStrip.Text = "statusStrip1";
            // 
            // calcStatus
            // 
            this.calcStatus.AutoSize = false;
            this.calcStatus.Name = "calcStatus";
            this.calcStatus.Size = new System.Drawing.Size(75, 18);
            this.calcStatus.Text = "Status";
            this.calcStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // calcProgress
            // 
            this.calcProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.calcProgress.AutoSize = false;
            this.calcProgress.Name = "calcProgress";
            this.calcProgress.Size = new System.Drawing.Size(100, 17);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(307, 22);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.nextPrimeAsyncButton);
            this.groupBox1.Controls.Add(this.nextPrimeButton);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(15, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 62);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate next prime number";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 416);
            this.Controls.Add(this.calcStatusStrip);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.inputString);
            this.Controls.Add(this.PrimeNumberLabel);
            this.Controls.Add(this.textBoxPrime);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Performing Tasks Asynchronously";
            this.calcStatusStrip.ResumeLayout(false);
            this.calcStatusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPrime;
        private System.Windows.Forms.Label PrimeNumberLabel;
        private System.Windows.Forms.Button nextPrimeButton;
        private System.Windows.Forms.Button nextPrimeAsyncButton;
        private System.Windows.Forms.TextBox inputString;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.StatusStrip calcStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel calcStatus;
        private System.Windows.Forms.ToolStripProgressBar calcProgress;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}


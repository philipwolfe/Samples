namespace InkEnabledTextBox
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
            if (disposing && !isDisposed)
            {
                if (inkOverlay != null)
                {
                    inkOverlay.Dispose();
                }
                isDisposed = true;
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
            this.components = new System.ComponentModel.Container();
            this.basicTextBox = new System.Windows.Forms.TextBox();
            this.richTextBoxOffersTipCorrection = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // basicTextBox
            // 
            this.basicTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.basicTextBox.Location = new System.Drawing.Point(26, 25);
            this.basicTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.basicTextBox.Name = "basicTextBox";
            this.basicTextBox.Size = new System.Drawing.Size(543, 31);
            this.basicTextBox.TabIndex = 0;
            // 
            // richTextBoxOffersTipCorrection
            // 
            this.richTextBoxOffersTipCorrection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOffersTipCorrection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxOffersTipCorrection.Location = new System.Drawing.Point(26, 77);
            this.richTextBoxOffersTipCorrection.Margin = new System.Windows.Forms.Padding(6);
            this.richTextBoxOffersTipCorrection.Multiline = false;
            this.richTextBoxOffersTipCorrection.Name = "richTextBoxOffersTipCorrection";
            this.richTextBoxOffersTipCorrection.Size = new System.Drawing.Size(543, 39);
            this.richTextBoxOffersTipCorrection.TabIndex = 1;
            this.richTextBoxOffersTipCorrection.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(26, 126);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(543, 31);
            this.textBox1.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 223);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBoxOffersTipCorrection);
            this.Controls.Add(this.basicTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox basicTextBox;
        private System.Windows.Forms.RichTextBox richTextBoxOffersTipCorrection;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
    }
}


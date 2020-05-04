namespace BE.pinvoke2006
{
    partial class SignatureControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkRadioButton = new System.Windows.Forms.RadioButton();
            this.signatureTextBox = new System.Windows.Forms.TextBox();
            this.updatedLabel = new System.Windows.Forms.Label();
            this.timerDelay = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnOnline = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkRadioButton
            // 
            this.checkRadioButton.AutoSize = true;
            this.checkRadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkRadioButton.Location = new System.Drawing.Point(13, 19);
            this.checkRadioButton.Name = "checkRadioButton";
            this.checkRadioButton.Size = new System.Drawing.Size(45, 17);
            this.checkRadioButton.TabIndex = 0;
            this.checkRadioButton.TabStop = true;
            this.checkRadioButton.Text = "lang";
            this.checkRadioButton.UseVisualStyleBackColor = true;
            this.checkRadioButton.MouseLeave += new System.EventHandler(this.SignatureControl_MouseLeave);
            this.checkRadioButton.MouseEnter += new System.EventHandler(this.SignatureControl_MouseEnter);
            this.checkRadioButton.CheckedChanged += new System.EventHandler(this.checkRadioButton_CheckedChanged);
            // 
            // signatureTextBox
            // 
            this.signatureTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.signatureTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signatureTextBox.Location = new System.Drawing.Point(64, 19);
            this.signatureTextBox.Multiline = true;
            this.signatureTextBox.Name = "signatureTextBox";
            this.signatureTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.signatureTextBox.Size = new System.Drawing.Size(451, 62);
            this.signatureTextBox.TabIndex = 1;
            this.signatureTextBox.MouseLeave += new System.EventHandler(this.SignatureControl_MouseLeave);
            this.signatureTextBox.MouseEnter += new System.EventHandler(this.SignatureControl_MouseEnter);
            // 
            // updatedLabel
            // 
            this.updatedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updatedLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updatedLabel.Location = new System.Drawing.Point(64, 3);
            this.updatedLabel.Name = "updatedLabel";
            this.updatedLabel.Size = new System.Drawing.Size(454, 13);
            this.updatedLabel.TabIndex = 3;
            this.updatedLabel.Text = "updated";
            this.updatedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.updatedLabel.MouseLeave += new System.EventHandler(this.SignatureControl_MouseLeave);
            this.updatedLabel.Click += new System.EventHandler(this.SignatureControl_Click);
            this.updatedLabel.MouseEnter += new System.EventHandler(this.SignatureControl_MouseEnter);
            // 
            // timerDelay
            // 
            this.timerDelay.Tick += new System.EventHandler(this.timerDelay_Tick);
            // 
            // btnOnline
            // 
            this.btnOnline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOnline.Image = global::BE.pinvoke2006.Properties.Resources.globe;
            this.btnOnline.Location = new System.Drawing.Point(13, 57);
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.Size = new System.Drawing.Size(45, 24);
            this.btnOnline.TabIndex = 4;
            this.btnOnline.UseVisualStyleBackColor = true;
            this.btnOnline.MouseLeave += new System.EventHandler(this.SignatureControl_MouseLeave);
            this.btnOnline.Click += new System.EventHandler(this.btnOnline_Click);
            this.btnOnline.MouseEnter += new System.EventHandler(this.SignatureControl_MouseEnter);
            // 
            // SignatureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(140)))));
            this.Controls.Add(this.btnOnline);
            this.Controls.Add(this.updatedLabel);
            this.Controls.Add(this.signatureTextBox);
            this.Controls.Add(this.checkRadioButton);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "SignatureControl";
            this.Size = new System.Drawing.Size(518, 84);
            this.Click += new System.EventHandler(this.SignatureControl_Click);
            this.MouseEnter += new System.EventHandler(this.SignatureControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SignatureControl_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton checkRadioButton;
        private System.Windows.Forms.TextBox signatureTextBox;
        private System.Windows.Forms.Label updatedLabel;
        private System.Windows.Forms.Timer timerDelay;
        private System.Windows.Forms.Button btnOnline;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

namespace ClientSettings
{
    partial class EditorOptions
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkDetectURLs = new System.Windows.Forms.CheckBox();
            this.checkWordWrap = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkDetectURLs);
            this.groupBox1.Controls.Add(this.checkWordWrap);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Settings";
            // 
            // checkDetectURLs
            // 
            this.checkDetectURLs.AutoSize = true;
            this.checkDetectURLs.Checked = true;
            this.checkDetectURLs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkDetectURLs.Location = new System.Drawing.Point(17, 45);
            this.checkDetectURLs.Name = "checkDetectURLs";
            this.checkDetectURLs.Size = new System.Drawing.Size(88, 17);
            this.checkDetectURLs.TabIndex = 1;
            this.checkDetectURLs.Text = "&Detect URLs";
            this.checkDetectURLs.UseVisualStyleBackColor = true;
            // 
            // checkWordWrap
            // 
            this.checkWordWrap.AutoSize = true;
            this.checkWordWrap.Checked = true;
            this.checkWordWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkWordWrap.Location = new System.Drawing.Point(17, 19);
            this.checkWordWrap.Name = "checkWordWrap";
            this.checkWordWrap.Size = new System.Drawing.Size(81, 17);
            this.checkWordWrap.TabIndex = 0;
            this.checkWordWrap.Text = "&Word Wrap";
            this.checkWordWrap.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(110, 90);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(200, 90);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // EditorOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 122);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "EditorOptions";
            this.Text = "EditorOptions";
            this.Load += new System.EventHandler(this.EditorOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkWordWrap;
        private System.Windows.Forms.CheckBox checkDetectURLs;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}
namespace UsingDataGridView
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
            this.listBoxDirectReports = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxDirectReports
            // 
            this.listBoxDirectReports.FormattingEnabled = true;
            this.listBoxDirectReports.HorizontalScrollbar = true;
            this.listBoxDirectReports.Location = new System.Drawing.Point(160, 148);
            this.listBoxDirectReports.Name = "listBoxDirectReports";
            this.listBoxDirectReports.Size = new System.Drawing.Size(222, 121);
            this.listBoxDirectReports.Sorted = true;
            this.listBoxDirectReports.TabIndex = 2;
            this.listBoxDirectReports.Visible = false;
            this.listBoxDirectReports.SelectedIndexChanged += new System.EventHandler(this.listBoxDirectReports_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 416);
            this.Controls.Add(this.listBoxDirectReports);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Using the DataGridView Control";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.ListBox listBoxDirectReports;

	}
}


namespace UrlBuddy
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ContextMenuStrip contextMenuStrip;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.showLastUrlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.recentUrlsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.timer = new System.Windows.Forms.Timer(this.components);
			contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip
			// 
			contextMenuStrip.Enabled = true;
			contextMenuStrip.GripMargin = new System.Windows.Forms.Padding(2);
			contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLastUrlMenuItem,
            this.recentUrlsMenuItem,
            this.exitMenuItem});
			contextMenuStrip.Location = new System.Drawing.Point(22, 37);
			contextMenuStrip.Name = "contextMenuStrip";
			contextMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
			contextMenuStrip.Size = new System.Drawing.Size(146, 70);
			// 
			// showLastUrlMenuItem
			// 
			this.showLastUrlMenuItem.Enabled = false;
			this.showLastUrlMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.showLastUrlMenuItem.Name = "showLastUrlMenuItem";
			this.showLastUrlMenuItem.Text = "Show Last URL";
			// 
			// recentUrlsMenuItem
			// 
			this.recentUrlsMenuItem.Enabled = false;
			this.recentUrlsMenuItem.Name = "recentUrlsMenuItem";
			this.recentUrlsMenuItem.Text = "Recent URLs";
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Name = "exitMenuItem";
			this.exitMenuItem.Text = "E&xit";
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = contextMenuStrip;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Visible = true;
			// 
			// timer
			// 
			this.timer.Interval = 5000;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 52);
			this.ControlBox = false;
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.ShowInTaskbar = false;
			this.TopMost = true;
			contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLastUrlMenuItem;
		private System.Windows.Forms.ToolStripMenuItem recentUrlsMenuItem;
    }
}
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
	partial class VerticalToolTabsForm : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
            this.toolWindowHost1 = new Microsoft.Samples.Windows.Forms.ToolStripSamples.ToolWindowHost();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // toolWindowHost1
            // 
            this.toolWindowHost1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolWindowHost1.Location = new System.Drawing.Point(504, 0);
            this.toolWindowHost1.Name = "toolWindowHost1";
            this.toolWindowHost1.Size = new System.Drawing.Size(211, 453);
            this.toolWindowHost1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(501, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 453);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(501, 453);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // VerticalToolTabsForm
            // 
            this.ClientSize = new System.Drawing.Size(715, 453);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolWindowHost1);
            this.IsMdiContainer = true;
            this.Name = "VerticalToolTabsForm";
            this.Text = "VerticalToolTabs";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

		#endregion

        private Splitter splitter1;
		private RichTextBox richTextBox1;
        private ToolWindowHost toolWindowHost1;

	}
}


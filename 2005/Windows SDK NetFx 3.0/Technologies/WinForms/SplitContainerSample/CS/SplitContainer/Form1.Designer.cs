namespace Microsoft.Samples.Windows.Forms.SplitContainer
{
	public partial class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Panel2Collapsed = new System.Windows.Forms.CheckBox();
            this.Panel1Collapsed = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Panel2MinSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Panel1MinSize = new System.Windows.Forms.TextBox();
            this.SplitterWidth = new System.Windows.Forms.TextBox();
            this.SplitterDistance = new System.Windows.Forms.TextBox();
            this.SplitterIncrement = new System.Windows.Forms.TextBox();
            this.SplitterIncrementLabel = new System.Windows.Forms.Label();
            this.SplitterWidthLabel = new System.Windows.Forms.Label();
            this.SplitterDistanceLabel = new System.Windows.Forms.Label();
            this.OrientationLabel = new System.Windows.Forms.Label();
            this.OrientationButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.restorePanel2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Panel2Collapsed);
            this.splitContainer1.Panel2.Controls.Add(this.Panel1Collapsed);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.Panel2MinSize);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.Panel1MinSize);
            this.splitContainer1.Panel2.Controls.Add(this.SplitterWidth);
            this.splitContainer1.Panel2.Controls.Add(this.SplitterDistance);
            this.splitContainer1.Panel2.Controls.Add(this.SplitterIncrement);
            this.splitContainer1.Panel2.Controls.Add(this.SplitterIncrementLabel);
            this.splitContainer1.Panel2.Controls.Add(this.SplitterWidthLabel);
            this.splitContainer1.Panel2.Controls.Add(this.SplitterDistanceLabel);
            this.splitContainer1.Panel2.Controls.Add(this.OrientationLabel);
            this.splitContainer1.Panel2.Controls.Add(this.OrientationButton);
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Panel2Collapsed
            // 
            resources.ApplyResources(this.Panel2Collapsed, "Panel2Collapsed");
            this.Panel2Collapsed.Name = "Panel2Collapsed";
            this.Panel2Collapsed.CheckStateChanged += new System.EventHandler(this.Panel2Collapsed_CheckStateChanged);
            // 
            // Panel1Collapsed
            // 
            resources.ApplyResources(this.Panel1Collapsed, "Panel1Collapsed");
            this.Panel1Collapsed.Name = "Panel1Collapsed";
            this.Panel1Collapsed.CheckedChanged += new System.EventHandler(this.Panel1Collapsed_CheckedChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Panel2MinSize
            // 
            resources.ApplyResources(this.Panel2MinSize, "Panel2MinSize");
            this.Panel2MinSize.Name = "Panel2MinSize";
            this.Panel2MinSize.Validated += new System.EventHandler(this.Panel2MinSize_Validated);
            this.Panel2MinSize.Validating += new System.ComponentModel.CancelEventHandler(this.Panel2MinSize_Validating);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Panel1MinSize
            // 
            resources.ApplyResources(this.Panel1MinSize, "Panel1MinSize");
            this.Panel1MinSize.Name = "Panel1MinSize";
            this.Panel1MinSize.Validated += new System.EventHandler(this.Panel1MinSize_Validated);
            this.Panel1MinSize.Validating += new System.ComponentModel.CancelEventHandler(this.Panel1MinSize_Validating);
            // 
            // SplitterWidth
            // 
            resources.ApplyResources(this.SplitterWidth, "SplitterWidth");
            this.SplitterWidth.Name = "SplitterWidth";
            this.SplitterWidth.Validated += new System.EventHandler(this.SplitterWidth_Validated);
            this.SplitterWidth.Validating += new System.ComponentModel.CancelEventHandler(this.SplitterWidth_Validating);
            // 
            // SplitterDistance
            // 
            resources.ApplyResources(this.SplitterDistance, "SplitterDistance");
            this.SplitterDistance.Name = "SplitterDistance";
            this.SplitterDistance.ReadOnly = true;
            // 
            // SplitterIncrement
            // 
            resources.ApplyResources(this.SplitterIncrement, "SplitterIncrement");
            this.SplitterIncrement.Name = "SplitterIncrement";
            this.SplitterIncrement.Validated += new System.EventHandler(this.SplitterIncrement_Validated);
            this.SplitterIncrement.Validating += new System.ComponentModel.CancelEventHandler(this.SplitterIncrement_Validating);
            // 
            // SplitterIncrementLabel
            // 
            resources.ApplyResources(this.SplitterIncrementLabel, "SplitterIncrementLabel");
            this.SplitterIncrementLabel.Name = "SplitterIncrementLabel";
            // 
            // SplitterWidthLabel
            // 
            resources.ApplyResources(this.SplitterWidthLabel, "SplitterWidthLabel");
            this.SplitterWidthLabel.Name = "SplitterWidthLabel";
            // 
            // SplitterDistanceLabel
            // 
            resources.ApplyResources(this.SplitterDistanceLabel, "SplitterDistanceLabel");
            this.SplitterDistanceLabel.Name = "SplitterDistanceLabel";
            // 
            // OrientationLabel
            // 
            resources.ApplyResources(this.OrientationLabel, "OrientationLabel");
            this.OrientationLabel.Name = "OrientationLabel";
            // 
            // OrientationButton
            // 
            resources.ApplyResources(this.OrientationButton, "OrientationButton");
            this.OrientationButton.Name = "OrientationButton";
            this.OrientationButton.Click += new System.EventHandler(this.OrientationButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restorePanel2ToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // restorePanel2ToolStripMenuItem
            // 
            this.restorePanel2ToolStripMenuItem.Name = "restorePanel2ToolStripMenuItem";
            resources.ApplyResources(this.restorePanel2ToolStripMenuItem, "restorePanel2ToolStripMenuItem");
            this.restorePanel2ToolStripMenuItem.Click += new System.EventHandler(this.restorePanel2ToolStripMenuItem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        /// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox SplitterWidth;
        private System.Windows.Forms.TextBox SplitterDistance;
        private System.Windows.Forms.TextBox SplitterIncrement;
        private System.Windows.Forms.Label SplitterIncrementLabel;
        private System.Windows.Forms.Label SplitterWidthLabel;
        private System.Windows.Forms.Label SplitterDistanceLabel;
        private System.Windows.Forms.Label OrientationLabel;
        private System.Windows.Forms.Button OrientationButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Panel2MinSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Panel1MinSize;
        private System.Windows.Forms.CheckBox Panel2Collapsed;
        private System.Windows.Forms.CheckBox Panel1Collapsed;
        private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem restorePanel2ToolStripMenuItem;
		private System.Windows.Forms.ErrorProvider errorProvider1;
	}
}


namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
    partial class SampleLauncher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleLauncher));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.LayoutButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitStackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DockButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TextImageRelationButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.imageBeforeTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBeforeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageAboveTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textAboveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextAlignButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.leftToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.righToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageAlignButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.leftToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(26, 372);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LayoutButton,
            this.DockButton,
            this.toolStripSeparator1,
            this.TextImageRelationButton,
            this.TextAlignButton,
            this.ImageAlignButton,
            this.toolStripSeparator2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(558, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // LayoutButton
            // 
            this.LayoutButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableToolStripMenuItem,
            this.flowToolStripMenuItem,
            this.splitStackToolStripMenuItem});
            this.LayoutButton.Image = ((System.Drawing.Image)(resources.GetObject("LayoutButton.Image")));
            this.LayoutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LayoutButton.Name = "LayoutButton";
            this.LayoutButton.Size = new System.Drawing.Size(69, 22);
            this.LayoutButton.Text = "&Layout";
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tableToolStripMenuItem.Text = "&Table";
            this.tableToolStripMenuItem.Click += new System.EventHandler(this.tableToolStripMenuItem_Click);
            // 
            // flowToolStripMenuItem
            // 
            this.flowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticalToolStripMenuItem,
            this.horizontalToolStripMenuItem});
            this.flowToolStripMenuItem.Name = "flowToolStripMenuItem";
            this.flowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.flowToolStripMenuItem.Text = "&Flow";
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bottomUpToolStripMenuItem,
            this.topDownToolStripMenuItem});
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verticalToolStripMenuItem.Text = "&Vertical";
            // 
            // bottomUpToolStripMenuItem
            // 
            this.bottomUpToolStripMenuItem.Name = "bottomUpToolStripMenuItem";
            this.bottomUpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bottomUpToolStripMenuItem.Text = "&BottomUp";
            this.bottomUpToolStripMenuItem.Click += new System.EventHandler(this.bottomUpToolStripMenuItem_Click);
            // 
            // topDownToolStripMenuItem
            // 
            this.topDownToolStripMenuItem.Name = "topDownToolStripMenuItem";
            this.topDownToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.topDownToolStripMenuItem.Text = "&TopDown";
            this.topDownToolStripMenuItem.Click += new System.EventHandler(this.topDownToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftToRightToolStripMenuItem,
            this.rightToLeftToolStripMenuItem});
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.horizontalToolStripMenuItem.Text = "&Horizontal";
            // 
            // leftToRightToolStripMenuItem
            // 
            this.leftToRightToolStripMenuItem.Name = "leftToRightToolStripMenuItem";
            this.leftToRightToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.leftToRightToolStripMenuItem.Text = "&LeftToRight";
            this.leftToRightToolStripMenuItem.Click += new System.EventHandler(this.leftToRightToolStripMenuItem_Click);
            // 
            // rightToLeftToolStripMenuItem
            // 
            this.rightToLeftToolStripMenuItem.Name = "rightToLeftToolStripMenuItem";
            this.rightToLeftToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rightToLeftToolStripMenuItem.Text = "&RightToLeft";
            this.rightToLeftToolStripMenuItem.Click += new System.EventHandler(this.rightToLeftToolStripMenuItem_Click);
            // 
            // splitStackToolStripMenuItem
            // 
            this.splitStackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem,
            this.verticalToolStripMenuItem1,
            this.horizontalToolStripMenuItem1});
            this.splitStackToolStripMenuItem.Name = "splitStackToolStripMenuItem";
            this.splitStackToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.splitStackToolStripMenuItem.Text = "&SplitStack";
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.autoToolStripMenuItem.Text = "&Auto";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem1
            // 
            this.verticalToolStripMenuItem1.Name = "verticalToolStripMenuItem1";
            this.verticalToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.verticalToolStripMenuItem1.Text = "&Vertical";
            this.verticalToolStripMenuItem1.Click += new System.EventHandler(this.verticalToolStripMenuItem1_Click);
            // 
            // horizontalToolStripMenuItem1
            // 
            this.horizontalToolStripMenuItem1.Name = "horizontalToolStripMenuItem1";
            this.horizontalToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.horizontalToolStripMenuItem1.Text = "&Horizontal";
            this.horizontalToolStripMenuItem1.Click += new System.EventHandler(this.horizontalToolStripMenuItem1_Click);
            // 
            // DockButton
            // 
            this.DockButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftToolStripMenuItem,
            this.rightToolStripMenuItem,
            this.topToolStripMenuItem,
            this.bottomToolStripMenuItem,
            this.fillToolStripMenuItem});
            this.DockButton.Image = ((System.Drawing.Image)(resources.GetObject("DockButton.Image")));
            this.DockButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DockButton.Name = "DockButton";
            this.DockButton.Size = new System.Drawing.Size(59, 22);
            this.DockButton.Text = "&Dock";
            this.DockButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DockButton_DropDownItemClicked);
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.leftToolStripMenuItem.Text = "&Left";
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rightToolStripMenuItem.Text = "&Right";
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.topToolStripMenuItem.Text = "&Top";
            // 
            // bottomToolStripMenuItem
            // 
            this.bottomToolStripMenuItem.Name = "bottomToolStripMenuItem";
            this.bottomToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bottomToolStripMenuItem.Text = "&Bottom";
            // 
            // fillToolStripMenuItem
            // 
            this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            this.fillToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fillToolStripMenuItem.Text = "&Fill";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TextImageRelationButton
            // 
            this.TextImageRelationButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageBeforeTextToolStripMenuItem,
            this.textBeforeImageToolStripMenuItem,
            this.imageAboveTextToolStripMenuItem,
            this.textAboveImageToolStripMenuItem,
            this.overlayToolStripMenuItem});
            this.TextImageRelationButton.Image = ((System.Drawing.Image)(resources.GetObject("TextImageRelationButton.Image")));
            this.TextImageRelationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TextImageRelationButton.Name = "TextImageRelationButton";
            this.TextImageRelationButton.Size = new System.Drawing.Size(127, 22);
            this.TextImageRelationButton.Text = "TextImage&Relation";
            this.TextImageRelationButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TextImageRelationButton_DropDownItemClicked);
            // 
            // imageBeforeTextToolStripMenuItem
            // 
            this.imageBeforeTextToolStripMenuItem.Name = "imageBeforeTextToolStripMenuItem";
            this.imageBeforeTextToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.imageBeforeTextToolStripMenuItem.Text = "&ImageBeforeText";
            // 
            // textBeforeImageToolStripMenuItem
            // 
            this.textBeforeImageToolStripMenuItem.Name = "textBeforeImageToolStripMenuItem";
            this.textBeforeImageToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.textBeforeImageToolStripMenuItem.Text = "&TextBeforeImage";
            // 
            // imageAboveTextToolStripMenuItem
            // 
            this.imageAboveTextToolStripMenuItem.Name = "imageAboveTextToolStripMenuItem";
            this.imageAboveTextToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.imageAboveTextToolStripMenuItem.Text = "Image&AboveText";
            // 
            // textAboveImageToolStripMenuItem
            // 
            this.textAboveImageToolStripMenuItem.Name = "textAboveImageToolStripMenuItem";
            this.textAboveImageToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.textAboveImageToolStripMenuItem.Text = "TextA&boveImage";
            // 
            // overlayToolStripMenuItem
            // 
            this.overlayToolStripMenuItem.Name = "overlayToolStripMenuItem";
            this.overlayToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.overlayToolStripMenuItem.Text = "&Overlay";
            // 
            // TextAlignButton
            // 
            this.TextAlignButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftToolStripMenuItem1,
            this.righToolStripMenuItem,
            this.rightToolStripMenuItem1});
            this.TextAlignButton.Image = ((System.Drawing.Image)(resources.GetObject("TextAlignButton.Image")));
            this.TextAlignButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TextAlignButton.Name = "TextAlignButton";
            this.TextAlignButton.Size = new System.Drawing.Size(81, 22);
            this.TextAlignButton.Text = "&TextAlign";
            this.TextAlignButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TextAlignButton_DropDownItemClicked);
            // 
            // leftToolStripMenuItem1
            // 
            this.leftToolStripMenuItem1.Name = "leftToolStripMenuItem1";
            this.leftToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.leftToolStripMenuItem1.Text = "&Left";
            // 
            // righToolStripMenuItem
            // 
            this.righToolStripMenuItem.Name = "righToolStripMenuItem";
            this.righToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.righToolStripMenuItem.Text = "&Center";
            // 
            // rightToolStripMenuItem1
            // 
            this.rightToolStripMenuItem1.Name = "rightToolStripMenuItem1";
            this.rightToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.rightToolStripMenuItem1.Text = "&Right";
            // 
            // ImageAlignButton
            // 
            this.ImageAlignButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftToolStripMenuItem2,
            this.centerToolStripMenuItem,
            this.rightToolStripMenuItem2});
            this.ImageAlignButton.Image = ((System.Drawing.Image)(resources.GetObject("ImageAlignButton.Image")));
            this.ImageAlignButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImageAlignButton.Name = "ImageAlignButton";
            this.ImageAlignButton.Size = new System.Drawing.Size(89, 22);
            this.ImageAlignButton.Text = "&ImageAlign";
            this.ImageAlignButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ImageAlignButton_DropDownItemClicked);
            // 
            // leftToolStripMenuItem2
            // 
            this.leftToolStripMenuItem2.Name = "leftToolStripMenuItem2";
            this.leftToolStripMenuItem2.Size = new System.Drawing.Size(110, 22);
            this.leftToolStripMenuItem2.Text = "&Left";
            // 
            // centerToolStripMenuItem
            // 
            this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            this.centerToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.centerToolStripMenuItem.Text = "&Center";
            // 
            // rightToolStripMenuItem2
            // 
            this.rightToolStripMenuItem2.Name = "rightToolStripMenuItem2";
            this.rightToolStripMenuItem2.Size = new System.Drawing.Size(110, 22);
            this.rightToolStripMenuItem2.Text = "&Right";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // SampleLauncher
            // 
            this.ClientSize = new System.Drawing.Size(558, 397);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "SampleLauncher";
            this.Text = "ToolStripSamples";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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


        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton LayoutButton;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splitStackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton TextImageRelationButton;
        private System.Windows.Forms.ToolStripMenuItem bottomUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftToRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton DockButton;
        private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageBeforeTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textBeforeImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageAboveTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textAboveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton ImageAlignButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton TextAlignButton;
        private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem righToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem2;
    }
}


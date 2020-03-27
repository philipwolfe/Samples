namespace UsingMenusStatusStripsToolStrips
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.docContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.formatContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.formatBoldContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.formatItalicsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.formatUnderlineContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.EntryArea = new System.Windows.Forms.RichTextBox();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.boldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.italicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.underlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testProgressBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeOpacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.twentfivePercent = new System.Windows.Forms.ToolStripMenuItem();
			this.fiftyPercent = new System.Windows.Forms.ToolStripMenuItem();
			this.seventyfivePercent = new System.Windows.Forms.ToolStripMenuItem();
			this.onehundredPercent = new System.Windows.Forms.ToolStripMenuItem();
			this.formatToolStrip = new System.Windows.Forms.ToolStrip();
			this.formatToolStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.formatToolStripBoldButton = new System.Windows.Forms.ToolStripButton();
			this.formatToolStripItalicsButton = new System.Windows.Forms.ToolStripButton();
			this.formatToolStripUnderlineButton = new System.Windows.Forms.ToolStripButton();
			this.fileToolStrip = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.docContextMenuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.mainMenuStrip.SuspendLayout();
			this.formatToolStrip.SuspendLayout();
			this.fileToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// docContextMenuStrip
			// 
			this.docContextMenuStrip.Enabled = true;
			this.docContextMenuStrip.GripMargin = new System.Windows.Forms.Padding(2);
			this.docContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatContextMenuItem});
			this.docContextMenuStrip.Location = new System.Drawing.Point(25, 66);
			this.docContextMenuStrip.Name = "docContextMenuStrip";
			this.docContextMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.docContextMenuStrip.Size = new System.Drawing.Size(98, 26);
			// 
			// formatContextMenuItem
			// 
			this.formatContextMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatBoldContextMenuItem,
            this.formatItalicsContextMenuItem,
            this.formatUnderlineContextMenuItem});
			this.formatContextMenuItem.Name = "formatContextMenuItem";
			this.formatContextMenuItem.Text = "Format";
			// 
			// formatBoldContextMenuItem
			// 
			this.formatBoldContextMenuItem.Name = "formatBoldContextMenuItem";
			this.formatBoldContextMenuItem.Text = "&Bold";
			this.formatBoldContextMenuItem.Click += new System.EventHandler(this.formatMenuItem_Click);
			// 
			// formatItalicsContextMenuItem
			// 
			this.formatItalicsContextMenuItem.Name = "formatItalicsContextMenuItem";
			this.formatItalicsContextMenuItem.Text = "&Italics";
			this.formatItalicsContextMenuItem.Click += new System.EventHandler(this.formatMenuItem_Click);
			// 
			// formatUnderlineContextMenuItem
			// 
			this.formatUnderlineContextMenuItem.Name = "formatUnderlineContextMenuItem";
			this.formatUnderlineContextMenuItem.Text = "&Underline";
			this.formatUnderlineContextMenuItem.Click += new System.EventHandler(this.formatMenuItem_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			// 
			// EntryArea
			// 
			this.EntryArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.EntryArea.ContextMenuStrip = this.docContextMenuStrip;
			this.EntryArea.Location = new System.Drawing.Point(0, 53);
			this.EntryArea.Name = "EntryArea";
			this.EntryArea.Size = new System.Drawing.Size(543, 336);
			this.EntryArea.TabIndex = 3;
			this.EntryArea.Text = "";
			// 
			// statusStrip
			// 
			this.statusStrip.AutoSize = false;
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
			this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
			this.statusStrip.Location = new System.Drawing.Point(0, 392);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(542, 24);
			this.statusStrip.TabIndex = 4;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Text = "Status";
			// 
			// toolStripProgressBar
			// 
			this.toolStripProgressBar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new System.Drawing.Size(100, 17);
			this.toolStripProgressBar.Text = "toolStripProgressBar1";
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.BackColor = System.Drawing.SystemColors.MenuBar;
			this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.optionsToolStripMenuItem});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.mainMenuStrip.Size = new System.Drawing.Size(140, 24);
			this.mainMenuStrip.TabIndex = 1;
			this.mainMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.fileMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.fileMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.fileMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.fileMenuItem_Click);
			// 
			// formatToolStripMenuItem
			// 
			this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boldToolStripMenuItem,
            this.italicsToolStripMenuItem,
            this.underlineToolStripMenuItem});
			this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
			this.formatToolStripMenuItem.Text = "Fo&rmat";
			// 
			// boldToolStripMenuItem
			// 
			this.boldToolStripMenuItem.CheckOnClick = true;
			this.boldToolStripMenuItem.Image = UsingMenusStatusStripsToolStrips.Properties.Resources.Bold;
			this.boldToolStripMenuItem.Name = "boldToolStripMenuItem";
			this.boldToolStripMenuItem.Text = "&Bold";
			this.boldToolStripMenuItem.Click += new System.EventHandler(this.formatMenuItem_Click);
			// 
			// italicsToolStripMenuItem
			// 
			this.italicsToolStripMenuItem.CheckOnClick = true;
			this.italicsToolStripMenuItem.Image = UsingMenusStatusStripsToolStrips.Properties.Resources.Italics;
			this.italicsToolStripMenuItem.Name = "italicsToolStripMenuItem";
			this.italicsToolStripMenuItem.Text = "&Italics";
			this.italicsToolStripMenuItem.Click += new System.EventHandler(this.formatMenuItem_Click);
			// 
			// underlineToolStripMenuItem
			// 
			this.underlineToolStripMenuItem.CheckOnClick = true;
			this.underlineToolStripMenuItem.Image = UsingMenusStatusStripsToolStrips.Properties.Resources.Underline;
			this.underlineToolStripMenuItem.Name = "underlineToolStripMenuItem";
			this.underlineToolStripMenuItem.Text = "&Underline";
			this.underlineToolStripMenuItem.Click += new System.EventHandler(this.formatMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testProgressBarToolStripMenuItem,
            this.changeOpacityToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Text = "O&ptions";
			// 
			// testProgressBarToolStripMenuItem
			// 
			this.testProgressBarToolStripMenuItem.Name = "testProgressBarToolStripMenuItem";
			this.testProgressBarToolStripMenuItem.Text = "&Test Progress Bar";
			this.testProgressBarToolStripMenuItem.Click += new System.EventHandler(this.testProgressBarToolStripMenuItem_Click);
			// 
			// changeOpacityToolStripMenuItem
			// 
			this.changeOpacityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.twentfivePercent,
            this.fiftyPercent,
            this.seventyfivePercent,
            this.onehundredPercent});
			this.changeOpacityToolStripMenuItem.Name = "changeOpacityToolStripMenuItem";
			this.changeOpacityToolStripMenuItem.Text = "&Change Opacity";
			// 
			// twentfivePercent
			// 
			this.twentfivePercent.CheckOnClick = true;
			this.twentfivePercent.Name = "twentfivePercent";
			this.twentfivePercent.Tag = ".25";
			this.twentfivePercent.Text = "&25%";
			this.twentfivePercent.Click += new System.EventHandler(this.changeOpacityToolStripMenuItem_Click);
			// 
			// fiftyPercent
			// 
			this.fiftyPercent.CheckOnClick = true;
			this.fiftyPercent.Name = "fiftyPercent";
			this.fiftyPercent.Tag = ".50";
			this.fiftyPercent.Text = "&50%";
			this.fiftyPercent.Click += new System.EventHandler(this.changeOpacityToolStripMenuItem_Click);
			// 
			// seventyfivePercent
			// 
			this.seventyfivePercent.CheckOnClick = true;
			this.seventyfivePercent.Name = "seventyfivePercent";
			this.seventyfivePercent.Tag = ".75";
			this.seventyfivePercent.Text = "&75%";
			this.seventyfivePercent.Click += new System.EventHandler(this.changeOpacityToolStripMenuItem_Click);
			// 
			// onehundredPercent
			// 
			this.onehundredPercent.CheckOnClick = true;
			this.onehundredPercent.Name = "onehundredPercent";
			this.onehundredPercent.Tag = "1";
			this.onehundredPercent.Text = "&100%";
			this.onehundredPercent.Click += new System.EventHandler(this.changeOpacityToolStripMenuItem_Click);
			// 
			// formatToolStrip
			// 
			this.formatToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.formatToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatToolStripLabel,
            this.formatToolStripBoldButton,
            this.formatToolStripItalicsButton,
            this.formatToolStripUnderlineButton});
			this.formatToolStrip.Location = new System.Drawing.Point(80, 25);
			this.formatToolStrip.Name = "formatToolStrip";
			this.formatToolStrip.Size = new System.Drawing.Size(148, 25);
			this.formatToolStrip.TabIndex = 2;
			this.formatToolStrip.Text = "toolStrip1";
			this.formatToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.formatToolStrip_ItemClicked);
			// 
			// formatToolStripLabel
			// 
			this.formatToolStripLabel.Name = "formatToolStripLabel";
			this.formatToolStripLabel.Text = "Format";
			// 
			// formatToolStripBoldButton
			// 
			this.formatToolStripBoldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.formatToolStripBoldButton.Image = UsingMenusStatusStripsToolStrips.Properties.Resources.Bold;
			this.formatToolStripBoldButton.Name = "formatToolStripBoldButton";
			this.formatToolStripBoldButton.Text = "&Bold";
			// 
			// formatToolStripItalicsButton
			// 
			this.formatToolStripItalicsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.formatToolStripItalicsButton.Image = UsingMenusStatusStripsToolStrips.Properties.Resources.Italics;
			this.formatToolStripItalicsButton.Name = "formatToolStripItalicsButton";
			this.formatToolStripItalicsButton.Text = "&Italics";
			// 
			// formatToolStripUnderlineButton
			// 
			this.formatToolStripUnderlineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.formatToolStripUnderlineButton.Image = UsingMenusStatusStripsToolStrips.Properties.Resources.Underline;
			this.formatToolStripUnderlineButton.Name = "formatToolStripUnderlineButton";
			this.formatToolStripUnderlineButton.Text = "&Underline";
			// 
			// fileToolStrip
			// 
			this.fileToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.fileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton});
			this.fileToolStrip.Location = new System.Drawing.Point(0, 25);
			this.fileToolStrip.Name = "fileToolStrip";
			this.fileToolStrip.Size = new System.Drawing.Size(111, 25);
			this.fileToolStrip.TabIndex = 5;
			this.fileToolStrip.Text = "toolStrip1";
			this.fileToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.fileToolStrip_ItemClicked);
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Text = "&New";
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Text = "&Open";
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Text = "&Save";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.AddExtension = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(542, 416);
			this.Controls.Add(this.fileToolStrip);
			this.Controls.Add(this.EntryArea);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.mainMenuStrip);
			this.Controls.Add(this.formatToolStrip);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Using Menus, StatusStrips, ToolStrips";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.docContextMenuStrip.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.mainMenuStrip.ResumeLayout(false);
			this.formatToolStrip.ResumeLayout(false);
			this.fileToolStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip docContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem formatContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem formatBoldContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem formatItalicsContextMenuItem;
		private System.Windows.Forms.ToolStripMenuItem formatUnderlineContextMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.RichTextBox EntryArea;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem boldToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem italicsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem underlineToolStripMenuItem;
		private System.Windows.Forms.ToolStrip formatToolStrip;
		private System.Windows.Forms.ToolStripLabel formatToolStripLabel;
		private System.Windows.Forms.ToolStripButton formatToolStripBoldButton;
		private System.Windows.Forms.ToolStripButton formatToolStripItalicsButton;
		private System.Windows.Forms.ToolStripButton formatToolStripUnderlineButton;
		private System.Windows.Forms.ToolStrip fileToolStrip;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testProgressBarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeOpacityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem twentfivePercent;
		private System.Windows.Forms.ToolStripMenuItem fiftyPercent;
		private System.Windows.Forms.ToolStripMenuItem seventyfivePercent;
		private System.Windows.Forms.ToolStripMenuItem onehundredPercent;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

	}
}


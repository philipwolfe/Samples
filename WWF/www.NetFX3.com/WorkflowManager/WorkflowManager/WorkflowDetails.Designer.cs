//---------------------------------------------------------------------
//  This file is part of the NetFx3.com web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------
namespace Microsoft.Workflow.Samples.WorkflowManager
{
	partial class WorkflowDetailsForm
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
			this.fileMainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editMainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.suspendToolButton = new System.Windows.Forms.ToolStripButton();
			this.resumeToolButton = new System.Windows.Forms.ToolStripButton();
			this.terminateToolButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolButton = new System.Windows.Forms.ToolStripButton();
			this.saveAsToolButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.changeToolButton = new System.Windows.Forms.ToolStripButton();
			this.acceptChangeToolButton = new System.Windows.Forms.ToolStripButton();
			this.cancelChangesToolButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.expandOutlineToolButton = new System.Windows.Forms.ToolStripButton();
			this.aggreagateOutlineToolButton = new System.Windows.Forms.ToolStripButton();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.titlePanel = new System.Windows.Forms.Panel();
			this.typeLabel = new System.Windows.Forms.Label();
			this.typeRichTextBox = new System.Windows.Forms.RichTextBox();
			this.activatedRichTextBox = new System.Windows.Forms.RichTextBox();
			this.titleLabel = new System.Windows.Forms.Label();
			this.activatedLabel = new System.Windows.Forms.Label();
			this.titleRichTextBox = new System.Windows.Forms.RichTextBox();
			this.contentPanel = new System.Windows.Forms.Panel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.mainPanel.SuspendLayout();
			this.titlePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMainMenuItem,
            this.editMainMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(872, 24);
			this.menuStrip1.TabIndex = 8;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileMainMenuItem
			// 
			this.fileMainMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
			this.fileMainMenuItem.Name = "fileMainMenuItem";
			this.fileMainMenuItem.Text = "File";
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Name = "exitMenuItem";
			this.exitMenuItem.Text = "Exit";
			this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
			// 
			// editMainMenuItem
			// 
			this.editMainMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutMenuItem,
            this.copyMenuItem,
            this.pasteMenuItem,
            this.toolStripMenuItem4,
            this.deleteMenuItem});
			this.editMainMenuItem.Name = "editMainMenuItem";
			this.editMainMenuItem.Text = "Edit";
			// 
			// cutMenuItem
			// 
			this.cutMenuItem.Name = "cutMenuItem";
			this.cutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutMenuItem.Text = "Cut";
			this.cutMenuItem.Click += new System.EventHandler(this.cutMenuItem_Click);
			// 
			// copyMenuItem
			// 
			this.copyMenuItem.Name = "copyMenuItem";
			this.copyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyMenuItem.Text = "Copy";
			this.copyMenuItem.Click += new System.EventHandler(this.copyMenuItem_Click);
			// 
			// pasteMenuItem
			// 
			this.pasteMenuItem.Name = "pasteMenuItem";
			this.pasteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteMenuItem.Text = "Paste";
			this.pasteMenuItem.Click += new System.EventHandler(this.pasteMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			// 
			// deleteMenuItem
			// 
			this.deleteMenuItem.Name = "deleteMenuItem";
			this.deleteMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.deleteMenuItem.Text = "Delete";
			this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suspendToolButton,
            this.resumeToolButton,
            this.terminateToolButton,
            this.toolStripSeparator1,
            this.saveToolButton,
            this.saveAsToolButton,
            this.toolStripSeparator2,
            this.changeToolButton,
            this.acceptChangeToolButton,
            this.cancelChangesToolButton,
            this.toolStripSeparator3,
            this.expandOutlineToolButton,
            this.aggreagateOutlineToolButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(872, 25);
			this.toolStrip1.TabIndex = 9;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// suspendToolButton
			// 
			this.suspendToolButton.Image = Properties.Resources.Suspend;
			this.suspendToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.suspendToolButton.Name = "suspendToolButton";
			this.suspendToolButton.Text = "Suspend";
			this.suspendToolButton.Click += new System.EventHandler(this.suspendToolButton_Click);
			// 
			// resumeToolButton
			// 
			this.resumeToolButton.Image = Properties.Resources.Resume;
			this.resumeToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.resumeToolButton.Name = "resumeToolButton";
			this.resumeToolButton.Text = "Resume";
			this.resumeToolButton.Click += new System.EventHandler(this.resumeToolButton_Click);
			// 
			// terminateToolButton
			// 
			this.terminateToolButton.Image = Properties.Resources.Terminate;
			this.terminateToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.terminateToolButton.Name = "terminateToolButton";
			this.terminateToolButton.Text = "Terminate";
			this.terminateToolButton.Click += new System.EventHandler(this.terminateToolButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			// 
			// saveToolButton
			// 
			this.saveToolButton.Image = Properties.Resources.Save;
			this.saveToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolButton.Name = "saveToolButton";
			this.saveToolButton.Text = "Save";
			this.saveToolButton.Visible = false;
			// 
			// saveAsToolButton
			// 
			this.saveAsToolButton.Image = Properties.Resources.SaveAs;
			this.saveAsToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveAsToolButton.Name = "saveAsToolButton";
			this.saveAsToolButton.Text = "Save As...";
			this.saveAsToolButton.Visible = false;
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Visible = false;
			// 
			// changeToolButton
			// 
			this.changeToolButton.Image = Properties.Resources.Edit1;
			this.changeToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.changeToolButton.Name = "changeToolButton";
			this.changeToolButton.Text = "Change Workflow";
			this.changeToolButton.Click += new System.EventHandler(this.changeToolButton_Click);
			// 
			// acceptChangeToolButton
			// 
			this.acceptChangeToolButton.Image = Properties.Resources.AcceptChanges;
			this.acceptChangeToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.acceptChangeToolButton.Name = "acceptChangeToolButton";
			this.acceptChangeToolButton.Text = "Accept Changes";
			this.acceptChangeToolButton.Visible = false;
			this.acceptChangeToolButton.Click += new System.EventHandler(this.acceptChangeToolButton_Click);
			// 
			// cancelChangesToolButton
			// 
			this.cancelChangesToolButton.Image = Properties.Resources.CancelChanges;
			this.cancelChangesToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cancelChangesToolButton.Name = "cancelChangesToolButton";
			this.cancelChangesToolButton.Text = "Cancel Changes";
			this.cancelChangesToolButton.Visible = false;
			this.cancelChangesToolButton.Click += new System.EventHandler(this.cancelChangesToolButton_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Visible = false;
			// 
			// expandOutlineToolButton
			// 
			this.expandOutlineToolButton.Image = Properties.Resources.ExpandExecutionTree;
			this.expandOutlineToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.expandOutlineToolButton.Name = "expandOutlineToolButton";
			this.expandOutlineToolButton.Text = "Expand Outline";
			this.expandOutlineToolButton.Visible = false;
			this.expandOutlineToolButton.Click += new System.EventHandler(this.expandOutlineToolButton_Click);
			// 
			// aggreagateOutlineToolButton
			// 
			this.aggreagateOutlineToolButton.Image = Properties.Resources.AggregateExecutionTree;
			this.aggreagateOutlineToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.aggreagateOutlineToolButton.Name = "aggreagateOutlineToolButton";
			this.aggreagateOutlineToolButton.Text = "Aggregate Outline";
			this.aggreagateOutlineToolButton.Visible = false;
			this.aggreagateOutlineToolButton.Click += new System.EventHandler(this.aggreagateOutlineToolButton_Click);
			// 
			// mainPanel
			// 
			this.mainPanel.Controls.Add(this.titlePanel);
			this.mainPanel.Controls.Add(this.contentPanel);
			this.mainPanel.Controls.Add(this.toolStrip1);
			this.mainPanel.Controls.Add(this.menuStrip1);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(872, 566);
			this.mainPanel.TabIndex = 4;
			// 
			// titlePanel
			// 
			this.titlePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.titlePanel.BackColor = System.Drawing.SystemColors.Control;
			this.titlePanel.Controls.Add(this.typeLabel);
			this.titlePanel.Controls.Add(this.typeRichTextBox);
			this.titlePanel.Controls.Add(this.activatedRichTextBox);
			this.titlePanel.Controls.Add(this.titleLabel);
			this.titlePanel.Controls.Add(this.activatedLabel);
			this.titlePanel.Controls.Add(this.titleRichTextBox);
			this.titlePanel.Location = new System.Drawing.Point(0, 52);
			this.titlePanel.Name = "titlePanel";
			this.titlePanel.Size = new System.Drawing.Size(872, 42);
			this.titlePanel.TabIndex = 7;
			// 
			// typeLabel
			// 
			this.typeLabel.AutoSize = true;
			this.typeLabel.Location = new System.Drawing.Point(12, 3);
			this.typeLabel.Name = "typeLabel";
			this.typeLabel.Size = new System.Drawing.Size(30, 13);
			this.typeLabel.TabIndex = 0;
			this.typeLabel.Text = "Type:";
			// 
			// typeRichTextBox
			// 
			this.typeRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.typeRichTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.typeRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.typeRichTextBox.DetectUrls = false;
			this.typeRichTextBox.Location = new System.Drawing.Point(44, 4);
			this.typeRichTextBox.Name = "typeRichTextBox";
			this.typeRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.typeRichTextBox.Size = new System.Drawing.Size(573, 18);
			this.typeRichTextBox.TabIndex = 2;
			this.typeRichTextBox.Text = "Type name goes here";
			this.typeRichTextBox.WordWrap = false;
			// 
			// activatedRichTextBox
			// 
			this.activatedRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.activatedRichTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.activatedRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.activatedRichTextBox.DetectUrls = false;
			this.activatedRichTextBox.Location = new System.Drawing.Point(673, 4);
			this.activatedRichTextBox.Multiline = false;
			this.activatedRichTextBox.Name = "activatedRichTextBox";
			this.activatedRichTextBox.ReadOnly = true;
			this.activatedRichTextBox.Size = new System.Drawing.Size(199, 18);
			this.activatedRichTextBox.TabIndex = 5;
			this.activatedRichTextBox.Text = "Activation time goes here";
			this.activatedRichTextBox.WordWrap = false;
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Location = new System.Drawing.Point(13, 22);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(26, 13);
			this.titleLabel.TabIndex = 1;
			this.titleLabel.Text = "Title:";
			// 
			// activatedLabel
			// 
			this.activatedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.activatedLabel.AutoSize = true;
			this.activatedLabel.Location = new System.Drawing.Point(618, 4);
			this.activatedLabel.Name = "activatedLabel";
			this.activatedLabel.Size = new System.Drawing.Size(51, 13);
			this.activatedLabel.TabIndex = 4;
			this.activatedLabel.Text = "Activated:";
			// 
			// titleRichTextBox
			// 
			this.titleRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.titleRichTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.titleRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.titleRichTextBox.DetectUrls = false;
			this.titleRichTextBox.Location = new System.Drawing.Point(44, 22);
			this.titleRichTextBox.Multiline = false;
			this.titleRichTextBox.Name = "titleRichTextBox";
			this.titleRichTextBox.ReadOnly = true;
			this.titleRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.titleRichTextBox.Size = new System.Drawing.Size(828, 18);
			this.titleRichTextBox.TabIndex = 3;
			this.titleRichTextBox.Text = "Title goes here";
			this.titleRichTextBox.WordWrap = false;
			// 
			// contentPanel
			// 
			this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.contentPanel.BackColor = System.Drawing.SystemColors.Window;
			this.contentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.contentPanel.ForeColor = System.Drawing.SystemColors.InactiveCaption;
			this.contentPanel.Location = new System.Drawing.Point(6, 101);
			this.contentPanel.Name = "contentPanel";
			this.contentPanel.Size = new System.Drawing.Size(860, 459);
			this.contentPanel.TabIndex = 6;
			// 
			// WorkflowDetailsForm
			// 
			this.ClientSize = new System.Drawing.Size(872, 566);
			this.Controls.Add(this.mainPanel);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "WorkflowDetailsForm";
			this.Text = "Workflow Details";
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.titlePanel.ResumeLayout(false);
			this.titlePanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStripMenuItem fileMainMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
		private System.Windows.Forms.ToolStripButton suspendToolButton;
		private System.Windows.Forms.ToolStripButton resumeToolButton;
		private System.Windows.Forms.ToolStripButton terminateToolButton;
		private System.Windows.Forms.ToolStripButton saveToolButton;
		private System.Windows.Forms.ToolStripButton saveAsToolButton;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Label typeLabel;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.RichTextBox typeRichTextBox;
		private System.Windows.Forms.Label activatedLabel;
		private System.Windows.Forms.RichTextBox titleRichTextBox;
		private System.Windows.Forms.RichTextBox activatedRichTextBox;
		private System.Windows.Forms.Panel contentPanel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton changeToolButton;
		private System.Windows.Forms.ToolStripButton acceptChangeToolButton;
		private System.Windows.Forms.ToolStripButton cancelChangesToolButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton expandOutlineToolButton;
		private System.Windows.Forms.ToolStripButton aggreagateOutlineToolButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Panel titlePanel;
		private System.Windows.Forms.ToolStripMenuItem editMainMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cutMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
	}
}
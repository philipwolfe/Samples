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
using System.Drawing;
namespace Microsoft.Workflow.Samples.WorkflowManager
{
	partial class WorkflowManager
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkflowManager));
			this.sources_MainViews = new System.Windows.Forms.SplitContainer();
			this.workflowDataSources = new System.Windows.Forms.TreeView();
			this.sectionHeader1 = new SectionHeader();
			this.list_preview = new System.Windows.Forms.SplitContainer();
			this.dataGridViewExplore1 = new DataGridViewExplore();
			this.sectionHeader2 = new SectionHeader();
			this.wfPreviewControl1 = new WFPreviewControl();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileMainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.wfStateImageList = new System.Windows.Forms.ImageList(this.components);
			this.sources_MainViews.Panel1.SuspendLayout();
			this.sources_MainViews.Panel2.SuspendLayout();
			this.sources_MainViews.SuspendLayout();
			this.list_preview.Panel1.SuspendLayout();
			this.list_preview.Panel2.SuspendLayout();
			this.list_preview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewExplore1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// sources_MainViews
			// 
			this.sources_MainViews.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sources_MainViews.Location = new System.Drawing.Point(0, 24);
			this.sources_MainViews.Name = "sources_MainViews";
			// 
			// Panel1
			// 
			this.sources_MainViews.Panel1.Controls.Add(this.workflowDataSources);
			this.sources_MainViews.Panel1.Controls.Add(this.sectionHeader1);
			// 
			// Panel2
			// 
			this.sources_MainViews.Panel2.Controls.Add(this.list_preview);
			this.sources_MainViews.Size = new System.Drawing.Size(892, 574);
			this.sources_MainViews.SplitterDistance = 123;
			this.sources_MainViews.TabIndex = 0;
			this.sources_MainViews.Text = "splitContainer1";
			// 
			// workflowDataSources
			// 
			this.workflowDataSources.Dock = System.Windows.Forms.DockStyle.Fill;
			this.workflowDataSources.HideSelection = false;
			this.workflowDataSources.Location = new System.Drawing.Point(0, 30);
			this.workflowDataSources.Name = "workflowDataSources";
			this.workflowDataSources.ShowPlusMinus = false;
			this.workflowDataSources.ShowRootLines = false;
			this.workflowDataSources.Size = new System.Drawing.Size(123, 544);
			this.workflowDataSources.TabIndex = 0;
			// 
			// sectionHeader1
			// 
			this.sectionHeader1.Dock = System.Windows.Forms.DockStyle.Top;
			this.sectionHeader1.ForeColor = System.Drawing.SystemColors.Highlight;
			this.sectionHeader1.HeaderText = "Workflow";
			this.sectionHeader1.Location = new System.Drawing.Point(0, 0);
			this.sectionHeader1.Name = "sectionHeader1";
			this.sectionHeader1.Size = new System.Drawing.Size(123, 30);
			this.sectionHeader1.TabIndex = 0;
			// 
			// list_preview
			// 
			this.list_preview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.list_preview.Location = new System.Drawing.Point(0, 0);
			this.list_preview.Name = "list_preview";
			// 
			// Panel1
			// 
			this.list_preview.Panel1.Controls.Add(this.dataGridViewExplore1);
			this.list_preview.Panel1.Controls.Add(this.sectionHeader2);
			// 
			// Panel2
			// 
			this.list_preview.Panel2.Controls.Add(this.wfPreviewControl1);
			this.list_preview.Size = new System.Drawing.Size(765, 574);
			this.list_preview.SplitterDistance = 377;
			this.list_preview.TabIndex = 0;
			this.list_preview.Text = "splitContainer1";
			// 
			// dataGridViewExplore1
			// 
			this.dataGridViewExplore1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridViewExplore1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridViewExplore1.ColumnHeadersHeight = 20;
			this.dataGridViewExplore1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridViewExplore1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewExplore1.Location = new System.Drawing.Point(0, 30);
			this.dataGridViewExplore1.Name = "dataGridViewExplore1";
			this.dataGridViewExplore1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExplore1.Size = new System.Drawing.Size(377, 544);
			this.dataGridViewExplore1.TabIndex = 1;
			// 
			// sectionHeader2
			// 
			this.sectionHeader2.Dock = System.Windows.Forms.DockStyle.Top;
			this.sectionHeader2.ForeColor = System.Drawing.SystemColors.Highlight;
			this.sectionHeader2.HeaderText = "Workflow Instances";
			this.sectionHeader2.Location = new System.Drawing.Point(0, 0);
			this.sectionHeader2.Name = "sectionHeader2";
			this.sectionHeader2.Size = new System.Drawing.Size(377, 30);
			this.sectionHeader2.TabIndex = 0;
			// 
			// wfPreviewControl1
			// 
			this.wfPreviewControl1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.wfPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wfPreviewControl1.Location = new System.Drawing.Point(0, 0);
			this.wfPreviewControl1.Name = "wfPreviewControl1";
			this.wfPreviewControl1.SelectedInstance = null;
			this.wfPreviewControl1.Size = new System.Drawing.Size(384, 574);
			this.wfPreviewControl1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMainMenuItem,
            this.helpMainMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
			//this.menuStrip1.Raft = System.Windows.Forms.RaftingSides.Top;
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "mainMenu";
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
			// 
			// helpMainMenuItem
			// 
			this.helpMainMenuItem.Name = "helpMainMenuItem";
			this.helpMainMenuItem.Text = "Help";
			// 
			// statusStrip1
			// 
			this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
			this.statusStrip1.Location = new System.Drawing.Point(0, 0);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(892, 18);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.Images.SetKeyName(0, "WorkflowDataSourceRoot");
			this.imageList1.Images.SetKeyName(1, "LiveDataSource");
			this.imageList1.Images.SetKeyName(2, "TrackedDataSource");
			this.imageList1.Images.SetKeyName(3, "TroublesomeDataSource");
			// 
			// wfStateImageList
			// 
			this.wfStateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("wfStateImageList.ImageStream")));
			this.wfStateImageList.Images.SetKeyName(0, "StartedLive");
			this.wfStateImageList.Images.SetKeyName(1, "StartedLiveOpened");
			this.wfStateImageList.Images.SetKeyName(2, "StartedTracked");
			this.wfStateImageList.Images.SetKeyName(3, "StartedTrackedOpened");
			this.wfStateImageList.Images.SetKeyName(4, "CompletedLive");
			this.wfStateImageList.Images.SetKeyName(5, "CompletedLiveOpened");
			this.wfStateImageList.Images.SetKeyName(6, "CompletedTracked");
			this.wfStateImageList.Images.SetKeyName(7, "CompletedTrackedOpened");
			this.wfStateImageList.Images.SetKeyName(8, "SuspendedLive");
			this.wfStateImageList.Images.SetKeyName(9, "SuspendedLiveOpened");
			this.wfStateImageList.Images.SetKeyName(10, "SuspendedTracked");
			this.wfStateImageList.Images.SetKeyName(11, "SuspendedTrackedOpened");
			this.wfStateImageList.Images.SetKeyName(12, "TerminatedLive");
			this.wfStateImageList.Images.SetKeyName(13, "TerminatedLiveOpened");
			this.wfStateImageList.Images.SetKeyName(14, "TerminatedTracked");
			this.wfStateImageList.Images.SetKeyName(15, "TerminatedTrackedOpened");
			// 
			// WorkflowManager
			// 
			this.ClientSize = new System.Drawing.Size(892, 616);
			this.Controls.Add(this.sources_MainViews);
			this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "WorkflowManager";
			this.Text = "Windows Workflow Manager";
			this.sources_MainViews.Panel1.ResumeLayout(false);
			this.sources_MainViews.Panel2.ResumeLayout(false);
			this.sources_MainViews.ResumeLayout(false);
			this.list_preview.Panel1.ResumeLayout(false);
			this.list_preview.Panel2.ResumeLayout(false);
			this.list_preview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewExplore1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer sources_MainViews;
		private System.Windows.Forms.TreeView workflowDataSources;
		private System.Windows.Forms.SplitContainer list_preview;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileMainMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpMainMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ImageList wfStateImageList;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private SectionHeader sectionHeader1;
		private DataGridViewExplore dataGridViewExplore1;
		private SectionHeader sectionHeader2;
		private WFPreviewControl wfPreviewControl1;
	}
}
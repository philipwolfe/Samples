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
	partial class WorkflowDetailsControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.rootSplitContainer = new System.Windows.Forms.SplitContainer();
			this.workflow_toolboxSpliContainer = new System.Windows.Forms.SplitContainer();
			this.toolbox_PropGridSplitContainer = new System.Windows.Forms.SplitContainer();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.rootSplitContainer.Panel2.SuspendLayout();
			this.rootSplitContainer.SuspendLayout();
			this.workflow_toolboxSpliContainer.Panel2.SuspendLayout();
			this.workflow_toolboxSpliContainer.SuspendLayout();
			this.toolbox_PropGridSplitContainer.Panel2.SuspendLayout();
			this.toolbox_PropGridSplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// rootSplitContainer
			// 
			this.rootSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rootSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.rootSplitContainer.Name = "rootSplitContainer";
			// 
			// Panel2
			// 
			this.rootSplitContainer.Panel2.Controls.Add(this.workflow_toolboxSpliContainer);
			this.rootSplitContainer.Size = new System.Drawing.Size(800, 600);
			this.rootSplitContainer.SplitterDistance = 196;
			this.rootSplitContainer.TabIndex = 0;
			this.rootSplitContainer.Text = "splitContainer1";
			// 
			// workflow_toolboxSpliContainer
			// 
			this.workflow_toolboxSpliContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.workflow_toolboxSpliContainer.Location = new System.Drawing.Point(0, 0);
			this.workflow_toolboxSpliContainer.Name = "workflow_toolboxSpliContainer";
			// 
			// Panel2
			// 
			this.workflow_toolboxSpliContainer.Panel2.Controls.Add(this.toolbox_PropGridSplitContainer);
			this.workflow_toolboxSpliContainer.Size = new System.Drawing.Size(600, 600);
			this.workflow_toolboxSpliContainer.SplitterDistance = 429;
			this.workflow_toolboxSpliContainer.TabIndex = 0;
			this.workflow_toolboxSpliContainer.Text = "splitContainer1";
			// 
			// toolbox_PropGridSplitContainer
			// 
			this.toolbox_PropGridSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolbox_PropGridSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.toolbox_PropGridSplitContainer.Name = "toolbox_PropGridSplitContainer";
			this.toolbox_PropGridSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// Panel2
			// 
			this.toolbox_PropGridSplitContainer.Panel2.Controls.Add(this.propertyGrid);
			this.toolbox_PropGridSplitContainer.Size = new System.Drawing.Size(167, 600);
			this.toolbox_PropGridSplitContainer.SplitterDistance = 274;
			this.toolbox_PropGridSplitContainer.TabIndex = 0;
			this.toolbox_PropGridSplitContainer.Text = "splitContainer1";
			// 
			// propertyGrid
			// 
			this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid.Location = new System.Drawing.Point(0, 0);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(167, 322);
			this.propertyGrid.TabIndex = 0;
			// 
			// WorkflowDetailsControl
			// 
			this.Controls.Add(this.rootSplitContainer);
			this.Name = "WorkflowDetailsControl";
			this.Size = new System.Drawing.Size(800, 600);
			this.rootSplitContainer.Panel2.ResumeLayout(false);
			this.rootSplitContainer.ResumeLayout(false);
			this.workflow_toolboxSpliContainer.Panel2.ResumeLayout(false);
			this.workflow_toolboxSpliContainer.ResumeLayout(false);
			this.toolbox_PropGridSplitContainer.Panel2.ResumeLayout(false);
			this.toolbox_PropGridSplitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer rootSplitContainer;
		private System.Windows.Forms.SplitContainer workflow_toolboxSpliContainer;
		private System.Windows.Forms.SplitContainer toolbox_PropGridSplitContainer;
		private System.Windows.Forms.PropertyGrid propertyGrid;
	}
}

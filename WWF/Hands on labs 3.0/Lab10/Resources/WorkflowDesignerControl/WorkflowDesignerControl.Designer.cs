//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

namespace WorkflowDesignerControl
{
    partial class WorkflowDesignerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlDesigner = new System.Windows.Forms.Panel();
            this.workflowViewSplitter = new System.Windows.Forms.SplitContainer();
            this.propertyGridSplitter = new System.Windows.Forms.SplitContainer();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.pnlDesigner.SuspendLayout();
            this.workflowViewSplitter.Panel2.SuspendLayout();
            this.workflowViewSplitter.SuspendLayout();
            this.propertyGridSplitter.Panel2.SuspendLayout();
            this.propertyGridSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDesigner
            // 
            this.pnlDesigner.Controls.Add(this.workflowViewSplitter);
            this.pnlDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesigner.Location = new System.Drawing.Point(0, 0);
            this.pnlDesigner.Name = "pnlDesigner";
            this.pnlDesigner.Size = new System.Drawing.Size(699, 399);
            this.pnlDesigner.TabIndex = 1;
            this.pnlDesigner.TabStop = true;
            // 
            // workflowViewSplitter
            // 
            this.workflowViewSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workflowViewSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workflowViewSplitter.Location = new System.Drawing.Point(0, 0);
            this.workflowViewSplitter.Name = "workflowViewSplitter";
            this.workflowViewSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.workflowViewSplitter.Panel1MinSize = 300;
            // 
            // workflowViewSplitter.Panel2
            // 
            this.workflowViewSplitter.Panel2.Controls.Add(this.propertyGridSplitter);
            this.workflowViewSplitter.Size = new System.Drawing.Size(699, 399);
            this.workflowViewSplitter.SplitterDistance = 300;
            this.workflowViewSplitter.TabIndex = 0;
            this.workflowViewSplitter.Text = "splitContainer1";
            // 
            // propertyGridSplitter
            // 
            this.propertyGridSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertyGridSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridSplitter.Location = new System.Drawing.Point(0, 0);
            this.propertyGridSplitter.Name = "propertyGridSplitter";
            // 
            // propertyGridSplitter.Panel2
            // 
            this.propertyGridSplitter.Panel2.Controls.Add(this.propertyGrid);
            this.propertyGridSplitter.Size = new System.Drawing.Size(699, 95);
            this.propertyGridSplitter.SplitterDistance = 336;
            this.propertyGridSplitter.TabIndex = 1;
            this.propertyGridSplitter.Text = "splitContainer2";
            // 
            // propertyGrid
            // 
            this.propertyGrid.CommandsVisibleIfAvailable = false;
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.LineColor = System.Drawing.Color.LightSteelBlue;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid.Size = new System.Drawing.Size(357, 93);
            this.propertyGrid.TabIndex = 1;
            this.propertyGrid.ToolbarVisible = false;
            // 
            // WorkflowDesignerControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlDesigner);
            this.Name = "WorkflowDesignerControl";
            this.Size = new System.Drawing.Size(699, 399);
            this.pnlDesigner.ResumeLayout(false);
            this.workflowViewSplitter.Panel2.ResumeLayout(false);
            this.workflowViewSplitter.ResumeLayout(false);
            this.propertyGridSplitter.Panel2.ResumeLayout(false);
            this.propertyGridSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDesigner;
        private System.Windows.Forms.SplitContainer workflowViewSplitter;
        private System.Windows.Forms.SplitContainer propertyGridSplitter;
        private System.Windows.Forms.PropertyGrid propertyGrid;
    }
}

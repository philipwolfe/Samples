//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.workflowViewSplitter = new System.Windows.Forms.SplitContainer();
            this.propertyGridSplitter = new System.Windows.Forms.SplitContainer();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.panel1.SuspendLayout();
            this.workflowViewSplitter.Panel2.SuspendLayout();
            this.workflowViewSplitter.SuspendLayout();
            this.propertyGridSplitter.Panel2.SuspendLayout();
            this.propertyGridSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.workflowViewSplitter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 275);
            this.panel1.TabIndex = 1;
            this.panel1.TabStop = true;
            // 
            // workflowViewSplitter
            // 
            this.workflowViewSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workflowViewSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workflowViewSplitter.Location = new System.Drawing.Point(0, 0);
            this.workflowViewSplitter.Name = "workflowViewSplitter";
            // 
            // workflowViewSplitter.Panel2
            // 
            this.workflowViewSplitter.Panel2.Controls.Add(this.propertyGridSplitter);
            this.workflowViewSplitter.Size = new System.Drawing.Size(421, 275);
            this.workflowViewSplitter.SplitterDistance = 240;
            this.workflowViewSplitter.TabIndex = 0;
            this.workflowViewSplitter.Text = "splitContainer1";
            // 
            // propertyGridSplitter
            // 
            this.propertyGridSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertyGridSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridSplitter.Location = new System.Drawing.Point(0, 0);
            this.propertyGridSplitter.Name = "propertyGridSplitter";
            this.propertyGridSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // propertyGridSplitter.Panel2
            // 
            this.propertyGridSplitter.Panel2.Controls.Add(this.propertyGrid);
            this.propertyGridSplitter.Size = new System.Drawing.Size(177, 275);
            this.propertyGridSplitter.SplitterDistance = 124;
            this.propertyGridSplitter.TabIndex = 0;
            this.propertyGridSplitter.Text = "splitContainer2";
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(175, 145);
            this.propertyGrid.TabIndex = 1;
            this.propertyGrid.Enter += new System.EventHandler(this.propertyGrid_GotFocus);
            // 
            // WorkflowDesignerControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Name = "WorkflowDesignerControl";
            this.Size = new System.Drawing.Size(421, 275);
            this.panel1.ResumeLayout(false);
            this.workflowViewSplitter.Panel2.ResumeLayout(false);
            this.workflowViewSplitter.ResumeLayout(false);
            this.propertyGridSplitter.Panel2.ResumeLayout(false);
            this.propertyGridSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer workflowViewSplitter;
        private System.Windows.Forms.SplitContainer propertyGridSplitter;
        private System.Windows.Forms.PropertyGrid propertyGrid;
    }
}

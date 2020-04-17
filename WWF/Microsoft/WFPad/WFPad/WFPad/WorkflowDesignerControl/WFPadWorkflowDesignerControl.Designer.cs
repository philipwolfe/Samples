//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

namespace WFPadWorkflowDesignerControl
{
    partial class WFPadWorkflowDesignerControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.xomlView = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnApplyXaml = new System.Windows.Forms.ToolStripButton();
            this.btnAutoSynch = new System.Windows.Forms.ToolStripButton();
            this.btnGetXaml = new System.Windows.Forms.ToolStripButton();
            this.propertyGridSplitter = new System.Windows.Forms.SplitContainer();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.pnlDesigner.SuspendLayout();
            this.workflowViewSplitter.Panel1.SuspendLayout();
            this.workflowViewSplitter.Panel2.SuspendLayout();
            this.workflowViewSplitter.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            // 
            // workflowViewSplitter.Panel1
            // 
            this.workflowViewSplitter.Panel1.Controls.Add(this.splitContainer1);
            this.workflowViewSplitter.Panel1MinSize = 300;
            // 
            // workflowViewSplitter.Panel2
            // 
            this.workflowViewSplitter.Panel2.Controls.Add(this.propertyGridSplitter);
            this.workflowViewSplitter.Size = new System.Drawing.Size(699, 399);
            this.workflowViewSplitter.SplitterDistance = 476;
            this.workflowViewSplitter.TabIndex = 0;
            this.workflowViewSplitter.Text = "splitContainer1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(476, 399);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.xomlView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(474, 138);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // xomlView
            // 
            this.xomlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xomlView.Location = new System.Drawing.Point(3, 23);
            this.xomlView.Multiline = true;
            this.xomlView.Name = "xomlView";
            this.xomlView.Size = new System.Drawing.Size(468, 112);
            this.xomlView.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnApplyXaml,
            this.btnAutoSynch,
            this.btnGetXaml});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(474, 20);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnApplyXaml
            // 
            this.btnApplyXaml.Image = global::WFPadWorkflowDesignerControl.Properties.Resources.uparrow;
            this.btnApplyXaml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApplyXaml.Name = "btnApplyXaml";
            this.btnApplyXaml.Size = new System.Drawing.Size(79, 17);
            this.btnApplyXaml.Text = "Apply Xaml";
            this.btnApplyXaml.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnApplyXaml.ToolTipText = "Loads the Workflow designer with the current Xaml code below";
            this.btnApplyXaml.Click += new System.EventHandler(this.btnApplyXaml_Click);
            // 
            // btnAutoSynch
            // 
            this.btnAutoSynch.Checked = true;
            this.btnAutoSynch.CheckOnClick = true;
            this.btnAutoSynch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnAutoSynch.Image = global::WFPadWorkflowDesignerControl.Properties.Resources.autosynch;
            this.btnAutoSynch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAutoSynch.Name = "btnAutoSynch";
            this.btnAutoSynch.Size = new System.Drawing.Size(124, 17);
            this.btnAutoSynch.Text = "AutoSynch Designer";
            this.btnAutoSynch.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAutoSynch.ToolTipText = "If this is active, any changes in the designer will automatically update the Xaml" +
                " code below";
            this.btnAutoSynch.CheckedChanged += new System.EventHandler(this.btnAutoSynch_CheckedChanged);
            // 
            // btnGetXaml
            // 
            this.btnGetXaml.Enabled = false;
            this.btnGetXaml.Image = global::WFPadWorkflowDesignerControl.Properties.Resources.downArrow;
            this.btnGetXaml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetXaml.Name = "btnGetXaml";
            this.btnGetXaml.Size = new System.Drawing.Size(69, 17);
            this.btnGetXaml.Text = "Get Xaml";
            this.btnGetXaml.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGetXaml.ToolTipText = "Retrieves the Xaml code for the workflow currently in the designer";
            this.btnGetXaml.Click += new System.EventHandler(this.btnGetXaml_Click);
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
            this.propertyGridSplitter.Size = new System.Drawing.Size(219, 399);
            this.propertyGridSplitter.SplitterDistance = 168;
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
            this.propertyGrid.Size = new System.Drawing.Size(217, 225);
            this.propertyGrid.TabIndex = 1;
            this.propertyGrid.ToolbarVisible = false;
            // 
            // WFPadWorkflowDesignerControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlDesigner);
            this.Name = "WFPadWorkflowDesignerControl";
            this.Size = new System.Drawing.Size(699, 399);
            this.pnlDesigner.ResumeLayout(false);
            this.workflowViewSplitter.Panel1.ResumeLayout(false);
            this.workflowViewSplitter.Panel2.ResumeLayout(false);
            this.workflowViewSplitter.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.propertyGridSplitter.Panel2.ResumeLayout(false);
            this.propertyGridSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDesigner;
        private System.Windows.Forms.SplitContainer workflowViewSplitter;
        private System.Windows.Forms.SplitContainer propertyGridSplitter;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox xomlView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnApplyXaml;
        private System.Windows.Forms.ToolStripButton btnAutoSynch;
        private System.Windows.Forms.ToolStripButton btnGetXaml;
    }
}

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

namespace DesignerHostingApplication
{
    partial class DesignerShell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignerShell));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.workflowDesignerControl = new WorkflowDesignerControl.WorkflowDesignerControl();
            this.zoomDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.mni25PercentZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mni100PercentZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mni200PercentZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomDropDown,
            this.toolStripSeparator1,
            this.btnDelete});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(592, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // workflowDesignerControl
            // 
            this.workflowDesignerControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workflowDesignerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workflowDesignerControl.Location = new System.Drawing.Point(0, 25);
            this.workflowDesignerControl.Name = "workflowDesignerControl";
            this.workflowDesignerControl.Size = new System.Drawing.Size(592, 441);
            this.workflowDesignerControl.TabIndex = 1;
            this.workflowDesignerControl.Xoml = resources.GetString("workflowDesignerControl.Xoml");
            this.workflowDesignerControl.XomlFile = "";
            // 
            // zoomDropDown
            // 
            this.zoomDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.zoomDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mni25PercentZoom,
            this.mni100PercentZoom,
            this.mni200PercentZoom});
            this.zoomDropDown.Image = ((System.Drawing.Image)(resources.GetObject("zoomDropDown.Image")));
            this.zoomDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomDropDown.Name = "zoomDropDown";
            this.zoomDropDown.Size = new System.Drawing.Size(46, 22);
            this.zoomDropDown.Text = "Zoom";
            // 
            // mni25PercentZoom
            // 
            this.mni25PercentZoom.Name = "mni25PercentZoom";
            this.mni25PercentZoom.Size = new System.Drawing.Size(152, 22);
            this.mni25PercentZoom.Tag = "25";
            this.mni25PercentZoom.Text = "25%";
            this.mni25PercentZoom.Click += new System.EventHandler(this.zoomDropDownMenuItem_Click);
            // 
            // mni100PercentZoom
            // 
            this.mni100PercentZoom.Name = "mni100PercentZoom";
            this.mni100PercentZoom.Size = new System.Drawing.Size(152, 22);
            this.mni100PercentZoom.Tag = "100";
            this.mni100PercentZoom.Text = "100%";
            this.mni100PercentZoom.Click += new System.EventHandler(this.zoomDropDownMenuItem_Click);
            // 
            // mni200PercentZoom
            // 
            this.mni200PercentZoom.Name = "mni200PercentZoom";
            this.mni200PercentZoom.Size = new System.Drawing.Size(152, 22);
            this.mni200PercentZoom.Tag = "200";
            this.mni200PercentZoom.Text = "200%";
            this.mni200PercentZoom.Click += new System.EventHandler(this.zoomDropDownMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 22);
            this.btnDelete.Text = "Remove Activity";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // DesignerShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 466);
            this.Controls.Add(this.workflowDesignerControl);
            this.Controls.Add(this.toolStrip);
            this.Name = "DesignerShell";
            this.Text = "DesignerShell";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private WorkflowDesignerControl.WorkflowDesignerControl workflowDesignerControl;
        private System.Windows.Forms.ToolStripDropDownButton zoomDropDown;
        private System.Windows.Forms.ToolStripMenuItem mni25PercentZoom;
        private System.Windows.Forms.ToolStripMenuItem mni100PercentZoom;
        private System.Windows.Forms.ToolStripMenuItem mni200PercentZoom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDelete;
    }
}


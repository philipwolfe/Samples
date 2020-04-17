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
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
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
            // DesignerShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 466);
            this.Controls.Add(this.workflowDesignerControl);
            this.Controls.Add(this.toolStrip);
            this.Name = "DesignerShell";
            this.Text = "DesignerShell";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private WorkflowDesignerControl.WorkflowDesignerControl workflowDesignerControl;
    }
}


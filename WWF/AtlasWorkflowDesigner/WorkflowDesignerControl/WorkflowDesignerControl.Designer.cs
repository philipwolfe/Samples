//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Beta 2 Hands on Labs
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
            this.SuspendLayout();
            // 
            // pnlDesigner
            // 
            this.pnlDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesigner.Location = new System.Drawing.Point(0, 0);
            this.pnlDesigner.Name = "pnlDesigner";
            this.pnlDesigner.Size = new System.Drawing.Size(699, 399);
            this.pnlDesigner.TabIndex = 1;
            this.pnlDesigner.TabStop = true;
            // 
            // WorkflowDesignerControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlDesigner);
            this.Name = "WorkflowDesignerControl";
            this.Size = new System.Drawing.Size(699, 399);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDesigner;
    }
}

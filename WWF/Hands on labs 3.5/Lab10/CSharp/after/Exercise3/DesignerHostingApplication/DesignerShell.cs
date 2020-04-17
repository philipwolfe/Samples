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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesignerHostingApplication
{
    public partial class DesignerShell : Form
    {
        public DesignerShell()
        {
            InitializeComponent();
        }

        private void zoomDropDownMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

                int zoomFactor = 0;

                bool result = Int32.TryParse(menuItem.Tag.ToString(), out zoomFactor);

                if (result)
                {
                    this.workflowDesignerControl.ProcessZoom(zoomFactor);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl.DeleteSelected();
        }

    }
}
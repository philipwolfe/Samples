//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
    public partial class DynamicContextMenuStripForm : Form
    {
        public DynamicContextMenuStripForm()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            // switch off source control to determine which items to include
            if (contextMenuStrip1.SourceControl is LinkLabel)
            {

                // show
                showLinkTargetToolStripMenuItem.Visible = true;

                // hide
                insertDefaultTextToolStripMenuItem.Visible = false;

            }
            else if (contextMenuStrip1.SourceControl is TextBox)
            {

                // show
                insertDefaultTextToolStripMenuItem.Visible = true;

                // hide
                showLinkTargetToolStripMenuItem.Visible = false;
            }
        }


 
        private void insertDefaultTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Default Text";
        }

        private void customizeToolStripItemContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // determine the toolstrip item visibilities dynamically
            customizeToolStripItemContextMenuStrip.Items.Clear();

            foreach (ToolStripItem tsi in toolStrip1.Items)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(tsi.Text, tsi.Image);
                toolStripMenuItem.Checked = tsi.Visible;
                toolStripDropDownButton1.DropDownItems.Add(toolStripMenuItem);
            }
        }

        private void customizeToolStripItemContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // show hide with check
            ToolStripMenuItem toolStripMenuItem = e.ClickedItem as ToolStripMenuItem;
            toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Text == toolStripMenuItem.Text)
                {
                    toolStrip1.Items[i].Visible = toolStripMenuItem.Checked;
                    break;
                }
            }
        }

        private void showLinkTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(linkLabel1.Tag.ToString());
        }

        private void customizeToolStripItemContextMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Process.Start(new ProcessStartInfo(linkLabel1.Tag.ToString()));
            }
        }

    }
}
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

#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
    public partial class RendererSwitcherForm : Form
    {
        public RendererSwitcherForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)(sender)).Checked == true)
            {
                ToolStripManager.VisualStylesEnabled = true;
            }
            else
            {
                ToolStripManager.VisualStylesEnabled = false;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {            
            if (((RadioButton)(sender)).Checked == true)
            {
                switch (((RadioButton)(sender)).Text)
                {
                    case "&Professional":
                        // could use ToolStripManager.RenderMode, but that would impact the whole thread
                        SetRenderer(this, ToolStripRenderMode.Professional);
                        break;

                    case "&System":
                        // could use ToolStripManager.RenderMode, but that would impact the whole thread
                        SetRenderer(this, ToolStripRenderMode.System);
                        break;

                    default:
                        break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressStatusStripPanel.Value = (this.progressStatusStripPanel.Value == 100) ? 0 : this.progressStatusStripPanel.Value + 10;
        }

        private void SetRenderer(Control ctl, ToolStripRenderMode renderMode)
        {
            foreach (Control control in ctl.Controls)
            {
                // does this control support RenderMode?
                PropertyDescriptor prop = TypeDescriptor.GetProperties(control)["RenderMode"];
                if (prop != null)
                {
                    // Set RenderMode to renderMode
                    prop.SetValue(control, renderMode);
                }

                if (ctl.Controls.Count > 0)
                {
                    // recurse for controls with non-empty collections
                    SetRenderer(control, renderMode);
                }
            }
        }
    }
}
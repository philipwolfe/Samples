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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.PortalStyleFlowLayout
{
    /// <summary>
    /// Summary description for PortalElement.
    /// </summary>
    public class PortalElement : System.Windows.Forms.UserControl
    {
        private Panel panel1;
        private Button buttonClearText;
        private Button buttonAddText;
        private Label labelTestText;
        private Button buttonDeleteElement;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public PortalElement()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitComponent call
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTestText = new System.Windows.Forms.Label();
            this.buttonAddText = new System.Windows.Forms.Button();
            this.buttonClearText = new System.Windows.Forms.Button();
            this.buttonDeleteElement = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonDeleteElement);
            this.panel1.Controls.Add(this.buttonClearText);
            this.panel1.Controls.Add(this.buttonAddText);
            this.panel1.Controls.Add(this.labelTestText);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.MaximumSize = new System.Drawing.Size(177, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(177, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 169);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.ElementPaint);
            // 
            // labelTestText
            // 
            this.labelTestText.AutoSize = true;
            this.labelTestText.Location = new System.Drawing.Point(13, 130);
            this.labelTestText.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.labelTestText.MaximumSize = new System.Drawing.Size(148, 0);
            this.labelTestText.Name = "labelTestText";
            this.labelTestText.Size = new System.Drawing.Size(145, 27);
            this.labelTestText.TabIndex = 0;
            this.labelTestText.Text = "Click \'Add Text\' to add more text ...";
            // 
            // buttonAddText
            // 
            this.buttonAddText.Location = new System.Drawing.Point(13, 15);
            this.buttonAddText.Name = "buttonAddText";
            this.buttonAddText.Size = new System.Drawing.Size(143, 23);
            this.buttonAddText.TabIndex = 1;
            this.buttonAddText.Text = "Add Text";
            this.buttonAddText.Click += new System.EventHandler(this.buttonAddText_Click);
            // 
            // buttonClearText
            // 
            this.buttonClearText.Location = new System.Drawing.Point(13, 44);
            this.buttonClearText.Name = "buttonClearText";
            this.buttonClearText.Size = new System.Drawing.Size(143, 23);
            this.buttonClearText.TabIndex = 2;
            this.buttonClearText.Text = "Clear Text";
            this.buttonClearText.Click += new System.EventHandler(this.buttonClearText_Click);
            // 
            // buttonDeleteElement
            // 
            this.buttonDeleteElement.Location = new System.Drawing.Point(13, 73);
            this.buttonDeleteElement.Name = "buttonDeleteElement";
            this.buttonDeleteElement.Size = new System.Drawing.Size(143, 23);
            this.buttonDeleteElement.TabIndex = 3;
            this.buttonDeleteElement.Text = "Delete This Element";
            this.buttonDeleteElement.Click += new System.EventHandler(this.buttonDeleteElement_Click);
            // 
            // PortalElement
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panel1);
            this.Name = "PortalElement";
            this.Size = new System.Drawing.Size(183, 175);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private void buttonAddText_Click(object sender, EventArgs e)
        {
            labelTestText.Text += "... and more text ...";
        }

        private void buttonClearText_Click(object sender, EventArgs e)
        {
            labelTestText.Text = "Click 'Add Text' to add more text ...";
        }

        private void ElementPaint(object sender, PaintEventArgs e)
        {
            // Paint a pretty background on each element
            Graphics g = e.Graphics;
            LinearGradientBrush lb = new LinearGradientBrush(this.DisplayRectangle, Color.LightBlue, Color.White, 45);
            g.FillRectangle(lb , this.DisplayRectangle);
        }

        private void buttonDeleteElement_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}

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

namespace Microsoft.Samples.Windows.Forms.EventBasedAsync
{
    partial class SampleCodeForm : Form {
        public SampleCodeForm() {
            InitializeComponent();
        }
        public void ShowOrBringToFront() {
            if (this.Visible == true) {
                this.BringToFront();
            } else {
                this.Show();
            }
        }

        public string SampleCodeRtf {
            get {
                return richTextBox1.Rtf;
            }
            set {
                richTextBox1.Rtf = value;
            }
        }

        public string SampleCodeText {
            get {
                return richTextBox1.Text;
            }
            set {
                richTextBox1.Text = value;
            }
        }

        private void SaveToolStripMenuItem_Click(System.Object sender, System.EventArgs e) {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

    }
}



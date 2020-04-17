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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.SimpleFlowLayout
{
	/// <summary>
	/// Summary description for form.
	/// </summary>
	public partial class SimpleFlowLayout : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public SimpleFlowLayout()
		{
            Application.EnableVisualStyles();
            InitializeComponent();
		}

        // Simple method demonstrating adjusting the Form (and the anchored FlowLayoutPanel within it)
        // to various integral heights of the contents of the panel.
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            switch (((RadioButton)sender).Name)
            {
                case "radioHorizontal":
                    this.Size = new Size(475, 176);
                    break;
                case "radioVertical":
                    this.Size = new Size(244, 317);
                    break;
            }
        }
	}
}


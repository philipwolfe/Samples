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
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.PortalStyleFlowLayout
{
    partial class MainPortal : Form
    {
        public MainPortal()
        {
            InitializeComponent();
        }

        private void buttonAddPortalElement_Click(object sender, EventArgs e)
        {
            // add a new PortalElement usercontrol to the FlowLayoutPanel
            PortalElement newelement = new PortalElement();
            flowLayoutPanel1.Controls.Add(newelement);
        }
    }
}

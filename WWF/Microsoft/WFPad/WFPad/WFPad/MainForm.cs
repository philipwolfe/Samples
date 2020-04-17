//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation SDK Code Samples.
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.IO;
using System.Workflow.ComponentModel.Serialization;
using System.Xml;
using System.Collections.Generic;
using System.Collections;

namespace Microsoft.Samples.Workflow.WFPad
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mnuNewSequential_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.LoadNewSequentialWorkflow();
        }

        private void mnuNewStateMachine_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.LoadNewStateMachineWorkflow();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.LoadExistingWorkflow();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.Save();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zoom25_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.FitToPage();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.ProcessZoom(this.trackBar1.Value);
        }
    }
}
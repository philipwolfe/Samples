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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WFPadWorkflowDesignerControl
{
    public partial class ChooseWorkflow : Form
    {
        private List<Type> types;
        private Type selectedType;

        public Type SelectedType
        {
            get { return selectedType; }
            set { selectedType = value; }
        }

        public List<Type> Types
        {
            get { return types; }
            set 
            { 
                types = value;
                this.cbTypes.Items.Clear();
                this.cbTypes.Items.AddRange(types.ToArray());
                this.cbTypes.SelectedIndex = 0;
            }
        }

        public ChooseWorkflow()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.selectedType = this.cbTypes.SelectedItem as Type;
            this.Close();
        }
    }
}
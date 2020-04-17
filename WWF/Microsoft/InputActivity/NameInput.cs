//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation Sample Code.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace InputActivity
{
	public partial class NameInput: Form
	{
        EmployeeActivity activity;
 
		public NameInput()
		{
			InitializeComponent();
		}

        public NameInput(EmployeeActivity empAct) : this()
        {
            this.activity = empAct;
            txtFirstName.Text = this.activity.FirstName;
            txtLastName.Text = this.activity.LastName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PropertyDescriptor firstPropDescr = TypeDescriptor.GetProperties(this.activity)["FirstName"];
            firstPropDescr.SetValue(this.activity, txtFirstName.Text);
            PropertyDescriptor lastPropDescr = TypeDescriptor.GetProperties(this.activity)["LastName"];
            lastPropDescr.SetValue(this.activity, txtLastName.Text);

            this.Close();
        }
	}
}
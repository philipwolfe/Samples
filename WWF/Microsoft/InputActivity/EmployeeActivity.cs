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
using System.ComponentModel.Design;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;

namespace InputActivity
{
    [Designer(typeof(EmployeeDesigner), typeof(IDesigner))]
    public partial class EmployeeActivity : System.Workflow.ComponentModel.Activity
	{
		public EmployeeActivity()
		{
			InitializeComponent();
		}

        public static DependencyProperty FirstNameProperty = DependencyProperty.Register("FirstName", typeof(string), typeof(EmployeeActivity), new PropertyMetadata(""));

        [Description("Employee's first name.")]
        [Category("Activity")]
        public string FirstName
        {
            get
            {
                return GetValue(FirstNameProperty) as string;
            }
            set
            {
                SetValue(FirstNameProperty, value);
            }
        }

        public static DependencyProperty LastNameProperty = DependencyProperty.Register("LastName", typeof(string), typeof(EmployeeActivity), new PropertyMetadata(""));

        [Description("Employee's last name.")]
        [Category("Activity")]
        public string LastName
        {
            get
            {
                return GetValue(LastNameProperty) as string;
            }
            set
            {
                SetValue(LastNameProperty, value);
            }
        }
    }

    public class EmployeeDesigner : ActivityDesigner
    {
        protected override void OnMouseDoubleClick(System.Windows.Forms.MouseEventArgs e)
        {
            NameInput nameInput = new NameInput(this.Activity as EmployeeActivity);
            nameInput.Show();
        }
    }
}

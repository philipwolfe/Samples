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
using Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn;

namespace Microsoft.Samples.Windows.Forms.DataGridViewCustomColumnTest
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridViewColumns();
			this.Text = "DataGridViewCustomColumn Sample";
        }

        //  Creates and Initializes the columns for our DataGridView.
        private void InitializeDataGridViewColumns()
        {
            DataGridViewTextBoxColumn dgvtbc;
            MaskedTextBoxColumn mtbc;

            //
            // employee name.
            //
            dgvtbc = new DataGridViewTextBoxColumn();
            dgvtbc.HeaderText = "Name";
            dgvtbc.Width = 120;
            this.employeesDataGridView.Columns.Add(dgvtbc);

            //
            // Employee ID -- this will be of the format:
            // [A-Z][0-9][0-9][0-9][0-9][0-9]
            //
            // this is well sutied to using a MaskedTextBox column.
            //
            mtbc = new MaskedTextBoxColumn();
            mtbc.HeaderText = "Employee ID";
            mtbc.Mask = "L00000";
            mtbc.Width = 75;
            this.employeesDataGridView.Columns.Add(mtbc);

            //
            // [American] Social Security number, of the format:
            // ###-##-####
            // 
            mtbc = new MaskedTextBoxColumn();
            mtbc.HeaderText = "SSN";
            mtbc.Mask = "000-00-0000";
            mtbc.Width = 75;
            this.employeesDataGridView.Columns.Add(mtbc);

            //
            // Address
            //
            dgvtbc = new DataGridViewTextBoxColumn();
            dgvtbc.HeaderText = "Address";
            dgvtbc.Width = 150;
            this.employeesDataGridView.Columns.Add(dgvtbc);

            //
            // City
            //
            dgvtbc = new DataGridViewTextBoxColumn();
            dgvtbc.HeaderText = "City";
            dgvtbc.Width = 75;
            this.employeesDataGridView.Columns.Add(dgvtbc);

            //
            // State
            //
            mtbc = new MaskedTextBoxColumn();
            mtbc.HeaderText = "State";
            mtbc.Mask = "LL";
            mtbc.Width = 40;
            this.employeesDataGridView.Columns.Add(mtbc);

            //
            // Zip Code #####-#### (+4 optional)
            //
            mtbc = new MaskedTextBoxColumn();
            mtbc.HeaderText = "Zip Code";
            mtbc.Mask = "00000-0000";
            mtbc.Width = 75;
            mtbc.ValidatingType = typeof(ZipCode);
            this.employeesDataGridView.Columns.Add(mtbc);


            //
            // Department Code
            //
            dgvtbc = new DataGridViewTextBoxColumn();
            dgvtbc.HeaderText = "Department";
            dgvtbc.ValueType = typeof(int);
            dgvtbc.Width = 75;
            this.employeesDataGridView.Columns.Add(dgvtbc);
		}
    }
}

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
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.DataGridViewSample
{
    partial class CustomerOrdersForm : Form
    {
        private System.Collections.Generic.Dictionary<int, bool> checkState;

        public CustomerOrdersForm()
        {
            InitializeComponent();
        }

        public void ShowDialog(string customerID, IWin32Window parent, IBindingListView blist)
        {
            // Put the customer id in the window title.
            this.Text = "Orders for Customer ID: " + customerID;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = blist;

            // The check box column will be virtual.
            dataGridView1.VirtualMode = true;
            dataGridView1.Columns.Insert(0, new DataGridViewCheckBoxColumn());

            // Don't allow the column to be resizable.
            dataGridView1.Columns[0].Resizable = DataGridViewTriState.False;

            // Make the check box column frozen so it is always visible.
            dataGridView1.Columns[0].Frozen = true;

            // Put an extra border to make the frozen column more visible
            dataGridView1.Columns[0].DividerWidth = 1;

            // Make all columns except the first read only.
            foreach (DataGridViewColumn c in dataGridView1.Columns)
                if (c.Index != 0) c.ReadOnly = true;

            // Initialize the dictionary that contains the boolean check state.
            checkState = new Dictionary<int, bool>();

            // Show the dialog.
            this.ShowDialog(parent);
        }

        private void UpdateStatusBar()
        {
            // Calculate the number of checked values in the dictionary and update the status bar.
            int number = 0;
            foreach (bool isChecked in checkState.Values)
            {
                if (isChecked) number++;
            }

            toolStripStatusLabel1.Text = "Number of orders selected: " + number.ToString(System.Globalization.CultureInfo.CurrentUICulture);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update the status bar when the cell value changes.
            if (e.ColumnIndex == 0)
            {
                // Force the update of the value for the checkbox column.
                // Without this, the value doens't get updated until you move off from the cell.
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = (bool)dataGridView1.Rows[e.RowIndex].Cells[0].EditedFormattedValue;

            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format the RequirdDate and ShippedDate cells differently if the shipped date was passed or near the required date.            
            if (e.ColumnIndex == dataGridView1.Columns["RequiredDate"].Index ||
                e.ColumnIndex == dataGridView1.Columns["ShippedDate"].Index)
            {
                // Get the object value first to check for DBNull since DateTime is a value type.
                object shippedDateObject = dataGridView1.Rows[e.RowIndex].Cells["ShippedDate"].Value;
                object requiredDateObject = dataGridView1.Rows[e.RowIndex].Cells["RequiredDate"].Value;
                DateTime shippedDate;
                DateTime requiredDate;

                if (shippedDateObject != System.DBNull.Value && requiredDateObject != System.DBNull.Value)
                {
                    try
                    {
                        shippedDate = (DateTime)shippedDateObject;
                        requiredDate = (DateTime)requiredDateObject;
                    }
                    catch (InvalidCastException)
                    {
                        // Either the shipped date or the required date could not be
                        // cast to a DateTime. Don't perform any more formatting of the cell.
                        return;
                    }

                    // Format the cells as red if the Shipped Date was past the Required Date.
                    if (shippedDate.Date > requiredDate.Date)
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.SelectionBackColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Black;
                    }
                    // Format the cells as yellow if the Shipped Date was within 5 days of the Required Date.
                    else if (Math.Abs((shippedDate.Date - requiredDate.Date).Days) <= 5)
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                        e.CellStyle.SelectionBackColor = Color.Yellow;
                        e.CellStyle.SelectionForeColor = Color.Black;
                    }

                }
            }    
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Update the status bar when the cell value changes.
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                // Get the orderID from the OrderID column.
                int orderID = (int)dataGridView1.Rows[e.RowIndex].Cells["OrderID"].Value;
                checkState[orderID] = (bool)dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                this.UpdateStatusBar();
            }
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            // Handle the notification that the value for a cell in the virtual column
            // is needed. Get the value from the dictionary if the key exists.

            if (e.ColumnIndex == 0)
            {
                int orderID = (int)dataGridView1.Rows[e.RowIndex].Cells["OrderID"].Value;
                if (checkState.ContainsKey(orderID))
                {
                    e.Value = checkState[orderID];
                }
                else
                    e.Value = false;
            }

        }

        private void dataGridView1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            // Handle the notification that the value for a cell in the virtual column
            // needs to be pushed back to the dictionary.

            if (e.ColumnIndex == 0)
            {
                // Get the orderID from the OrderID column.
                int orderID = (int)dataGridView1.Rows[e.RowIndex].Cells["OrderID"].Value;

                // Add or update the checked value to the dictionary depending on if the 
                // key (orderID) already exists.
                if (!checkState.ContainsKey(orderID))
                {
                    checkState.Add(orderID, (bool)e.Value);
                }
                else
                    checkState[orderID] = (bool)e.Value;
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Auto size columns after the grid data binding is complete.
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // Pressing the space bar will toggle the checked state of the row.
            if (dataGridView1.CurrentCellAddress.X != 0)
            {
                if (e.KeyCode == Keys.Space)
                {
                    // Alternate the selected checked state of the current row.
                    bool checkedValue = (bool)dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[0].Value;
                    dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[0].Value = !checkedValue;
                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Paint the row number on the row header.
            // The using statement automatically disposes the brush.
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(e.RowIndex.ToString(System.Globalization.CultureInfo.CurrentUICulture), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            }
        }

        private void CustomerOrdersForm_KeyUp(object sender, KeyEventArgs e)
        {
            // Close the dialog if the user presses Escape.
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }

        private void CustomerOrdersForm_Shown(object sender, EventArgs e)
        {
            // Turn off the wait cursor.
            Application.UseWaitCursor = false;
        }

        private void processToolStripButton_Click(object sender, EventArgs e)
        {
            // Perform processing here.
            MessageBox.Show("Process orders here...");
        }
    }
}

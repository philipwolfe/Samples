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

namespace Microsoft.Samples.Windows.Forms.DataGridViewSample
{
    partial class CustomerForm : Form
    {
        private DataSet northwindDS;

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void ViewOrders(string customerID)
        {
            this.Cursor = Cursors.WaitCursor;

            // Show the CustomerOrders dialog, passing in the customer ID.
            CustomerOrdersForm co = new CustomerOrdersForm();

            // Get the related list of orders for the current customer.
            CurrencyManager cm = ((CurrencyManager)this.BindingContext[northwindDS, "Customers.CustOrders"]);
            IBindingListView list = (IBindingListView)cm.List;

            co.ShowDialog(customerID, this, list);

            this.Cursor = Cursors.Default;

        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Load the DataSet that represents the offline version of the 
            // Northwind database.
            northwindDS = new DataSet("Northwind");
            northwindDS.ReadXmlSchema(".\\NorthwindCustomerOrders.xsd");
            northwindDS.ReadXml(".\\NorthwindCustomerOrders.xml", XmlReadMode.Auto);
            northwindDS.Locale = System.Globalization.CultureInfo.CurrentUICulture;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = northwindDS;
            dataGridView1.DataMember = "Customers";
                       
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close the form to exit the application.
            this.Close();
        }

        private void viewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the customer order screen when the user presses Enter except for
            // where the Customer ID is not yet known (such as the New Row).
            string customerID = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["CustomerID"].Value as string;
            if (customerID != null)
            {
                this.ViewOrders(customerID);
            }
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Move focus to the new row and start editing.

            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Company"];
            dataGridView1.BeginEdit(false);

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // Show the customer order screen when the user presses Enter except for
            // where the Customer ID is not yet known (such as the New Row).
            if (e.KeyData == Keys.Enter)
            {
                string customerID = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["CustomerID"].Value as string;
                if (customerID != null)
                {
                    this.ViewOrders(customerID);
                }
            }

        }

		private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			// Validate that the content length will fit into the DataSet.
			if (dataGridView1.IsCurrentCellDirty)
			{
				int maxLength = northwindDS.Tables["Customers"].Columns[e.ColumnIndex].MaxLength;

				if (e.FormattedValue.ToString().Length > maxLength)
				{
					String error = "Column value cannot exceed " + maxLength.ToString(System.Globalization.CultureInfo.CurrentUICulture) + " characters.";

					// Show error icon/text since the value cannot fit.
					DataGridViewCell c = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
					c.ErrorText = error;
					e.Cancel = false;
                }
                else
                {
                    // Clear the error icon/text.
                    DataGridViewCell c = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (c.ErrorText != String.Empty)
                        c.ErrorText = String.Empty;
				}
			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// Show the customer order screen when the user clicks the link.
			if (e.ColumnIndex == 1 && e.RowIndex != -1 && !dataGridView1.Rows[e.RowIndex].IsNewRow)
			{
                string customerID = dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells["CustomerID"].Value as string;
                if (customerID != null)
                {
                    this.ViewOrders(customerID);
                }
            }

		}

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dataGridView1.Rows[e.RowIndex].ErrorText = e.Exception.ToString();
                e.Cancel = true;
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // Identify to the user that the CustomerID is auto-generated.
            e.Row.Cells["CustomerID"].Value = "<AUTO>";

        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Calculate the customer ID for offline mode. Currently this is done by handling
            // the RowValidating event, but note that this event fires each time focus leaves 
            // a row. Currently the row index has to be special cased to decide when to perform
            // calculate the customerID.            

            if ((e.RowIndex == (dataGridView1.Rows.Count - 2)) &&
                dataGridView1.Rows[e.RowIndex + 1].IsNewRow)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Only want to calculate the CustomerID if it hasn't been calculated.
                if (row.Cells["CustomerID"].Value != null)
                {
                    if (row.Cells["CustomerID"].Value == DBNull.Value ||
                        row.Cells["CustomerID"].Value.ToString() == "<AUTO>")
                    {

                        // CustomerID is calculated by taking the first 2 characters 
                        // of the Company name and appending the RowIndex. 
                        string coname = row.Cells["Company"].Value as string;
                        if (coname != null)
                        {
                            string coid = coname.ToUpper().Substring(0, Math.Min(2, coname.Length)) + e.RowIndex.ToString() ;
                            row.Cells["CustomerID"].Value = coid;
                            e.Cancel = false;
                        }
                    }
                }
            }
        }
    }
}

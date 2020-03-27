using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Office = Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace UsingTheListObject
{
    public partial class AddProductUserControl : UserControl
    {
        AdventureWorks_DataDataSet dataSet;
        AdventureWorks_DataDataSetTableAdapters.ProductTableAdapter tableAdapter;
        AdventureWorks_DataDataSet.ProductDataTable productTable;
        AdventureWorks_DataDataSet.ProductRow currentProduct = null;

        public AddProductUserControl()
        {
            InitializeComponent();

            dataSet = new AdventureWorks_DataDataSet();
            productTable = dataSet.Product;

            tableAdapter = new UsingTheListObject.AdventureWorks_DataDataSetTableAdapters.ProductTableAdapter();
            tableAdapter.Fill(productTable);
        }

        /// <summary>
        /// The Insert button should only be enabled if the item
        /// name has been found.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemNumberTextbox_TextChanged(object sender, EventArgs e)
        {
            if (itemNumberTextBox.Text.Length == 0)
            {
                lookupButton.Enabled = false;
                currentProduct = null;
                insertItemButton.Enabled = false;
            }
            else
            {
                lookupButton.Enabled = true;
            }
        }

        private void lookupButton_Click(object sender, EventArgs e)
        {
            AdventureWorks_DataDataSet.ProductRow[] row =
                (AdventureWorks_DataDataSet.ProductRow[])
                dataSet.Product.Select("ProductNumber='" + itemNumberTextBox.Text + "'");

            if (row.Length > 0)
            {
                itemNameTextbox.Text = row[0].Name;
                currentProduct = row[0];
            }
            else
            {
                itemNameTextbox.Text = "{NOT FOUND}";
                currentProduct = null;
            }

            insertItemButton.Enabled = (currentProduct != null);
        }

        private void insertItemButton_Click(object sender, EventArgs e)
        {
            Excel.ListRow row = Globals.Sheet1.orderDetailsList.ListRows.Add(Type.Missing);
            Excel.Range currentCell = row.Range.get_Item(1, 1) as Excel.Range;
            currentCell.Value2 = currentProduct.ProductNumber;

            currentCell = row.Range.get_Item(1, 2) as Excel.Range;
            currentCell.Value2 = currentProduct.Name;

            currentCell = row.Range.get_Item(1, 3) as Excel.Range;
            currentCell.Value2 = currentProduct.ListPrice;
        }
    }
}

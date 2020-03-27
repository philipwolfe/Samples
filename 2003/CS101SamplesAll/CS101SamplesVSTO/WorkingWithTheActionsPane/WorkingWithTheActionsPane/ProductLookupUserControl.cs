using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace WorkingWithTheActionsPane
{
    public partial class ProductLookupUserControl : UserControl
    {
        public ProductLookupUserControl()
        {
            InitializeComponent();

            productTableAdapter.Fill(adventureWorks_DataDataSet.Product);
        }

        private void insertProductInfoButton_Click(object sender, EventArgs e)
        {
            // Complex casting due to row being contained in list
            AdventureWorks_DataDataSet.ProductRow prod = 
                (AdventureWorks_DataDataSet.ProductRow)
                ((DataRowView)productsListBox.SelectedItem).Row;

            // It is important to check each value for null prior to
            // attempting to access it, or an exception will be thrown.
            string price = string.Format("{0:c}", prod.ListPrice);

            // As with price, confirm that weight is not null
            string weight;
            if (!prod.IsWeightNull())
            {
                weight =
                    string.Format("{0:0.##} {1}", 
                    prod.Weight, prod.WeightUnitMeasureCode);
            }
            else
            {
                weight = "Unknown";
            }

            // Format the fields using the string.Format() method.  This
            // is more efficient than using string concatenation
            string productInfo =
                string.Format("[{0}] {1} - Price: {2}, Weight: {3}",
                prod.ProductNumber, prod.Name, price, weight);

            // Obtain the Selection property in order to 
            Word.Selection currentSelection = 
                Globals.ThisDocument.Application.Selection;

            // Only add the text if the cursor is positioned as an insertion
            // point, not if text is currently selected.  This prevents loss
            // of existing text.
            if (currentSelection.Type == Word.WdSelectionType.wdSelectionIP)
            {
                currentSelection.TypeText(productInfo);
                currentSelection.TypeParagraph();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using System.Text.RegularExpressions;

using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;

using System.Windows.Forms;
 
namespace CreatingSmartTags
{
    class SampleSmartTag : SmartTag
    {
        private Action popupTextAction, insertTextAction;

        private AdventureWorks_DataDataSet data;
        private AdventureWorks_DataDataSetTableAdapters.ProductTableAdapter adapter;

        internal SampleSmartTag()
            : base("www.microsoft.com/VSTO#SampleSmartTag", "AdventureWorks Product SmartTag")
        {
            // Initialize dataset
            data = new AdventureWorks_DataDataSet();
            adapter = new CreatingSmartTags.AdventureWorks_DataDataSetTableAdapters.ProductTableAdapter();

            adapter.Fill(data.Product);

            // Create items to display in the Smart Tag menu, and
            // actions to associate when they are clicked.
            popupTextAction = new Action("Show product info");
            popupTextAction.Click += new ActionClickEventHandler(popupTextAction_Click);

            insertTextAction = new Action("Insert product info");
            insertTextAction.Click += new ActionClickEventHandler(insertTextAction_Click);

            // The two actions are added to the array of Action objects
            Actions = new Action[] { popupTextAction, insertTextAction };

            // The RegEx object encapuslates a regular expression which is a
            // standardized method of recognizing patterns within text.
            // This expression will find product numbers in the form of
            // XX-XXXX or XX-XXXX-## as based on products in AdventureWorks
            Expressions.Add(new Regex(@"\b[A-Z]{2}-[A-Z,0-9]{4}(-[0-9]{2})?\b"));

            // Specific words can be added to match in addition to the expression
            Terms.Add("TEST");
        }

        /// <summary>
        /// The event handler to be called if the "Show product info" action
        /// is clicked in the Smart Tag popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void  popupTextAction_Click(object sender, ActionEventArgs e)
        {
            string text = RetrieveProductData( e.Range.Text );
            MessageBox.Show( "Product information:\n" + text );
        }

        /// <summary>
        /// The event handler to be called if the "Insert product info" action
        /// is clicked in the Smart Tag popup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void  insertTextAction_Click(object sender, ActionEventArgs e)
        {
            string text = RetrieveProductData( e.Range.Text );
            e.Range.Text = text;
        }

        /// <summary>
        /// Retrieves the row in the Product database corresponding to the
        /// product number added.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        string RetrieveProductData( string productID )
        {
            AdventureWorks_DataDataSet.ProductRow[] row =
                (AdventureWorks_DataDataSet.ProductRow[])
                data.Product.Select("ProductNumber='" + productID + "'");

            if (row.Length > 0)
            {
                return String.Format("Product: {0} [{1:c}]", 
                        row[0].Name, row[0].ListPrice);
            }
            else
            {
                return "Product information for " + productID + " not found";
            }
        }

        /// <summary>
        /// The Recognize() method of the SmartTag base class allows you to
        /// perform custom checking for matching expressions.
        /// 
        /// Normally, this method is not required, however can be included if the
        /// code should perform matching beyond simple pattern.  This could
        /// include a call to a database, Web service, or local business object
        /// to verify that a matched pattern should indeed display a smart tag.
        /// This requires that you do your own pattern matching based on the 
        /// current text token being passed in the first argument.
        /// 
        /// Note: In order to use the interfaces defined in the declaration, 
        /// you must add the COM reference "Microsoft Smart Tags 2.0 Type Library"
        /// to the project.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="site"></param>
        /// <param name="tokenList"></param>
        protected override void Recognize(string text, Microsoft.Office.Interop.SmartTag.ISmartTagRecognizerSite site, Microsoft.Office.Interop.SmartTag.ISmartTagTokenList tokenList)
        {
            // Do nothing and allow the base class to handle the recognition
            base.Recognize(text, site, tokenList);
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;

namespace UsingBookmarksInWord
{
    public partial class EmployeeSelectorUserControl : UserControl
    {
        public EmployeeSelectorUserControl( )
        {
            InitializeComponent();

            // Fill the dataset when the control initializes
            this.vEmployeeTableAdapter.Fill(
                this.adventureWorks_DataDataSet.vEmployee);
        }

        /// <summary>
        /// Event handler when the Select button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectButton_Click(object sender, EventArgs e)
        {
            // The BindingSource object acts as a broker between the
            // DataSource and the objects binding to the data.
            // The BindingSource object has a concept of current
            // record (manipulated by the BindingNavigator in this
            // case.  When the Select button is clicked, you can
            // work with the current record (returned as a DataRowView,
            // then obtain its Row property, then cast it to the
            // specialized vEmployeeRow.
            AdventureWorks_DataDataSet.vEmployeeRow currentRow =
                ((DataRowView)vEmployeeBindingSource.Current).Row
                as AdventureWorks_DataDataSet.vEmployeeRow;

            // The main document already has a number of bookmarks defined.
            // The Text property allows you to replace the contained text.
            Globals.ThisDocument.lastNameBookmark.Text = currentRow.LastName;
            Globals.ThisDocument.firstNameBookmark.Text = currentRow.FirstName;
            Globals.ThisDocument.jobTitleBookmark.Text = currentRow.JobTitle;
            Globals.ThisDocument.emailAddressBookmark.Text = currentRow.EmailAddress;

            SetAndReplacePhoneBookmark(currentRow.Phone);
        }

        /// <summary>
        /// When a programatically-added Bookmark object is added, any
        /// change will remove the bookmark from the document.  This method
        /// retains the original bookmark.
        /// </summary>
        /// <param name="contents"></param>
        private void SetAndReplacePhoneBookmark( string contents )
        {
            // Because of the requirement to pass the parameter as
            // an object by reference, a simple string cannot be
            // passed.  The string must be assigned to an object
            // variable before being used.
            object bookmarkName = "phoneBookmark";

            // Retrieve the bookmark from the Bookmarks collection by name,
            // then retrieve the embedded Range object
            Word.Range currentRange =
                Globals.ThisDocument.Bookmarks.get_Item(ref bookmarkName).Range;

            // Replace the text of the range with the new contents
            currentRange.Text = contents;

            // Again, because the parameter must be passed as a reference
            // to an object, a simple assignment is made.
            object rangeObject = currentRange;

            // Finally, the bookmark is added back to the collection
            // since setting the text removes it initially.
            Globals.ThisDocument.Bookmarks.Add("phoneBookmark", ref rangeObject);
        }
    }
}

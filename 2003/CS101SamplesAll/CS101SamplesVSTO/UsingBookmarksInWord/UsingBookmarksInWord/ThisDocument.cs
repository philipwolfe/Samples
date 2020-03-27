using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;

namespace UsingBookmarksInWord
{
    public partial class ThisDocument
    {
        // Declare user controls at class level to prevent any issues
        // from objects going out of scope.
        EmployeeSelectorUserControl employeeControl;

        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            // Create a new instance of the employee selector
            // user control, then bind to the click event
            employeeControl = new EmployeeSelectorUserControl( );

            // Add the user control to the Document Actions pane.
            Globals.ThisDocument.ActionsPane.Controls.Add(employeeControl);

            CreatePhoneBookmark();
        }

        /// <summary>
        /// The first name, last name, job title, and email address Bookmark
        /// objects are created at design time.  The Phone Bookmark is
        /// created at runtime to demonstrate how it works.
        /// </summary>
        public void CreatePhoneBookmark()
        {
            // Create a new range from position 139-146
            Word.Range pb = Range(ref missing, ref missing);

            // The new range spans characters 139 to 146.  As
            // a placeholder, the documents uses spaces in that
            // position initially.
            pb.Start = 139;
            pb.End = 146;

            // The initial placeholder text is set
            pb.Text = "<Phone>";

            // The range object must be set to an object reference
            // due to the "ref object" parameter signature.
            object rangeObject = pb;
            Globals.ThisDocument.Bookmarks.Add("phoneBookmark", ref rangeObject);
        }

        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(ThisDocument_Shutdown);
        }

        #endregion
    }
}

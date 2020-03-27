using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;

namespace Working_with_XML_in_Word
{
    public partial class ThisDocument
    {
		// Declare a class-level variable for adding an ActionsPane control.
		// To learn how to add an ActionsPage control to a Word project see
		// http://msdn2.microsoft.com/en-us/library/kfzd656e.
		private RssNavActionsPane myRssNavActionsPane = new RssNavActionsPane();

        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
			// Add the ActionsPane control to the ActionsPane Controls collection.
			this.ActionsPane.Controls.Add(myRssNavActionsPane);
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

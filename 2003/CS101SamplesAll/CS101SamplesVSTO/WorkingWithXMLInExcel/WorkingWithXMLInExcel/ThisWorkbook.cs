using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace Working_with_XML_in_Excel
{
	public partial class ThisWorkbook
	{
		// Declare a class-level variable for adding an ActionsPane control.
		// To learn how to add an ActionsPage control to a Word project see
		// http://msdn2.microsoft.com/en-us/library/kfzd656e.
		private theaterFinderActionsPane myTheaterFinderActionsPane = new theaterFinderActionsPane();

		private void ThisWorkbook_Startup(object sender, System.EventArgs e)
		{
			// Add the ActionsPane control to the ActionsPane Controls collection.
			this.ActionsPane.Controls.Add(myTheaterFinderActionsPane);
		}

		private void ThisWorkbook_Shutdown(object sender, System.EventArgs e)
		{
		}

		#region VSTO Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(ThisWorkbook_Startup);
			this.Shutdown += new System.EventHandler(ThisWorkbook_Shutdown);
		}

		#endregion

	}
}

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace LegacyTimesheet
{
    public partial class Sheet1
    {
        EmployeeSelectorUserControl userControl;

        private void Sheet1_Startup(object sender, System.EventArgs e)
        {
            userControl = new EmployeeSelectorUserControl();

            Globals.ThisWorkbook.ActionsPane.Controls.Add(userControl);
        }

        private void Sheet1_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Shutdown += new System.EventHandler(this.Sheet1_Shutdown);
            this.Startup += new System.EventHandler(this.Sheet1_Startup);
        }

        #endregion

    }
}

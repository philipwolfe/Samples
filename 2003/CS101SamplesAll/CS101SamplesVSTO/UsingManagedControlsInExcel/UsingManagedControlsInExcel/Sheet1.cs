using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace UsingManagedControlsInExcel
{
    public partial class Sheet1
    {
        Random r = new Random();
        SimpleForm form;

        private void Sheet1_Startup(object sender, System.EventArgs e)
        {
            form = new SimpleForm();
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
            this.addRowButton.Click += new System.EventHandler(this.addRowButton_Click);
            this.doubleClickNamedRange.BeforeDoubleClick += new Microsoft.Office.Interop.Excel.DocEvents_BeforeDoubleClickEventHandler(this.doubleClickNamedRange_BeforeDoubleClick);
            this.rightClickNamedRange.BeforeRightClick += new Microsoft.Office.Interop.Excel.DocEvents_BeforeRightClickEventHandler(this.rightClickNamedRange_BeforeRightClick);
            this.helpCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.helpCalendar_DateSelected);
            this.selectNamedRange.Selected += new Microsoft.Office.Interop.Excel.DocEvents_SelectionChangeEventHandler(this.selectNamedRange_Selected);
            this.selectNamedRange.Deselected += new Microsoft.Office.Interop.Excel.DocEvents_SelectionChangeEventHandler(this.selectNamedRange_Deselected);
            this.Shutdown += new System.EventHandler(this.Sheet1_Shutdown);
            this.Startup += new System.EventHandler(this.Sheet1_Startup);

        }

        #endregion

        private void doubleClickNamedRange_BeforeDoubleClick(Microsoft.Office.Interop.Excel.Range Target, ref bool Cancel)
        {
            MessageBox.Show("You double-clicked the cell.");
            Cancel = true;
        }

        private void rightClickNamedRange_BeforeRightClick(Microsoft.Office.Interop.Excel.Range Target, ref bool Cancel)
        {
            form.Show();

            Cancel = true;
        }

        private void addRowButton_Click(object sender, EventArgs e)
        {
            Excel.ListRow row = Globals.Sheet1.dynamicListObject.ListRows.Add(missing);

            row.Range.Value2 = r.Next();
        }

        private void selectNamedRange_Selected(Microsoft.Office.Interop.Excel.Range Target)
        {
            helpCalendar.Visible = true;
        }

        private void selectNamedRange_Deselected(Microsoft.Office.Interop.Excel.Range Target)
        {
            helpCalendar.Visible = false;
        }

        private void helpCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectNamedRange.Value = helpCalendar.SelectionStart.ToShortDateString();
            selectNamedRange.Select();
        }

    }
}

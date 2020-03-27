using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelTools = Microsoft.Office.Tools.Excel;
using Office = Microsoft.Office.Core;

namespace __WorkingWithNamedRangeInExcel_cs
{
    public partial class Sheet1
    {
        ExcelTools.NamedRange c4NamedRange;
        
        private void Sheet1_Startup(object sender, System.EventArgs e)
        {
            CreateNamedRange();
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
            this.salaryNamedRange.Change += new Microsoft.Office.Interop.Excel.DocEvents_ChangeEventHandler(this.salaryNamedRange_Change);
            this.debtNamedRange.Change += new Microsoft.Office.Interop.Excel.DocEvents_ChangeEventHandler(this.debtNamedRange_Change);
            this.Shutdown += new System.EventHandler(this.Sheet1_Shutdown);
            this.Startup += new System.EventHandler(this.Sheet1_Startup);

        }

        #endregion

        /// <summary>
        /// Create a named range programmatically, then set the inner value
        /// </summary>
        private void CreateNamedRange()
        {
            // First obtain the intrinsic range for the given cell(s)
            // The second argument can be supplied for a multi-cell range
            Excel.Range c4Range = this.Range["C4", System.Type.Missing];

            // Now create the named range by providing the intrinsic range
            // and a reference name
            c4NamedRange = this.Controls.AddNamedRange(c4Range, "MyNamedRange");

            // Now set the value of the named range, this is, what will be
            // displayed in the worksheet.
            c4NamedRange.Value2 = "Runtime named range created";
        }

        private void salaryNamedRange_Change(Microsoft.Office.Interop.Excel.Range Target)
        {
            UpdateRiskLevel();
        }

        private void debtNamedRange_Change(Microsoft.Office.Interop.Excel.Range Target)
        {
            UpdateRiskLevel();
        }

        /// <summary>
        /// A shared method to handle obtaining credit risk information
        /// and displaying it.
        /// </summary>
        private void UpdateRiskLevel()
        {
            // Verify that both fields are set
            if (salaryNamedRange.Value2 != null && debtNamedRange.Value2 != null)
            {
                // Convert the values to floats
                float salary = float.Parse(salaryNamedRange.Value2.ToString());
                float debt = float.Parse(debtNamedRange.Value2.ToString());

                // Calculate the risk level and display it
                riskNamedRange.Value2 = LookupRiskLevel(salary, debt);
            }
        }

        /// <summary>
        /// A simple comparison to assign a text-based risk level based on 
        /// a given debt ratio.
        /// </summary>
        /// <param name="salary">The salary of the person being evaluated</param>
        /// <param name="debt">The total debt load for this person</param>
        /// <returns></returns>
        private string LookupRiskLevel( float salary, float debt )
        {
            float ratio = debt / salary;

            if (ratio < .25)
            {
                return "LOW";
            }
            else if (ratio < .5)
            {
                return "AVERAGE";
            }
            else if (ratio < .7)
            {
                return "HIGH";
            }
            else
            {
                return "EXTREME";
            }
        }

    }
}

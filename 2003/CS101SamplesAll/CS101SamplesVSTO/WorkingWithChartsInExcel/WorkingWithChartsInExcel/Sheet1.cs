using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace WorkingWithChartsInExcel
{
    public partial class Sheet1
    {
        Label chartTitleLabel;
        TextBox chartTitleTextBox;
        Label chartTypeLabel;
        ComboBox changeChartTypeComboBox;
        Label minimumSalesLabel;
        TextBox minimumSalesTextBox;

        private void Sheet1_Startup(object sender, System.EventArgs e)
        {
            if (this.NeedsFill("adventureWorks_DataDataSet"))
            {
                this.vSalesPersonSalesByFiscalYearsTableAdapter.Fill(
                    this.adventureWorks_DataDataSet.vSalesPersonSalesByFiscalYears);
            }

            // Create the chart title Label
            chartTitleLabel = new Label();
            chartTitleLabel.Text = "Chart Title";

            // Create the TextBox for the chart type
            chartTitleTextBox = new TextBox();
            chartTitleTextBox.Text = embeddedChart.ChartTitle.Caption;
            chartTitleTextBox.TextChanged +=
                new EventHandler(chartTitleTextBox_TextChanged);

            // Create the Label for chart type
            chartTypeLabel = new Label();
            chartTypeLabel.Text = "Chart Type";

            // Create the ComboBox for chart types
            changeChartTypeComboBox = new ComboBox();

            // The AddRange method is used to add an entire array of
            // values to the ComboBox.  The Enum.GetNames method
            // returns a string representation of all values in an
            // enumerated type (the chart types in this example).
            // This is a convenient way to populate the list without
            // duplicating values.
            changeChartTypeComboBox.Items.AddRange(
                Enum.GetNames(typeof(Excel.XlChartType)));
            changeChartTypeComboBox.Text =
                embeddedChart.ChartType.ToString();

            changeChartTypeComboBox.SelectedIndexChanged +=
                new EventHandler(changeChartTypeComboBox_SelectedIndexChanged);

            // Create the chart title Label
            minimumSalesLabel = new Label();
            minimumSalesLabel.Text = "Show sales consistently above:";

            // Create the TextBox for the chart type
            minimumSalesTextBox = new TextBox();
            minimumSalesTextBox.Text = "";
            minimumSalesTextBox.TextChanged +=
                new EventHandler(minimumSalesTextBox_TextChanged);

            // Add all controls to the Document Actions pane
            Globals.ThisWorkbook.ActionsPane.Controls.Add(chartTypeLabel);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(changeChartTypeComboBox);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(chartTitleLabel);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(chartTitleTextBox);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(minimumSalesLabel);
            Globals.ThisWorkbook.ActionsPane.Controls.Add(minimumSalesTextBox);
        }

        void minimumSalesTextBox_TextChanged(object sender, EventArgs e)
        {
            if (minimumSalesTextBox.Text != string.Empty)
            {
                string filter = string.Format(
                    "[2002] >= {0} and [2003] >= {0} and [2004] >= {0}",
                    minimumSalesTextBox.Text);

                vSalesPersonSalesByFiscalYearsBindingSource.Filter = filter;
            }
            else
            {
                vSalesPersonSalesByFiscalYearsBindingSource.Filter = "";
            }
        }

        /// <summary>
        /// Changes the chart title caption based on the contents
        /// of the chartTitleTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void chartTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            embeddedChart.ChartTitle.Caption = chartTitleTextBox.Text;
            Globals.sheetChart.ChartTitle.Caption = chartTitleTextBox.Text;
        }

        /// <summary>
        /// Changes the chart type based on the contents of the ComboBox.
        /// If the selected type starts with xlStock, the type is not
        /// changed.  Stock charts require additional information to
        /// render.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void changeChartTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = changeChartTypeComboBox.Text;
            if (selectedText.StartsWith("xlStock"))
            {
                // Stock types are special cases so will not be rendered.
            }
            else
            {
                Excel.XlChartType type = (Excel.XlChartType)
                    Enum.Parse(
                    typeof(Excel.XlChartType), 
                    changeChartTypeComboBox.Text);

                embeddedChart.ChartType = type;
                Globals.sheetChart.ChartType = type;
            }
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
            this.Startup += new System.EventHandler(Sheet1_Startup);
            this.Shutdown += new System.EventHandler(Sheet1_Shutdown);
        }

        #endregion

    }
}

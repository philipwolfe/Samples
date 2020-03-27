using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LegacyTimesheet
{
    public partial class EmployeeSelectorUserControl : UserControl
    {
        public EmployeeSelectorUserControl()
        {
            InitializeComponent();

            this.vEmployeeTableAdapter.Fill(this.adventureWorks_DataDataSet.vEmployee);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            AdventureWorks_DataDataSet.vEmployeeRow employeeRow = 
                (AdventureWorks_DataDataSet.vEmployeeRow)
                ((DataRowView)this.vEmployeeBindingSource.Current).Row;

            Globals.Sheet1.emailAddressNamedRange.Value =
                employeeRow.EmailAddress.Split('@')[0];
            Globals.Sheet1.employeeNameNamedRange.Value =
                employeeRow.LastName + ", " + employeeRow.FirstName;
            Globals.Sheet1.employeeNumberNamedRange.Value =employeeRow.EmployeeID;
            Globals.Sheet1.employeePhoneNamedRange.Value = employeeRow.Phone;
            Globals.Sheet1.employeeTitleNamedRange.Value = employeeRow.JobTitle;
            Globals.Sheet1.locationNamedRange.Value =
                employeeRow.City + ", " + employeeRow.StateProvinceName;
        }
    }
}

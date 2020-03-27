using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UsingBindingNavigator
{
	public partial class Form1 : Form
	{

		private BindingSource EmployeesBindingSource;
        private System.Windows.Forms.BindingNavigator BindingNavigatorStandard;
        private System.Windows.Forms.BindingNavigator BindingNavigatorCustom;

		public Form1()
		{
			InitializeComponent();

			// Create a BindingSource for all the BindingNavigators to use
			this.EmployeesBindingSource = new BindingSource();
            this.EmployeesBindingSource.AllowNew = false;

			// The first BindingNavigator (Toolbox) was generated at design time
			// by dragging the control from the Toolbox
			SetupTab2();
			SetupTab3();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			DataSet ds = RetrieveDataSet();

			if (ds != null)
			{
				// Associate the DataSet with the BindingSource.
				this.EmployeesBindingSource.DataMember = "Employee";
				this.EmployeesBindingSource.DataSource = ds;

				// Associate the BindingNavigators with the BindingSource
				this.EmployeesBindingNavigator.BindingSource = this.EmployeesBindingSource;
				this.BindingNavigatorStandard.BindingSource = this.EmployeesBindingSource;
				this.BindingNavigatorCustom.BindingSource = this.EmployeesBindingSource;

				// Bind the form controls
				this.employeeIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EmployeesBindingSource, "EmployeeID", true));
				this.titleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EmployeesBindingSource, "Title", true));
				this.birthDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.EmployeesBindingSource, "BirthDate", true));
				this.maritalStatusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EmployeesBindingSource, "MaritalStatus", true));
				this.genderTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EmployeesBindingSource, "Gender", true));
				this.hireDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.EmployeesBindingSource, "HireDate", true));
				this.salariedFlagCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.EmployeesBindingSource, "SalariedFlag", true));
				this.vacationHoursTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EmployeesBindingSource, "VacationHours", true));
				this.sickLeaveHoursTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.EmployeesBindingSource, "SickLeaveHours", true));
				this.currentFlagCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.EmployeesBindingSource, "CurrentFlag", true));
			}
		}

		public void SetupTab2()
		{
			// Generate the second BindingNavigator (Standard UI)
			// Constructor parameter addStandardItems = true,
			// meaning give the control the "standard" VCR type UI
			this.BindingNavigatorStandard = new BindingNavigator(true);

			// Place navigator on 2nd tab
			this.tabPageStandard.Controls.Add(this.BindingNavigatorStandard);
			this.BindingNavigatorStandard.Dock = DockStyle.Fill;

		}

		public void SetupTab3()
		{
			// Generate the third BindingNavigator (Custom UI)
			// Constructor parameter addStandardItems = false,
			// for constructing a custom UI
			this.BindingNavigatorCustom = new BindingNavigator(false);

			// Build the custom UI
			// Generate buttons
			ToolStripButton firstButton = new ToolStripButton("|<");
			ToolStripButton prevButton = new ToolStripButton("<<");
			ToolStripButton nextButton = new ToolStripButton(">>");
			ToolStripButton lastButton = new ToolStripButton(">|");
			ToolStripSeparator separator1 = new System.Windows.Forms.ToolStripSeparator();
			ToolStripTextBox positionItem = new System.Windows.Forms.ToolStripTextBox();
			ToolStripLabel countItem = new System.Windows.Forms.ToolStripLabel();
			ToolStripSeparator separator2 = new System.Windows.Forms.ToolStripSeparator();
			ToolStripButton addNewItem = new System.Windows.Forms.ToolStripButton("Add");
			ToolStripButton deleteItem = new System.Windows.Forms.ToolStripButton("Delete");

			positionItem.Text = "0";
			positionItem.ToolTipText = "Current Index";
			
			// Add buttons to the BindingNavigatorCustom, which is a toolstrip
			// The order in which the buttons are added is 
			// the order in which buttons are displayed.
			this.BindingNavigatorCustom.Items.AddRange( new ToolStripItem[]
				{firstButton, prevButton, nextButton, lastButton,
				separator1,
				positionItem, countItem,
				separator2,
				addNewItem, deleteItem});

			// Hook up controls to navigator functionality
			this.BindingNavigatorCustom.MoveFirstItem = firstButton;
			this.BindingNavigatorCustom.MoveLastItem = lastButton;
			this.BindingNavigatorCustom.MoveNextItem = nextButton;
			this.BindingNavigatorCustom.MovePreviousItem = prevButton;
			this.BindingNavigatorCustom.PositionItem = positionItem;
			this.BindingNavigatorCustom.CountItem = countItem;
			this.BindingNavigatorCustom.CountItemFormat = "of {0}";
			this.BindingNavigatorCustom.AddNewItem = addNewItem;
			this.BindingNavigatorCustom.DeleteItem = deleteItem;

			// Place navigator on 3rd tab
			this.tabPageCustom.Controls.Add(this.BindingNavigatorCustom);
			this.BindingNavigatorCustom.Dock = DockStyle.Fill;

		}

		public DataSet RetrieveDataSet()
		{
			try
			{
				// Retrieve Employee data from database into a DataSet
				// Build a connnection string to the database
				SqlConnectionStringBuilder connectStringBuilder = new SqlConnectionStringBuilder();
				connectStringBuilder.DataSource = @".\SQLEXPRESS";
				connectStringBuilder.AttachDBFilename = @"C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_Data.mdf";
				connectStringBuilder.IntegratedSecurity = true;
				connectStringBuilder.UserInstance = true;

				// Prepare a DataSet to receive the Employee data
				DataSet ds = new DataSet("Employees");

				// Open connection to the AdventureWorks database
				using (SqlConnection connection = new SqlConnection(connectStringBuilder.ConnectionString))
				{
					connection.Open();
					// Retrieve Employee data
					SqlCommand command = new SqlCommand(
						"SELECT TOP 100 * FROM [HumanResources].[Employee]", connection);

					using (SqlDataReader drEmployees = command.ExecuteReader())
					{
						ds.Load(
							drEmployees,
							LoadOption.OverwriteChanges,
							new string[] { "Employee" });
					}

					// Close the connection to the database
					connection.Close();
				}
				

				return ds;
			}
			catch (SqlException err)
			{
				MessageBox.Show(err.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

        private void employeeIDTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.HandleValidation(
                sender,
                e,
                employeeIDTextBox.Text.Trim(),
                true);             
        }

        private void HandleValidation(object sender, CancelEventArgs e, string text, bool requiresNumeric)
        {
            string error = null;
            bool numericFailed = false;
            if (requiresNumeric)
            {
                int output;
                bool isNumeric = int.TryParse(text, out output);
                numericFailed = !isNumeric;
            }
            if (text.Length == 0 || numericFailed)
            {
                error = requiresNumeric ? "Required Numeric Field" : "Required Field";
                errorProvider1.SetError((Control)sender, error);
                e.Cancel = true;
            }
            else
                errorProvider1.Clear();
        }

        private void maritalStatusTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.HandleValidation(
                sender,
                e,
                this.maritalStatusTextBox.Text.Trim(),
                false);
        }

        private void genderTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.HandleValidation(
                sender,
                e,
                this.genderTextBox.Text.Trim(),
                false);
        }

        private void titleTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.HandleValidation(
                sender,
                e,
                titleTextBox.Text.Trim(),
                false);
        }

        private void vacationHoursTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.HandleValidation(
                sender,
                e,
                this.vacationHoursTextBox.Text.Trim(),
                true);
        }

        private void sickLeaveHoursTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.HandleValidation(
                sender,
                e,
                this.sickLeaveHoursTextBox.Text.Trim(),
                true);
        }
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CreatingMasterDetails
{
    public partial class Form1 : Form
    {
        private DataSet hrDataSet;
        private BindingSource departmentBindingSource;
		private BindingSource departmentEmployeeBindingSource;
		private BindingSource employeeBindingSource;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			// The first two lines of code were added by Visual Studio 2005 during the design time
			// work on the Tab 1.
			// TODO: This line of code loads data into the 'adventureWorks_DataDataSet.Employee' table. You can move, or remove it, as needed.
            //this.employeeTableAdapter.Fill(this.adventureWorks_DataDataSet.Employee);
            // TODO: This line of code loads data into the 'adventureWorks_DataDataSet.Department' table. You can move, or remove it, as needed.
            //this.departmentTableAdapter.Fill(this.adventureWorks_DataDataSet.Department);

			// Tabs 2 and 3 use the same BindingSource for Department data.
            // Department data draws from the Department table in the DataSet.
			hrDataSet = LoadDBData();

			// Tab 1: Department data comes from the untyped DataSet filled in the LoadDBData method.
			departmentBindingSource = new BindingSource(hrDataSet, "Department");

			// Tab 2: Employee data uses the Department->Employee relation in the Department table
			departmentEmployeeBindingSource = new BindingSource(departmentBindingSource, "Department_Employee");

			// Tab 3: Employee data uses the Employee table and no data relation because the 
			// relation is handled in departmentBindingSource_PositionChanged().
			employeeBindingSource = new BindingSource(hrDataSet, "Employee");

            // Make binding resources ReadOnly. You can easily change this, but you'll need to add validation and
            //  error handling routines to avoid errors/issues.
            departmentBindingSource.AllowNew = false;
            departmentEmployeeBindingSource.AllowNew = false;
            employeeBindingSource.AllowNew = false;
            // departmentBindingSource1.AllowNew = false; // change in the designer.

			SetupTab2();
            SetupTab3();
        }

        private void SetupTab2()
        {                     
			// Create a BindingNavigator for navigating through the Department data
            BindingNavigator tab2BindingNavigator = new BindingNavigator(departmentBindingSource);
            tabControl1.TabPages[1].Controls.Add(tab2BindingNavigator);
            tab2BindingNavigator.Dock = DockStyle.Top;

            // Bind the Department form
            this.departmentIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", departmentBindingSource, "DepartmentID", true));
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", departmentBindingSource, "Name", true));
            this.groupNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", departmentBindingSource, "GroupName", true));

            // Bind the Employee DataGridView
			employeeDataGridView.DataSource = departmentEmployeeBindingSource;
        }

        private void SetupTab3()
        {           
            // Create a BindingNavigator for navigating through the Department data
            BindingNavigator tab3BindingNavigator = new BindingNavigator(departmentBindingSource);
            tabControl1.TabPages[2].Controls.Add(tab3BindingNavigator);
            tab3BindingNavigator.Dock = DockStyle.Top;

            // Bind the Department form
            this.departmentIDTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", departmentBindingSource, "DepartmentID", true));
            this.nameTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", departmentBindingSource, "Name", true));
            this.groupNameTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", departmentBindingSource, "GroupName", true));

            // Bind the Employee DataGridView
			employeeDataGridView2.DataSource = employeeBindingSource;

            // Add event handler to refresh Employee grid on the current Department
			departmentBindingSource.PositionChanged += departmentBindingSource_PositionChanged;
		}

		void departmentBindingSource_PositionChanged(object sender, EventArgs e)
		{
			refreshEmployeeGrid2();
		}

        // Refresh the Employees grid based upon the current Department
        private void refreshEmployeeGrid2()
        {
            // Filter the BindingSource based upon the current Department
            // DepartmentID is a SQL smallint, which is an Int16.
            Int16 departmentId = (Int16)((DataRowView)departmentBindingSource.Current)["DepartmentID"];
            employeeBindingSource.Filter = "DepartmentID = " + departmentId.ToString();
        }

		// Retrieve all the data required from the database at once into a dataset
		private DataSet LoadDBData()
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
				DataSet ds = new DataSet();

				// Open connection to the AdventureWorks database
				using (SqlConnection connection = new SqlConnection(connectStringBuilder.ConnectionString))
				{
					connection.Open();

					// Retrieve Employee data
                    SqlCommand empCommand = new SqlCommand(
                        "SELECT "
                        + "	Employee.EmployeeID, EmployeeContact.LastName, EmployeeContact.FirstName,"
                        + "	Employee.Title, Employee.SalariedFlag, Employee.ManagerID, Department.DepartmentID,"
                        + "	ManagerContact.LastName + ', ' + ManagerContact.FirstName AS ManagerName"
                        + " FROM [HumanResources].[Employee] AS Employee"
                        + " INNER JOIN ( SELECT EmployeeID, DepartmentID"
                        + " 	FROM HumanResources.EmployeeDepartmentHistory h1"
                        + " 	WHERE EXISTS ( SELECT NULL FROM HumanResources.EmployeeDepartmentHistory h2"
                        + " 	WHERE h1.EmployeeID = h2.EmployeeID GROUP BY h2.EmployeeID"
                        + " 	HAVING h1.ModifiedDate = MAX(h2.ModifiedDate))"
                        + " ) Department ON Department.EmployeeID = Employee.EmployeeID"
                        + " INNER JOIN [Person].[Contact] AS EmployeeContact ON (EmployeeContact.ContactID = Employee.ContactID)"
                        + " INNER JOIN [HumanResources].[Employee] AS Manager ON (Manager.EmployeeID = Employee.ManagerID)"
                        + " INNER JOIN [Person].[Contact] AS ManagerContact ON (ManagerContact.ContactID = Manager.ContactID)",
                        connection);

					using (SqlDataReader dataReaderEmployees = empCommand.ExecuteReader())
					{
						// Load the result set into the dataset.
						ds.Load(
							dataReaderEmployees,
							LoadOption.OverwriteChanges,
							new string[] { "Employee" });
					}

					// Retrieve Department data
					SqlCommand deptCommand = new SqlCommand(
						"SELECT * FROM [HumanResources].[Department]",
						connection);

					using (SqlDataReader dataReaderDepartment = deptCommand.ExecuteReader())
					{
						// Load the result set into the dataset.
						ds.Load(
							dataReaderDepartment,
							LoadOption.OverwriteChanges,
							new string[] { "Department" });
					}

					// Setup a relationship between employees and departments
					ds.Relations.Add("Department_Employee",
										ds.Tables["Department"].Columns["DepartmentID"],
										ds.Tables["Employee"].Columns["DepartmentID"]);

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
    }
}
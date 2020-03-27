using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UsingDataGridView
{
    public partial class Form1 : Form
    {
        // A DataSet of Employee records from the AdventureWorks database
        DataSet dataSetAdventureWorks;
		DataGridView dataGridView1;
        BindingSource bindingSourceEmployee;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set up a dataset for binding purposes
            dataSetAdventureWorks = LoadDBData();
			if (dataSetAdventureWorks != null)
			{
				bindingSourceEmployee = new BindingSource(dataSetAdventureWorks, "Employee");
				SetupGrid();
			}
        }

        private void SetupGrid()
        {
            // For the second grid, columns are generated manually
            dataGridView1 = new DataGridView();
            dataGridView1.Name = "dataGridView1";
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToAddRows = false;
            // Render alternating rows with a different background color
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.InactiveCaptionText;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSourceEmployee;
            // Only one selection is supported at a time
            dataGridView1.MultiSelect = false;
            // Configure the grid to use cell selection
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            // Because this grid will contain unbound columns
            // VirtualMode must be On.
            dataGridView1.VirtualMode = true;

            // There are five kinds of Column UI elements
            // 1. Text Box
            // 2. Combo Box
            // 3. Button
            // 4. Link
            // 5. Image
            // In addition, cell templates can be defined for customizing cell UI

            //
            // Column: Employee ID, text box
            //
            DataGridViewTextBoxColumn colEmployeeId = new DataGridViewTextBoxColumn();
            colEmployeeId.DataPropertyName = "EmployeeID";
            colEmployeeId.HeaderText = "Employee ID";
            colEmployeeId.Name = "EmployeeID";
            colEmployeeId.ReadOnly = true;
            // Do not display this system internal number to the user.
            colEmployeeId.Visible = false;
            dataGridView1.Columns.Add(colEmployeeId);
            
            //
            // Column: Last name, text box
            //
            DataGridViewTextBoxColumn colLastName = new DataGridViewTextBoxColumn();
			// Size the column width so it is wide enough to display the widest visible cell, including the header
			colLastName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			colLastName.DataPropertyName = "LastName";
            colLastName.HeaderText = "Surname";
            colLastName.Name = "LastName";
            colLastName.ReadOnly = false;
            dataGridView1.Columns.Add(colLastName);

            //
            // Column: First name, text box
            //
            DataGridViewTextBoxColumn colFirstName = new DataGridViewTextBoxColumn();
			// Size the column width so it is wide enough to display the widest visible cell, including the header
			colFirstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			colFirstName.DataPropertyName = "FirstName";
            colFirstName.HeaderText = "Given Name";
            colFirstName.Name = "FirstName";
            colFirstName.ReadOnly = false;
            dataGridView1.Columns.Add(colFirstName);

            //
            // Column: Hire Date, text box with custom formatting
            //
            DataGridViewTextBoxColumn colHireDate = new DataGridViewTextBoxColumn();
            // Size the column width so it is wide enough to display the widest visible cell, including the header
            colHireDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colHireDate.DataPropertyName = "HireDate";
            // Format date as Month, yyyy
            colHireDate.DefaultCellStyle.Format = "y";
            colHireDate.HeaderText = "Date of Hire";
            colHireDate.Name = "HireDate";
            colHireDate.ReadOnly = true;
            dataGridView1.Columns.Add(colHireDate);

            //
            // Column: Age, unbound calculated column
            //
            DataGridViewTextBoxColumn colAge = new DataGridViewTextBoxColumn();
			// Size the column width to display the header
			colAge.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			colAge.HeaderText = "Age";
            colAge.Name = "Age";
            // Mark column as read-only.  Data edits would occur through a BirthDate column.
            // If not read-only, then a CellValuePush event handler is required to write the 
            // entered data into the datasource.
            colAge.ReadOnly = true;
            // Unbound columns fetch data via the CellValueNeeded event
            dataGridView1.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.colAge_CellValueNeeded);
            dataGridView1.Columns.Add(colAge);

            //
            // Column: Gender, combo box
            //
            // For this column, combo box contents are specified programmatically
            DataGridViewComboBoxColumn colGender = new DataGridViewComboBoxColumn();
            // Size the column width so it is wide enough to display the header
            colGender.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colGender.DataPropertyName = "Gender";
            // Specifiy the list of choices in the combo box
            colGender.Items.AddRange(new string[] { "M", "F" });
            // Sort the combo box contents alphabetically
            colGender.Sorted = true;
            // Disable sorting for the column
            colGender.SortMode = DataGridViewColumnSortMode.NotSortable;
            colGender.HeaderText = "Gender";
            colGender.Name = "Gender";
            colGender.ReadOnly = false;
            dataGridView1.Columns.Add(colGender);

            //
            // Column: Marital status, combo box
            //
            // For this column, combo box contents are retrieved from the database
            DataGridViewComboBoxColumn colMaritalStatus = new DataGridViewComboBoxColumn();
            // Size the column width so it is wide enough to display the header
            colMaritalStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colMaritalStatus.DataPropertyName = "MaritalStatus";
            // Retrieve the list of choices from the database
            colMaritalStatus.DataSource = dataSetAdventureWorks.Tables["MaritalStatusChoices"];
            // Identify the column in the Employee table that is used to select the combo box item
            colMaritalStatus.ValueMember = "MaritalStatus";
            // If the column value is not human friendly, e.g., a foreign key identity off to a related table,
            // the DisplayMember property is used to identify the column used for display purposes
            colMaritalStatus.DisplayMember = "MaritalStatus";
            colMaritalStatus.HeaderText = "Marital Status";
            colMaritalStatus.Name = "MaritalStatus";
            colMaritalStatus.ReadOnly = false;
            dataGridView1.Columns.Add(colMaritalStatus);

            //
            // Column: SalariedFlag, check box
            //
            DataGridViewCheckBoxColumn colSalariedFlag = new DataGridViewCheckBoxColumn();
            // Size the column width so it is wide enough to display the header
            colSalariedFlag.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            // Because this is a nullable column, support 3 values for a boolean:
            // {true, false, unknown}
            colSalariedFlag.ThreeState = true;
            colSalariedFlag.TrueValue = 1;
            colSalariedFlag.FalseValue = 0;
            colSalariedFlag.IndeterminateValue = System.DBNull.Value;
            colSalariedFlag.DataPropertyName = "SalariedFlag";
            colSalariedFlag.HeaderText = "Salaried";
            colSalariedFlag.Name = "SalariedFlag";
            colSalariedFlag.ReadOnly = true;
            dataGridView1.Columns.Add(colSalariedFlag);


            //
            // Column: Direct Reports, button
            //
            // This column is not bound to a database table column.
            // Display a list of employees who report directly to this employee
            DataGridViewButtonColumn colDirectReports = new DataGridViewButtonColumn();
            colDirectReports.HeaderText = "Direct Reports";
            colDirectReports.Name = "DirectReports";
            colDirectReports.Text = "Subordinates";
			// Use the .Text value for the Button caption
			colDirectReports.UseColumnTextForButtonValue = true;
            // Make the column as wide as required by the column header
            colDirectReports.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colDirectReports.ToolTipText = "Click to display a list of employees who report directly to this person.";
            dataGridView1.Columns.Add(colDirectReports);

            // Handle the button click. 
            // Because there is no event specific to button columns or cells,
            // use the DataGridView.CellContentClick event
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(colDirectReports_CellContentClick);

            //
            // Column: Manager, link
            //
            // Links to the manager's entry, by seeking it in the dataset, and then setting the selected row
            DataGridViewLinkColumn colManager = new DataGridViewLinkColumn();
            // Size the column width so it is fills out the rest of the grid
            colManager.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // But give it a minimum size
            colManager.MinimumWidth = 100;
            colManager.DataPropertyName = "ManagerName";
            colManager.HeaderText = "Manager";
            colManager.LinkBehavior = LinkBehavior.AlwaysUnderline;
            colManager.LinkBehavior = LinkBehavior.SystemDefault;
            colManager.LinkColor = Color.Blue;
            colManager.Name = "Manager";
            colManager.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns.Add(colManager);

            // Handle the link click
            // The DataGridViewLinkColumn behaves like the DataGridViewButtonColumn
            // but with a different UI.
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(colManager_CellContentClick);

            // Freeze the grid at the FirstName column, so it and columns to its left
            // stay on screen throughout horizontal scrolling
            colFirstName.Frozen = true;

            dataGridView1.Dock = DockStyle.Fill;
			this.Controls.Add(dataGridView1);

            dataGridView1.Click += new EventHandler(dataGridView1_Click);
        }

        void dataGridView1_Click(object sender, EventArgs e)
        {
            this.HideDirectReports();
        }

        private void HideDirectReports()
        {
            if (this.listBoxDirectReports.Visible)
            {
                this.listBoxDirectReports.Visible = false;
                this.listBoxDirectReports.SendToBack();
            }
        }

        // Retrieve all the data required from the database at once into a dataset
        private DataSet LoadDBData()
        {
			try
			{
				// Retrieve Employee data from database into a DataSet
				// Build a connnection string to the database
				System.Data.SqlClient.SqlConnectionStringBuilder connectStringBuilder = new SqlConnectionStringBuilder();
				connectStringBuilder.DataSource = @".\SQLEXPRESS";
				connectStringBuilder.AttachDBFilename = @"C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_Data.mdf";
				connectStringBuilder.IntegratedSecurity = true;
				connectStringBuilder.UserInstance = true;

				DataSet ds = new DataSet();

				// Open connection to the AdventureWorks database
				using (SqlConnection connection = new SqlConnection(connectStringBuilder.ConnectionString))
				{
					connection.Open();

					// Retrieve Employee data
					SqlCommand command = new SqlCommand(
							"SELECT TOP 50"
								+ "  Employee.*"
								+ ", EmployeeContact.*"
								+ ", ManagerContact.LastName + ', ' + ManagerContact.FirstName AS ManagerName"
								+ " FROM [HumanResources].[Employee] AS Employee"
								+ " INNER JOIN [Person].[Contact] AS EmployeeContact ON (EmployeeContact.ContactID = Employee.ContactID)"
								+ " INNER JOIN [HumanResources].[Employee] AS Manager ON (Manager.EmployeeID = Employee.ManagerID)"
								+ " INNER JOIN [Person].[Contact] AS ManagerContact ON (ManagerContact.ContactID = Manager.ContactID)",
							connection);

					using (SqlDataReader dataReaderEmployees = command.ExecuteReader())
					{
						// Load the result set into the dataset.
						ds.Load(
							dataReaderEmployees,
							LoadOption.OverwriteChanges,
							new string[] { "Employee" });
					}

					// Retrieve Marital Status choices
					command.CommandText = "SELECT DISTINCT MaritalStatus FROM [HumanResources].[Employee]";
					using (SqlDataReader dataReaderMaritalChoices = command.ExecuteReader())
					{
						// Load the result set into the dataset.
						ds.Load(
							dataReaderMaritalChoices,
							LoadOption.OverwriteChanges,
							new string[] { "MaritalStatusChoices" });
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

        // Handler for clicks on the DirectReports button
        // Display a listbox at the mouse pointer location with the list of employees 
		// who report directly.
        private void colDirectReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            // Filter out clicks not in the DirectReports column
            if (e.RowIndex >= 0 && e.ColumnIndex == grid.Columns["DirectReports"].Index)
            {
                // Filter for direct reports
                DataTable Employees = dataSetAdventureWorks.Tables["Employee"];
                int employeeId = (int)((DataRowView)grid.Rows[e.RowIndex].DataBoundItem).Row["EmployeeID"];
                DataRow[] directReports = Employees.Select("ManagerID = " + employeeId.ToString(), "LastName ASC");

                listBoxDirectReports.Items.Clear();
                for (int i = directReports.GetLowerBound(0); i <= directReports.GetUpperBound(0); i++)
                {
                    string entry = "";
                    entry += directReports[i]["LastName"];
                    listBoxDirectReports.Items.Add(entry);
                }
                if (listBoxDirectReports.Items.Count == 0)
                    listBoxDirectReports.Items.Add("None");

                // Add listbox to form, on top, positioned at mouse pointer
                this.Controls.Add(listBoxDirectReports);
                listBoxDirectReports.Location = this.PointToClient(MousePosition);
                // Display listbox
                listBoxDirectReports.Visible = true;
                listBoxDirectReports.BringToFront();
                listBoxDirectReports.Focus();
            }
        }

        // When focus is lost on the direct reports list box, hide the control
        private void listBoxDirectReports_Leave(object sender, EventArgs e)
        {
            listBoxDirectReports.Visible = false;
        }

        // Handler for clicks on the Manager link
        // Seeks to the manager's row in the grid
        private void colManager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            // Filter out clicks not in the DirectReports column.
            if (e.RowIndex >= 0 && e.ColumnIndex == grid.Columns["Manager"].Index)
            {
                // Seek to the manager's entry in the grid
                // Pull the data from the DataRow behind the GridRow
                // You should not use e.RowIndex as the index into the Employees table,
                // because e.RowIndex is not invariant through sort operations
                //int managerId = (int)dataSetAdventureWorks.Tables["Employee"].DefaultView[e.RowIndex]["ManagerID"];
                int managerId = (int)((DataRowView)grid.Rows[e.RowIndex].DataBoundItem).Row["ManagerID"];
                bool boolFound = false;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    // IsNewRow indicates the grid entry row at the bottom of the grid
                    // Because EmployeeID data is contained in the grid,
                    // you can either retrieve the EmployeeID from the grid...
                    //if (!row.IsNewRow && (int) row.Cells["EmployeeID"].Value == managerId)
                    // ...or from the underlying datasource.
                    if (!row.IsNewRow && (int) ((DataRowView)row.DataBoundItem).Row["EmployeeID"] == managerId)
                    {
                        boolFound = true;
                        // The DataGridView is in cell selection mode.
                        // If row selection were used, use row.Selected = true;
                        row.Cells["LastName"].Selected = true;
                        break;
                    }
                }
                // Notify user if manager record is not present
                // This will occur in this sample sometimes because 
                // not all employee records were retrieved.
                if (!boolFound)
                    MessageBox.Show("No manager data available.");
            }
        }

        // Handle the request for data for unbound columns
        private void colAge_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex == ((DataGridView) sender).Columns["Age"].Index)
            {
                int age;
                DataTable Employees = dataSetAdventureWorks.Tables["Employee"];
                DateTime birthDate = (DateTime)Employees.DefaultView[e.RowIndex]["BirthDate"];
                age = DateTime.Today.Year - birthDate.Year;
                // Adjust down if hasn't had this year's birthday yet.
                if (DateTime.Today.DayOfYear < birthDate.DayOfYear)
                    age--;
                e.Value = age;
            }
        }

		private void listBoxDirectReports_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (((ListBox)sender).SelectedItem != null)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow && ((DataRowView)row.DataBoundItem).Row["LastName"].ToString() == ((ListBox)sender).SelectedItem.ToString())
                    {
                        row.Cells["LastName"].Selected = true;
                        listBoxDirectReports.Visible = false;
                        break;
                    }
                }
            }
            else
            {
                listBoxDirectReports.Visible = false;
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            this.HideDirectReports();
        }
    }
}
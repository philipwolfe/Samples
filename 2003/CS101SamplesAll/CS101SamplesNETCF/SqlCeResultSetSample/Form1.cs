using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlServerCe;
using System.IO;

namespace SQLCeResultSetSample
{
	public partial class Form1 : Form
	{

		private SqlCeConnection conn;
		private SqlCeCommand cmd;
		private SqlCeResultSet rs;
		private int id = 0;  // simple way to auto increment id (primary key) for record

		public Form1()
		{
			InitializeComponent();

			CreateDatabase();
		}
		~Form1()
		{ 
			// The SqlCeResultSet requires the connection to be open to perform 
			// various functions so close only when the form goes away
			conn.Close();
		}

		private void CreateDatabase()
		{
			try
			{
				// Delete the SQL Mobile 2005 Database file
				File.Delete("\\My Documents\\Personal\\Contacts.sdf");

				// Create a new database
				SqlCeEngine engine = new SqlCeEngine("Data Source = \\My Documents\\Personal\\Contacts.sdf");
				engine.CreateDatabase();

				// Create and open connection.  The SqlCeResultSet requires the 
				// connection to be open to perform various functions

				conn = new SqlCeConnection("Data Source = \\My Documents\\Personal\\Contacts.sdf");
				conn.Open();

				// Create Command
				cmd = conn.CreateCommand();
				cmd.CommandText = "CREATE TABLE Contact (ID INT, First NVARCHAR(20), Last NVARCHAR(30), Phone NVARCHAR(20), EntryDate DATETIME)";
				cmd.ExecuteNonQuery();

				// Create ResultSet
				cmd.CommandText = "SELECT * FROM Contact";
				rs = cmd.ExecuteResultSet(ResultSetOptions.Updatable | ResultSetOptions.Scrollable);

				// Bind the result set to the DataGrid
				ContactDataGrid.DataSource = rs.ResultSetView;

				// Add records for demonstration purposes
				for (int i = 0; i < 10; i++)
				{
					string idxStr = i.ToString();
					AddRecord(rs, "First" + idxStr, "Last" + idxStr, "555-100" + idxStr);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Error: " + e.Message);
			}
		}

		private void AddRecord(SqlCeResultSet rs, string first, string last, string phone)
		{
			// Create a Record
			SqlCeUpdatableRecord rec = rs.CreateRecord();

			// Stuff record with data
			id++; // increment id
			rec.SetInt32(0, id);
			rec.SetString(1, first);
			rec.SetString(2, last);
			rec.SetString(3, phone);
			rec.SetDateTime(4, DateTime.Now);

			// Insert record into result set
			rs.Insert(rec);
		}

		// Populate the textboxes based on the current record in the result set
		private void DataToForm()
		{
			FirstTextBox.Text = rs.GetString(1);
			LastTextBox.Text = rs.GetString(2);
			PhoneTextBox.Text = rs.GetString(3);
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			AddRecord(rs, FirstTextBox.Text, LastTextBox.Text, PhoneTextBox.Text);
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			try
			{
				rs.Delete();
				// Make sure that the cursor in the result set is set to the current row index of the grid
				// this is necessary to keep synchronization between the result set and data grid
				rs.ReadAbsolute(ContactDataGrid.CurrentRowIndex);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			// Write pending changes in the result set to the database
			try
			{
				rs.Update();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void PrevButton_Click(object sender, EventArgs e)
		{
			if (ContactDataGrid.CurrentRowIndex > 0)
				ContactDataGrid.CurrentRowIndex--;
		}

		private void NextButton_Click(object sender, EventArgs e)
		{
			// There doesn't appear to be any efficient way to determine the index of the last row of the data
			// or the number of records in the result set, so just catch and swallow the obvious exception of stepping
			// over the end.
			try
			{
	            ContactDataGrid.CurrentRowIndex++;
			}
			catch
			{
	            rs.ReadLast(); // sync up ResultSet with DataGrid
			}
		}

		private void ContactDataGrid_CurrentCellChanged(object sender, EventArgs e)
		{
			rs.ReadAbsolute(ContactDataGrid.CurrentRowIndex);
			DataToForm();
		}
		
	}
}
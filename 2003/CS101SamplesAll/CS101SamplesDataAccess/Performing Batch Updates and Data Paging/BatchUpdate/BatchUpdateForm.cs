using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;

namespace BatchUpdate
{
	public partial class batchUpdateForm : Form
	{
     
        string myConnectionString = ConfigurationManager.AppSettings["myConnectionString"];
		private SqlDataAdapter myDataAdapter;
		private DataSet myDataSet;
		private DataTable myDataTable;
		private SqlConnection myConnection;
		private StringBuilder myStringBuilder = new StringBuilder();

		public batchUpdateForm()
		{
			
            try
            {
                InitializeComponent();

                // We want to initialize the DataAdapter, add the event handler so we 
                // provide feedback to the user, and build the insert, update, and delete command for
                // the DataAdapter.  We also want to display any information that is already stored in the database.
                string myQuery = "SELECT * FROM SampleData ORDER BY ID DESC";
                myDataAdapter = new SqlDataAdapter(myQuery, myConnectionString);
                myDataAdapter.RowUpdated += new SqlRowUpdatedEventHandler(RowUpdatedHandler);
                BuildCommands();

                myDataSet = new DataSet();
                myDataSet.CaseSensitive = true;
                myDataAdapter.Fill(myDataSet, "SampleData");

                FillDataGridView();

                FillDataSetSize();

                batchSizeComboBox.SelectedIndex = 0;
                dataSetSizeComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error in the application: " + ex.Message.ToString(), "Alert");
                insertDataButton.Enabled = false;
                batchSizeComboBox.Enabled = false;
                dataSetSizeComboBox.Enabled = false;
            }
		}
		/// <summary>
		/// This method creates all the SqlDataAdapter commands to either Insert, Update or Delete.
		/// For this example, only the insert is leveraged, but the Update and Delete could be
		/// implemented easily.
		/// </summary>
		private void BuildCommands()
		{
			// Get the connection that is used by the SqlDataAdapter
			myConnection = myDataAdapter.SelectCommand.Connection;


			// Here we set the INSERT command and parameter.
			// This is the command that is used primarily in this example
			// because only new rows are added to the existing DataSet
			myDataAdapter.InsertCommand = new SqlCommand("INSERT INTO SampleData (value1) VALUES (@value1);", myConnection);
			myDataAdapter.InsertCommand.Parameters.Add("@value1", SqlDbType.Int, 4, "value1");
			myDataAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;

			// Here we set the UPDATE command and parameters.
			// This is then called if any of the rows in the DataSet
			// have been altered and must be updated.
			myDataAdapter.UpdateCommand = new SqlCommand("UPDATE SampleData SET value1=@value WHERE value1 > 1;", myConnection);
			myDataAdapter.UpdateCommand.Parameters.Add("@value1", SqlDbType.Int, 4, "value1");
			myDataAdapter.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;


			// Here we set the DELETE command and parameter.
			// Again although this isn't used in this example, 
			// it would be called if any of the rows in the DataSet
			// were deleted.
			myDataAdapter.DeleteCommand = new SqlCommand("DELETE FROM SampleData WHERE ID=@ID;", myConnection);
			myDataAdapter.DeleteCommand.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
			myDataAdapter.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
		}


		/// <summary>
		/// This event handler is called whenever a batch has completed updating.  This allows us
		/// to provide feedback to the end-user
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void RowUpdatedHandler(Object sender, SqlRowUpdatedEventArgs args)

		{

                // Indicate how we are updating the records: Batch or Insert for this example
                myStringBuilder.Append(String.Format("<font size=2 face='Arial'>Update Type: '<b>{0}</b>'</font><br />", args.StatementType.ToString()));

                // Indicate how many rows were updated
                myStringBuilder.Append(String.Format("<font size=2 face='Arial'>Rows Updated: <b>{0}</b> </font><br />", args.RecordsAffected.ToString()));

                myStringBuilder.Append("<p />");
            
			
		}

		/// <summary>
		/// This event handler shows how you can insert data first into the dataset
		/// and then you can commit the changes into the database using the BatchUpdateSize
		/// property.  If this property is set to 0, it will update all the records in a 
		/// single batch.  If the property is set to 1, it will update each record individually.
		/// Otherwise, it will update the records in batches according to the batch size.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void insertData_Click(object sender, EventArgs e)
		{

			// Create an instance of the new StopWatch class to mark the performance
			// of changing the batch sizes.
			Stopwatch myWatch = new Stopwatch();

            // disable the button and change the text
            insertDataButton.Text = "Processing...";
            insertDataButton.Enabled = false;

            ClearControls();
			
			// Here you set the batch size of the DataAdapter and the records will
			// be update according this property.
			myDataAdapter.UpdateBatchSize = Convert.ToInt32(batchSizeComboBox.SelectedItem);

			// We start the timer here so we can record only the time required to insert into
			// the DataSet and database.
			myWatch.Start();

            int myNumberofRows = 0;
			// Create new rows for the DataSet
			try
			{
                myNumberofRows = Convert.ToInt32(dataSetSizeComboBox.SelectedItem.ToString());

				for (int i = 0; i < myNumberofRows; i++)
				{
					// For each record inserted, we have to create a new row
					DataRow newRow = myDataTable.NewRow();

					// Give it some value
                    newRow["ID"] = i;
					newRow["value1"] = i * 10;

					// Add the new row to the DataSet
					myDataSet.Tables[0].Rows.Add(newRow);
				}	
				
				// After all the new rows have been added to the DataSet, we can update the database.
				// Since we are inserting, all the rows that have been added, will be updated.
				myDataAdapter.Update(myDataSet,"SampleData");
				// We want to explicitly show that the changes have been accepted to update the database
				myDataSet.AcceptChanges();

				Application.DoEvents();

                	
				}
				// If an exception is thrown, we want to reject any changes that were made
				// and display a message
				catch (SqlException ex)
				{

					myDataSet.RejectChanges();
					MessageBox.Show(ex.Message, "Alert");
				}

				// Now we want to stop the timer and display the results
				myWatch.Stop();
				// Display the results in milliseconds
				elapsedTimeLabel.Text = myWatch.ElapsedMilliseconds.ToString() + " ms";
                // Display the rows inserted
                rowsInsertedLabel.Text = "Rows Inserted: " + myNumberofRows.ToString(); 
				// Display how the data was updated in the WebBrowser control
				finalResultWebBrowser.DocumentText = myStringBuilder.ToString();
                // Display the results in the DataGridView
                FillDataGridView();

               // enable the button and set text back
                insertDataButton.Enabled = true;
                insertDataButton.Text = "Insert Data";

		}// end method

        #region Helper Methods
		
		/// <summary>
		/// This methods retrieves the data from the dataset and 
		/// displays it in the DataGridView
		/// </summary>
		private void FillDataGridView()
		{
			myDataTable = myDataSet.Tables[0];
			sampleDataDataGridView.DataSource = myDataTable;
			
		}


        /// <summary>
        /// This method resets all the controls to their original state
        /// </summary>
		private void ClearControls()
		{
            rowsInsertedLabel.Text = "";
            elapsedTimeLabel.Text = "";
			finalResultWebBrowser.DocumentText = "";
			myStringBuilder.Remove(0, myStringBuilder.Length);
			sampleDataDataGridView.DataSource = "";
		}

        private void FillDataSetSize()
        {
            for (int i = 1; i <= 5; i++)
            {
                dataSetSizeComboBox.Items.Add(i * 1000);
            }
        }
        #endregion



    }
}
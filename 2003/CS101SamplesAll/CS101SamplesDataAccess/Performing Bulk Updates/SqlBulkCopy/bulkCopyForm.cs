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

namespace SqlBulkCopy
{
	public partial class bulkCopyForm : Form
	{
		DataSet myDataSet = new DataSet();
		public static int NOTIFICATION_TOLERANCE = 10;
		public static int PROGRESS_STEP = 10;
		private int progressCount = 0;
		private int progressIterator = 1;
		public bulkCopyForm()
		{
			InitializeComponent();
		}

		private void bulkCopyForm_Load(object sender, EventArgs e)
		{
			
			FillNumberofRows();
			copyProgressProgressBar.Step = PROGRESS_STEP;
            numberOfRowsComboBox.SelectedIndex = 0;
			
		}

		/// <summary>
		/// In this event, the first data table is filled with integers so that it
		/// can be queried and copied later using SqlBulkCopy
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fillTableButton_Click(object sender, EventArgs e)
		{
            try
            {
                fillTableButton.Enabled = false;
                fillTableButton.Text = "Filling...";
                Application.DoEvents();

                // We want to keep track of time required to insert all these values.
                Stopwatch myWatch = new Stopwatch();

                // This is where we are inserted all the values
                string connectionString = ConfigurationManager.AppSettings["myConnectionString"];
		
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    myConnection.Open();
                    myWatch.Start();
                    int myCount = Convert.ToInt32(numberOfRowsComboBox.SelectedItem);
                    for (int i = 0; i < myCount; i++)
                    {
                        string queryString = "INSERT INTO Data(value1) VALUES(" + i + ")";
                        SqlCommand myCommand = new SqlCommand(queryString, myConnection);
                        myCommand.ExecuteNonQuery();
                    }

                    // stop timing the event and display the results
                    myWatch.Stop();
                    if (Convert.ToBoolean((int)myWatch.ElapsedMilliseconds > 1000))
                    {
                        elapsedTimeLabel.Text = Convert.ToString(myWatch.ElapsedMilliseconds / 1000) + " sec";
                    }
                    else
                        elapsedTimeLabel.Text = myWatch.ElapsedMilliseconds.ToString() + " ms";

                    rowsCopiedTextLabel.Text = "Rows Inserted: ";
                    rowsCopiedLabel.Text = myCount.ToString();
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Alert");
            }
            finally
            {
                fillTableButton.Text = "Fill Data";
                fillTableButton.Enabled = true;
            }		
		}
		
		/// <summary>
		/// This method simulates copying data from the dataset into another table.
		/// This table can exist on the current server or on a remote server depending on the
		/// the location specified in the connection string.  Performance is shown in this method as well.
		/// The SqlRowsCopiedEventHandler is also added so that constant feedback can be provided to the user
		/// as copying occurs.
		/// </summary>
		private void CopyUsingSqlBulkCopy()
		{
            copyDataButton.Enabled = false;
            copyDataButton.Text = "Copying...";
            Application.DoEvents();

            rowsCopiedLabel.Text = "0";
            progressIterator = 1;
            Stopwatch myWatch = new Stopwatch();
            string connectionString = ConfigurationManager.AppSettings["myConnectionString"];
            // Create a connection to where the data is to be copied to
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                // start the timer
                myWatch.Start();

                // create a new SqlBulkCopy object
                System.Data.SqlClient.SqlBulkCopy myBulkCopy = new System.Data.SqlClient.SqlBulkCopy(myConnection);

                // Add the SqlRowsCopiedEventHandler so that progress can be shown
                myBulkCopy.SqlRowsCopied +=
                new SqlRowsCopiedEventHandler(OnSqlRowsCopied);

                // You want to indicate when you want the event to fire
                myBulkCopy.NotifyAfter = NOTIFICATION_TOLERANCE;

                // Specify the name of the table to where the data will be copied
                myBulkCopy.DestinationTableName = "Data2";

                try
                {
                    //Open the connection
                    myConnection.Open();
                    // Here is where you are executing the command to copy the contents of the dataset
                    // into the specified table
                    myBulkCopy.WriteToServer(myDataSet.Tables["MyTable"]);
                    // Close the SqlBulkCopy object
                    myBulkCopy.Close();
                    // Stop the timing so we can see how long it took to copy the data
                    myWatch.Stop();
                    // Display the time	
                    if (Convert.ToBoolean((int)myWatch.ElapsedMilliseconds > 1000))
                    {
                        elapsedTimeLabel.Text = Convert.ToString(myWatch.ElapsedMilliseconds / 1000) + " sec";
                    }
                    else
                        elapsedTimeLabel.Text = myWatch.ElapsedMilliseconds.ToString() + " ms";

                    // Display the data that was moved
                    resultsDataGridView.DataSource = myDataSet.Tables["MyTable"];
                    // Display how many rows were copied
                    rowsCopiedTextLabel.Text = "Rows Copied: ";
                    rowsCopiedLabel.Text = numberOfRowsComboBox.SelectedItem.ToString();
                    // set the progress bar to complete
                    copyProgressProgressBar.Value = 100;
                    // Close the connection
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Alert");
                }
                finally
                {
                    copyDataButton.Text = "Copy Data";
                    copyDataButton.Enabled = true;
                }
            }
		}

		/// <summary>
		/// This is the event that is handled every time the notification criteria is met. 
		/// The progress bar is updated based on the number of rows that are being copied.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
		{
			int updateTolerance = 0;
			updateTolerance = (int)((double)numberOfRowsComboBox.SelectedItem * .10);
			
			progressCount += NOTIFICATION_TOLERANCE;
            
            if (progressCount == updateTolerance)
			{
				progressCount = 0;
				copyProgressProgressBar.Value = progressIterator * PROGRESS_STEP;
				progressIterator++;
			}
		

		}

		/// <summary>
		/// The method retrieves the specified data from the database and fills the dataset that is used
		/// in the SqlBulkCopy operation. 
		/// </summary>
		private void RetrieveDataSet()
		{
            try
            {
                string connectionString = ConfigurationManager.AppSettings["myConnectionString"];
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {
                    myConnection.Open();
                    string queryString = "SELECT TOP " + numberOfRowsComboBox.SelectedItem.ToString() + " * FROM Data";
                    SqlCommand myCommand = new SqlCommand(queryString, myConnection);
                    SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCommand);
                    myDataAdapter.Fill(myDataSet, "MyTable");
                }
            }
            catch
            {
                MessageBox.Show("Please click the 'Fill Data' button first.", "Alert");
            }

		}

		#region Helper Functions

        /// <summary>
        /// This method adds the number of rows choice to the 
        /// combobox in a power of ten.
        /// </summary>
		private void FillNumberofRows()
		{
			for (int i = 2; i < 7; i++)
			{
				numberOfRowsComboBox.Items.Add(System.Math.Pow(10, i));
			}
		}

        /// <summary>
        /// This event gets the data that is stored in the database and 
        /// then copies it to another data source.  in this case, it copies it
        /// into the same database, but it could another data source.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void copyDataButton_Click(object sender, EventArgs e)
		{
			Application.DoEvents();
			myDataSet.Clear();
			ClearControls();
			RetrieveDataSet();
			CopyUsingSqlBulkCopy();
		}

        /// <summary>
        /// This reinstates the original state of all the controls.
        /// </summary>
		private void ClearControls()
		{
			copyProgressProgressBar.Value = 0;
			rowsCopiedLabel.Text = "";
			elapsedTimeLabel.Text = "";
			progressIterator = 1;
		}

        /// <summary>
        /// This event clears all the controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void numberOfRows_SelectedIndexChanged(object sender, EventArgs e)
		{
			ClearControls();

		}

		#endregion

	}

}
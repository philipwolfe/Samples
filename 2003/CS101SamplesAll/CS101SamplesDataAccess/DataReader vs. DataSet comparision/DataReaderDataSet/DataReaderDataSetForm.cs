using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;



namespace DataReaderDataSet
{
	public partial class dataReaderDataSetForm : Form
	{
		// create a dataset
		DataSet myDataSet = null;

		// create a sqlDataReader
		SqlDataReader myReader;	

		public dataReaderDataSetForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// This event checks to see if we are filing a DataSet or a DataReader object. It also
		/// determines if you are reading strings or integers.
		/// The DataReader object is fast read-only object to display data.  Conversely, the 
		/// DataSet object is slower in performance, but is bi-directional and read/write.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void runTestButton_Click(object sender, EventArgs e)
		{
            try
            {
                runTestButton.Enabled = false;
                Application.DoEvents();

                // Rows Retrieved
                int rowsRetrieved = 0;


                // Stopwatch Class
                // This is a new class in the 2.0.  This provides a simple and accurate 
                // timing mechanism.  Create a new StopWatch object and then you can 
                // start the stopwatch and the timing begins.
                Stopwatch myWatch = new Stopwatch();
                myWatch.Start();

                rowsRetrieved = Convert.ToInt32(iterations.Value.ToString());

                // This decision struture determines if you are using a DataSet to hold the data
                // or a DataReader to hold the data.  It also determines if you are accesing strings
                // integers.
                if (true == dataReaderRadioButton.Checked)
                {
                    // read the strings table
                    if (true == stringsRadioButton.Checked)
                    {
                        // get the string data
                        retrieveMethodLabel.Text = "Retrieve method: Strings";
                        myReader = integerDataTableAdapter.retrieveData("strings", rowsRetrieved);

                    }
                    else
                    {
                        // get the integer data
                        retrieveMethodLabel.Text = "Retrieve method: Integers";
                        myReader = integerDataTableAdapter.retrieveData("integer", rowsRetrieved);

                    }
                    // Since the DataReader object cannot be displayed directly in the DataGridView,
                    // you can use the new method Load of a DataTable to fill a DataTable and then 
                    // display the results in the DataGridView.  This method is still faster
                    // than filling a DataSet.
                    DataTable myTable = new DataTable();
                    myTable.Load(myReader);

                    // set the datasource
                    testDataDataGridView.DataSource = myTable;
                    // close the datareader
                    myReader.Close();
                    myReader.Dispose();

                }

                else
                {
                    // By being in the else clause of the structure, you assume that you are filling
                    // a DataSet and then binding that to the DataGridView.
                    if (true == stringsRadioButton.Checked)
                        // get the strings dataset
                        myDataSet = integerDataTableAdapter.retrieveDataSet("strings", rowsRetrieved);
                    else
                        // get the integer dataset
                        myDataSet = integerDataTableAdapter.retrieveDataSet("integers", rowsRetrieved);

                    // set the datasource
                    testDataDataGridView.DataSource = myDataSet.Tables[0];
                }

                // At this point, you stop the stopwatch and then you can retrieve
                // the time that calculated from start to finish for display or
                // other calculations.
                myWatch.Stop();
                // display the time
                elapsedTimeLabel.Text = "Elapsed Time: " + myWatch.ElapsedMilliseconds.ToString() + " ms";
                // display the rows queried
                rowsQueriedLabel.Text = "Rows Queried: " + rowsRetrieved.ToString();
            }
            catch
            {
                MessageBox.Show("There was an error running the test.  Please try again.","Alert");
            }
            finally
            {
                runTestButton.Enabled = true;
            }
		}

	}
}
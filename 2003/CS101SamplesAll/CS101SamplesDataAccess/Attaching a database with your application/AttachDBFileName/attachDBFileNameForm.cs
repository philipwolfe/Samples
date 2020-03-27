using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Reflection;
using System.Diagnostics;


namespace AttachDBFileName
{
	public partial class attachDBFileNameForm : Form
	{
		// create the clas variables
		protected string execPath;
		private string currentDB = "DB1";
		
		public attachDBFileNameForm()
		{
			InitializeComponent();
			// This is the path to the bin directory.  The databases filename uses this
			// to indicated where the databases are located.
			execPath = Path.GetDirectoryName(
				Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
			
        
		}
		
		/// <summary>
		/// This event, inserts the new rows into the specified database.
		/// It determines not only which database to insert the data into, but
		/// which insert method should be used.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void runTestButton_Click(object sender, EventArgs e)
		{
            try
            {
                runTestButton.Enabled = false;
                runTestButton.Text = "Running";
                this.CleanupForm();
                Application.DoEvents();

                const string SPROC = " Sproc";
                const string QUERY = " Query";
                if (currentDB == "DB1")
                    testDataTableAdapter.AttachDB1();

                // Stopwatch Class
                // This is a new class in the 2.0.  This provides a simple and accurate 
                // timing mechanism.  Create a new StopWatch object and then you can 
                // start the stopwatch and the timing begins.
                Stopwatch myWatch = new Stopwatch();
                myWatch.Start();

                // This decision structure determines if we are inserting values by
                // using a stored procedure or by passing a query text
                if (true == storedProcedureRadioButton.Checked)
                {
                    insertMethodLabel.Text = "Insert method:  Stored procedure";

                    for (int i = 1; i <= iterationListBox.Value; i++)
                    {
                        testDataTableAdapter.StoredProcedureQueryInsert("spInsertData", this.currentDB + SPROC + i.ToString(),
                            this.currentDB + SPROC + (i * 2).ToString(), System.DateTime.Now.ToString());
                    }
                }
                // insert if it's a plain query
                else
                {
                    insertMethodLabel.Text = "Insert method:  SQL Text";

                    for (int i = 1; i <= iterationListBox.Value; i++)
                    {

                        testDataTableAdapter.QueryInsert(
                            String.Format(
                            "INSERT INTO dbo.TestData (firstValue, secondValue, timeStamp)VALUES('{0}{1}','{0}{2}','{3}')",
                            (this.currentDB + QUERY),
                            i.ToString(),
                            (i * 2).ToString(),
                            System.DateTime.Now));
                    }
                    testDataTableAdapter.Update(perfTestDataSet);
                }

                perfTestDataSet.AcceptChanges();

                // At this point, you stop the stopwatch and then you can retrieve
                // the time that calculated from start to finish for display or
                // other calculations.
                myWatch.Stop();

                // read the time that elapsed and divide by 1000
                double timeSpent = myWatch.ElapsedMilliseconds / 1000;
                elapsedTimeLabel.Text = String.Format("Elapsed time:  {0} seconds",
                    timeSpent.ToString("#,##.##"));
                rowsAddedLabel.Text = "Rows added:  " + iterationListBox.Value.ToString();

                // This clears all the data before the dataset is filled again
                testDataTableAdapter.ClearBeforeFill = true;
                testDataTableAdapter.Fill(perfTestDataSet.TestData);
                testDataTableAdapter.Connection.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error running the test. Please try again." + ex.Message.ToString(),"Alert");
            }
            finally
            {
                runTestButton.Enabled = true;
                runTestButton.Text = "Run Test";
            }
		}
		
		/// <summary>
		/// In this event, the second database is chosen.
		/// A call to the AttachDB2 method is made here.
		/// That method makes a connection to the second database
		/// instead of the first database by using the file name.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void db2RadioButton_CheckedChanged(object sender, EventArgs e)
		{
            if (db2RadioButton.Checked)
            {
                testDataTableAdapter.Connection.Close();
                this.currentDB = "DB2";
                testDataTableAdapter.AttachDB2();
                perfTestDataSet.Clear();
            }
			
		}

		/// <summary>
		/// This event handles when the first database radio button is selected
		/// This event calls the AttachDB1 method which attaches to the first 
		/// database using the file to connect.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void db1RadioButton_CheckedChanged(object sender, EventArgs e)
		{
            if (db1RadioButton.Checked)
            {
                testDataTableAdapter.Connection.Close();
                this.currentDB = "DB1";
                testDataTableAdapter.AttachDB1();
                perfTestDataSet.Clear();
            }
		}

		private void attachDBFileNameForm_Load(object sender, EventArgs e)
		{
            execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
		}
        
        /// <summary>
        /// This method reset the form to its original format.
        /// </summary>
        private void CleanupForm()
        {
            insertMethodLabel.Text = "Insert method:";
            rowsAddedLabel.Text = "Rows added:";
            elapsedTimeLabel.Text = "Elapsed time:";

            perfTestDataSet.Clear();
        }
	}
}
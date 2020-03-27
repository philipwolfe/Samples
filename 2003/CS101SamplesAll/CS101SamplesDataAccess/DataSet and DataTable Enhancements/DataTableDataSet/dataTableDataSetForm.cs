#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;

#endregion


namespace DataTableDataSet
{
	public partial class dataTableDataSetForm : Form
	{
		// This DataSet is used throughout the sample when
		// inserting or displaying data
		DataSet myMainDataSet = new DataSet();

		public dataTableDataSetForm()
		{
			InitializeComponent();
		}
		
		/// <summary>
		/// In this event, we are going to load a million rows into a DataTable.  This is done 
		/// in a reasonable time frame because of new performance enhancements with DataSets
		/// and DataTable.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void performanceAddRowsButton_Click(object sender, EventArgs e)
		{
			int i;
			DataRow myDataRow;
			long myTime;
            clearLabels();
            performanceAddRowsButton.Text = "Processing...";
            performanceAddRowsButton.Enabled = false;
            // We are leveraging the new StopWatch class which gives us better
			// control over timing events and a simpler, more accurate way to display
			// the performance of inserting these rows
			Stopwatch myWatch = new Stopwatch();			

			Common myCommon = new Common();

			// First, we must generate the DataSet with the 
			// proper number of columns and their respective data types
			myCommon.CreateMyTable(myMainDataSet);

			// You start the StopWatch where you want to start the timing from
			myWatch.Start();

			// Here, we are loading the DataTable of the DataSet with a large number of
			// rows filled with random numbers.
			// With ADO.NET 1.1, this was possible, but the time required made it not practical

			Random myRandom = new Random() ;
			int myRandomValue = 0;
			
			for(i =	1; i< 10001; i++)
			{
				try
				{
                    myRandomValue = myRandom.Next();
                    myDataRow = myMainDataSet.Tables["MyTable"].NewRow();
                    myDataRow["ID"] = i;
                    myDataRow["IntegerValue1"] = myRandomValue;
                    myMainDataSet.Tables["MyTable"].Rows.Add(myDataRow);

				}
				catch(Exception ex)
				{
                    MessageBox.Show(ex.Message.ToString(), "Alert");
        		}
			}
                
			// Stop the stopwatch at this point, so we can calculate how much time elapsed
			// while we were adding the new rows into the DataTable.
        	myWatch.Stop();
			myTime = myWatch.ElapsedMilliseconds;
			 
				
			// Display the time required to add the rows
			elapsedTimeLabel.Text = "Elapsed time: " + myTime.ToString() + " ms";

        	// Display the number of rows that were inserted
        	rowsInsertedLabel.Text = "Rows Inserted: " + myMainDataSet.Tables["MyTable"].Rows.Count;

            performanceAddRowsButton.Text = "Add Rows";
            performanceAddRowsButton.Enabled = true;
            
		}

		/// <summary>
		/// In this event, we are just showing the rows that were inserted and 
		/// displaying how long it takes to bind this data to a datagridview.
		/// This event acts as a verification that the rows we meant to insert
		/// were actually inserted.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void performanceShowRowsButton_Click(object sender, EventArgs e)
		{

			Stopwatch myWatch = new Stopwatch();
			myWatch.Start();
            clearLabels();
            try
            {
               performanceShowRowsButton.Text = "Processing...";
               performanceShowRowsButton.Enabled = false;
                if (myMainDataSet.Tables["MyTable"].Rows.Count > 0)
                {
                    resultsDataGridView.DataSource = myMainDataSet.Tables["MyTable"];
                
                    myWatch.Stop();
                
                    elapsedTimeLabel.Text = "Elapsed time: " + myWatch.ElapsedMilliseconds + " ms";
                    rowsInsertedLabel.Text = "Rows Displayed: " + myMainDataSet.Tables["MyTable"].Rows.Count.ToString();
                }
                else
                    MessageBox.Show("Please click the 'Add Rows' button first.");

            }
            catch
            {
                MessageBox.Show("Please click the 'Add Rows' button first.", "Alert");
            }
            performanceShowRowsButton.Text = "Show Rows";
            performanceShowRowsButton.Enabled = true;
               

		}

		/// <summary>
		/// This event first creates a number of rows and inserts them into a DataTable
		/// in a DataSet.  With ADO 2.0, you can now write this data and schema directly 
		/// to an XML file. The file is stored in the bin directory of this sample.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void xmlWriteButton_Click(object sender, EventArgs e)
		{
			DataTable myTable;
			DataRow myDataRow;
			string myPath = "";
			long myTime = 0;
			int i = 0;
            clearLabels();

            xmlWriteButton.Text = "Processing...";
            xmlWriteButton.Enabled = false;

			// Again use the new StopWatch class to handle all the timing events.			
			Stopwatch myWatch = new Stopwatch();

			Common myCommon = new Common();

			// start the timing
			myWatch.Start();

			// We are putting getting the file path to the bin directory, so that we keep all 
			// the files contained in one area.
			myPath = Path.GetDirectoryName(
				Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);

			myCommon.CreateMyTable(myMainDataSet);

			// We want to add some values to the DataTable before we write them to the XML file
			Random myRandom = new Random() ;
			int myRandomValue = 0;
			for (i = 1; i < 101; i++)
			{
				try
				{
					myRandomValue = myRandom.Next();
					myDataRow = myMainDataSet.Tables["MyTable"].NewRow();
                    myDataRow["ID"] = i;
                    myDataRow["IntegerValue1"] = myRandomValue;
                    myMainDataSet.Tables["MyTable"].Rows.Add(myDataRow);

				}
				catch (Exception ex)
				{
                    MessageBox.Show(ex.Message.ToString(), "Alert");
				}
			}

			// retrieve the DataTable
			myTable = myMainDataSet.Tables["MyTable"];
			try
			{
				// Here we are writing all the data that was stored in the DataTable using
				// one statement.
				myTable.WriteXml(myPath + "\\myXML.xml");
				// We also write the XML schema so that it can be read correctly.
				myTable.WriteXmlSchema(myPath + "\\myXMLSchema.xml");
			}
			catch(Exception ex)
			{
                MessageBox.Show(ex.Message.ToString(), "Alert");
			}

			// End Timing now that the Write has completed.
			myWatch.Stop();
	
			myTime = myWatch.ElapsedMilliseconds;

			// display the amount of time it took to write the XML
			readWriteTimeLabel.Text = "Elapsed time: " + myTime.ToString() + " ms";

			// display the number of rows that were written to the XML file.
			rowsReadWrittenLabel.Text = "Rows written: " + myTable.Rows.Count;

            xmlWriteButton.Text = "Write XML";
            xmlWriteButton.Enabled = true;

		}

		/// <summary>
		/// Now that we have added data to an XML file, we can read the XML file,
		/// load the data into a DataTable, and display the results in a DataGridView
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void xmlReadButton_Click(object sender, EventArgs e)
		{
			// Use the StopWatch class to time the reading events.
			Stopwatch myWatch = new Stopwatch();
			DataTable myDataTable = new DataTable();
			string myFile = "";
            clearLabels();
            try
            {
                xmlReadButton.Text = "Processing...";
                xmlReadButton.Enabled = false;

                // start timing right before we start reading the file
                myWatch.Start();

                // have to look in the bin directory since that's where we wrote the file.
                myFile = Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);

                // make sure the file exists before we try to read it
                if (File.Exists(myFile + "\\myXML.xml"))
                {
                    // read the XML schema first to make sure we know how to generate the resulting DataTable
                    myDataTable.ReadXmlSchema(myFile + "\\myXMLSchema.xml");
                    // fill the DataTable with the actual values that exist in the XML file.
                    myDataTable.ReadXml(myFile + "\\myXML.xml");
                    // bind the resulting DataTable to the DataGridView
                    xmlResultsDataGridView.DataSource = myDataTable;
                    // display the results
                    rowsReadWrittenLabel.Text = "Rows read: " + myDataTable.Rows.Count.ToString();
                }
                else
                    rowsReadWrittenLabel.Text = "Rows read: 0";

                // stop the StopWatch
                myWatch.Stop();
                readWriteTimeLabel.Text = "Elapsed time: " + myWatch.ElapsedMilliseconds + " ms";
            }
            catch
            {
                MessageBox.Show("Please click the 'Write XML' button first", "Alert");
            }
            xmlReadButton.Text = "Read XML";
            xmlReadButton.Enabled = true;

		}

		/// <summary>
		/// This event shows a full DataTable bound to a DataGridView.  It first generates the values to be displayed 
		/// and inserts them into a DataTable.  Then, the DataTable is bound to the DataGridView displaying all of its 
		/// columns.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataViewShowDataSetButton_Click(object sender, EventArgs e)
		{
			int i;
			DataRow myDataRow;
			long myTime;
            clearLabels();

            dataViewShowDataSetButton.Text = "Processing...";
            dataViewShowDataSetButton.Enabled = false;

			// Use the new StopWatch class to track the time required to generate and display the 
			Stopwatch myWatch = new Stopwatch();
			Common myCommon = new Common();
            try
            {
                myCommon.CreateMyDataViewTable(myMainDataSet);

                // catch start time
                myWatch.Start();

                // Add a few data items just for example
                Random myRandom = new Random();
                int myRandomValue = 0;
                for (i = 1; i < 11; i++)
                {
                    try
                    {
                        myRandomValue = myRandom.Next();
                        myDataRow = myMainDataSet.Tables["MyDataViewTable"].NewRow();
                        myDataRow["ID"] = i;
                        myDataRow["IntegerValue1"] = myRandomValue;
                        myDataRow["IntegerValue2"] = myRandomValue + 1;
                        myDataRow["IntegerValue3"] = myRandomValue + 2;
                        myMainDataSet.Tables["MyDataViewTable"].Rows.Add(myDataRow);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Alert");
                    }

                }

                // Show elapsed time in milliseconds because the datatable is so small)
                myWatch.Stop();
                myTime = myWatch.ElapsedMilliseconds;

                rowsReturnedTimeLabel.Text = "Elapsed time: " + myTime.ToString() + " ms";


                //verify number of rows in the table
                rowsReturnedLabel.Text = "Rows returned: " + myMainDataSet.Tables["MyDataViewTable"].Rows.Count;
                // bind this new DataTable to the DataGridView
                dataViewDataGridView.DataSource = myMainDataSet.Tables["MyDataViewTable"];
            }
            catch
            {
                MessageBox.Show("There was an error displaying the DataSet data. Please try again.", "Alert");
            }
            dataViewShowDataSetButton.Text = "DataSet";
            dataViewShowDataSetButton.Enabled = true;

		}

		/// <summary>
		/// This event takes an existing DataTable and tailors the display columns to 
		/// show only the columns you are interested in.  This is done using only one 
		/// line of code.  The DefaultView.ToTable creates the new table that is bound
		/// to the DataGridView
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataViewShowDataView_Click(object sender, EventArgs e)
		{
            clearLabels();
            dataViewShowDataViewButton.Text = "Processing...";
            dataViewShowDataViewButton.Enabled = false;

                try
                {
                    if (myMainDataSet.Tables["MyDataViewTable"].Rows.Count > 0)
                    {
                        string[] columns = { "ID", "IntegerValue2" };

                        // Use the new StopWatch class to measure timing
                        Stopwatch myWatch = new Stopwatch();
                        myWatch.Start();

                        // This is where you create the new table by accessing the DefaultView.ToTable method and pass in the 
                        // columns you want to display.
                        DataTable myDataTable = myMainDataSet.Tables["MyDataViewTable"].DefaultView.ToTable("MySmallTable", true, columns);

                        // bind the new DataTable to the DataGridView showing only two columns
                        dataViewDataGridView.DataSource = myDataTable;
                        // stop the StopWatch
                        myWatch.Stop();

                        // Display the results
                        rowsReturnedLabel.Text = "Rows returned: " + myDataTable.Rows.Count;
                        rowsReturnedTimeLabel.Text = "Elapsed time: " + myWatch.ElapsedMilliseconds.ToString() + " ms";
                    }
                    else
                        MessageBox.Show("Please click the 'DataSet' button first", "Alert");
                }
                catch
                {
                    MessageBox.Show("Please click the 'DataSet' button first", "Alert");
                }

                dataViewShowDataViewButton.Text = "DataView";
                dataViewShowDataViewButton.Enabled = true;

             
		}

        /// <summary>
        /// This method clears all the lables and the
        /// DataGridViews of data.
        /// </summary>
        private void clearLabels()
        {
            rowsInsertedLabel.Text = "";
            elapsedTimeLabel.Text = "";
            rowsReadWrittenLabel.Text = "";
            readWriteTimeLabel.Text = "";
            rowsReturnedLabel.Text = "";
            rowsReturnedTimeLabel.Text = "";
            dataViewDataGridView.DataSource = "";
            resultsDataGridView.DataSource = "";
            xmlResultsDataGridView.DataSource = "";
        }

	}
}
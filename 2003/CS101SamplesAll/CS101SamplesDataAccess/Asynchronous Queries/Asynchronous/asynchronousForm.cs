using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Configuration;

namespace Asynchronous
{
	public partial class asynchronousForm : Form
	{

		public asynchronousForm()
		{
			InitializeComponent();
		}

		#region Polling Section

		/// <summary>
		/// This event makes a call to the RetrieveByPolling, which returns data
		/// asynchronously and polls to see if the execute has completed or not
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pollingAsynchButton_Click(object sender, EventArgs e)
		{
            pollingAsynchButton.Text = "Processing..."; 
            pollingAsynchButton.Enabled=false;
            queryStatusStatusBar.Enabled = statusLabel.Enabled = true;
 
			// Allow other events to continue operating while this executing
			Application.DoEvents();
			// Clear all the form controls before this runs
			ClearControls();
			// Get the data
			RetrieveByPolling();
            pollingAsynchButton.Text = "Polling";
            pollingAsynchButton.Enabled = true;
			
		}
		
		/// <summary>
		/// This method retrieves data from a database asynchronously.  Other tasks can continue
		/// to perform while the data is returned and when the data does return, then it will
		/// display its contents in the DataGridView
		/// </summary>
		private void RetrieveByPolling()

		{
			// Use the new StopWatch class to keep track of the performance
			// of using this technique
			Stopwatch myWatch = new Stopwatch();
			// To allow for asynchronous processing these connection strings have to
			//include "Asynchronous Processing=true"
	        string myConnectionString = ConfigurationManager.AppSettings["myAsyncConnectionString"];
	
			// Here we are going to start an asynchronous request 
			myWatch.Start();
			using (SqlConnection myConnection = new SqlConnection(myConnectionString))
			{
				try
				{
					// Create a Delay in the query to simulate a really large query so we
					// can do some polling
					string myQuery = "WAITFOR DELAY '0:0:3';" + 
										"SELECT * FROM Data1 ORDER BY ID DESC";
									

					int myCount = 0;
					SqlCommand myCommand =
					new SqlCommand(myQuery, myConnection);
					myConnection.Open();

					// We use the BeginExecuteReader which returns a IAsyncResult
					// which can be polled to see if it's complete
					IAsyncResult myResult =
					myCommand.BeginExecuteReader();
					while (!myResult.IsCompleted)
					{
						
						myCount++;
						// We are just updating the status bar to
						// show that we are in process until the result returns with 
						// finished
                        queryStatusStatusBar.Step = 1;
                        queryStatusStatusBar.Value = myCount;
						if (myCount == 100)
							myCount = 0;
					}
					
					// After the result finishes, we can end the reader
					SqlDataReader myReader = myCommand.EndExecuteReader(myResult);
					myWatch.Stop();

					// We are just finishing up here displaying all the information
					elapsedTime.Text = myWatch.ElapsedMilliseconds.ToString() + " ms";
					messageReturned.Text = "Data Returned by Polling!";
					DataTable myTable = new DataTable();
					myTable.Load(myReader);
					population1DataGridView.DataSource = myTable;
                    queryStatusStatusBar.Value = 100;

				}
				catch (SqlException ex)
				{
                    MessageBox.Show(ex.Message.ToString(), "Alert");
					
				}
				catch (InvalidOperationException ex)
				{
                    MessageBox.Show(ex.Message.ToString(), "Alert");
					
				}
				catch (Exception ex)
				{
                    MessageBox.Show(ex.Message.ToString(), "Alert");					
				}
			}
		}

		#endregion

		#region Fill Data Section

		/// <summary>
		/// In this method, we are just filling the database with some values.
		/// </summary>
		private void FillData()
		{
            try
            {
                string myConnectionString = ConfigurationManager.AppSettings["myConnectionString"];
                Random myRandomNumber = new Random();

                SqlConnection myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();

                for (int i = 0; i < 100; i++)
                {
                    int myMultiplier = 0;
                    myMultiplier = myRandomNumber.Next(1, 100);
                    string myQuery = "INSERT INTO Data1 (value1) VALUES(" + i * myMultiplier + ")";
                    SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
                    myCommand.ExecuteNonQuery();
                    myMultiplier = myRandomNumber.Next(1, 50);
                    string myQuery2 = "INSERT INTO Data2 (value1) VALUES(" + i * myMultiplier + ")";
                    SqlCommand myCommand2 = new SqlCommand(myQuery2, myConnection);
                    myCommand2.ExecuteNonQuery();

                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error filling the tables.  Please try again." + ex.Message.ToString(), "Alert");
            }
		}

        /// <summary>
        /// This event fills the two data with fictious country population data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void fillTablesButton_Click(object sender, EventArgs e)
		{
            try
            {
                this.fillTablesButton.Text = "Filling...";
                this.fillTablesButton.Enabled = false;
                Application.DoEvents();
                ClearControls();
                FillData();
                messageReturned.Text = "Population Data has been added!";
                this.fillTablesButton.Text = "Fill Tables";
                this.fillTablesButton.Enabled = true;


            }
            catch
            {
                MessageBox.Show("There was an error filling the tables.  Please try again.", "Alert");
            }
		}

		#endregion

		#region CallBack Section
		
		// Create these delegates so that you can display user messages, timing messages,
		// the dataGridView data.
		private delegate void DisplayInfoDelegate(string Text);

		private delegate void DisplayTimeInfoDelegate(string Text);

		private delegate void DisplayDataGridViewDelegate(DataTable myTable);

		// This example maintains the connection object 
		// externally, so that it's available for closing.
		private SqlConnection myCallbackConnection;

		// Create the StopWatch externally, so we can access it when the threads are done processing
		// This new class allows us to keep track of time as we perform the callbacks
		private Stopwatch myCallBackWatch = new Stopwatch();

		/// <summary>
		/// This event calls the RetrieveByCallBack method so that we
		/// can see an example of using CallBacks to retrieve data
		/// asynchronously
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void callBackAsynchButton_Click(object sender, EventArgs e)
		{
            callBackAsynchButton.Text = "Processing...";
            callBackAsynchButton.Enabled = false;
            queryStatusStatusBar.Enabled = statusLabel.Enabled = false;
			
			Application.DoEvents();
			ClearControls();
			
			RetrieveByCallBack();

            callBackAsynchButton.Text = "Callback";
            callBackAsynchButton.Enabled = true;
			
		}

		private void RetrieveByCallBack()
		{
            
				
                string myConnectionString = ConfigurationManager.AppSettings["myAsyncConnectionString"];
			
				SqlCommand myCommand = null;
				try
				{
					DisplayResults("");
					
					// We use the using statement when calling this connection to ensure that it will 
					// be closed when all the processing is done
					myCallbackConnection = new SqlConnection(myConnectionString);
					

					// We are adding in a Delay so that we can simulate a long running
					// query.
					string myQuery =
						"WAITFOR DELAY '0:0:05';" +
						"SELECT * FROM Data1 ORDER BY ID DESC";

					// Create a new command
					myCommand = new SqlCommand(myQuery, myCallbackConnection);
					
					// Open the connetion
					myCallbackConnection.Open();
					
					// Provide user interface feedback before we start the processing
					DisplayResults("Executing...");

					// We start the stop watch now
					myCallBackWatch.Start();
					
					// We create a new AsyncCallBack object passing the HandleCallback
					AsyncCallback myCallBack = new AsyncCallback(HandleCallback);
					// Now we can start the asynchronous retrieval of data
					myCommand.BeginExecuteReader(myCallBack, myCommand);
					
				}
				
				catch (Exception ex)
				{
                    DisplayResults(string.Format(ex.Message.ToString()));
					if (myCallbackConnection != null)
					{
						myCallbackConnection.Close();
					}
				
				}
			
		}
		
		/// <summary>
		/// This method displays the user message text that occurs during processing
		/// and after processing completes
		/// </summary>
		/// <param name="Text"></param>
		private void DisplayResults(string Text)
		{
			this.messageReturned.Text = Text;
			
		}

		/// <summary>
		/// This method displays the time message to the user interface
		/// after the callbacks are complete
		/// </summary>
		/// <param name="Text"></param>
		private void DisplayTimeResults(string Text)
		{
			
			this.elapsedTime.Text = Text;
		}

		/// <summary>
		/// This method binds the DataTable to the DataGridView after
		/// the processing is complete and the Callbacks are done
		/// </summary>
		/// <param name="myTable"></param>
		private void DisplayDataResults(DataTable myTable)
		{
			this.population1DataGridView.DataSource = myTable;
		}
		
		/// <summary>
		/// This method is what is called when the callbacks are complete.  This handles all the callbacks
		/// and finishes processing the results.
		/// </summary>
		/// <param name="result"></param>
		private void HandleCallback(IAsyncResult myResult)
		{
		try
		{
			// We will get the original command object here in this
			// method by accessing the AsyncState property
			// of the IAsyncResult parameter.
			SqlCommand myCommand = (SqlCommand)myResult.AsyncState;
			// We complete the retrieval of data
			SqlDataReader myReader = myCommand.EndExecuteReader(myResult);
			
			// We Stop the stopwatch so we can see how long it took to process
			myCallBackWatch.Stop();

			// We create all the messages that are to be display in the form here
			string userMessage = "Data Returned by Callback!";
			string myCallBackTime = myCallBackWatch.ElapsedMilliseconds.ToString() + " ms";
			DataTable myTable = new DataTable();
			myTable.Load(myReader);
			
			
			// Since we can't interact directly with the form, we have to create a new instance of each delegate
			// and invoke the method of each delegate so we can display user messages, time messages, and bind
			// the DataTable to the DataGridView
			DisplayInfoDelegate myUserDelegate = new DisplayInfoDelegate(DisplayResults);
	        this.Invoke(myUserDelegate, userMessage);

			DisplayTimeInfoDelegate myTimeDelegate = new DisplayTimeInfoDelegate(DisplayTimeResults);
			this.Invoke(myTimeDelegate, myCallBackTime);

			DisplayDataGridViewDelegate myDataDelegate = new DisplayDataGridViewDelegate(DisplayDataResults);
			this.Invoke(myDataDelegate, myTable);

		}
		catch (Exception ex)
		{
			// You have to handle exceptions here because there isn't any
			// additional exception handling higher up.  To display the message, you have to 
			// once again create an instance of a delegate and passed the method that you want 
			// to use to display the message.
			
			this.Invoke(new DisplayInfoDelegate(DisplayResults),
			String.Format(ex.Message));
		}
		finally
		{
			if (myCallbackConnection != null)
			{
				myCallbackConnection.Close();
			}
		}
	}

		#endregion

		#region Wait Section
	
		/// <summary>
		/// This event calls the RetrieveByWait to examine asynchronous data retrieval by using the
		/// wait commands.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void waitAsynchButton_Click(object sender, EventArgs e)
		{
            waitAsynchButton.Text = "Processing...";
            waitAsynchButton.Enabled = false;
            queryStatusStatusBar.Enabled = statusLabel.Enabled = false;
			
            ClearControls();
			Application.DoEvents();			
			RetrieveByWait();

            waitAsynchButton.Text = "Wait";
           waitAsynchButton.Enabled = true;
			
		}

		/// <summary>
		/// In this method, you can create a number of different connections to simulate connecting to a different databases, 
		/// even those on different servers.  In this example, we are only connecting to one database.
		/// </summary>
		private void RetrieveByWait()
		{
            // Create a new StopWatch object
            Stopwatch myWatch = new Stopwatch();
            Stopwatch mySecondWatch = new Stopwatch();
			// Set the connection string
			
            string myConnectionString = ConfigurationManager.AppSettings["myAsyncConnectionString"];
			
			// Create two different connection objects for the simlation
			SqlConnection myConnection1 =
				 new SqlConnection(myConnectionString);
			SqlConnection myConnection2 =
				 new SqlConnection(myConnectionString);

			// We create two different query strings simulating two different running times of queries to 
			// use for this example
			string myQuery1 = "WAITFOR DELAY '0:0:01';" +
				 "SELECT * FROM Data1 ORDER BY ID DESC";

			string myQuery2 = "WAITFOR DELAY '0:0:03';" +
				 "SELECT * FROM Data2 ORDER BY ID DESC";
			
            // Start the watch
            myWatch.Start();
            mySecondWatch.Start();
			try

			//  We are going to open a connection for each query and begin 
			//  execution. Using the IAsyncResult object returned by 
			//  each BeginExecuteReader we can add a WaitHandle for each 
			//  to the array.
			{
				myConnection1.Open();
				SqlCommand myCommand1 =
					 new SqlCommand(myQuery1, myConnection1);
				IAsyncResult myResult1 = myCommand1.BeginExecuteReader();
				WaitHandle myWaitHandle1 = myResult1.AsyncWaitHandle;

				myConnection2.Open();
				SqlCommand myCommand2 =
					 new SqlCommand(myQuery2, myConnection2);
				IAsyncResult myResult2 = myCommand2.BeginExecuteReader();
				WaitHandle myWaitHandle2 = myResult2.AsyncWaitHandle;

				// Add the wait handles to the WaitHandle Array so we can check for
				// all the Wait handles as they come in
				WaitHandle[] myWaitHandles = {myWaitHandle1, myWaitHandle2};

				int index;
				for (int countWaits = 0; countWaits <= 2; countWaits++)
				{
					//  We are going to se the WaitHandle to WaitAny.
					//  This means that it is looking for any of the WaitHandles to
					// complete.  The value that gets returned is the index of the array element 
					// of the particular WaitHandle or it's the Timeout value
					index = WaitHandle.WaitAny(myWaitHandles,5000, false);
					
					//  Depending on which process returns, we display it's values in the
					// DataGridView.  You could do additional processing here.  Since this is 
					// happening asynchronously, we do not know which one will complete processing first.
					switch (index)
					{
						case 0:
							SqlDataReader myReader1 = myCommand1.EndExecuteReader(myResult1);
							// Display information in the first DataGridView
							if (myReader1.Read())
							{
                                myWatch.Stop();
								elapsedTime.Text =
								"County 1: " +
								myWatch.ElapsedMilliseconds.ToString() + " ms";
								DataTable myTable = new DataTable();
								myTable.Load(myReader1);
								population1DataGridView.DataSource = myTable;
							}
							myReader1.Close();
							break;
						case 1:
							SqlDataReader myReader2 = myCommand2.EndExecuteReader(myResult2);
							// Display information in the second DataGridView
							if (myReader2.Read())
							{
                                mySecondWatch.Stop();
                                elapsedTime2.Text =
                                "County 2: " +
                                mySecondWatch.ElapsedMilliseconds.ToString() + " ms";
								DataTable myTable = new DataTable();
								myTable.Load(myReader2);
								population2DataGridView.DataSource = myTable;
							}
							myReader2.Close();
							break;
						case WaitHandle.WaitTimeout:
							break;
					}
				}
			}
			catch 
			{
                MessageBox.Show("There was an error returning by WaitHandles.  Please try again.", "Alert");
				
			}
			myConnection1.Close();
			myConnection2.Close();
            messageReturned.Text = "Data Returned by WaitHandles!";

		}
	#endregion

        /// <summary>
        /// This method resets all the controls on the page.
        /// </summary>
		private void ClearControls()
		{
			population1DataGridView.DataSource = "";
			population2DataGridView.DataSource = "";
            messageReturned.Text = "";
			elapsedTime.Text = "";
			elapsedTime2.Text = "";
            queryStatusStatusBar.Value = 0;

		}

        
	}
}
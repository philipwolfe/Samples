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

namespace MultipleActiveResultsSets
{
	public partial class multipleActiveResultSetsForm : Form
	{
		public multipleActiveResultSetsForm()
		{
			InitializeComponent();
            withoutMARSRadioButton.Checked = true;
		}

		/// <summary>
		/// This event calls methods depending on which radio button is selected
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void retrieveDataButton_Click(object sender, EventArgs e)
		{
            try
            {
                retrieveDataButton.Text = "Processing...";
                retrieveDataButton.Enabled = false;
                
                if (withMARSRadioButton.Checked)
                {
                    FillUserAddressesWithMARS();
                }
                else
                {
                    FillUserAddressesWithoutMARS();
                }
                
                retrieveDataButton.Enabled = true;
                retrieveDataButton.Text = "Retrieve Data";
                
            }
            catch
            {
                MessageBox.Show("There was an error retrieving the data.","Alert");
            }
		}

		/// <summary>
		/// This method fills employee and address information using Multiple Active Result Sets
		/// This is set in the connection string by setting the MultipleActiveResultSets to true
		/// by default it is set to true if ommitted.  
		/// By setting Multiple Active Results Sets, multiple data readers can be opened
		/// by using the same connection without any blocking from occurring.
		/// </summary>
		private void FillUserAddressesWithMARS()
		{
			int myEmployeeID = 0;
			SqlDataReader myAddressReader = null;
			Stopwatch myWatch = new Stopwatch();
			string myFinalString = "";
			int myConnectionCount = 0;

            try
            {
                // explicitly set the connection string to support Multiple Active Result Sets.
                string connectionString = ConfigurationManager.AppSettings["myMarsConnectionString"];
                

                // Set the query strings
                string myEmployeeQuery = "SELECT * FROM Employees ORDER BY LastName";
                string myAddressQuery = "SELECT * FROM Addresses WHERE EmployeeID = @EmployeeID";

                // Use the new StopWatch class to time the retrieval and display of data
                myWatch.Start();

                // Encapsulate the retrieval with this one connection
                using (SqlConnection myConnection = new
                SqlConnection(connectionString))
                {
                    // Open the connection and incrase the count
                    myConnection.Open();
                    myConnectionCount++;

                    // We create both SqlCommand objects using the same connection
                    SqlCommand myEmployeeCommand = new SqlCommand(myEmployeeQuery, myConnection);
                    SqlCommand myAddressCommand = new SqlCommand(myAddressQuery, myConnection);

                    // Add the parameter to the address command, this will allow us
                    // to get all the addresses for each employee id
                    myAddressCommand.Parameters.AddWithValue("@EmployeeID", SqlDbType.Int);

                    // We are going to go through all the Employee records
                    using (SqlDataReader myEmployeeReader =
                    myEmployeeCommand.ExecuteReader())
                    {
                        while (myEmployeeReader.Read())
                        {
                            // We want to display the name of the employee in the final text box
                            string myName = myEmployeeReader["FirstName"].ToString() + " " + myEmployeeReader["LastName"].ToString();
                            myFinalString = myFinalString + myName + "\n";

                            // Retrieve the EmployeeID for getting all the addresses
                            myEmployeeID =
                                (int)myEmployeeReader["EmployeeID"];
                            myAddressCommand.Parameters["@EmployeeID"].Value = myEmployeeID;

                            // get the address information
                            myAddressReader = myAddressCommand.ExecuteReader();
                            using (myAddressReader)
                            {
                                if (myAddressReader.HasRows)
                                {
                                    // retrieve all the addresses in the DataReader object
                                    while (myAddressReader.Read())
                                    {
                                        string myAddress = myAddressReader["Address"].ToString();
                                        string myCity = myAddressReader["City"].ToString();
                                        string myState = myAddressReader["State"].ToString();
                                        string myZipCode = myAddressReader["ZipCode"].ToString();
                                        string myAddressType = myAddressReader["AddressType"].ToString();
                                        myFinalString = myFinalString + myAddress + "\n" +
                                            myCity + ", " + myState + " " + myZipCode + "\n" +
                                            "Address Type: " + myAddressType + "\n\n";
                                    }
                                }
                                else
                                    myFinalString = myFinalString + "No Address \n\n";
                            }

                            // Stop the StopWatch so that we can display the time
                            myWatch.Stop();
                            // Display the time elapsed
                            elapsedTimeLabel.Text = myWatch.ElapsedMilliseconds.ToString() + " ms";
                            // Display how many connections were created
                            connectionNumberLabel.Text = myConnectionCount.ToString();
                            // set some properties for the RichTextBox
                            displayedDataRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
                            displayedDataRichTextBox.WordWrap = true;
                            // Assign the final data
                            displayedDataRichTextBox.Text = myFinalString;

                        }
                        // Close the connection
                        myConnection.Close();
                    }

                }
            }
            catch
            {
                MessageBox.Show("There was an error retrieving data using MARS", "Alert");
            }
		}			
			
		/// <summary>
		/// This method creates and displays information using the previous method
		/// in which multiple connections are required to interleave Employee data
		/// and Address data
		/// </summary>
        private void FillUserAddressesWithoutMARS()
        {

            int myEmployeeID = 0;
            SqlDataReader myAddressReader = null;
            Stopwatch myWatch = new Stopwatch();
            string myFinalString = "";
            int myConnectionCount = 0;

            try
            {
                // Create connection string with the MultipleActiveResultSet is set to false
                string connectionString = ConfigurationManager.AppSettings["myNonMarsConnectionString"];

                // set the query strings here
                string myEmployeeQuery = "SELECT * FROM Employees ORDER BY LastName";
                string myAddressQuery = "SELECT * FROM Addresses WHERE EmployeeID = @EmployeeID";

                // Using the new StopWatch class, you can start the stop watch
                // so we can time how long it takes to display Employee and Address
                // data
                myWatch.Start();

                // Use the first connection to retrieve Employee data
                using (SqlConnection myConnection = new
                SqlConnection(connectionString))
                {
                    myConnection.Open();
                    myConnectionCount++;

                    SqlCommand myEmployeeCommand = new SqlCommand(myEmployeeQuery, myConnection);

                    using (SqlDataReader myEmployeeReader =
                    myEmployeeCommand.ExecuteReader())
                    {
                        // Iterate through the Employee data 
                        while (myEmployeeReader.Read())
                        {

                            string myName = myEmployeeReader["FirstName"].ToString() + " " + myEmployeeReader["LastName"].ToString();
                            myFinalString = myFinalString + myName + "\n";

                            myEmployeeID =
                                (int)myEmployeeReader["EmployeeID"];

                            // Each time we iterate through the Employee data, we have to 
                            // open a second connection so that we can retrieve the 
                            // address data
                            using (SqlConnection mySecondConnection = new
                                SqlConnection(connectionString))
                            {
                                mySecondConnection.Open();
                                myConnectionCount++;

                                // Create an Address Command object
                                SqlCommand myAddressCommand = new SqlCommand(myAddressQuery, mySecondConnection);
                                myAddressCommand.Parameters.AddWithValue("@EmployeeID", SqlDbType.Int);

                                myAddressCommand.Parameters["@EmployeeID"].Value = myEmployeeID;

                                // Get the Address data based on the EmployeeID
                                myAddressReader = myAddressCommand.ExecuteReader();
                                using (myAddressReader)
                                {
                                    if (myAddressReader.HasRows)
                                    {
                                        while (myAddressReader.Read())
                                        {
                                            // Retrieve the address information
                                            string myAddress = myAddressReader["Address"].ToString();
                                            string myCity = myAddressReader["City"].ToString();
                                            string myState = myAddressReader["State"].ToString();
                                            string myZipCode = myAddressReader["ZipCode"].ToString();
                                            string myAddressType = myAddressReader["AddressType"].ToString();
                                            myFinalString = myFinalString + myAddress + "\n" +
                                            myCity + ", " + myState + " " + myZipCode + "\n" +
                                            "Address Type: " + myAddressType + "\n\n";
                                        }
                                    }
                                    else
                                        myFinalString = myFinalString + "No Address \n\n";
                                }
                                // Close the second connection so that we can open another the next time
                                // through the list
                                mySecondConnection.Close();
                            }

                            // Stop the StopWatch so that we can display the time
                            myWatch.Stop();
                            // Assign the time for display
                            elapsedTimeLabel.Text = myWatch.ElapsedMilliseconds.ToString() + " ms";
                            // Display the connection count
                            connectionNumberLabel.Text = myConnectionCount.ToString();
                            // Set the RichTextBox properties
                            displayedDataRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
                            displayedDataRichTextBox.WordWrap = true;
                            displayedDataRichTextBox.Text = myFinalString;

                        }
                        myConnection.Close();
                    }

                }

            }
            catch
            {
                MessageBox.Show("There was an error retrieving the data without MARS.", "Alert");
            }
            }
    
	}
}
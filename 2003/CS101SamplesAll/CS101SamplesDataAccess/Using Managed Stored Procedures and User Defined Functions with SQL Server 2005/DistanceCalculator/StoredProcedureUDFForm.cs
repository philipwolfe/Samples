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

namespace DistanceCalculator
{
	public partial class StoredProcedureUDFForm : Form
	{
		/// <summary>
		/// In the Form1 constructor, we must create the table in the tempdb database so we can execute
		/// our stored procedure and user defined function.
		/// </summary>
		public StoredProcedureUDFForm()
		{
            InitializeComponent();
            try
            {

                string myConnectionString = ConfigurationManager.AppSettings["myConnectionString"];

                string myQuery = "IF NOT EXISTS (SELECT * FROM sysobjects where name='GeoCache' and xtype='U') " +
                                " CREATE TABLE GeoCache " +
                                "(" +
                                " ID int IDENTITY(1,1)," +
                                " longitude1 float(53), " +
                                " latitude1 float (53), " +
                                " longitude2 float(53), " +
                                " latitude2 float (53), " +
                                " distance float (53), " +
                                ") ";

                SqlConnection myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
                myCommand.ExecuteNonQuery();

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("There was an error starting this application. Please start again.", "Alert");
                latitude1TextBox.Enabled = false;
                longitude1TextBox.Enabled = false;
                latitude2TextBox.Enabled = false;
                longitude2TextBox.Enabled = false;
                insertNewDataButton.Enabled = false;
                retrieveDataButton.Enabled = false;
            }
	}

		/// <summary>
		/// In this event, we are retrieving the data using another stored procedure
		/// that returns the data that is stored in the table. This stored procedure is one
		/// of two SqlProcedures in the StoredProcedures class.  
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void retrieveDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                retrieveDataButton.Text = "Processing...";
                retrieveDataButton.Enabled = false;

                // Here we are just returning the data that is stored in the table
                string myConnectionString = ConfigurationManager.AppSettings["myConnectionString"];
                string myQuery = "spGetData";
                Stopwatch myWatch = new Stopwatch();
                DataSet myDataSet = new DataSet();
                myWatch.Start();
                SqlConnection myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
                SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCommand);
                myDataAdapter.Fill(myDataSet);

                resultsDataGridView.DataSource = myDataSet.Tables[0];
                myWatch.Stop();
                myConnection.Close();

                elapsedTimeLabel.Text = "Elapsed Time: " + myWatch.ElapsedMilliseconds.ToString() + " ms";
                actionLabel.Text = "Action: Data Retrieved!";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("There was an error displaying the data. Please try again.", "Alert");
            }

            retrieveDataButton.Text = "Retrieve Data";
            retrieveDataButton.Enabled = true;
        }

		/// <summary>
		/// In this button click event, we are taking the user input to calculate the
		/// distance between the two points using a user defined function and then 
		/// we insert all those values into the table using another stored procedure that is 
		/// defined in the StoredProcedures class.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void insertNewDataButton_Click(object sender, EventArgs e)
		{
            try
            {
                insertNewDataButton.Text = "Processing...";
                insertNewDataButton.Enabled = false;

                if (!IsNumeric(longitude1TextBox.Text) || longitude1TextBox.Text == "")
                    MessageBox.Show("Please enter a valid longitude 1 value.", "Alert");
                else if (!IsNumeric(latitude1TextBox.Text) || latitude1TextBox.Text == "")
                    MessageBox.Show("Please enter a valid latitude 1 value.", "Alert");
                else if (!IsNumeric(longitude2TextBox.Text) || longitude2TextBox.Text == "")
                    MessageBox.Show("Please enter a valid longitude 2 value.", "Alert");
                else if (!IsNumeric(latitude2TextBox.Text) || latitude2TextBox.Text == "")
                    MessageBox.Show("Please enter a valid latitude 2 value.", "Alert");
                else
                {
                    // This is the new StopWatch class which allows us 
                    // to keep track of timed events simply
                    Stopwatch myWatch = new Stopwatch();

                    string myConnectionString = ConfigurationManager.AppSettings["myConnectionString"];
                    string myQuery = "";
                    DataSet myDataSet = new DataSet();
                    double longitude1 = Convert.ToDouble(longitude1TextBox.Text.ToString());
                    double latitude1 = Convert.ToDouble(latitude1TextBox.Text.ToString());
                    double longitude2 = Convert.ToDouble(longitude2TextBox.Text.ToString());
                    double latitude2 = Convert.ToDouble(latitude2TextBox.Text.ToString());
                    double distance = 0;
                    //SqlParameter []myParameter = new SqlParameter[4];

                    myWatch.Start();
                    SqlConnection myConnection = new SqlConnection(myConnectionString);
                    myConnection.Open();

                    // Here is where we use the User Defined Function to return the distance
                    // between two latitude/longitude pairs
                    myQuery = "SELECT dbo.CalculateDistance (" + longitude1 + "," + latitude1 + "," + longitude2 + "," + latitude2 + ") as myDistance";
                    SqlCommand myCommand = new SqlCommand(myQuery, myConnection);

                    SqlDataAdapter myDataAdapter = new SqlDataAdapter(myCommand);
                    myDataAdapter.Fill(myDataSet);
                    distance = (double)myDataSet.Tables[0].Rows[0]["myDistance"];

                    // After the distance is calculated, we want to insert the values into the table
                    myQuery = "spInsertData";

                    myCommand.CommandText = myQuery;
                    myCommand.Parameters.AddWithValue("@latitude1", latitude1);
                    myCommand.Parameters.AddWithValue("@longitude1",longitude1);
                    myCommand.Parameters.AddWithValue("@latitude2", latitude2);
                    myCommand.Parameters.AddWithValue("@longitude2", longitude2);
                    myCommand.Parameters.AddWithValue("@distance", distance);
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.ExecuteNonQuery();

                    myWatch.Stop();
                    myConnection.Close();

                    // We return some user interface feedback here
                    elapsedTimeLabel.Text = "Elapsed Time: " + myWatch.ElapsedMilliseconds.ToString() + " ms";
                    actionLabel.Text = "Action: Data Inserted!";
                    latitude1TextBox.Text = "";
                    longitude1TextBox.Text = "";
                    latitude2TextBox.Text = "";
                    longitude2TextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("There was an error inserting the data. Please try again.", "Alert");
            }

            insertNewDataButton.Text = "Insert New Data";
            insertNewDataButton.Enabled = true;
		}

        
        /// <summary>
        /// This method validates whether the values being entered are 
        /// numeric values or not.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(object value)
        {
            try
            {
                double i = Convert.ToDouble(value.ToString());
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }  
    }      
}
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
namespace GeoCache
{
    public partial class UserDefinedTypesForm : Form
    {
        /// <summary>
        /// Since we are using the tempdb, we need to create the database that we will use for this example
        /// Because of the User Defined Type, we need ot make sure the UDT project is built and deployed before
        /// running this form.
        /// </summary>
        public UserDefinedTypesForm()
        {
            InitializeComponent();
            try
            {
                // get the connection string
                string connectionString = ConfigurationManager.AppSettings["myConnectionString"];

                // create a table with an ID, Geocache location, city
                string myQuery = "IF NOT EXISTS (SELECT * FROM sysobjects where name='MyData' and xtype='U') " +
                        "CREATE TABLE dbo.MyData ( " +
                        "ID int IDENTITY(1,1) PRIMARY KEY, " +
                        "GC GeoCache,City varchar(255))";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            catch
            {
                MessageBox.Show("There was an error starting this application.", "Alert");
                enterNewLocationButton.Enabled = false;
                longitudeTextBox.Enabled = false;
                latitudeTextBox.Enabled = false;
                cityTextBox.Enabled = false;
            }
        }



        /// <summary>
        /// In this event, data is inserted from user input into the database.
        /// The longitude and latitude values are contained in the GeoCache 
        /// user defined type.  User defined types allow us to group common data
        /// together and stored in one type in a table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterNewLocationButton_Click(object sender, EventArgs e)
        {
            double longitude = 0;
            double latitude = 0;
            string city = "";
            string myQuery = "";
            try
            {
                enterNewLocationButton.Text = "Processing...";
                enterNewLocationButton.Enabled = false;

            if (!IsNumeric(longitudeTextBox.Text) || longitudeTextBox.Text == "")
                MessageBox.Show("Please enter a valid longitude.", "Alert");
            else if (!IsNumeric(latitudeTextBox.Text) || latitudeTextBox.Text == "")
                MessageBox.Show("Please enter a valid latitude.", "Alert");
            else if (cityTextBox.Text == "")
                MessageBox.Show("Please enter a city.", "Alert");
            else
            {
                Stopwatch myWatch = new Stopwatch();
                string myConnectionString = ConfigurationManager.AppSettings["myConnectionString"];
                longitude = Convert.ToDouble(longitudeTextBox.Text.ToString());
                latitude = Convert.ToDouble(latitudeTextBox.Text.ToString());
                city = cityTextBox.Text.ToString();

                myWatch.Start();
                SqlConnection myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();

                // We have to convert the data collected into the user defined type so that it can be stored properly.
                // It will call the Parse method of the User defined class to insert this data.			
                myQuery = "INSERT INTO MyData (GC,City) VALUES(CONVERT(GeoCache,'" + longitude + "," + latitude + "'),'" + city + "')";

                SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
                myCommand.ExecuteNonQuery();

                ShowData();
                myWatch.Stop();
                timeElapsedLabel.Text = "Elapsed Time: " + myWatch.ElapsedMilliseconds.ToString() + " ms";
                myConnection.Close();
                longitudeTextBox.Text = "";
                latitudeTextBox.Text = "";
                cityTextBox.Text = "";

 
            }
            enterNewLocationButton.Text = "Enter a New Geocache Location";
            enterNewLocationButton.Enabled = true;

        }
        catch
        {
            MessageBox.Show("There was an error inserting data.", "Alert");
        }
        }
        /// <summary>
        /// This method retrieves the data from the table including the user defined type.  
        /// In the select list, it calls the overloaded ToString() method of the user defined
        /// type class to display the data stored.
        /// </summary>
        private void ShowData()
        {

            // We retrieve the data from the table and use the ToString method of the User Defined Type
            // to return the values stored in that type.
            string myQuery = "SELECT ID,GC.ToString() as myGC, City FROM MyData";
            string myConnectionString = ConfigurationManager.AppSettings["myConnectionString"];
            string myResults = "";
            DataSet myDataSet = new DataSet();
            try
            {
                SqlConnection myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
                SqlDataAdapter myDataAdpater = new SqlDataAdapter(myCommand);
                myDataAdpater.Fill(myDataSet);

                for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)
                {
                    myResults = myResults + "ID: " + myDataSet.Tables[0].Rows[i]["ID"].ToString() + "\nGeoCache Location: " + myDataSet.Tables[0].Rows[i]["myGC"].ToString() + "\nCity:" + myDataSet.Tables[0].Rows[i]["City"].ToString() + "\n\n";

                }
                displayRichTextBox.Text = myResults;
                rowsAffectedLabel.Text = "Rows Affected: " + myDataSet.Tables[0].Rows.Count.ToString();

                myConnection.Close();
            }
            catch
            {
                MessageBox.Show("There was an error displaying the data.", "Alert");
            }
        }



        /// <summary>
        /// This method determines whether the value passed in is numeric or not.
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
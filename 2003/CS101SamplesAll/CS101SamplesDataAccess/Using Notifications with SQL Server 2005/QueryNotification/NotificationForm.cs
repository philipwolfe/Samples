using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;

namespace QueryNotification
{
    public partial class NotificationForm : Form
    {
        static SqlDependency myDependency;     // Notification SqlDependency.
        static SqlConnection myConnection;    // Connection to the data source.
        static SqlCommand myCommand;        // Database table query.
        static DataTable myTable;         // Local DataTable bound to the DataGrid.
        static SqlDataAdapter myDataAdapter;     // DataAdapter to fill the DataTable.
        
        /// <summary>
        /// Initialize form.
        /// </summary>
        public NotificationForm()
        {
            InitializeComponent();
        }
        
        /// <summary>
        ///     In this method, called from Form_Load, we are initializing the table and the preliminary data. As well, we initialize the preliminary static
        ///     objects so that we can register and receive query notifications when data changes.
        /// </summary>
        public void InitializeData()
        {
            try
            {
                // get the connection string
                string connectionString = ConfigurationManager.AppSettings["myConnectionString"];
                
                // create a table with an ID, Geocache location, city
                string myQuery = "IF EXISTS (SELECT * FROM sysobjects where name='SampleData' and xtype='U') " +
                 "DROP TABLE dbo.SampleData ";

                SqlConnection localConnection = new SqlConnection(connectionString);
                localConnection.Open();

                myQuery = "IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS " +
                          " WHERE TABLE_NAME = 'SampleView') " +
                          " DROP VIEW SampleView";

                SqlCommand localCommand = new SqlCommand(myQuery, localConnection);
                localCommand.ExecuteNonQuery();

                myQuery = "IF EXISTS (SELECT * FROM sysobjects where name='SampleData' and xtype='U') " +
                     "DROP TABLE dbo.SampleData ";

                localCommand.CommandText = myQuery;
                localCommand.ExecuteNonQuery();

                myQuery = "CREATE TABLE dbo.SampleData ( " +
                        "ID int IDENTITY(1,1) PRIMARY KEY, " +
                        "Value1 float(53))";

                localCommand.CommandText = myQuery;
                localCommand.ExecuteNonQuery();

                for (int i = 0; i < 5; i++)
                {
                    myQuery = "INSERT INTO SampleData (Value1) VALUES(" + i + ")";
                    localCommand.CommandText = myQuery;
                    localCommand.ExecuteNonQuery();
                }
                localConnection.Close();

                myConnection = new SqlConnection(ConfigurationManager.AppSettings["myConnectionString"]);
                myCommand = new SqlCommand("SELECT ID, Value1 FROM SampleData ORDER BY Value1", myConnection);
                myDataAdapter = new SqlDataAdapter(myCommand);
                myTable = new DataTable("Values");
                this.DisplayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error starting this application." + Environment.NewLine + ex.Message, "Alert");
                value1TextBox.Enabled = false;
                insertButton.Enabled = false;
                updateComboBox.Enabled = false;
                updateButton.Enabled = false;

            }
        }
        // Create these delegates so that you can display user messages, timing messages,
        // the dataGridView data.
        private delegate void DisplayInfoDelegate(string Text);
        /// <summary>
        /// This method displays the user message text that occurs during processing
        /// and after processing completes
        /// </summary>
        /// <param name="Text"></param>
        private void DisplayResults(string Text)
        {
            MessageBox.Show(Text, "Information");

        }
        /// <summary>
        /// This event is called whenever a notification that the data has changed occurs.  This indicates
        /// that the data has changed and the information surrounding that change.
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="args"></param>
        public void MySqlDependencyChange(object caller, SqlNotificationEventArgs args)
        {
            string userMessage = "Source data has changed. Data is being refreshed.";

            // Since we can't interact directly with the form, we have to create a new instance of each delegate
            // and invoke the method of each delegate so we can display user messages, time messages, and bind
            // the DataTable to the DataGridView
            DisplayInfoDelegate myUserDelegate = new DisplayInfoDelegate(DisplayResults);
            this.Invoke(myUserDelegate, userMessage);            
        }

        /// <summary>
        /// This event updates data based on the ID that is chosen from the combobox.  Once the data
        /// is altered, a notification should arise telling you that data has been altered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateButton_Click(object sender, EventArgs e)
        {
            Stopwatch myWatch = new Stopwatch();
            try
            {
                updateButton.Text = "Processing...";
                updateButton.Enabled = false;

                myWatch.Start();
                string connectionString = ConfigurationManager.AppSettings["myConnectionString"];
                SqlConnection localConnection = new SqlConnection(connectionString);
                localConnection.Open();
                string myQuery = "UPDATE SampleData SET Value1 = 111 WHERE ID=" + updateComboBox.SelectedItem.ToString();
                SqlCommand localCommand = new SqlCommand(myQuery, localConnection);
                localCommand.ExecuteNonQuery();
                localConnection.Close();
                myWatch.Stop();
                elapsedTimeLabel.Text = "Elapsed Time: " + myWatch.ElapsedMilliseconds.ToString() + " ms";
                actionLabel.Text = "Action: Data Updated";
                DisplayData();

                updateButton.Text = "Update Data";
                updateButton.Enabled = true;

            }
            catch
            {
                MessageBox.Show("There was an error updating.", "Alert");
            }
        }

        /// <summary>
        /// This method sets the creates the SqlDependency that is associated to the 
        /// command object.  This adds a new event handler that calls the MySqlDependencyChange method
        /// whenever a changed in the data is detected.
        /// </summary>
        /// <param name="cmd"></param>
        private void SetupDependency(SqlCommand cmd)
        {
            
            // unregister any previous eventhandlers
            if (myDependency != null)
                myDependency.OnChange -= new OnChangeEventHandler(MySqlDependencyChange);

            // Clear out any existing notification information from the command.
            cmd.Notification = null;

            // Create the SqlDependency and associate it with the query command.
            myDependency = new SqlDependency(cmd);
            myDependency.OnChange += new OnChangeEventHandler(MySqlDependencyChange);

            // start the dependency:
            SqlDependency.Start(cmd.Connection.ConnectionString);
           
        }

        /// <summary>
        /// This method simply calls the SetupDependency method passing the command object as a parameter
        /// and then gets the most recent verion of the data to display.
        /// </summary>
        private void DisplayData()
        {
            try
            {
                myDataAdapter.SelectCommand.CommandText = "SELECT ID, Value1 FROM SampleData ORDER BY Value1";
                myTable.Clear();
                SetupDependency(myDataAdapter.SelectCommand);
                myDataAdapter.Fill(myTable);
                resultsDataGridView.DataSource = myTable;
                FillComboBox();
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error displaying the data." + Environment.NewLine + ex.Message, "Alert");
            }
        }

        /// <summary>
        /// This event inserts new data into the table to altering the dataset that woudl be returned 
        /// providing a notification that will be sent back to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertButton_Click(object sender, EventArgs e)
        {
            try
            {
                insertButton.Text = "Processing...";
                insertButton.Enabled = false;

                if (!IsNumeric(value1TextBox.Text) || value1TextBox.Text == "")
                    MessageBox.Show("Please enter a valid number.", "Alert");
                else
                {
                    Stopwatch myWatch = new Stopwatch();
                    myWatch.Start();
                    double myValue = Convert.ToDouble(value1TextBox.Text.ToString());
                    myConnection.Open();
                    string myQuery = "INSERT INTO SampleData (Value1) VALUES(" + myValue + ")";
                    SqlCommand localCommand = new SqlCommand(myQuery, myConnection);
                    localCommand.ExecuteNonQuery();
                    myConnection.Close();
                    myWatch.Stop();
                    elapsedTimeLabel.Text = "Elapsed Time: " + myWatch.ElapsedMilliseconds.ToString() + " ms";
                    actionLabel.Text = "Action: Data Inserted.";
                    value1TextBox.Text = "";
                    DisplayData();
                }

                insertButton.Text = "Insert Data";
                insertButton.Enabled = true;

            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error inserting data." + Environment.NewLine + ex.Message, "Alert");
            }

        }

        /// <summary>
        /// This event is fired when the form is loaded and initializes data, then fills the combobox for the update event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotificationForm_Load(object sender, EventArgs e)
        {
            InitializeData();
            FillComboBox();
        }

        /// <summary>
        /// This method fills the combobox with the data from the table.
        /// </summary>
        private void FillComboBox()
        {
            try
            {
                updateComboBox.Items.Clear();
                myConnection.Open();
                myCommand.CommandText = "SELECT * FROM dbo.SampleData";
                SqlDataReader myReader = myCommand.ExecuteReader();
                // process DataReader
                while (myReader.Read())
                    updateComboBox.Items.Add(myReader[0].ToString());
                myReader.Close();
                myConnection.Close();

                updateComboBox.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error Filling the ComboBox." + Environment.NewLine + ex.Message, "Alert");
            }
        }
       
       
        /// <summary>
        /// This method determines if a value is valid numeric value or not
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
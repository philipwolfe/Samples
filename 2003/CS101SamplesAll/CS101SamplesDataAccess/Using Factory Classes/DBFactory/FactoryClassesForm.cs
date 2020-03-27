using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Configuration;
using System.Diagnostics;

namespace DBFactory
{
	public partial class factoryClassesForm : Form
	{
		public factoryClassesForm()
		{
			InitializeComponent();
            providerComboBox.SelectedIndex = 0;
		}
		/// <summary>
		/// In this event, you create the DbProviderFactory which allows
		/// you to connect to the a number of different data sources.  
		/// All the specific connection string information is retrieved
		/// from the app.config file.  This allows you to write the generic connection
		/// code and the specific information is populated from the configuration file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void getDataButton_Click(object sender, EventArgs e)
		{
			try
			{
				// Create an instance of the new StopWatch class to measure performance
				Stopwatch myWatch = new Stopwatch();

				// Start the timer to measure connection and retrieval of data
				myWatch.Start();

				// Get the name of the database we are going to use
				string myName = providerComboBox.SelectedItem.ToString();

				// Get the connection settings from the configuration file based on the name selected
				// in the ComboBox
				ConnectionStringSettings myConnectionSettings = ConfigurationManager.ConnectionStrings[myName];

				// Create an instance of the DbProviderFactory by using the Provider name in the config file
				DbProviderFactory myProvider = DbProviderFactories.GetFactory(myConnectionSettings.ProviderName);
				
				// Create the connection from the DbProvider factory, this code does not need to change for
				// for different providers
				DbConnection myConnection = myProvider.CreateConnection();

				// Get the connection string from the connectionsettings
				// This gets us the specific provider by which we will connect
				myConnection.ConnectionString = myConnectionSettings.ConnectionString;

				// Open the connection
				myConnection.Open();

				// now we can create the DataAdapter and then create a command
				DbDataAdapter myAdapter = myProvider.CreateDataAdapter();
				DbCommand myCommand = myProvider.CreateCommand();
				
				// Create the DataSet so that we can populate the datagrid
				string myQuery = "SELECT * FROM SampleData";
				DataSet myDataSet = new DataSet();

				myCommand.Connection = myConnection;
				myCommand.CommandText = myQuery;

				myAdapter.SelectCommand = myCommand;

				myAdapter.Fill(myDataSet);
				
				displayDataGridView.DataSource = myDataSet.Tables[0];

				// Now we can stop the timer and display the elapsed time along
				// with other provider and connection string information
				myWatch.Stop();
				elapsedTimeTextLabel.Text = "Elapsed Time: " +  myWatch.ElapsedMilliseconds.ToString() + " ms";
				providerLabel.Text = "Provider: " + myConnectionSettings.ProviderName.ToString();
				connectionStringLabel.Text = myConnectionSettings.ConnectionString.ToString();

			}
			catch 
			{
				MessageBox.Show("There was an error retrieving data.  Please try again.", "Alert");
			}
			
    	}
	}
}
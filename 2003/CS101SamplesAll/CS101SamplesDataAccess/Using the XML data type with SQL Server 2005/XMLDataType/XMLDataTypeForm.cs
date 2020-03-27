using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Data.SqlTypes;
using System.Configuration;

namespace XMLDataType
{
	public partial class xmlDataTypeForm : Form
	{
		public xmlDataTypeForm()
		{
			InitializeComponent();
            
		}

		/// <summary>
		/// This event reads an XML file and stores the information in 
		/// an xml data type column.  This did not exist in previous versions of 
		/// SQL Server.  With the next XmlReader object, you can read xml data
		/// directly from your source and insert the reader object into a SqlDbType.Xml column.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void insertDataButton_Click(object sender, EventArgs e)
		{
			try
			{

                schemaDataGridView.DataSource = "";
                dataRichTextBox.Text = "";
                
                insertDataButton.Text = "Processing...";
                insertDataButton.Enabled = false;

				// first initialize the connection string and the query string
                string connectionString = ConfigurationManager.AppSettings["myConnectionString"];
				string myQuery = "";
				if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My CD's"))
				{
					myQuery = "INSERT INTO  CDInformation(CDInformation) VALUES(@myXMLData)";
				}
				else if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My Plants"))
				{
					myQuery = "INSERT INTO  PlantInformation(PlantInformation) VALUES(@myXMLData)";
				}
				else if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My Menus"))
				{
					myQuery = "INSERT INTO  MenuInformation(MenuInformation) VALUES(@myXMLData)";
				}

				// create all connection objects and command objects here
				using (SqlConnection myConnection = new SqlConnection(connectionString))
				using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
				{
					myConnection.Open();
					// Add SqlDbType parameter to be inserted into the table
					myCommand.Parameters.Add("@myXMLData", SqlDbType.Xml);

					// connect the parameter value to a file based on the the collectionList item chosen
					XmlReader myXmlReader = null;
					if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My CD's"))
					{
						myXmlReader = XmlReader.Create("../../DataFiles/cd_catalog.xml");
					}
					else if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My Plants"))
					{
						myXmlReader = XmlReader.Create("../../DataFiles/plant_catalog.xml");
					}
					else if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My Menus"))
					{
						myXmlReader = XmlReader.Create("../../DataFiles/simple.xml");
					}

					// We want to make sure the XmlReader has been assigned
					if (myXmlReader != null)
					{
						myCommand.Parameters[0].Value = new SqlXml(myXmlReader);
						int i = myCommand.ExecuteNonQuery();
						MessageBox.Show("Inserted Successfully!", "Information");
					}
					else
						MessageBox.Show("There was an error inserting!", "Alert");
				}
			}
			catch
			{
				MessageBox.Show("There was an error inserting!", "Alert");
			}

            insertDataButton.Text = "Insert Data";
            insertDataButton.Enabled =true;


		}

		/// <summary>
		/// This event shows the actual data. This event shows the database columns by binding to a DataGridview
		/// and the actual data is displayed in a richtextbox to show how easy it is to get the data out of a xml data field
		/// You can also choose between data with markup and data without
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void showDataButton_Click(object sender, EventArgs e)
		{
            try
            {
                if (withMarkupRadioButton.Checked)
                {
                    DisplayDataWithMarkup();
                }
                else
                {
                    DisplayDataWithoutMarkup();
                    withoutMarkupRadioButton.Checked = true;
                }
            }
            catch
            {
                MessageBox.Show("There was an error displaying data. Please click the 'Insert Data' button first.", "Alert");
            }

		}

		/// <summary>
		/// This method reads the XML data from the database and then populates the DataGridView and the 
		/// clean data populates the richtext box.  This is accomplished by creating a SqlDataReader and data table to 
		/// populate the DataGridViewfrom and the new XmlReader object to populate the RichTextBox. 
		/// </summary>
		private void DisplayDataWithoutMarkup()
		{
            try
            {
                // initialize the different parameters, these will all be used later.
                string myConnectionString = ConfigurationManager.AppSettings["myConnectionString"];
                string myQuery = "";
                string myCleanData = "";

                // determine which table should be queried
                if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My CD's"))
                {
                    myQuery = "select TOP 1 CDInformation from CDInformation";
                }
                else if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My Plants"))
                {
                    myQuery = "select TOP 1 PlantInformation from PlantInformation";
                }
                else if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My Menus"))
                {
                    myQuery = "select TOP 1 MenuInformation from MenuInformation";
                }

                // This is where the main work happens.  We read through all the records returned
                // from the database.  We use the new XmlReader object to read the XML data that is
                // stored in the database
                using (SqlConnection myConnection = new SqlConnection(myConnectionString))
                using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                {
                    myConnection.Open();
                    SqlCommand mySecondCommand = new SqlCommand(myQuery, myConnection);

                    SqlDataReader myReader = myCommand.ExecuteReader();
                    DataTable myData = new DataTable();
                    myData.Load(myReader);
                    myReader.Close();
                    // We are going to read the data stored in the xmlReader
                    XmlReader myXMLReader = mySecondCommand.ExecuteXmlReader();
                    myXMLReader.Read();
                    while (myXMLReader.Read())
                    {
                        // Here we are getting the data without any markup to be displayed
                        myCleanData = myCleanData + myXMLReader.ReadString() + "\n";
                    }


                    // Bind the DataTable to the DataGridView
                    schemaDataGridView.DataSource = myData;
                    // Here we are assigning the data to the textbox to show the XML data without markup
                    dataRichTextBox.Text = myCleanData;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show("There was an error displaying data without markup. Please click the 'Insert Data' button first.", "Alert");
            }
		}

		/// <summary>
		/// This method is similar to the DisplayDataWithoutMarkup except that in this method,
		/// we are displaying the specific data in the nodes in the XML document.
		/// </summary>
		private void DisplayDataWithMarkup()
		{
            try
            {
                // initialize the different parameters, these will all be used later.
                string myConnectionString = ConfigurationManager.AppSettings["myConnectionString"];
                string myQuery = "";
                string myXMLData = "";

                // determine which table to query
                if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My CD's"))
                {
                    myQuery = "select TOP 1 CDInformation from CDInformation";
                }
                else if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My Plants"))
                {
                    myQuery = "select TOP 1 PlantInformation from PlantInformation";
                }
                else if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My Menus"))
                {
                    myQuery = "select TOP 1 MenuInformation from MenuInformation";
                }

                // Here we are again creating the data readers to display the data
                // We are using the new XmlReader to read the XML data that is returned from the query
                using (SqlConnection myConnection = new SqlConnection(myConnectionString))
                using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                {
                    myConnection.Open();
                    SqlCommand mySecondCommand = new SqlCommand(myQuery, myConnection);

                    SqlDataReader myReader = myCommand.ExecuteReader();
                    DataTable myData = new DataTable();
                    myData.Load(myReader);
                    myReader.Close();

                    XmlReader myXMLReader = mySecondCommand.ExecuteXmlReader();
                    while (myXMLReader.Read())
                    {
                        myXMLReader.Read();
                        myXMLData = myXMLData + myXMLReader.ReadOuterXml() + "\n\n";
                        myXMLReader.Read();
                    }
                    // Bind the DataTable to the DataGridView to see how the data is stored in the database
                    schemaDataGridView.DataSource = myData;
                    // Assign richTextBox with XML data
                    dataRichTextBox.Text = myXMLData;

                }
            }
            catch
            {
                MessageBox.Show("There was an error displaying data with markup. Please click the 'Insert Data' button first.", "Alert");
            }
		}

		/// <summary>
		/// This method displays the table schema so that you can see how the table is setup with it's 
		/// properties
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void showDefinitionButton_Click(object sender, EventArgs e)
		{
            try
            {
                dataRichTextBox.Text = "";

                // set up the Connection String and Querystring
                string myConnectionString = ConfigurationManager.AppSettings["myConnectionString"];
                string myQuery = "";
                if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My CD's"))
                {
                    myQuery = "select * from CDInformation";
                }
                else if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My Plants"))
                {
                    myQuery = "select * from PlantInformation";
                }
                else if (Convert.ToBoolean(collectionListComboBox.SelectedItem.ToString() == "My Menus"))
                {
                    myQuery = "select * from MenuInformation";
                }

                // This is where you get the Table Schema that is
                // to be displayed in the DataGridView
                using (SqlConnection myConnection = new SqlConnection(myConnectionString))
                using (SqlCommand myCommand = new SqlCommand(myQuery, myConnection))
                {
                    myConnection.Open();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    DataTable myTable = myReader.GetSchemaTable();

                    schemaDataGridView.DataSource = myTable;

                }
            }
            catch
            {
                MessageBox.Show("There was an error displaying table definition.  Please click the 'Insert Data' button first.", "Alert");
            }
		}

		#region Events

        /// <summary>
        /// This event loads the ComboBox with collection items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void xmlDataTypeForm_Load(object sender, EventArgs e)
		{
			collectionListComboBox.Items.Add("My CD's");
			collectionListComboBox.Items.Add("My Plants");
			collectionListComboBox.Items.Add("My Menus");
            collectionListComboBox.SelectedIndex = 0;
		}

        /// <summary>
        /// This event displays information without markup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void withoutMarkup_CheckedChanged(object sender, EventArgs e)
		{
			DisplayDataWithoutMarkup();
		}

        /// <summary>
        /// This event displays information with markup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void withMarkup_CheckedChanged(object sender, EventArgs e)
		{
			DisplayDataWithMarkup();
		}
		#endregion

		
	}
}
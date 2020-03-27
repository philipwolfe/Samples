using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace XPathXsL
{
	public partial class xpathXslForm : Form
	{
		public xpathXslForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// This event displays the actual data that is stored in the database.  Using the XmlReader you can
		/// retrieve the xml data type results from the database.
		/// The XmlDocument class allows us to search on the XML results that are stored in the reader
		/// The XmlNavigator and XPathNodeIterator classes allows you to filter the results that are stored
		/// in the XmlDocument.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void displayData_Click(object sender, EventArgs e)
		{
            try
            {

                // Initialize the connection string
                string myConnectionString = ConfigurationManager.AppSettings["myConnectionString"];
                // The using block ensures that we will close this connection when we finish
                using (SqlConnection myConnection = new SqlConnection(myConnectionString))
                {
                    // Using the new StopWatch class, we can display the time required to 
                    // retrieve, filter and display the results
                    Stopwatch myWatch = new Stopwatch();
                    // Open the connection
                    myConnection.Open();

                    // Retrieve the XML results
                    string myQuery = "SELECT TOP 1 Description FROM Information ORDER BY ID Desc";

                    // Create the SqlCommand
                    SqlCommand myCommand = new SqlCommand(myQuery, myConnection);

                    // Here you want to set the XmlReader settings to ensure that the
                    // data returned will fit within a conformance level and be properly 
                    // displayed
                    XmlReaderSettings mySettings = new XmlReaderSettings();
                    mySettings.ConformanceLevel = ConformanceLevel.Fragment;
                    mySettings.IgnoreComments = true;
                    mySettings.IgnoreWhitespace = true;

                    // At this point, you want start the timer
                    myWatch.Start();

                    // Here we are filling the XmlReader object with the results from the query
                    XmlReader myReader = XmlReader.Create(myCommand.ExecuteXmlReader(), mySettings);

                    // Now, we are creating the XmlDocument that we will use when we filter the results
                    XmlDocument myDocument = new XmlDocument();
                    myDocument.Load(myReader);

                    // We need to create a navigator object so that we can execute an XPath Query
                    XPathNavigator myNavigator = myDocument.CreateNavigator();

                    // Get the price from the combobox that we will use to filter the results
                    string myPrice = priceChoiceComboBox.SelectedItem.ToString();

                    // Set the XPath Query that we will use to filter the results
                    string myExpression = "/CATALOG/PLANT[PRICE>" + myPrice + "]";

                    // Create an XPathNodeIterator that is returned when we execute the filter expression
                    // these are just returned as the values of the nodes.
                    XPathNodeIterator myIterator = myNavigator.Select(myExpression);

                    // We can set how many rows are returned from the iterator
                    rowsReturned.Text = myIterator.Count.ToString();

                    // Since we want to transform the data, we need to pass the Iterator results as arguments in the
                    // transformation method
                    XsltArgumentList myArguments = new XsltArgumentList();
                    myArguments.AddParam("parameter1", "", myIterator);

                    // We create a new XslCompiledTransform object which supercedes the XslTransform class
                    XslCompiledTransform myTransform = new XslCompiledTransform();
                    // We have to load the XSL style sheet before we perform any transformation
                    myTransform.Load(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()).ToString() + "\\Datafiles\\PlantCatalog.xsl");

                    // We are setting the XmlWriterSettings so that we match the conformance level of the XmlReaderSettings
                    XmlWriterSettings myWriterSettings = new XmlWriterSettings();
                    myWriterSettings.ConformanceLevel = ConformanceLevel.Fragment;

                    // Create a string builder which will eventually contain our transformed results
                    StringBuilder myString = new StringBuilder();

                    // Perform the transformation using the XmlDocument, the Parameters created from the Iterator and 
                    // write it to the StringBuilder
                    myTransform.Transform(myDocument, myArguments, XmlWriter.Create(myString, myWriterSettings));

                    // Using the WebBrowser control, display the transformed data
                    resultsWebBrowser.DocumentText = myString.ToString();
                    // We can stop the timing now
                    myWatch.Stop();

                    // Display the time required to perform the transformation
                    elapsedTime.Text = myWatch.ElapsedMilliseconds.ToString() + " ms";
                }
            }
            catch
            {
                MessageBox.Show("There was an error displaying the data. Please click the 'Load XML' button first.", "Alert");
            }
		}

		/// <summary>
		/// This event allows us to read in some XML from a file and insert it into the database 
		/// by using the Bulk and the SingleClob keywords.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void loadXMLButton_Click(object sender, EventArgs e)
		{
            try
            {
                loadXMLButton.Text = "Processing...";
                loadXMLButton.Enabled = false;

                Application.DoEvents();

                string myConnectionString = ConfigurationManager.AppSettings["myConnectionString"];
                SqlConnection myConnection = new SqlConnection(myConnectionString);
                myConnection.Open();
                string myQuery = "INSERT INTO Information " +
                                    " SELECT XmlColumn " +
                                    " FROM    (SELECT *     " +
                                    " FROM OPENROWSET (BULK '" + Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()).ToString() + "\\Datafiles\\plant_catalog.xml', SINGLE_CLOB)  " +
                                    " AS XmlColumn) AS R(XmlColumn) ";

                SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Data Loaded!", "Information");
            }
            catch
            {
                MessageBox.Show("There was an error loading the XML. Please try again.","Alert");
            }
            finally
            {
                loadXMLButton.Enabled = true;
                loadXMLButton.Text = "Load XML";
            }
		}

        /// <summary>
    /// This event fires when the form is loaded and fills the ComboBox with price information.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
        /// <remarks></remarks>
    
		private void XPathXslForm_Load(object sender, EventArgs e)
		{
            try
            {
                for (int i = 1; i < 11; i++)
                {
                    priceChoiceComboBox.Items.Add(i);
                }
                priceChoiceComboBox.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("There was an error loading the ComboBox.", "Alert");
            }
		}
	}
}
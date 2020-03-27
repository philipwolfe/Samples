using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO; // For stream reader / writer
using System.Xml; // For XmlTextReader
using System.Data; // For DataSet

namespace DataCentricApp
{
	public partial class Form1 : Form
	{
		private const string myFileName = "\\My Documents\\Personal\\Persons.xml";
		private DataSet myDataSet;

		public Form1()
		{
			InitializeComponent();
			myDataSet = new DataSet();
			CreateXmlDataFile();

			// Hide PrevNextButton until after user has loaded xml file
			PrevNextButton.Visible = false;
		}

		// Create simple xml file data file with two entries for this sample.  
		private void CreateXmlDataFile()
		{
			// Create xml file
			StreamWriter writer = File.CreateText(myFileName);
			writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
			writer.WriteLine("<Persons>");
			writer.WriteLine("  <Person>");
			writer.WriteLine("      <First>Joe</First>");
			writer.WriteLine("      <Last>Smith</Last>");
			writer.WriteLine("      <Phone>509-555-1212</Phone>");
			writer.WriteLine("  </Person>");
			writer.WriteLine("  <Person>");
			writer.WriteLine("      <First>Jane</First>");
			writer.WriteLine("      <Last>Jones</Last>");
			writer.WriteLine("      <Phone>503-555-1212</Phone>");
			writer.WriteLine("  </Person>");
			writer.WriteLine("</Persons>");
			writer.Close();
		}

		private void ClearBindings()
		{
			TextBox1.DataBindings.Clear();
			TextBox2.DataBindings.Clear();
			TextBox3.DataBindings.Clear();		
		}

		private void AddBindings(DataSet dataSet)
		{
			TextBox1.DataBindings.Add(new Binding("Text", dataSet, "Person.First"));
			TextBox2.DataBindings.Add(new Binding("Text", dataSet, "Person.Last"));
			TextBox3.DataBindings.Add(new Binding("Text", dataSet, "Person.Phone"));
		}

		// Uses a FileStream and XmlTextReader to read the xml file generated when
		// the form is created...see Form1 class member fileName for location of file
		private void ReadXml(DataSet dataSet)
		{
			try
			{
				FileStream fs = File.OpenRead(myFileName);
				XmlTextReader reader = new XmlTextReader(fs);
				dataSet.ReadXml(reader);
				reader.Close(); // close reader and underlying stream
			}
			catch (Exception e)
			{
				MessageBox.Show("Error: " + e.Message);
			}
		}

		private void LoadButton_Click(object sender, EventArgs e)
		{
			StatusBar1.Text = "Loading Xml from File...";
			StatusBar1.Update(); // Force update
			Cursor.Current = Cursors.WaitCursor; // Show wait cursor

			// Clear the DataSet and DataBindings in case the 'Load// button is clicked repeatedly
			myDataSet.Clear();
			ClearBindings();

			// Populate dataset with data from xml file
			ReadXml(myDataSet);

			// Add Bindings
			AddBindings(myDataSet);

			Cursor.Current = Cursors.Default; // show default cursor
			StatusBar1.Text = "Loading Xml from File...Complete";

			// Show PrevNextButton after file loaded
			PrevNextButton.Visible = true;
		}

		private void PrevNextButton_Click(object sender, EventArgs e)
		{
			if (PrevNextButton.Text == "Next")
			{
			    BindingContext[myDataSet, "Person"].Position += 1;
		        PrevNextButton.Text = "Prev";
	            StatusBar1.Text = "Person: " + TextBox1.Text + " " + TextBox2.Text + " - " + TextBox3.Text;
			}
			else
			{
	            BindingContext[myDataSet, "Person"].Position -= 1;
		        PrevNextButton.Text = "Next";
			    StatusBar1.Text = "Person: " + TextBox1.Text + " " + TextBox2.Text + " - " + TextBox3.Text;
			}
		}

		private void DeleteMenuItem_Click(object sender, EventArgs e)
		{
			// Delete xml file
			try
			{
				File.Delete(myFileName);

				// Hide PrevNextButton until after user has loaded xml file
				PrevNextButton.Visible = false;
				StatusBar1.Text = "File Deleted";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void CreateMenuItem_Click(object sender, EventArgs e)
		{
			CreateXmlDataFile();
			StatusBar1.Text = "File Created";
		}
	}
}
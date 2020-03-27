using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DocumentList
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			// Create files for this sample.  User may choose to omit this action if there are already 
			// files on the emulator or device.
			CreateSampleFiles();

			// Init the ComboBox
			InitCombo();
			FilterComboBox.SelectedIndex = 0; // Select default filter as All

			// Set the initial folder for the DocumentList control
			FileDocumentList.SelectedDirectory = "Personal";
		}

		// Create simple text and xml files for this sample.  In order to properly demonstrate the 
		// DocumentList control, there should be some files on the device.  Because emulators don't have
		// any useful files in the My Documents folder or sub folders, six files will be created here to 
		// guarantee files will be available for viewing.  Note there are also usually some default template
		// files in the \My Documents\Templates older as well.
		private void CreateSampleFiles()
		{
			string path = "\\My Documents\\Personal\\" ;

			// Create 3 text files
			for (int i = 0; i <= 2; i++)
			{
				string name = "TextFile" + i.ToString() + ".txt";
				StreamWriter writer = File.CreateText(path + name);
				writer.WriteLine(name);
				writer.WriteLine();
				writer.WriteLine("This is a standard text file created for this sample");
				writer.Close();
			}

			// Create 3 xml files
			for (int i = 0; i <= 2; i++)
			{
				string name = "XmlFile" + i.ToString() + ".xml";
				StreamWriter writer = File.CreateText(path + name);
				writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
				writer.WriteLine("<Items>");
				writer.WriteLine("<Item>");
				writer.WriteLine("<Name>Apple" + i.ToString() + "</Name>");
				writer.WriteLine("<Desc>Round Fruit</Desc>");
				writer.WriteLine("</Item>");
				writer.WriteLine("<Items>");
				writer.Close();
			}
		}

		// Give the Combo Box some initial filter values
		private void InitCombo()
		{
			FilterComboBox.Items.Add("All");
			FilterComboBox.Items.Add("Text");
			FilterComboBox.Items.Add("Xml");
			FilterComboBox.Items.Add("Other");
			FileDocumentList.Filter = GetFilter();
		}

		// Determine the filter based on the selected index of the combo box
		// For each filtering option, the filter string contains a description of the filter, 
		// followed by a vertical bar (|) and the filter pattern. Because of limited space, 
		// Pocket PC guidelines suggest skipping the description. 
		// An omitted description REQUIRES A SPACE before a vertical bar. 
		// For example, the following filter string includes a description:

		//   "Text files (*.txt)|*.txt"

		//   Without a description, this filter string should appear as: " |*.txt"

		// A vertical bar also separates filtering options. You can use semicolons to 
		// delineate multiple filter patterns within a filter option. 
		// The following filter string specifies five filtering options: 
		//   " |*.*| |*.pwi;*.pdt| |*.rtf| |*.txt| |*.xml"
		private string GetFilter()
		{
			switch (FilterComboBox.SelectedIndex)
			{
				case 1 : return " |*.txt";
				case 2 : return " |*.xml";
				case 3 : return " |*.pwi;*.pdt| |*.rtf| |*.txt| |*.xml";
				default : return " |*.*"; // default "All" which is case 0
			}
		}

		// Event to set DocumentList Filter property when selection in ComboBox is changed
		private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			string filter = GetFilter();
			FileDocumentList.Filter = filter;

			// Update the StatusBar so filter can be seen.
			ActionStatusBar.Text = "Filter: " + FilterComboBox.Items[FilterComboBox.SelectedIndex].ToString() + " - " + filter;
			FileContentsTextBox.Text = string.Empty; // clear text
		}

		// Handle the DeletingDocument event with code to close the file.
		private void FileDocumentList_DeletingDocument(object sender, Microsoft.WindowsCE.Forms.DocumentListEventArgs e)
		{
	       ActionStatusBar.Text = "Deleted: " + e.Path;
	       FileContentsTextBox.Text = string.Empty; // clear text
		}

		// Handle the DocumentedActivated event with code to open the file, read file and display contents
		// in the TextBox
		private void FileDocumentList_DocumentActivated_1(object sender, Microsoft.WindowsCE.Forms.DocumentListEventArgs e)
		{
		    FileContentsTextBox.Text = string.Empty; // clear text box
		    ActionStatusBar.Text = "Activated: " + e.Path;
		    // Open the selected file and display contents in textbox
							
			try 
			{
				// Create an instance of StreamReader to read from a file.
				// The using statement also closes the StreamReader.
				using (StreamReader reader = new StreamReader(e.Path)) 
				{
					string line;
			        string fileText = string.Empty;
					// Read and display lines from the file until the end of 
					// the file is reached.
					while ((line = reader.ReadLine()) != null) 
					{
						FileContentsTextBox.Text += line + "\r\n";
					}
				}
			}
			catch (Exception ex) 
			{
				// Let the user know what went wrong.
		        MessageBox.Show("The file could not be read:\r\n" + ex.Message);
			}
		}
		// Handle the SelectedDirectoryChanged event with code that sets the correct  
		// path for opening and closing files.
		private void FileDocumentList_SelectedDirectoryChanged(object sender, EventArgs e)
		{
			// Write selected folder change to the status bar
			ActionStatusBar.Text = "Folder: " + FileDocumentList.SelectedDirectory;
			FileContentsTextBox.Text = string.Empty; // clear text
		}
		// Delete the Sample Files that were created.  It is assumed that the files remain
		// in the created location and have not been renamed or moved   
		private void DeleteMenuItem_Click(object sender, EventArgs e)
		{
			FileContentsTextBox.Text = string.Empty; // clear text
			string path = "\\My Documents\\Personal\\";
			try
			{
				// Delete text files
				File.Delete(path + "TextFile0.txt");
				File.Delete(path + "TextFile1.txt");
				File.Delete(path + "TextFile2.txt");

				// Delete xml files
				File.Delete(path + "XmlFile0.xml");
				File.Delete(path + "XmlFile1.xml");
				File.Delete(path + "XmlFile2.xml");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}
		// Create the sample files again...Useful if files have been deleted while using the 
		// DocumentList control delete or move
		private void CreateMenuItem_Click(object sender, EventArgs e)
		{
			FileContentsTextBox.Text = string.Empty; // clear text
			CreateSampleFiles();
		}
  	}
}
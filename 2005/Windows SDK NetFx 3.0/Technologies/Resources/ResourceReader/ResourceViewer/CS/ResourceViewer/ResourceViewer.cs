//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;
using System.Text;

#endregion

namespace Microsoft.Samples.ResourceViewer
{
	// This struct will be used to store the information about the 
	// resources that we gather from the .resrouces file
	struct resource
	{
		#region Private Fields

		object ValueData;
		string TypeValue;
		string NameValue;
		byte[] BytesValue;

		#endregion

		#region Public Properties

		public object Value { get { return ValueData; } }
		public string Type { get { return TypeValue; } }
		public string Name { get { return NameValue; } }
		public byte[] Bytes { get { return BytesValue; } }

		#endregion

		#region Constructor

		public resource(string name, string type, object value, byte[] bytes)
		{ NameValue = name; TypeValue = type; ValueData = value; BytesValue = bytes; }

		#endregion
	}

	partial class ResourceViewer : Form
	{
		// The resource information that we read from the .resources file
		Dictionary<string, resource> resources;

		public ResourceViewer()
		{
			InitializeComponent();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			#region Local Variables
			string name;
			string type;
			object value;
			byte[] bytes;
			#endregion

			#region Call Open Dialog

			openFileDialog1.ShowDialog();

			// If the user cancels out of the dialog we 
			// shouldn't proceed
			if (string.IsNullOrEmpty(openFileDialog1.FileName))
				return;

			#endregion

			#region Resetting Information and Opening File

			// We should clear this information in case this isn't
			// the first file the user has opened.
			gridResources.Rows.Clear();
			resources = new Dictionary<string, resource>();

			txtBytes.Text = string.Empty;
			txtName.Text = string.Empty;
			txtType.Text = string.Empty;
			txtValue.Text = string.Empty;
			image.Image = null;

			// Here, we set up the resource reader and get an enumerator
			// to walk through the resources
			ResourceReader myReader = new ResourceReader(openFileDialog1.FileName);
			IDictionaryEnumerator readerWalker = myReader.GetEnumerator();

			#endregion

			#region Reading Resources

			try
			{
				while (readerWalker.MoveNext())
				{
					// The resource name is the 
					// enumterator's key 
					name = (string)(readerWalker.Key);

					// GetResourceData is used to retrieve the type and
					// binary information about the resource
					myReader.GetResourceData(name, out type, out bytes);

					// If possible, we will read the resource's value directly
					try
					{
						value = readerWalker.Value;
					}
					// However, if the type cannot be deserialized, we can report that
					// and the binary data and type gathered by the GetResourceData method
					// will still be useful.
					catch (FileNotFoundException) { value = "Unresolvable type: " + type; }
					catch (TypeLoadException) { value = "Unresolvable type: " + type; }

					// We add each resource we read to our dictionary so that we can 
					// access it later
					resources.Add(name, new resource(name, type, value, bytes));

					// Very long names in the data grid will hurt our performance, so as
					// we add each resource to the data grid, we limit it's value's length
					// to 500 characters. We don't actually change the value in our 
					// dictionary, however, because we want to be able to display the full value
					// in the value text box when the user selects the resource.
					string shortVal = null;
					if (value != null)
					{
						shortVal = (value.ToString().Length > 500) ? value.ToString().Substring(0, 500) : value.ToString();
					}

					// We add the information to our data grid
					gridResources.Rows.Add(new object[] { name, ShortType(type), shortVal });
				}
			}
			finally
			{
				// We enclose the Close statement in a finally clause so that we can be sure it is 
				// executed even if something goes wrong with the resource reading code
				myReader.Close();
			} 

			#endregion

		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void gridResources_SelectionChanged(object sender, EventArgs e)
		{
			// If the data grid is cleared (as it is between files) then the
			// selection will change to nothing and we should not try to
			// display such a selection
			if (gridResources.SelectedRows.Count == 0) return;

			#region Retrieve Resource Information

			// We use the name from the data grid to find the resource in our dictionary
			string selectedName = gridResources.SelectedRows[0].Cells[0].Value.ToString();
			resource selectedResource = resources[selectedName];

			// We set the test boxes to the appropriate values
			txtName.Text = selectedResource.Name;
			txtType.Text = selectedResource.Type;
			lblBytes.Text = "Bytes (" + selectedResource.Bytes.Length + ")";

			// And for now we hide both the value text box and image
			image.Visible = false;
			txtValue.Visible = false;

			// We start the bytes text box with a default string because it can take a
			// little bit of time to turn all of the bytes in a large array into a string
			// and we want something in the bytes text box to inform the user of that
			txtBytes.Text = "Reading bytes...";

			#endregion

			#region Displaying the Resource's Value

			// If the resource's value is null, we simply
			// display as much in the value text box
			if (selectedResource.Value == null)
			{
				image.Visible = false;
				txtValue.Visible = true;

				txtValue.Text = "<null>";
			}

			// If the resource's value is a bitmap, we show the
				// image box and fill it with the image
			else if (selectedResource.Value.GetType() == typeof(System.Drawing.Bitmap))
			{
				image.Visible = true;
				txtValue.Visible = false;

				image.Image = (Bitmap)(selectedResource.Value);
			}

			// If the resource's value is an icon, we convert it to a bitmap
				// and display it as before
			else if (selectedResource.Value.GetType() == typeof(System.Drawing.Icon))
			{
				image.Visible = true;
				txtValue.Visible = false;

				image.Image = ((Icon)(selectedResource.Value)).ToBitmap();
			}

			// Finally, for any other data type, we display it in the value
				// text box by calling its ToString method
			else
			{
				image.Visible = false;
				txtValue.Visible = true;

				txtValue.Text = selectedResource.Value.ToString();
			}

			// We refresh before filling the bytes text box, because that can be
			// a time consuming process if there are a lot of bytes, and we want
			// the user to see what is ready to be shown, especially the message
			// informing them that the bytes are currently being read
			this.Refresh();

			#endregion

			// Finally, we fill the byte text box with our BytesToString
			// helper method
			txtBytes.Text = BytesToString(selectedResource.Bytes);
		}

		private string BytesToString(byte[] bytes)
		{
			// We know that each byte will be two digits plus a space, so we can initialize our
			// string builder to the correct capacity
			StringBuilder output = new StringBuilder(bytes.Length * 3);

			foreach (byte b in bytes)
			{
				// Here we append either the byte (in hex) and a space, or a zero, the byte, and
				// a space depending on whether the byte is one or two digits in hex.
				output.Append((b < 16) ? "0" + b.ToString("x", NumberFormatInfo.InvariantInfo) + " " : b.ToString("x", NumberFormatInfo.InvariantInfo) + " ");
			}
			return output.ToString();
		}

		private string ShortType(string p)
		{
			// We want the part of the string that is after the last period that is before
			// the first comma. This should get us the actual type name and avoid the
			// namespace and version information. We want this for the datagrid where
			// space is limited. We will show the whole type in the type text box

			// ex. myNamespace.mySubNamespace.myType, Version=0.0.0.0 -> myType
			string[] splitStrings = p.Split(new char[] { ',' })[0].Split(new char[] { '.' });
			return splitStrings[splitStrings.Length - 1];
		}
	}
}
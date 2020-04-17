//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) 2005 Microsoft Corporation.  All rights reserved.
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

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using System.Data;

namespace Microsoft.Samples.Windows.Forms.BindingNavigatorSample
{
	/// <summary>
	/// Summary description for form.
	/// </summary>
	public partial class BindingNavigatorSample : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		const string		FlagsPrefix = "Flags.";
		private Hashtable	flagsMapping = new Hashtable();

		public BindingNavigatorSample()
		{
			InitializeComponent();

			// Set the informational text
			SetInfoMessage(null);
		}

		private void BindingSourceSample_Load(object sender, EventArgs e)
		{
			Assembly	assembly = this.GetType().Assembly;

			// Fill Combo Box with images from the manifest
			string[]	resources = assembly.GetManifestResourceNames();
			int			pos;
			string		shortName;

			foreach (string resource in resources)
			{
				// Look for manifest resources that start with Flags
				// These should be the flag images we've embedded in the
				// Assembly.
				pos = resource.IndexOf(FlagsPrefix);
				if (pos >= 0)
				{
					// Get a short name (the filename of the embedded image)
					shortName = resource.Substring(pos + FlagsPrefix.Length);

					// Add to a hashtable to map shortName to the full resource name
					this.flagsMapping.Add(shortName, resource);

					// Add to the combo box
					// Note - not using data binding so we can use the ComboBox to sort.
					this.addComboBox.Items.Add(shortName);
				}
			}

			// Set the first item as the selected item
			this.addComboBox.SelectedIndex = 0;
		}

		private void SetInfoMessage(object source)
		{
			if (null == source)
			{
				// Default message
				this.info.Text = "This sample demonstrates a BindingNavigator bound to a BindingSource.  The BindingNavigator is a subclass of ToolStrip that contains a pre-populated set of buttons for navigating through data in a BindingSource.  The functionality behind these buttons is extensible.  In this sample, the New button behavior is overridden.  Click on the New button to add a row to the BindingSource.";
			}
			else if (this.bindingNavigatorMoveFirstItem == source)
			{
				this.info.Text = "Click on this Button to navigate to the first item in the BindingSource.  This calls BindingSource.MoveFirst().";
			}
			else if (this.bindingNavigatorMovePreviousItem == source)
			{
				this.info.Text = "Click on this Button to navigate to the previous item in the BindingSource.  This calls BindingSource.MovePrevious().";
			}
			else if (this.bindingNavigatorMoveNextItem == source)
			{
				this.info.Text = "Click on this Button to navigate to the next item in the BindingSource.  This calls BindingSource.MoveNext().";
			}
			else if (this.bindingNavigatorMoveLastItem == source)
			{
				this.info.Text = "Click on this Button to navigate to the last item in the BindingSource.  This calls BindingSource.MoveLast().";
			}
			else if (this.bindingNavigatorPositionItem == source)
			{
				this.info.Text = "This shows the BindingSource's current position.  This calls BindingSource.Position.";
			}
			else if (this.bindingNavigatorCountItem == source)
			{
				this.info.Text = "This shows the BindingSource's item Count.  This calls BindingSource.Count.";
			}
			else if (this.flagName == source)
			{
				this.info.Text = "This shows the value of the Name property for the current item in the BindingSource.  This Control is bound to the 'Flag.Name' property through the BindingSource.  A default message is displayed if there are no items in the BindingSource.";
			}
			else if (this.flagPicture == source)
			{
				this.info.Text = "This shows the value of the Image property for the current item in the BindingSource.  This Control is bound to the 'Flag.Image' property through the BindingSource.  Nothing is displayed if there are no items in the BindingSource.";
			}
			else if (this.addComboBox == source)
			{
				this.info.Text = "Shows a list of Flags.  Select a Flag and then select the Add button to create a 'Flag' instance and add it to the BindingSource.";
			}
			else if (this.flagsNavigator == source)
			{
				this.info.Text = "This is the BindingNavigator Control.  It provides a set of buttons for performing standard actions on the data in a BindingSource.";
			}
			else if (this.bindingNavigatorAddNewItem == source)
			{
				this.info.Text = "Creates and instance of the 'Flag' Type and adds it to the BindingSource.";
			}
		}

		private void Mouse_MouseEnter(object sender, EventArgs e)
		{
			SetInfoMessage(sender);
		}

		private void Mouse_MouseLeave(object sender, EventArgs e)
		{
			SetInfoMessage(null);
		}

		private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
		{
			Assembly	assembly = this.GetType().Assembly;
			string		imageName = this.addComboBox.SelectedItem as string;
			string		resource = this.flagsMapping[imageName] as string;
			
			// Get the image from the manifest
			Image image = Image.FromStream(assembly.GetManifestResourceStream(resource));

			// Create a Flag instance and add it to the BindingSource
			this.flagsBindingSource.Add(new Flag(imageName, image));

			// Set the position to the added item
			this.flagsBindingSource.Position = this.flagsBindingSource.Count - 1;

			// Remove from the ComboBox (don't allow adding the same item twice)
			this.addComboBox.Items.Remove(imageName);

			// Select the first item
			if (this.addComboBox.Items.Count > 0)
			{
				this.addComboBox.SelectedIndex = 0;
			}
			else
			{
				this.bindingNavigatorAddNewItem.Enabled = false;
			}
		}

        private void flagsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
	}
}


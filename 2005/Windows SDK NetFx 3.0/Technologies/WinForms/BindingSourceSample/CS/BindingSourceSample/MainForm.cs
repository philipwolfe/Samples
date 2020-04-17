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

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using System.Data;

namespace Microsoft.Samples.Windows.Forms.BindingSourceSample
{
    /// <summary>
    /// Summary description for form.
    /// </summary>
    public partial class MainForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        const string FlagsPrefix = "Flags.";
        private Hashtable flagsMapping = new Hashtable();

        public MainForm()
        {
            InitializeComponent();

            // Set Initial State of Buttons and Position Indicator
            SetButtonState();

            // Set the informational text
            SetInfoMessage(null);
        }

        private void SetButtonState()
        {
            // Sets the "enabled" state of the previous and back buttons
            // If the position is at the beginning then "previous" is greyed out.
            // If the position is at the end then "next" is greyed out.
            int count = this.flagsBindingSource.Count;
            int pos = this.flagsBindingSource.Position;

            this.movePrevious.Enabled = (pos > 0);
            this.moveNext.Enabled = (pos < (count - 1));

            // Set the position indicator
            // If there are no items in the list, then show -1
            if (this.flagsBindingSource.Position < 0)
            {
                this.positionIndicator.Text = this.flagsBindingSource.Position.ToString(CultureInfo.CurrentUICulture);
            }
            else
            {
                this.positionIndicator.Text = (this.flagsBindingSource.Position + 1).ToString(CultureInfo.CurrentUICulture) + " / " + this.flagsBindingSource.Count.ToString(CultureInfo.CurrentUICulture);
            }
        }

        private void flagsBindingSource_PositionChanged(object sender, EventArgs e)
        {
            // Set previous and next button state
            SetButtonState();
        }

        private void flagsBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            // Set previous and next button state
            SetButtonState();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Assembly assembly = this.GetType().Assembly;
            string imageName = this.flagsCombo.SelectedItem as string;
            string resource = this.flagsMapping[imageName] as string;

            // Get the image from the manifest
            Image image = Image.FromStream(assembly.GetManifestResourceStream(resource));

            // Create a Flag instance and add it to the BindingSource
            this.flagsBindingSource.Add(new Flag(imageName, image));

			// Set Position
			this.flagsBindingSource.Position = this.flagsBindingSource.Count - 1;

            // Remove from the ComboBox (don't allow adding the same item twice)
            this.flagsCombo.Items.Remove(imageName);

            // Select the first item
            if (this.flagsCombo.Items.Count > 0)
            {
                this.flagsCombo.SelectedIndex = 0;
            }
            else
            {
                this.addButton.Enabled = false;
            }
        }

        private void BindingSourceSample_Load(object sender, EventArgs e)
        {
            Assembly assembly = this.GetType().Assembly;

            // Fill Combo Box with images from the manifest
            string[] resources = assembly.GetManifestResourceNames();
            int pos;
            string shortName;

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
                    this.flagsCombo.Items.Add(shortName);
                }
            }

            // Set the first item as the selected item
			this.flagsCombo.SelectedIndex = 0;
        }

        private void SetInfoMessage(Control source)
        {
            if (null == source)
            {
                // Default message
                this.info.Text = "This sample demonstrates binding BindingSource to a Type.  At design time, the BindingSource is bound to the Flag type and the flagName and flagImage Controls are bound to Flag properties through the BindingSource.  Click on the Add button to create a Flag instance and add it to the BindingSource.  Click on the < and > buttons to use the BindingSource API to navigate through the BindingSource items.  The positionIndicator TextBox shows the position of the current BindingSource item as well as the BindingSource item count.";
            }
            else if (this.movePrevious == source)
            {
                this.info.Text = "Click on this Button to navigate to the previous item in the BindingSource.  This calls BindingSource.MovePrevious().";
            }
            else if (this.moveNext == source)
            {
                this.info.Text = "Click on this Button to navigate to the next item in the BindingSource.  This calls BindingSource.MoveNext().";
            }
            else if (this.positionIndicator == source)
            {
                this.info.Text = "This shows the BindingSource's current position and the BindingSource's item Count.  This calls BindingSource.Position and BindingSource.Count.";
            }
            else if (this.flagName == source)
            {
                this.info.Text = "This shows the value of the Name property for the current item in the BindingSource.  This Control is bound to the 'Flag.Name' property through the BindingSource.  A default message is displayed if there are no items in the BindingSource.";
            }
            else if (this.flagPicture == source)
            {
                this.info.Text = "This shows the value of the Image property for the current item in the BindingSource.  This Control is bound to the 'Flag.Image' property through the BindingSource.  Nothing is displayed if there are no items in the BindingSource.";
            }
            else if (this.flagsCombo == source)
            {
                this.info.Text = "Shows a list of Flags.  Select a Flag and then select the Add button to create a 'Flag' instance and add it to the BindingSource.";
            }
            else if (this.addButton == source)
            {
                this.info.Text = "Creates an instance of the 'Flag' Type and adds it to the BindingSource.";
            }
        }

        private void movePrevious_Click(object sender, EventArgs e)
        {
            // Move to (display) to the previous item in the list
            this.flagsBindingSource.MovePrevious();
        }

        private void moveNext_Click(object sender, EventArgs e)
        {
            // Move to (display) to the next item in the list
            this.flagsBindingSource.MoveNext();
        }

        private void Mouse_MouseEnter(object sender, EventArgs e)
        {
            SetInfoMessage(sender as Control);
        }

        private void Mouse_MouseLeave(object sender, EventArgs e)
        {
            SetInfoMessage(null);
        }
    }
}


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
using System.Windows.Forms;
using System.Data;
using System.Security.Permissions;
using System.Globalization;

namespace Microsoft.Samples.Windows.Forms.SplitContainer
{
    /// <summary>
    /// Summary description for form.
    /// </summary>
    public partial class Form1 : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            // This event will be fired every time the splitter is moved

            // The 'sender' parameter will contain the actual splitter control that raised the event
            // We need to cast it to a SplitContainer since it comes in as an 'object'
            System.Windows.Forms.SplitContainer splitter = (System.Windows.Forms.SplitContainer)sender;

            // Populate the 'SplitterDistance' text box with the current value of the SplitterDistance property
            // of the splitter control.
            this.SplitterDistance.Text = GetSplitterDistance(splitter);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // On FormLoad we want to initialize our text box controls to have the current values
            // of the respective SplitContainer properties (SplitterDistance, SplitterWidth and SplitterIncrement)
            InitializeTextBoxes();

            // Give the picture box an actual image to display
            this.pictureBox1.Image = Image.FromFile("..\\..\\Blue Hills.jpg");
            restorePanel2ToolStripMenuItem.Enabled = false;

        }
        private void InitializeTextBoxes()
        {
            // Set the text property of the respective text boxes to their corresponding SplitContainer property values
            this.SplitterDistance.Text = GetSplitterDistance(this.splitContainer1);
            this.SplitterWidth.Text = GetSplitterWidth(this.splitContainer1);
            this.SplitterIncrement.Text = GetSplitterIncrement(this.splitContainer1);
            this.Panel1MinSize.Text = GetPanel1MinSize(this.splitContainer1);
            this.Panel2MinSize.Text = GetPanel2MinSize(this.splitContainer1);
        }
        private String GetSplitterDistance(System.Windows.Forms.SplitContainer splitter)
        {
            // Grab the SplitterDistance property for the current splitter and convert it to text
            // (cause that's what the text box will need)
            return splitter.SplitterDistance.ToString(CultureInfo.CurrentUICulture);
        }

        private String GetSplitterWidth(System.Windows.Forms.SplitContainer splitter)
        {
            // Grab the SplitterWidth property for the current splitter and convert it to text
            // (cause that's what the text box will need)
            return splitter.SplitterWidth.ToString(CultureInfo.CurrentUICulture);
        }

        private String GetSplitterIncrement(System.Windows.Forms.SplitContainer splitter)
        {
            // Grab the SplitterIncrement property for the current splitter and convert it to text
            // (cause that's what the text box will need)
            return splitter.SplitterIncrement.ToString(CultureInfo.CurrentUICulture);
        }

        private String GetPanel1MinSize(System.Windows.Forms.SplitContainer splitter)
        {
            // Grab the Panel1MinSize property for the current splitter and convert it to text
            // (cause that's what the text box will need)
            return splitter.Panel1MinSize.ToString(CultureInfo.CurrentUICulture);
        }

        private String GetPanel2MinSize(System.Windows.Forms.SplitContainer splitter)
        {
            // Grab the Panel2MinSize property for the current splitter and convert it to text
            // (cause that's what the text box will need)
            return splitter.Panel2MinSize.ToString(CultureInfo.CurrentUICulture);
        }

        private void OrientationButton_Click(object sender, EventArgs e)
        {
            // This event fires every time the 'Orientation' button is clicked

            // The idea is that each time the button is clicked, the orientation of the SplitContainer
            // will toggle between 'Vertical' and 'Horizontal' orientation

            // The sender parameter is the button that was clicked.  We need to cast is to Button
            Button orientationButton = (Button)sender;

            // Decide what the orientation should be based upon the current values
            if (this.splitContainer1.Orientation == Orientation.Vertical)
            {
                // Set the actual SplitContainer orientation property
                this.splitContainer1.Orientation = Orientation.Horizontal;
                // Change the text of the button to reflect the toggle
                orientationButton.Text = "&Horizontal";
                this.splitContainer1.SplitterDistance = 150;
            }
            else
            {
                // Set the actual SplitContainer orientation property
                this.splitContainer1.Orientation = Orientation.Vertical;
                // Change the text of the button to reflect the toggle
                orientationButton.Text = "&Vertical";
            }
        }

        private void SplitterWidth_Validating(object sender, CancelEventArgs e)
        {
            // Make sure that there is an actual value in text box.  This is especially important since
            // as the user deletes characters in the text box this event will fire and when the last character
            // is deleted the event fires with no string in the text box which would result in us trying to set
            // the splitter width to a bogus value and we would cause a runtime exception to be thrown

            try
            {
                int tryValue = Int32.Parse(this.SplitterWidth.Text);
                if (tryValue > 0)
                    errorProvider1.SetError(this.SplitterWidth, "");
                else
                {
                    errorProvider1.SetError(this.SplitterWidth, "Invalid value for SplitterWidth, must be a valid integer greater than zero");
                    e.Cancel = true;
                }

            }
            catch (FormatException ex)
            {
                errorProvider1.SetError(SplitterWidth, "Invalid value for SplitterWidth, must be a valid integer greater than zero" + ex.Message.ToString());
                e.Cancel = true;
            }
        }

        private void SplitterWidth_Validated(object sender, EventArgs e)
        {
            // This event will fire when the user changes the Splitter Width

            // The sender parameter will be the text box that fired the event
            // We need to cast it to a TextBox type in order to use it as a TextBox
            TextBox splitterWidth = (TextBox)sender;

            // Need to convert the text to an integer
            this.splitContainer1.SplitterWidth = Convert.ToInt32(splitterWidth.Text, CultureInfo.CurrentUICulture);
        }

        private void SplitterIncrement_Validated(object sender, EventArgs e)
        {
            // This event will fire when the user changes the Splitter Width

            // The sender parameter will be the text box that fired the event
            // We need to cast it to a TextBox type in order to use it as a TextBox
            TextBox splitterIncrement = (TextBox)sender;

            // Need to convert the text to an integer
            this.splitContainer1.SplitterIncrement = Convert.ToInt32(splitterIncrement.Text, CultureInfo.CurrentUICulture);
        }

        private void SplitterIncrement_Validating(object sender, CancelEventArgs e)
        {
            // Make sure that there is an actual value in text box.  This is especially important since
            // as the user deletes characters in the text box this event will fire and when the last character
            // is deleted the event fires with no string in the text box which would result in us trying to set
            // the splitter width to a bogus value and we would cause a runtime exception to be thrown
            try
            {
                int tryValue = Int32.Parse(this.SplitterIncrement.Text);
                if (tryValue > 0)
                    errorProvider1.SetError(this.SplitterIncrement, "");
                else
                {
                    errorProvider1.SetError(this.SplitterIncrement, "Invalid value for SplitterIncrement, must be a valid integer greater than zero");
                    e.Cancel = true;
                }

            }
            catch (FormatException ex)
            {
                errorProvider1.SetError(SplitterIncrement, "Invalid value for SplitterIncrement, must be a valid integer greater than zero" + ex.Message.ToString());
                e.Cancel = true;
            }
        }

        private void Panel1MinSize_Validating(object sender, CancelEventArgs e)
        {
            // Make sure that there is an actual value in text box.  This is especially important since
            // as the user deletes characters in the text box this event will fire and when the last character
            // is deleted the event fires with no string in the text box which would result in us trying to set
            // the splitter width to a bogus value and we would cause a runtime exception to be thrown

            try
            {
                int tryValue = Int32.Parse(this.Panel1MinSize.Text);
                if (tryValue > 0)
                    errorProvider1.SetError(this.Panel1MinSize, "");
                else
                {
                    errorProvider1.SetError(this.Panel1MinSize, "Invalid value for Panel1MinSize, must be a valid integer greater than zero");
                    e.Cancel = true;
                }

            }
            catch (FormatException ex)
            {
                errorProvider1.SetError(Panel1MinSize, "Invalid value for Panel1MinSize, must be a valid integer greater than zero" + ex.Message.ToString());
                e.Cancel = true;
            }
        }

        private void Panel1MinSize_Validated(object sender, EventArgs e)
        {
            // This event will fire when the user changes Panel1MinSize

            // The sender parameter will be the text box that fired the event
            // We need to cast it to a TextBox type in order to use it as a TextBox
            TextBox panel1MinSize = (TextBox)sender;

            // Need to convert the text to an integer
            this.splitContainer1.Panel1MinSize = Convert.ToInt32(panel1MinSize.Text, CultureInfo.CurrentUICulture);
        }

        private void Panel2MinSize_Validating(object sender, CancelEventArgs e)
        {
            // Make sure that there is an actual value in text box.  This is especially important since
            // as the user deletes characters in the text box this event will fire and when the last character
            // is deleted the event fires with no string in the text box which would result in us trying to set
            // the splitter width to a bogus value and we would cause a runtime exception to be thrown

            try
            {
                int tryValue = Int32.Parse(this.Panel2MinSize.Text);
                if (tryValue > 0)
                    errorProvider1.SetError(this.Panel2MinSize, "");
                else
                {
                    errorProvider1.SetError(this.Panel2MinSize, "Invalid value for Panel2MinSize, must be a valid integer greater than zero");
                    e.Cancel = true;
                }

            }
            catch (FormatException ex)
            {
                errorProvider1.SetError(Panel2MinSize, "Invalid value for Panel2MinSize, must be a valid integer greater than zero" + ex.Message.ToString());
                e.Cancel = true;
            }
        }

        private void Panel2MinSize_Validated(object sender, EventArgs e)
        {
            // This event will fire when the user changes Panel2MinSize

            // The sender parameter will be the text box that fired the event
            // We need to cast it to a TextBox type in order to use it as a TextBox
            TextBox panel2MinSize = (TextBox)sender;

            // Need to convert the text to an integer
            this.splitContainer1.Panel2MinSize = Convert.ToInt32(panel2MinSize.Text, CultureInfo.CurrentUICulture);
        }

        private void Panel1Collapsed_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the Panel1Collapsed property based on the value of the check box
            this.splitContainer1.Panel1Collapsed = Panel1Collapsed.Checked;
        }

        private void Panel2Collapsed_CheckStateChanged(object sender, EventArgs e)
        {
            // Toggle the Panel2Collapsed property based on the value of the check box
            this.splitContainer1.Panel2Collapsed = Panel2Collapsed.Checked;

            if (this.splitContainer1.Panel2Collapsed)
                restorePanel2ToolStripMenuItem.Enabled = true;

        }

        private void restorePanel2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2Collapsed = false;
            this.Panel2Collapsed.Checked = false;
            this.restorePanel2ToolStripMenuItem.Enabled = false;
        }
    }
}
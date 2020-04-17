//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET SDK Code Samples.
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
//-----------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Microsoft.Samples.WinForms.TableLayoutPanelSample
{
	/// <summary>
	/// Summary description for form.
	/// </summary>
	public partial class formBrowser : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
        private Form pendingForm;

		public formBrowser()
		{
            Application.EnableVisualStyles();
            InitializeComponent();
		}

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonViewForm_Click(object sender, EventArgs e)
        {
            switch (comboSelectForm.SelectedIndex)
            {
                case 0:
                    pendingForm = new BasicDataEntry();
                    break;
                case 1:
                    pendingForm = new TwoPaneProp();
                    break;
                default:
                    pendingForm = new Form();
                    break;
            }
            
            // locate new form away from browser form
            pendingForm.Location = new Point(this.Location.X+this.Size.Width, this.Location.Y);
            pendingForm.Show();
        }

        private void formBrowser_Load(object sender, EventArgs e)
        {
            // Populate list of available forms - buggy currently
            //comboSelectForm.Items.Add(new BasicDataEntry());
            comboSelectForm.Items.Add("Basic Data Entry Form");
            comboSelectForm.Items.Add("Two-Paned Proportional Form");

            // init combobox to basic data entry form
            comboSelectForm.SelectedIndex = 0;
        }

        private void FormSelected(object sender, EventArgs e)
        {
            switch (comboSelectForm.SelectedIndex)
            {
                case 0:
                    pictureThumbnail.Image = Microsoft.Samples.WinForms.TableLayoutPanelSample.Resources.BasicDataEntry1;
                    textDescription.Text = "A simple data entry form, using the TableLayoutPanel to yield simple but robust resizing behavior.\r\n\r\n";
                    textDescription.Text += "A single TableLayoutPanel encompasses all controls except for the two Buttons at the bottom of the Form.\r\n\r\n" ;
                    break;
                case 1:
                    pictureThumbnail.Image = Microsoft.Samples.WinForms.TableLayoutPanelSample.Resources.TwoPaneProp;
                    textDescription.Text = "A basic two-pane form, supporting proportional resizing of the two main panes, plus two absolutely positioned buttons within a central column.";
                    break;
            }
        }
	}
}


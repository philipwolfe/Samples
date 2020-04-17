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
using System.Runtime.InteropServices;
using System.Data;
using System.IO;

namespace Microsoft.Samples.WinForms.ManagedWebBrowser
{
	/// <summary>
	/// Summary description for form.
	/// </summary>
	/// 
	[ComVisible(true)]
	public partial class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
        private FileStream fs;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

			// Navigate to our home page by default on startup
			webBrowser1.GoHome();
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			// This is the button handler for our HTML reader scenario
            			
			// Set up the properties for the OpenFile dialog.  Restrict to HTM and HTML files
            openFileDialog1.Filter = "HTML Files (*.html) | *.html|HTM Files (*.htm) | *.htm";

			// Prompt the user to choose an HTML file
			openFileDialog1.ShowDialog();

			// Poke the chosen filename into the TextBox on the form
			htmlFileName.Text = this.openFileDialog1.FileName;

            if (htmlFileName.Text != String.Empty)
            {
                // Open the file that the user selected
                this.fs = new FileStream(htmlFileName.Text, FileMode.Open);

                // Load the HTML file stream into the Web Browser control
                webBrowser1.DocumentStream = fs;
                openFileDialog1.Reset();
            }
        }

		private void backButton_Click(object sender, EventArgs e)
		{
			// Navigate the Web Browser control backward
			webBrowser1.GoBack();
		}

		private void forwardButton_Click(object sender, EventArgs e)
		{
			// Navigate the Web Browser control forward
			webBrowser1.GoForward();
		}

		private void stopButton_Click(object sender, EventArgs e)
		{
			// Send the stop command to the Web Browser control
			webBrowser1.Stop();
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			// Refresh the page currently loaded in the Web Browser control
			webBrowser1.Refresh();
		}

		private void homeButton_Click(object sender, EventArgs e)
		{
			// Navigate home
			webBrowser1.GoHome();
		}

		private void goButton_Click(object sender, EventArgs e)
		{
			// Navigate the Web Browser control to the URL indicated in the toolStripTextBox

            if (urlAddress.Text.Length != 0)
            {
                webBrowser1.Navigate(urlAddress.Text);
            }
		}

 		private void loadScriptButton_Click(object sender, EventArgs e)
		{
			// This is the handler for loading the script into the Web Browser control and allowing us to interact
			// between the script in the Browser control and this form class


			// Set the ObjectForScripting property of the Web Browser control to point to this form class
			// This will allow us to interact with methods in this form class via the window.external property 
			webBrowser1.ObjectForScripting = this;

			// Load the script into the Web Browser by setting the DocumentText property
			// Note that we will pass the userName value in the input box to the underlying form class method by hooking
			// the OnClick event and pointing to the Welcome() method via the window.external property
			webBrowser1.DocumentText = "<html><body>" + "Please enter your name:<br/>" + "<input type='text' name='Name'/><br/>" + "<a href='http://www.microsoft.com' " + "onClick='window.external.Welcome(Name.value)'>" + "Send input to method of Form class</a></body></html>";

		}

		public void Welcome(string userName)
		{
			// Simply echo out the name that the user typed in the input box of the HTML page
			if (System.Threading.Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft == true)
				MessageBox.Show("Hello " + userName, "Managed Web Browser Sample", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
			else
				MessageBox.Show("Hello " + userName, "Managed Web Browser Sample", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
			if (this.fs != null)
				this.fs.Close();
        }
	}
}


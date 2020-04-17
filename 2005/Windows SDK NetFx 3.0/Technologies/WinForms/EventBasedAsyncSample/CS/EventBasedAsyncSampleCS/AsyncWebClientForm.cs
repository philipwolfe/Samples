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
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

#endregion

namespace Microsoft.Samples.Windows.Forms.EventBasedAsync
{


    partial class AsyncWebClientForm : Form {

        /// The WebClient component used to download a file
        private WebClient myWebClient = new WebClient();

		/// Store full file name
		private string fullTargetFileName = "";

        public AsyncWebClientForm() {
            InitializeComponent();

            //Handle the DownloadFileCompleted and DownloadProgressChanged events
            myWebClient.DownloadFileCompleted += new AsyncCompletedEventHandler(myWebClient_DownloadFileCompleted);
            myWebClient.DownloadProgressChanged +=new DownloadProgressChangedEventHandler(myWebClient_DownloadProgressChanged);
}

        /// <summary>
        /// Handle the Click event on btnBrowse. 
        /// Allow the user to set the name of the file when it has been downloaded
        /// </summary>
        private void btnBrowse_Click(System.Object sender, System.EventArgs e) {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                txtToLocation.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handle the Click event on btnDownloadFile. 
        /// Start the async download of the text file pointed to by txtFromLocation - this can be 
        /// a file name or url. The file is downloaded to the name in txtToLocation
        /// </summary>
        private void btnDownloadFile_Click(System.Object sender, System.EventArgs e) {
            webClientOperationToolStripProgressBar.Value = 0;
            webClientOperationToolStripTextProgressPanel.Text = "";
            btnDownloadFile.Enabled = false;
            btnCancel.Enabled = true;
			fullTargetFileName = Path.GetFullPath(txtToLocation.Text);
            myWebClient.DownloadFileAsync(new Uri(txtFromLocation.Text), fullTargetFileName);
        }

        /// <summary>
        /// Handle the Click event on btnCancel.
        /// Cancel the async loading of the text file
        /// Note: It is possible that the load may have completed by the time cancel is processed
        ///       - you will need to take this into account in your applications
        /// </summary>
        private void btnCancel_Click(System.Object sender, System.EventArgs e) {
            myWebClient.CancelAsync();
			fullTargetFileName = "";
        }

        /// <summary>
        /// Handle the DownloadFileCompleted event. This event is raised when the WebClient component
        /// has finished async downloading the file.
        /// The AsyncCompletedEventArgs contains information about the async operation 
        /// - whether it was canceled, if there was an error and so on
        /// </summary>
        private void myWebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            btnCancel.Enabled = false;
            btnDownloadFile.Enabled = true;
            if (e.Error != null) {
                MessageBox.Show(e.Error.Message, "Async Web Client Sample", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else if ((e.Cancelled == true)) {
                MessageBox.Show("Download of file canceled", "Async Web Client Sample");
            } else {
                MessageBox.Show(String.Format("Download of file completed. File is located at: {0}", fullTargetFileName), "Async Web Client Sample");
            }
			fullTargetFileName = "";
        }

        /// <summary>
        /// Handle the ProgressChanged event. This event is raised during the async download 
        /// of the file. It can be used to give progress feedback to the user.
        /// The ProgressChangedEventArgs contains information about the progress of 
        /// the async operation - the percentage complete, the number of bytes downloaded and so on
        /// </summary>
		private void myWebClient_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
		{
            webClientOperationToolStripProgressBar.Value = e.ProgressPercentage;
            webClientOperationToolStripTextProgressPanel.Text = "Downloaded " + e.BytesReceived.ToString() + " bytes of " + e.TotalBytesToReceive.ToString();
        }

        /// <summary> 
        /// Utility method that generates a 24MB text file for the sample
        /// This should really be done asynchronously as well but to keep the sample
        /// simple we'll simply do it in line
        /// </summary>
        private void InstructionsLinkLabel_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
            using (new WaitCursorManager(this)) {
                using (StreamWriter sw = new StreamWriter("big.txt")) {
                    for (int i = 1; i <= 300000; i++) {
                        sw.Write(i);
                        sw.WriteLine(" this is a line of text in a big file that we are generating for our sample");
                    }
                }
            }
        }
    }
}




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

#endregion

namespace Microsoft.Samples.Windows.Forms.EventBasedAsync
{

    partial class AsyncWebServiceForm : Form {

        private SampleCodeForm sampleCodeForm = null;

        //Key used to identify the Web service call - see comments below for details
        private object webServiceCallKey = new object();

        public AsyncWebServiceForm() {
            InitializeComponent();
			txtWebServiceUrl.Text = Settings1.Default.SimpleWebService;
		}

        /// <summary>
        /// Handle the Form load event
        /// Sets the default selected item in the ComboBox of questions
        /// </summary>
        private void AsyncWebServiceForm_Load(object sender, System.EventArgs e) {
            cmbQuestion.SelectedIndex = 0;
        }


        /// <summary>
        /// Handle the Click event on btnAskTheQuestion. 
        /// Start the async Web service call using the Web service pointed to by txtWebServiceUrl
        /// </summary>
        private void btnAskTheQuestion_Click(System.Object sender, System.EventArgs e) {
            btnCancel.Enabled = true;
            btnAskTheQuestion.Enabled = false;
            txtAnswer.Text = "";
            simpleWebService1.Url = txtWebServiceUrl.Text;

            StartProgress("Calling Web Service..."); //See StartProgress below for an explanation of this method

            //Although our UI only supports one outstanding call at a time, the webservice supports 
            //multiple outstanding requests. We want to be able to cancel an outstanding request and the 
            //Web service requires that we identify the request to be cancelled using the userState 
            //parameter. Therefore we need to pass in a unique userState identifier to the webservice call 
            //so that we can pass the same identifier into CancelAsync (see below). 

            //Because we only support one outstanding call at a time we can re-use the same identifier however 
            //if we supported issuing multiple requests at once we would need to generate a unique identifier 
            //for each request.
            simpleWebService1.GetAnswerAsync(cmbQuestion.Text, webServiceCallKey);
        }

        /// <summary>
        /// Handle the Click event on btnCancel.
        /// Cancel the async call of the webservice
        /// Note: It is possible that the Web service may have completed by the time cancel is processed
        ///       - you will need to take this into account in your applications
        /// </summary>
        private void btnCancel_Click(System.Object sender, System.EventArgs e) {
            //More than one async request can be running at a time 
            //So pass in the key that identifies this operation
            //In our case we only have one operation running at a time so pass in the standard key
            simpleWebService1.CancelAsync(webServiceCallKey);
        }

        /// <summary>
        /// Handle the LoadCompleted event. This event is raised when the Web service has 
        /// finished async execution
        /// The AsyncCompletedEventArgs contains information about the async operation 
        /// - the result, whether it was canceled, if there was an error and so on
        /// </summary>
        private void simpleWebService1_GetAnswerCompleted(object sender, Microsoft.Samples.Windows.Forms.EventBasedAsync.SimpleWebServices.GetAnswerCompletedEventArgs e)
        {
            btnCancel.Enabled = false;
            btnAskTheQuestion.Enabled = true;
            StopProgress("Ready"); //See StartProgress below for an explanation of this method

            if (e.Cancelled == true) {
                MessageBox.Show("Web Service request canceled", "Async Web Service Sample");
            } else {

                //
                //Note: If the Web service returned an error e.Result will throw the exception associated with the error
                //
                //      You can also check for e.Error:
                //
                //           if (e.Error != null) {
                //           }
                //
				try
				{
					txtAnswer.Text = e.Result;
                    MessageBox.Show("Web Service request completed", "Async Web Service Sample");
				}
				catch (Exception ex)
				{
                    MessageBox.Show("Web Service request error:" + ex.Message, "Async Web Service Sample", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
            }
        }

        /// <summary> 
        /// Web Services do not return progress information and so we will simulate progress
        /// with a progress bar that slowly increments based on a timer
        /// This method sets the status text and starts the timer
        /// </summary>
        private void StartProgress(string progressText) {
            webServiceOperationToolStripProgressBar.Value = 0;
            webServiceOperationToolStripProgressBar.Visible = true;
            webServiceOperationToolStripTextProgressPanel.Text = progressText;
            simulateProgressTimer.Start();
        }

        /// <summary> 
        /// This method sets the status text and stops the timer by incrementing 
        /// it quickly to the end 
        /// </summary>
        private void StopProgress(string status) {
            simulateProgressTimer.Stop();
            int i;
            for (i = webServiceOperationToolStripProgressBar.Value; i <= webServiceOperationToolStripProgressBar.Maximum; i++) {
                webServiceOperationToolStripProgressBar.Value = i;
                System.Threading.Thread.Sleep(5);
            }
            webServiceOperationToolStripProgressBar.Visible = false;
            webServiceOperationToolStripTextProgressPanel.Text = status;
        }

        /// <summary> 
        /// The timer tick event - used to increment the progress bar
        /// </summary>
        private void SimulateProgressTimer_Tick(System.Object sender, System.EventArgs e) {
            if (webServiceOperationToolStripProgressBar.Value == webServiceOperationToolStripProgressBar.Maximum) {
                webServiceOperationToolStripProgressBar.Value = 0;
            }
            webServiceOperationToolStripProgressBar.Value += 1;
        }

        /// <summary> 
        /// Utility method that displays the source code for the Web service
        /// </summary>
        private void ViewWebServiceSourceLinkLabel_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
            if (Application.OpenForms["SampleCodeForm"] != null) {
                sampleCodeForm.SampleCodeRtf = Properties.Resources.SimpleWebServiceSourceCode;
                sampleCodeForm.BringToFront();
            } else {
                sampleCodeForm = new SampleCodeForm();
                sampleCodeForm.SampleCodeRtf = Properties.Resources.SimpleWebServiceSourceCode; 
                sampleCodeForm.Show();
            }
        }
    }
}

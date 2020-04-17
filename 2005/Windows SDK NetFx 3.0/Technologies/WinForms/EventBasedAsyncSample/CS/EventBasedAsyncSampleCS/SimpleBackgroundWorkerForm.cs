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

    // Note: In order to support Cancellation and Progress reporting the following
    //       properties have been set to true on BackgroundWorker1
    // 
    //           this.BackgroundWorker1.WorkerReportsProgress = true;
    //           this.BackgroundWorker1.WorkerSupportsCancellation = true;
    // 

    partial class SimpleBackgroundWorkerForm : Form {
        public SimpleBackgroundWorkerForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Handle the Form load event
        /// Sets the default value of the masked text box
        /// </summary>
        private void SimpleBackgroundWorkerForm_Load(System.Object sender, System.EventArgs e) {
            this.mtxtInput.Text = "2";
        }

        /// <summary>
        /// Handle the Click event on btnStart. 
        /// Start the background worker task passing mtxtInput as the input to the task
        /// via RunWorkerAsync
        /// </summary>
        private void btnStart_Click(System.Object sender, System.EventArgs e) {
            btnCancel.Enabled = true;
            btnStart.Enabled = false;
            operationToolStripProgressBar.Value = 0;
            operationToolStripProgressBar.Visible = true;
            operationToolStripTextProgressPanel.Text = "Calculating result";

			try
			{
				int inputNumber = Int32.Parse(this.mtxtInput.Text);
				backgroundWorker1.RunWorkerAsync(inputNumber);
			}
			catch (FormatException myE)
			{
                MessageBox.Show("You must enter only integers in the MaskedTextBox" + myE.Message.ToString(), "Async BackgroundWorker Sample");
				btnStart.Enabled = true;
			}
        }

        /// <summary>
        /// Handle the Click event on btnCancel.
        /// Cancel the background worker task
        /// 
        /// Note: It is possible that the task may have completed by the time cancel is processed
        ///       - you will need to take this into account in your applications
        /// 
        /// Note: This is only supported if 
        /// 
        ///       (1) you set WorkerSupportsCancellation = true 
        ///       (2) you respond to CancellationPending in the DoWork event (see below)
        /// 
        /// </summary>
        private void btnCancel_Click(System.Object sender, System.EventArgs e) {
            backgroundWorker1.CancelAsync();
        }

        /// <summary>
        /// Handle the DoWork event on the BackgroundWorker.
        /// 
        /// Note well: This event runs on a seperate thread not on the UI thread
        ///            You put your long running task in this event handler and it is 
        ///            invoked via RunWorkerAsync.
        /// 
        /// As this event runs on a background thread you should not directly access
        /// controls in this event.
        /// 
        /// You can call ReportProgress to raise the progress event on the UI thread 
        /// You can set the Result which is returned to the UI thread in the Completed event 
        /// You can use Control.Invoke/Control.BeginInvoke to set the state of controls on the UI thread
        /// 
        /// When this event handler exits the Completed event is raised on the UI thread
        /// 
        /// </summary>
        private void backgroundWorker1_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e) {
			// This method will run on a thread other than the UI thread.
			// Be sure not to manipulate any Windows Forms controls created
			// on the UI thread from this method.

        //Get the input argument from the event args
		int inputNumber = Convert.ToInt32(e.Argument);

        //Throw an exception if input is greater than 1000
        //This causes the Completed event to be raised with e.Error containing
        //this exception
        if (inputNumber > 1000) 
			throw new ArgumentException("We only support numbers up to 1000");

        //Do the operation - simply double the number
		int result = inputNumber * 2;

        //Now simulate a long running task by looping for 2000 milliseconds
        //If CancelAsync is called CancellationPending is true. Look for this and 
        //terminate the task if CancellationPending is true
		int i = 1;
        while (i < 100 &&  !backgroundWorker1.CancellationPending)
		{

            //Sleep for 5 milliseconds
            System.Threading.Thread.Sleep(20);

            //Report progress back to the UI thread via ReportProgress
            backgroundWorker1.ReportProgress(i);

            i += 1;
		}

        //If the user canceled the task then set e.Cancel to true
        //so that in the Completed we can detect that the cancellation
        //suceeded
        if (backgroundWorker1.CancellationPending) 
            e.Cancel = true;

        //Set the result into the event args to be picked up by Completed event
		e.Result = result;

		}

        /// <summary>
        /// Handle the LoadCompleted event. This event is raised when the BackgroundWorker DoWork event 
        /// handler has finished executing
        /// The RunWorkerCompletedEventArgs contains information about the task
        /// - the result, whether it was canceled, if there was an error and so on
        /// </summary>
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            btnCancel.Enabled = false;
            btnStart.Enabled = true;
            operationToolStripProgressBar.Value = 0; 
            operationToolStripProgressBar.Visible = false;
            operationToolStripTextProgressPanel.Text = "Ready";

            if (e.Cancelled == true) {
                MessageBox.Show("Background task canceled", "Async BackgroundWorker Sample");
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
					txtOutput.Text = e.Result.ToString();
                    MessageBox.Show("Background task completed", "Async BackgroundWorker Sample");
				}
				catch (Exception ex)
				{
                    MessageBox.Show(ex.Message, "Async BackgroundWorker Sample", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
            }
        }

        /// <summary>
        /// Handle the ProgressChanged event. This event is raised during the execution of 
        /// DoWork is ReportProgress is called. It can be used to give progress feedback to the 
        /// user.
        /// 
        /// The ProgressChangedEventArgs contains the percentage complete as reported by ReportProgress.
        /// 
        /// Note: This is only supported if you set WorkerReportsProgress = true 
        /// 
        /// </summary>
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e) {
            operationToolStripProgressBar.Value = e.ProgressPercentage;
        }

    }
}


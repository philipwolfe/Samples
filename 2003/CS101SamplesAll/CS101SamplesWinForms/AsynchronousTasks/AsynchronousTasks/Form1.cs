using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AsynchronousTasks
{
    public partial class MainForm : Form
    {
        private System.ComponentModel.BackgroundWorker backgroundCalculator;

        public MainForm()
        {
            InitializeComponent();

            // Prepare the background worker for asynchronous prime number calculation
            backgroundCalculator = new BackgroundWorker();
            // Specify that the background worker provides progress notifications
            backgroundCalculator.WorkerReportsProgress = true;
            // Specify that the background worker supports cancellation
            backgroundCalculator.WorkerSupportsCancellation = true;
            // The DoWork event handler is the main work function of the background thread
            backgroundCalculator.DoWork += new DoWorkEventHandler(backgroundCalculator_DoWork);
            // Specify the function to use to handle progress notifications
            backgroundCalculator.ProgressChanged += new ProgressChangedEventHandler(backgroundCalculator_ProgressChanged);
            // Specify the function to run when the background worker finishes
            // There are three conditions possible that should be handled in this function:
            // 1. The work completed successfully
            // 2. The work aborted with errors
            // 3. The user cancelled the process
            backgroundCalculator.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundCalculator_RunWorkerCompleted);

            updateStatus(String.Empty);

        }

    // This region implements calculating primes in a synchronous fashion
    #region Synchronous calculation

        // Synchronously calculate the next prime number, 
        // starting with a specified number.
        private int getNextPrimeSync(int start)
        {
            int percentComplete = 0;

            start++;
            while (!isPrime(start))
            {
                // start was not prime.  Try next number higher.
                start++;

                // Report progress
                percentComplete++;
                // With prime number calculation, there is no way to determine
                // how far along you are, so simply move the progress bar
                // and reset as needed
                updateProgress(percentComplete % 100);
            }
            return start;
        }

        private void nextPrimeButton_Click(object sender, EventArgs e)
        {
            enableCalcButtons(false);
            updateStatus("Calculating...");

			int start;
			Int32.TryParse(textBoxPrime.Text, out start );

			if (start == 0)
			{
				reportError("The number must be a valid integer");
			}
			else
			{
				try
				{
					int prime = getNextPrimeSync(start);
					reportPrime(prime);
				}
				catch (ApplicationException err)
				{
					reportError(err);
				}
				calcProgress.Value = 0;
			}
            enableCalcButtons(true);
        }

    #endregion

    // This region implements calculating primes in an asynchronous fashion
    #region Asynchronous calculation

        // The main worker function for calculating the next prime number
        // It is identical to the synchronous version, except that 
        // it checks for user cancellation, 
        // and it reports progress using the BackgroundWorker.ReportProgress delegate.
        private int getNextPrimeAsync(int start, BackgroundWorker worker, DoWorkEventArgs e)
        {
            int percentComplete = 0;

            start++;
            while (!isPrime(start))
            {
                // Check for cancellation
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // start was not prime.  Try next number higher.
                    start++;

                    // Report progress
                    percentComplete++;
                    // With prime number calculation, there is no way to determine
                    // how far along you are, so simply move the progress bar
                    // and reset as needed
                    worker.ReportProgress(percentComplete % 100);
                }
            }
            return start;
        }

        void backgroundCalculator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                updateStatus("Cancelled.");
            }
            else if (e.Error != null)
            {
                reportError(e.Error);
            }
            else
            {
                reportPrime((int)e.Result);
            }
            calcProgress.Value = 0;
            // re-enable the buttons and the prime textbox, disable "Cancel"
            enableCalcButtons(true);
            cancelButton.Enabled = false;
        }

        void backgroundCalculator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            updateProgress(e.ProgressPercentage);
        }

        // The DoWork method runs on another thread, and hence
        // cannot access form elements generated on the UI
        // thread.  Attempting to access such UI elements will
        // throw an exception.
        void backgroundCalculator_DoWork(object sender, DoWorkEventArgs e)
        {
            int start = (int) e.Argument;
            e.Result = getNextPrimeAsync(start, (BackgroundWorker)sender, e);
        }

        private void nextPrimeAsyncButton_Click(object sender, EventArgs e)
        {
            enableCalcButtons(false);
            // only enable the "Cancel" button during async
            cancelButton.Enabled = true;
            updateStatus("Calculating...");

			int start;
			Int32.TryParse(textBoxPrime.Text, out start);

			if (start == 0)
			{
				reportError("The number must be a valid integer");
			}
			else
			{
				// Kick off the background worker process
				backgroundCalculator.RunWorkerAsync(int.Parse(textBoxPrime.Text));
			}
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (backgroundCalculator.IsBusy)
            {
                updateStatus("Cancelling...");
                backgroundCalculator.CancelAsync();
            }
        }


    #endregion
    
    // User Interface feedback
    #region User Feedback
        
        // Update the Status label
        private void updateStatus(string status)
        {
            calcStatus.Text = status;
        }

        // Indicate progress using progress bar
        private void updateProgress(int percentComplete)
        {
            calcProgress.Value = percentComplete;
        }

        // Display the prime number
        private void reportPrime(int prime)
        {
            textBoxPrime.Text = prime.ToString();
            updateStatus("Done!");
            // re-enable the buttons and the prime textbox
        }

        // Report an error
        private void reportError(Exception e)
        {
            updateStatus("Error!");
			MessageBox.Show("The following error occurred: \r\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

		private void reportError(string message)
		{
			updateStatus("Error!");
			MessageBox.Show("The following error occurred: \r\n" + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

        // disable or enable the calculate buttons and textbox during and after a calculation, respectively
        private void enableCalcButtons(bool bEnable)
        {
            nextPrimeAsyncButton.Enabled = bEnable;
            nextPrimeButton.Enabled = bEnable;
            textBoxPrime.Enabled = bEnable;            
        }
    #endregion


        // Tries dividing by successively higher numbers 
        // to check for primeness
        private bool isPrime(int candidate)
        {
            bool retVal = true;
            
            // It is more efficient to calculate using increasing numbers,
            // but using decreasing numbers allows for a better demonstration
            // of BackgroundWorkder cancellation.
            //for (int i = 2; i < candidate / 2; i++)
            for (int i = candidate / 2 + 1; i > 1; i--)
            {
                if (candidate % i == 0)
                {
                    retVal = false;
                    break;
                }
            }
            return retVal;
        }
    }
}
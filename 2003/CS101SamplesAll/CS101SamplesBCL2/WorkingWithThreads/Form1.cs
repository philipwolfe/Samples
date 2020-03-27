using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WorkingWithThreads {
    public partial class Form1 : Form {

        #region Declarations

        private string cr = Environment.NewLine;
        private int foregroundLoops = 0;
        private int backgroundLoops = 0;
        private int numberToDouble = 0;
        private int timesToDouble = 0;

        // The AutoResetEvent class is used to notify a thread that an event
        // has occurred. This one is used to indicate that the user has chosen 
        // to cancel the current operation.
        AutoResetEvent haltProcessing = new AutoResetEvent(false);

        // These are delegates for calling back into the user interface. The first 
        // line declares a delegate type, along with the parameters it will expect, 
        // which must match the parameters of the procedure it will eventually point 
        // to. The second line declares a field, that will later become an instance 
        // of the delegate (see the Form's constructor). Once a delegate type has 
        // been declared, you can create multiple instances of that type.
        delegate void BooleanCallback(bool enable); // delegate type
        BooleanCallback handleButtonsDelegate;      // delegate field

        delegate void StringCallback(TextBox tb, string msg);
        StringCallback updateResultsDelegate;

        #endregion

        #region Constructor

        public Form1() {
            InitializeComponent();
            // Instantiate delegates for calling back into the user interface. 
            // Each delegate points to a specific procedure it will invoke.
            handleButtonsDelegate = new BooleanCallback(HandleButtons);
            updateResultsDelegate = new StringCallback(UpdateResults);
        }

        #endregion

        #region Event Procedures

        private void Form1_Load(object sender, EventArgs e) {
            HandleButtons(true);
            foregroundLoopsComboBox.SelectedIndex = 1;
            backgroundLoopsComboBox.SelectedIndex = 1;
            numberToDoubleComboBox.SelectedIndex = 0;
            timesToDoubleComboBox.SelectedIndex = 1;
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        #endregion

        #region Basic Threading

        // This is the procedure that will be invoked on the background thread.
        private void BackgroundProcedure(object numLoops) {
            string cr = Environment.NewLine;

            // Code in a background thread has no direct access to the
            // user interface, but the UpdateResults method is written
            // to handle cross-thread communication.
            UpdateResults(resultsTextBoxBackground, "Background processing beginning" + cr);

            int howManyTimes = (int)numLoops;
            for (int i = 1; i <= howManyTimes; i++) {
                // Simulate work being done.
                Application.DoEvents();

                // Wait one second to see if the user chooses to cancel.
                if (haltProcessing.WaitOne(1000, false)) {
                    break;
                }
                UpdateResults(resultsTextBoxBackground, "Background processing " + i + cr);
            }
            UpdateResults(resultsTextBoxBackground, "Background processing complete " + cr);
            HandleButtons(true);
        }

        private void beginButton_Click(object sender, EventArgs e) {
            clearResultsButton.Enabled = false;

            // Main thread processing prior to activating background processing.
            UpdateResults(resultsTextBoxMain, "Main processing beginning" + cr);
            for (int i = 1; i <= foregroundLoops; i++) {
                UpdateResults(resultsTextBoxMain, "Main processing " + i + cr);
                DoNothing(1);
                Application.DoEvents();
            }
            HandleButtons(false);

            // Call the background procedure on a new thread from the application's 
            // thread pool. Using the thread pool makes handling of the thread far 
            // easier than if you instantiated a thread of your own.
            WaitCallback async = new WaitCallback(BackgroundProcedure);
            ThreadPool.QueueUserWorkItem(async, backgroundLoops);

            // Main thread processing after the background thread has been activated. 
            // At this point, both threads are operating simultaneously, as you will 
            // note in the results text boxes. If you need your main thread to pause 
            // and wait for the background thread to complete, you will need to create 
            // your own thread, rather than using the thread pool. 
            UpdateResults(resultsTextBoxMain, cr + "Further main processing beginning" + cr);
            for (int i = 1; i <= foregroundLoops; i++) {
                UpdateResults(resultsTextBoxMain, "Further main processing " + i + cr);
                DoNothing(1);
                Application.DoEvents();
            }
            UpdateResults(resultsTextBoxMain, cr + "Main processing complete" + cr);
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            // Set the AutoResetEvent, notifying the thread in question.
            haltProcessing.Set();
            HandleButtons(false);
        }

        private void clearResultsButton_Click(object sender, EventArgs e) {
            resultsTextBoxMain.Clear();
            resultsTextBoxBackground.Clear();
        }

        private void HandleButtons(bool enable) {
            // If HandleButtons is called from a thread other than the main thread, 
            // InvokeRequired will be true. HandleButtons will then call itself via 
            // the handleButtonsDelegate delegate, using the BeginInvoke method, and 
            // passing an object array containing parameters.
            if (InvokeRequired) {
                BeginInvoke(handleButtonsDelegate, new Object[] { enable });
                return;
            }
            beginButton.Enabled = enable;
            clearResultsButton.Enabled = enable;
            cancelButton.Enabled = !enable;
        }

        private void UpdateResults(TextBox tb, string message) {
            // UpdateResults uses the same principle as HandleButtons, above. If 
            // it is called from the main thread, InvokeRequired will be false, 
            // and processing will continue.
            if (InvokeRequired) {
                BeginInvoke(updateResultsDelegate, new Object[] { tb, message });
                return;
            }
            tb.Text += message;
        }

        // A procedure for simulating processing.
        private void DoNothing(double howLong) {
            DateTime stopTime = DateTime.Now.AddSeconds(howLong);
            do {
                Application.DoEvents();
            } while (DateTime.Now < stopTime);
        }

        private void foregroundLoopsComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            foregroundLoops = Convert.ToInt32(foregroundLoopsComboBox.SelectedItem);
        }

        private void backgroundLoopsComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            backgroundLoops = Convert.ToInt32(backgroundLoopsComboBox.SelectedItem);
        }

        #endregion

        #region BackgroundWorker

        // The procedure to be executed on the background thread. It accepts a 
        // number, then doubles it repeatedly.
        //
        // As this procedure progresses, it is able to update the user interface, 
        // because it is being passed a reference to the BackgroundWorker objcet, 
        // which has a ProgressChanged event procedure that runs on the main thread. 
        //
        // It also receives a reference to the DoWorkEventArgs object from the 
        // BackgroundWorker's DoWork event procedure, so it can be canceled at any 
        // time.
        private int BackgroundProcedureBGW(object numberToCompute, object timesToCompute, BackgroundWorker bgworker, DoWorkEventArgs e) {
            int answer = Convert.ToInt32(numberToCompute);

            int numLoops = Convert.ToInt32(timesToCompute);
            for (int i = 1; i <= numLoops; i++) {

                // Simulate work being done.
                Thread.Sleep(500);

                // This is how the BackgroundWorker component lets you report 
                // progress to the main thread.
                int progress = Convert.ToInt32((float)i / (float)numLoops * 100);
                bgworker.ReportProgress(progress);

                // Double the number.
                answer *= 2;

                // Check to see if the user has cancelled the background task.
                if (bgworker.CancellationPending) {
                    e.Cancel = true;
                    break;
                }
            }
            return answer;
        }

        private void beginButtonBGW_Click(object sender, EventArgs e) {
            resultsTextBoxBGW.Text = "Processing started" + cr + cr;

            // Start the background process, passing it an object containing an array of numbers.
            backgroundWorker1.RunWorkerAsync(new int[] { numberToDouble, timesToDouble });
            cancelButtonBGW.Enabled = true;
        }

        // The BackgroundWorker object does its work in this procedure.
        // Include here any code you want to run in the background.
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            // Get a Reference to the BackgroundWorker object.
            BackgroundWorker bgw = (BackgroundWorker)sender;

            // Invoke the procedure for doing the calculation needed.
            // The result will be stored in e.Result, and will be available to the 
            // RunWorkerCompleted event procedure. 
            //
            // e.Argument contains the object parameter passed to this procedure. 
            // In this case the object contains an array of numbers. The object must 
            // be cast to an array, then the elements extracted, to be passed to 
            // the background procedure.

            int[] args = (int[])e.Argument;
            e.Result = BackgroundProcedureBGW(args[0], args[1], bgw, e);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            // Update the user interface.
            resultsTextBoxBGW.Text += e.ProgressPercentage + "% progress" + cr;
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                resultsTextBoxBGW.Text += cr + "Processing aborted" + cr;
            }
            else {
                resultsTextBoxBGW.Text += cr + "Processing completed" + cr;
                exponentResultTextBox.Text = Convert.ToInt32(e.Result).ToString();
            }
        }

        private void cancelButtonBGW_Click(object sender, EventArgs e) {
            backgroundWorker1.CancelAsync();
            cancelButtonBGW.Enabled = false;
        }

        private void clearResultsBGW_Click(object sender, EventArgs e) {
            resultsTextBoxBGW.Clear();
            exponentResultTextBox.Clear();
            progressBar1.Value = 0;
        }

        private void numberForExponentComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            numberToDouble = Convert.ToInt32(numberToDoubleComboBox.SelectedItem);
        }

        private void timesToDoubleComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            timesToDouble = Convert.ToInt32(timesToDoubleComboBox.SelectedItem);
        }

        #endregion

    }
}

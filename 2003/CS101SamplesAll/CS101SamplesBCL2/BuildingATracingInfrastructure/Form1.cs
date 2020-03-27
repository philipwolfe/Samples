using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

// System.Diagnostics contains the Trace and Debug classes.
using System.Diagnostics;

namespace BuildingATracingInfrastructure {
    public partial class Form1 : Form {

        #region Declarations

        // Trace file location.
        private string traceFile = Path.GetFullPath(@"..\..\TraceData\TraceLog.txt");

        #endregion

        #region Constructor

        public Form1() {
            InitializeComponent();
        }

        #endregion

        #region Event Procedures

        private void Form1_Load(object sender, EventArgs e) {
            serverNamecomboBox.SelectedIndex = 0;
        }

        private void serverNamecomboBox_SelectedIndexChanged(object sender, EventArgs e) {
            databaseButton.Enabled = serverNamecomboBox.Text.Trim().Length > 0;
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        #endregion

        #region Database Procedures

        private void databaseButton_Click(object sender, EventArgs e) {
            // Use server name to connect.
            ConnectToDatabase(serverNamecomboBox.Text);
        }

        private void ConnectToDatabase(string serverName) {
            try {
                // Try to access a database server. The server may be inaccessible because 
                // the name was changed, or the server is down.
                //
                // In this demo, access to the "AvailableServer" succeeds, but access to 
                // "UnavailableServer" does not.
                //
                // If you have SQL Server installed, you can try uncommenting the 
                // lines below for a true test.
                //
                //SqlConnection cn = new SqlConnection();
                //cn.ConnectionString =
                //    "Data Source=" + serverName + ";" +
                //    "Integrated Security=true;" +
                //    "Initial Catalog=Northwind";
                //cn.Open();

                // Throw an exception if the choice is "UnavailableServer"
                if (serverName == "UnavailableServer") {
                    throw new DataException("Could not connect to the database");
                }

                ShowInfoMessage("Database access succeeded.");
            }
            catch (Exception ex) {
                // Instantiate a boolean switch, and process trace statements only 
                // if the main Application-Level switch in web.config is on.
                BooleanSwitch appSwitch = new BooleanSwitch("ApplicationTracingSwitch",
                    "Application Trace setting");

                if (appSwitch.Enabled) {
                    // Create an EventLog TraceListener and add it to the 
                    // Trace.Listeners collection.
                    EventLogTraceListener eltl = new EventLogTraceListener("TracingInfrastructureSample");
                    Trace.Listeners.Add(eltl);

                    // Initialize a TraceSwitch, referencing the switch configured
                    // in the App.config file. The application will read that switch's
                    // settings and act accordingly.
                    //
                    // You can take any action you think is necessary for each trace level. It's
                    // entirely in your hands as to how much data to emit to the trace listeners.
                    TraceSwitch dataSwitch = new TraceSwitch("DataAccessSwitch",
                        "Data access tracing");

                    switch (dataSwitch.Level) {
                        case TraceLevel.Off:
                            break;
                        case TraceLevel.Error:
                        case TraceLevel.Warning:
                            // The message below will be written to all Listeners
                            // currently in the Trace.Listeners collection. Note that
                            // Trace has a Write method which does not include a new
                            // line at the end, WriteIf and WriteLineIf methods that
                            // write only if a condition is true, an Assert method that
                            // writes if a condition is false, and a Fail method that
                            // lets you write both an error message and a more detailed
                            // message.
                            //
                            Trace.WriteLine("Data Access Error: " + ex.Message);
                            break;
                        case TraceLevel.Info:
                            Trace.WriteLine("Data Access Error: " + ex.StackTrace);
                            break;
                        case TraceLevel.Verbose:
                            Trace.WriteLine("Data Access Error: " + ex.ToString());
                            break;
                    }
                    // If you don't want other trace messages written to the Event Log, 
                    // remove this listener from the Listeners collection.
                    Trace.Listeners.Remove(eltl);
                }

                // Now that the tracing has been recorded, handle the error
                // appropriately with a message box to the user, or however
                // you choose.
                ShowErrorMessage("Problem accessing database.");
            }
        }

        #endregion

        #region Long Process Procedures

        private void longProcessButton_Click(object sender, EventArgs e) {
            // Get execution time for long running process.
            int executionTime = GetNumberFromTextBox(longProcessDelayTextBox.Text);

            if (executionTime < 1) {
                return;
            }

            // Execute the long process.
            this.Cursor = Cursors.WaitCursor;
            RunLongProcess(executionTime);
            this.Cursor = Cursors.Default;
        }

        private void RunLongProcess(int executionTime) {
            // Simulate running a long process.
            // Delay for as many seconds as indicated.
            Thread.Sleep(executionTime * 1000);

            if (executionTime < 4) {
                ShowInfoMessage("Process completed.");
            }
            else {
                ShowErrorMessage("Process timed out.");

                // Instantiate a boolean switch.
                BooleanSwitch appSwitch = new BooleanSwitch("ApplicationTracingSwitch",
                    "Application Trace setting");

                // Process trace statements only if the main Application-Level switch is on.
                if (appSwitch.Enabled) {

                    // Add a Trace Listener that's directed to a file.
                    // When a trace listener is added, Trace message are written to it
                    // as well as to all the other listeners in the Listeners collection.
                    StreamWriter traceWriter = new StreamWriter(traceFile, true);
                    TextWriterTraceListener twtl = new TextWriterTraceListener(traceWriter);
                    Trace.Listeners.Add(twtl);

                    // This trace message will be written both to the output window 
                    // (if you're debugging) and to the text file.
                    Trace.WriteLine("Process Error", "The process has timed out. " +
                        "Please investigate possible causes for process delay.");

                    // You can write trace information to a single listener by using 
                    // one of its Write methods. For example, when writing to a text 
                    // file, you may want to record the date and time of the error. 
                    //
                    // This would not be necessary with the Event Log, for example, 
                    // since it already records such information.
                    //
                    // The message below is written only to the text file.
                    twtl.WriteLine(DateTime.Now);

                    // Flush the output buffer, forcing any remaining data to be written.
                    Trace.Flush();

                    // When a listener is no longer needed, you can remove it from
                    // the collection. Remember to close the listener first so it will 
                    // release any non-memory resources, such as file handles.
                    twtl.Close();
                    Trace.Listeners.Remove(twtl);
                }
            }
        }

        #endregion

        #region Web Service Procedures

        private void webServiceButton_Click(object sender, EventArgs e) {
            // Get delay time for simulating slow web server response.
            int delayTime = GetNumberFromTextBox(webServiceDelayTextBox.Text);

            if (delayTime < 1) {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            AccessWebService(delayTime);
            this.Cursor = Cursors.Default;
        }

        private void AccessWebService(int delayLength) {

            WebServiceSimulator dws = new WebServiceSimulator();
            string employees = dws.GetEmployeeNames(delayLength * 1000);

            if (employees != "Error") {
                ShowInfoMessage(String.Format("Employees successfully retrieved.{0}{0}{1}",
                        Environment.NewLine, employees));
            }
            else {
                // Check app.config to see if the switch is enabled.
                BooleanSwitch wsSwitch = new BooleanSwitch("WebServiceSwitch",
                    "Web service access");

                if (wsSwitch.Enabled) {
                    // Create an EventLog TraceListener, and set a custom Event Log
                    // source for it.
                    EventLogTraceListener eltl = new EventLogTraceListener("TracingInfrastructureSample");
                    Trace.Listeners.Add(eltl);

                    Trace.WriteLine("Problem accessing web service");

                    // Remove this listener so it won't be used for other
                    // trace messages.
                    Trace.Listeners.Remove(eltl);
                }

                // If you have a simple, one-line message to write you can use the 
                // WriteLineIf method, like this:
                //
                // Trace.WriteLineIf(wsSwitch.Enabled, "Problem accessing web service");
                //
                // In this case, the second argument, "Problem..." is a simple
                // string, but it could easily have been an expression. WriteLineIf
                // always evaluates both arguments even if the first is false, so your
                // code would have to ensure that the expression is valid and
                // resolvable.
                //
                // The bottom line: You'll get better performance with a simple "if" 
                // statement. It also lets you handle a situation like the one above, 
                // where multiple trace statements depend on the "if" condition.

                ShowErrorMessage("Problem accessing web service");
            }
        }

        #endregion

        #region Utility Functions

        private int GetNumberFromTextBox(string timeString) {
            int delayTime = 0;
            try {
                delayTime = Convert.ToInt32(timeString);

                if (delayTime < 1) {
                    ShowErrorMessage("Positive numbers only.");
                }
                return delayTime;
            }
            catch (Exception ex) {
                ShowErrorMessage(ex.Message);
                return 0;
            }
        }

        private void ShowErrorMessage(string msg) {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowInfoMessage(string msg) {
            MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

    }
}

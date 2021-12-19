//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
//------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.Cs.ThreadMarshal {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;
    using System.Threading;


    public class ThreadMarshal : System.WinForms.Form {
        private System.ComponentModel.Container components;
        private System.WinForms.Button button1;
        private System.WinForms.Button button2;
        private System.WinForms.ProgressBar progressBar1;

        private Thread timerThread;

        public ThreadMarshal() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();

        }

        //This function is executed on a background thread - it marshalls calls to 
        //update the UI back to the foreground thread
        public void ThreadProc() {
            
            try {
                MethodInvoker mi = new MethodInvoker(this.UpdateProgress);
                while (true) {       
                    //Call BeginInvoke on the Form
                    this.BeginInvoke(mi);
                    Thread.Sleep(500) ;
                }
            }
            //Thrown when the thread is interupted by the main thread - exiting the loop
            catch (ThreadInterruptedException) {
                //Simply exit....
            }
            catch (Exception) {
            }
        }

        //This function is called from the background thread
        private void UpdateProgress() {

            //Reset to start if required
            if (progressBar1.Value == progressBar1.Maximum) {
                progressBar1.Value = progressBar1.Minimum ;
            }

            progressBar1.PerformStep() ;
        }

        //Start the background thread to update the progress bar
        private void button1_Click(object sender, System.EventArgs e) {
            timerThread = new Thread(new ThreadStart(ThreadProc));
            timerThread.IsBackground = true;
            timerThread.Start();
        }

        //Stop the background thread to update the progress bar
        private void button2_Click(object sender, System.EventArgs e) {
            if (timerThread != null) {
                timerThread.Interrupt();
                timerThread = null;
            }
        }


        public override void Dispose() {
            if (timerThread != null) {
                timerThread.Interrupt();
                timerThread = null;
            }

            base.Dispose();
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.WinForms.Button();
            this.button2 = new System.WinForms.Button();
            this.progressBar1 = new System.WinForms.ProgressBar();

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.Text = "Built using the Designer";
            this.ClientSize = new System.Drawing.Size(392, 117);

            button1.Size = new System.Drawing.Size(120, 40);
            button1.TabIndex = 1;
            button1.Font = new System.Drawing.Font("TAHOMA", 8f, System.Drawing.FontStyle.Bold);
            button1.Text = "Start!";
            button1.Location = new System.Drawing.Point(130, 64);
            button1.Click += new System.EventHandler(button1_Click);

            button2.Size = new System.Drawing.Size(120, 40);
            button2.TabIndex = 1;
            button2.Font = new System.Drawing.Font("TAHOMA", 8f, System.Drawing.FontStyle.Bold);
            button2.Text = "Stop!";
            button2.Location = new System.Drawing.Point(256, 64);
            button2.Click += new System.EventHandler(button2_Click);

            progressBar1.Size = new System.Drawing.Size(350, 40);
            progressBar1.TabIndex = 2;
            progressBar1.Font = new System.Drawing.Font("TAHOMA", 8f, System.Drawing.FontStyle.Bold);
            progressBar1.Text = "Start!";
            progressBar1.Location = new System.Drawing.Point(10, 10);
            progressBar1.Step = 10;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;

            this.Controls.Add(button1);
            this.Controls.Add(button2);
            this.Controls.Add(progressBar1);
	    }

        public static void Main(string[] args) {
            Application.Run(new ThreadMarshal());
        }


    }
}











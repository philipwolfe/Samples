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
namespace Microsoft.Samples.WinForms.Cs.ErrorHandler {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.WinForms;
    using System.Threading;
    
    //The Error Handler class
    //We need a class because event handling methods can't be static
    internal class CustomExceptionHandler {

        //Handle the exception  event
        public void OnThreadException(object sender, ThreadExceptionEventArgs t) {

            DialogResult result = DialogResult.Cancel;
            try {
                result = this.ShowThreadExceptionDialog(t.exception);
            }
            catch {
                try {
                    MessageBox.Show("Fatal Error", "Fatal Error", MessageBox.IconStop|MessageBox.AbortRetryIgnore);
                }
                finally {
                    Application.Exit();
                }
            }

            if (result == DialogResult.Abort) 
                Application.Exit();

        }

        private DialogResult ShowThreadExceptionDialog(Exception e) {
            string errorMsg = "An error occurred please contact the adminstrator with the following information:\n\n";
            errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, "Application Error", MessageBox.IconStop|MessageBox.AbortRetryIgnore);
        }
    }

    public class ErrorHandler : System.WinForms.Form {
        private System.ComponentModel.Container components;
        private System.WinForms.Button button1;

        public ErrorHandler() {
            
            // Required by the Windows Forms Designer
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call

        }

        public override void Dispose() {
            base.Dispose();
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.WinForms.Button();

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.Text = "Exception Handling Sample";
            this.ClientSize = new System.Drawing.Size(392, 117);

            button1.Size = new System.Drawing.Size(120, 40);
            button1.TabIndex = 1;
            button1.Font = new System.Drawing.Font("TAHOMA", 8f, System.Drawing.FontStyle.Bold);
            button1.Text = "Click Me!";
            button1.Location = new System.Drawing.Point(256, 64);
            button1.Click += new System.EventHandler(button1_Click);

            this.Controls.Add(button1);
	    }

        private void button1_Click(object sender, System.EventArgs e) {
            throw new ArgumentException("The parameter was invalid");
        }


        public static void Main(string[] args) {
            CustomExceptionHandler eh = new CustomExceptionHandler();
            Application.ThreadException += new ThreadExceptionEventHandler(eh.OnThreadException);
            Application.Run(new ErrorHandler());
        }


    }
}











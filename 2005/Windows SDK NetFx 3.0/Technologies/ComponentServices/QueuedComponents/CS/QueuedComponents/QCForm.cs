//-----------------------------------------------------------------------
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
/*=====================================================================
  File:  QCForm.cs

  Summary:   .NET Client App For Generating Queued Messages

=====================================================================*/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Microsoft.Samples.Technologies.ComponentServices.QueuedComponents
{

    public class QCForm : Form
    {
        private Button sendMsg;
        private TextBox msgToSend;

        public QCForm()
        {
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            this.sendMsg = new Button();
            this.msgToSend = new TextBox();

            sendMsg.Location = new System.Drawing.Point (24, 40);
            sendMsg.Size = new System.Drawing.Size (140, 24);
            sendMsg.TabIndex = 1;
            sendMsg.Text = "Send Queued Msg";
            sendMsg.Click += new EventHandler (this.SendMsg_Click);

            msgToSend.Location = new System.Drawing.Point (24, 80);
            msgToSend.Size = new System.Drawing.Size (140, 24);
            msgToSend.Text = "Hello Queued Component!";

            this.Text = "Queued components";
            this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
            this.ClientSize = new System.Drawing.Size (200, 150);
            this.Controls.Add (this.sendMsg);
            this.Controls.Add (this.msgToSend);
        }

    
        // Create the queued component, call it, and release it
        private void SendMsg_Click (object sender, System.EventArgs e)
        {
            IQComponent iQC;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                // invoke an instance of our queued component using a queue moniker
                // this provides a client reference that's called into as if it were an actual
                // instance of the server component
                iQC = (IQComponent)Marshal.BindToMoniker("queue:/new:Microsoft.Samples.Technologies.ComponentServices.QueuedComponents.QComponent");

                // Call into the queued component. if we're not connected to an activated
                // server object, this will place a packaged message in the QCDemoSvr queue.
                iQC.DisplayMessage (msgToSend.Text);

                // appropriate method for releasing our queued component
                Marshal.ReleaseComObject(iQC);
            }
       
            catch (Exception ex)
            {
                MessageBox.Show("An exception was caught : " + ex.Message + "\nMake sure you installed MSMQ and runned REGSVCS.EXE as explained in the README of this sample!" , "Error");
            }

            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

 
        [STAThread()]
        public static void Main(string[] args) 
        {
            Application.Run(new QCForm());
        }
    }
}
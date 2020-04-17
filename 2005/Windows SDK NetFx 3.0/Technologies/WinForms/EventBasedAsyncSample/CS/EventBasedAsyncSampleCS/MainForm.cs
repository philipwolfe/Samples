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
using System.Windows.Forms;

#endregion

namespace Microsoft.Samples.Windows.Forms.EventBasedAsync
{

    partial class MainForm : Form {

        private AsyncPictureBoxForm asyncPictureBoxForm;
        private AsyncWebClientForm asyncWebClientForm;
        private AsyncWebServiceForm asyncWebServiceForm;
        private SimpleBackgroundWorkerForm simpleBackgroundWorkerForm;

        public MainForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Displays the PictureBox Async sample form
        /// </summary>
        private void btnAsyncPictureBoxSample_Click(System.Object sender, System.EventArgs e) {
            if (Application.OpenForms["AsyncPictureBoxForm"] != null) {
                asyncPictureBoxForm.BringToFront();
            } else {
                asyncPictureBoxForm = new AsyncPictureBoxForm();
                asyncPictureBoxForm.Show();
            }
        }

        /// <summary>
        /// Displays the WebClient Async sample form
        /// </summary>
        private void btnAsyncWebClientSample_Click(System.Object sender, System.EventArgs e) {
            if (Application.OpenForms["AsyncWebClientForm"] != null) {
                asyncWebClientForm.BringToFront();
            } else {
                asyncWebClientForm = new AsyncWebClientForm();
                asyncWebClientForm.Show();
            }
        }

        /// <summary>
        /// Displays the WebService Async sample form
        /// </summary>
        private void btnAsyncWebServiceSample_Click(System.Object sender, System.EventArgs e) {
            if (Application.OpenForms["AsyncWebServiceForm"] != null) {
                asyncWebServiceForm.BringToFront();
            } else {
                asyncWebServiceForm = new AsyncWebServiceForm();
                asyncWebServiceForm.Show();
            }
        }

        /// <summary>
        /// Displays the BackgroundWorker sample form
        /// </summary>
        private void btnBackgroundWorkerSample_Click(System.Object sender, System.EventArgs e) {
            if (Application.OpenForms["SimpleBackgroundWorkerForm"] != null) {
                simpleBackgroundWorkerForm.BringToFront();
            } else {
                simpleBackgroundWorkerForm = new SimpleBackgroundWorkerForm();
                simpleBackgroundWorkerForm.Show();
            }
        }
    }
}





//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

namespace WinFormTestHost
{
  public partial class Form1 : Form
	{
		private WorkflowRuntime wr;

		public Form1()
		{
			InitializeComponent();
        }

		private void btnStartWorkflow_Click(object sender, EventArgs e)
		{
            if (wr == null)
            {
                wr = new WorkflowRuntime();
                wr.StartRuntime();
            }

			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add("FirstName", txtFirstName.Text);
			parameters.Add("LastName", txtLastName.Text);

            WorkflowInstance instance = wr.CreateWorkflow(typeof(HelloWorldWorkflow.Workflow1), parameters);
            instance.Start();
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (wr != null)
			{
				if (wr.IsStarted)
				{
					wr.StopRuntime();
				}
			}
		}
	}
}
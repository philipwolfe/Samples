//--------------------------------------------------------------------------------
// This file is a Windows Workflow Foundation "Sample" built by
// Customer Support & Services
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
using System.Workflow.Activities;
using System.Workflow.Runtime;
using System.Threading;
using System.Windows.Forms;

namespace SimpleCommunication
{
    [Serializable]
    public class MyExternalDataEventArgs : ExternalDataEventArgs
    {
        public MyExternalDataEventArgs(Guid InstanceID, string strValue)
            : base(InstanceID)
        {
            this.Value = strValue;
        }

        #region Implementation

        private string strValue;

        public string Value
        {
            get { return strValue; }
            set { strValue = value; }
        }

        #endregion
    }

    [ExternalDataExchange]
    public interface ILocalService
    {
        // The host raises this event to the Workflow
        event EventHandler<MyExternalDataEventArgs> WorkComplete;

        // The workflow calls this method
        void GetResult();
    }

    public class LocalService : ILocalService
    {
        public event EventHandler<MyExternalDataEventArgs> WorkComplete;

        public void GetResult()
        {
            Console.WriteLine("Queuing up to get answer from user");
            ThreadPool.QueueUserWorkItem(GetResultWork, WorkflowEnvironment.WorkflowInstanceId);
        }

        private void GetResultWork(object o)
        {
            // Prompt the user for the "Result"
            DialogResult r = MessageBox.Show("Please choose Yes or No", "Results", MessageBoxButtons.YesNo);

            MyExternalDataEventArgs args = new MyExternalDataEventArgs((Guid)o, r.ToString());

            Console.WriteLine("Dispatching results to Workflow");
            if (WorkComplete != null)
            {
                WorkComplete(null, args);
            }
        }
    }
}

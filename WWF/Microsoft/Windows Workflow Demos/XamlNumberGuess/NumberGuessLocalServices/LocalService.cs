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
using System.Collections.Generic;
using System.Text;
using System.Workflow.Activities;
using System.Workflow.Runtime;

namespace NumberGuessWorkflowLibrary
{
    [Serializable]
    public class MyExternalDataEventArgs : ExternalDataEventArgs
    {
        public MyExternalDataEventArgs(Guid InstanceID, int Guess)
            : base(InstanceID)
        {
            this.Guess = Guess;
        }

        private int guess;

        public int Guess
        {
            get { return guess; }
            set { guess = value; }
        }
    }

    [ExternalDataExchange]
    public interface ILocalService
    {
        // The host raises this event to the Workflow
        event EventHandler<MyExternalDataEventArgs> GuessEntered;

        // The workflow calls this method
        void SetMessage(string msg);
    }
}

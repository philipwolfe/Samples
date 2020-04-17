//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation Sample Code.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Workflow.Activities;

namespace SendDataToStateMachine
{
	[Serializable]
    public class CompletedEventArgs : ExternalDataEventArgs
    {
        private string reason;

        public CompletedEventArgs(Guid instanceId, string reason)
            : base(instanceId)
        {
            this.reason = reason;
            this.WaitForIdle = true;
        }

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
    }

    [ExternalDataExchange]
    public interface IMyService
    {
        event EventHandler<CompletedEventArgs> Completed;
    }

    public class MyService : IMyService
    {
        public void RaiseEvent(CompletedEventArgs args)
        {
            EventHandler<CompletedEventArgs> completed = this.Completed;
            if (completed != null)
                completed(null, args);
        }

        public event EventHandler<CompletedEventArgs> Completed;
    }
}

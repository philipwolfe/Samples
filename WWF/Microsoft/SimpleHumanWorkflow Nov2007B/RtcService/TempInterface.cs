//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
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
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;
using System.IO;
using System.Xml;
using SmtpMailActivityLibrary.Interfaces;
using RTCCORELib;

namespace RtcActivityLibrary.Interfaces
{
    [Serializable]
    public class RtcMessageEventArgs : ExternalDataEventArgs
    {
        private string uri;
        public string Uri
        {
            get { return uri; }
        }

        
        private string message;
        public string Message
        {
            get { return message; }
        }

        
        public RtcMessageEventArgs(Guid InstId, string Uri, string Message)
            : base(InstId)
        {
            this.uri = Uri;
            this.message = Message;
        }
    }

    [ExternalDataExchange]
    [CorrelationParameter("Uri")]
    public interface IRtcCommunication
    {
        void SetStatus(RTC_PRESENCE_STATUS Status);
        RTC_PRESENCE_STATUS GetStatus(string Uri);
        [CorrelationInitializer]
        void SendMessage(string Uri, string Message);
        [CorrelationAlias("Uri", "e.Uri")]
        event EventHandler<SmtpMailEventArgs> SmtpMailReceived;
    }

}

 
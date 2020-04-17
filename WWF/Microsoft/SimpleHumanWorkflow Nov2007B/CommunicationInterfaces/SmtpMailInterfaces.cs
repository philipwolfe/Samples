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

namespace SmtpMailActivityLibrary.Interfaces
{

    public enum SmtpEMailType
    {
        PlainText=0,
        HtmlText=1
    }

    [Serializable]
    public class SmtpMailEventArgs : ExternalDataEventArgs
    {
        private Guid messageId;
        public Guid MessageId
        {
            get { return messageId; }
        }

        private string to;
        public string To
        {
            get { return to; }
        }

        private string from;
        public string From
        {
            get { return from; }
        }

        private string subject;
        public string Subject
        {
            get { return subject; }
        }

        private string body;
        public string Body
        {
            get { return body; }
        }

        private SmtpEMailType mailType;
        public SmtpEMailType MailType
        {
            get { return mailType; }
        }
        
        
        public SmtpMailEventArgs(Guid InstId,Guid MessageId, string To, string From,
            string Subject, string Body, SmtpEMailType MailType)
            :base(InstId)
        {
            this.messageId = MessageId;
            this.to = To;
            this.from = From;
            this.subject = Subject;
            this.body = Body;
            this.mailType = MailType;
        }
    }
    
    [ExternalDataExchange]
    [CorrelationParameter("MessageId")]
    public interface ISmtpCommunication
    {
        [CorrelationInitializer]
        void SendEmail(Guid MessageId, string To, string From,
            string Subject, string Body, SmtpEMailType MailType);
        [CorrelationAlias("MessageId", "e.MessageId")]
        event EventHandler<SmtpMailEventArgs> SmtpMailReceived;
    }

}

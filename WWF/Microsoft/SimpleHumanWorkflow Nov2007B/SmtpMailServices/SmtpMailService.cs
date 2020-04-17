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
using SmtpMailActivityLibrary.Interfaces;
using System.Text.RegularExpressions;

namespace SmtpMailActivityLibrary.Services
{
    public abstract class SmtpMailService : ISmtpCommunication
    {

        #region ISmtpCommunication Members

        protected SubscriptionService.SubscriptionService subscriptionService;

        public abstract void SendEmail(Guid MessageId, string To, string From, string Subject, string Body, SmtpEMailType MailType);

        private event EventHandler<SmtpMailActivityLibrary.Interfaces.SmtpMailEventArgs> smtpMailReceived;
        public event EventHandler<SmtpMailActivityLibrary.Interfaces.SmtpMailEventArgs> SmtpMailReceived
        {
            add
            {
                this.smtpMailReceived += value;
            }
            remove
            {
                this.smtpMailReceived -= value;
            }
        }

        #endregion

        
        public void RaiseSmtpMailReceived(object state)
        {

            SmtpMailEventArgs args = (SmtpMailEventArgs)state;
           

            if (smtpMailReceived != null)
            {
                Console.WriteLine("Service receipt of email from:" + args.From);
                try
                {
                    smtpMailReceived(null, args);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
             
        }

        public abstract void StartSmtpTracking();

        #region Utility Methods
        protected static string ParseInstIdFromString(string textToParse)
        {
            string instIdSubject;
            try
            {
                Regex regex = new Regex("<id(?<instid>[^ >]+)id>");
                Match match = regex.Match(textToParse);
                if (match.Success)
                    instIdSubject = match.Groups["instid"].Value;
                else
                    instIdSubject = "";
            }
            catch (Exception ex)
            {
                instIdSubject = "";
                Console.WriteLine(ex.Message);
            }
            return instIdSubject;
        }
        #endregion

    }
}

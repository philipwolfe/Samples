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
using System.Threading;
using System.Reflection;  
using SmtpMailActivityLibrary.Interfaces;
using Microsoft.Office.Interop.Outlook;

namespace SmtpMailActivityLibrary.Services
{
    public class SmtpOutlookMailService:SmtpMailService
    {
        Microsoft.Office.Interop.Outlook.ApplicationClass outlookApp;

        public SmtpOutlookMailService(SubscriptionService.SubscriptionService subscriptionService)
        {
            //Initialize our OutlookApplication 
            outlookApp = new ApplicationClass();
            this.subscriptionService = subscriptionService;

            outlookApp.NewMailEx += new ApplicationEvents_11_NewMailExEventHandler(outlookApp_NewMailEx);
            
        }

        public override void StartSmtpTracking()
        {
            return;
        }

        void outlookApp_NewMailEx(string EntryIDCollection)
        {
            NameSpace outlookNS = outlookApp.GetNamespace("MAPI");
            MAPIFolder mFolder =
                outlookApp.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            MailItem newMail = (MailItem)
                outlookNS.GetItemFromID(EntryIDCollection, mFolder.StoreID);

            //Don't bother checking the headers for the MessageId in Outlook as Outlook doesn't have support for the References header.
            string instIdSubject = "";

            //***************************************************************
            //HACK HACK HACK
            //We check that the first 3 chars of the subject are 'RE:' here
            //Reason we do this is so that the whole solution can run on a single Outlook mail box.
            //So we check for RE: so that only replies are actually raised back into the workflow.
            //If you have a dedicated instance of Outlook acting as a mailbox for the workflow itself
            //then you can remove this checked.
            //***************************************************************
            if (newMail.Subject.Substring(0, 3).ToUpper() != "RE:")
                return;

            instIdSubject = ParseInstIdFromString(newMail.Subject);

            Guid messageId = Guid.Empty;
            //Give priority to the RFC Compliant Header
            if (instIdSubject.Trim().Length == 36)
            {
                messageId = new Guid(instIdSubject);
            }
            else
            {
                //Can't find an instance ID to Correlate with so ignore this message.
                Console.WriteLine("Unable to Correlate. No instance ID present");
                return;
            }


            if (messageId != Guid.Empty)
            {


                Guid workflowInstanceId = this.subscriptionService.FindInstanceIdBySubscription(
                        typeof(ISmtpCommunication),
                        "SmtpMailReceived",
                        new string[] { "MessageId" },
                        new object[] { messageId });

                if (newMail.HTMLBody.Length > 0)
                {
                    //Favour HTML
                    ThreadPool.QueueUserWorkItem(new WaitCallback(RaiseSmtpMailReceived),
                                    new SmtpMailActivityLibrary.Interfaces.SmtpMailEventArgs(workflowInstanceId,messageId, newMail.To, newMail.SenderEmailAddress, newMail.Subject, newMail.Body, SmtpEMailType.HtmlText));
                }
                else
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(RaiseSmtpMailReceived),
                                    new SmtpMailActivityLibrary.Interfaces.SmtpMailEventArgs(workflowInstanceId,messageId, newMail.To, newMail.SenderEmailAddress, newMail.Subject, newMail.Body, SmtpEMailType.PlainText));
                }
            }

        }

        public override void SendEmail(Guid MessageId, string To, string From, string Subject, string Body, SmtpMailActivityLibrary.Interfaces.SmtpEMailType MailType)
        {
            Console.WriteLine("Sending Email To:" + To);

            NameSpace outlookNS = outlookApp.GetNamespace("MAPI");

            Recipients oRecips;
            MailItem oMsg;
            Recipient oRecip;

            try
            {
                //Login using a dialog.
                //See http://support.microsoft.com/default.aspx?scid=kb;en-us;310262
                //for details on how to suppress the dialog and just login with fixed details.
                outlookNS.Logon(Missing.Value, Missing.Value, true, true);

                oMsg = (MailItem)outlookApp.CreateItem(OlItemType.olMailItem);

                oMsg.Subject = Subject;


                if (MailType == SmtpEMailType.HtmlText)
                    oMsg.HTMLBody = Body;
                else
                    oMsg.Body = Body;

                //Add the recipient - we do not set From as that will be set by the Outlook profile we logged into
                oRecips = (Recipients)oMsg.Recipients;
                
                oRecip = (Recipient)oRecips.Add(To);
                oRecip.Resolve();

                //Add the correlation tracking details
                oMsg.Subject = oMsg.Subject + new string(' ', 100) + "<id" + MessageId.ToString() + "id>";

                oMsg.Send();
            }
            finally
            {
                outlookNS.Logoff();
                oRecip = null;
                oRecips = null;
                oMsg = null;
                outlookNS = null;
            }
            
        }
    }
}

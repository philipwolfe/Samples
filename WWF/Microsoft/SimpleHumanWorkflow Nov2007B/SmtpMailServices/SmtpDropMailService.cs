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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Activities;
using System.Workflow.Runtime;
using System.Workflow.Activities.Rules;
using System.Threading;
using SmtpMailActivityLibrary.Interfaces;
using System.Net.Mail;
using System.IO;
using System.Text.RegularExpressions;
    
namespace SmtpMailActivityLibrary.Services
{
    [Serializable]
    public class SmtpDropMailService:SmtpMailService,IDisposable  
    {
        private string smtpServer;
        private string dropDirectory;
        private FileSystemWatcher fsw;

        public SmtpDropMailService(string smtpServer, string dropDirectory,SubscriptionService.SubscriptionService subscriptionService)
        {
            this.smtpServer = smtpServer;
            this.dropDirectory = dropDirectory;
            this.subscriptionService = subscriptionService;

            //Setup the FS Watcher for delivery of emails.
            fsw = new FileSystemWatcher(dropDirectory, "*.eml");
            fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fsw.Created += new FileSystemEventHandler(fsw_Created);
                        
        }

        public override void StartSmtpTracking()
        {
            fsw.EnableRaisingEvents = true;
            ProcessDropDirectory();
        }

        private void ProcessDropDirectory()
        {
            fsw.EnableRaisingEvents = false;
            CDO.DropDirectory iDropDir = new CDO.DropDirectory();
            CDO.IMessages iMsgs;
            CDO.IMessage iMsg;

            iMsgs = iDropDir.GetMessages(dropDirectory);
            Console.WriteLine("Processing SMTP Drop Directory Message Count: " + iMsgs.Count);

            //Sleep the thread to wait for the SMTP service to release the file.
            //This is an unfortunate side effect of the FileSystemWatcher firing before the 
            //SMTP service is finished with the msg file.
            Thread.Sleep(1000);

            try
            {
                //CDO using 1 indexed arrays
                for (int i = 1; i < iMsgs.Count + 1; i++)
                {
                    iMsg = iMsgs[i];

                    //Try to pull the instId off the message.
                    //We try to use headers and the subject.
                    //Headers
                    string messageIdReferences = "";

                    try
                    {
                        messageIdReferences = iMsg.Fields["urn:schemas:mailheader:references"].Value.ToString();
                    }
                    catch (NullReferenceException ex)
                    {
                        messageIdReferences = "";
                        Console.WriteLine(ex.Message);
                    }
                    //Subject
                    string messageIdSubject = "";
                    messageIdSubject = ParseInstIdFromString(iMsg.Subject);

                    Guid messageId = Guid.Empty;
                    //Give priority to the RFC Compliant Header
                    if (messageIdReferences.Trim().Length == 36)
                    {
                        messageId = new Guid(messageIdReferences);
                    }
                    else if (messageIdSubject.Trim().Length == 36)
                    {
                        messageId = new Guid(messageIdSubject);
                    }
                    else
                    {
                        //Can't find an instance ID to Correlate with so ignore this message.
                        Console.WriteLine("Unable to Correlate. No instance ID present");
                    }

                    if (messageId != Guid.Empty)
                    {

                        Guid workflowInstanceId = this.subscriptionService.FindInstanceIdBySubscription(
                        typeof(ISmtpCommunication),
                        "SmtpMailReceived",
                        new string[] { "MessageId" },
                        new object[] { messageId });

                        if (iMsg.HTMLBody.Length > 0)
                        {
                            //Favour HTML
                            ThreadPool.QueueUserWorkItem(new WaitCallback(RaiseSmtpMailReceived),
                                        new SmtpMailActivityLibrary.Interfaces.SmtpMailEventArgs(workflowInstanceId,messageId, iMsg.To, iMsg.From, iMsg.Subject, iMsg.HTMLBody, SmtpEMailType.HtmlText));
                        }
                        else
                        {
                            ThreadPool.QueueUserWorkItem(new WaitCallback(RaiseSmtpMailReceived),
                                        new SmtpMailActivityLibrary.Interfaces.SmtpMailEventArgs(workflowInstanceId,messageId, iMsg.To, iMsg.From, iMsg.Subject, iMsg.TextBody, SmtpEMailType.PlainText));
                        }
                    }

                }

                //Delte all the mesages we have processed.
                iMsgs.DeleteAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed while parsing messages:" + ex.Message);
                //Rethrow to the host
                throw;
            }
            finally
            {
                iMsg = null;
                iMsgs = null;
                iDropDir = null;
                fsw.EnableRaisingEvents = true;
            }
        }
        private void fsw_Created(object sender, FileSystemEventArgs e)
        {
            ProcessDropDirectory();
        }

        public override void SendEmail(Guid MessageId, string To, string From, string Subject, string Body, SmtpEMailType MailType)
        {
            Console.WriteLine("Sending Email To:" + To);
            
            //Setup mail message
            MailMessage msg = new MailMessage(From,To,Subject,Body); 
            msg.IsBodyHtml = MailType == SmtpEMailType.HtmlText;

          
            //Add the correlation tracking headers
            //We add both References [RFC822 4.6.3] (for non Outllok clients) 
            //and a subject tracking entry from Outlook clients as Outlook does not support References
            msg.Headers.Add("references", MessageId.ToString());
            msg.Subject = msg.Subject + new string(' ', 100) + "<id" + MessageId.ToString() + "id>";

            //Send
            SmtpClient client = new SmtpClient(smtpServer);
            client.Send(msg);
 
        }




        #region IDisposable Members

        public void Dispose()
        {
            this.fsw.Dispose();
        }

        #endregion
    }
}
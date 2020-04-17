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
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace SmtpMailActivityLibrary.Services
{
    [Serializable]
    public class ExchangeWebDavMailService : SmtpMailService, IDisposable
    {
        private string smtpServer;
        private string mailBoxUri;
        private string userName;
        private string password;
        private System.Windows.Forms.Timer timer;

        public ExchangeWebDavMailService(string smtpServer, string mailBoxUri, string userName, string password, int timerInterval, SubscriptionService.SubscriptionService subscriptionService)
        {
            this.smtpServer = smtpServer;
            this.mailBoxUri = mailBoxUri;
            this.userName = userName;
            this.password = password;
            this.subscriptionService = subscriptionService;

            //Setup a timer to poll the server looking for new emails
            timer = new System.Windows.Forms.Timer();
            timer.Interval = timerInterval;
            timer.Tick += new EventHandler(timer_Tick);

        }

        void timer_Tick(object sender, EventArgs e)
        {
            ProcessMailBox();
        }

        public override void StartSmtpTracking()
        {
            timer.Start();
        }

        private void ProcessMailBox()
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(GetMessageListXML(mailBoxUri, userName, password));
            XmlNamespaceManager nsm = new XmlNamespaceManager(xml.NameTable);
            nsm.AddNamespace("a", "DAV:");
            nsm.AddNamespace("d", "urn:schemas:httpmail:");
            nsm.AddNamespace("h", "urn:schemas:mailheader:");

            foreach (XmlNode node in xml.SelectNodes("//a:response", nsm))
            {
                string messageUri = node.SelectSingleNode("./a:href", nsm).InnerText;
                string subject = node.SelectSingleNode("./a:propstat/a:prop/d:subject", nsm).InnerText;
                string to = node.SelectSingleNode("./a:propstat/a:prop/h:to", nsm).InnerText;
                string from = node.SelectSingleNode("./a:propstat/a:prop/d:fromemail", nsm).InnerText;
                string textBody = node.SelectSingleNode("./a:propstat/a:prop/d:textdescription", nsm).InnerText;
                string htmlBody = node.SelectSingleNode("./a:propstat/a:prop/d:htmldescription", nsm).InnerText;
                string references="";
                if(node.SelectSingleNode("./a:propstat/a:prop/h:references", nsm) != null)
                    references = node.SelectSingleNode("./a:propstat/a:prop/h:references", nsm).InnerText;
                                
                Console.WriteLine("Processing Message:" + messageUri);
                //Try to pull the instId off the message.
                //We try to use headers and the subject.
                //Headers
                string messageIdReferences = "";

                try
                {
                    messageIdReferences = references;
                }
                catch (NullReferenceException ex)
                {
                    messageIdReferences = "";
                    Console.WriteLine(ex.Message);
                }
                //Subject
                string messageIdSubject = "";
                messageIdSubject = ParseInstIdFromString(subject);

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

                    if (htmlBody.Length > 0)
                    {
                        //Favour HTML
                        ThreadPool.QueueUserWorkItem(new WaitCallback(RaiseSmtpMailReceived),
                                    new SmtpMailActivityLibrary.Interfaces.SmtpMailEventArgs(workflowInstanceId, messageId, to, from, subject, htmlBody, SmtpEMailType.HtmlText));
                    }
                    else
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(RaiseSmtpMailReceived),
                                    new SmtpMailActivityLibrary.Interfaces.SmtpMailEventArgs(workflowInstanceId, messageId, to, from, subject, textBody, SmtpEMailType.PlainText));
                    }
                }
                MarkMessageAsRead(messageUri, userName, password);
            }




        }


        private void fsw_Created(object sender, FileSystemEventArgs e)
        {
            ProcessMailBox();
        }

        public override void SendEmail(Guid MessageId, string To, string From, string Subject, string Body, SmtpEMailType MailType)
        {
             Console.WriteLine("Sending Email To:" + To);

            //Setup mail message
            MailMessage msg = new MailMessage(From, To, Subject, Body);
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


        private string MarkMessageAsRead(string sMessageUri, string sUserName, string sPassword)
        {
            System.Uri myUri = new System.Uri(sMessageUri);
            HttpWebRequest HttpWRequest = (HttpWebRequest)WebRequest.Create(myUri);
            string sQuery;
            sQuery = sQuery = "<?xml version='1.0'?>" +
                "<g:propertyupdate xmlns:g='DAV:' xmlns:m='urn:schemas:httpmail:'>" +
                //"<g:target>"+
                //"<g:href> " + sMessageUri + "</g:href> " +
                //"</g:target>" +
                "<g:set>" +
                "<g:prop><m:read>1</m:read></g:prop> " +
                "</g:set>" +
                "</g:propertyupdate>";
            NetworkCredential myCred = new NetworkCredential(sUserName, sPassword);
            CredentialCache MyCredentialCache;
            //  = New CredentialCache
            if ((sUserName != ""))
            {
                //  Use Basic Authentication
                myCred = new NetworkCredential(sUserName, sPassword);
                MyCredentialCache = new CredentialCache();
                MyCredentialCache.Add(myUri, "Basic", myCred);
                HttpWRequest.Credentials = MyCredentialCache;
                // HttpWRequest.UnsafeAuthenticatedConnectionSharing = True ' Need this so you dont get an error on HttpWRequest.GetRequestStream()
            }
            else
            {
                //  Use Windows Authentication
                HttpWRequest.Credentials = CredentialCache.DefaultCredentials;
                // HttpWRequest.UnsafeAuthenticatedConnectionSharing = True ' Need this so you dont get an error on HttpWRequest.GetRequestStream()
            }
            //  Set some headers
            HttpWRequest.KeepAlive = false;
            HttpWRequest.Headers.Set("Pragma", "no-cache");
            HttpWRequest.Headers.Set("Translate", "f");
            HttpWRequest.Headers.Set("Depth", "0");
            HttpWRequest.ContentType = "text/xml";
            HttpWRequest.ContentLength = sQuery.Length;
            // set the request timeout to 5 min.
            HttpWRequest.Timeout = 300000;
            //  set the request method
            HttpWRequest.Method = "PROPPATCH";
            byte[] ByteQuery = System.Text.Encoding.ASCII.GetBytes(sQuery);
            HttpWRequest.ContentLength = ByteQuery.Length;
            Stream QueryStream = HttpWRequest.GetRequestStream();
            //  write the data to be posted to the Request Stream
            QueryStream.Write(ByteQuery, 0, ByteQuery.Length);
            QueryStream.Close();
            //  Send Request and Get Response
            HttpWebResponse HttpWResponse = (HttpWebResponse)HttpWRequest.GetResponse();
            //  Get Status and Headers
            int iStatCode = (int)HttpWResponse.StatusCode;
            string sStatus = iStatCode.ToString();
            
            Stream strm = HttpWResponse.GetResponseStream();
            //  Read the Response Steam
            StreamReader sr = new StreamReader(strm);
            string sText = sr.ReadToEnd();
            //  Close Stream
            strm.Close();
            //  Clean Up
            HttpWRequest = null;
            HttpWResponse = null;
            MyCredentialCache = null;
            myCred = null;
            QueryStream = null;
            strm = null;
            sr = null;
            return sText;
        }

        private string GetMessageListXML(string sUri, string sUserName, string sPassword)
        {
            System.Uri myUri = new System.Uri(sUri);
            HttpWebRequest HttpWRequest = (HttpWebRequest)WebRequest.Create(myUri);
            string sQuery;
            sQuery = sQuery = "<?xml version='1.0'?>" +
                "<g:searchrequest xmlns:g='DAV:'>" +
                "<g:sql>SELECT \"DAV:displayname\", " +
                "\"DAV:href\", " +
                "\"urn:schemas:httpmail:subject\", " +
                "\"urn:schemas:httpmail:textdescription\", " +
                "\"urn:schemas:httpmail:fromemail\", " +
                "\"urn:schemas:mailheader:to\", " +
                "\"urn:schemas:httpmail:read\", " +
                "\"urn:schemas:httpmail:htmldescription\" " +
                "FROM SCOPE('SHALLOW TRAVERSAL OF \"" + sUri + "\"') " +
                "WHERE \"urn:schemas:httpmail:read\" = false " +
                "</g:sql>" +
                "</g:searchrequest>";
            NetworkCredential myCred = new NetworkCredential(sUserName, sPassword);
            CredentialCache MyCredentialCache;
            //  = New CredentialCache
            if ((sUserName != ""))
            {
                //  Use Basic Authentication
                myCred = new NetworkCredential(sUserName, sPassword);
                MyCredentialCache = new CredentialCache();
                MyCredentialCache.Add(myUri, "Basic", myCred);
                HttpWRequest.Credentials = MyCredentialCache;
                // HttpWRequest.UnsafeAuthenticatedConnectionSharing = True ' Need this so you dont get an error on HttpWRequest.GetRequestStream()
            }
            else
            {
                //  Use Windows Authentication
                HttpWRequest.Credentials = CredentialCache.DefaultCredentials;
                // HttpWRequest.UnsafeAuthenticatedConnectionSharing = True ' Need this so you dont get an error on HttpWRequest.GetRequestStream()
            }
            //  Set some headers
            HttpWRequest.KeepAlive = false;
            HttpWRequest.Headers.Set("Pragma", "no-cache");
            HttpWRequest.Headers.Set("Translate", "f");
            HttpWRequest.Headers.Set("Depth", "0");
            HttpWRequest.ContentType = "text/xml";
            HttpWRequest.ContentLength = sQuery.Length;
            // set the request timeout to 5 min.
            HttpWRequest.Timeout = 300000;
            //  set the request method
            HttpWRequest.Method = "SEARCH";
            byte[] ByteQuery = System.Text.Encoding.ASCII.GetBytes(sQuery);
            HttpWRequest.ContentLength = ByteQuery.Length;
            Stream QueryStream = HttpWRequest.GetRequestStream();
            //  write the data to be posted to the Request Stream
            QueryStream.Write(ByteQuery, 0, ByteQuery.Length);
            QueryStream.Close();
            //  Send Request and Get Response
            HttpWebResponse HttpWResponse = (HttpWebResponse)HttpWRequest.GetResponse();
            //  Get Status and Headers
            int iStatCode = (int)HttpWResponse.StatusCode;
            string sStatus = iStatCode.ToString();
            
            Stream strm = HttpWResponse.GetResponseStream();
            //  Read the Response Steam
            StreamReader sr = new StreamReader(strm);
            string sText = sr.ReadToEnd();
            //  Close Stream
            strm.Close();
            //  Clean Up
            HttpWRequest = null;
            HttpWResponse = null;
            MyCredentialCache = null;
            myCred = null;
            QueryStream = null;
            strm = null;
            sr = null;
            return sText;
        }




        #region IDisposable Members

        public void Dispose()
        {

        }

        #endregion
    }
}
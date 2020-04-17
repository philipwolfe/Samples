//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
namespace Microsoft.Samples.SendSmtpMail
{
    using System;
    using System.Activities;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Text;

    // SendMail activity allows sending mail using SMTP in Workflow applications. 
    // To achieve this goal, SendMail activity uses the functionality in System.Net.Mail.
    // To use this activity, you will need to have access to an operational SMTP server.
    public sealed class SendMail : CodeActivity
    {
        public string Host { get; set; }
        public MailAddress From { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [IsRequired]
        public InArgument<MailAddressCollection> To { get; set; }

        [IsRequired]
        public InArgument<string> Subject { get; set; }
        public InArgument<string> Body { get; set; }
        public InArgument<Collection<Attachment>> Attachments { get; set; }
        public InArgument<MailAddressCollection> CC { get; set; }
        public InArgument<MailAddressCollection> Bcc { get; set; }
        public InArgument<IDictionary<string, string>> Tokens { get; set; }
        public string BodyTemplateFilePath { get; set; }
        public MailAddress TestMailTo { get; set; }
        public string TestDropPath { get; set; }
		
		public SendMail()
        {
            this.Port = 25;
        }

        protected override void OnOpen(DeclaredEnvironment environment)
        {
            if (string.IsNullOrEmpty(this.Host))
            {
                throw new ValidationException("Property 'Host' of SendMail activity cannot be null or empty");
            }

            if (this.From == null)
            {
                throw new ValidationException("Property 'From' of SendMail activity cannot be null or empty");
            }

            if (this.Port <= 0)
            {
                throw new ValidationException("The value of property 'Port' of SendMail activity must be larger than 0");
            }

            if (this.BodyTemplateFilePath != null && !File.Exists(this.BodyTemplateFilePath))
            {
                throw new ValidationException("The provided path for the body template (argument 'BodyTemplateFilePath') does not exist or access is denied.");
            }
        }

        protected override void Cancel(AsyncOperationContext context)
        {
            SmtpClient client = (SmtpClient)context.UserState;
            if (client != null)
            {
                client.SendAsyncCancel();
                context.CancelOperation();
            }
        }

        // Replaces tokens found in the body with the values specified 
        // by the user in the tokens dictionary
        private void ReplaceTokensInBody(CodeActivityContext context)
        {
            IDictionary<string, string> t = Tokens.Get(context);

            string tmpBody = this.Body.Get(context);

            foreach (string key in t.Keys)
            {
                tmpBody = tmpBody.Replace(key, t[key]);
            }

            this.Body.Set(context, tmpBody);
        }

        // Loads a template for the body of the mail if the 
        // bodyTemplateFile property is specified
        private void LoadBodyTemplate(CodeActivityContext context)
        {
            if (!string.IsNullOrEmpty(this.BodyTemplateFilePath))
            {
                using (StreamReader re = File.OpenText(this.BodyTemplateFilePath))
                {
                    this.Body.Set(context, re.ReadToEnd());
                }
            }
        }

        // If a testMailToAdress is specified, then 1) the to of the message
        // is changed to that address and 2) a note is added at the bottom of the email
        private void AddTestInformationToBody(CodeActivityContext context)
        {
            StringBuilder buffer = new StringBuilder();

            buffer.Append("<br/>");
            buffer.Append("<hr/>");
            buffer.Append(string.Format("<b>Test Mode</b> - TestMailTo address is {0}", this.TestMailTo.Address));
            buffer.Append("<hr/>");

            string bodyWithTestInfo = this.Body.Get(context) + buffer.ToString();

            this.Body.Set(context, bodyWithTestInfo);
        }

        // If testMailDropPath attribute is set, the email is written in files
        // in that path: 
        //    xxxx.body.html with body 
        //    xxxx.data.txt with message data (from, to, cc, bcc, and subject)
        private void WriteMailInTestDropPath(CodeActivityContext context)
        {
            // create file with Html of the body
            string testDropBodyFileName = string.Format("{0}\\{1}.body.htm", this.TestDropPath, DateTime.Now.ToString("yyyyMMddhhmmssff"));
            using (TextWriter writer = new StreamWriter(testDropBodyFileName))
            {
                writer.Write(this.Body.Get(context));
            }

            // create file with from, to, cc, bcc, subject
            string testDropDataFileName = string.Format("{0}\\{1}.data.txt", this.TestDropPath, DateTime.Now.ToString("yyyyMMddhhmmssff"));
            MailAddressCollection toList = this.To.Get(context);
            MailAddressCollection bccList = this.Bcc.Get(context);
            MailAddressCollection ccList = this.CC.Get(context);

            using (TextWriter writer = new StreamWriter(testDropDataFileName))
            {
                writer.Write("From: {0}", this.From.Address);

                writer.Write("\r\nTo: ");
                foreach (MailAddress address in toList)
                {
                    writer.Write(string.Format("{0} ", address.Address));
                }

                if (TestMailTo != null)
                {
                    writer.WriteLine("\r\nTest MailTo Mode Enable...Address: {0}", TestMailTo.Address);
                }

                if (ccList != null)
                {
                    writer.Write("\r\nCc: ");
                    foreach (MailAddress address in ccList)
                    {
                        writer.Write("{0} ", address.Address);
                    }
                }

                if (bccList != null)
                {
                    writer.Write("\r\nBcc: ");
                    foreach (MailAddress address in bccList)
                    {
                        writer.Write("{0} ", address.Address);
                    }
                }

                writer.Write("\r\nSubject: {0}", this.Subject.Get(context));
            }
        }

        protected override void Execute(CodeActivityContext context)
        {
            MailMessage message = new MailMessage();
            message.From = this.From;

            if (TestMailTo == null)
            {
                foreach (MailAddress address in this.To.Get(context))
                {
                    message.To.Add(address);
                }

                MailAddressCollection ccList = this.CC.Get(context);
                if (ccList != null)
                {
                    foreach (MailAddress address in ccList)
                    {
                        message.CC.Add(address);
                    }
                }

                MailAddressCollection bccList = this.Bcc.Get(context);
                if (bccList != null)
                {
                    foreach (MailAddress address in bccList)
                    {
                        message.Bcc.Add(address);
                    }
                }
            }
            else
            {
                message.To.Add(TestMailTo);
            }

            Collection<Attachment> attachments = this.Attachments.Get(context);
            if (attachments != null)
            {
                foreach (Attachment attachment in attachments)
                {
                    message.Attachments.Add(attachment);
                }
            }

            if (!string.IsNullOrEmpty(this.BodyTemplateFilePath))
            {
                LoadBodyTemplate(context);
            }

            if (this.Tokens.Get(context).Count > 0)
            {
                ReplaceTokensInBody(context);
            }

            if (this.TestMailTo != null)
            {
                AddTestInformationToBody(context);
            }

            message.Subject = this.Subject.Get(context);
            message.Body = this.Body.Get(context);

            SmtpClient client = new SmtpClient();
            client.Host = this.Host;
            client.Port = this.Port;
            client.EnableSsl = this.EnableSsl;

            if (string.IsNullOrEmpty(this.UserName))
            {
                client.UseDefaultCredentials = true;
            }
            else
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(this.UserName, this.Password);
            }

            if (!string.IsNullOrEmpty(this.TestDropPath))
            {
                WriteMailInTestDropPath(context);
            }

            new SendMailHelper(this, client).Send(message, context.SetupAsyncOperationBlock());
        }

        void OnSendComplete(ActivityExecutionContext context, Bookmark bookmark, object state)
        {
            if (state != null)
            {
                Exception error = state as Exception;
                throw new InvalidOperationException(error.Message, error);
            }
        }

        class SendMailHelper
        {
            SendMail parent;
            AsyncOperationContext operationContext;
            SmtpClient client;

            internal SendMailHelper(SendMail owner, SmtpClient client)
            {
                this.client = client;
                this.parent = owner;
            }

            internal void Send(MailMessage message, AsyncOperationContext context)
            {
                this.operationContext = context;
                client.SendCompleted += new SendCompletedEventHandler(OnSendComplete);
                client.SendAsync(message, this);
            }

            void OnSendComplete(object sender, AsyncCompletedEventArgs e)
            {
                if (e.Error != null)
                {
                    this.operationContext.CompleteOperation(new BookmarkCallback(this.parent.OnSendComplete), e.Error);
                }
                else
                {
                    this.operationContext.CompleteOperation(new BookmarkCallback(this.parent.OnSendComplete), null);
                }
            }
        }
    }
}
